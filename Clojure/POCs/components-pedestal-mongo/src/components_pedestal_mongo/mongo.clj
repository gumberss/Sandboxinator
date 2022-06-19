(ns components-pedestal-mongo.mongo
  (:require [monger.core :as mg]
            [com.stuartsierra.component :as component]
            [monger.collection :as mc]))

(defrecord Mongo []
  component/Lifecycle
  (start [this]
    (let [conn (mg/connect {:host "localhost" :port 27017})
          db (mg/get-db conn "monger-test")]
      (mc/ensure-index db "people" (array-map :latlong "2dsphere"))
      (assoc this
        :connection conn
        :db db)))
  (stop [this]
    (mg/disconnect (:connection this))
    (dissoc this :connection :db)))

(defn new-mongo
  []
  (map->Mongo {}))