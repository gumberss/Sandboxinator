const express = require("express");
const bodyParser = require('body-parser')
const { randomBytes } = require("crypto");

const app = express();
app.use(bodyParser.json())

const posts = {};

app.get("/posts", (req, resp) => {
  resp.send(posts);
});

app.post("/posts", (req, resp) => {
  const id = randomBytes(4).toString("hex");
  const { title } = req.body;

  posts[id] = {
    id,
    title,
  };

  resp.status(201).send(posts[id])
});

app.listen(4000, () => {
  console.log("Listening on 4000");
});
