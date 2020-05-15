const express = require("express");
const bodyParser = require("body-parser");
const { randomBytes } = require("crypto");
const cors = require('cors')

const app = express();
app.use(bodyParser.json());
app.use(cors())

const commentsByPostId = {};

app.get("/posts/:id/comments", (req, resp) => {
  resp.send(commentsByPostId[req.params.id] || []);
});

app.post("/posts/:id/comments", (req, resp) => {
  const id = randomBytes(4).toString("hex");
  const { content } = req.body;

  let postId = req.params.id;

  let comments = commentsByPostId[postId] || [];

  comments.push({
    id,
    content,
  });

  commentsByPostId[postId] = comments;

  resp.status(201).send(comments);
});

app.listen(4001, () => {
  console.log("Listening on 4001");
});
