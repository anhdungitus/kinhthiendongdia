////////////ajax loading
var divAjaxLoading = '<div id="divAjaxLoadingPage" class="divAjaxLoadingPage">' +
            '<img class="imgAjaxLoading" src="/Images/ajaxLoading.gif" alt="Ajax loading" />' +
        '</div>';

var lthdShowAjaxLoadingForPage = function () {
	var width = $(document).width();
	var height = $(document).height();
	var top = $(window).scrollTop() + ($(window).height() / 2) - 20;
	if ($("#divAjaxLoadingPage").length == 0) {
		$("body").append(divAjaxLoading);
	}

	$("#divAjaxLoadingPage").css({ "display": "block", "width": width, "height": height });
	$("#divAjaxLoadingPage .imgAjaxLoading").css({ "top": top });
}

$.fn.lthdShowAjaxLoadingForDom = function () {
	var hight = $(this).height();
	var top = hight / 2 - 50;

	if ($("#divAjaxLoadingPage").length == 0) {
		$(this).append(divAjaxLoading);
	}

	$("#divAjaxLoadingPage").css({ "display": "block", "width": "100%", "height": "100%" });
	$("#divAjaxLoadingPage .imgAjaxLoading").css({ "top": top });


	//apply options
	if (arguments.length != 0) {
		if (arguments[0].marginTop != undefined) {
			$("#divAjaxLoadingPage").css({ "margin-top": arguments[0].marginTop, "height": hight - arguments[0].marginTop });
		}
	}
}

var lthdHideAjaxLoading = function () {
	$("#divAjaxLoadingPage").remove();
	$("#divAjaxLoadingPage").css({ "display": "none" });
}