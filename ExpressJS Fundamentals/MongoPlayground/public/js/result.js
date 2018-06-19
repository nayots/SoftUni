let tagElements = document.querySelectorAll('.tag')
let tagField = document.querySelector('#tagField')
let tagsId = document.querySelector('#tagsId')

for(let t of tagElements){
   t.addEventListener('click',function(){
       console.log(this)
       console.log(this.innerText)
       tagField.value+= this.innerText+','
       tagsId.value += this.getAttribute('id')+','
   })
}