/**
 * 
 * @authors Tom Hu (webmaster@h1994st.com)
 * @date    2014-07-25 16:25:17
 * @version 1.0
 */

$(document).ready(function() {
  $('.item-comment-box textarea').focus(function(event) {
    $('.item-comment-box .comment-btn').fadeIn(100);
  });

  $('.item-comment-box textarea').blur(function(event) {
    $('.item-comment-box .comment-btn').fadeOut(100);
  });
});