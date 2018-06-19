const url = require("url");
const qs = require("querystring");
const Image = require("../models/ImageSchema");
const Tag = require("../models/TagSchema");
const fs = require("fs");

module.exports = async (req, res) => {
  if (req.pathname === '/search') {
    let queryData = qs.parse(url.parse(req.url).query);

    let tagFilter = queryData.tagName ? { tags: { $in: queryData.tagName.split(',').filter(t => t !== '') } } : {};
      let beforeDate = queryData.beforeDate ? queryData.beforeDate : Date.now()
      let afterDate = queryData.afterDate ? queryData.afterDate : new Date(0, 0, 0)
      let limit = queryData.Limit ? Number(queryData.Limit) : 10
 
     
      Image.find(tagFilter)
      .where('creationDate')
      .gt(afterDate)
      .lt(beforeDate)
      .sort({creationDate: -1})
      .limit(limit)
      .then((images) => {
        displayResults(res, images)
      })

    function displayResults(res, images) {
      fs.readFile("./views/results.html", (err, data) => {
        if (err) {
          console.log(err);
        }
  
        let content = "";
        for (const img of images) {
          content +=
            `<fieldset id => <legend>${img.imageTitle}:</legend> 
              <img src="${img.imageUrl}">
              </img><p>${img.description}<p/>
              <button onclick='location.href="/delete?id=${img._id}"'class='deleteBtn'>Delete
              </button> 
              </fieldset>`
        }
  
        let html = data.toString().replace("<div class='replaceMe'></div>", content);
  
        res.writeHead(200, {
          'Content-Type': 'text/html'
        })
        res.end(html)
      })
    }
  } else {
    return true
  }
}