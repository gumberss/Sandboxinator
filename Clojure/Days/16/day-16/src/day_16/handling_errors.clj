(ns day-16.handling-errors)

(s/set-fn-validation! true)

(def Result
  {:status s/Keyword :value s/Any})


(s/defn runner :- Result [fun]
        (try
          {:status :success :value (fun)}
          (catch Exception e
            {:status :fail :value e}
            )))


(defn handle [func success error]
  (let [{status :status value :value} (runner func)]
    (if (= status :success)
      (success value)
      (error value)))
  )

(defn random-functin []
  (if (< 5 (rand 10))
    :everything-ok
    (throw (ex-info "error" {"hi" "hihi"}))))


(defn some-flow []
  (handle
    random-functin
    #(str "Handling success!! " %)
    #(str "Handling errors :( :(" %)))

(println (some-flow))