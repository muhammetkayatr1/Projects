$(".menu-line").click(function(){
    
    if ( $( this ).hasClass( "active" ) ) {
        $(".menu-line").removeClass("active");
        $(".menu ul").removeClass("responsive");
        
 
    }else{
        $(".menu-line").addClass("active");
        $(".menu ul").addClass("responsive");
    }
 
  });

