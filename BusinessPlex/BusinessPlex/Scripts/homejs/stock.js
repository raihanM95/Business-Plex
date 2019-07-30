 $(document).ready(function () {

     // script for password match //

     window.onload = function () {
         document.getElementById("password1").onchange = validatePassword;
         document.getElementById("password2").onchange = validatePassword;
     }

     function validatePassword() {
         var pass2 = document.getElementById("password2").value;
         var pass1 = document.getElementById("password1").value;
         if (pass1 != pass2)
             document.getElementById("password2").setCustomValidity("Passwords Don't Match");
         else
             document.getElementById("password2").setCustomValidity('');
         //empty string means no validation error
     }
     
     //script for smooth scrolling
     jQuery(document).ready(function ($) {
         $(".scroll ").click(function (event) {
             event.preventDefault();

             $('html,body').animate({
                 scrollTop: $(this.hash).offset().top
             }, 1000);
         });
     });
     //script  for  ease
     $(document).ready(function () {
         /*
          var defaults = {
         	 containerID: 'toTop', // fading element id
         	 containerHoverID: 'toTopHover', // fading element hover id
         	 scrollSpeed: 1200,
         	 easingType: 'linear' 
          };
          */

         $().UItoTop({
             easingType: 'easeOutQuart'
         });

     });
 });