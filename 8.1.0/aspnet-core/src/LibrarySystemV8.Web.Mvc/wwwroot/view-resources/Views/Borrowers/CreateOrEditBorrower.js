(function ($) {
    var _$form = $("#borrowerCreateOrEditForm");
    var _borrowerAppService = abp.services.app.borrower;
    var _bookAppService = abp.services.app.book;
    var _indexPage = "/Borrowers";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var borrower = _$form.serializeFormToObject();
        if (borrower.Id != 0) {
            _borrowerAppService.update(borrower).done(function () {
             
                    window.location.href = _indexPage;
                
            })
        } else {
            _borrowerAppService.create(borrower).done(function () {
                _bookAppService.update({
                    id: borrower.BookId,
                    isBorrowed: borrower.IsBorrowed,
                    bookCategoryId: 8
                }).done(function () {
                        window.location.href = _indexPage;
                    })
            })
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
}
)(jQuery);