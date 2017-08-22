(function(){
    "use strict";

    angular.module("goodyApp")
        .factory("personService", PersonService);

    PersonService.$inject = ["$http", "$q"];

    function PersonService($http, $q) {
        return {
            getAll: _getAll
        };

        function _getAll() {
            console.log("PersonService: getAll");
            return $http.get("/api/person")
                .then(_getAllSuccess)
                .catch(_getAllError);

            function _getAllSuccess(response) {
                console.log("PersonService: getAllSuccess");
                return response.data;
            }

            function _getAllError(err) {
                console.log("PersonService: getAllError");
                $q.reject(err);
            }
        }
    }
})();