const express = require('express')
const fs = require('fs')
const cors = require('cors')
const port = 9999
let app = express()

let bioCollection = fs.readFileSync('./db/bioDb.json')
let epCollection = fs.readFileSync('./db/epDb.json')

epCollection = JSON.parse(epCollection.toString())
bioCollection = JSON.parse(bioCollection.toString())

app.use(cors())

app.get('/roster',(req,res)=>{
    res.send(bioCollection)
})

app.get('/character/:id',(req,res)=>{
    let targetElem = req.params.id
    let target = bioCollection.find(x=>{
        if(x.id==targetElem){
            return x
        }
    })
    res.send(JSON.stringify(target))     
})

//Colection episodes

app.get('/episodePreview/:id',(req,res)=>{
    let targetElem = req.params.id
    
    if(Number(targetElem)<0){
        console.log(targetElem)
        targetElem=0
    }
    if(Number(targetElem)>=epCollection.length){
        console.log(targetElem)
        
        targetElem=epCollection.length-1
    }
    let target = epCollection.find(x=>{
        if(x.id==targetElem){
            return x
        }
    })

    

    res.send(JSON.stringify(target))
})

app.listen(port)
console.log(port)