(ns java8.day-04-transactions
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

(def conn (db/open-connection))

(db/create-schema conn)

(def product
  {
   :product/price       1008.90M
   :product/name        "Big Bottle 2"
   :product/description "Big"
   :product/id          (model/uuid)
   :product/category    {:category/name "Water 2"
                         :category/id   (model/uuid)}})

(defn insert-transaction-data []
  (let [db-add-ip [:db/add "datomic.tx" :tx-data/ip "123.123.123.123"]]
    (d/transact conn (conj [product] db-add-ip))))

(insert-transaction-data)

;Get data by transaction
(defn get-products-by-ip [db ip]
  (d/q '[:find ?ip (pull ?p [*])
         :in $ ?find-ip
         :where [?t :tx-data/ip ?ip]
         [?p :product/id _ ?t]
         ]
       db ip))


(pprint (get-products-by-ip (d/db conn) "123.123.123.123"))