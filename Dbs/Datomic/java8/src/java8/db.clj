(ns java8.db
  (:use clojure.pprint)
  (:require [datomic.api :as d]
            [java8.model :as model]
            [schema.core :as s]
            [clojure.walk :as walk]))

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
             {:db/ident       :product/digital
              :db/cardinality :db.cardinality/one
              :db/valueType   :db.type/boolean              ; Reference to other entity
              }
             ; stock
             {:db/ident       :product/stock
              :db/valueType   :db.type/long
              :db/cardinality :db.cardinality/one}

             ;Category
             {:db/ident       :category/name
              :db/valueType   :db.type/string
              :db/cardinality :db.cardinality/one}
             {:db/ident       :category/id
              :db/valueType   :db.type/uuid
              :db/cardinality :db.cardinality/one
              :db/unique      :db.unique/identity}
             ;transactions
             {:db/ident       :tx-data/ip
              :db/valueType   :db.type/string
              :db/cardinality :db.cardinality/one}])

(defn create-schema [conn]
  (d/transact conn schema))

(defn dissoc-db-key
  [entity]
  (if (map? entity)
    (dissoc entity :db/id)
    entity))



(defn datomic->entity [entities]
  (walk/prewalk dissoc-db-key entities))

(s/defn add-categories!
  [conn & categories :- [model/Category]]
  @(d/transact conn categories))

(s/defn create-product! [conn & products :- [model/Product]]
  @(d/transact conn products))

(defn bind-category!
  [conn product-id category-id]
  @(d/transact conn [[:db/add
                      [:product/id product-id]
                      :product/category
                      [:category/id category-id]]]))



(defn create-example-data [conn]
  (let [c1 (model/new-category "Eletronic")
        c2 (model/new-category "Something")
        computer (model/new-product (model/uuid) "C ool Computer" "Its so nice and amazing" 1.33M false 10)
        toy (model/new-product (model/uuid) "Cool toy" "Its so nice and amazing" 123.33M false)
        keyboard (model/new-product (model/uuid) "Cool keyboard" "Its so nice and amazing" 3.33M false 12)
        mouse (model/new-product (model/uuid) "Cool mouse" "Its so nice and amazing" 2.33M false)
        online-game (model/new-product (model/uuid) "Cool game" "Its so nice and amazing" 288.33M true)]
    (add-categories! conn c1 c2)
    (create-product! conn computer toy keyboard mouse online-game)
    (println "Binding1")
    (bind-category! conn (:product/id computer) (:category/id c1))
    (bind-category! conn (:product/id toy) (:category/id c2))
    (bind-category! conn (:product/id online-game) (:category/id c2))
    (println "Binding")
    (bind-category! conn (:product/id keyboard) (:category/id c1))
    ))

(s/defn pull-entities :- [model/Product] [db]
  (datomic->entity (d/q '[:find [(pull ?e [* {:product/category [*]}]) ...]
                          :where [?e :product/name]] db)))

(s/defn pull-product :- (s/maybe model/Product)
  [db product-id]
  (let [product (d/q '[:find [(pull ?e [* {:product/category [*]}])]
                       :in $ ?product-id
                       :where [?e :product/id ?product-id]
                       ] db product-id)
        product (first (datomic->entity product))]
    (if (:product/id product)
      product
      nil))
  )

(s/defn pull-product! :- model/Product
  [db product-id]
  (let [product (pull-product db product-id)]
    (if (nil? product)
      (throw (ex-info "Product not found by id" {:product/id product-id}))
      product)))

(s/defn pull-categories :- [model/Category]
  [db]
  (datomic->entity (d/q '[:find [(pull ?e [*]) ...]
                          :where [?e :category/id]]
                        db)))

(def rules
  '[
    [(stock ?e ?stock)
     [?e :product/stock ?stock]]
    [(stock ?e ?stock)
     [?e :product/digital true]
     [(ground 100) ?stock]]
    [(can-sell? ?e)
     [stock ?e ?stock]
     [(> ?stock 0)]]
    [(product-in-category ?entity ?category-name)
     [?category :category/name ?category-name]
     [?entity :product/category ?category]]])

(s/defn products-with-salable
  [db]
  (d/q
    '[:find [(pull ?e [*]) ...]
      :in $ %
      :where
      [stock ?e ?stock]
      [can-sell? ?e]] db rules))

(s/defn find-product-with-salable
  [db product-id]
  (let [product (datomic->entity (d/q '[:find (pull ?e [* {:product/category [*]}]) .
                                        :in $ % ?product-id
                                        :where [?e :product/id ?product-id]
                                        [can-sell? ?e]] db rules product-id))]
    (if (:product/id product) product nil)))

(s/defn products-by-category :- [model/Product]
  [db, categories :- [s/Str]]
  (datomic->entity
    (d/q '[:find [(pull ?entity [* {:product/category [*]}]) ...]
           :in $ [?category-name ...]
           :where
           (product-in-category ?entity ?category-name)]
         db categories)))

(s/defn products-by-category-and-digital :- [model/Product]
  [db, categories :- [s/Str] digital? :- s/Bool]
  (datomic->entity
    (d/q '[:find [(pull ?entity [* {:product/category [*]}]) ...]
           :in $ % [?category-name ...] ?digital?
           :where
           (product-in-category ?entity ?category-name)
           [?entity :product/digital ?digital?]]
         db rules categories digital?)))

(s/defn update-price [conn product-id :- java.util.UUID old-price :- BigDecimal new-price :- BigDecimal ]
  )