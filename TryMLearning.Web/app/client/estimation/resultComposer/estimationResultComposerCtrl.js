(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationResultComposerCtrl', estimationResultComposerCtrl);

    estimationResultComposerCtrl.$inject = [
        '$state',
        'estimationSvc',
        'spinnerSvc',
        'config',
        '$scope',
        '$base64',
        '$stateParams'
    ];

    function estimationResultComposerCtrl(
        $state,
        estimationSvc,
        spinnerSvc,
        config,
        $scope,
        $base64,
        $stateParams
    ) {
        var vm = this;

        vm.estimation = undefined;
        vm.estimateAliases = config.classifierEstimates;
        vm.resultRequest = undefined;
        vm.selectedEstimate = undefined;

        vm.getResultClick = getResultClick;
        vm.estimateClick = estimateClick;
        vm.addEstimateClick = addEstimateClick;
        vm.removeClick = removeClick;
        vm.upClick = upClick;
        vm.downClick = downClick;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            vm.resultRequest = {
                id: +$stateParams.id
            };

            if (!$stateParams.e) {
                return;
            }

            vm.resultRequest.estimates = angular.copy($stateParams.e);
            if (!_.isArray(vm.resultRequest.estimates)) {
                vm.resultRequest.estimates = [vm.resultRequest.estimates];
            }

            _.each(vm.resultRequest.estimates, function (e) {
                e.$id = _.uniqueId();;
            });
        }

        function estimateClick(estimate) {
            if (vm.selectedEstimate && vm.selectedEstimate.$id && vm.selectedEstimate.$id === estimate.$id) {
                resetSelected();
            } else {
                vm.selectedEstimate = angular.copy(estimate);
                vm.selectedEstimateIndex = _.findIndex(vm.resultRequest.estimates, { $id: estimate.$id });
            }
        }

        function addEstimateClick() {
            if ($scope.esimateForm.$invalid) {
                $scope.esimateForm.$setSubmitted();
                return;
            }

            if (!vm.selectedEstimate.$id) {
                vm.selectedEstimate.$id = _.uniqueId();

                if (!vm.resultRequest.estimates) {
                    vm.resultRequest.estimates = [];
                }

                vm.resultRequest.estimates.push(vm.selectedEstimate);
            } else {
                vm.resultRequest.estimates[vm.selectedEstimateIndex] = vm.selectedEstimate;
            }

            resetSelected();

            var estimates = getPureEstimates();

            $state.go('client.estimation.resultComposer', { e: estimates }, { notify: false });
        }

        function removeClick(estimate) {
            _.remove(vm.resultRequest.estimates, function(e) {
                return e.$id === estimate.$id;
            });
        }

        function downClick(estimate) {
            var i = _.findIndex(vm.resultRequest.estimates, { $id: estimate.$id });

            var t = vm.resultRequest.estimates[i];
            vm.resultRequest.estimates[i] = vm.resultRequest.estimates[i + 1];
            vm.resultRequest.estimates[i + 1] = t;
        }

        function upClick(estimate) {
            var i = _.findIndex(vm.resultRequest.estimates, { $id: estimate.$id });

            var t = vm.resultRequest.estimates[i];
            vm.resultRequest.estimates[i] = vm.resultRequest.estimates[i - 1];
            vm.resultRequest.estimates[i - 1] = t;
        }

        function resetSelected() {
            vm.selectedEstimate = undefined;
            vm.selectedEstimateIndex = undefined;
            $scope.esimateForm.$setPristine();
            $scope.esimateForm.$setUntouched();
        }

        function getResultClick() {
            if (_.isArray($stateParams.id)) {
                $state.go('client.estimation.compare', { id: $stateParams.id, e: getPureEstimates() });
            } else {
                $state.go('client.estimation.result', { id: $stateParams.id, e: getPureEstimates() });
            }

        }

        function getPureEstimates() {
            var request = angular.copy(vm.resultRequest);

            _.each(request.estimates, function (e) {
                delete e.$id;
            });

            return request.estimates;
        }
    }
})();
