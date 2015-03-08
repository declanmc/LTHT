'use strict';

app.controller('PeopleController', ['$scope', 'PeopleService','person', function ($s, PeopleService, person) {

    $s.isLoading = true;

    var people = PeopleService.getAll();
    people.then(function (result) {
        $s.people = result.map(person.create);
        $s.isLoading = false;
    });

}]);

app.controller('PersonController', ['$scope', 'PeopleService', 'ColoursService', 'person', '$routeParams', '$location', function ($s, PeopleService, ColoursService, person, $routeParams, $location) {
    $s.person = {};

    $s.init = function () {
        var personId = $routeParams.id;
        var existingPerson = PeopleService.get(personId);
        var colours = ColoursService.getAll();

        existingPerson.then(function (result) {
            $s.person = person.create(result);
        });

        colours.then(function (result) {
            $s.colours = result;
        });
    };

    $s.hideCheckbox = function(id) {
        angular.element('#' + id).toggleClass('ng-hide');
    };

    $s.update = function () {
        var save = PeopleService.save($s.person);
        save.then(function() {
            $location.path('/people');
        });
    };

    $s.cancel = function () {
        $location.path('/people');
    };
}]);
