(ns day-18.core
  (:require clojure.pprint))

(def empty-queue clojure.lang.PersistentQueue/EMPTY)

(def company {
              :waiting empty-queue
              :cashier empty-queue
              :coffee  empty-queue
              :lunch   empty-queue
              })

(defn is-full? [company department limit]
  (> (count (department company)) limit))

(defn arrive [company person]
  (if (not (is-full? company :waiting 10))
    (update company :waiting conj person)
    (throw (ex-info "The company is full" {:company company :person person}))))

(defn transfer
  [company from-department to-department]
  (let [person (peek (from-department company))]
    (if (not (is-full? company to-department 5))
      (->
        (update company from-department pop)
        (update to-department conj person))
      (throw (ex-info "The department is full" {:department to-department}))
      )
    ))

(->
  (arrive company {:name "hi1"})
  (arrive {:name "hi2"})
  (arrive {:name "hi3"})
  (arrive {:name "hi4"})
  (arrive {:name "hi5"})
  (arrive {:name "hi6"})
  (arrive {:name "hi7"})
  (arrive {:name "hi8"})
  (arrive {:name "hi9"})
  (arrive {:name "hi10"})
  (transfer :waiting :coffee)
  (arrive {:name "hi12"})
  (transfer :waiting :coffee)
  (transfer :coffee :lunch)
  (transfer :waiting :lunch)
  (transfer :lunch :cashier)
  ;(pprint)
  )

