const mongoose = require("mongoose");

let editSchema = mongoose.Schema({
    author: {type: mongoose.Schema.Types.ObjectId, ref: 'User', required: [true, "Author is required!"]},
    creationDate: {type: mongoose.Schema.Types.Date, default: Date.now},
    content: {type: mongoose.Schema.Types.String, required: [true, "Article content is required!"]},
    article: {type: mongoose.Schema.Types.ObjectId, ref: "Article", required: [true, "An article is required!"]}
});

let Edit = mongoose.model("Edit", editSchema);

module.exports = Edit;