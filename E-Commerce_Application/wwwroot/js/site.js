
sessionStorage.setItem('count', 0)
let cart = document.getElementbyId("cart")

function addCartItem(item, name, size, quantity) {
    const CartItem = {
        itemId: item,
        itemName:name,
        size: size,
        quantity: quantity
    }
    const cartItemJson = JSON.stringify(CartItem)
    sessionStorage.setItem("CartItem" + sessionStorage.getItem('count'), cartItemJson)
    sessionStorage.setItem('count', sessionStorage.getItem('count') + 1)

}

function removeCartItem(itemName) {
    sessionStorage.removeItem(itemName)
}

function submitCartItem() {
    var itemId = document.getElementById("itemId").value;
    var name = document.getElementById("name").value;
    var size = document.getElementById('size').value;
    var quantity = document.getElementById("quantity").value;

    addCartItem(itemId, name, size, quantity)
}


cart.addEventListener('load',()=>{
    var sessionItems = Object.keys(sessionStorage)
    for (let i = 0; i < sessionItems.length, i++;){
        if (sessionItems[i].includes("CartItem")){
                let currentItemJson = sessionStorage.getItem(sessionItems[i])
                let cartItem = JSON.parse(currentItemJson)
                cart.innerHTML =+ `<li>${cartItem.itemName}<li>`
        }
    }
    let paragraph = document.getElementById("addedItem")

    paragraph.classList.remove("hidden")
})