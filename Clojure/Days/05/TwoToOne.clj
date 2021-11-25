;https://www.codewars.com/kata/5656b6906de340bd1b0000ac

; First Solution
(ns longest.core)
(require '[clojure.string :as str])

(defn longest [s1 s2]
  (apply str (sort-by #(int %1) (set (concat s1 s2))))
)

; Using arrow

(ns longest.core)
(require '[clojure.string :as str])

(defn longest [s1 s2]
  (->> (concat s1 s2)
    (set)
    (sort-by #(int %1))
    (apply str)
  )
)

; Using (comp)
(ns longest.core)
(require '[clojure.string :as str])

(defn longest [s1 s2]
   (apply str ((comp sort set concat) s1 s2))
  )


; Interesting way to order set and do the same thing with many strings as paramenters
(ns longest.core)

(defn longest [& ss]
  (->> ss (apply concat) (apply sorted-set) (apply str)))
	
; Join strings using (str)
(ns longest.core)
(require '[clojure.string :as str])

(defn longest [s1 s2]
  (apply str (set (str s1 s2)))
  )

