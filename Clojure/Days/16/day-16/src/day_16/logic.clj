(ns day-16.logic)

(defn fit-in-the-queue? [company department]
  (some-> company
      department
      count
      (< 5)))
