/* ===================================================================
    
    Author          : Valid Theme
    Template Name   : MediHub - Medical & Health Template
    Version         : 1.1
    
* ================================================================= */
////const { Toast } = require("bootstrap");
//const { ajax, error } = require("jquery");

(function ($) {
    "use strict";

    $(document).on('ready', function () {


        /* ==================================================
            # Wow Init
         ===============================================*/
        var wow = new WOW({
            boxClass: 'wow', // animated element css class (default is wow)
            animateClass: 'animated', // animation css class (default is animated)
            offset: 0, // distance to the element when triggering the animation (default is 0)
            mobile: true, // trigger animations on mobile devices (default is true)
            live: true // act on asynchronously loaded content (default is true)
        });
        wow.init();


        /* ==================================================
            # Smooth Scroll
         ===============================================*/
        $("body").scrollspy({
            target: ".navbar-collapse",
            offset: 200
        });
        $('a.smooth-menu').on('click', function (event) {
            var $anchor = $(this);
            var headerH = '75';
            $('html, body').stop().animate({
                scrollTop: $($anchor.attr('href')).offset().top - headerH + "px"
            }, 1500, 'easeInOutExpo');
            event.preventDefault();
        });

        $("#open_popup").click(function () {
            $(".tab-content-info .accept_btn").removeClass("active_popup");
            $(this).addClass("active_popup");
        });


        /* ==================================================
            # Banner Animation
        ===============================================*/
        function doAnimations(elems) {
            //Cache the animationend event in a variable
            var animEndEv = 'webkitAnimationEnd animationend';
            elems.each(function () {
                var $this = $(this),
                    $animationType = $this.data('animation');
                $this.addClass($animationType).one(animEndEv, function () {
                    $this.removeClass($animationType);
                });
            });
        }

        //Variables on page load
        var $immortalCarousel = $('.animate_text'),
            $firstAnimatingElems = $immortalCarousel.find('.item:first').find("[data-animation ^= 'animated']");
        //Initialize carousel
        $immortalCarousel.carousel();
        //Animate captions in first slide on page load
        doAnimations($firstAnimatingElems);
        //Other slides to be animated on carousel slide event
        $immortalCarousel.on('slide.bs.carousel', function (e) {
            var $animatingElems = $(e.relatedTarget).find("[data-animation ^= 'animated']");
            doAnimations($animatingElems);
        });


        /* ==================================================
            # Equal Height Init
        ===============================================*/
        $(window).on('resize', function () {
            $(".equal-height").equalHeights();
        });

        $(".equal-height").equalHeights().find("img, iframe, object").on('load', function () {
            $(".equal-height").equalHeights();
        });


        /* ==================================================
            # imagesLoaded active
        ===============================================*/
        $('#portfolio-grid,.blog-masonry').imagesLoaded(function () {

            /* Filter menu */
            $('.mix-item-menu').on('click', 'button', function () {
                var filterValue = $(this).attr('data-filter');
                $grid.isotope({
                    filter: filterValue
                });
            });

            /* filter menu active class  */
            $('.mix-item-menu button').on('click', function (event) {
                $(this).siblings('.active').removeClass('active');
                $(this).addClass('active');
                event.preventDefault();
            });

            /* Filter active */
            var $grid = $('#portfolio-grid').isotope({
                itemSelector: '.pf-item',
                percentPosition: true,
                masonry: {
                    columnWidth: '.pf-item',
                }
            });

            /* Filter active */
            $('.blog-masonry').isotope({
                itemSelector: '.blog-item',
                percentPosition: true,
                masonry: {
                    columnWidth: '.blog-item',
                }
            });

        });


        /* ==================================================
           # Fun Factor Init
       ===============================================*/
        $('.timer').countTo();
        $('.fun-fact').appear(function () {
            $('.timer').countTo();
        }, {
            accY: -100
        });


        /* ==================================================
            # Youtube Video Init
         ===============================================*/
        $('.player').mb_YTPlayer();



        /* ==================================================
            # Magnific popup init
         ===============================================*/
        $(".popup-link").magnificPopup({
            type: 'image',
            // other options
        });

        $(".popup-gallery").magnificPopup({
            type: 'image',
            gallery: {
                enabled: true
            },
            // other options
        });

        $(".popup-youtube, .popup-vimeo, .popup-gmaps").magnificPopup({
            type: "iframe",
            mainClass: "mfp-fade",
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false
        });

        $('.magnific-mix-gallery').each(function () {
            var $container = $(this);
            var $imageLinks = $container.find('.item');

            var items = [];
            $imageLinks.each(function () {
                var $item = $(this);
                var type = 'image';
                if ($item.hasClass('magnific-iframe')) {
                    type = 'iframe';
                }
                var magItem = {
                    src: $item.attr('href'),
                    type: type
                };
                magItem.title = $item.data('title');
                items.push(magItem);
            });

            $imageLinks.magnificPopup({
                mainClass: 'mfp-fade',
                items: items,
                gallery: {
                    enabled: true,
                    tPrev: $(this).data('prev-text'),
                    tNext: $(this).data('next-text')
                },
                type: 'image',
                callbacks: {
                    beforeOpen: function () {
                        var index = $imageLinks.index(this.st.el);
                        if (-1 !== index) {
                            this.goTo(index);
                        }
                    }
                }
            });
        });


        /* ==================================================
            # Doctor Carousel
         ===============================================*/
        $('.doctor-carousel').owlCarousel({
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
                    items: 3
                }
            }
        });


        /* ==================================================
            # Services Carousel
         ===============================================*/
        $('.services-carousel').owlCarousel({
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
                    items: 3
                }
            }
        });

        /* ==================================================
            # Testimonials Carousel
         ===============================================*/
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


        /* ==================================================
            # Health Tips Carousel
         ===============================================*/
        $('.tips-carousel').owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            items: 1,
            navText: [
                "<i class='fa fa-angle-left'></i>",
                "<i class='fa fa-angle-right'></i>"
            ],
        });


        /* ==================================================
            Preloader Init
         ===============================================*/
        $(window).on('load', function () {
            // Animate loader off screen
            $(".se-pre-con").fadeOut("slow");;
        });


        /* ==================================================
            Nice Select Init
         ===============================================*/
        $('select').niceSelect();


        /* ==================================================
            Contact Form Validations
        ================================================== */
        $('.contact-form').each(function () {
            var formInstance = $(this);
            formInstance.submit(function () {

                var action = $(this).attr('action');

                $("#message").slideUp(750, function () {
                    $('#message').hide();

                    $('#submit')
                        .after('<img src="assets/img/ajax-loader.gif" class="loader" />')
                        .attr('disabled', 'disabled');

                    $.post(action, {
                        name: $('#name').val(),
                        email: $('#email').val(),
                        phone: $('#phone').val(),
                        comments: $('#comments').val()
                    },
                        function (data) {
                            document.getElementById('message').innerHTML = data;
                            $('#message').slideDown('slow');
                            $('.contact-form img.loader').fadeOut('slow', function () {
                                $(this).remove()
                            });
                            $('#submit').removeAttr('disabled');
                        }
                    );
                });
                return false;
            });
        });

    }); // end document ready function
})(jQuery); // End jQuery



function ChangeNavMenu() {
    $(".dashboard_left").addClass("chng_nav");
}
function RemoveClass() {
    $(".dashboard_left").removeClass("chng_nav");
}

function OpenPopUp(id) {
    $(".btn-md").attr("data-jobId", id);
    $("#sendid").val(id);
}

function AcceptInvitation(instance) {

    var sendData = {
        JobApplyId: $('#sendid').val(),
        PrefferedRate: $('#hourly_rate').val()
    }
    $.ajax({
        type: "POST",
        url: "https://gahealthcarenurseswebapi.azurewebsites.net/api/JobApplyForEmployer/ApplyJob",
        contentType: "application/json",
        data: JSON.stringify(sendData),
        success: function (result) {
            instance.invokeMethodAsync("Response", result.status)
        },
        error: function () {
            DotNet.invokeMethodAsync("Response", "InternalServerError")

        }
    });
}


function RenderPaypalButton(elementId, planId, onApproveFunctionAssembly, onApproveFunctionName) {
    paypal.Buttons({
        style: {
            shape: 'pill',
            color: 'blue',
            layout: 'horizontal',
            label: 'subscribe',
            tagline: true
        },
        createSubscription: function (data, actions) {
            return actions.subscription.create({
                'plan_id': planId,
            });
        },
        onApprove: function (data, actions) {
            DotNet.invokeMethodAsync(onApproveFunctionAssembly, onApproveFunctionName, data, actions);
        }
    }).render(elementId);
}



function CreatePlan() {
    $.ajax({
        type: "POST",
        url: "https://api.sandbox.paypal.com/v1/payments/billing-plans/",
        contentType: "application/json",
        data: {
            "name": "Plan with Regular and Trial Payment Definitions",
            "description": "Plan with regular and trial payment definitions.",
            "type": "fixed",
            "payment_definitions": [
                {
                    "name": "Regular payment definition",
                    "type": "REGULAR",
                    "frequency": "MONTH",
                    "frequency_interval": "2",
                    "amount":
                    {
                        "value": "100",
                        "currency": "USD"
                    },
                    "cycles": "12",
                    "charge_models": [
                        {
                            "type": "SHIPPING",
                            "amount":
                            {
                                "value": "10",
                                "currency": "USD"
                            }
                        },
                        {
                            "type": "TAX",
                            "amount":
                            {
                                "value": "12",
                                "currency": "USD"
                            }
                        }]
                },
                {
                    "name": "Trial payment definition",
                    "type": "trial",
                    "frequency": "week",
                    "frequency_interval": "5",
                    "amount":
                    {
                        "value": "9.19",
                        "currency": "USD"
                    },
                    "cycles": "2",
                    "charge_models": [
                        {
                            "type": "SHIPPING",
                            "amount":
                            {
                                "value": "1",
                                "currency": "USD"
                            }
                        },
                        {
                            "type": "TAX",
                            "amount":
                            {
                                "value": "2",
                                "currency": "USD"
                            }
                        }]
                }],
            "merchant_preferences":
            {
                "setup_fee":
                {
                    "value": "1",
                    "currency": "USD"
                },
                "return_url": "https://google.com",
                "cancel_url": "https://google.com",
                "auto_bill_amount": "YES",
                "initial_fail_amount_action": "CONTINUE",
                "max_fail_attempts": "0"
            }
        },
        success: function (result) {
            instance.invokeMethodAsync("Response", result.status)
        },
        error: function (result) {
            DotNet.invokeMethodAsync("Response", "InternalServerError")

        }

    })
}
