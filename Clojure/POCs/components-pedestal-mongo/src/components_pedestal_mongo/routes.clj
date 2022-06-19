(ns components-pedestal-mongo.routes
  (:require [schema.core :as s]
            [io.pedestal.http.body-params :as body-params]
            [monger.collection :as mc]
            [monger.core :as mg]
            [monger.operators :refer :all]
            [monger.result :as r])
  (:import (org.bson.types ObjectId)))

(defn names
  [{{{:keys [db]} :mongo}   :component
    {:keys [name lat long]} :params}]
  (try
    (let [lat (Double/parseDouble lat)
          long (Double/parseDouble long)]
      {:status 200
       :body   (mc/insert-and-return db "people" {:_id     (ObjectId.)
                                                  :name    name
                                                  :latlong {:type "Point" :coordinates [lat long]}
                                                  :id      (random-uuid)})})
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
  [{{{:keys [db]} :mongo} :component
    {:keys [lat long]}    :params}]
  (let [lat (Double/parseDouble lat)
        long (Double/parseDouble long)
        name (try
               (mc/find-maps db "people" {:latlong {$near {"$geometry"    {:type        "Point"
                                                                           :coordinates [lat long]}
                                                           "$maxDistance" 100}}})
               (catch Exception e
                 (println e)))]
    {:status 200
     :body   name}))

(defn routes []
  #{["/name" :post [names] :route-name :name]
    ["/name" :get [get-name] :route-name :get-name]
    ["/name" :put [put-name] :route-name :put-name]})