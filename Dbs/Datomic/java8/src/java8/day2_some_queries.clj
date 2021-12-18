(ns java8.day2-some-queries
  (:use clojure.pprint)
  (:require [java8.db :as db]
            [java8.model :as model]
            [datomic.api :as d]))


(def conn (db/open-connection))

(db/create-schema conn)

(pprint (let [computer (model/new-product (model/uuid) "Cool Computer" "Its so nice and amazing" 1.33M)
              toy (model/new-product (model/uuid) "Cool toy" "Its so nice and amazing" 123.33M)
              keyboard (model/new-product (model/uuid) "Cool keyboard" "Its so nice and amazing" 3.33M)
              mouse (model/new-product (model/uuid) "Cool mouse" "Its so nice and amazing" 2.33M)]
          ;(d/transact conn [computer toy keyboard mouse])
          ))

(def query-db (d/db conn))

(defn find-all-products [db]
  (d/q '[:find ?e
         :where [?e :product/name]] db))

;(pprint (find-all-products query-db))

; :in variables you want to bind to query
; $ default db as variable inside the query
(defn find-all-by-name [db name]
  (d/q '[:find ?e
         :in $ ?name
         :where [?e :product/name ?name]] db name))

; (pprint (find-all-by-name (d/db conn) "Cool mouse"))

(defn all-descriptions [db]
  (d/q '[:find ?description
         :where [_ :product/description ?description]] db))
;(pprint (all-descriptions (d/db conn)))

(defn all-cross-join [db]
  (d/q '[:find ?name ?price
         :where
         [_ :product/name ?name]
         [_ :product/price ?price]] db))
;(pprint (all-cross-join (d/db conn)))

(defn columns-by-entity [db]
  (d/q '[:find ?name ?price
         :keys name price
         :where
         [?e :product/name ?name]
         [?e :product/price ?price]] db))

;(pprint (columns-by-entity (d/db conn)))


(defn columns-by-entity-and-namespace [db]
  (d/q '[:find ?name ?price
         :keys product/name product/price
         :where
         [?e :product/name ?name]
         [?e :product/price ?price]] db))

;(pprint (columns-by-entity-and-namespace (d/db conn)))

; Declaring each attribute
(defn pull-entity-attr [db]
  (d/q '[:find (pull ?e [:product/name :product/description :product/price])
         :where [?e :product/name]] db))

; (pprint (pull-entity-attr (d/db conn)))

(defn pull-entity [db]
  (d/q '[:find (pull ?e [*])
         :where [?e :product/name]] db))

; (pprint (pull-entity (d/db conn)))


(defn columns-by-entity [db price-filter]
  (d/q '[:find ?name ?price
         :keys product/name product/price
         :in $ ?price-filter
         :where
         [?e :product/name ?name]
         [?e :product/price ?price]
         [(> ?price ?price-filter)]] db price-filter))

;(pprint (columns-by-entity (d/db conn) 100))


(defn columns-by-entity-optimized [db price-filter]
  (d/q '[:find (pull ?e [*])
         :in $ ?price-filter
         :where
         [?e :product/price ?price]                         ; Since I already have the ?price variable setted,
         [(> ?price ?price-filter)]                         ; I'll filter the price
         [?e :product/name ?name]] db price-filter))        ;Before bind the name

;(pprint (columns-by-entity-optimized (d/db conn) 100))


;(d/transact conn [[:db/add 17592186045420 :product/keywords "Computer"]
;                  [:db/add 17592186045420 :product/keywords "Desktop"]
;                  [:db/add 17592186045420 :product/keywords "Fast"]])

;(d/transact conn [[:db/retract 17592186045420 :product/keywords "Fast"]])

(defn entities-by-keyword [db keyword]
  (d/q '[:find (pull ?e [*])
         :in $ ?keyword
         :where [?e :product/keywords ?keyword]]
       db keyword))

;(pprint (entities-by-keyword (d/db conn) "Computer"))

(defn get-one-element [db id]
  (d/pull db '[*] id))

;(pprint (get-one-element (d/db conn) 17592186045421))

(pprint (-> (d/db conn) (db/pull-entities) ffirst :db/id))
;(pprint (get-one-element (d/db conn) (-> (d/db conn) (db/pull-entities) first first :db/id)))

(def product-id (-> (d/db conn) (db/pull-entities) ffirst :product/id))

(defn one-product-uuid [db uuid]
  (d/pull db '[*] [:product/id uuid]))

(pprint (one-product-uuid (d/db conn) product-id))



; (db/delete-database)
