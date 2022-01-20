(ns test-api.components
  (:require [com.stuartsierra.component :as component]))

(defrecord MyInteger []
  component/Lifecycle

  (start [component]
    (println ";; Integer")
    (let [int 56]
      (println ";; Integer" int)
      (assoc component :my-integer int)))

  (stop [component]
    (println ";; Stopping Integer")
    (assoc component :my-integer nil)))


(defrecord MyNewInteger [my-integer]
  component/Lifecycle
  (start [component]
    (println ";; new Integer. Old" my-integer)
    (let [int (+ (:my-integer my-integer)  44)]
      (println ";; new Integer" int)
      (assoc component :my-new-integer int)))

  (stop [component]
    (println ";; Stopping Integer new")
    (assoc component :my-new-integer nil)))

(defn map->MyNewInteger []
  (->MyNewInteger {}))