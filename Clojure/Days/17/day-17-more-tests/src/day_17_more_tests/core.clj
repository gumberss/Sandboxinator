(ns day-17-more-tests.core
  (:use clojure.pprint))

(def store
  {:cashiers {:cashier1 {:id :cashier1 :queue []}
              :cashier2 {:id :cashier2 :queue []}}
   :inside   #{}})

(defn person [id name]
  {:id id :name name})

(defn enter-in
  [store person]
  (update store :inside conj person))

(defn find-best-cashier-to-go [store]
  (let [cashiers (get store :cashiers)
        cashiers-keys (keys cashiers)
        ordered-cashiers (sort-by #(count (get (get cashiers %) :queue)) cashiers-keys)
        best-id (first ordered-cashiers)]
    best-id))

(defn go-to-cashier [store cashier person]
  (-> (update store :inside disj person)
      (update-in [:cashiers cashier :queue] conj person)))

(defn- my-flow []
  (let [person {:id 2 :name "123"}
        my-store (-> store (enter-in {:id 2 :name "123"}))
        best-cashier-to-go (find-best-cashier-to-go my-store)]
    (go-to-cashier my-store best-cashier-to-go person)))

(pprint (my-flow))

