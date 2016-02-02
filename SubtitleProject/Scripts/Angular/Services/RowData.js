'use strict';

subProject.factory('subtitleData', function ($http, $log) {
    return {

        getData: function (getFunction, start, end) {

            $http({
                method: 'GET',
                url: 'http://localhost:52689/api/getbycount',
                headers: {
                    'Content-Type': 'application / json'
                },
                params: {
                    'start': start,
                    'end': end
                }
            }).success(function (data, status, headers, config) {



                var myarray = [];
                for (var i = 0; i < data.SubDataList.length; i++) {
                    var dataPacket = {
                        Name: data.SubDataList[i],
                        Data: data.SubDataList[i]
                    };
                    myarray.push(dataPacket);
                }
                //console.log(myarray);

                var a = {
                    SubDataList: myarray,
                    Start: data.Start,
                    End: data.End
                }
                //console.log(a);
                getFunction(a);
            }).error(function (data, status, headers, config) {

                $log.warn(data.status, headers(), config);

            });

        },

        postData: function (subs) {

            var params = JSON.stringify(subs);

            console.log(subs);
            var req = {
                method: 'POST',
                url: 'http://localhost:52689/api/SubtitleManage',
                headers: {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': 'http://localhost:52689'
                },
                data: subs
            }

            $http.post('http://localhost:52689/api/SubtitleManage'
                , subs
                , {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': 'http://localhost:52689'
                })
                .then(function (data) {
                    console.log(data);
                }, function (data) {
                    console.log(data);
                });

        }



    }

});
