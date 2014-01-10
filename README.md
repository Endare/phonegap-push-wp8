# Phonegap Windows Phone 8 Push Plugin

![Endare icon](http://www.endare.eu/images/logo.png)

This plugin offers a way to register a Windows Phone device with a push server. It uses basic authentication to identify itself
at the push server. It's up to you to implement the server and to check if the call is valid or not.

## Phonegap CLI
You can add this plugin via the command line

```bash
$ phonegap local plugin add https://github.com/Endare/phonegap-push-wp8.git
```

This will add the following lines to your config.xml

```xml
<feature name="PushNotificationPlugin">
    <param name="wp-package" onload="true" value="PushNotificationPlugin" />
</feature>
```

In order to configure the registration endpoint and the application key and secret, you have to add the following lines to your
config.xml file.

```xml
<preference name="eu.endare.push.registration_uri" value="http://my.server.com/push" />
<preference name="eu.endare.push.app_key" value="APP_KEY" />
<preference name="eu.endare.push.app_secret" value="APP_SECRET" />
```

You can use whatever you want as APP_KEY and APP_SECRET. The library will use the key as basic authentication username, and the
secret as basic authentication password.

## Registration
When the plugin loads, it is automatically initialized and the following HTTP call is done to the server.

```
POST /push HTTP/1.1
Host: my.server.com
Content-Type: application/json

{platform: "Windows Phone 8", token: "GEQ5da8qDA452dQDADE221dadQ"}
```

So a post is done to your server's endpoint with a JSON body. The body consists of the platform and the push token. This push token will be
used to push data to the device.

## Contributors
 * [Sam Verschueren]     <sam.verschueren@endare.com>

## Changelog
**1.0.0:**
 * first release
 
## The full MIT license

The MIT License

Copyright (c) 2013 Endare BVBA <info@endare.eu>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.