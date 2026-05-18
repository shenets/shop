//************************************************************************************************************************************//
var Home = {}

Home.Index = function () {
    
    var self = this;

    self.products = ko.observableArray([]);

    self.fill = function (products) {
        self.products(products);
    };

    self.clickLoad = function (shopId) {

        var callback = function (success, data) {

            if (success == true && data != null) {
                self.fill(data);
            }
        };

        self.loadProducts(shopId, callback);
    };
    
    self.loadProducts = function (shopId, callback) {
        $.ajax({
            type: 'POST',
            url: api.products.find,
            data: JSON.stringify({ shopId: shopId }),
            contentType: "application/json",
            dataType: 'json'
        })
        .done(function (data) {
            callback(true, data);
        })
        .fail(function () {
            callback(false, null);
        });
    };
};
