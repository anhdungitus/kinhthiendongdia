var setView = function (view) {
    adminModel.currentView(view);
}

var setListMode = function (mode) {
    adminModel.listMode(mode);
}

var authenticateUser = function () {
    authenticate(function () {
        setView("productList");
        getProducts();
        getOrders();
    });
}

var createProduct = function () {
    saveProduct(adminModel.newProduct, function () {
        setListMode("products");
    })
}

var jumpToUpdate = function (product) {
    adminModel.udProduct.ProductId(product.ProductId);
    adminModel.udProduct.ProductName(product.ProductName);
    adminModel.udProduct.CategoryId(product.CategoryId);
    adminModel.udProduct.Description(product.Description);
    adminModel.udProduct.Price(product.Price);
    adminModel.udProduct.ImageUrl(product.ImageUrl);
    window.scroll(0, 0);
    setListMode('updateProduct');
}

var updateProduct = function () {
    saveUpdateProduct(adminModel.udProduct, function () {
        setListMode('products');
    });
}

var removeProduct = function (product) {
    if(confirm("Bạn thật sự muốn xóa sản phẩm này?")) {
        deleteProduct(product.ProductId);
        setListMode('products');
        getProducts();
    }
}

var removeOrder = function (order) {
    deleteOrder(order.OrderId);
}

var changeStatus = function (order) {
    order.Status = true;
    order.Lines = [];
    debugger;
    saveUpdateOrder(order, function () {
        getOrders();
    }, function () {
        alert("Đã xảy ra lỗi");
    });
}


