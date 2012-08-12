/*jslint browser: true */
/*global $ */
var contentUrl = '/dashboard/content';
var secondsBeforeReload = 0;
var reloadInterval;

$(document).ready(function () {
    'use strict';
    $('#js-required').remove();
    $('#dashboard').show();
    reloadInterval = setInterval(function () {
        if (secondsBeforeReload < 1) {
            $('#dashboard').load(contentUrl, function () {
                $('*[rel=popover]').popover();
            });
            secondsBeforeReload = 10;
        } else {
            secondsBeforeReload = secondsBeforeReload - 1;
        }
    }, 1000);
});