(function ($) {
    var _$form = $('#studentCreateForm');
    var _studentAppService = abp.services.app.student;
    var _indexPage = "/Students";
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var student = _$form.serializeFormToObject();
        if (student.Id != 0) {
            _studentAppService.update(student).done(function () {
                window.location.href = _indexPage;
            });
        } else {
            _studentAppService.create(student).done(function () {
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