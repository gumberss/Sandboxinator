(ns test-api.pedestal-api
  (:require [io.pedestal.http :as http]
            [com.stuartsierra.component :as component] ))

(defn respond-hello [request]
  {:status 200 :body "Hello, world!"})

(defn test?
  [service-map]
  (= :test (:env service-map)))

(defrecord Pedestal [service-map
                     service]
  component/Lifecycle
  (start [this]
    (if service
      this
      (cond-> service-map
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