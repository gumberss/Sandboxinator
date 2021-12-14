(ns day-17-more-tests.core
  (:use clojure.pprint)
  (:require [schema.core :as s]))

(s/set-fn-validation! true)

(def Cashier
  {:id s/Keyword :queue [Person]})

(def Person
  {:id s/Num :name s/Str})

(s/def Store
  {:cashiers {:cashier1 Cashier
              :cashier2 Cashier}
   :inside   #{Person}})

(def the-store
  {:cashiers {:cashier1 {:id :cashier1 :queue []}
              :cashier2 {:id :cashier2 :queue []}}
   :inside   #{}})

(s/defn enter-in :- Store
  [store :- Store person :- Person]
  (update store :inside conj person))

(s/defn find-best-cashier-to-go [store :- Store] :- Cashier
  (let [cashiers (get store :cashiers)
        cashiers-keys (keys cashiers)
        ordered-cashiers-ids (sort-by #(count (get (get cashiers %) :queue)) cashiers-keys)
        cashier (->> ordered-cashiers-ids first (get cashiers))]
    cashier))

(s/defn go-to-cashier :- Store
  [store :- Store
   cashier :- Cashier
   person :- Person]
  (let [cashier-id (get cashier :id)]
  (-> (update store :inside disj person)
      (update-in [:cashiers cashier-id :queue] conj person))))

(defn- my-flow []
  (let [person {:id 2 :name "123"}
        my-store (-> the-store (enter-in {:id 2 :name "123"}))
        best-cashier-to-go (find-best-cashier-to-go my-store)]
    (go-to-cashier my-store best-cashier-to-go person)))

(pprint (my-flow))

