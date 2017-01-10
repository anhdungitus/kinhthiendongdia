var setCategory = function (category) {
    setView('list');
    customerModel.selectedCategory(category);
    filterProductsByCategory();
    localStorage.setItem("checkout", "false");
}
var setView = function (view) {
    customerModel.currentView(view);
}
var addToCart = function (product) {
    localStorage.setItem("checkout", "false");
    var found = false;
    var cart = customerModel.cart();
    for (var i = 0; i < cart.length; i++) {
        if (cart[i].product.ProductId == product.ProductId) {
            found = true;
            count = cart[i].count + 1;
            customerModel.cart.splice(i, 1);
            customerModel.cart.push({
                count: count,
                product: product
            });
            break;
        }
    }
    if (!found) {
        customerModel.cart.push({ count: 1, product: product });
    }
    localStorage.setItem("giohang", JSON.stringify(customerModel.cart()));
    window.scrollTo(0, 280);
    setView("cart");
}
var viewProduct = function (product) {
    localStorage.setItem("checkout", "false");
    customerModel.productDetail.removeAll();
    customerModel.productDetail.push({ product: product });
    window.scrollTo(0, 280);
    $("[id*='productDetail']").addClass("hidden")
    $("#productDetail" + product.ProductId).removeClass("hidden");
    setView("detail");
}

var removeFromCart = function (productSelection) {
    if (confirm("Bạn có thực sự muốn xóa sản phẩm này khỏi giỏ hàng")) {
        customerModel.cart.remove(productSelection);
    }
    localStorage.setItem("checkout", "false");
    localStorage.setItem("giohang", JSON.stringify(customerModel.cart()));
}
var placeOrder = function () {
    if (model.receiverName() == null || model.receiverPhoneNumber() == null || model.tradeAddress() == null) {
        alert("Vui lòng nhập đầy đủ thông tin để tiện cho việc giao nhận hàng");
        return false;
    }
    localStorage.setItem("checkout", "false");
    var order = {
        ReceiverName: model.receiverName(),
        ReceiverPhoneNumber: model.receiverPhoneNumber(),
        TradeAdress: model.tradeAddress(),
        UserName: $("#userName").text().replace("Chào ", ""),
        RequestDay: new Date().toLocaleString(),
        Lines: customerModel.cart().map(function (item) {
            return {
                Count: item.count,
                ProductId: item.product.ProductId
            }
        }),
        TotalCost: customerModel.cartTotal()
    };
    saveOrder(order, function () {
        orderHistory();
        for (var i = 0; i < customerModel.cart().length; i++) {
            customerModel.cart([]);
        }
        localStorage.setItem("giohang", JSON.stringify(customerModel.cart()));
    });
}
var orderHistory = function () {
    getOrders();
    window.scrollTo(0, 280);
    filterOrdersByUserName();
    setView('orderHistory')
}

model.categories.subscribe(function () {
    filterProductsByCategory();
    customerModel.productCategories.removeAll();
    customerModel.productCategories.push.apply(customerModel.productCategories,
    model.categories().map(function (p) {
        return {
            "Id": p.CategoryId,
            "Name": p.CategoryName
        }
    })
    .filter(function (value, index, self) {
        return self.indexOf(value) === index;
    }).sort());
});

customerModel.cart.subscribe(function (newCart) {
    customerModel.cartTotal(newCart.reduce(
    function (prev, item) {
        return prev + (item.count * item.product.Price);
    }, 0));
    customerModel.cartCount(newCart.reduce(
    function (prev, item) {
        return prev + item.count;
    }, 0));
})

var filterOrdersByUserName = function() {
    var username = $('#userName').text().replace("Chào ", "");
    customerModel.filteredOrders.removeAll();
    debugger;
    customerModel.filteredOrders.push.apply(customerModel.filteredOrders,
    model.orders().filter(function (o) {
        return o.UserName == username;
    }));
}

var filterProductsByCategory = function () {
    var category = customerModel.selectedCategory();
    customerModel.filteredProducts.removeAll();
    customerModel.filteredProducts.push.apply(customerModel.filteredProducts,
    model.products().filter(function (p) {
        return category == null || p.CategoryId == category.Id;
    }));
}

var filterProductsBySearch = function () {
    var keySearch = $("#keySearch").val().toLowerCase();
    customerModel.filteredProducts.removeAll();
    debugger;
    customerModel.filteredProducts.push.apply(customerModel.filteredProducts,
    model.products().filter(function (p) {
        return p.ProductName.toLowerCase().search(keySearch) >= 0;
    }));
    $("#keySearch").val("");
}

var checkout = function () {
    window.scrollTo(0, 280);
    if (customerModel.cartCount() > 0) {
        setView('checkout');
    } else {
        alert("Không thể thanh toán khi chưa có sản phẩm nào");
    }
}

var searchEvent = function () {
    setView('list');
    filterProductsBySearch();
    window.scrollTo(0, 280);
}
$("#hienthi").click();
$(document).ready(function () {
    
    getOrders();
    $("#btnSearch").click(function () {
        searchEvent();
    });
    $('#keySearch').bind("enterKey", function (e) {
        searchEvent();
        $(this).blur();
    });

    $('#keySearch').keyup(function (e) {
        if (e.keyCode == 13) {
            $(this).trigger("enterKey");
        }
    });
    $("#hienthi").click();
})