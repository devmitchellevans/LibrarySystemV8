(function ($) {
    var _$form = $("#borrowerCreateOrEditForm");
    var _borrowerAppService = abp.services.app.borrower;
    var _bookAppService = abp.services.app.book;
    var _indexPage = "/Borrowers";
    var _currentDate = new Date();
    var _returnDate = new Date();

    window.onload = (event) => {
        getCurrentDate();
        getReturnDate();

    }


    function formatDate(yyyy, mm, dd ) {
        let format = new Date();

        format.setDate(`${yyyy}/${mm}/${dd}`);

        return format;
    }

    function getCurrentDate() {

        let dd = _currentDate.getDate();

        let mm = _currentDate.getMonth();

        let yyyy = _currentDate.getFullYear();

        document.getElementById('current-date').value = formatDate(yyyy,mm, dd );
    }

    function getReturnDate() {
        let dd = _returnDate.getDate()+7;

        let mm = _returnDate.getMonth();

        let yyyy = _returnDate.getFullYear();

        document.getElementById('return-date').value = formatDate(yyyy, mm, dd );
        
    }

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