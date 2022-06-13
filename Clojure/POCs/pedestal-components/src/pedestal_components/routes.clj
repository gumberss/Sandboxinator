(ns pedestal-components.routes)

(defn respond-hello [request]
  {:status 200 :body request})

(defn assoc-component [component context]
  (println component)
  (update context :request assoc :component component))

(defn inject-component [component]
  {:name  :component-injector
   :enter (partial assoc-component component)})

(defn routes [component]
  #{["/greet" :get [(inject-component component) respond-hello] :route-name :greet]})