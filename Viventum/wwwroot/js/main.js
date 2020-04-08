$(function(){
// wow.js
    new WOW().init();
// Scroll
$(window).scroll(function(){
    if ($(window).scrollTop() >= 1) {
        $('.inner-header').addClass('fixed');
    }
    else {
        $('.inner-header').removeClass('fixed');
    }
});

 // Go top
 $(function() {

    $(window).scroll(function() {
   
     if($(this).scrollTop() != 0) {
   
      $('.go-top').fadeIn();
   
     } else {
   
      $('.go-top').fadeOut();
   
     }
   
    });
   
    $('.go-top').click(function(e) {
     e.preventDefault();
     $('body,html').animate({scrollTop:0},800);
   
    });
   
   });
   
   //Anchor
   $(document).ready(function(){
      $(".nav a").bind("click", function(e){
         var anchor = $(this);
         $('html, body').stop().animate({
            scrollTop: $(anchor.attr('href')).offset().top 
         },1000);
         e.preventDefault();
      });
      return false;
   });

 // Menu button
 (function() {
  "use strict";
  var toggles = document.querySelectorAll(".c-hamburger");
  for (var i = toggles.length - 1; i >= 0; i--) {
    var toggle = toggles[i];
    toggleHandler(toggle);
  };
  function toggleHandler(toggle) {
    toggle.addEventListener( "click", function(e) {
      e.preventDefault();
      (this.classList.contains("is-active") === true) ? this.classList.remove("is-active") : this.classList.add("is-active");
    });
  }
})();

///Drop menu
var test = $('.inner-header');
$(function(){
  $('.colapse-menu-button .c-hamburger').on('click',function(){
    $('.mobile-menu').slideToggle();
    $('.overlay-menu').toggleClass('active');
    $('body').toggleClass('overlay-scroll');
    test.toggleClass('menu-style')
  });
});



$('.mobile-menu ul li a').on('click',function(){
  $('.colapse-menu-button .c-hamburger').trigger('click');
});

// Hidden menu
var menu = $('.mobile-menu'); 
$(window).resize(function(){
    var wid = $(window).width();
    if(wid > 570 && menu.is(':visible')) {
        menu.removeAttr('style');
        $('.colapse-menu-button .c-hamburger').removeClass('is-active');
        $('.overlay-menu').removeClass('active');
        $('body').removeClass('overlay-scroll'); 
        $('.inner-header').removeClass('menu-style');
    }
});

  function handleCookie() {
    const cookieOk = Cookies.get('cookie_ok');
    
    if (!cookieOk || cookieOk === '') {

      $('.my-cookie').show();
      $('.my-cookie a').on('click', function (e) {
        e.preventDefault();
        Cookies.set('cookie_ok', "cookie_ok", { expires: 365 });
        $('.my-cookie').fadeOut(300);
      });      
    }

    

  }

  handleCookie();
});
