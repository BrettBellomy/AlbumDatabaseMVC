// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let slideIndex = 0;
showSlides();

function showSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    slides[slideIndex - 1].style.display = "block";
    setTimeout(showSlides, 4000);
}

function updateConfirmation(e) {
    let confirmation = confirm('Are you sure you want to update this album?');
    if (!confirmation) {
        e.preventDefault();
        return false;
    }
    return true;
};

function deleteConfirmation(e) {
    let confirmation = confirm('Are you sure you want to delete this album?');
    if (!confirmation) {
        e.preventDefault();
        return false;
    }
    return true;
};