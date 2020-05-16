const express = require('express')
const bodyParser = require('body-parser')
const { randomBytes } = require('crypto')
const cors = require('cors')
const axios = require('axios')

const app = express()
app.use(bodyParser.json())
app.use(cors())

const posts = {}

app.get('/posts', (req, resp) => {
	resp.send(posts)
})

app.post('/posts', async (req, resp) => {
	const id = randomBytes(4).toString('hex')
	const { title } = req.body

	posts[id] = {
		id,
		title,
	}

	//event-bus-srv -> the cluser ip service's name of event-bus 
	await axios.post('http://event-bus-srv:4005/events', {
		type: 'PostCreated',
		data: {
			id,
			title,
		},
	})

	resp.status(201).send(posts[id])
})

app.post('/events', (req, res) => {
  console.log('Received Event:', req.body.type)

  res.send({})
})

app.listen(4000, () => {
	console.log('v23')
	console.log('Listening on 4000')
})
