const { Socket } = require('phoenix-channels')
let socket = new Socket("ws://127.0.0.1:4000/socket")

socket.connect()

let channel = socket.channel("room:test", {myMessage: "Batman"})

channel.join()
  .receive("ok", resp => { console.log("Joined successfully", resp) })
  .receive("error", resp => { console.log("Unable to join", resp) })