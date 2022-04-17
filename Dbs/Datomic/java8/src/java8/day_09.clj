(ns java8.day-09
  (:require [schema.core :as s]
            [java8.db :as db]
            [datomic.api :as d]
            [clojure.pprint :refer [pprint]]))

(s/set-fn-validation! true)

(db/delete-database)
(def conn (db/open-connection))
(db/create-schema conn)
(db/create-example-data conn)

;; (pprint (db/pull-entities (d/db conn)))

(pprint (db/products-by-category-and-digital (d/db conn) ["Eletronic" "Food"] false))