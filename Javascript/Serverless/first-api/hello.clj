(ns com.example.aws-lambda.hello
  (:gen-class
    :implements [com.amazonaws.services.lambda.runtime.RequestStreamHandler])
  (:require
    [clojure.data.json :as json]
    [clojure.java.io :as io]))


(defn handler
  [event context]
  (str "Hello, " (get event "firstName") (get event "lastName")))

(defn -handleRequest
  "Converts IO streams to data structures."
  [_ input-stream output-stream context]
  (with-open [reader (io/reader input-stream)
              writer (io/writer output-stream)]
    (-> reader
        (json/read)
        (handler context)
        (json/write writer))))