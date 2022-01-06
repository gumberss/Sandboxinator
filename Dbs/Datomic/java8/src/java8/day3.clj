(ns java8.day3
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))

(def conn (db/open-connection))

(db/create-schema conn)


(pprint (db/pull-categories (d/db conn)))
(pprint (db/pull-entities (d/db conn)))

(pprint
  @(d/transact conn [[:db/add
                      [:product/id #uuid "93f232c0-4596-490f-bb78-cf236b74c08f"]
                      :product/category
                      [:category/id #uuid "096ae9d7-36fa-405d-8861-a3b3c99f7183"]]]))

