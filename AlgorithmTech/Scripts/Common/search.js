(function () {
    /// <summary>初始化搜索框<summary>
    function initSearch(propmt, searcher){
        $("#search").searchbox({
            prompt: prompt,
            searcher: searcher
            });
    }
})();