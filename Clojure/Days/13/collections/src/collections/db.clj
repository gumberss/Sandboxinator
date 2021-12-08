(ns collections.db)

(def pedido1 { :usuario 1
              :itens {:mochila {:id :mochila :quantidade 2 :preco-unitario 100}
                      :camiseta {:id :camiseta :quantidade 2 :preco-unitario 50}
                      :meia {:id :meia :quantidade 1}}
              })

(def pedido2 { :usuario 1
              :itens {:mochila {:id :mochila :quantidade 2 :preco-unitario 100}
                      :camiseta {:id :camiseta :quantidade 2 :preco-unitario 50}
                      :meia {:id :meia :quantidade 1}}
              })

(def pedido3 { :usuario 2
              :itens {:mochila {:id :mochila :quantidade 2 :preco-unitario 100}
                      :camiseta {:id :camiseta :quantidade 2 :preco-unitario 50}
                      :meia {:id :meia :quantidade 1}}
              })

(def pedido4 { :usuario 3
              :itens {:mochila {:id :mochila :quantidade 20 :preco-unitario 100}
                      :camiseta {:id :camiseta :quantidade 2 :preco-unitario 50}
                      :meia {:id :meia :quantidade 1}}
              })

(def pedido5 { :usuario 4
              :itens {:mochila {:id :mochila :quantidade 2 :preco-unitario 100}
                      :camiseta {:id :camiseta :quantidade 10 :preco-unitario 50}
                      :meia {:id :meia :quantidade 1}}
              })

(defn todos-pedidos []
  [pedido1 pedido2 pedido3 pedido4 pedido5])