(ns java8.db
  (:use clojure.pprint)
  (:require [datomic.api :as d]))

(def db-uri "datomic:dev://localhost:4334/store")

(defn open-connection []
  (d/create-database db-uri)
  (d/connect db-uri))

(defn delete-database []
  (d/delete-database db-uri))

(def schema [{:db/ident       :product/name
              :db/valueType   :db.type/string
              :db/cardinality :db.cardinality/one
              :db/doc         "The product name"}
             {:db/ident       :product/description
              :db/valueType   :db.type/string
              :db/cardinality :db.cardinality/one
              :db/doc         "The product description"}
             {
              :db/ident       :product/price
              :db/valueType   :db.type/bigdec
              :db/cardinality :db.cardinality/one
              :db/doc         "Guess what, the product price :O"}
             {:db/ident       :product/keywords
              :db/cardinality :db.cardinality/many
              :db/valueType   :db.type/string}
             {:db/ident       :product/id
              :db/valueType   :db.type/uuid
              :db/cardinality :db.cardinality/one
              :db/unique      :db.unique/identity           ; If you use the same id in two entities, the second one will overwrite the first one
              }
             {:db/ident       :product/category
              :db/cardinality :db.cardinality/one
              :db/valueType   :db.type/ref                  ; Reference to other entity
              }
             {:db/ident       :category/name
              :db/valueType   :db.type/string
              :db/cardinality :db.cardinality/one}
             {:db/ident       :category/id
              :db/valueType   :db.type/uuid
              :db/cardinality :db.cardinality/one
              :db/unique      :db.unique/identity}
             ;transactions
             {:db/ident :tx-data/ip
              :db/valueType :db.type/string
              :db/cardinality :db.cardinality/one}])

(defn create-schema [conn]
  (d/transact conn schema))

(defn pull-entities [db]
  (d/q '[:find (pull ?e [*])
         :where [?e :product/name]] db))

(defn pull-catetegories [db]
  (d/q '[:find (pull ?e [*])
         :where [?e :category/id]]
       db))
