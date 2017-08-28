(function () {
    "use strict";

    angular
        .module("goodyApp")
        .controller("fileController", fileController);

    fileController.$inject = ["$scope", "Upload", "$timeout"];

    function fileController($scope, Upload, $timeout){
        var vm = this;
        vm.$scope = $scope;
        vm.Upload = Upload;
        vm.$timeout = $timeout;
        vm.item = {};

        vm.uploadPic = _uploadPic;

        function _uploadPic(file) {
            file.upload = Upload.upload({
                url: '/api/file/upload',
                data: { username: $scope.username, file: file },
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