(function ($, Dropbox) {
    
    var DropboxPicker = window.DropboxPicker = function (opts) {
        this.opts = $.extend({}, opts);
    };
    
    DropboxPicker.prototype.init = function (cb) { 
        cb();
    };
    
    DropboxPicker.prototype.openDialog = function (cb) {
        Dropbox.choose({
            linkType: 'direct',
            multiselect: false, 
            success: function (files) {
                cb(files[0].name, files[0].link);
            }
        });
    };
    
})($, Dropbox);
