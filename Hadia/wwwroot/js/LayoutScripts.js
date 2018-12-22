

$(".confirm").click(function (e) {
    e.preventDefault();
    var location = $(this).attr('href');
    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: false
    }).then(function (isConfirm) {
        if (isConfirm.value) {
            window.location.href = location;
        };
    });
});
$(".deactivate").click(function (e) {
    e.preventDefault();
    var location = $(this).attr('href');
    swal({
        title: 'Are you sure?',
        text: "Do you realy want to deactivate",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Deactivate!',
        cancelButtonText: 'No, cancel!',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: false
    }).then(function (isConfirm) {
        if (isConfirm.value) {
            window.location.href = location;
        };
    });
});
$(function () {
    var current = location.pathname;
    $('.nav-link').each(function () {
        var $this = $(this);
        var attr = $(this).attr('href');
        if (current == '/') {
            //$('.dashboardmenu').addClass('active');
        }
        if (typeof attr !== typeof undefined && attr !== false) {
            if (attr == current) {
                $this.addClass('active');
                //$this.closest('li').addClass('is-expanded');$this.attr('href').indexOf(current) !== -1

                $(this).closest('.nav-item-submenu').addClass('nav-item-open nav-item-expanded');
                if ($(this).closest('.subsubmenu').length > 0) {
                    $(this).closest('.subsubmenu').addClass('nav-item-open nav-item-expanded');
                }
            } else if (current.indexOf('/Details') != -1) {

            }
        }

    });
});