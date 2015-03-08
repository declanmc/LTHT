'use strict';

var app = angular.module('techTestApp', ['ngResource', 'ngRoute']).config(function ($sceProvider) {
    // Completely disable SCE to support IE7.
    $sceProvider.enabled(false);
});


