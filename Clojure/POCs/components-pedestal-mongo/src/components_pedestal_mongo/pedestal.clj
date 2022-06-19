(ns components-pedestal-mongo.pedestal
  (:require [com.stuartsierra.component :as component]
            [io.pedestal.http :as http]
            [components-pedestal-mongo.routes :as routes]
            [clojure.pprint :as p]))

(defn test?
  [service-map]
  (= :test (:env service-map)))

(defn assoc-component [component context]
  (update context :request assoc :component component))

(defn inject-component [component]
  {:name  :component-injector
   :enter (partial assoc-component component)})

(defn add-component-interceptor
  [endpoint component]
  (update-in endpoint [2] #(into [(inject-component component)] %)))

(defn add-component-to-interceptors
  [endpoints component]
  (set (map #(add-component-interceptor % component) endpoints)))

(defrecord Pedestal [service-map
                     service]
  component/Lifecycle
  (start [this]
    (println (add-component-to-interceptors (routes/routes) this))
    (if service
      this
      (cond-> service-map
              true (assoc ::http/routes  (add-component-to-interceptors (routes/routes) this))
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