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
        vm.item = {};
        vm.id = 0;
        vm.back = _back;
        vm.getByIdSuccess = _getByIdSuccess;
        vm.getByIdError = _getByIdError;
        vm.getAllSuccess = _getAllSuccess;
        vm.getAllError = _getAllError;
        vm.delete = _delete;
        vm.edit = _edit;
        vm.create = _create;
        vm.save = _save;
        vm.saveSuccess = _saveSuccess;
        vm.saveError = _saveError;

        vm.$onInit = _init;

        function _init() {
            console.log("PersonController: Init");
            var modelId = $("#modelId").val();
            if (modelId) {
                vm.id = parseInt(modelId);
                if (vm.id > 0) {
                    vm.personService.getById(vm.id)
                        .then(vm.getByIdSuccess)
                        .catch(vm.getByIdError);
                }
            } else {
                vm.personService.getAll()
                    .then(vm.getAllSuccess)
                    .catch(vm.getAllError);
            }
        }

        function _save() {
            console.log("PersonController: save");
            console.log(vm.item);
            if (vm.id > 0) {
                // Perform a put
                vm.personService.update(vm.item)
                    .then(vm.saveSuccess)
                    .catch(vm.saveError);
            } else {
                // Perform a post
                vm.personService.save(vm.item)
                    .then(vm.saveSuccess)
                    .catch(vm.saveError);
            }
        }

        function _saveSuccess(data){
            console.log("PersonController: saveSuccess");
            console.log(data.item);
            window.location = "/people";
        }

        function _saveError(err) {
            console.log("PersonController: saveError");
            console.log(err);
        }

        function _back() {
            window.location = "/people";
        }

        function _getByIdSuccess(data) {
            console.log("PersonController: getByIdSuccess");
            vm.item = data.item;
        }

        function _getByIdError(err) {
            console.log("PersonController: _getByIdError");
            console.log(err);
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