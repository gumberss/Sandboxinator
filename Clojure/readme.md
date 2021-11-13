# The Beginning
- https://clojure.org/guides/learn/syntax
- The unit of source code is a Clojure expression, not a Clojure source file
- Source files are read as a series of expressions

![image](https://user-images.githubusercontent.com/38296002/141652702-aac42720-f77a-4e09-9882-a309cceb9a89.png)

In the diagram, (+ 3 4) is read as a list containing the symbol (+) and two numbers (3 and 4). The first element (where + is found) can be called "function position", that is, a place to find the thing to invoke


## Delaying evaluation with quoting
- use symbol '
- '(1,2,3)
- 'x

## Find documentation
- `(doc +) ; + is the function I want to see the documentation`
- Not sure what something is called? Use `(apropos "+")`
- You can also widen your search to include the docstrings themselves with find-doc: `(find-doc "trim")`
- If you’d like to see a full listing of the functions in a particular namespace, you can use the dir function `(dir clojure.repl)`
- To see not only the documentation but the underlying source for any function accessible by the runtime: `(source dir)`

![image](https://user-images.githubusercontent.com/38296002/141655218-7e1577b7-debb-4dfa-9661-68cd1c1ecd1e.png)


Source: https://clojure.org/guides/learn/syntax
