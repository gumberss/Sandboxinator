(ns collections.queues
  (:use [clojure pprint])
  (:require [collections.queues-logic :as c.queues-logic]))


(pprint c.queues-logic/hospital)

(def hospital (c.queues-logic/come-to c.queues-logic/hospital 111))
(def hospital (c.queues-logic/come-to hospital 222))
(def hospital (c.queues-logic/come-to hospital 333))
(def hospital (c.queues-logic/come-to hospital 444))
(def hospital (c.queues-logic/come-to hospital 555))
;(def hospital (c.queues-logic/come-to hospital 111))

(pprint hospital)
(def hospital (c.queues-logic/forward :laboratory1 hospital))


(pprint hospital)


(pprint (atom {}))
(defn test-atom []
  (let [atom (atom {})]
    (pprint (deref atom))
    (pprint @atom)

    (pprint (assoc @atom :nao-vai-ficar c.queues-logic/empty-queue))
    (pprint @atom)

    (pprint (swap! atom assoc :agora-vai-ficar c.queues-logic/empty-queue))
    (pprint @atom)

    (swap! atom update :agora-vai-ficar conj 123)
    (pprint @atom)
    ))

(test-atom)


(defn teste-atom2 []
  (let [atomio (atom [])]
    (pprint (swap! atomio conj 1 2 3 4 5))
    ))

(teste-atom2)


(defn test-atom3 []
  (let [tio-atom (atom 1)]
    (-> tio-atom (swap! inc) (pprint))
    (-> tio-atom (swap! inc) (pprint))
    (-> tio-atom (swap! inc) (pprint))
    (-> tio-atom (swap! inc) (pprint))
    (-> tio-atom (swap! inc) (pprint))))
(test-atom3)

(defn test-atom4 []
  (let [tio-atom (atom '(5))]
    (swap! tio-atom conj 4)
    (swap! tio-atom conj 3)
    (swap! tio-atom conj 2)
    (swap! tio-atom conj 1)
    (pprint @tio-atom)))

(test-atom4)


(defn sum [num1 num2]
  (+ num1 num2))

(println ((partial sum 1) 2))

(defn bigger? [num1 num2]
  (> num1 num2))

(println ((partial bigger? 10) 1))

(defn my-if [cond do-thing else-thing]
  (if cond
    (do-thing)
    (else-thing)))

(pprint "q")
(my-if (> 10 1) #(pprint "aham") #(pprint "não"))

(pprint "q2")
((partial (partial my-if (> 10 1) #(pprint "aham"))) #(pprint "não"))

(println "apply and partial")

(defn my-if2 [cond ok err]
  (if cond
    ok
    err))

(println ((-> (partial my-if2 (> 10 1))
              (partial "aham")
              (partial "no"))))

(println (apply + [1 2 3 4 5 6 7]))
(println (apply map #(+ %1 %2) [[1 2 3] [3 2 1]]))
(println (map (partial reduce +) [[1 2 3] [3 2 1]]))
(println (reduce + (map (partial reduce +) [[1 2 3] [3 2 1]])))
(println (reduce concat [[1 2 3] [3 2 1]]))
(println (reduce (partial map +) [[1 2 3] [3 2 1]]))
(println (reduce (partial map +) [[1 2 3] [3 2 1] [4 5 6]]))
; lines to columns
(println (apply map #(into [] [%1 %2 %3]) [[1 2 3]
                                           [4 5 6]
                                           [7 8 9]]))
;to vector (mapv)
(println (apply mapv #(into [] [%1 %2 %3]) [[1 2 3]
                                            [4 5 6]
                                            [7 8 9]]))
; invert list
(println (into () '(1 2 3)))

(println "Juxt and comp")
(pprint ((juxt count (partial reduce +)) [1 2 3 4 5]))

(pprint ((juxt count (partial apply +)) [1 2 3 4 5]))

(pprint ((juxt
           (comp
             (partial reduce +)
             (partial map #(+ % 1)))
           (partial apply +)) [1 2 3 4 5]))

(pprint (reduce + ((juxt
                     (comp
                       (partial apply +)
                       (partial map #(+ % 1)))
                     (partial apply +)) [1 2 3 4 5])))

