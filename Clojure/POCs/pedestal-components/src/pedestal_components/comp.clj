(ns pedestal-components.comp
  (:require [com.stuartsierra.component :as component]))


(defrecord Lala []
  component/Lifecycle

  (start [component]
    (assoc component :po 123))

  (stop [component]
    (dissoc component :po)))

(defn new-lala []
  (map->Lala {}))