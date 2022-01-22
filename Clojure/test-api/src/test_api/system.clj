(ns test-api.system
  (:require [com.stuartsierra.component :as component]
            [com.stuartsierra.component.repl
             :refer [ set-init]]
            [test-api.components :as tac]
            [io.pedestal.http :as http]
            [test-api.pedestal-api :as pedestal]
            [test-api.routes :as routes]))


(defn new-system
  [env]
  (component/system-map
    :service-map
    {:env          env
     ::http/routes routes/routes
     ::http/type   :jetty
     ::http/port   8890
     ::http/join?  false}
    :pedestal
    (component/using
      (pedestal/new-pedestal)
      [:service-map])
    :my-integer (tac/->MyInteger)
    :my-new-integer (component/using
                      (tac/map->MyNewInteger)
                      [:my-integer])))


(def sys (new-system :prod))

(alter-var-root #'sys component/start)