(ns day-16.logic-test
  (:require [clojure.test :refer :all]
            [day-16.logic :refer :all]))

(defn should-be [value expected]
  (is (= value expected)))

(defn should-be-false [value]
  (is (= value false)))


(deftest fit-in-the-queue?-test
  (testing "Fit in the queue"
    (let [company {:waiting []}]
      (is (fit-in-the-queue? company :waiting))))

  (testing "It should not fit in the queue when the queue is full"
    (let [company {:waiting [1 2 3 4 5]}]
      (-> (fit-in-the-queue? company :waiting) (should-be false))))

  (testing "It should not fit in the queue when the queue is overflowing o.o"
    (let [company {:waiting [1 2 3 4 5 6 7]}]
      (-> (fit-in-the-queue? company :waiting) should-be-false)))

  (testing "It should fit in the queue when the queue is almost full"
    (let [company {:waiting [1 2 3]}]
      (is (= (fit-in-the-queue? company :waiting)) true)))

  (testing "It should fit in the queue when the queue is almost empty"
    (let [company {:waiting [1]}]
      (is (fit-in-the-queue? company :waiting))))

  (testing "It should not fit in the queue when the queue does not exist"
    (let [company {:waiting [1 2 3]}]
      (is (not (fit-in-the-queue? company :not-existent-queue))))))