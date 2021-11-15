(defn messenger [msg]
  (let [a 7
        b 5
        c (clojure.string/capitalize msg)]
    (println a b c)
  ) ;; end of let scope
) ;; end of function

(messenger "hi my little friend")

(defn sum-values [x] (fn [y] (+ x y)))
(def sum-with-ten (sum-values 10))
(println (sum-with-ten 20))


(defn say-something [something] (fn [receiver] (println "Hey" receiver ", listen: " something)))

(def say-hi-to (say-something "How are you?"))

(say-hi-to "Jarbas" )
(say-hi-to "Batman" )

(defn explain-action [action] (fn [explain] (println "I'm" action "because" explain)))

(def learning-why (explain-action "learning"))

(learning-why "I love it")
(learning-why "I like it")
(learning-why "I'm happy with it")

(defn sqrt [number] (Math/sqrt number))

(defn p [& text] (apply println text))

(p (sqrt 25))

(p (.length "Jarbas"))

(defn hi 
    ([] (p "Hi :)"))
    ([name] (p "Hi, " name " :D"))
    ([greet name] (p greet name " :D"))
)

(hi)
(hi "Batman")
(hi "Hello" "Batman")
