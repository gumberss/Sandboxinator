const express = require('express')
const bodyParser = require('body-parser')
const axios = require('axios')

const app = express()

app.post('/events', (req, resp) => {
    
})

app.listen(4003, () => {
	console.log('Listinin on 4003')
})
