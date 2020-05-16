const express = require('express')
const cors = require('cors')
const bodyParser = require('body-parser')
const axios = require('axios')

const app = express()
app.use(bodyParser.json())
app.use(cors())

const posts = {}

app.get('/posts', (req, res) => {
	res.send(posts)
})

const handleEvent = (type, data) => {
	if (type === 'PostCreated') {
		const { id, title, status } = data
		posts[id] = {
			id,
			title,
			status,
			comments: [],
		}
	} else if (type === 'CommentCreated') {
		const { id, content, status, postId } = data

		const post = posts[postId]

		post.comments.push({
			id,
			content,
			status,
		})
	} else if (type === 'CommentUpdated') {
		const { id, content, status, postId } = data

		const post = posts[postId]

		const comment = post.comments.find(comment => comment.id == id)

		comment.status = status
		comment.content = content
	}
}

app.post('/events', (req, res) => {
	const { type, data } = req.body

	handleEvents(type, data)

	res.send({})
})

app.listen(4002, async () => {
	console.log('Listening on 4002')

	const res = await axios.get('http://localhost:4005/events')

	for (let event of res.data) {
        console.log('Processing event: ', event.type)
        handleEvent(event.type, event.data)
	}
})
