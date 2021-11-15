(defn p [& args] (apply println args))

; ## Vectors
(p "Vectors")
(def arr [1 2 3 4])
(def arr2 (vector 1 2 3 4)) ; another way to create a vector


(p arr)

(p (get arr 1))
(p (get arr 10)) ; nil

(p (count arr))

(p (conj arr 1 2 3))

; ## Lists

(p "Lists")

(def things '(5 :ace :nice))

(p (first things))
(p (rest things))
(p (conj things :other))

(p things)

(p (peek things))
(p (pop things))
(p things)

; ## Sets
(p "sets")
(def names #{"Batman" "Jarbas" "My name"})
(p names)
(p (conj names "Other name"))
(p names)
(p (disj names "Batman" "Jarbas"))
(p (contains? names "Batman"))
(p (conj (sorted-set) "Batman" "A guy" "Charlie" "Alpha" ))
(p (into names arr)) ; adding array elements to the set
(p (into arr names)) ; adding set elements to the array

; ## Maps

(def batman {
  "Name"        "Batman"
  "Best Friend" "Robin"
  "Age"         70
})
(def robin {
    "Name" "Tio Robin",
    "Best Friend" "Batman",
    "Age" 45
})
(p batman robin)

(p (assoc batman "Car" "Batmovel"))
(p (dissoc batman "Name"))
(p (get batman "Age"))

(p (batman "Age"))
(p (robin "Name"))
; (p (nil "Age")) ; Error

(p (batman "Jarbas" "Defaut"))
(p (get batman "Jarbas" "Defaut"))

(p (contains? robin "Age"))
(p (keys robin))
(p (vals robin))

(def players #{ "Batman" "Robin" "Me" "Other guy" })

(p (zipmap players (repeat 0)))
(p (into {} (map (fn [player] [player 0]) players)))
(p (reduce (fn [m player] (assoc m player 0)) {} players))

(def scores (zipmap players (repeat 1)))
(def new-scores (zipmap names (repeat 2)))


(p scores new-scores)
(p (merge scores new-scores)) ; remove duplicates
(p (merge-with + scores new-scores)) ; Sum batman values (1 + 2 = 3)
(p (merge-with (fn [a b](* (+ a 1) (+ b 2))) scores new-scores))
(p (merge-with #(* (+ %1 1) (+ %2 2)) scores new-scores))
