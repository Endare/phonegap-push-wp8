'use strict';

var PushNotificationPlugin = (function() {

    function PushNotificationPlugin() {

    };

    PushNotificationPlugin.prototype.getIncoming = function(callback) {
        _this.call_native(callback, 'GetIncoming');
    };

    var _this = {
        call_native: function(callback, name, args) {
            args = args || [];

            return cordova.exec(callback, this.failure, 'PushNotificationPlugin', name, args);
        }
    };

    return PushNotificationPlugin;
})();

module.exports = new PushNotificationPlugin();