//open slider menu
function openNav() {
    if (window.innerWidth > 500 && window.innerWidth < 1000) {
        document.getElementById("menu-items").style.width = "250px";
    } else {
        document.getElementById("menu-items").style.width = "unset";
    }
}

//close button for slide menu
function closeNav() {
    document.getElementById("menu-items").style.width = "0";
}

const close = document.getElementById("close");
const open = document.getElementById("menu-button");

close.addEventListener("click", closeNav);
open.addEventListener("click", openNav);

/* toggle Menu */
const menuToggle = document.getElementById("menu-button");
const menuNav = document.getElementById('menu-items');

function toggleMenu() {
    menuNav.classList.toggle("show");
}

menuToggle.addEventListener("click", toggleMenu);

//appending openNav function on load of a window
window.onload = openNav();


var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}
