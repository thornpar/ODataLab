angular.module("ODataLab").controller("odataIndex.controller", ['$scope', 'ODataLab.Api', function ($scope, api) {
    
    var selectedColumns = ['Name', 'Category', 'Price'];

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
                        Name: { type: "string" },
                        Price: { type: "number" },
                        Category: { type: "string" }
                    }
                }
            },
            type: "odata",
            transport: {
                read: {
                    url: "//localhost:50005/OData/Employments",
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
            field: "Name",
            title: "Name",
            width: "120px",
        }, {
            field: "Price",
            title: "Price",
            width: "120px"
        }, {
            field: "Category",
            width: "120px"
        }]
    };

    $scope.kendoOptions = kendoOptions;
}]);