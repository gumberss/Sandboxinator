(ns day-17-more-tests.generative-tests-test
  (:require [clojure.test :refer :all]
            [clojure.test.check.generators :as gen]
            [clojure.test.check.properties :as prop]
            [clojure.test.check.clojure-test :refer [defspec]]
            [day-17-more-tests.generative-tests :as g])
  (:use clojure.pprint))



(defspec add-to-array-tests 100
         (prop/for-all [array (gen/vector gen/large-integer)
                        value gen/large-integer]
(pprint (g/add-to-array array value))
                       true
                       )
         )