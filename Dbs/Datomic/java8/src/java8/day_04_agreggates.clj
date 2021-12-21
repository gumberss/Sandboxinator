(ns java8.day-04-agreggates
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

(def conn (db/open-connection))


(defn products-min-max-query [db]
  ;Count price will count prices inside a set, so, if there are two equal prices, will count only one of these
  ; So we use :with to consider the id of the entity
  (d/q '[:find (min ?price) (max ?price) (count ?price)
         :with ?p
         :where [?p :product/price ?price]]
       db))


;(pprint (products-min-max-query (d/db conn)))

(defn products-min-max-by-category-query [db]
  (d/q '[:find ?category-name (min ?price) (max ?price) (count ?price)
         :with ?p
         :where [?p :product/price ?price]
         [?p :product/category ?category-id]
         [?category-id :category/name ?category-name]]
       db))

;(pprint (products-min-max-by-category-query (d/db conn)))


(defn products-min-max-by-category-query-2 [db]
  (d/q '[:find (pull ?p [*])
         :where
         [(q '[:find (max ?price)
               :where [_ :product/price ?price]]
             $) [[?price]]]
         [?p :product/price ?price]]
       db))

(pprint (products-min-max-by-category-query-2 (d/db conn)))