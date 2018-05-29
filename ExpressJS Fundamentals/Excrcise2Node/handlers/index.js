const movieHandler = require("./movie-handler");
const staticHandler = require("./static-files");
const statusHandler = require("./status-handler");

module.exports= [statusHandler, movieHandler, staticHandler];