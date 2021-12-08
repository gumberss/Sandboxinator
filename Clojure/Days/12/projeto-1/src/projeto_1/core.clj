(ns projeto-1.core)

(defn taxa-de-entrega
  "Calcula a taxa de entrega com base nas regras de negócio...."
  [valor-da-compra]
       (if (<= valor-da-compra 100)
         15
        (if (<= valor-da-compra 200)
          5
          0)))
; Intelij
; cmd shift + p - > executa a linha
; cmd shift + k -> coloca a aexpressão dentro dos parenteses
; cmd shift + j -> tira a aexpressão de dentro dos parenteses


(def pedido {:mochila {:quantidade 2 :preco 80}})

