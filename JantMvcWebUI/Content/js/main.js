$(document).ready(function () {
	if ($(".fancybox").length) {
		$('.fancybox').fancybox();
	}

    $("#menu-control").click(function(){
       $("#left-menu").slideToggle(function(){});
    });
    $(".product").hover(function () {
        $(this).find(".product-details-hover").stop().stop().fadeIn("fast");
    }, function () {
        $(this).find(".product-details-hover").fadeOut("fast");
    });
    $('#mainslider').flexslider({
        controlNav: true,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
        directionNav: true,
        animation: "slide"
    });
    $('#mostsellsslider').flexslider({
        animation: "slide"
    });
    $(".thumbs img").click(function () {
        $("#big-product-image").attr("src",$(this).attr("rel"));
    });

    if($('#product-images').length){
        $('#product-images').carouFredSel({
        auto: {
            pauseOnHover: 'resume'
        }
    }, {
        transition: true
    });    
    }
    
    if($('.cat-carousel').length){
        $('.cat-carousel').carouFredSel({
        prev: '.cc-left',
        next: '.cc-right',
        }, {
            transition: true
        });    
    }
    $(".downarrow").click(function(){
        $(".otherbrands").slideToggle(function(){});
    });

    if($('#suggcarousel').length){
        $('#suggcarousel').carouFredSel({
        prev: '.suggprev',
        next: '.suggnext',
        }, {
            transition: true
        });    
    }


    $(".cat-lists li:last-child").click (function() {
        var hangisi = $(this).attr("rel");
        $("."+hangisi).slideToggle(function(){});
    });
    
    $(".tabs ul li").click(function(){
        $(".tabs ul li").removeClass("current");
        $(this).addClass("current");
        var tunc="#"+$(this).attr("rel");
        $(".info-content").hide();
        $(tunc).show();
    });
    
    $(".tab-res").change (function (){
        var secilen=$(this).val();
        $(".info-content").hide();
        $("#"+secilen).show();
    });


    if($('.product-info').length){
        var w = $(window).width();
        var t = $('.product-info');
        
        if(w > 480 && w < 769){
            var s = t.find('#pricing');
            var c = s.clone();
            s.remove();

            t.find('#images').removeClass('col-sm-4').addClass('col-sm-8');
            t.find('#social').removeClass('col-sm-3').addClass('col-sm-4');

            var r = $('<div class="row"></div>');

            t.append(r);
            c.appendTo(r);
        }

    }

});

$(window).resize(function(){
    var w = $(window).width();
    var t = $('.product-info');
    var s = t.find('#pricing');

    if(w > 480 && w < 769){
        var c = s.clone();

        c.removeClass('col-sm-5').addClass('col-sm-12');
        s.remove();

        t.find('#images').removeClass('col-sm-4').addClass('col-sm-8');
        t.find('#social').removeClass('col-sm-3').addClass('col-sm-4');

        var r = $('<div class="row"></div>');

        t.append(r);
        c.appendTo(r);
    } else {
        if(s.hasClass('col-sm-12')) {
            var c = s.clone();

            c.removeClass('col-sm-12').addClass('col-sm-5');

            s.parent().remove();

            t.find('#images').removeClass('col-sm-8').addClass('col-sm-4');
            t.find('#social').removeClass('col-sm-4').addClass('col-sm-3');

            c.insertAfter(t.find('#images'));
        }
    }
}); 