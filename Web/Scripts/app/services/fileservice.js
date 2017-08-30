(function () {
    "use strict";
    
    angular.module("goodyApp")
        .factory("fileService", FileService);

    FileService.$inject = ["$http", "$q"];

    function FileService($http, $q) {
        return {
            getAll: _getAll
        };

        function _getAll() {
            console.log("FileService: GetAll");
            return $http.get("/api/file/getall")
                .then(_getAllSuccess)
                .catch(_getAllError);

            function _getAllSuccess(response) {
                console.log("FileService: GetAllSuccess");
                return response.data;
            }

            function _getAllError(err) {
                console.log("FileService: GetAllError");
                return $q.reject(err);
            }
        }
    }
})();