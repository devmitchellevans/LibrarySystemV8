(function ($) {
    var _bookCategoryAppService = abp.services.app.bookCategory;
    l = abp.localization.getSource('LibrarySystemV8');

    $(document).on('click', '.edit-bookCat', function (e) {
        var bookCatId = $(this).attr("data-bookCat-id");

        e.preventDefault();

        window.location.href = "/BookCategories/CreateOrEditBookCategories/" + bookCatId;
    });

    $(document).on('click', '.delete-bookCat', function (e) {
        var bookCatId = $(this).attr("data-bookCat-id");
        var bookCatName = $(this).attr('data-bookCat-name');

        e.preventDefault();

        deleteBookCat(bookCatId, bookCatName);
    });

    function deleteBookCat(bookCatId, bookCatName) 
    { 

        if (bookCatId > 0) {

            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete'),
                    bookCatName),
                null,
                (isConfirmed) => {
                    if (isConfirmed) {
                        _bookCategoryAppService.delete({
                            id: bookCatId
                        }).done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            window.location.href = "/BookCategories";
                        });
                    }
                }
            );

        }

    }

})(jQuery);