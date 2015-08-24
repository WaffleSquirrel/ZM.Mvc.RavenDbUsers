ko.bindingHandlers.appendToHref = {
    init: function (element, valueAccessor) {
        var currentHref = $(element).attr('href');

        $(element).attr('href', currentHref + '/' + valueAccessor());
    }
};

ko.bindingHandlers.isDirty = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var originalValue = ko.unwrap(valueAccessor());

        var interceptor = ko.pureComputed(function () {
            return (bindingContext.$data.showButton !== undefined && bindingContext.$data.showButton)
                    || originalValue != valueAccessor()();
        });

        ko.applyBindingsToNode(element, {
            visible: interceptor
        });
    }
};