const progress = document.getElementById("progress");
const circles = document.querySelectorAll(".circle");
const prev = document.getElementById("prev");
const next = document.getElementById("next");

// the number of active circles as a flag, initially only circle No.1 is active
let currentActive = 1;

function updateStyle() {
  // circles style
  circles.forEach((circle, index) => {
    // for example, if currentActive=2, it means that only index=0&1 can be activated.
    // currentActive=4, index=0,1,2,3 are active
    if (index < currentActive) {
      circle.classList.add("active");
    } else {
      // for example, if currentActive minus to 3, it means that index=3 need to remove the 'active' class
      // currentActive=2, index=2,3 need to remove the 'active' class. currentActive=1, index=1,2,3 need to remove the 'active' class
      circle.classList.remove("active");
    }
  });

  // progress bar style
  progress.style.width =
    ((currentActive - 1) / (circles.length - 1)) * 100 + "%"; // Current number of segments divided by total number of segments, x/3

  //buttons style
  // when currentActive=1,prev btn is disabled. When currentActive=4, next btn is disabled
  if (currentActive == 1) {
    prev.disabled = true;
  } else if (currentActive == circles.length) {
    next.disabled = true;
  } else {
    prev.disabled = false;
    next.disabled = false;
  }
}

next.addEventListener("click", () => {
  currentActive++;
  if (currentActive > circles.length) {
    currentActive = circles.length;
  }
  updateStyle();
});

prev.addEventListener("click", () => {
  currentActive--;
  if (currentActive < 1) {
    currentActive = 1;
  }
  updateStyle();
});
