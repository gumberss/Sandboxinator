(ns projeto-1.core-test
  (:require [clojure.test :refer :all]
            [projeto-1.core :refer :all]))



(deftest test1-test
  (testing "Valores de 100 reais ou menos"
    (is (= 15 (taxa-de-entrega 99)))
    (is (= 15 (taxa-de-entrega 100)))))

(deftest test2-test
  (testing "Valores maiores que 100 e menores ou iguais a duzentos"
    (is (= 5 (taxa-de-entrega 100.01)))
    (is (= 5 (taxa-de-entrega 200.00)))))

(deftest test3-test
  (testing "Valores acima de 200"
    (is (= 0 (taxa-de-entrega 200.01)))
    (is (= 0 (taxa-de-entrega 500.00)))))