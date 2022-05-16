(function ($) {
    var self = this;
    self.Loading = function (status) {
        
        if (status == "show") {
            self.html = '<div class="box-loading-page" style="position: fixed;left: 0;width: 100%;height: 100%;z-index: 1000;display: flex;justify-content: center;align-items: center;">' +
                '<div class="spinner-border"></div>' +
                '<div style="background-color: rgb(136, 136, 136);display: inline-block;width: 100%;height: 100%;position: fixed;opacity: 0.2;"></div></div>';
            $('body').append(self.html);
        } else {
            $('body .box-loading-page').remove();
        }
    };
})(jQuery);