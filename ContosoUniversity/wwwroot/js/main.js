document.addEventListener('DOMContentLoaded', init);
//cargar el tema seleccionado actualente
loadTheme();

function init() {
    document.getElementById("theme-btn").addEventListener("click", toggleTheme);
    document.getElementById("config-btn").addEventListener("click", openSideMenu);
    document.querySelector(".side-menu-container").addEventListener("click", closeSideMenu);
    document.querySelector(".side-menu .sm-header .xmark-wrapper").addEventListener("click", closeSideMenu);
    document.querySelector(".side-menu").addEventListener("click", function(e) {e.stopPropagation()});
}

//Carga y aplica el tema guardado en localStorage
function loadTheme() {
    let theme = localStorage.getItem("theme");
    if (theme !== null) {
        const html = document.getElementById("html");
        if (theme == "light") {
            html.classList.remove("dark");
            html.classList.add("light");
        } else {
            html.classList.remove("light");
            html.classList.add("dark");
        }
    }
}

function toggleTheme() {
    const html = document.getElementById("html");
    html.classList.toggle('light');
    html.classList.toggle('dark');

    //Guardar tema actual en localStorage
    if (html.classList.contains("light")) {
        localStorage.setItem("theme", "light");
    } else {
        localStorage.setItem("theme", "dark");
    }
}

function openSideMenu() {
    const body = document.querySelector("body");
    const sideMenu = document.querySelector(".side-menu");
    const container = document.querySelector(".side-menu-container");

    container.style.display = "block";

    setTimeout(function() {
        body.style.overflowY = "hidden";
        sideMenu.classList.remove("close");
        container.classList.remove("close");
    }, 50)
}

function closeSideMenu() {
    const body = document.querySelector("body");
    const sideMenu = document.querySelector(".side-menu");
    const container = document.querySelector(".side-menu-container");

    sideMenu.classList.add("close");
    container.classList.add("close");
    setTimeout(function() {
        container.style.display = "none";
    }, 400)
    body.style.overflowY = "auto";
}