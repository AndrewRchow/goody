(function () {
    "use strict";

    angular
        .module("goodyApp")
        .controller("fileController", fileController);

    fileController.$inject = ["$scope", "$location", "$timeout", "Upload", "fileService"];

    function fileController($scope, $location, $timeout, Upload, fileService){
        var vm = this;
        vm.$scope = $scope;
        vm.$location = $location;
        vm.$timeout = $timeout;
        vm.Upload = Upload;
        vm.fileService = fileService;
        vm.item = {};
        vm.items = [];

        vm.uploadPic = _uploadPic;

        vm.uploadNew = _uploadNew;
        vm.getAllSuccess = _getAllSuccess;
        vm.getAllError = _getAllError;
        vm.$onInit = _init;

        function _init() {
            console.log("FileController: Init");
            var absUrl = vm.$location.absUrl();
            if (!vm.$location.absUrl().toLowerCase().includes('/file/upload')) {
                vm.fileService.getAll()
                    .then(vm.getAllSuccess)
                    .catch(vm.getAllError);
            }
        }

        function _uploadNew() {
            window.location = "/file/upload";
        }

        function _getAllSuccess(data) {
            console.log("FileController: GetAllSuccess");
            vm.items = data.items;
        }

        function _getAllError(err) {
            console.log("FileController: GetAllError");
            console.log(err);
        }

        function _uploadPic(file) {
            file.upload = Upload.upload({
                url: '/api/file/upload',
                data: { file: file },
            });
            
            file.upload.then(function (response) {
                $timeout(function () {
                    file.result = response.data;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                // Math.min is to fix IE which reports 200% sometimes
                file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
            });
        }
    }
})();