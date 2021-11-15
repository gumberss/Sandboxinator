; https://www.codewars.com/kata/55d24f55d7dd296eb9000030/train/clojure

; First Solution
(ns kata.summation)
(defn summation [n]
  ( ->> n
    (+ 1)
    (range 1)
    (reduce #(+ %1 %2) 0)
  ))
	
; Using reduce with + 
(ns kata.summation)
(defn summation [n]
  ( ->> n
    (+ 1)
    (range 1)
    (reduce +)
  ))
	
; Using inc 
(ns kata.summation)
(defn summation [n]
  ( ->> n
    (inc)
    (range 1)
    (reduce +)
  ))
	
; Using apply 
(ns kata.summation)
(defn summation [n]
  ( ->> n
    (+ 1)
    (range 1)
    (apply +)
  ))
	
; Using math (O(1))
(ns kata.summation)
(defn summation [n]
  (/ (* n (+ n 1)) 2))
	
; Using math and -> (-> not ->>, ensuring the result is passed as first argument of the next function) 
(ns kata.summation)
(defn summation [n]
  (-> n
    (inc)
    (* n)
    (/ 2)
  )
)
