(ns day-15.core)

(defprotocol Discontable
  (get-discount [this]))

(defrecord Food [ price perishable])

(extend-type Food Discontable
  (get-discount [this] (let [price (get this :price)
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

