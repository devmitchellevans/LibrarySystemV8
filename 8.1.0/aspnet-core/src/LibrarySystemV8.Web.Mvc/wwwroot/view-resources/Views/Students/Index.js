(function ($) {
    var _studentAppService = abp.services.app.student;
    l = abp.localization.getSource('LibrarySystemV8');

    $(document).on('click', '.edit-stud', function (e) {
        var studId = $(this).attr("data-stud-id");

        e.preventDefault();

        window.location.href = "/Students/CreateOrEditStudents/" + studId;
    });

    $(document).on('click', '.delete-stud', function (e) {
        var studId = $(this).attr("data-stud-id");
        var studName = $(this).attr('data-stud-name');

        e.preventDefault();

        deleteStud(studId, studName);
    });

    function deleteStud(studId, studName) 
    { 

        if (studId > 0) {

            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete'),
                    studName),
                null,
                (isConfirmed) => {
                    if (isConfirmed) {
                        _studentAppService.delete({
                            id: studId
                        }).done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            window.location.href = "/Students";
                        });
                    }
                }
            );

        }

    }

})(jQuery);