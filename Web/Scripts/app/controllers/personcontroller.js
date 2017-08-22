(function () {
    "use strict";

    angular
        .module("goodyApp")
        .controller("personController", PersonController);

    PersonController.$inject = ["$scope", "personService"];

    function PersonController($scope, personService) {
        var vm = this;
        vm.$scope = $scope;
        vm.personService = personService;
        vm.items = [];
        vm.getAllSuccess = _getAllSuccess;
        vm.getAllError = _getAllError;
        vm.delete = _delete;
        vm.edit = _edit;
        vm.create = _create;

        vm.$onInit = _init;

        function _init() {
            console.log("PersonController: Init");
            vm.personService.getAll()
                .then(vm.getAllSuccess)
                .catch(vm.getAllError);
        }

        function _getAllSuccess(data) {
            console.log("PersonController: getAllSuccess");
            vm.items = data.items;
        }

        function _getAllError(err) {
            console.log("PersonController: getAllError");
            console.log(err);
        }

        function _delete(item) {
            console.log("PersonController: delete()");
            console.log(item);
            var index = vm.items.indexOf(item);
            vm.items.splice(index, 1);
        }

        function _edit(item) {
            window.location = "/people/" + item.id + "/edit";
        }

        function _create() {
            window.location="/people/create"
        }
    }
})();