(ns day-16.schemas
  (:require [schema.core :as s])
  (:use clojure.pprint)
  )

(s/set-fn-validation! true)

(def Numbers [s/Num])

(pprint (s/validate Numbers [15 10 12.2]))
(pprint (s/validate Numbers [0]))
(pprint (s/validate Numbers nil))
;(pprint (s/validate s/Num nill))


(def SuperPower s/Keyword)

(def Hero
  {:name                         s/Str
   :super-powers                 [SuperPower]
   (s/optional-key :description) s/Str})

(println (s/validate Hero {:name "Batman" :super-powers [:money :intelligence]})) ; ok
(println (s/validate Hero {:name "A random guy" :super-powers []})) ; ok
(println (s/validate Hero {:name "A random guy" :super-powers nil})) ; ok
;(println (s/validate Hero {:name "A random guy" :super-powers [nil]})); Error

(println (s/validate Hero {:name "Batman" :super-powers [:money] :description "Oi"})) ; ok

(def PosInt
  (s/pred pos-int?))

(def HeroList
  {PosInt Hero})

(def Batman {:name "Batman" :super-powers [:money :intelligence]})

(pprint (s/validate HeroList {10 Batman}))
(pprint (s/validate HeroList {10 Batman 11 Batman}))




