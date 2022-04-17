(ns java8.model
  (:require [schema.core :as s]))

(defn uuid [] (java.util.UUID/randomUUID))

(defn new-product
  ([uuid name description price digital]
   (new-product uuid name description price digital 0))
  ([uuid name description price digital stock]
   {:product/id          uuid
    :product/name        name
    :product/description description
    :product/price       price
    :product/stock       stock
    :product/digital     digital}))

(defn new-category
  ([name] (new-category (uuid) name))
  ([uuid name] {:category/id   uuid
                :category/name name}))

(def Category
  {
   :category/id   java.util.UUID
   :category/name s/Str
   })

(def Product
  {:product/id                           java.util.UUID
   (s/optional-key :product/name)        s/Str
   (s/optional-key :product/price)       BigDecimal
   (s/optional-key :product/description) s/Str
   (s/optional-key :product/category)    Category
   (s/optional-key :product/keywords)    [s/Str]
   (s/optional-key :product/stock)       s/Int
   (s/optional-key :product/digital)     s/Bool})

