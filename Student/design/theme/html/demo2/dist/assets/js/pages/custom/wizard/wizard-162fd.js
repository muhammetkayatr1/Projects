"use strict";
var KTWizard1 = (function () {
    var t,
        e,
        i,
        s = [];
    return {
        init: function () {
            (t = KTUtil.getById("kt_wizard")),
                (e = KTUtil.getById("kt_form")),
                s.push(
                    FormValidation.formValidation(e, {
                        fields: {
                            country: { validators: { notEmpty: { message: "Bu alan zorunludur!" } } },
                        },
                        plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap({ eleValidClass: "" }) },
                    })
                ),
                s.push(
                    FormValidation.formValidation(e, {
                        fields: {
                            package: { validators: { notEmpty: { message: "Package details is required" } } },
                            weight: { validators: { notEmpty: { message: "Package weight is required" }, digits: { message: "The value added is not valid" } } },
                            width: { validators: { notEmpty: { message: "Package width is required" }, digits: { message: "The value added is not valid" } } },
                            height: { validators: { notEmpty: { message: "Package height is required" }, digits: { message: "The value added is not valid" } } },
                            packagelength: { validators: { notEmpty: { message: "Package length is required" }, digits: { message: "The value added is not valid" } } },
                        },
                        plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap({ eleValidClass: "" }) },
                    })
                ),
                s.push(
                    FormValidation.formValidation(e, {
                        fields: {
                            textInfo: { validators: { notEmpty: { message: "Bu alan zorunludur!" } } },
                            radios1: { validators: { notEmpty: { message: "Bu alan zorunludur!" } } },
                            radios2: { validators: { notEmpty: { message: "Bu alan zorunludur!" } } },
                        },
                        plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap({ eleValidClass: "" }) },
                    })
                ),
                s.push(
                    FormValidation.formValidation(e, {
                        fields: {
                            locaddress1: { validators: { notEmpty: { message: "Address is required" } } },
                            locpostcode: { validators: { notEmpty: { message: "Postcode is required" } } },
                            loccity: { validators: { notEmpty: { message: "City is required" } } },
                            locstate: { validators: { notEmpty: { message: "State is required" } } },
                            loccountry: { validators: { notEmpty: { message: "Country is required" } } },
                        },
                        plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap({ eleValidClass: "" }) },
                    })
                ),
                (i = new KTWizard(t, { startStep: 1, clickableSteps: !1 })).on("change", function (t) {
                    if (!(t.getStep() > t.getNewStep())) {
                        var e = s[t.getStep() - 1];
                        return (
                            e &&
                                e.validate().then(function (e) {
                                    "Valid" == e
                                        ? (t.goTo(t.getNewStep()), KTUtil.scrollTop())
                                        : Swal.fire({
                                              text: "Lütfen başvurunuzu kontrol edip tekrar deneyiniz.",
                                              icon: "error",
                                              buttonsStyling: !1,
                                              confirmButtonText: "Tamam",
                                              customClass: { confirmButton: "btn font-weight-bold btn-light" },
                                          }).then(function () {
                                              KTUtil.scrollTop();
                                          });
                                }),
                            !1
                        );
                    }
                }),
                i.on("changed", function (t) {
                    KTUtil.scrollTop();
                }),
                i.on("submit", function (t) {
                    Swal.fire({
                        text: "Girdiğiniz bilgiler ile başvurunuzu onaylıyor musunuz?",
                        icon: "success",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Evet",
                        cancelButtonText: "Hayır",
                        customClass: { confirmButton: "btn font-weight-bold btn-primary", cancelButton: "btn font-weight-bold btn-default" },
                    }).then(function (t) {
                        t.value
                            ? e.submit()
                            : "cancel" === t.dismiss &&
                              Swal.fire({ text: "Başvuru gerçekletirilirken bir hata oluştu!.", icon: "error", buttonsStyling: !1, confirmButtonText: "Tamam!", customClass: { confirmButton: "btn font-weight-bold btn-primary" } });
                    });
                });
        },
    };
})();
jQuery(document).ready(function () {
    KTWizard1.init();
});

/*calendar*/
var KTBootstrapDatepicker = (function () {
    var t;
    t = KTUtil.isRTL() ? { leftArrow: '<i class="la la-angle-right"></i>', rightArrow: '<i class="la la-angle-left"></i>' } : { leftArrow: '<i class="fas fa-angle-left"></i>', rightArrow: '<i class="fas fa-angle-right"></i>' };
    return {
        init: function () {
            $("#kt_datepicker_1, #kt_datepicker_1_validate").datepicker({ rtl: KTUtil.isRTL(), todayHighlight: !0, orientation: "bottom left", templates: t }),
                $("#kt_datepicker_1_modal").datepicker({ rtl: KTUtil.isRTL(), todayHighlight: !0, orientation: "bottom left", templates: t }),
                $("#kt_datepicker_2, #kt_datepicker_2_validate").datepicker({ rtl: KTUtil.isRTL(), todayHighlight: !0, orientation: "bottom left", templates: t }),
                $("#kt_datepicker_2_modal").datepicker({ rtl: KTUtil.isRTL(), todayHighlight: !0, orientation: "bottom left", templates: t }),
                $("#kt_datepicker_3, #kt_datepicker_3_validate").datepicker({ rtl: KTUtil.isRTL(), todayBtn: "linked", clearBtn: !0, todayHighlight: !0, templates: t }),
                $("#kt_datepicker_3_modal").datepicker({ rtl: KTUtil.isRTL(), todayBtn: "linked", clearBtn: !0, todayHighlight: !0, templates: t }),
                $("#kt_datepicker_4_1").datepicker({ rtl: KTUtil.isRTL(), orientation: "top left", todayHighlight: !0, templates: t }),
                $("#kt_datepicker_4_2").datepicker({ rtl: KTUtil.isRTL(), orientation: "top right", todayHighlight: !0, templates: t }),
                $("#kt_datepicker_4_3").datepicker({ rtl: KTUtil.isRTL(), orientation: "bottom left", todayHighlight: !0, templates: t }),
                $("#kt_datepicker_4_4").datepicker({ rtl: KTUtil.isRTL(), orientation: "bottom right", todayHighlight: !0, templates: t }),
                $("#kt_datepicker_5").datepicker({ rtl: KTUtil.isRTL(), todayHighlight: !0, templates: t }),
                $("#kt_datepicker_6").datepicker({ rtl: KTUtil.isRTL(), todayHighlight: !0, templates: t });
        },
    };
})();
jQuery(document).ready(function () {
    KTBootstrapDatepicker.init();
});
