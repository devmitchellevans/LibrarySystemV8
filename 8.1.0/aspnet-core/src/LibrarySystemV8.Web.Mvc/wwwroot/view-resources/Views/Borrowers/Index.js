(function ($) {
    var _borrowerAppService = abp.services.app.borrower;
    l = abp.localization.getSource('LibrarySystemV8');

    $(document).on('click', '.edit-borrower', function (e) {
        var borrowerId = $(this).attr("data-borrow-id");

        e.preventDefault();

        window.location.href = "/Borrowers/EditBorrowers/" + borrowerId;
    });

    $(document).on('click', '.delete-borrower', function (e) {
        var borrowerId = $(this).attr("data-borrow-id");
        var borrowerName = $(this).attr('data-borrow-name');

        e.preventDefault();

        deleteBorrower(borrowerId, borrowerName);
    });

    function deleteBorrower(borrowerId, borrowerName) {

        if (borrowerId > 0) {

            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete'),
                    borrowerName),
                null,
                (isConfirmed) => {
                    if (isConfirmed) {
                        _borrowerAppService.delete({
                            id: borrowerId
                        }).done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            window.location.href = "/Borrowers";
                        });
                    }
                }
            );

        }

    }

})(jQuery);