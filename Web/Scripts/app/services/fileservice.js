(function () {
    "use strict";
    
    angular.module("goodyApp")
        .factory("fileService", FileService);

    FileService.$inject = ["$http", "$q"];

    function FileService($http, $q) {
        return {
            getAll: _getAll,
            delete: _delete
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

        function _delete(id) {
            return $http.delete("/api/file/delete/" + id)
                .then(_deleteSuccess)
                .catch(_deleteError);

            function _deleteSuccess(response) {
                console.log("FileService: DeleteSuccess");
                return response.data;
            }

            function _deleteError(err) {
                console.log("FileServer: DeleteError");
                return $q.reject(err);
            }
        }
    }
})();