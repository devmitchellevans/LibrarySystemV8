(function ($) {
    var _$form = $('#departmentCreateForm');
    var _departmentAppService = abp.services.app.department;
    var _indexPage = "/Departments";
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var department = _$form.serializeFormToObject();
        if (department.Id != 0) {
            _departmentAppService.update(department).done(function () {
                window.location.href = _indexPage;
            });
        } else {
            _departmentAppService.create(department).done(function () {
                window.location.href = _indexPage;
            });
        }


    }


    _$form.find('.cancel-button').on('click', (e) => {
        e.preventDefault();
        window.location.href = _indexPage;

    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        save();
    });

})(jQuery);