(ns test-api-2-pedestal.controller)

(defn respond-hello [request]
  (let [
        qp (get request :query-params)
        nm (get-in request [:query-params :name])]
    {:status 200 :body (str "Hello, " nm "\n" qp "\n")}))