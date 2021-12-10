(ns deeper.record
  (:use [clojure pprint]))

(println "bora")

(defrecord Batman [id name best-friend])

(def batman (->Batman 10 "Tio Bat" "Robin"))
(println batman)
(pprint batman)

(def batman (Batman. 100 "Batman" "Probably Robin"))
(println batman)
(pprint batman)
(println (=
           (Batman. 100 "Batman" "Probably Robin")
           (Batman. 100 "Batman" "Probably Robin")))
(println (=
           (Batman. 100 "Batman" "Other person")
           (Batman. 100 "Batman" "Probably Robin")))        ; not check reference
(pprint (.equals batman batman))                            ; check reference
(pprint (.equals batman (->Batman 10 "Tio Bat" "Robin")))   ; check reference

(println (map->Batman {:id 9999 :name "Uncle Batman" :best-friend "Uncle Robin"}))
(println (map->Batman {:best-friend "Uncle Robin"}))
;(Batman. 100 "Batman" "Probably Robin" "Other thing" "I cant create other property)
(println (map->Batman {:id             9999
                       :name           "Uncle Batman"
                       :best-friend    "Uncle Robin"
                       :other-property "Yes I can do it"}))

(pprint (.name batman))
(pprint (class batman))
(pprint (.hashCode batman))

(defn can-do-it? [map]
  (if-let [id (get map :id)]
    (str "yes " id)
    "no"))

(println (can-do-it? { :id 10 }))
(println (can-do-it? {:not-id 10}))

(println "--------------------PROTOCOL-----------------")

(defprotocol Hero
  (save-the-world [hero]))

(extend-type Batman Hero
  (save-the-world [hero]
    (println "I save the world like a bat")))

(defrecord IronMan [name])
(def iron-man (IronMan. "Mark 11"))

(extend-type IronMan Hero
  (save-the-world [hero]
    (println "I'm" (get hero :name))))

(save-the-world batman)
(save-the-world iron-man)

(defrecord SuperMan [age]
  Hero
  (save-the-world [hero]
    (println "I'm" (get hero :age) "and i save the world")))


(save-the-world (->SuperMan 38))

(println "------------------------ EXTENSION METHODS?---------------------")

(defprotocol Dateable (to-ms [this]))

(extend-type java.lang.Number
  Dateable
  (to-ms [this] this))

(println (to-ms 10))

(extend-type java.util.Date
  Dateable
  (to-ms [this] (.getTime this)))

(println (to-ms (java.util.Date.)))

(extend-type java.util.Calendar
  Dateable
  (to-ms [this] (to-ms (.getTime this))))

(pprint (to-ms (java.util.GregorianCalendar.)))





