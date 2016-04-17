angular.module("ODataLab").factory('ODataLab.Api', ['$http', function ($http) {

    var someVal = 'hello from factory'
    return {
        hello: function () {
            return someVal;
        }
    }

}]);