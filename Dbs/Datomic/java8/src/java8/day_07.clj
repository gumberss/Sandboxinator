(ns java8.day-07
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



(def dama {
           :product/name        "Dama"
           :product/description "/dama"
           :product/price       10.14M
           :product/id          (model/uuid)})

(db/create-product! conn (assoc dama :product/description "/jogo-dama"))

(db/create-product! conn (assoc dama :product/price 150M))

(pprint (db/pull-entities (d/db conn)))

(pprint (db/pull-product (d/db conn) (:product/id dama)))

(defn update-price []
  (println "Atualizando preco")
  (let [product {:product/id (:product/id dama)
                 :product/price 10002222M}]
    (db/create-product! conn product)
    (println "Atualizado preco")))

(defn update-description []
  (println 'Updating')
  (let [product {:product/id (:product/id dama)
                 :product/description "lala po broda"}]
      (Thread/sleep 3000)
      (db/create-product! conn product)
      (println "Atualizado description")))


(defn run-transaction [tx]
  (let [futures (mapv #(future (%)) tx)]
    (pprint (map deref futures))
    (pprint "result")
    (pprint (db/pull-product (d/db conn) (:product/id dama)))))

;(run-transaction [update-price update-description] )

(def products  (db/pull-entities (d/db conn)))

(pprint (db/pull-product (d/db conn) (:product/id (second products))))

(pprint (db/pull-product (d/db conn) (model/uuid)))
(pprint (db/pull-product! (d/db conn) (model/uuid)))
(pprint (db/products-with-stock (d/db conn)))
(pprint (db/find-product-with-stock (d/db conn) (:product/id (first products))))
(pprint (db/find-product-with-stock (d/db conn) (:product/id (second products))))