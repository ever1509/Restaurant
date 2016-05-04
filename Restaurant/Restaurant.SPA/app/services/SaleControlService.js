(function () {
    "use strict";
    var baseurl = "http://localhost:3268/api/";
    app.service("SaleControlService", ["$log", "$http", function ($log, $http) {
        var url = baseurl + "salecontrol/";
        var self = this;
        self.getAll = function () {
            return $http.get(url);
        };
        self.get = function (id) {
            return $http.get(url + id);
        };
        self.post = function (entity) {
            return $http.post(url, entity);
        }
        self.put = function (id, entity) {
            return $http.put(url+ id, entity);
        };
        self.delete = function (id, entity) {
            return $http.delete(url + id, entity);
        };
    }]);
})();