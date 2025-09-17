function showSection(id) {
  // hide all sections
  document.querySelectorAll("section").forEach(section => {
    section.classList.remove("active");
  });

  // show the chosen one
  document.getElementById(id).classList.add("active");
}

document.addEventListener("DOMContentLoaded", () => {
  showSection("settings");
});

document.addEventListener("DOMContentLoaded", () => {
  // handle dropdowns (supports multiple)
  document.querySelectorAll(".dropdown").forEach(drop => {
    const btn = drop.querySelector(".dropbtn");
    const menu = drop.querySelector(".dropdown-content");

    // toggle open/close
    btn.addEventListener("click", (e) => {
      e.stopPropagation(); // don't let document click immediately close it
      drop.classList.toggle("active");
    });

    btn.addEventListener("mouseenter", () => {
      drop.classList.add("active");
    });

    // close when mouse leaves the whole dropdown
    drop.addEventListener("mouseleave", () => {
      drop.classList.remove("active");
    });

    // handle clicks inside menu links (prevent page jump and close dropdown)
    menu.querySelectorAll("a").forEach(link => {
        link.addEventListener("click", (e) => {
            drop.classList.remove("active");

            // only prevent default if href is "#" or empty
            if (link.getAttribute("href") === "#" || !link.getAttribute("href")) {
            e.preventDefault();
            }

            e.stopPropagation();  // prevent the document click from immediately closing
        });
    });
});


  // close any open dropdown when clicking outside
document.addEventListener("click", () => {
    document.querySelectorAll(".dropdown.active").forEach(d => d.classList.remove("active"));
  });
});

document.getElementById("chatInput").addEventListener("keydown", (e) => {
  if (e.key === "Enter") {
    sendMessage()
  }
});

document.getElementById("ipInput").addEventListener("keydown", (e) => {
  if (e.key === "Enter") {
    connect(document.getElementById("ipInput").value);
  }
});