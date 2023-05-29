(function ($) {
    var _borrowerAppService = abp.services.app.borrower;
    var _bookAppService = abp.services.app.book;
    l = abp.localization.getSource('LibrarySystemV8');
    window.onload = (event) => {
            var isBorrowed = $(this).attr("data-borrower-is-borrowed");
            var returnOverDue = $(this).attr("data-borrower-expected-return-date");
            let date = new Date();

            if (isBorrowed == false) {
                document.getElementById("edit-button").disabled = true;
                document.getElementById("delete-button").disabled = true;
            }
            if (returnOverDue > date) {
                document.getElementById("table-row").style.backgroundColor = "red";
            }
  
    }
    $(document).on('click', '.edit-borrower', function (e) {
        var borrowerId = $(this).attr("data-borrow-id");

        e.preventDefault();

        window.location.href = "/Borrowers/EditBorrowers/" + borrowerId;
    });

    $(document).on('click', '.delete-borrower', function (e) {
        var borrowerId = $(this).attr("data-borrow-id");
        var borrowerName = $(this).attr('data-borrow-name');
        var bookId = $(this).attr('data-borrow-book-id');

        e.preventDefault();

        deleteBorrower(borrowerId, borrowerName, bookId);
    });

    function deleteBorrower(borrowerId, borrowerName, bookId) {

        if (borrowerId > 0) {

            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete'),
                    borrowerName),
                null,
                (isConfirmed) => {
                    if (isConfirmed) {
                        _bookAppService.getUpdateBook({
                            id: bookId
                        }).done(function () {
                            _borrowerAppService.delete({
                                id: borrowerId
                            }).done(() => {
                                abp.notify.info(l('SuccessfullyDeleted'));
                                window.location.href = "/Borrowers";
                            });
                        });

                    }
                }
            );

        }

    }

})(jQuery);