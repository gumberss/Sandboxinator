(defproject test-api "0.1.0-SNAPSHOT"
  :description "FIXME: write description"
  :url "http://example.com/FIXME"
  :license {:name "EPL-2.0 OR GPL-2.0-or-later WITH Classpath-exception-2.0"
            :url "https://www.eclipse.org/legal/epl-2.0/"}
  :dependencies [[org.clojure/clojure "1.10.1"]
                 [com.stuartsierra/dependency "1.0.0"]
                 [com.stuartsierra/component "1.0.0"]
                 [io.pedestal/pedestal.service "0.5.7"]
                 [io.pedestal/pedestal.route "0.5.7"]
                 [com.stuartsierra/component.repl "0.2.0"]
                 [io.pedestal/pedestal.jetty "0.5.7"]
                 [org.clojure/data.json "0.2.6"]
                 [org.slf4j/slf4j-simple "1.7.28"]]
  :repl-options {:init-ns test-api.core})
