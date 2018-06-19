const formidable = require("formidable");
const Image = require("../models/ImageSchema");
const Tag = require("../models/TagSchema");
const url = require("url");
const qs = require("querystring");

module.exports = (req, res) => {
  if (req.pathname === '/addImage' && req.method === 'POST') {
    addImage(req, res)
  } else if (req.pathname === '/delete' && req.method === 'GET') {
    deleteImg(req, res)
  } else {
    return true
  }
}

function deleteImg(req, res) {
  let queryData = qs.parse(url.parse(req.url).query);

  if (queryData.id) {
    Image.findById(queryData.id).then((img) => {
      Image.deleteOne({"_id": queryData.id}).then((r) => {
        for (const imgRef of img.tags) {
          let tagId = imgRef.toString();
          Tag.findById(tagId).then((t) => {
            let result = t.images.filter((ta) => ta.toString() !== img._id.toString());
            t.images = result;
            t.save();
          }).catch((err) => console.log(err));
        }

        res.writeHead(302, {
            "Location": "/"
        });
        res.end();
      })
    }).catch((err) => {
      console.log(err);
    })
  }
}

function addImage(req, res) {
  let form = new formidable.IncomingForm();

  form.parse(req, (err, fields, files) => {
    if (err) {
      console.log(err);
      return;
    }

    if (fields.imageTitle && fields.imageUrl && fields.tagsID && fields.description) {

      let filteredTags = fields.tagsID.split(",").filter(v => v !== "").filter((v, i, coll) => {
        return coll.indexOf(v) == i;
      })

      let image = {
        imageTitle: fields.imageTitle,
        imageUrl: fields.imageUrl,
        creationDate: Date.now(),
        description: fields.description,
        tags: filteredTags
      }

      Image.create(image).then((createdImage) => {
        for (const fTag of filteredTags) {
          Tag.findById(fTag).then((t) => {
            t.images.push(createdImage._id);
            t.save();
          })
        }

        res.writeHead(302, {
          "Location": "/"
        });

        res.end();
      }).catch((err) => {
        console.log(err);
      })
    } else {
      res.writeHead(400, {
        "Content-Type": "text/html"
      });
      res.end("All fields are required");
    }
  })
}