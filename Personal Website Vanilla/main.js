var navbar = document.querySelector('.navbar'); //navbar=ul
var links = document.querySelectorAll('.navbar__item');
var menuBtn = document.querySelector('.menu-btn i');

// to add or remove className navbar--active
// navbar is hidden by default in small screen
function menuShow() {
  if (navbar.classList.contains('navbar--active')) {
    navbar.classList.remove('navbar--active');
  } else {
    navbar.classList.add('navbar--active');
  }
}

// to close navbar when any navbar__item was clicked in small screen
links.forEach(function (link) {
  link.addEventListener('click', function () {
    if (navbar.classList.contains('navbar--active')) {
      navbar.classList.remove('navbar--active');
    }
  });
});

// theme switching
var color = 'dark';
function themeSwitch() {
  document.body.classList.toggle(color); //to switch (add or remove) the className when user clicks Theme
  if (document.body.classList.contains(color)) {
    localStorage.setItem('theme', 'dark'); //store the selected theme in localStorage
  } else {
    localStorage.setItem('theme', 'light');
  }
}
// persist the selected theme then add or remove className dark
function loadPage() {
  const storedTheme = localStorage.getItem('theme');
  if (storedTheme === 'dark') {
    document.body.classList.add(color);
  } else {
    document.body.classList.remove(color);
  }
}

// automatically called when the page loads
loadPage();
