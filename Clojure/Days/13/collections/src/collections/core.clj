(ns collections.core
  (:require [collections.db :as c.db])
  (:use [clojure pprint]))

(defn p [& vals]
  (apply clojure.pprint/pprint vals))

; primeiro teste map reduce
(defn valor-item
  [[id detalhes]]
  (* (get detalhes :quantidade 0) (get detalhes :preco-unitario 0)))

(defn preco-pedido [pedido]
  (->>
       (get pedido :itens)
       (map valor-item)
       (reduce +)))

(defn preco-total-pedidos
  [pedidos]
  (->> pedidos
       (map preco-pedido)
       (reduce +)))


(defn conta-por-usuario
  [[usuario pedidos]]
  {:usuario usuario
   :total-pedidos (count pedidos)
   :preco-total (preco-total-pedidos pedidos)})

 (->> (c.db/todos-pedidos)
              (group-by :usuario)
          (map conta-por-usuario)
      ;(p)
      )



; segundo teste mapcat

(defn valor-item
  [[id detalhes]]
  (* (get detalhes :quantidade 0) (get detalhes :preco-unitario 0)))

(defn preco-total-pedidos
  [pedidos]
  (->> pedidos
       (mapcat :itens)
       (map valor-item)
       (reduce +)))

(defn conta-por-usuario
  [[usuario pedidos]]
  {:usuario usuario
   :total-pedidos (count pedidos)
   :preco-total (preco-total-pedidos pedidos)})

(->> (c.db/todos-pedidos)
     (group-by :usuario)
     (map conta-por-usuario)
     (p))


