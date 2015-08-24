function RegisteredUsersViewModel(model) {
    var viewModel = this;

    viewModel.currentlyProcessing = ko.observable(false);

    viewModel.model = model;

    viewModel.model.registeredUsers = ko.observableArray(viewModel.model.registeredUsers);

    viewModel.model.totalNumberOfUsers = viewModel.model.registeredUsers.length;

    viewModel.userBeingChanged = null;

    viewModel.removeUser = function (userToRemove) {
        viewModel.currentlyProcessing(true);
        viewModel.userBeingChanged = userToRemove;

        $.ajax({
            url: '/api/users',
            type: 'remove',
            contentType: 'application/json',
            data: ko.toJSON(userToRemove)
        })
        .success(viewModel.onRemoveUserSuccess)
        .error(viewModel.onRemoveUserFailure)
        .complete(function () { viewModel.currentlyProcessing(false) });
    };

    viewModel.onRemoveUserSuccess = function (data) {
        $('.body-content').prepend('<div class="alert alert-success"><strong>Successfully Removed User</strong> - The user has been removed from the system.</div>');

        viewModel.model.registeredUsers.remove(viewModel.userBeingChanged);

        viewModel.userBeingChanged = null;
    };

    viewModel.onRemoveUserFailure = function () {
        $('.body-content').prepend('<div class="alert alert-danger"><strong>Removing User Failed</strong> - There was an error while attempting to remove the user from the system.</div>');
    };

    viewModel.fadeOut = function (element) {
        $(element).fadeOut(1000, function () {
            $(element).remove();
        });
    };
};