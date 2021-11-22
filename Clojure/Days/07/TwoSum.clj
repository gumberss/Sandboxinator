(ns twosum)
; O(n)
; Add and find an item in hashed lists cost O(1)
; Recursive is O(n) because in the worst case, will iterate all the numbers inside numbers list
(defn recursive [hashed target numbers current-index]  
  (let [current (first numbers)
        diff (- target current)
        item-hashed (get hashed diff)]
  (cond
    (not= nil item-hashed) {item-hashed current-index}
    :else (recur (assoc hashed current current-index) target (rest numbers) (inc current-index))
    )
  )
)
; O(n)
(defn twosum [numbers target]
 (first (recursive {} target numbers 0)))


; Using more lets :)
(ns twosum)
; O(n)
(defn recursive [hashed target numbers current-index]  
  (let [current (first numbers)
        diff (- target current)
        item-hashed (get hashed diff)
        new-hashed (assoc hashed current current-index)
        next-index (inc current-index)]
  (cond
    (not= nil item-hashed) {item-hashed current-index}
    :else (recur new-hashed target (rest numbers) next-index)
    )
  )
)
; O(n)
(defn twosum [numbers target]
 (first (recursive {} target numbers 0)))


; Using For O(n²)
(ns twosum)

; O(n²)
(defn twosum [numbers target]
  (first
  (for [i (range (count numbers))
        j (range (count numbers))
        :when (and (not= i j)
                (= target (+ (nth numbers i) (nth numbers j))))]
    [i j])))
