const mongoose = require("mongoose");

let tagSchema = mongoose.Schema({
    tagName: {type: mongoose.Schema.Types.String, required: true, unique: true},
    creationDate: {type: mongoose.Schema.Types.Date, required: true},
    images: [{type: mongoose.Schema.Types.ObjectId, ref: "Image"}]
});

tagSchema.methods.toLowerTag = function () {
    return this.model.tagName.toLowerCase();
}

let Tag = mongoose.model("Tag", tagSchema);

module.exports = Tag;