(ns test-api.system
  (:require [com.stuartsierra.component :as component]
            [test-api.components :as tac]))


(defn system [config-options]
    (component/system-map
      :my-integer (tac/->MyInteger)
      :my-new-integer (component/using
                        (tac/map->MyNewInteger)
                        [:my-integer])))

(def sys (system {}))


(alter-var-root #'sys component/start)

;(alter-var-root #'system component/stop)