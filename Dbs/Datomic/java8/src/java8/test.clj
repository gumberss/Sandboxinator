(ns java8.test
  (:require [clojure.string :as str]))




(defn keep2
  [sg1 sg2 result]
  (if (not= (count sg1) (count sg2) 0)
    (let [
          sg1-first-group (first sg1)
          sg1-char (first sg1-first-group)
          count-sg1 (count (second sg1-first-group))

          sg2-first-group (first sg2)
          sg2-char (first sg2-first-group)
          count-sg2 (count (second sg2-first-group))

          bigger (if (>= count-sg1 count-sg2)
                   sg1-first-group
                   sg2-first-group)
          bigger-count (if (>= count-sg1 count-sg2)
                         count-sg1
                         count-sg2)
          symbol (cond
                   (= count-sg1 count-sg2) "="
                   (> count-sg1 count-sg2) "1"
                   (< count-sg1 count-sg2) "2")

          ]
      (if (= sg1-char sg2-char)
        (recur (rest sg1) (rest sg2) (assoc result sg1-char (str symbol ":" (str/join (repeat bigger-count (first bigger))) "/")))
        (if (< (int (first sg1-char)) (int (first sg2-char)))
          (recur (rest sg1) sg2 (assoc result sg1-char (str symbol ":" (str/join (repeat count-sg1 (first sg1-char))) "/")))
          (recur sg1 (rest sg2) (assoc result sg1-char (str symbol ":" (str/join (repeat count-sg2 (first sg2-char))) "/")))
          )
        )
      )
    result))

;(str result symbol ":" (str/join (repeat bigger-count (first bigger))) "/")

(defn a
  []
  (let [
        s1 "Are they here"
        s1 (re-seq #"[a-z]" s1)
        s1 (group-by identity s1)
        s1 (sort-by first s1)


        s2 "yes, they are here"
        s2 (re-seq #"[a-z]" s2)
        s2 (group-by identity s2)
        s2 (sort-by first s2)]
(println (map #(= (first (second %)) \=)  (keep2 s1 s2 {})))
(println (str/join (vals (sort-by #(count (second %)) #(compare %2 %1) (filter #(> (count (second %)) 4) (keep2 s1 s2 {}))))))
    ))

(a)