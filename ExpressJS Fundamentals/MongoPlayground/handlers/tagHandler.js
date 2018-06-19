const formidable = require("formidable");
const Tag = require("../models/TagSchema");


module.exports = (req, res) => {
  if (req.pathname === '/generateTag' && req.method === 'POST') {
    let form = new formidable.IncomingForm();

    form.parse(req, (err, fields, files) => {
      let tagName = fields["tagName"];
      if (tagName) {
        Tag.find({}).where("tagName", tagName).exec().then((data) => {
          if (data.length == 0) {
            let tag = {
              tagName: tagName.toLowerCase(),
              creationDate: Date.now(),
              images: []
            }
            Tag.create(tag).then((createdTag) => {
              res.writeHead(302, {
                "Location": "/"
              });

              res.end();
            }).catch((err) => {
              console.log(err);
            })
          } else {
            res.writeHead(302, {
              "Location": "/"
            });

            res.end();
          }
        })
      } else {
        res.writeHead(400, {
          "Content-Type": "text/html"
        });
        res.end("Tag name is required");
      }
    })
  } else {
    return true
  }
}