'use strict';






// Class definition
var  KTDualListbox = function () {
    // Private functions
     var AdayTercihler = function () {
        // Dual Listbox
        var _this = document.getElementById('listbox_Tercihler');

        // init dual listbox
        var dualListBox = new DualListbox(_this, {
            addEvent: function (value) {
                console.log("eklenen", value);
              
            },
            removeEvent: function (value) {
                console.log("silinen",value);
            },
            availableTitle: "Seçenekler",
            selectedTitle: "Tercihlerim",
            addButtonText: "<i class='flaticon2-next'></i>",
            removeButtonText: "<i class='flaticon2-back'></i>",
            addAllButtonText: "<i class='flaticon2-fast-next'></i>",
            removeAllButtonText: "<i class='flaticon2-fast-back'></i>"
        });
         dualListBox.search.classList.add('dual-listbox__search--hidden');






    };

    return {
        // public functions
        init: function () {
            AdayTercihler();
        },
    };
}();

window.addEventListener('load', function () {
    KTDualListbox.init();
 
});
