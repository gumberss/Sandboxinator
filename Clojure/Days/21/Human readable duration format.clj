; https://www.codewars.com/kata/52742f58faf5485cae000b9a
(ns human-readable)

(defn make-text [last-name s [name value]]
  (let [nam (if (> value 1 ) (str name "s") name)
        separator (cond (= name last-name) " and " :else ", ")]
  (if s (str s separator value " " nam) (str value " " nam))))

(defn parse [nam divide m]
  (let [remaining (rem (:remaining m) divide)
        current-total (quot (:remaining m) divide)]
  (assoc m :remaining remaining nam current-total)))

(defn formatDuration [secs]
  (let [data {:remaining secs}
        data (reduce #(%2 %1) data [(partial parse "year" (* 60 60 24 365))
                           (partial parse "day" (* 60 60 24))
                           (partial parse "hour" (* 60 60))
                           (partial parse "minute" 60)
                           (partial parse "second" 1)])
        filtered (filter #(> (last %) 0) data)
        last-filtered-name (first (last filtered))
        result (reduce (partial make-text last-filtered-name) nil filtered)]
    (if (= result nil) "now" result)))