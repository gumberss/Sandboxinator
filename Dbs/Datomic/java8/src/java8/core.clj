(ns java8.core
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

(def conn (db/open-connection))

(db/create-schema conn)

(let [computer (model/new-product (model/uuid) "Cool Computer" "Its so nice and amazing" 123.33M)]
  (d/transact conn [computer]))

(let [computer (model/new-product (model/uuid) "Cool Keybord" "Its so nice and amazing" 23.33M)]
  (d/transact conn [computer]))

(let [computer {:product/name "Cool something"}]
  (d/transact conn [computer]))

; Database at the moment when the line is executed
(def query-db (d/db conn))

(pprint (d/q '[:find ?entity
               :where [?entity :product/name]]
             query-db))

(let [product (model/new-product (model/uuid) "Cool Keybord nice" "Its so nice and amazing" 23.33M)
      insert-result @(d/transact conn [product])
      id-product (first (vals (:tempids insert-result)))]
  (pprint insert-result)
  (pprint @(d/transact conn [[:db/add id-product :product/price 10M]]))
  (pprint @(d/transact conn [[:db/retract id-product :product/description "Its so nice and amazing"]])))



;(db/delete-database)