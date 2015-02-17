To enable jQTouch add the following lines to your document:

<script src="/Scripts/jquery-1.4.2.min.js" type="application/x-javascript" charset="utf-8"></script>
<script src="/Scripts/jqtouch.js" type="application/x-javascript" charset="utf-8"></script>

<style type="text/css" media="screen">@import "/Content/jQTouch/jqtouch.css";</style>
<style type="text/css" media="screen">@import "/Content/jQTouch/jqt/theme.css";</style>

To change the theme to apple, change the import statement in the second style tag to "/Content/jQTouch/apple/theme.css".

Lastly, add the following line of javascript to initialize jQTouch:

$.jQTouch();

For Demos and Extensions check out http://jqtouch.com.