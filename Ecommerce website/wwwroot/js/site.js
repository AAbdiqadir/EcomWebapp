// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*let quantitychanged = document.getElementsByClassName("cart-quantity-input")
for (let i = 0; i < quantitychanged.length; i++) {
    let quantitychanged1 = quantitychanged[i]
    quantitychanged1.addEventListener("change", (e) => {
        var change1 = e.target
        if (change1.value <= 0) {
            change1.value = 1
        }
        updatetotalprice()
    })
}
function updatetotalprice(){
      let cartitems = document.querySelector(".items")
      console.log(cartitems)
      let cartrows = cartitems.querySelectorAll(".rows")
      var total = 0;
      for(let i= 0; i < cartrows.length; i++){
        let cart_row = cartrows[i]
        
        let quantity1 = cart_row.querySelector(".cart-quantity-input")
        let price_ = cart_row.querySelector(".price")
        
        let prices = price_.innerText.replace("£" ,"")
        let price = parseFloat(prices)
        
        let quantitys = quantity1.value
        let quantity = parseFloat(quantitys)
          let priceofproduct = price * quantity
          total = total + (price * quantity)
          cart_row.querySelector(".price").innerText = "£" + priceofproduct
        
      }
      document.querySelector(".cart-total-price").innerText = "£" +total
    }*/