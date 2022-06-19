(ns components-pedestal-mongo.mongo
  (:require [monger.core :as mg]
            [com.stuartsierra.component :as component]))

(defrecord Mongo []
  component/Lifecycle
  (start [this]
    (assoc this :connection (mg/connect {:host "localhost" :port 27017})))
  (stop [this]
    (mg/disconnect (:connection this))
    (dissoc this :connection)))

(defn new-mongo
  []
  (map->Mongo {}))