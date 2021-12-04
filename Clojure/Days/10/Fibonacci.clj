; O(log n)
(ns pentanacci.core)

(defn pos [f pos1 pos2] 
  (nth (nth f pos1) pos2))

(defn multiply [ f m ]      
    (def x (+ (* (pos f 0 0) (pos m 0 0)) (* (pos f 0 1) (pos m 1 0))))
    (def y (+ (* (pos f 0 0) (pos m 0 1)) (* (pos f 0 1) (pos m 1 1))))
    (def z (+ (* (pos f 1 0) (pos m 0 0)) (* (pos f 1 1) (pos m 1 0))))
    (def w (+ (* (pos f 1 0) (pos m 0 1)) (* (pos f 1 1) (pos m 1 1))))
                    
    [[x y] [z w]]
)

(defn power [current-matrix multiplier-matrix n]
  (cond 
    (<= n 1) current-matrix
    :else (do
            
      (def recursion-matrix (power current-matrix multiplier-matrix (quot n 2)))
      (def new-matrix (multiply recursion-matrix  recursion-matrix))
      (cond 
        (not= (mod n 2) 0) (multiply new-matrix multiplier-matrix)
        :else new-matrix)
    ))
)

(defn count-odd-pentaFib [n]
  (def matrix [[1 1][1 0]])
  (pos (power matrix matrix (dec n)) 0 0)
)
