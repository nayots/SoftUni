const furnitureData = {}
let currentId = 0

module.exports = {
  total: () => Object.keys(furnitureData).length,
  save: (furniture) => {
    const id = ++currentId
    furniture.id = id

    let newFurniture = {
      id,
      make: furniture.make,
      model: furniture.model,
      year: furniture.year,
      description: furniture.description,
      price: furniture.price,
      image: furniture.image,
      createdOn: new Date(),
      createdBy: furniture.createdBy,
      likes: [],
      reviews: []
    }

    if (furniture.material) {
      newFurniture.material = furniture.material
    }

    furnitureData[id] = newFurniture
  },
  all: (page, search) => {
    const pageSize = 10

    let startIndex = (page - 1) * pageSize
    let endIndex = startIndex + pageSize

    return Object
      .keys(furnitureData)
      .map(key => furnitureData[key])
      .filter(furniture => {
        if (!search) {
          return true
        }

        const furnitureMake = furniture.make.toLowerCase()
        const furnitureModel = furniture.model.toLowerCase()
        const searchTerm = search.toLowerCase()

        return furnitureModel.indexOf(searchTerm) >= 0 ||
        furnitureMake.indexOf(searchTerm) >= 0
      })
      .sort((a, b) => b.id - a.id)
      .slice(startIndex, endIndex)
  },
  findById: (id) => {
    return furnitureData[id]
  },
  addReview: (id, rating, comment, user) => {
    const review = {
      rating,
      comment,
      user,
      createdOn: new Date()
    }

    furnitureData[id].reviews.push(review)
  },
  allReviews: (id) => {
    return furnitureData[id]
      .reviews
      .sort((a, b) => b.createdOn - a.createdOn)
      .slice(0)
  },
  like: (id, user) => {
    const likes = furnitureData[id].likes

    if (likes.indexOf(user) >= 0) {
      return false
    }

    likes.push(user)

    return true
  },
  byUser: (user) => {
    return Object
      .keys(furnitureData)
      .map(key => furnitureData[key])
      .filter(furniture => furniture.createdBy === user)
      .sort((a, b) => b.id - a.id)
  },
  delete: (id) => {
    delete furnitureData[id]
  }
}
