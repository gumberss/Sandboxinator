https://www.codewars.com/kata/54da5a58ea159efa38000836

; First solution
(ns find-the-odd-int)

(defn find-odd [xs]
  (->> xs 
    (group-by #(int %))
    (vals)
    (filter #(odd? (count %)))
    (apply first))  
)

; Using ffirst
(ns find-the-odd-int)

(defn find-odd [xs]
  (->> xs 
    (group-by #(int %))
    (vals)
    (filter #(odd? (count %)))
    (ffirst))  
)

; Using frequencies
(ns find-the-odd-int)

(defn find-odd [xs]
  (->> xs 
    (frequencies)
    (filter #(odd? (second %)))
    (ffirst)
    )  
)

; Magic from Clever guys
(ns find-the-odd-int)

(defn find-odd [xs]
  (reduce bit-xor xs))
