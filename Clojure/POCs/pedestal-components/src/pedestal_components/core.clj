(ns pedestal-components.core
  (:require [com.stuartsierra.component :as component]
            [com.stuartsierra.component.repl
             :refer [reset set-init start stop system]]
            [pedestal-components.comp :as comp]
            [io.pedestal.http :as http]
            [pedestal-components.pedestal :as pedestal]))

(defn new-system
  [env]
  (component/system-map
    :lala (comp/new-lala)
    :service-map
    {:env         env
     ::http/type  :jetty
     ::http/port  8890
     ::http/join? false}

    :pedestal
    (component/using
      (pedestal/new-pedestal)
      [:lala :service-map])))

(set-init (constantly (new-system :prod)))