-- https://www.codewars.com/kata/514b92a657cdc65150000006/train/haskell

module MultiplesOf3And5 where

solution :: Integer -> Integer
solution number = 
    sum (filter(\c -> c `rem` 3 == 0 || c `rem` 5 == 0) [1..number - 1])
