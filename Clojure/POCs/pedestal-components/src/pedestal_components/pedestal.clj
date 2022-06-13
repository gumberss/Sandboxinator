(ns pedestal-components.pedestal
  (:require [com.stuartsierra.component :as component]
            [io.pedestal.http :as http]
            [pedestal-components.routes :as routes]))

(defn test?
  [service-map]
  (= :test (:env service-map)))

(defrecord Pedestal [service-map
                     service]
  component/Lifecycle
  (start [this]
    (println this)
    (if service
      this
      (cond-> service-map
              true (assoc ::http/routes (routes/routes this))
              true                      http/create-server
              (not (test? service-map)) http/start
              true                      ((partial assoc this :service)))))
  (stop [this]
    (when (and service (not (test? service-map)))
      (http/stop service))
    (assoc this :service nil)))

(defn new-pedestal
  []
  (map->Pedestal {}))