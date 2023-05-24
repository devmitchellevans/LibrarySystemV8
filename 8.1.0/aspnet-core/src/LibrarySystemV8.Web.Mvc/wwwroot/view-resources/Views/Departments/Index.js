(function ($) {
    var _departmentAppService = abp.services.app.department;
    l = abp.localization.getSource('LibrarySystemV8');

    $(document).on('click', '.edit-dept', function (e) {
        var deptId = $(this).attr("data-dept-id");

        e.preventDefault();

        window.location.href = "/Departments/CreateOrEditDepartments/" + deptId;
    });

    $(document).on('click', '.delete-dept', function (e) {
        var deptId = $(this).attr("data-dept-id");
        var deptName = $(this).attr('data-dept-name');

        e.preventDefault();

        deleteDept(deptId, deptName);
    });

    function deleteDept(deptId, deptName) 
    { 

        if (deptId > 0) {

            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete'),
                    deptName),
                null,
                (isConfirmed) => {
                    if (isConfirmed) {
                        _departmentAppService.delete({
                            id: deptId
                        }).done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            window.location.href = "/Departments";
                        });
                    }
                }
            );

        }

    }

})(jQuery);