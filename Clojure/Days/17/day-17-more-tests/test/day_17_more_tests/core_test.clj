(ns day-17-more-tests.core-test
  (:require [clojure.test :refer :all]
            [day-17-more-tests.core :refer :all]))

(deftest testing-enter-in
  (let [store store
        result {:cashiers {:cashier1 {:id :cashier1 :queue []}
                           :cashier2 {:id :cashier2 :queue []}}
                :inside   #{{:id 2 :name "Batman"}}}]
    (testing "Should add a person in 'inside' hashmap when a person arrive to the store"
      (is (= result (enter-in store {:id 2 :name "Batman"})))
      )))

(deftest testing-find-best-cashier-to-go
  (testing "Should find cashier1 when cashier1 has less people inside than others"
    (let [store {:cashiers {:cashier1 {:id :cashier1 :queue [{:id 65 :name "Batman"}]}
                            :cashier2 {:id :cashier2 :queue [{:id 3 :name "Robin"} {:id 97 :name "Tony"}]}}
                 :inside   #{}}]
      (is (= :cashier1 (find-best-cashier-to-go store)))))
  (testing "Should find cashier2 when cashier2 has less people inside than others"
    (let [store {:cashiers {:cashier1 {:id :cashier1 :queue [{:id 3 :name "Robin"} {:id 97 :name "Tony"}]}
                            :cashier2 {:id :cashier2 :queue [{:id 65 :name "Batman"}]}}
                 :inside   #{}}]
      (is (= :cashier2 (find-best-cashier-to-go store)))))
  (testing "Should find the first queue when all the queues are empty"
    (let [store {:cashiers {:cashier1 {:id :cashier1 :queue []}
                            :cashier2 {:id :cashier2 :queue []}}
                 :inside   #{}}]
      (is (= :cashier1 (find-best-cashier-to-go store))))))

(deftest testing-go-to-cashier
  (testing "Should forward a person to a carrier when the person want to finish its purchase"
    (let [person {:id 65 :name "Batman"}
          store {:cashiers {:cashier1 {:id :cashier1 :queue []}
                            :cashier2 {:id :cashier2 :queue []}}
                 :inside   #{ person {:id 23 :name "Robin"}}}]
      (is (= {:cashiers {:cashier1 {:id :cashier1 :queue []}
                         :cashier2 {:id :cashier2 :queue [person]}}
              :inside   #{{:id 23 :name "Robin"}}}
            (go-to-cashier store :cashier2 person))))))