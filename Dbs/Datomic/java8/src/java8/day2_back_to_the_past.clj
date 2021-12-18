(ns java8.day2-back-to-the-past
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

(def conn (db/open-connection))

(db/create-schema conn)


(pprint (let [computer (model/new-product (model/uuid) "Cool Computer" "Its so nice and amazing" 1.33M)
              toy (model/new-product (model/uuid) "Cool toy" "Its so nice and amazing" 123.33M)]
          ;@(d/transact conn [computer toy])
          ))

(pprint (let [keyboard (model/new-product (model/uuid) "Cool keyboard" "Its so nice and amazing" 3.33M)
              mouse (model/new-product (model/uuid) "Cool mouse" "Its so nice and amazing" 2.33M)]
          ;@(d/transact conn [ keyboard mouse])
          ))

;get database filtered with past date
(pprint (count (db/pull-entities (d/as-of (d/db conn) #inst "2021-12-17T17:37:35.548-00:00"))))

(pprint (count (db/pull-entities (d/as-of (d/db conn) #inst "2021-12-17T17:37:35.546-00:00"))))

(pprint (count (db/pull-entities (d/db conn))))

;(db/delete-database)