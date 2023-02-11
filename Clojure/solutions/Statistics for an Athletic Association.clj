; https://www.codewars.com/kata/55b3425df71c1201a800009c

(ns stat.core
  (:require [clojure.string :as str]))

(defn individual-results [input]
  (str/split input #","))

(defn ->int 
  [v]
  (Integer/parseInt v))

(defn ->seconds
  [[h m s]]
  (let [h (-> (->int h))
        m (->int m)
        s (->int s)]
  (+ (* h 60 60) (* m 60) s)))

(defn ->floor [v]
  (Math/floor v))

(defn ->time
  [seconds]
  (let [secs (->floor (rem seconds 60))
        hours (->floor (/ seconds (*  60 60)))
        minutes (- (->floor (/ seconds 60)) (* hours 60))]
    [(int hours) (int minutes) (int secs)]))

(defn str->individual-results
  [individual-result]
  (->> (str/split individual-result #"\|")
    (map str/trim)))

(defn find-range
  [runners-results]
  (let [[first last] (->> (sort runners-results)
                       ((juxt first last)))]
  (- last first)))

(defn find-average
  [runners-results]
  (/ (apply + runners-results) (count runners-results)))

(defn find-median-positions
  [enumerable]
  (let [length (count enumerable)
        middle (-> (/ length 2) (Math/floor))]
  (if (even? length)
    [middle (- middle 1)]
    [middle])))

(defn find-median
  [runners-results]
  (let [runners-results-count (count runners-results)
        middle (-> (/ runners-results-count 2)
                 (Math/floor))
        sorted-results (sort runners-results)
        median-positions (find-median-positions sorted-results)
        median-sum (->> median-positions
                     (map (partial nth sorted-results))
                     (reduce +))]
    (/ median-sum
       (count median-positions))))
  
(defn find-stats
  [runners-results]
  {:range (find-range runners-results)
   :average (find-average runners-results) 
   :median (find-median runners-results)})

(defn stats->time
  [stats]
  (-> stats
    (update :range ->time)
    (update :average ->time)
    (update :median ->time)))

(defn stat-time->str
  [[h m s]]
  (str/join "|" [(format "%02d" h)
                 (format "%02d" m)
                 (format "%02d" s)]))

(defn stats->str
  [{:keys [range average median]}]
  (let [range (str "Range: "(stat-time->str range) " ")
        average (str "Average: "(stat-time->str average) " ")
        median (str "Median: "(stat-time->str median))]
  (str range average median)))

(defn stat [s]
  (if (empty? s) ""
  (->> s
    individual-results 
    (map str->individual-results)
    (map ->seconds)
    find-stats
    stats->time
    stats->str)))
