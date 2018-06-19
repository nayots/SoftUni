const http = require('http')
const url = require('url')
const qs = require('querystring')
const port = process.env.PORT || 3000
const handlers = require('./handlers/handlerBlender')
const db = require('./config/db');

db("mongodb://localhost:27017/MongoDbPlayGroundDatabase")

http
  .createServer(async (req, res) => {
    req.pathname = url.parse(req.url).pathname
    req.pathquery = qs.parse(url.parse(req.url).query)
    for (let handler of handlers) {
      if (!handler(req, res)) {
        break
      }
    }
  })
  .listen(port)
