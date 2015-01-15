(function ($) {

    /// <summary>文章记录点击事件</summary>
    function articleClick(event) {
        var articleId = $(this).attr("articleId"); 
        var data = $.data(event.data.element, "articleui");
        var record = undefined;

        $.each(data.options.data, function (index, obj) { // 获取文章记录对应的数据
            if (obj.articleId == articleId) {
                record = obj;
                return false;
            }
        });

        // 会调文章记录点击事件
        if (data.options.articleRecordeClick) {
            data.options.articleRecordeClick(record);
        }
    }

    ///<summary>生成UI</summary>
    function generateArticleUI(element, data) {
        var htmlContainerStr = '<div class="article-record-container" articleId={0}> </div>';
        var htmlStr = '<div class="article-record-img-container">' +
                        '<img class="article-record-img" src="{0}" />' +
                    '</div>' +
                    '<div>' +
                        '<div>' +
                            '<label class="articletitle" >{1}</label>' +
                        '</div>' +
                    '</div>' +
                    '<label class="tag">{2}</label>' +
                    '<div class="clear-both"> </div>';

        $.each(data, function (index, obj) {
            var htmlContainer = htmlContainerStr.format(obj.articleId)
            var html = htmlStr.format(obj.imgPath, obj.title, obj.tag)

            var container = $(htmlContainer);
            container.append(html);
            container.on('click', { element: element }, articleClick);
          
            $(element).append(container)
        });
    }

    $.fn.articleui = function articleui(opt, param) {
        // 方法调用
        if (typeof opt == 'string') {
            var method = $.fn.articleui.methods[opt];
            if (method) {
                return method(this, param);
            }
        }

        // 创建对象
        var option = $.extend({
            articleRecordeClick:undefined,
            data: []
        }, opt);

        // this为Element元素
        return this.each(function () {
            _articleui = this;
            var state = $.data(this, 'articleui');
            if (state) {
                $.extend(state.options, options);
            } else {
                $.data(this, 'articleui', {
                    options:option
                });
            }
           
            generateArticleUI(this, option.data);
        });
    };

    // 方法定义
    $.fn.articleui.methods = {};
})(jQuery)