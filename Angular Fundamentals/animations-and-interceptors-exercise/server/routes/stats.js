const express = require('express')
const furnitureData = require('../data/furniture')
const usersData = require('../data/users')

const router = new express.Router()

router.get('/', (req, res) => {
  const furniture = furnitureData.total()
  const users = usersData.total()

  res.status(200).json({
    furniture,
    users
  })
})

module.exports = router
