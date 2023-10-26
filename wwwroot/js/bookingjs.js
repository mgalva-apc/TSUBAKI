var responseInputs = document.getElementsByClassName("respinput");
var selectTag = document.getElementById("qs");

function qnafunction() {
    for (var i = 0; i < responseInputs.length; i++) {
        responseInputs[i].style.opacity = "0";
    }
    responseInputs[selectTag.selectedIndex].style.opacity = "1";
}

for (var i = 0; i < responseInputs.length; i++) {
    responseInputs[i].style.opacity = "0";
}
responseInputs[0].style.opacity = "1";

$(document).ready(function () {
    $(".datepicker").datepicker();
});
