/**
 * @package 	WordPress
 * @subpackage 	Mall
 * @version 	1.2.1
 * 
 * Theme Custom Scripts
 * Created by CMSMasters
 * 
 */


jQuery(document).ready(function() {
    "use strict";

    /* Add Class To Row */
    (function($) {
        $('.cmsmasters_row_margin').each(function() {
            var cmsmasters_column = $(this).find('.cmsmasters_column').eq(0);


            if (
                cmsmasters_column.hasClass('one_half') &&
                cmsmasters_column.next().hasClass('one_half')
            ) {
                $(this).addClass('cmsmasters_1212');
            } else if (
                cmsmasters_column.hasClass('one_third') &&
                cmsmasters_column.next().hasClass('two_third')
            ) {
                $(this).addClass('cmsmasters_1323');
            } else if (
                cmsmasters_column.hasClass('two_third') &&
                cmsmasters_column.next().hasClass('one_third')
            ) {
                $(this).addClass('cmsmasters_2313');
            } else if (
                cmsmasters_column.hasClass('one_fourth') &&
                cmsmasters_column.next().hasClass('three_fourth')
            ) {
                $(this).addClass('cmsmasters_1434');
            } else if (
                cmsmasters_column.hasClass('three_fourth') &&
                cmsmasters_column.next().hasClass('one_fourth')
            ) {
                $(this).addClass('cmsmasters_3414');
            } else if (
                cmsmasters_column.hasClass('one_third') &&
                cmsmasters_column.next().hasClass('one_third') &&
                cmsmasters_column.next().next().hasClass('one_third')
            ) {
                $(this).addClass('cmsmasters_131313');
            } else if (
                cmsmasters_column.hasClass('one_half') &&
                cmsmasters_column.next().hasClass('one_fourth') &&
                cmsmasters_column.next().next().hasClass('one_fourth')
            ) {
                $(this).addClass('cmsmasters_121414');
            } else if (
                cmsmasters_column.hasClass('one_fourth') &&
                cmsmasters_column.next().hasClass('one_half') &&
                cmsmasters_column.next().next().hasClass('one_fourth')
            ) {
                $(this).addClass('cmsmasters_141214');
            } else if (
                cmsmasters_column.hasClass('one_fourth') &&
                cmsmasters_column.next().hasClass('one_fourth') &&
                cmsmasters_column.next().next().hasClass('one_half')
            ) {
                $(this).addClass('cmsmasters_141412');
            } else if (
                cmsmasters_column.hasClass('one_fourth') &&
                cmsmasters_column.next().hasClass('one_fourth') &&
                cmsmasters_column.next().next().hasClass('one_fourth') &&
                cmsmasters_column.next().next().next().hasClass('one_fourth')
            ) {
                $(this).addClass('cmsmasters_14141414');
            } else {
                $(this).addClass('cmsmasters_11');
            }
        });
    })(jQuery);



    /* Scroll Top */
    (function($) {
        $(window).scroll(function() {
            if ($(this).scrollTop() > 200) {
                $('#slide_top').filter(':hidden').fadeIn('fast');
            } else {
                $('#slide_top').filter(':visible').fadeOut('fast');
            }
        });


        $('.divider a, #slide_top').on('click', function() {
            $('html, body').animate({
                scrollTop: 0
            }, 'slow');


            return false;
        });
    })(jQuery);



    /* Lightbox Classes Adding */
    (function($) {
        $('.widget_custom_flickr_entries').each(function() {
            var flickrUniqID = uniqID();


            $(this).find('.flickr_badge_image a').each(function() {
                var src = $(this).find('img').attr('src'),
                    title = $(this).find('img').attr('title'),
                    src_full = src.replace(/_s.jpg/g, '.jpg');


                $(this).removeAttr('href').attr({
                    href: src_full,
                    title: title,
                    rel: 'ilightbox[flickr_' + flickrUniqID + ']'
                });
            });
        }); // Flickr Widget Lightbox


        $('.gallery').each(function() {
            var galUniqID = uniqID();


            $(this).find('a').each(function() {
                var linkHref = $(this).attr('href'),
                    lastDotPos = linkHref.lastIndexOf('.'),
                    imgFormat = linkHref.slice(lastDotPos + 1);


                if (imgFormat.length <= 5) {
                    $(this).attr('rel', 'ilightbox[wp_gal_' + galUniqID + ']');
                }
            });
        }); // WordPress Default Gallery Shortcode Lightbox
    })(jQuery);



    /* iLightBox Init */
    (function($) {
        var ilightbox_settings = {
                skin: cmsmasters_script.ilightbox_skin,
                path: cmsmasters_script.ilightbox_path,
                infinite: (cmsmasters_script.ilightbox_infinite == '1') ? true : false,
                keepAspectRatio: (cmsmasters_script.ilightbox_aspect_ratio == '1') ? true : false,
                mobileOptimizer: (cmsmasters_script.ilightbox_mobile_optimizer == '1') ? true : false,
                maxScale: Number(cmsmasters_script.ilightbox_max_scale),
                minScale: Number(cmsmasters_script.ilightbox_min_scale),
                innerToolbar: (cmsmasters_script.ilightbox_inner_toolbar == '1') ? true : false,
                smartRecognition: (cmsmasters_script.ilightbox_mobile_optimizer == '1') ? true : false,
                fullAlone: (cmsmasters_script.ilightbox_fullscreen_one_slide == '1') ? true : false,
                fullViewPort: cmsmasters_script.ilightbox_fullscreen_viewport,
                controls: {
                    toolbar: (cmsmasters_script.ilightbox_controls_toolbar == '1') ? true : false,
                    arrows: (cmsmasters_script.ilightbox_controls_arrows == '1') ? true : false,
                    fullscreen: (cmsmasters_script.ilightbox_controls_fullscreen == '1') ? true : false,
                    thumbnail: (cmsmasters_script.ilightbox_controls_thumbnail == '1') ? true : false,
                    keyboard: (cmsmasters_script.ilightbox_controls_keyboard == '1') ? true : false,
                    mousewheel: (cmsmasters_script.ilightbox_controls_mousewheel == '1') ? true : false,
                    swipe: (cmsmasters_script.ilightbox_controls_swipe == '1') ? true : false,
                    slideshow: (cmsmasters_script.ilightbox_controls_slideshow == '1') ? true : false
                },
                text: {
                    close: cmsmasters_script.ilightbox_close_text,
                    enterFullscreen: cmsmasters_script.ilightbox_enter_fullscreen_text,
                    exitFullscreen: cmsmasters_script.ilightbox_exit_fullscreen_text,
                    slideShow: cmsmasters_script.ilightbox_slideshow_text,
                    next: cmsmasters_script.ilightbox_next_text,
                    previous: cmsmasters_script.ilightbox_previous_text
                },
                errors: {
                    loadImage: cmsmasters_script.ilightbox_load_image_error,
                    loadContents: cmsmasters_script.ilightbox_load_contents_error,
                    missingPlugin: cmsmasters_script.ilightbox_missing_plugin_error
                }
            },
            gallery_array = [],
            gallery_id = '';


        $('[rel="ilightbox"]').each(function() {
            $(this).iLightBox(ilightbox_settings);
        });


        $('[rel^="ilightbox["]').each(function() {
            if ($(this).closest('.cmsmasters_more_items_loader').length === 0) {
                var item_rel = $(this).attr('rel');


                if ($.inArray(item_rel, gallery_array) === -1) {
                    gallery_array.push(item_rel);
                }
            }
        });


        $.each(gallery_array, function(gallery_array, gallery_id) {
            $('[rel="' + gallery_id + '"]').iLightBox(ilightbox_settings);
        });
    })(jQuery);



    /* Shortcodes Animation Run */
    (function($) {
        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android
        ) {
            $('[data-animation]').waypoint(function(dir) {
                if (dir === 'down') {
                    var el = $(this),
                        animation = el.data('animation'),
                        delay = (el.data('delay')) ? el.data('delay') : 0;


                    setTimeout(function() {
                        el.addClass(animation + ' animated');
                    }, delay);
                }
            }, {
                offset: '100%'
            }).waypoint(function(dir) {
                if (dir === 'up') {
                    var el = $(this),
                        animation = el.data('animation'),
                        delay = (el.data('delay')) ? el.data('delay') : 0;


                    setTimeout(function() {
                        el.addClass(animation + ' animated');
                    }, delay);
                }
            }, {
                offset: '25%'
            });
        } else {
            $('[data-animation]').addClass('animated');
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android
        ) {
            $('.cmsmasters_icon_box').waypoint(function(dir) {
                if (dir === 'down') {
                    var el = $(this);


                    el.addClass('shortcode_animated');
                }
            }, {
                offset: '100%'
            }).waypoint(function(dir) {
                if (dir === 'up') {
                    var el = $(this);


                    el.addClass('shortcode_animated');
                }
            }, {
                offset: '25%'
            });
        } else {
            $('.cmsmasters_icon_box').addClass('shortcode_animated');
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android
        ) {
            $('.cmsmasters_icon_list_items.cmsmasters_icon_list_type_block').waypoint(function(dir) {
                if (dir === 'down') {
                    var el = $(this),
                        items = el.find('li'),
                        delay = 500,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '100%'
            }).waypoint(function(dir) {
                if (dir === 'up') {
                    var el = $(this),
                        items = el.find('li'),
                        delay = 500,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '25%'
            });
        } else {
            $('.cmsmasters_icon_list_items .cmsmasters_icon_list_item').addClass('shortcode_animated');
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android
        ) {
            $('.cmsmasters_hover_slider').waypoint(function(dir) {
                if (dir === 'down') {
                    var el = $(this),
                        items = el.find('li'),
                        delay = 300,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '100%'
            }).waypoint(function(dir) {
                if (dir === 'up') {
                    var el = $(this),
                        items = el.find('li'),
                        delay = 300,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '25%'
            });
        } else {
            $('.cmsmasters_hover_slider ul li').addClass('shortcode_animated');
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android
        ) {
            $('.cmsmasters_profile.vertical').waypoint(function(dir) {
                if (dir === 'down') {
                    var el = $(this),
                        items = el.find('article'),
                        delay = 500,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '100%'
            }).waypoint(function(dir) {
                if (dir === 'up') {
                    var el = $(this),
                        items = el.find('article'),
                        delay = 500,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '25%'
            });
        } else {
            $('.cmsmasters_profile.vertical .profile').addClass('shortcode_animated');
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android
        ) {
            $('.cmsmasters_clients_grid').waypoint(function(dir) {
                if (dir === 'down') {
                    var el = $(this),
                        items = el.find('.cmsmasters_clients_item'),
                        delay = 300,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '100%'
            }).waypoint(function(dir) {
                if (dir === 'up') {
                    var el = $(this),
                        items = el.find('.cmsmasters_clients_item'),
                        delay = 300,
                        i = 1;


                    items.each(function() {
                        var item = $(this);


                        setTimeout(function() {
                            item.addClass('shortcode_animated');
                        }, delay * i);


                        i += 1;
                    });
                }
            }, {
                offset: '25%'
            });
        } else {
            $('.cmsmasters_clients_grid').find('.cmsmasters_clients_item').addClass('shortcode_animated');
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android
        ) {
            $('.cmsmasters_gallery, .blog.columns, .blog.timeline').waypoint(function(dir) {
                if (dir === 'down') {
                    var el = $(this),
                        items = el.find('article.post, .cmsmasters_gallery_item'),
                        itemsCount = items.length,
                        delay = 300,
                        i = 1;


                    var newTime = setInterval(function() {
                        if (el.hasClass('isotope')) {
                            clearInterval(newTime);
                        } else {
                            return false;
                        }


                        items.each(function() {
                            var item = $(this);


                            setTimeout(function() {
                                item.addClass('shortcode_animated');
                            }, delay * i);


                            i += 1;


                            if (i === itemsCount) {
                                setTimeout(function() {
                                    $(window).trigger('resize');
                                }, delay * i);
                            }
                        });
                    }, 300);
                }
            }, {
                offset: '100%'
            }).waypoint(function(dir) {
                if (dir === 'up') {
                    var el = $(this),
                        items = el.find('article.post, .cmsmasters_gallery_item'),
                        itemsCount = items.length,
                        delay = 300,
                        i = 1;


                    var newTime = setInterval(function() {
                        if (el.hasClass('isotope')) {
                            clearInterval(newTime);
                        } else {
                            return false;
                        }


                        items.each(function() {
                            var item = $(this);


                            setTimeout(function() {
                                item.addClass('shortcode_animated');
                            }, delay * i);


                            i += 1;


                            if (i === itemsCount) {
                                setTimeout(function() {
                                    $(window).trigger('resize');
                                }, delay * i);
                            }
                        });
                    }, 300);
                }
            }, {
                offset: '25%'
            });
        } else {
            $('.cmsmasters_gallery, .blog.columns, .blog.timeline').find('article.post, .cmsmasters_gallery_item').addClass('shortcode_animated');
        }
    })(jQuery);



    /* Stats Run */
    (function($) {
        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android &&
            !checker.ua.ie9
        ) {
            $('.cmsmasters_stats.stats_mode_circles').waypoint(function() {
                var i = 1;


                $(this).find('.cmsmasters_stat').each(function() {
                    var el = $(this);


                    setTimeout(function() {
                        el.easyPieChart({
                            size: 140,
                            lineWidth: 5,
                            lineCap: 'square',
                            animate: 1000,
                            scaleColor: false,
                            trackColor: false,
                            barColor: function() {
                                return ($(this.el).data('bar-color')) ? $(this.el).data('bar-color') : cmsmasters_script.primary_color;
                            },
                            onStep: function(from, to, val) {
                                $(this.el).find('.cmsmasters_stat_counter').text(~~val);
                            }
                        });
                    }, 500 * i);


                    i += 1;
                });
            }, {
                offset: '100%'
            });
        } else {
            $('.cmsmasters_stats.stats_mode_circles').find('.cmsmasters_stat').easyPieChart({
                size: 140,
                lineWidth: 5,
                lineCap: 'square',
                animate: 1000,
                scaleColor: false,
                trackColor: false,
                barColor: function() {
                    return ($(this.el).data('bar-color')) ? $(this.el).data('bar-color') : cmsmasters_script.primary_color;
                },
                onStep: function(from, to, val) {
                    $(this.el).find('.cmsmasters_stat_counter').text(~~val);
                }
            });
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android &&
            !checker.ua.ie9
        ) {
            $('.cmsmasters_counters').waypoint(function() {
                var i = 1;


                $(this).find('.cmsmasters_counter').each(function() {
                    var el = $(this);


                    setTimeout(function() {
                        el.easyPieChart({
                            size: 140,
                            lineWidth: 0,
                            lineCap: 'square',
                            animate: 1500,
                            scaleColor: false,
                            trackColor: false,
                            barColor: '#ffffff',
                            onStep: function(from, to, val) {
                                $(this.el).find('.cmsmasters_counter_counter').text(~~val);
                            }
                        });
                    }, 500 * i);


                    i += 1;
                });
            }, {
                offset: '100%'
            });
        } else {
            $('.cmsmasters_counters').find('.cmsmasters_counter').easyPieChart({
                size: 140,
                lineWidth: 0,
                lineCap: 'square',
                animate: 1500,
                scaleColor: false,
                trackColor: false,
                barColor: '#ffffff',
                onStep: function(from, to, val) {
                    $(this.el).find('.cmsmasters_counter_counter').text(~~val);
                }
            });
        }


        if (!checker.os.iphone &&
            !checker.os.ipod &&
            !checker.os.ipad &&
            !checker.os.blackberry &&
            !checker.os.android &&
            !checker.ua.ie9
        ) {
            $('.cmsmasters_stats.stats_mode_bars').waypoint(function() {
                $(this).addClass('shortcode_animated').find('.cmsmasters_stat').each(function() {
                    var el = $(this);


                    el.easyPieChart({
                        size: 140,
                        lineWidth: 0,
                        lineCap: 'square',
                        animate: 1500,
                        scaleColor: false,
                        trackColor: false,
                        barColor: '#ffffff',
                        onStep: function(from, to, val) {
                            $(this.el).find('.cmsmasters_stat_counter').text(~~val);
                        }
                    });
                });
            }, {
                offset: '100%'
            });
        } else {
            $('.cmsmasters_stats.stats_mode_bars').addClass('shortcode_animated').find('.cmsmasters_stat').easyPieChart({
                size: 140,
                lineWidth: 0,
                lineCap: 'square',
                animate: 1500,
                scaleColor: false,
                trackColor: false,
                barColor: '#ffffff',
                onStep: function(from, to, val) {
                    $(this.el).find('.cmsmasters_stat_counter').text(~~val);
                }
            });
        }
    })(jQuery);



    /* Header Search Toggle */
    (function($) {
        $('.search_wrap .search_button button').on('click', function() {
            if ($(window).width() > (768 - 17)) {
                var searchButton = $(this),
                    searchWrap = searchButton.closest('.search_wrap'),
                    searchInput = searchWrap.find('.search_field input');


                if (searchWrap.hasClass('search_opened')) {
                    searchWrap.removeClass('search_opened');

                    searchButton.removeClass('cmsmasters_theme_icon_cancel');

                    setTimeout(function() {
                        searchButton.addClass('cmsmasters_theme_icon_search').attr('type', 'submit');
                    }, 300);
                } else {
                    searchWrap.addClass('search_opened');

                    searchButton.removeClass('cmsmasters_theme_icon_search');

                    setTimeout(function() {
                        searchButton.addClass('cmsmasters_theme_icon_cancel').attr('type', 'button');
                    }, 300);

                    searchInput.focus();
                }


                return false;
            }
        });

        $(window).on('debouncedresize', function() {
            if ($(window).width() <= (768 - 17)) {
                var searchButton = $('.search_wrap .search_button button'),
                    searchWrap = searchButton.closest('.search_wrap'),
                    searchInput = searchWrap.find('.search_field input');


                if (searchWrap.hasClass('search_opened')) {
                    searchWrap.removeClass('search_opened');

                    searchButton.removeClass('cmsmasters_theme_icon_cancel');

                    setTimeout(function() {
                        searchButton.addClass('cmsmasters_theme_icon_search').attr('type', 'submit');
                    }, 300);
                }
            }
        });
    })(jQuery);



    /* Header Top Hide Toggle */
    (function($) {
        $('.header_top_but').on('click', function() {
            var headerTopBut = $(this),
                headerTopButArrow = headerTopBut.find('> span'),
                headerTopOuter = headerTopBut.parents('.header_top').find('.header_top_outer');

            if (headerTopBut.hasClass('opened')) {
                headerTopOuter.slideUp();

                headerTopButArrow.removeClass('cmsmasters_theme_icon_slide_top').addClass('cmsmasters_theme_icon_slide_bottom');

                headerTopBut.removeClass('opened').addClass('closed');
            } else if (headerTopBut.hasClass('closed')) {
                headerTopOuter.slideDown();

                headerTopButArrow.removeClass('cmsmasters_theme_icon_slide_bottom').addClass('cmsmasters_theme_icon_slide_top');

                headerTopBut.removeClass('closed').addClass('opened');
            }
        });
    })(jQuery);



    /* Fixed Header Function Start */
    (function($) {
        $('#header').cmsmastersFixedHeaderScroll();
    })(jQuery);



    /* Responsive Navigation Function Start */
    (function($) {
        $('#navigation').cmsmastersResponsiveNav();
    })(jQuery);



    /* Row Parallax Function Start */
    (function($) {
        $(window).on('load', function() {
            if (!checker.os.iphone &&
                !checker.os.ipad &&
                !checker.os.ipod &&
                !checker.os.android &&
                !checker.os.blackberry
            ) {
                if (checker.ua.safari) {
                    if (checker.ua.chrome || checker.os.mac) {
                        setTimeout(function() {
                            $.stellar({
                                horizontalScrolling: false,
                                verticalOffset: 30,
                                parallaxElements: false
                            });
                        }, 1500);


                        $(window).on('debouncedresize', function() {
                            if ($(window).width() < 1024) {
                                $.stellar('destroy');
                            } else {
                                $.stellar({
                                    horizontalScrolling: false,
                                    verticalOffset: 30,
                                    parallaxElements: false
                                });
                            }
                        });
                    }
                } else {
                    setTimeout(function() {
                        $.stellar({
                            horizontalScrolling: false,
                            verticalOffset: 30,
                            parallaxElements: false
                        });
                    }, 1500);


                    $(window).on('debouncedresize', function() {
                        if ($(window).width() < 1024) {
                            $.stellar('destroy');
                        } else {
                            $.stellar({
                                horizontalScrolling: false,
                                verticalOffset: 30,
                                parallaxElements: false
                            });
                        }
                    });
                }
            } else {
                $('div.cmsmasters_row').css('background-attachment', 'scroll');
            }
        });
    })(jQuery);



    /* One Page Navigation */
    (function($) {
        function cmsmasters_get_offset_val() {
            var cmsmasters_wpAdminBar = $('#wpadminbar').outerHeight(),
                cmsmasters_offset_val = (cmsmasters_wpAdminBar !== undefined) ? cmsmasters_wpAdminBar : 0;


            if ($('#page').hasClass('fixed_header')) {
                var header_mid_data_height = $('.header_mid').data('height'),
                    header_mid_height = header_mid_data_height - (header_mid_data_height / 3),
                    header_bot_data_height = $('.header_bot').data('height'),
                    header_bot_data_height = (header_bot_data_height !== undefined) ? header_bot_data_height : 0;


                cmsmasters_offset_val = cmsmasters_offset_val + header_mid_height + header_bot_data_height - 1;
            }


            return cmsmasters_offset_val;
        }


        var cmsmasters_window_hash = window.location.hash;

        if ($(cmsmasters_window_hash).length > 0) {
            setTimeout(function() {
                $('html, body').animate({
                    scrollTop: $(cmsmasters_window_hash).offset().top - cmsmasters_get_offset_val() + 1
                }, 800);
            }, 800);
        }


        $('body').scrollspy({
            target: '#navigation'
        });


        $('#navigation a').on('click', function(event) {
            if (this.hash !== "") {
                event.preventDefault();


                var hash = this.hash,
                    linkHref = $(this).attr('href');


                if ($(hash).length > 0) {
                    $('html, body').animate({
                        scrollTop: $(hash).offset().top - cmsmasters_get_offset_val() + 1
                    }, 800, function() {
                        if (history.pushState) {
                            history.pushState(null, null, hash);
                        }
                    });
                } else if (!$('body').hasClass('cmsmasters_custom_page_menu')) {
                    if (
                        linkHref.indexOf(hash) !== -1 &&
                        linkHref.slice(0, linkHref.indexOf(hash)) !== cmsmasters_script.site_url &&
                        linkHref !== hash
                    ) {
                        window.location.href = linkHref;
                    } else {
                        window.location.href = cmsmasters_script.site_url + hash;
                    }
                }
            }
        });
    })(jQuery);



    /* Notise Close Button */
    (function($) {
        $('.cmsmasters_notice a.notice_close').on('click', function() {
            $(this).parents('.cmsmasters_notice').fadeOut(500, function() {
                $(this).remove();
            });


            return false;
        });
    })(jQuery);



    /* Toggles */
    (function($) {
        $('.cmsmasters_toggles .cmsmasters_toggle_title a').on('click', function(i) {
            var active_toggle = $(this).parents('.cmsmasters_toggles').find('.cmsmasters_toggle_wrap.current_toggle .cmsmasters_toggle'),
                toggle = $(this).parents('.cmsmasters_toggle_wrap'),
                acc = ($(this).parents('.cmsmasters_toggles').hasClass('toggles_mode_accordion')) ? true : false,
                dropDown = toggle.find('.cmsmasters_toggle');


            if (toggle.hasClass('current_toggle')) {
                dropDown.slideUp('fast', function() {
                    toggle.removeClass('current_toggle');
                });
            } else {
                if (acc) {
                    active_toggle.slideUp('fast', function() {
                        active_toggle.parents('.cmsmasters_toggle_wrap').removeClass('current_toggle');
                    });
                }

                dropDown.slideDown('fast', function() {
                    toggle.addClass('current_toggle');
                });
            }


            i.preventDefault();


            setTimeout(function() {
                jQuery('body').trigger('debouncedresize');
            }, 300);
        });


        $('.cmsmasters_toggles .cmsmasters_toggles_filter a').on('click', function(i) {
            var filter_wrap = $(this).parents('.cmsmasters_toggles_filter'),
                filter = $(this).data('key'),
                toggle = $(this).parents('.cmsmasters_toggles').find('.cmsmasters_toggle_wrap');


            if ($(this).is(':not(.current_filter)')) {
                filter_wrap.find('a').removeClass('current_filter');


                $(this).addClass('current_filter');


                toggle.filter('[data-tags~="' + filter + '"]').slideDown('fast');


                toggle.filter(':not([data-tags~="' + filter + '"])').slideUp('fast');


                toggle.filter(':not([data-tags~="' + filter + '"])').removeClass('current_toggle').find('.cmsmasters_toggle').removeAttr('style');
            }


            i.preventDefault();
        });
    })(jQuery);



    /* Tabs */
    (function($) {
        $('.cmsmasters_woo_tabs > .cmsmasters_tabs_list > .cmsmasters_tabs_list_item:first-child').addClass('current_tab');
        $('.cmsmasters_woo_tabs > .cmsmasters_tabs_wrap > .cmsmasters_tab:first-child').addClass('active_tab');

        $('.cmsmasters_tabs ul.cmsmasters_tabs_list li a').on('click', function(t) {
            var tabs_parent = $(this).parents('.cmsmasters_tabs'),
                tabs = tabs_parent.find('.cmsmasters_tabs_wrap'),
                index = $(this).parents('li').index();


            tabs_parent.find('.cmsmasters_tabs_list > .current_tab').removeClass('current_tab');


            $(this).parents('li').addClass('current_tab');


            tabs.find('.cmsmasters_tab').not(':eq(' + index + ')').slideUp('fast', function() {
                $(this).removeClass('active_tab');
            });


            tabs.find('.cmsmasters_tab:eq(' + index + ')').slideDown('fast', function() {
                $(this).addClass('active_tab');
            });


            t.preventDefault();


            setTimeout(function() {
                jQuery('body').trigger('debouncedresize');
            }, 300);
        });
    })(jQuery);



    /* Share Buttons */
    (function($) {
        $('.share_posts a, .share_wrap a:not(.cmsmasters_pinterest_button)').bind('click', function(e) {
            var screenSize = {
                    width: screen.width,
                    height: screen.height
                },
                windowWidth = 650,
                windowHeight = 350,
                windowTop = (screenSize.height / 2) - (windowHeight / 2),
                windowLeft = (screenSize.width / 2) - (windowWidth / 2),
                socialHref = $(this).attr('href'),
                newWindow = 'width = ' + windowWidth + ', height = ' + windowHeight + ', top = ' + windowTop + ', left = ' + windowLeft + ', resizable = no, status = no, titlebar = no, toolbar = no, location = no';


            e.preventDefault();


            return window.open(socialHref, '_blank', newWindow);
        });
    })(jQuery);



    /* YouTube Iframe Fix */
    (function($) {
        var iframe = $('iframe[src*="youtube.com"]');


        iframe.each(function() {
            var current = $(this),
                src = current.attr('src');


            if (src) {
                if (src.indexOf('?') !== -1) {
                    src += "&wmode=opaque";
                } else {
                    src += "?wmode=opaque";
                }


                current.attr('src', src);
            }
        });
    })(jQuery);
});



/* Like Button */
function cmsmastersLike(postID) {
    "use strict";

    if (postID !== '') {
        var likeButton = jQuery('#cmsmastersLike-' + postID),
            data = {
                action: 'cmsmasters_ajax_like',
                id: postID,
                nonce: cmsmasters_script.nonce_ajax_like
            };


        likeButton.find('> span').text('...');


        jQuery.post(cmsmasters_script.ajaxurl, data, function(response) {
            likeButton.find('> span').text(response);


            likeButton.addClass('active');


            likeButton.attr({
                onclick: 'return false;'
            });
        });
    }


    return false;
}


"use strict";

/* Correct OS & Browser Check */
var ua = navigator.userAgent,
    checker = {
        os: {
            iphone: ua.match(/iPhone/),
            ipod: ua.match(/iPod/),
            ipad: ua.match(/iPad/),
            blackberry: ua.match(/BlackBerry/),
            android: ua.match(/(Android|Linux armv6l|Linux armv7l)/),
            linux: ua.match(/Linux/),
            win: ua.match(/Windows/),
            mac: ua.match(/Macintosh/)
        },
        ua: {
            ie: ua.match(/MSIE/),
            ie6: ua.match(/MSIE 6.0/),
            ie7: ua.match(/MSIE 7.0/),
            ie8: ua.match(/MSIE 8.0/),
            ie9: ua.match(/MSIE 9.0/),
            ie10: ua.match(/MSIE 10.0/),
            ie11: ua.match(/MSIE 11.0/),
            opera: ua.match(/Opera/),
            firefox: ua.match(/Firefox/),
            chrome: ua.match(/Chrome/),
            safari: ua.match(/(Safari|BlackBerry)/)
        }
    };



/* Correct Image Load Check */
function isImageOk(img) {
    "use strict";

    if (!img.complete) {
        return false;
    }


    if (typeof img.naturalWidth !== undefined && img.naturalWidth === 0) {
        return 'stop';
    }


    return true;
}



/* Check Whether the Numbers are Approximately Equal */
function checkN(a, b, x) {
    "use strict";

    if ((a > b && a - x <= b) || (b > a && b - x <= a)) {
        return true;
    } else {
        return false;
    }
}



/* Run Pinterest Widget */
if (jQuery('.cmsmasters_pinterest_button').length > 0) {
    (function() {
        window.PinIt = window.PinIt || {
            loaded: false
        };

        if (window.PinIt.loaded) {
            return;
        }

        window.PinIt.loaded = true;

        function async_load() {
            var s = document.createElement("script");
            s.type = "text/javascript";
            s.async = true;
            s.src = "//assets.pinterest.com/js/pinit.js";

            var x = document.getElementsByTagName("script")[0];


            x.parentNode.insertBefore(s, x);
        }

        if (window.attachEvent) {
            window.attachEvent("onload", async_load);
        } else {
            window.addEventListener("load", async_load, false);
        }
    })();
}



/* Uniq ID */
function uniqID() {
    "use strict";

    return Math.round(new Date().getTime() + (Math.random() * 1000000));
}