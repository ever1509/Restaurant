(function () {
    "use strict";
    app.controller("UserTypeController", UserTypeController);
    app.controller("CreateUserTypeController", CreateUserTypeController);
    app.controller("DetailUserTypeController", DetailUserTypeController);
    app.controller("EditUserTypeController", EditUserTypeController);
    app.controller("DeleteUserTypeController", DeleteUserTypeController);

    UserTypeController.$inject = ["$log", "$scope", "$location", "UserTypeService"];
    CreateUserTypeController.$inject = ["$log", "$scope", "$location", "UserTypeService"];
    DetailUserTypeController.$inject = ["$log", "$scope", "$location", "$routeParams", "UserTypeService"];
    EditUserTypeController.$inject = ["$log", "$scope", "$location", "$routeParams", "UserTypeService"];
    DeleteUserTypeController.$inject = ["$log", "$scope", "$location", "$routeParams", "UserTypeService"];

    function UserTypeController($log, $scope, $location, usertypeService) {
        $scope.result = {};
        usertypeService.getAll().then(function (result) {
            $scope.result = result.data;
        });

        $scope.create = function () {
            $location.path("/usertype-create/");
        };
        $scope.edit = function (item) {
            $location.path("/usertype-edit/" + item.userTypeID);
        };
        $scope.detail = function (item) {
            $location.path("/usertype-detail/" + item.userTypeID);
        };
        $scope.delete = function (item) {
            $location.path("/usertype-delete/" + item.userTypeID);
        };
    };
    function CreateUserTypeController($log, $scope, $location, usertypeService) {
        $scope.result = {};

        $scope.create = function () {
            usertypeService.post($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                }
                else {
                    $location.path("/usertypes");
                }
            });
        };
        $scope.cancel = function () {
            $location.path("/usertypes");
        };
    };
    function DetailUserTypeController($log, $scope, $location, $routeParams, usertypeService) {
        $scope.result = {};
        var id = $routeParams.id;
        usertypeService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.backlist = function () {
            $location.path("/usertypes");
        };
    };
    function EditUserTypeController($log, $scope, $location, $routeParams, usertypeService) {
        $scope.result = {};
        var id = $routeParams.id;
        usertypeService.get(id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.update = function () {
            usertypeService.put(id, $scope.result.model).then(function (result) {
                $location.path("/usertypes");
            });
        };
        $scope.cancel = function () {
            $location.path("/usertypes");
        };
    };
    function DeleteUserTypeController($log, $scope, $location, $routeParams, usertypeService) {
        $scope.result = {};
        var id = $routeParams.id;
        usertypeService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.delete = function () {
            usertypeService.delete(id).then(function (result) {
                $location.path("/usertypes");
            });
        };
        $scope.cancel = function () {
            $location.path("/usertypes");
        };
    };
})();