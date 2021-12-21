(ns java8.day-04-join-forward-backward
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

; "Join"
(defn all-product-and-its-categories-name [db]
  (d/q '[:find ?product-name ?category-name
         :keys product category
        :where [?product :product/name ?product-name]
         [?product :product/category ?category]
         [?category :category/name ?category-name]]
       db))
(def conn (db/open-connection))

;(pprint (all-product-and-its-categories-name (d/db conn)))

; Forward
(defn all-product-by-category [db category-name]
  (d/q '[:find (pull ?product [* {:product/category [*]}])
         :in $ ?category-name
         :where
         [?category-id :category/name ?category-name]
         [?product :product/category ?category-id]]
       db category-name))
(def conn (db/open-connection))

;(pprint (all-product-by-category (d/db conn) "Eletronic"))

;backward
(defn all-product-by-category-backward [db category-name]
  (d/q '[:find (pull ?category-id [* {:product/_category [:product/name :product/price]}])    ;_ = backward navigation
         :in $ ?category-name
         :where [?category-id :category/name ?category-name]]
       db category-name))
(def conn (db/open-connection))

(pprint (all-product-by-category-backward (d/db conn) "Eletronic"))
