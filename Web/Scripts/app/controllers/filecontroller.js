(function () {
    "use strict";

    angular
        .module("goodyApp")
        .controller("fileController", fileController);

    fileController.$inject = ["$scope", "$mdDialog", "$location", "$timeout", "Upload", "fileService"];

    function fileController($scope, $mdDialog, $location, $timeout, Upload, fileService){
        var vm = this;
        vm.$scope = $scope;
        vm.$mdDialog = $mdDialog;
        vm.$location = $location;
        vm.$timeout = $timeout;
        vm.Upload = Upload;
        vm.fileService = fileService;
        vm.item = {};
        vm.items = [];
        vm.$event = null;
        vm.status = "Hello";

        vm.uploadPic = _uploadPic;

        vm.showImage = _showImage;
        vm.uploadNew = _uploadNew;
        vm.getAllSuccess = _getAllSuccess;
        vm.getAllError = _getAllError;
        vm.delete = _delete;
        vm.deleteSuccess = _deleteSuccess;
        vm.deleteError = _deleteError;
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

        function _delete(fileItem) {
            vm.item = fileItem;
            vm.fileService.delete(fileItem.id)
                .then(vm.deleteSuccess)
                .catch(vm.deleteError);
        }

        function _deleteSuccess(data) {
            console.log("FileController: DeleteSuccess");
            console.log("FileController: Removing the following item: ");
            console.log(data.item);
            var idx = vm.items.indexOf(vm.item);
            vm.items.splice(idx, 1);
        }

        function _deleteError(err) {
            console.log("FileController: DeleteError");
            console.log(err);
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
                    window.location = '/file';
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                // Math.min is to fix IE which reports 200% sometimes
                file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
            });
        }

        function _showImage(ev) {
            console.log("FileController: ShowImage");
            vm.status = "Goodbye";
            vm.$event = ev;
            $mdDialog.show({
                controller: ['$scope', 'data', function ($scope, data) {
                    $scope.data = data;
                }],
                templateUrl: '/assets/diaglog1.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true,
                fullscreen: vm.$scope.customFullscreen,
                locals: { data: ev.currentTarget.currentSrc }
            })
            .then(function (answer) {
                vm.status = 'You said the information was "' + answer + '".';
            }, function () {
                vm.status = 'You cancelled the dialog.';
            });
        }
    }
})();