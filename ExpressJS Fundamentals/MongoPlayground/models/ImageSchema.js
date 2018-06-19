const mongoose = require("mongoose");

let imageSchema = mongoose.Schema({
    imageTitle: {type: mongoose.Schema.Types.String, required: true},
    imageUrl: {type: mongoose.Schema.Types.String, required: true},
    creationDate: {type: mongoose.Schema.Types.Date, required: true},
    description: {type: mongoose.Schema.Types.String, required: true},
    tags: [{type: mongoose.Schema.Types.ObjectId, ref: "Tag"}]
});

let Image = mongoose.model("Image", imageSchema);

module.exports = Image;