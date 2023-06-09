function toggleMenu(attribute) {
	try {
		const toggleBtn = document.querySelector(attribute);
		toggleBtn.addEventListener("click", function () {
			const element = document.querySelector(
				toggleBtn.getAttribute("data-target")
			);

			if (!element.classList.contains("open-menu")) {
				element.classList.add("open-menu");
				toggleBtn.classList.add("btn-outline.dark");
				toggleBtn.classList.add("btn-toggle.white");
			} else {
				element.classList.remove("open-menu");
				toggleBtn.classList.remove("btn-outline-dark");
				toggleBtn.classList.remove("btn-toggle-white");
			}
		});
	} catch {}
}
toggleMenu("[data-option-toggle]");
