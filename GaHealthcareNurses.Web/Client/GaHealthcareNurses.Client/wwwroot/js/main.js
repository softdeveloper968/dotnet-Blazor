window.mask = (id,mask, dotnetHelper) => {
    var customMask = IMask(
        document.getElementById(id), {
            mask: mask,
            commit: function (value, masked) {
                dotnetHelper.invokeMethodAsync('returnUnmaskedValue', this.unmaskedValue);                    
            }
    });
};

function abc() {
    $(".tab-content-info .accept_btn").removeClass("activeBtn");
  $(this).addClass("activeBtn");

}

function btnmd() {
    var id = $(".tab-content-info .accept_btn.activeBtn").attr("data-id");
    debugger;
}
