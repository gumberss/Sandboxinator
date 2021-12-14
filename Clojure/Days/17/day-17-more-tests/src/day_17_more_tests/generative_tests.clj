(ns day-17-more-tests.generative-tests
  (:require [clojure.test.check.generators :as gen]))

; https://github.com/clojure/test.check/blob/master/doc/cheatsheet.md
;(println (gen/sample gen/double))


(defn add-to-array [array value]
  (conj array value))
