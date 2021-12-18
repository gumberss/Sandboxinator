(ns java8.model)

(defn uuid [] (java.util.UUID/randomUUID))

(defn new-product [uuid name description price]
  {:product/id          uuid
   :product/name        name
   :product/description description
   :product/price       price})