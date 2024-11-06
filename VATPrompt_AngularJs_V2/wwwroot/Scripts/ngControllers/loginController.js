myApp.controller('loginController', ['$scope', '$location', 'loginService', function ($scope, $location, loginService) {

    // Initialize the login form data
    $scope.account = {
        username: '',
        password: ''
    };

    // Handle login form submission
    $scope.login = function () {
        // Call the login service to authenticate the user
        loginService.login($scope.account.username, $scope.account.password).then(function (token) {
            // On successful login, redirect to another page (e.g., dashboard or home page)
            $location.path('/home'); // Change this path to the relevant page in your app
        }, function (error) {
            // Handle error (e.g., display a message to the user)
            $scope.errorMessage = error;
        });
    };

    // Handle refresh/cancel button click (reset the form)
    $scope.clickRefresh = function () {
        $scope.account.username = '';
        $scope.account.password = '';
        $scope.errorMessage = '';
    };

}]);
