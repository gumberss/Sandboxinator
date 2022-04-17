(ns test-api-2-pedestal.controller)

(defn respond-hello [request]
  (let [
        qp (get request :query-params)
        nm (get-in request [:query-params :name])]
    {:status 200 :body (str "Hello, " nm "\n" qp "\n")}))

;(def sequ (->> "Hello World" (re-seq #"\w+")))
#_
    (defn invert-first [word]
      (let [f (first word)
            r (rest word)]
        (apply str (conj (vec r) f))))

#_ (defn add-ay [word]
     (str word "ay"))