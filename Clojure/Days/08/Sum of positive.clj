;https://www.codewars.com/kata/5715eaedb436cf5606000381

; First Solution
(ns kata)
(defn positive-sum [xs]
  (->> xs
  (filter #(> % 0))
  (reduce +)
))

; Using Pos?
(ns kata)
(defn positive-sum [xs]
  (reduce + (filter pos? xs)))
	
; Using (remove neg?) and apply
(ns kata)
(defn positive-sum [xs]
  (->> xs (remove neg?) (apply +)))
