(ns day-18.core-test
  (:require [clojure.test :refer :all]
            [day-18.core :refer :all]
            [clojure.test :refer :all]
            [clojure.test.check.generators :as gen]
            [clojure.test.check.properties :as prop]
            [clojure.test.check.clojure-test :refer [defspec]]
            )
  (:use clojure.pprint))

(defn total-people [company]
  (reduce + (map count (vals company))))

(defspec
  generative-tests
  100
  (prop/for-all
    [person (gen/map (gen/elements [:name]) gen/string-alphanumeric)
     coffee-queue (gen/vector gen/string-alphanumeric 0 4)
     lunch-queue (gen/vector gen/string-alphanumeric 0 4)
     cashier-queue (gen/vector gen/string-alphanumeric 0 4)
     waiting-queue (gen/vector gen/string-alphanumeric 0 9)]
    (let [ company {:waiting waiting-queue
                    :lunch lunch-queue
                    :coffee coffee-queue
                    :cashier cashier-queue
                    }]

      (is (=
            (+ 1 (total-people company))
            (total-people (arrive company person)))))))