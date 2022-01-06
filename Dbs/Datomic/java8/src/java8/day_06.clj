(ns java8.day-06
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]
            [schema.core :as s]))

(s/set-fn-validation! true)

;(db/delete-database)
(def conn (db/open-connection))
(db/create-schema conn)
;(db/create-example-data conn)
;
(pprint (db/pull-entities (d/db conn)))
(pprint (db/pull-categories (d/db conn)))

(def category (model/new-category "Eletronic"))
(pprint (s/validate model/Category category))

(def computer (model/new-product (model/uuid) "Cool Computer" "Its so nice and amazing" 1.33M))
(pprint (s/validate model/Product computer))
(pprint (s/validate model/Product (assoc computer :product/category category)))

;(db/create-example-data conn)
(db/pull-categories (d/db conn))


(pprint (db/pull-entities (d/db conn)))