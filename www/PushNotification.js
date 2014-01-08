'use strict';

var PushNotification = (function() {

    function PushNotification() {

    };

    PushNotification.prototype.getIncoming = function(callback) {
        _this.call_native(callback, 'GetIncoming');
    };

    var _this = {
        call_native: function(callback, name, args) {
            args = args || [];

            return cordova.exec(callback, this.failure, 'PushNotificationPlugin', name, args);
        }
    };

    return PushNotification;
})();

module.exports = new PushNotification();