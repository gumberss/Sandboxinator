(ns components-pedestal-mongo.core
  (:require [com.stuartsierra.component :as component]
            [com.stuartsierra.component.repl
             :refer [reset set-init start stop system]]
            [io.pedestal.http :as http]
            [components-pedestal-mongo.pedestal :as pedestal]
            [components-pedestal-mongo.mongo :as mongo]))

(defn new-system
  [env]
  (component/system-map
    :mongo (mongo/new-mongo)
    :service-map {:env         env
                  ::http/type  :jetty
                  ::http/port  8891
                  ::http/join? false}
    :pedestal (component/using
                (pedestal/new-pedestal)
                [:service-map :mongo])))

(set-init (constantly (new-system :prod)))