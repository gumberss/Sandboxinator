(ns collections.queues-logic)

(def empty-queue clojure.lang.PersistentQueue/EMPTY)

(def hospital {
               :front-desk  empty-queue
               :laboratory1 empty-queue
               :laboratory2 empty-queue
               :laboratory3 empty-queue
               })

(defn cabe-na-fila? [hospital department]
  (-> hospital
      (get department)
      count
      (< 5)))

(defn receive-person
  [hospital department person]
  (if (cabe-na-fila? hospital department)
    (update hospital department conj person)
    (throw (ex-info "The queue is full!" {:department department :person person}))))

(defn come-to [hospital person]
  (receive-person hospital :front-desk person))

(defn next-to-answer [hospital department]
  (peek (get hospital department)))

(defn answer-from [hospital department]
  (update hospital department pop))

(defn forward [laboratory hospital]
  (let [person (next-to-answer hospital :front-desk)]
    (-> hospital
        (answer-from :front-desk)
        (update laboratory conj person))))


