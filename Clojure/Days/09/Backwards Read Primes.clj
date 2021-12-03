; https://www.codewars.com/kata/5539fecef69c483c5a000015
(ns backwards-prime.core)

(defn get-divisors [number]
  (for [div (->> number (Math/sqrt) (int) (inc) (range 1))
                 :let [r (mod number div)]
                 :when (= r 0)] div))

(defn prime? [number]
  (cond 
    (<= number 2) true
    (-> number (get-divisors) (count) (<= 1)) true
    :else false))
  
(defn reverse-number 
  ([number reversed]
    (cond
      (= number 0) reversed
      :else (recur (quot number 10) (+ (mod number 10) (* reversed 10)))))
  ([number] (reverse-number number 0))
)

(defn is-reverse-prime [number]
  (= true (prime? number) (prime?(reverse-number number))))

(defn palindrome? [number] 
  (= number (reverse-number number)))

(defn backwards-prime [start stop]
 (->> (range start (inc stop)) 
   (filter is-reverse-prime)
   (remove palindrome?)))
