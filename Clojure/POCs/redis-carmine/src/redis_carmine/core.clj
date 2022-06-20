(ns redis-carmine.core
  (:require [taoensso.carmine :as car :refer (wcar)]
    ))

#_(println (wcar {:pool {} :spec
                {:host "127.0.0.1"
                 :port 6379
                 :password "pass"
                 :timeout-ms 6000}}
               (car/set "lala" {:lala {:po {:jujr {:popo "21321"
                                                   :mol 123}}}})))

(println (wcar {:pool {} :spec
                {:host "127.0.0.1"
                 :port 6379
                 :password "pass"
                 :timeout-ms 6000}}
               (car/get "lala")))
