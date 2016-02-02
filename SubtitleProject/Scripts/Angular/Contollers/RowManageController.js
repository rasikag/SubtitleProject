'use strict';
subProject.controller('RowManageController',
    function RowManageController($scope, $log, subtitleData) {

        subtitleData.getData(function (getData) {
            //console.log(getData);
            $scope.subData = getData;
        }, 0, 20);

        $scope.submitChanges = function (end , data) {

            subtitleData.getData(function (getData) {
                $scope.subData = getData;
            }, end + 1, end + 20);
            
            subtitleData.postData(data);

        }

    });