(ns day-15.core)

(defprotocol Discontable
  (get-discount [this]))

(defrecord Food [price perishable])

(extend-type Food Discontable
  (get-discount [this]
    (let [price (get this :price)
          perishable (get this :perishable)]
      (if (= perishable true)
        (* price 0.1)
        0))))

(defrecord Toy
  [price breakable]
  Discontable
  (get-discount [this]
    (let [price (get this :price)
          breakable (get this :breakable)]
      (if (= breakable true)
        (* price 0.11)
        0))))

(pprint (->Food 100 true))

(pprint (get-discount (->Food 100 true)))
(pprint (get-discount (->Food 100 false)))

(pprint (get-discount (Toy. 100 true)))
(pprint (get-discount (Toy. 100 false)))


(defmulti testinator class)
(defmethod testinator Food [food] (println "food" food))
(defmethod testinator Toy [toy] (println "toy" toy))

(testinator (->Food 100 true))

(defn what [s]
  (let [cost (:price s)]
    (if (> cost 1000)
      :expend-much
      (class s))))

(defmulti something what)
(defmethod something Food [thing] (println "Something with food"))
(defmethod something Toy [thing] (println "Something with toy"))
(defmethod something :expend-much [thing] (println "Something that expend much"))
(println "defmulti function")
;(something "a")
(something (Toy. 100 false))
(something (Food. 100 false))
(something (Food. 10000 false))






