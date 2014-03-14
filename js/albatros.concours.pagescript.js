var concoursService
jQuery(function ($) {
 concoursService = new ConcoursService($, {
   serverErrorText: '[ServerError]',
   serverErrorWithDescriptionText: '[ServerErrorWithDescription]',
   errorBoxId: '#concoursServiceErrorBox[ModuleId]'
  },
  [ModuleId]);
});
