(function ($) {
    var _$form = $("#borrowerCreateOrEditForm");
    var _borrowerAppService = abp.services.app.borrower;
    var _bookAppService = abp.services.app.book;
    var _indexPage = "/Borrowers";
    var _currentDate = new Date();
    var _returnDate = new Date();
    _returnDate.setDate(_returnDate.getDate() + 7);

    window.onload = (event) => {
        document.getElementById('current-date').value = _currentDate.toISOString().slice(0, 10);
        document.getElementById('return-date').value =  _returnDate.toISOString().slice(0, 10);
    }


    function save() {
        var borrowerBorrowDate = _currentDate.toISOString().slice(0, 10);
        var borrowerReturnDate = _returnDate.toISOString().slice(0, 10);
        if (!_$form.valid()) {
            return;
        }
        var borrower = _$form.serializeFormToObject();
        if (borrower.Id != 0) {
            _borrowerAppService.update(borrower).done(function () {

                if (borrower.ReturnDate >= borrowerBorrowDate) {
                    _bookAppService.getUpdateBook({
                        id: borrower.BookId
                    }).done(function () {
                        window.location.href = _indexPage;
                    })
                } else {
                    window.location.href = _indexPage;

                }

            })
        } else {
            if (borrower.BorrowDate < borrowerBorrowDate) {
                return;
            } else {
                if (borrower.ExpectedReturnDate < borrowerBorrowDate) {
                    return;
                } else {
                    _borrowerAppService.create(borrower).done(function () {
                        _bookAppService.getUpdateBook({
                            id: borrower.BookId
                        }).done(function () {
                            window.location.href = _indexPage;
                        })
                    })
                }

            }

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