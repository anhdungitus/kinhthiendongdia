var adminModel = {
    currentView: ko.observable("signin"),
    listMode: ko.observable("products"),
    newProduct: {},
    udProduct: {
        ProductId: ko.observable(""),
        ProductName: ko.observable(""),
        CategoryId: ko.observable(""),
        Description: ko.observable(""),
        Price: ko.observable(""),
        ImageUrl: ko.observable("")
    }
};

$(document).ready(function () {
    //setView('productList');
    setView('signin');
    getOrders();
});