class Handler {
	async main() {
		try {
			return {
				statusCode: 200,
				body: 'Hello',
			}
		} catch (err) {
			return {
				statusCode: 200,
				body: 'An error ' + JSON.stringify(err),
			}
		}
	}
}

const handler = new Handler()
module.exports = handler.main.bind(handler)