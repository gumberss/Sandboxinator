async function handler(event, context){
  console.log('Environment: ', JSON.stringify(process.env, null, 2))
  console.log('Evento: ', JSON.stringify(event, null, 2))
  console.log(':)')
  return {
    hello: 'world'
  }
}

module.exports = {
  handler
}