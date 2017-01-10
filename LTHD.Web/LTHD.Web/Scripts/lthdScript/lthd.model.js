var model = {
    products: ko.observableArray([]),
    categories: ko.observableArray([]),
    orders: ko.observableArray([]),
    authenticated: ko.observable(false),
    username: ko.observable(null),
    password: ko.observable(null),
    receiverPhoneNumber: ko.observable(null),
    tradeAddress: ko.observable(null),
    receiverName: ko.observable(null),
    requestDay: ko.observable(null)
}

var customerModel = {
    productCategories: ko.observableArray([]),
    filteredProducts: ko.observableArray([]),
    selectedCategory: ko.observable(null),
    productDetail: ko.observableArray([]),
    cart: ko.observableArray([]),
    cartTotal: ko.observable(0),
    cartCount: ko.observable(0),
    currentView: ko.observable("list"),
    filteredOrders: ko.observableArray([])
}

window.onload = function () {
    $("#hienthi").click();
    $("#hienthi").click();
    $("#hienthi").click();
    $("#hienthi").click();
    $("#hienthi").click();
}

$(document).ready(function () {
    ko.applyBindings();
    getProducts();
    getCategories();
    if (localStorage.getItem("giohang") != null) {
        var giohang = JSON.parse(localStorage.getItem("giohang"));
        for (var i = 0; i < giohang.length; i++) {
            customerModel.cart.push(giohang[i]);
        }
        if (localStorage.getItem("checkout") == "true") {
            setView('checkout');
        } else {
            setView('list');
            localStorage.setItem("checkout", "false");
        }
    }
    $("#hienthi").click();
    $(".cart").css("cursor", "pointer");

    $(".cart").click(function () {
        setView("cart");
        window.scroll(0, 280);
    });

    $("#logoutForm > ul > li > a").hover(function () {

    })
    $("#hienthi").click();
});
