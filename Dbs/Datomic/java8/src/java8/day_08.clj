(ns java8.day-08
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]
            [schema.core :as s]))




(s/set-fn-validation! true)

(db/delete-database)
(def conn (db/open-connection))
(db/create-schema conn)
(db/create-example-data conn)
;
(pprint (db/pull-entities (d/db conn)))
(pprint (db/pull-categories (d/db conn)))


;(db/create-example-data conn)
(db/pull-categories (d/db conn))

;(run-transaction [update-price update-description] )

(def products  (db/pull-entities (d/db conn)))

(pprint (db/pull-product (d/db conn) (:product/id (second products))))

(pprint (db/pull-product (d/db conn) (model/uuid)))
;(pprint (db/pull-product! (d/db conn) (model/uuid)))
(pprint (db/products-with-salable (d/db conn)))
(pprint (db/find-product-with-salable (d/db conn) (:product/id (first products))))
(pprint (db/find-product-with-salable (d/db conn) (:product/id (second products))))
(pprint (db/find-product-with-salable (d/db conn) (:product/id (nth products 2))))
(:product/stock (nth products 2))