let navMenu = document.querySelector(".nav-menu"),
navItems = navMenu.querySelectorAll(".link-item");

document.addEventListener("click", (event) => {											// Event on Click
	if (event.target.classList.contains('link-item')) {									// if Link Clicked
		if (event.target.hash !== "") {													// href is not empty
			event.preventDefault();														// Prevent Default behavior
			const hash = event.target.hash;												// Get value after #
			
			document.querySelector(".section.active").classList.add("hide");			// Hide active section
			document.querySelector(".section.active").classList.remove("active");		// Deactivate Section
			
			document.querySelector(hash).classList.add("active");						// Activate Section from #
			document.querySelector(hash).classList.remove("hide");						// Show Section from #
			
			navMenu.querySelector(".color").classList.remove("color");					// Remove Color from previous Link

			navItems.forEach((item) => {
				if (hash === item.hash) {
					item.classList.add("color");										// Add color to clicked link
				}
			});
			window.location.hash = hash;												// Add # to 
		}
	}
});