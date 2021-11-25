;https://www.codewars.com/kata/56541980fa08ab47a0000040/train/clojure

; First solution
(ns printer.core)

(defn printer-error [s]
  ( 
   ->
    (- (count s) (count (filter #( and (>= (int %1) (int \a)) (<= (int %1) (int \m))) s)))
    (str "/" (count s))
   )
  ) 

; Refactor to valid? method
; and use let

(ns printer.core)

(defn valid? [c]
  (let [ m (int \m)
         a (int \a)
         ch (int c)]
   ( and (>= ch a) (<= ch m))
))

(defn printer-error [s]
  (let [ length (count s)]
    ( ->
      (- length (count (filter valid? s)))
      (str "/" length)
     )
  ) 
)

; using re-seq 
(ns printer.core)

(defn printer-error [s]
  (let [len (count s)]
    (str ( ->> s (re-seq #"[^n-z]") (count) (- len)) "/" len)
  )
)

; or if you do not care if the printer print others characters like $, % 1... (As was asked, but I'd rather, to learn, to filter chars a-m )

(ns printer.core)

(defn printer-error [s]
  (str (count (re-seq #"[n-z]" s)) "/" (count s))
)
