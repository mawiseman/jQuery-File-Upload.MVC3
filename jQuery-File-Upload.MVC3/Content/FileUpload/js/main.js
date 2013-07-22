/*
 * jQuery File Upload Plugin JS Example 7.0
 * https://github.com/blueimp/jQuery-File-Upload
 *
 * Copyright 2010, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * http://www.opensource.org/licenses/MIT
 */

/*jslint nomen: true, unparam: true, regexp: true */
/*global $, window, document */

$(function () {
    $('#fileupload').fileupload();

    $('#fileupload').fileupload('option', {
        maxFileSize: 500000000,
        resizeMaxWidth: 1920,
        resizeMaxHeight: 1200
    });
});
