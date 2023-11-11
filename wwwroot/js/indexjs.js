var container = document.getElementById("slideshow-container"); 
var slides = container.getElementsByClassName("index-slide");

function showSlides(s, i) {
    s[i].style.opacity = "1"; 

    if (i == 0) { 
        s[s.length-1].style.opacity = "0";
    } else {
        s[i-1].style.opacity = "0";
    }

    i++;
    if (i >= s.length) { 
        i = 0; 
    }
    setTimeout(function () { showSlides(s, i) }, 5000);
}

//flashingtext
var container2 = document.getElementById("flashingtext"); 
var slides2 = container2.getElementsByClassName("randmes");

function showSlides2(s, i) {
    s[i].style.opacity = "1"; 

    if (i == 0) { 
        s[s.length-1].style.opacity = "0";
    } else {
        s[i-1].style.opacity = "0";
    }

    i++;
    if (i >= s.length) { //LESSON 9.3 - COMPARISONS//
        i = 0; //LESSON 5.2 - ASSINGMENTS//
    }
    setTimeout(function () { showSlides2(s, i) }, 5000);
}

showSlides(slides, 0);
showSlides2(slides2, 0);
