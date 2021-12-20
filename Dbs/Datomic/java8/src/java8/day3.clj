(ns java8.day3
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

(def conn (db/open-connection))

(db/create-schema conn)

(let [c1 (model/new-category "Eletronic")
      c2 (model/new-category "Something")]
   (pprint @(d/transact conn [c1 c2]))
          )

(pprint (let [computer (model/new-product (model/uuid) "Cool Computer" "Its so nice and amazing" 1.33M)
              toy (model/new-product (model/uuid) "Cool toy" "Its so nice and amazing" 123.33M)]
          @(d/transact conn [computer toy])
          ))

(pprint (let [keyboard (model/new-product (model/uuid) "Cool keyboard" "Its so nice and amazing" 3.33M)
              mouse (model/new-product (model/uuid) "Cool mouse" "Its so nice and amazing" 2.33M)]
          @(d/transact conn [ keyboard mouse])
          ))

(pprint (db/pull-catetegories (d/db conn)))
(pprint (db/pull-entities (d/db conn)))

(pprint
  @(d/transact conn [[:db/add
                      [:product/id #uuid "93f232c0-4596-490f-bb78-cf236b74c08f"]
                      :product/category
                      [:category/id #uuid "096ae9d7-36fa-405d-8861-a3b3c99f7183"]]]))

