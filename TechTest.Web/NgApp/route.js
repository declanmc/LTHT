app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/people', {
            templateUrl: 'ngapp/views/people.html',
            controller: 'PeopleController'
        }).
        when('/people/:id', {
            templateUrl: 'ngapp/views/person.html',
            controller: 'PersonController'
        }).
        otherwise({
            redirectTo: '/people'
        });
  }]);