const http = require('http')
const url = require('url')
const handlers = require('./handlers/handlerBlender')
const db = require('./config/dataBase')
const port = 3000

db.load().then(() => {
  console.log('testing')
  
  http
    .createServer((req, res) => {
      for (let handler of handlers) {
        req.pathname = url.parse(req.url).pathname
        let task = handler(req, res)
        if (task !== true) {
          break
        }
      }
    })
    .listen(port)
    console.log('Im listening on '+port)
}).catch(()=>{
    console.log('Failed to load DB')
})
