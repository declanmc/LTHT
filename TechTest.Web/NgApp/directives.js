'use strict';
/* http://docs-next.angularjs.org/api/angular.module.ng.$compileProvider.directive */


app.directive('appVersion', ['version', function (version) {
    return function (scope, elm, attrs) {
        elm.text(version);
    };
}]);
