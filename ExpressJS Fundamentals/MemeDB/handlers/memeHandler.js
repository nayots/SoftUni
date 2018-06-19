const fs = require('fs');
const db = require("../config/dataBase");
const qs = require("querystring");
const url = require("url");
const formidable = require("formidable");
const util = require("util");
const shortId = require("shortid");
const path = require("path");

module.exports = (req, res) => {
  if (req.pathname === '/viewAllMemes' && req.method === 'GET') {
    let filePath = "./views/viewAll.html";
    fs.readFile(filePath, (err, data) => {
      if (err) {
        console.log(err)
        return
      }

      let memes = db.getDb().sort((a, b) => {
        return b.dateStamp - a.dateStamp;
      });

      memes = memes.filter(m => m.privacy == "on");

      let content = "";

      for (const m of memes) {
        content +=
          `<div class="meme">
          <a href="/getDetails?id=${m.id}">
          <img class="memePoster" src="${m.memeSrc}"/>          
        </div>`
      }

      let html = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', content);

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })
      res.end(html)
    })
  } else if (req.pathname === '/addMeme' && req.method === 'GET') {
    let filePath = "./views/addMeme.html";
    fs.readFile(filePath, (err, data) => {
      if (err) {
        console.log(err)
        return
      }
      res.writeHead(200, {
        'Content-Type': 'text/html'
      })
      res.end(data)
    });
  } else if (req.pathname === '/addMeme' && req.method === 'POST') {
    let form = new formidable.IncomingForm();

    form.parse(req, (err, fields, files) => {
      if (err) {
        console.log(err)
        return
      }

      let title = fields["memeTitle"];
      let description = fields["memeDescription"];
      let status = fields["status"];
      let meme = files.meme;

      if (title && description && meme) {

        let memeStoragePath = "./public/memeStorage";
        fs.readdir(memeStoragePath, (err, data) => {

          let folders = data.filter(f => fs.statSync(path.join(memeStoragePath, f)).isDirectory());

          let destinationFolder = undefined;

          for (const fol of folders) {
            let filesCount = fs.readdirSync(path.join(memeStoragePath, fol)).length;
            if (filesCount < 1000) {
              destinationFolder = path.join(memeStoragePath, fol);
              break;
            }
          }

          if (!destinationFolder) {
            let lastFolderNumber = Number.parseInt(folders.pop());

            let newMemeStorageFolderName = isNaN(lastFolderNumber) ? "0" : lastFolderNumber + 1;

            destinationFolder = path.join(memeStoragePath, newMemeStorageFolderName.toString())
            fs.mkdirSync(destinationFolder);
          }

          let newFileName = shortId.generate() + "." + meme.name.split(".").pop();
          let memeLocation = path.join(destinationFolder, newFileName);
          fs.copyFile(meme.path, memeLocation, (err) => {
            if (err) {
              console.log(err)
              return
            }
            fs.unlink(meme.path, (err) => {
              if (err) {
                console.log(err)
                return
              }

              let newMeme = {
                id: shortId.generate(),
                title: title,
                memeSrc: memeLocation,
                description: description,
                privacy: status,
                dateStamp: Date.now()
              }

              db.add(newMeme);
              db.save().then(() => {
                res.writeHead(302, {
                  "Location": `/getDetails?id=${newMeme.id}`
                });

                res.end();
              })
            });
          });
        });
      } else {
        res.writeHead(400, {
          'Content-Type': 'text/html'
        })
        res.end("Bad request! All fields are required(except status)!");
      }
    })
  } else if (req.pathname.startsWith('/getDetails') && req.method === 'GET') {
    let filePath = "./views/details.html";
    fs.readFile(filePath, (err, data) => {
      if (err) {
        console.log(err)
        return
      }

      let queryData = qs.parse(url.parse(req.url).query);

      let memeId = queryData["id"];

      let meme = db.getDb().filter(m => m.id == memeId).shift();

      if (!meme) {
        res.writeHead(404, {
          'Content-Type': 'text/html'
        });
        res.end("No such meme exsits");
        return;
      }

      let content =
        `<div class="content">
        <img src="${meme.memeSrc}" alt=""/>
        <h3>Title  ${meme.title}</h3>
        <p> ${meme.description}</p>
        <button><a href="${meme.memeSrc}" download="${meme.memeSrc.split("\\").pop()}">Download Meme</a></button>
      </div>`;

      let html = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', content);

      res.writeHead(200, {
        'Content-Type': 'text/html'
      });
      res.end(html);
    });
  } else {
    return true
  }
}