(ns java8.model)

(defn uuid [] (java.util.UUID/randomUUID))

(defn new-product [uuid name description price]
  {:product/id          uuid
   :product/name        name
   :product/description description
   :product/price       price})

(defn new-category
  ([name] (new-category (uuid) name))
  ([uuid name] {:category/id uuid
                :category/name name}))