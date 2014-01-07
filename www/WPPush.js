'use strict';

var WPPush = (function() {

    function WPPush() {

    };

    WPPush.prototype.test = function(callback) {
       
    };

    var _this = {
        call_native: function(callback, name, args) {
            args = args || [];

            return cordova.exec(callback, this.failure, 'PushNotificationPlugin', name, args);
        }
    };

    return WPPush;
})();

module.exports = new WPPush();