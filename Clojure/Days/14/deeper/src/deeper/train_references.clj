(ns deeper.train-references
  (:use clojure.pprint))

(println "Review Atom")

(defn package [] {:items [:ring :mouse :toy]})

(defn add [package item]
  (update package :items conj item))

(defn change-atom []
  (let [atom (atom (package))]
    (swap! atom add :apple)
    (swap! atom add :potato)
    (swap! atom add :bottle)
    (pprint @atom)
    ))

;(change-atom)

(println "Review ref")

(defn ref-package [] {:items (ref [:ring :mouse :toy])})

(println "ref-set")
(defn add-item
  [items new-item]
  (ref-set items (conj (deref items) new-item)))

(defn change-ref []
  (let [package (ref-package)]
    (dosync (add-item (get package :items) :potato))
    (pprint package)))

;(change-ref)

(println "alter")

(defn add-item-alter
  [items new-item]
  (alter items conj new-item))

(defn change-ref-alter []
  (let [package (ref-package)]
    (dosync (add-item-alter (get package :items) :potato))
    (pprint package)))

(change-ref-alter)









