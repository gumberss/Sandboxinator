(ns collections.test-collections
  (:use [clojure pprint]))

; Array

(defn array []
  (let [arr [1 2 3]]
    (pprint (conj arr 4))
    (pprint (pop arr))
    (pprint (first arr))
    (pprint (rest arr))))

;(array)

(defn listi []
  (let [ lis '(1 2 3)]
    (pprint (conj lis 4))
    (pprint (pop lis))
    (pprint (first lis))
    (pprint (rest lis))))
;(listi)

(defn queuee []
  (let [que (conj (clojure.lang.PersistentQueue/EMPTY) 1 2 3 4)]
    (pprint que)
    (pprint (conj que 7 8 9))
    (pprint (peek que))
    (pprint (pop que))))

(queuee)

