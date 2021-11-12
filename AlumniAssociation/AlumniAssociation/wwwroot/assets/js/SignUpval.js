
var inputIdentityNumber = document.querySelector("[name*='identityNumber']");
inputIdentityNumber.addEventListener('keyup', function (event) {
    if (event.which != 8 && event.which != 0 && event.which < 48 || event.which > 57) {
        this.value = this.value.replace(/\D{0,11}/g, "");
    };

});


function TCnoKontrol(tcno) {
    var tek = 0,
        cift = 0,
        sonuc = 0,
        TcToplam = 0,
        i = 0;
    //if (TCNO.length != 11) return false;   
    if (isNaN(tcno)) return false;
    if (tcno[0] == 0) return false;

    tek = parseInt(tcno[0]) + parseInt(tcno[2]) + parseInt(tcno[4]) + parseInt(tcno[6]) + parseInt(tcno[8]);
    cift = parseInt(tcno[1]) + parseInt(tcno[3]) + parseInt(tcno[5]) + parseInt(tcno[7]);


    tek = tek * 7;
    sonuc = Math.abs(tek - cift);
    if (sonuc % 10 != tcno[9]) return false;


    for (var i = 0; i < 10; i++) {
        TcToplam += parseInt(tcno[i]);
    }


    if (TcToplam % 10 != tcno[10]) return false;


    return true;

}


var tcKontrolValidator = function () {
    return {
        validate: function (input) {
            var value = input.value;

            if (value.length != 11) {
                return {
                    valid: false,
                    message: 'Kimlik no 11 haneden az veya fazla olamaz.'
                };
            }

            if (value === '') {
                return {
                    valid: false,
                    message: 'Kimlik numarası boş olamaz.'
                };
            }
            if (!TCnoKontrol(value)) {
                console.log(value)
                return {
                    valid: false,
                    message: 'Kimlik Numarası hatalı.'

                };
            }
            if (TCnoKontrol(value)) {
                console.log(value)
                return {
                    valid: true,
                };
            }
            return {
                valid: true,
            };
        }
    }
}





var KTFormValidation = function () {

    var _initWidgets = function () {

        FormValidation.validators.checkidentityNumber = tcKontrolValidator;
        FormValidation.formValidation(
            document.getElementById('kt_login_signin_form'),
            {
                localization: FormValidation.locales.tr_TR,
                fields: {
                    identityNumber: {
                        validators: {
                            notEmpty: {
                                message: ' T.C. Kimlik numarası boş olamaz.'
                            },
                            checkidentityNumber: {
                                message: 'Lütfen geçerli bir kimlik numarası giriniz.'
                            }
                        }
                    },
                    email: {
                        validators: {
                            notEmpty: {
                                message: 'Email boş olamaz.'
                            },
                            emailAddress: {
                                message: 'Geçerli bir mail adresi yazınız.'
                            }
                        }
                    },
                    phone: {
                        validators: {
                            notEmpty: {
                                message: 'Telefon bilgisi boş olamaz'
                            },
                            phone: {
                                country: 'TR',
                                message: 'Lütfen geçerli bir telefon numarası yazınız.'
                            },
                            regexp: {
                                flag: g,
                                regexp: /^5(0[5-7]|[3-5]\d) ?\d{3} ?\d{4}$/i,
                                message: 'Lütfen başında 0 olmadan ve arada boşluk olmadan telefon numaranızı giriniz.',
                            }
                        }
                    },
                 

                },

                plugins: { //Learn more: https://formvalidation.io/guide/plugins
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap(),
                    // Validate fields when clicking the Submit button
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    // Submit the form when all fields are valid
                    defaultSubmit: new FormValidation.plugins.DefaultSubmit(),

                }
            }
        ); //.registerValidator('checkidentityNumber', tcKontrolValidator)
    }

    return {
        init: function () {
            _initWidgets();
        }
    }
}();



jQuery(document).ready(function () {
    KTFormValidation.init();
});