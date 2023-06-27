


//I want this counter to go up infinitely just to insure that each item has a unique end.
sessionStorage.setItem('endCount', 0)

let cart = document.getElementById("cart")
let couter = document.getElementById("counter")
function addCartItem(item, name, size, quantity) {
    const CartItem = {
        itemId: item,
        itemName:name,
        size: size,
        quantity: quantity
    }
    const cartItemJson = JSON.stringify(CartItem)
    sessionStorage.setItem("CartItem" + sessionStorage.getItem('endCount'), cartItemJson)
    sessionStorage.setItem('endCount', parseInt(sessionStorage.getItem('endCount')) + 1)
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


function getCartItems(){
    var sessionItems = Object.keys(sessionStorage)
    for (let i = 0; i < sessionItems.length; i++){
        if (sessionItems[i].includes(`CartItem`)) {
            let currentItemJson = sessionStorage.getItem(sessionItems[i])
            let cartItem = JSON.parse(currentItemJson)
            cart.innerHTML += `<li class = "list-group-item">${cartItem['itemName']}</li>`
        }
     
    }
    counter.innerHTML = `Items in Cart: ${sessionItems.length-1}`
  
}