$(document).ready(function(){

	$('.mobile-menu-icon').click(function(){
		$('.style-left-nav').slideToggle();				
	});

	$('.style-content-widget .fa-times').click(function(){
		$(this).parent().slideUp(function(){
			$(this).hide();
		});
	});
});