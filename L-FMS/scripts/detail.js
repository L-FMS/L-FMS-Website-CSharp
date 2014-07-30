/**
 * 
 * @authors Tom Hu (webmaster@h1994st.com)
 * @date    2014-07-25 16:25:17
 * @version 1.0
 */

$(document).ready(function() {
  $('.item-comment-box textarea').focus(function(event) {
    $(this).animate({
      height: "86px"
    }, 250);
    $('.item-comment-box .comment-btn').fadeIn(100);
  });

  $('#comment-cancel').click(function (event) {
    debugger;
    event.preventDefault();
    $('.item-comment-box textarea').animate({
      height: "42px"
    }, 250);
    $('.item-comment-box .comment-btn').fadeOut(100);
  });
});