(ns deeper.core
  (:use [clojure pprint]))

(defn empty-queue
  []
  (clojure.lang.PersistentQueue/EMPTY))

; domain
(defn store-builder []
  {:stock {
           :banana {:description "Bananas" :count 10}
           :potato {:description "Potatos :D" :count 5}
           :orange {:description "It's not a color" :count 12}}})
;logic
(defn receive-new-product [store product count]
  (update-in store [:stock product :count] (partial + count)))



;side effects
(pprint (receive-new-product (store-builder) :banana 10))

(defn change []
  (let [store (atom (store-builder))]
    (swap! store receive-new-product :banana 100)
    (swap! store receive-new-product :banana 100)
    (pprint store)))

;(change)

(defn store-builder-ref []
  {:stock {
           :banana (ref {:description "Bananas" :count 10})
           :potato (ref {:description "Potatos :D" :count 5})
           :orange (ref {:description "It's not a color" :count 12})}})

(defn receive-ref [product count]
  (update product :count (partial + count)))

(defn receive-new-product-ref [stock product count]
  (let [produc (get stock product)]
    (ref-set produc (receive-ref @produc count))))

(defn change-ref []
  (let [store (store-builder-ref)]
    (dosync (receive-new-product-ref (get store :stock) :banana 1000))
    (dosync (receive-new-product-ref (get store :stock) :banana 1000))
    (pprint store)))

;(change-ref)


(defn receive-ref [product count]
  (update product :count (partial + count)))

(defn receive-new-product-ref [stock product count]
  (let [produc (get stock product)]
    (alter produc receive-ref count)))

(defn send-bullet
  "._."
  [store]
  (mapv #(future
           (Thread/sleep (rand 2000))
           (println "medo feito" %)
           (dosync
             (receive-new-product-ref
               (get store :stock) :banana %)))
        (range 10)))

(defn change-ref-alter []
  (let [store (store-builder-ref)
        futures (send-bullet store)]
    ;   (dosync (receive-new-product-ref (get store :stock) :banana 10000))
    ;(dosync (receive-new-product-ref (get store :stock) :banana 10000))

    (future
      (Thread/sleep 1000)
      (pprint store)
      (pprint futures))))

(change-ref-alter)


(println "oi")
(pprint (map :description (vals (get (store-builder) :stock))))
(println "----------------------------------------------------------------------------")








