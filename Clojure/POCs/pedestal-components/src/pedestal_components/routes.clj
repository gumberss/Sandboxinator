(ns pedestal-components.routes
  (:require [schema.core :as s]))

(defn respond-hello [request]
  {:status 200 :body request})

(defn assoc-component [component context]
  (update context :request assoc :component component))

(defn inject-component [component]
  {:name  :component-injector
   :enter (partial assoc-component component)})

(defn test
  [{{{po :po} :lala} :component
    params           :params}]
  {:status 200
   :body   (str po " - " (:xaxa params))})

(defn routes [component]
  #{["/greet" :get [(inject-component component) respond-hello] :route-name :greet]
    ["/test" :get [(inject-component component) test] :route-name :test]})