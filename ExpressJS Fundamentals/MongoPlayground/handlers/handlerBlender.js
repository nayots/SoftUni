const homeHandler= require('./homeHandler')
const addImageHandler = require('./addImageHandler')
const addTagHandler = require('./tagHandler')
const searchHandler = require('./searchHandler')
const staticFileHandler = require('./staticHandler')

module.exports = [homeHandler,addTagHandler,searchHandler,addImageHandler,staticFileHandler]