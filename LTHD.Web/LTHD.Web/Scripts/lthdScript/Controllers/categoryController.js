var categoryUrl = "/api/categories/";
var getCategories = function () {
    sendRequest(categoryUrl, "GET", null, function (data) {
        debugger;
        model.categories.removeAll();
        model.categories.push.apply(model.categories, data);
    })
};