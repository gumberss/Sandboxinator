(ns java8.day-04-insert
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

(def conn (db/open-connection))

; Insert category and product together
(def product
  {
   :product/price 100.90M
   :product/name "Bottle 2"
   :product/description "Big"
   :product/id (model/uuid)
   :product/category {:category/name "Water 2"
                      :category/id (model/uuid)}})

(pprint (d/transact conn [product]))

; Insert product with to an existent category
(def product2
  {
   :product/price 10000000.90M
   :product/name "Bottle 370990009090"
   :product/description "Big"
   :product/id (model/uuid)
   :product/category [:category/id #uuid "24f499d4-ef39-4078-b4b7-d85ba3d5744d"]})
(pprint (d/transact conn [product2]))


(defn all-product-by-category-backward [db category-name]
  (d/q '[:find (pull ?category-id [* {:product/_category [:product/name :product/price]}])    ;_ = backward navigation
         :in $ ?category-name
         :where [?category-id :category/name ?category-name]]
       db category-name))
(def conn (db/open-connection))

(pprint (all-product-by-category-backward (d/db conn) "Water 2"))
