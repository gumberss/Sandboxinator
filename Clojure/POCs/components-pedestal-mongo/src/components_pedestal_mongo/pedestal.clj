(ns components-pedestal-mongo.pedestal
  (:require [com.stuartsierra.component :as component]
            [io.pedestal.http :as http]
            [components-pedestal-mongo.routes :as routes]
            [clojure.pprint :as p]
            [io.pedestal.http.body-params :as body-params]))

(def all-routes
  (set (concat (routes/routes))))

(defn test?
  [service-map]
  (= :test (:env service-map)))

(defn assoc-component [component context]
  (update context :request assoc :component component))

(defn inject-component [component]
  {:name  :component-injector
   :enter (partial assoc-component component)})

(defn interceptors [components]
  [(body-params/body-params)
   (inject-component components)])

(defn include-interceptors
  [endpoint component]
  (update-in endpoint [2] #(into (interceptors component) %)))

(defn add-interceptors
  [endpoints component]
  (set (map #(include-interceptors % component) endpoints)))

(defrecord Pedestal [service-map
                     service]
  component/Lifecycle
  (start [this]
    (if service
      this
      (cond-> service-map
              true (assoc ::http/routes  (add-interceptors all-routes this))
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