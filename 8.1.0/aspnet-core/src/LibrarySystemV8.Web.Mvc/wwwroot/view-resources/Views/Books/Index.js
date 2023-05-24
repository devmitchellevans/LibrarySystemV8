(function ($) {
    var _departmentAppService = abp.services.app.book;
    l = abp.localization.getSource('LibrarySystemV8');

    $(document).on('click', '.edit-book', function (e) {
        var bookId = $(this).attr("data-book-id");

        e.preventDefault();

        window.location.href = "/Books/CreateOrEditBooks/" + bookId;
    });

    $(document).on('click', '.delete-book', function (e) {
        var bookId = $(this).attr("data-book-id");
        var bookName = $(this).attr('data-book-name');

        e.preventDefault();

        deleteDept(bookId, bookName);
    });

    function deleteDept(bookId, bookName) {

        if (bookId > 0) {

            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete'),
                    bookName),
                null,
                (isConfirmed) => {
                    if (isConfirmed) {
                        _departmentAppService.delete({
                            id: bookId
                        }).done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            window.location.href = "/Books";
                        });
                    }
                }
            );

        }

    }

})(jQuery);