;https://www.codewars.com/kata/52b7ed099cdc285c300001cd/train/clojure


; First solution 
(ns sum-intervals.core)

(defn sum-intervals
  [intervals]  
  (->> intervals
    (map #(- (second %) (first %)))
    (reduce +)))


; Second solution
; This is so weird, but I like so much!
(ns sum-intervals.core)

(defn sum-intervals
  [intervals]  
  (->> intervals
    (mapcat (partial apply range))
    set
    count))
