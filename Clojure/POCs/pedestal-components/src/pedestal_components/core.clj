(ns pedestal-components.core
  (:require [com.stuartsierra.component :as component]
            [com.stuartsierra.component.repl
             :refer [reset set-init start stop system]]
            [pedestal-components.datomic :as pc.datomic]
            [io.pedestal.http :as http]
            [pedestal-components.pedestal :as pedestal])
  (:gen-class))

(defn new-system
  [env]
  (component/system-map
    :datomic (pc.datomic/new-datomic)
    :service-map
    {:env         env
     ::http/type  :jetty
     ::http/port  3001
     ::http/host "0.0.0.0"
     ::http/join? false}

    :pedestal
    (component/using
      (pedestal/new-pedestal)
      [ :service-map :datomic])))

(defn -main
  "The entry-point for 'lein run'"
  [& args]
  (component/start (new-system :prod)))

(defn -stop
  "The entry-point for 'lein run'"
  [system]
  (component/stop system))
