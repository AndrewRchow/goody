(function(){
    "use strict";

    angular.module("goodyApp")
        .factory("personService", PersonService);

    PersonService.$inject = ["$http", "$q"];

    function PersonService($http, $q) {
        return {
            getAll: _getAll,
            getById: _getById,
            save: _save,
            update: _update
        };

        function _save(data) {
            console.log("PersonService: save");
            console.log(data);
            return $http.post('/api/person', data)
                .then(_saveSuccess)
                .catch(_saveError);

            function _saveSuccess(response) {
                console.log("PersonService: saveSuccess");
                return response.data;
            }

            function _saveError(err) {
                console.log("PersonService: saveError");
                return $q.reject(err);
            }
        }

        function _update(data) {
            console.log("PersonService: update");
            return $http.put("/api/person", data)
                .then(_updateSuccess)
                .catch(_updateError);

            function _updateSuccess(response) {
                console.log("PersonService: updateSuccess");
                return response.data;
            }

            function _updateError(err) {
                console.log("PersonService: updateError");
                return $q.reject(err);
            }
        }

        function _getById(id) {
            console.log("PersonService: getById(" + id + ")");
            return $http.get("/api/person/" + id)
                .then(_getByIdSuccess)
                .catch(_getByIdError);

            function _getByIdSuccess(response) {
                console.log("PersonService: getByIdSuccess");
                return response.data;
            }

            function _getByIdError(err) {
                console.log("PersonService: getByIdError");
                return $q.reject(err);
            }
        }

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
                return $q.reject(err);
            }
        }
    }
})();