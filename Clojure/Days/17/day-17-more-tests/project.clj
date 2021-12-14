(defproject day-17-more-tests "0.1.0-SNAPSHOT"
  :description "FIXME: write description"
  :url "http://example.com/FIXME"
  :main day-17-more-tests.core
  :aot [day-17-more-tests.core]
  :profiles {:dev {:dependencies [[ring/ring-devel "1.4.0"]]}}
  :license {:name "EPL-2.0 OR GPL-2.0-or-later WITH Classpath-exception-2.0"
            :url "https://www.eclipse.org/legal/epl-2.0/"}
  :dependencies [[org.clojure/clojure "1.10.1"]
                 [prismatic/schema "1.2.0"]
                 [org.clojure/test.check "1.1.1"]]
:repl-options {:init-ns day-17-more-tests.core})
