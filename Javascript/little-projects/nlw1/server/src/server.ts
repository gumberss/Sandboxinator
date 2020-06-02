import express, { Request, Response, response } from 'express'

const app = express()

app.get('/users', async (req: Request, resp: Response) => {
  
  resp.json([
    'Test1',
    'Test2',
    'Test3'
  ])

})

app.listen(3333)