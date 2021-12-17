(ns java8.model)


(defn new-product [name description price]
  {:product/name        name
   :product/description description
   :product/price       price})