(ns pedestal-components.routes
  (:require [schema.core :as s]
            [datomic.api :as d]
            [io.pedestal.http :as http]
            [io.pedestal.http.body-params :as body-params]
            ))

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

(defn name
  [{{:keys [datomic]} :component
    params            :params}]
  (println datomic)
  (try
    {:status 200
     :body   @(d/transact datomic [{:person/name (:name params)
                                    :person/id   (random-uuid)}])}
    (catch Exception e
      (println e))))

(defn put-name
  [{{:keys [datomic]} :component
    {name :name
     id   :id}        :json-params}]
  (try
    {:status 200
     :body   @(d/transact datomic [{:person/name name
                                    :person/id  (java.util.UUID/fromString id) }])}
    (catch Exception e
      (println e))))

(defn get-name
  [{{:keys [datomic]} :component}]
  (let [name (try
               (map first (d/q '[:find ?name
                                 :where [_ :person/name ?name]]
                               (d/db datomic)))
               (catch Exception e
                 (println e)))]
    {:status 200
     :body   name}))

(defn routes [component]
  #{["/greet" :get [(inject-component component) respond-hello] :route-name :greet]
    ["/test" :get [(inject-component component) test] :route-name :test]
    ["/name" :post [(inject-component component) name] :route-name :name]
    ["/name" :get [(inject-component component) get-name] :route-name :get-name]
    ["/name" :put [(inject-component component) (body-params/body-params) put-name] :route-name :put-name]})