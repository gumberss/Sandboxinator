; https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec

; First solution

(ns persistent.core)

(defn to-int [ch] (- (int ch) (int \0) ))

(defn get-times [n times]
  (let[sum (->> n
      (str)
      (map to-int)
      (reduce *)
      )]
    (cond 
      (< n 10) times
      (> sum 9) (get-times sum (inc times))
      :else (inc times)
    )
  )
)

(defn persistence [n] (-> n (get-times 0)))
  
; Unsing recur

(ns persistent.core)

(defn to-int [ch] (- (int ch) (int \0) ))

(defn get-times [n times]
  (let[sum (->> n
      (str)
      (map to-int)
      (reduce *)
      )]
    (cond 
      (< n 10) times
      (> sum 9) (recur sum (inc times))
      :else (inc times)
    )
  )
)

(defn persistence [n] (-> n (get-times 0)))
