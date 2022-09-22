//$(document).ready(function () {
//    $("header ul a").on("click", function () {
//        $("header ul").find(".active").removeClass("active");
//        $(this).parent().addClass("active");
//    });


//    $('ul li > a').each(function () {
//        if (urlRegExp.test($(this).attr('href'))) {
//            $(this).addClass('active');
//        }
//    });
//});

function onResetFile() {
    $('.inputFiled input[type=file]').val('');
};

function Slider() {

    $('.testimonial-carousel').owlCarousel({
        loop: false,
        margin: 30,
        nav: true,
        navText: [
            "<i class='fa fa-angle-left'></i>",
            "<i class='fa fa-angle-right'></i>"
        ],
        dots: false,
        autoplay: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            1000: {
                items: 2
            }
        }
    });


    //$("#carousel").owlCarousel({
    //    autoplay: true,
    //    lazyLoad: true,
    //    loop: true,
    //    margin: 27,
    //    responsiveClass: true,
    //    autoHeight: true,
    //    autoplayTimeout: 4000,
    //    smartSpeed: 500,
    //    responsive: {
    //        0: {
    //            items: 1
    //        },

    //        600: {
    //            items: 2
    //        },

    //        1024: {
    //            items: 3
    //        },

    //        1366: {
    //            items: 3
    //        }
    //    }
    //});
}

function HomePageSlider() {

    $('.carousel').carousel({
        interval: 3000
    });
}



function mask(){
    window.mask = (id, mask) => {
        var customMask = IMask(
            document.getElementById(id), {
            mask: mask
        });
    };
}