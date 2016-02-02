'use strict';

var subProject = angular
    .module('subProject', [])
    .config(['$httpProvider', function ($httpProvider) {

        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
    }]);