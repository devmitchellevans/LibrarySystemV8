(function ($) {
    var _$form = $('#bookCreateForm');
    var _bookAppService = abp.services.app.book;
    var _indexPage = "/Books";
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var book = _$form.serializeFormToObject();
        if (book.Id != 0) {
            _bookAppService.update(book).done(function () {
                window.location.href = _indexPage;
            });
        } else {
            _bookAppService.create(book).done(function () {
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