(ns day-15.schamas
  (:use clojure.pprint)
  (:require [schema.core :as s]))


(s/set-fn-validation! true)

(pprint (s/validate Long 15))

(s/defn my-test
  [x :- Long]
  (println x))

(my-test 10)
;(my-test "Batman")


(def Person
  "Schema of a person"
  {:id s/Num :name s/Str})

(pprint (s/explain Person))

; Broke when
; has more keys than schema
; Has less keys than schema
(pprint (s/validate Person {:id 10 :name "Batman"}))
;(pprint (s/validate Person {:id 10 :not-a-name "Batman"}))


(s/defn new-person :- Person
  [id :- s/Num name :- s/Str]
  {:id id, :name name})

(pprint (new-person 3 "Jarbas"))

(def Product
  {:price s/Num})

(s/defn expensive?
  :- s/Bool
  [product :- Product]
  (> (:price product) 1000))

;'expensive = Make easy to understand the error
(def Expensive (s/pred expensive? 'expensive?))

(pprint (s/validate Expensive {:price 10000}))
;(pprint (s/validate Expensive {:price 100}))

(s/defn expensive-price? :- s/Bool
  [price :- s/Num]
  (>= price 1000))

(def Animal
  {:food-price (s/constrained s/Num expensive-price?)})

(pprint (s/validate Animal {:food-price 10000}))


(pprint "A little more about schemas")


