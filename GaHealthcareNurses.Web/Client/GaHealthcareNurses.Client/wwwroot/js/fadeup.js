//import {AOS} from './aos'


//(function ($) {
	
//	"use strict";
	
//	// sidebar js start
//	$(document).ready (function() {
//		$("#openNav").click(function(){
//		  $("#mySidenav").addClass("sidenavWidth");
//		  $(".overly").css("display", "block");
//		});
//		$("#closeNav").click(function(){
//		  $("#mySidenav").removeClass("sidenavWidth");
//		  $(".overly").css("display", "none");
//		});
//		$(".overly").click(function(){
//			$("#mySidenav").removeClass("sidenavWidth");
//			$(this).hide();
//		});
//	});

//	$(document).on('keyup',function(evt) {
//		if (evt.keyCode == 27) {
//		   $("#mySidenav").removeClass("sidenavWidth");
//		   $(".overly").css("display", "none");
//		}
//	});
//	// sidebar js closed
	
//	// animation js start
//	AOS.init({
//	  duration: 1200,
//	});
//	// animation js closed
	
//	// carousel sliders js start
//	$('.owl-carousel').owlCarousel({
//		items : 1,
//		loop:true,
//		autoplay:true,
//		autoplayTimeout:4000,
//		autoplayHoverPause:true,
//		responsiveClass: true,
//		responsive: {
//		  0: {
//			items: 1,
//		  },
//		  600: {
//			items: 1,
//		  },
//		  768: {
//			items: 2,
//		  },
//		  1000: {
//			items: 3,
//			nav: true,
//			//loop: false,
//			margin: 0
//		  }
//		}
//	});
	
//	// sliders swiper js
//	$(".carousel").swipe({
//	  swipe: function(event, direction, distance, duration, fingerCount, fingerData) {
//		if (direction == 'left') $(this).carousel('next');
//		if (direction == 'right') $(this).carousel('prev');
//	  },
//	  allowPageScroll:"vertical"

//	});	
//	// carousel sliders js closed
	
//	// Scroll to Top js start
//	function headerStyle() {
//		if($('body').length){
//			var windowpos = $(window).scrollTop();
//			var scrollLink = $('.scroll-to-top');
//			if (windowpos > 100) {
//				scrollLink.fadeIn(300);
//			} else {
//				scrollLink.fadeOut(300);
//			}
//		}
//	}
//	headerStyle();
//	$(window).on('scroll', function() {
//		headerStyle();
//	});
//	/// Scroll to a Specific Div
//	if($('.scroll-to-target').length){
//		$(".scroll-to-target").on('click', function() {
//			var target = $(this).attr('data-target');
//		   // animate
//		   $('html, body').animate({
//			   scrollTop: $(target).offset().top
//			 }, 1500);

//		});
//	}
//	// Scroll to Top js Closed
	
//})(window.jQuery);