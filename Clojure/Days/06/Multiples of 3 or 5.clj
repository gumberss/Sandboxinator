; https://www.codewars.com/kata/514b92a657cdc65150000006

; First solution
(ns multiples)

(defn find-solution [limit founded current add]
  (cond 
    (>= current limit) founded
    :else (recur limit (conj founded current) (+ current add) add)
  )  
)

(defn solution [number]
  (def multiples-of-tree (find-solution number [] 3 3))
  (def multiples-of-five (find-solution number [] 5 5))
  (reduce + (set (concat multiples-of-tree multiples-of-five)))
)

; Using set as default array
(ns multiples)

(defn find-solution [limit founded current add]
  (cond 
    (>= current limit) founded
    :else (recur limit (conj founded current) (+ current add) add)
  )  
)

(defn solution [number]
  (def multiples-of-tree (find-solution number #{} 3 3))
  (def multiples-of-tree-and-five (find-solution number multiples-of-tree 5 5))
  (reduce + multiples-of-tree-and-five)
)

; Using arrow

(ns multiples)

(defn find-solution [limit founded current add]
  (cond 
    (>= current limit) founded
    :else (recur limit (conj founded current) (+ current add) add)
  )  
)

(defn solution [number]
  (def multiples-of-tree (find-solution number #{} 3 3))
  (->>
    (find-solution number multiples-of-tree 5 5)
    (reduce +)))
		
		
; Using range

(ns multiples)


(defn solution [number]
  (def multiples-of-tree (range 3 number 3))
  (def multiples-of-five (range 5 number 5))
  
  (->>
    (concat multiples-of-tree multiples-of-five)
    (set)
    (reduce +)
    )
  )
	
; Using mapcat
(ns multiples)

(defn solution [number]
  (->> [3 5]
    (mapcat #(range % number %)); (range start-from to increment)
    (set)
    (reduce +)))

; Using into 
(ns multiples)

(defn solution [number]
  (->> [3 5]
    (mapcat #(range % number %))
    (into #{})
    (reduce +)))


