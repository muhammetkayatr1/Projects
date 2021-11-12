"use strict";




// Class Definition
var KTLogin = function () {
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

    var _login;

    var _showForm = function(form) {
        var cls = 'login-' + form + '-on';
        var form = 'kt_login_' + form + '_form';

        _login.removeClass('login-forgot-on');
        _login.removeClass('login-signin-on');
        _login.removeClass('login-signup-on');

        _login.addClass(cls);

        KTUtil.animateClass(KTUtil.getById(form), 'animate__animated animate__backInUp');
    }

  //  var _handleSignInForm = function() {
  //      var validation;


  //      var tcKontrolValidator = function () {
  //          return {
  //              validate: function (input) {
  //                  var value = input.value;

  //                  if (value.length != 11) {
  //                      return {
  //                          valid: false,
  //                          message: 'Kimlik no 11 haneden az veya fazla olamaz.'
  //                      };
  //                  }

  //                  if (value === '') {
  //                      return {
  //                          valid: false,
  //                          message: 'Kimlik numarası boş olamaz.'
  //                      };
  //                  }
  //                  if (!TCnoKontrol(value)) {
  //                      console.log(value)
  //                      return {
  //                          valid: false,
  //                          message: 'Kimlik Numarası hatalı.'

  //                      };
  //                  }
  //                  if (TCnoKontrol(value)) {
  //                      console.log(value)
  //                      return {
  //                          valid: true,
  //                      };
  //                  }
  //                  return {
  //                      valid: true,
  //                  };
  //              }
  //          }
  //      }

  //      // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
  //      validation = FormValidation.formValidation(
		//	KTUtil.getById('kt_login_signin_form'),
  //          {
  //              fields: {

  //                  password: {
  //                      validators: {
  //                          notEmpty: {
  //                              message: 'Şifre Zorunlu'
  //                          }
  //                      }

  //                  },
  //                  plugins: {
  //                      trigger: new FormValidation.plugins.Trigger(),
  //                      submitButton: new FormValidation.plugins.SubmitButton(),
  //                      defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
  //                      bootstrap: new FormValidation.plugins.Bootstrap()
  //                  }
  //              }
  //          }
		//);

  //      $('#kt_login_signin_submit').on('click', function (e) {
  //          e.preventDefault();

  //          validation.validate().then(function(status) {
		//        if (status == 'Valid') {
  //                  swal.fire({
		//                text: "Formunuz eksiksiz doldurdunuz.",
		//                icon: "Başarılı",
		//                buttonsStyling: false,
		//                confirmButtonText: "Devam et",
  //                      customClass: {
  //  						confirmButton: "btn font-weight-bold btn-light-primary"
  //  					}
		//            }).then(function() {
		//				KTUtil.scrollTop();
		//			});
		//		} else {
		//			swal.fire({
		//                text: "Üzgünüm, bazı hatalar ile karşılaştık, lütfen tekrar deneyiniz.",
		//                icon: "error",
		//                buttonsStyling: false,
		//                confirmButtonText: "Tamam",
  //                      customClass: {
  //  						confirmButton: "btn font-weight-bold btn-light-primary"
  //  					}
		//            }).then(function() {
		//				KTUtil.scrollTop();
		//			});
		//		}
		//    });
  //      });

  //      // Handle forgot button
  //      $('#kt_login_forgot').on('click', function (e) {
  //          e.preventDefault();
  //          _showForm('forgot');
  //      });

  //      // Handle signup
  //      $('#kt_login_signup').on('click', function (e) {
  //          e.preventDefault();
  //          _showForm('signup');
  //      });
  //  }

    var _handleSignUpForm = function(e) {
		var validation;     
        var form = KTUtil.getById('kt_login_signup_form');

        FormValidation.validators.checkidentityNumber = tcKontrolValidator;
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
			form,
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
					fullname: {
						validators: {
							notEmpty: {
								message: 'İsim Zorunlu'
							}
						}
					},
                    Email: {
                        validators: {
                            notEmpty: {
                                message: 'Email boş olamaz.'
                            },
                            emailAddress: {
                                message: 'Geçerli bir mail adresi yazınız.'
                            }
                        }
                    },
                    PhoneNumber: {
                        validators: {
                            notEmpty: {
                                message: 'Telefon bilgisi boş olamaz'
                            },
                            phone: {
                                country: 'TR',
                                message: 'Lütfen geçerli bir telefon numarası yazınız.'
                            },
                            regexp: {
                                flag: 'g',
                                regexp: /^(05\d{2}\d{3}\d{2}\d{2})$/i,
                                message: 'Telefon numarası uygun formatta değil. Uygun format : 05551234567',
                            }
                        }
                    },
                    Password: {
                        validators: {
                            notEmpty: {
                                message: 'Şifre Zorunludur'
                            }
                        }
                    },
               
                    Kvkk: {
                        validators: {
                            notEmpty: {
                                message: 'KVKK onayı vermelisiniz.'
                            }
                        }
                    },
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    defaultSubmit: new FormValidation.plugins.DefaultSubmit()
				}
			}
		);

        $('#kt_login_signup_submit').on('click', function (e) {
            _formEl.submit();

        });

        // Handle cancel button
        $('#kt_login_signup_cancel').on('click', function (e) {
            e.preventDefault();

            _showForm('signin');
        });

        $('#kt_login_signup_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function(status) {
		        if (status == 'Valid') {
                    swal.fire({
		                text: "Formunuz eksiksiz doldurdunuz.",
		                icon: "Başarılı",
		                buttonsStyling: false,
		                confirmButtonText: "Devam et",
                        customClass: {
    						confirmButton: "btn font-weight-bold btn-light-primary"
    					}
		            }).then(function() {
						KTUtil.scrollTop();
					});
				} else {
					swal.fire({
		                text: "Üzgünüm, bazı hatalar ile karşılaştık, lütfen tekrar deneyiniz.",
		                icon: "error",
		                buttonsStyling: false,
		                confirmButtonText: "Tamam",
                        customClass: {
    						confirmButton: "btn font-weight-bold btn-light-primary"
    					}
		            }).then(function() {
						KTUtil.scrollTop();
					});
				}
		    });
        });




    }

  //  var _handleForgotForm = function(e) {
  //      var validation;

  //      // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
  //      validation = FormValidation.formValidation(
		//	KTUtil.getById('kt_login_forgot_form'),
		//	{
		//		fields: {
		//			email: {
		//				validators: {
		//					notEmpty: {
		//						message: 'Email address is required'
		//					},
  //                          emailAddress: {
		//						message: 'The value is not a valid email address'
		//					}
		//				}
		//			}
		//		},
		//		plugins: {
		//			trigger: new FormValidation.plugins.Trigger(),
		//			bootstrap: new FormValidation.plugins.Bootstrap()
		//		}
		//	}
		//);

  //      // Handle submit button
  //      $('#kt_login_forgot_submit').on('click', function (e) {
  //          e.preventDefault();

  //          validation.validate().then(function(status) {
		//        if (status == 'Valid') {
  //                  // Submit form
  //                  KTUtil.scrollTop();
		//		} else {
		//			swal.fire({
		//                text: "Sorry, looks like there are some errors detected, please try again.",
		//                icon: "error",
		//                buttonsStyling: false,
		//                confirmButtonText: "Ok, got it!",
  //                      customClass: {
  //  						confirmButton: "btn font-weight-bold btn-light-primary"
  //  					}
		//            }).then(function() {
		//				KTUtil.scrollTop();
		//			});
		//		}
		//    });
  //      });

  //      // Handle cancel button
  //      $('#kt_login_forgot_cancel').on('click', function (e) {
  //          e.preventDefault();

  //          _showForm('signin');
  //      });
  //  }

    // Public Functions
    return {
        // public functions
        init: function() {
            _login = $('#kt_login');

      /* _handleSignInForm();*/
            _handleSignUpForm();
          /*  _handleForgotForm();*/
        }
    };
}();

// Class Initialization
jQuery(document).ready(function() {
    KTLogin.init();
});
