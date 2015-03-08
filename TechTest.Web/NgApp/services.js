app.service('PeopleService', ['$http', function ($http) {

    var getAll = function () {
        var people = $http({
            method: 'GET',
            url: '/api/people',
            headers: {
                'Content-type': 'application/json'
            }
        }).
        error(function (data) {
            return data;
        }).
        then(function (response) {
            return response.data;
        });
        return people;
    };

    var get = function (id) {
        var people = $http({
            method: 'GET',
            url: '/api/people?id=' + id,
            headers: {
                'Content-type': 'application/json'
            }
        }).
        error(function (data) {
            return data;
        }).
        then(function (response) {
            return response.data;
        });
        return people;
    };

    var save = function (person) {
        var jsonPerson = JSON.stringify(person);
        var headersToSend = { headers: { 'Content-Type': 'application/json' } };
        var uri = '/api/people/';
        
        var promise =
            $http.put(uri + person.personId,
                        jsonPerson,
                        headersToSend
            ).error(function (data) {
                alert("An error occurred");
            }).then(function (response) {
                return response.data;
            });

        return promise;
    };

    return {
        getAll: getAll,
        get: get,
        save: save
    };
}]);

app.service('ColoursService', ['$http', function ($http) {

    var getAll = function () {
        var colours = $http({
            method: 'GET',
            url: '/api/colours',
            headers: {
                'Content-type': 'application/json'
            }
        }).
        error(function (data) {
            return data;
        }).
        then(function (response) {
            return response.data;
        });
        return colours;
    };

    return {
        getAll: getAll
    };
}]);