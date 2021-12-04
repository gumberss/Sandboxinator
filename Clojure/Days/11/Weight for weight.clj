; https://www.codewars.com/kata/55c6126177c9441a570000cc

(ns weightsort.core)
(use '[clojure.string :only (join split blank?)])

(defn weight [n]
  (cond 
    (<= n 0) 0
    :else (+ (weight (quot n 10)) (mod n 10)) ))

(defn order-weight [strng]
 (->> 
   (split strng #" ")
   (remove blank?)
   (map #(Long/valueOf %))
   (map #(into {} { :weight (weight %) :value (str %)}))
   (sort-by (juxt :weight :value))
   (map :value)
   (join " ")))
