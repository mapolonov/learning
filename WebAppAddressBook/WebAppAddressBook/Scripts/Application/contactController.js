var app = angular.module('myApp', []);

//function contactController($scope, $http) {
app.controller('contactController',
    function ($scope, $http) {
        $scope.loading = true;
        $scope.addMode = false;
        $scope.Contacts = [];
        //Used to display the data 
        $http.get('/api/Contact/').then(function(result) {
                //console.log(data);
            $scope.Contacts = result.data;
            $scope.loading = false;
           }
            ,function() {
                $scope.error = "An Error has occured while loading posts!";
                $scope.loading = false;
            });

        $scope.toggleEdit = function() {
            this.Contact.editMode = !this.Contact.editMode;
        };
        $scope.toggleAdd = function() {
            $scope.addMode = !$scope.addMode;
        };

        //Used to save a record after edit 
        $scope.save = function() {
            alert("Edit");
            $scope.loading = true;
            var frien = this.Contact;
            alert(emp);
            $http.put('/api/Contact/', frien).success(function(data) {
                alert("Saved Successfully!!");
                emp.editMode = false;
                $scope.loading = false;
            }).error(function(data) {
                $scope.error = "An Error has occured while Saving Contact! " + data;
                $scope.loading = false;

            });
        };

        //Used to add a new record 
        $scope.add = function() {
            $scope.loading = true;
            $http.post('/api/Contact/', this.newContact).success(function(data) {
                alert("Added Successfully!!");
                $scope.addMode = false;
                $scope.Contacts.push(data);
                $scope.loading = false;
            }).error(function(data) {
                $scope.error = "An Error has occured while Adding Contact! " + data;
                $scope.loading = false;

            });
        };

        //Used to edit a record 
        $scope.deleteContact = function() {
            $scope.loading = true;
            var Contactid = this.Contact.ContactId;
            $http.delete('/api/Contact/' + Contactid).success(function(data) {
                alert("Deleted Successfully!!");
                $.each($scope.Contacts,
                    function(i) {
                        if ($scope.Contacts[i].ContactId === Contactid) {
                            $scope.Contacts.splice(i, 1);
                            return false;
                        }
                    });
                $scope.loading = false;
            }).error(function(data) {
                $scope.error = "An Error has occured while Saving Contact! " + data;
                $scope.loading = false;

            });
        };

    });