const express = require('express')
const cors = require('cors')
const bodyParser = require('body-parser')

const app = express()
app.use(bodyParser.json())
app.use(cors())

const posts = {}

app.get('/posts', (req, res) => {
	res.send(posts)
})

app.post('/events', (req, res) => {
	const { type, data } = req.body

	if (type === 'PostCreated') {
		const { id, title, status } = data
		posts[id] = {
			id,
			title,
			status,
			comments: [],
		}
	} else if (type === 'CommentCreated') {
		const { id, content, postId } = data

		const post = posts[postId]

		post.comments.push({
			id,
			content,
		})
	} else if (type === 'CommentUpdated') {
		const { id, content, status, postId } = data

		const post = posts[postId]

		const comment = post.comments.find(comment => comment.id == id)

		comment.status = status
		comment.content = content
	}

	res.send({})
})

app.listen(4002, () => {
	console.log('Listening on 4002')
})
