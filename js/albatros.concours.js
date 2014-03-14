function ConcoursService($, settings, mid) {
 var moduleId = mid;
 var distancesServicepath = $.dnnSF(moduleId).getServiceRoot('Albatros/Concours') + 'Distances/';

 this.listSites = function (startString, success) {
  $.ajax({
   type: "GET",
   url: distancesServicepath + "ListSites",
   beforeSend: $.dnnSF(moduleId).setModuleHeaders,
   data: { StartString: startString }
  }).done(function (data) {
   if (success != undefined) {
    success(data);
   }
  }).fail(function (xhr, status) {
   displayMessage(settings.errorBoxId, settings.serverErrorWithDescription + eval("(" + xhr.responseText + ")").ExceptionMessage, "dnnFormWarning");
  });
 };

 this.myFlights = function (aoData, success) {
  $.ajax({
   type: "GET",
   url: distancesServicepath + "MyFlights",
   beforeSend: $.dnnSF(moduleId).setModuleHeaders,
   data: aoData
  }).done(function (data) {
   if (success != undefined) {
    success(data);
   }
  }).fail(function (xhr, status) {
   displayMessage(settings.errorBoxId, settings.serverErrorWithDescription + eval("(" + xhr.responseText + ")").ExceptionMessage, "dnnFormWarning");
  });
 };

 this.getValidatedFlights = function (aoData, success) {
  $.ajax({
   type: "GET",
   url: distancesServicepath + "GetValidatedFlights",
   beforeSend: $.dnnSF(moduleId).setModuleHeaders,
   data: aoData
  }).done(function (data) {
   if (success != undefined) {
    success(data);
   }
  }).fail(function (xhr, status) {
   displayMessage(settings.errorBoxId, settings.serverErrorWithDescription + eval("(" + xhr.responseText + ")").ExceptionMessage, "dnnFormWarning");
  });
 };

 this.getNonValidatedFlights = function (aoData, success) {
  $.ajax({
   type: "GET",
   url: distancesServicepath + "GetNonValidatedFlights",
   beforeSend: $.dnnSF(moduleId).setModuleHeaders,
   data: aoData
  }).done(function (data) {
   if (success != undefined) {
    success(data);
   }
  }).fail(function (xhr, status) {
   displayMessage(settings.errorBoxId, settings.serverErrorWithDescription + eval("(" + xhr.responseText + ")").ExceptionMessage, "dnnFormWarning");
  });
 };

 function displayMessage(msgBoxId, message, cssclass) {
  var messageNode = $("<div/>")
                .addClass('dnnFormMessage ' + cssclass)
                .text(message);
  $(msgBoxId).prepend(messageNode);
  messageNode.fadeOut(3000, 'easeInExpo', function () {
   messageNode.remove();
  });
 };
};
