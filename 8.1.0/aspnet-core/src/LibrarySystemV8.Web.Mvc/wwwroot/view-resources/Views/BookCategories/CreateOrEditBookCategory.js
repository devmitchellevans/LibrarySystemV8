(function ($) {
    var _$form = $('#bookCategoryCreateForm');
    var _bookCategoryAppService = abp.services.app.bookCategory;
    var _indexPage = "/BookCategories";
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var bookCategory = _$form.serializeFormToObject();
        if (bookCategory.Id != 0) {
            _bookCategoryAppService.update(bookCategory).done(function () {
                window.location.href = _indexPage;
            });
        } else {
            _bookCategoryAppService.create(bookCategory).done(function () {
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