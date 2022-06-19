(ns components-pedestal-mongo.routes
  (:require [schema.core :as s]
            [io.pedestal.http.body-params :as body-params]
            [monger.collection :as mc]
            [monger.core :as mg]
            [monger.result :as r])
  (:import (org.bson.types ObjectId)))

(defn assoc-component [component context]
  (update context :request assoc :component component))

(defn inject-component [component]
  {:name  :component-injector
   :enter (partial assoc-component component)})

(defn names
  [{{:keys [mongo]} :component
    {:keys [name]}  :params}]
  (try
    (let [conn (:connection mongo)
          db (mg/get-db conn "mongo-test")]
      {:status 200
       :body   (mc/insert-and-return db "people" {:_id  (ObjectId.)
                                                  :name name
                                                  :id   (random-uuid)})})
    (catch Exception e
      (println e))))

(defn put-name
  [{{{:keys [connection]} :mongo} :component
    {name :name
     id   :id}                    :json-params}]
  (try
    (let [db (mg/get-db connection "mongo-test")
          result (mc/update db "people" {:id (java.util.UUID/fromString id)} {:name name})]
      (println id name)
      {:status (if (r/acknowledged? result)
                 200
                 400)
       :body   {:updated-existing-document (r/updated-existing? result)}})
    (catch Exception e
      (println e))))

(defn get-name
  [{{{:keys [connection]} :mongo} :component}]
  (let [db (mg/get-db connection "mongo-test")
        name (try
               (mc/find-maps db "people")
               (catch Exception e
                 (println e)))]
    {:status 200
     :body   name}))

(defn routes [component]
  #{["/name" :post [(inject-component component) names] :route-name :name]
    ["/name" :get [(inject-component component) get-name] :route-name :get-name]
    ["/name" :put [(inject-component component) (body-params/body-params) put-name] :route-name :put-name]})