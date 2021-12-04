; https://www.codewars.com/kata/55c9172ee4bb15af9000005d/train/clojure

(ns pentanacci.core)

(def calculate-memo 
  (memoize (fn [n] 
    (cond 
      (<= n 0) 0
      (= n 1) 1
      :else (+' 
             (calculate-memo (-' n 1)) 
             (calculate-memo (-' n 2)) 
             (calculate-memo (-' n 3)) 
             (calculate-memo (-' n 4)) 
             (calculate-memo (-' n 5)))))))

(defn count-odd-pentaFib [n]
  (->> (range 1 (inc n)) (map #(calculate-memo %)) (filter odd?) (set) (count))
)
