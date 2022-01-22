(ns test-api.routes
  (:require  [io.pedestal.http.route :as route]))

(defn respond-hello [request]
  {:status 200 :body (str "Hello, world!" request)})

(def routes
  #{["/greet" :get respond-hello :route-name :greet]})