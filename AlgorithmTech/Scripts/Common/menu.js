/*
 * 菜单JS
 *
 */
(function (window) {
    var expanedMenuWidth = 110, // 菜单展开时宽度
    collapsedMenuWidth = 60;// 菜单收缩时宽度

    /// <summary>初始化菜单</summary>
    function initMenu() {
        var subItemHeights = getSubItemHeights();

        $(".items-func").hover(function () { // 主菜单项
            var func = $(this).attr("func");

            if ($(this).find(".items-logo div").hasClass("disabled") > 0) {
                $(this).css({ "background": "url('#')", "color": "gray", "cursor": "not-allowed" });
                return;
            }

            var $div = $(this).find(".items-logo div");
            $div.css({ "background-position": "0px " + (parseFloat($div.css("background-position-y")) - 64) + "px" });

            var $subItems = $(this).find(".subItems");
            var index = $(this).prevAll(".items-func").length;
            var parentTop = $(this).offset().top;
            var middleH = $(window).height() - $("#top").height() - $("#bottom").height();

            if ($(this).find(".subItems-func").length > 0) {
                setSubMenuLeft();
                $subItems.show(100, function () { // 显示子菜单
                    var height = subItemHeights[index] ? subItemHeights[index] : $subItems.height();
                    if (height > middleH) {
                        $(this).css("top", $("#top").height());
                        $subItems.height(middleH);
                    } else {
                        if (middleH - (parentTop - $("#top").height()) > height) {
                            $(this).css("top", parentTop > $("#top").height() ? parentTop : $("#top").height());
                        } else {
                            var top = $(window).height() - height - $("#bottom").height();
                            $(this).css("top", top > 0 ? top : parentTop);
                        }
                        $subItems.height(height);
                    }
                });
            }
        }, function () {
            if ($(this).find(".items-logo div").hasClass("disabled") > 0) {
            }
            else {
                var $div = $(this).find(".items-logo div");
                $div.css({ "background-position": "0px " + (parseFloat($div.css("background-position-y")) + 64) + "px" });
            }
            $(this).find(".subItems").hide();
        }).click(function () {
            var url = $(this).attr("url");
            if (url && url.indexOf("#") !== 0) {
                navigateTo(url);
            }
        });

        $(".subItems-func").hover(function () {
            var $div = $(this).find(".subItems-logo div");
            $div.css({ "background-position": "0px " + (parseFloat($div.css("background-position-y")) - 24) + "px" });
        }, function () {
            var $div = $(this).find(".subItems-logo div");
            $div.css({ "background-position": "0px " + (parseFloat($div.css("background-position-y")) + 24) + "px" });
        });

        $(".subItems-func").click(function () { // 子菜单单击
            var url = $(this).attr("url");
            navigateTo(url);
            return false;
        });

        $("#div-expander-menu").click(function () { // 收缩/展开

            $.cookie(userId + ".__isMenuCollapsed", null, { path: '/' })
            if (window.__isMenuCollapsed) { // 当前收缩，展开
                $.cookie(userId + ".__isMenuCollapsed", "0", { expires: 365, path: '/' });
                window.__isMenuCollapsed = false;

            } else { // 收缩
                $.cookie(userId + ".__isMenuCollapsed", "1", { expires: 365, path: '/' });
                window.__isMenuCollapsed = true;

            }
            tooggleMenu(!window.__isMenuCollapsed);
        });

        tooggleMenu();
        $("#div-expander-menu").show();
    }

    // 收缩、展开菜单
    function tooggleMenu(expand) {
        var shouldResize = true;
        if (expand === undefined) { // 根据Cookie决定收缩、展开
            //if ($.cookie(userId + ".__isMenuCollapsed") === "1") {
            //    expand = false;
            //} else {
            //    expand = true;
            //}
            expand = true;
            shouldResize = false;
        }
        var itemsW = expanedMenuWidth;
        if (expand) { // 展开
            $(".items-text").show(150);
            $("#middle_left").width(expanedMenuWidth);
            $("#items").width(expanedMenuWidth);
            $("#div-expander-menu").removeClass("div-expand").addClass("div-collapse").attr("title", "收缩菜单")/*.css("left", expanedMenuWidth)*/;
            if (shouldResize && typeof resize === "function") {
                try {
                    resize();
                } catch (e) { }
            }
        } else { // 收缩
            itemsW = collapsedMenuWidth;

            $(".items-text").hide(150, function () {
                $("#items").width(collapsedMenuWidth);
                $("#middle_left").width(collapsedMenuWidth);
                $("#div-expander-menu").removeClass("div-collapse").addClass("div-expand").attr("title", "展开菜单")/*.css("left", collapsedMenuWidth)*/;
                if (shouldResize && typeof resize === "function") {
                    try {
                        resize();
                    } catch (e) { }
                }
            });
        }
        window.__isMenuCollapsed = !expand;

        setSubMenuLeft(itemsW);
    }

    // 设置子菜单的left样式
    function setSubMenuLeft(itemsW) {
        if (!itemsW) {
            itemsW = $("#items").width();
        }
        var middleH = $(window).height() - $("#top").height() - $("#bottom").height();
        if ($("#items")[0].scrollHeight > middleH) {// 有滚动条
            $(".subItems").css("left", itemsW - 17);
        } else {
            $(".subItems").css("left", itemsW);
        }
    }

    // 获取二级菜单高度
    function getSubItemHeights() {
        var subItemHeights = [];
        $(".items-func").each(function (i, n) {
            subItemHeights[i] = $(this).find(".subItems").height();
        });
        return subItemHeights;
    }

    /// <summary> URL跳转 </summary>
    function navigateTo(url) {
        if (!url) {
            return;
        }
        if (url.indexOf("?") > 0) {
            url += "&t=" + new Date().getTime();
        } else {
            url += "?t=" + new Date().getTime();
        }
        var ir = document.getElementById("iframe-main-content");
        ir.src = url;
    }

    var itemCount = 0, middleThrottleH = 0;

    /// <summary>初始化菜单的高度</summary>
    function initMenuHeight() {
        itemCount = $(".items-func").length; // 计算菜单需要的高度
        middleThrottleH = itemCount * 94 + 10;
        $(window).resize(function () {
            layout();
        });

        setTimeout(layout, 100);
    }

    /// <summary>自适应高度</summary>
    function layout() {
        var newH = $(window).height() - $("#top").height() - $("#bottom").height();
        $("#middle").height(newH);
        $("#middle_left").height(newH);
        $("#mainWrap").height(newH);
        $("#items").height(newH);

        if (newH >= middleThrottleH) {
            $(".items-func").height(94);
            $(".items-logo").css("margin-top", 31);
            $(".items-text").css("margin-top", 35);
        } else {
            newH = 94 - (middleThrottleH - newH) / itemCount;
            newH = newH < 60 ? 60 : newH;
            $(".items-func").height(newH);
            $(".items-logo").css("margin-top", (newH - 32) / 2);
            $(".items-text").css("margin-top", (newH - 32) / 2 + 4);
        }

        try {
            resize();
        } catch (ex) {
        }
    }

    window.menu = {
        initMenu: initMenu,
        initMenuHeight:initMenuHeight
    };
})(window);


$(function () {
    window.menu.initMenu();
    window.menu.initMenuHeight();
});