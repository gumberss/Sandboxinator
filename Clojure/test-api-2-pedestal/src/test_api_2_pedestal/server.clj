(ns test-api-2-pedestal.server
  (:require [io.pedestal.http :as http]
            [io.pedestal.http.route :as route]
            [test-api-2-pedestal.controller :as p.c]
    ;          [io.pedestal.test :as test]
            )
  )


(def routes
  (route/expand-routes
    #{["/greet" :get p.c/respond-hello :route-name :greet]}))

(def service-map
  {::http/routes routes
   ::http/type   :jetty
   ::http/port   8890})

(defn start []
  (http/start (http/create-server service-map)))

;; For interactive development
(defonce server (atom nil))

(defn start-dev []
  (reset! server
          (http/start (http/create-server
                        (assoc service-map
                          ::http/join? false)))))

(defn stop-dev []
  (http/stop @server))

(defn restart []
  (stop-dev)
  (start-dev))