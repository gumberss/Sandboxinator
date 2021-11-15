; https://www.codewars.com/kata/5648b12ce68d9daa6b000099/train/clojure

; First Solution
(ns kata.bus)
(defn number
  [bus-stops]
  (->> bus-stops
      (reduce #(- (+ %1 (first %2))(last %2)) 0)
  )
  )


; Other random solution to learn more about others functions
(ns kata.bus)
; https://stackoverflow.com/questions/6135764/when-to-use-zipmap-and-when-map-vector
(defn number
  [bus-stops]
  (->> (range 1 ( * 2 (count bus-stops))) 
       (reduce #(conj %1 (* (last %1) #_%2 -1)  ) [1]) 
       (map vector (flatten bus-stops))
       (map #(* (first %) (last %)))
       (reduce +)
  )
  )
	
; Pattern matching 
(ns kata.bus)
(defn process [passangers [in out]] 
  (+ passangers (- in out))
)
(defn number
  [bus-stops]
    (reduce process 0 bus-stops)
)
	
; Interesting map	behavior (https://clojuredocs.org/clojure.core/map) 
; Apply map to each collumn, so, in this problem:
; if the input is [ [1 2] [3 4] ], function 'apply' will flatten to [1 2] [3 4]
; and map function will apply + to each collumn of each array:
; [   [  [
; 1 + 3 = 4
; 2 + 4 = 6
;	]   ]  ]
; returning [4 6]
; then we use reduce with - function

(ns kata.bus)
(defn number
  [bus-stops]
  (reduce - (apply map + bus-stops))
)
