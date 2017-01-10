var ordersUrl = "/api/orders/";

var getOrders = function () {
    sendRequest(ordersUrl, "GET", null, function (data) {
        debugger;
        model.orders.removeAll();
        model.orders.push.apply(model.orders, data);
    });
}

var saveOrder = function (order, successCallback) {
    sendRequest(ordersUrl, "POST", order, function () {
        if (successCallback) {
            successCallback();
        }
    });
}

var deleteOrder = function (id) {
    sendRequest(ordersUrl + id, "DELETE", null, function () {
        model.orders.remove(function (item) {
            return item.Id == id;
        })
    });
}

var saveUpdateOrder= function (order, successCallback) {
    sendRequest(ordersUrl, "PUT", order, function () {
        getOrders();
        if (successCallback) {
            successCallback();
        }
    });
}
