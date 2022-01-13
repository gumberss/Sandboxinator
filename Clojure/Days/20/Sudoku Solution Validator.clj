; https://www.codewars.com/kata/529bf0e9bdf7657179000008

(ns sudoku)

(defn validate-vector [v]
    (every? #(= (range 1 10) (sort %)) v))

(defn valid-solution [board]
  (let [reverse-board (apply map vector board)
        chunk-board (mapcat  #(map (partial reduce concat) %)
                             (map (partial partition 3)
                                  (map (partial apply map vector) 
                                       (partition 3 board))))]
  (and (validate-vector board)
       (validate-vector reverse-board)
       (validate-vector chunk-board))))
