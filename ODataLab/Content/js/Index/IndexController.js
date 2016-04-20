angular.module("ODataLab").controller("odataIndex.controller", ['$scope', 'ODataLab.Api', function ($scope, api) {
    
    var selectedColumns = ['LastName', 'FirstName', 'ex.fn'];

    var kendoOptions = {
        dataSource: {
            schema: {
                data: function (data) {
                    return data.value;
                },
                total: function (data) {
                    return data['odata.count'];
                },
                model: {
                    fields: {
                        FirstName: { type: "string" },
                        LastName: { type: "string" },
                        'ex.fn': { type: "string" }
                    }
                }
            },
            type: "odata",
            transport: {
                read: {
                    url: "//localhost:50015/OData/Employments",
                    dataType: "json",
                    data: {
                        $select: function () {
                            console.log('Select on the following columns : ' + selectedColumns);
                            return selectedColumns;
                        }
                    }
                }
            },
            pageSize: 5,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true,
        },
        
        sortable: true,
        filterable: true,
        columnMenu: true,
        columnShow: function (e) {
            console.log('Showing :' + e.column.field);
            selectedColumns.push(e.column.field);
            requestOnlyAdded = true;
            e.sender.dataSource.read();

        },
        columnHide: function (e) {
            console.log('Hiding :' + e.column.field);
            var index = selectedColumns.indexOf(e.column.field);
            selectedColumns.splice(index,1);
        },
        pageable: true,
        columns: [{
            field: "FirstName",
            title: "FirstName",
            width: "120px",
        }, {
            field: "LastName",
            title: "LastName",
            width: "120px"
        }, {
            field: "ex.fn",
            title: "ex",
            width: "120px"
        }]
    };

    $scope.kendoOptions = kendoOptions;
}]);