async function getBlogs() {
	const f = await fetch(`${baseUrl}/blogs`);

	if (!f.ok) {
		notify("<p id='see-fetch-error'>Error al hacer el fetching de datos</p>");
		return;
	}

	const json = await f.json();
	let html = "<ul>";

	json.forEach((x) => (html += `<li>${x.url}</li>`));

	html += "</ul>";
	app.innerHTML = html;
}

async function sendBlog(url) {
	const f = await fetch(`${baseUrl}/blog/create`, {
		method: "POST",
		headers: { "Content-Type": "Application/json" },
		body: JSON.stringify({ url }),
	});

	if (!f.ok) {
		notify("<p id='see-fetch-error'>Error al hacer el fetching de datos</p>");
		return;
	}

	const json = await f.json();
	const message = json.message;
	notify(`<b>${message}</b>`);

	getBlogs();
}

form.addEventListener("submit", (event) => {
	event.preventDefault();
	const { url } = Object.fromEntries(new FormData(event.target));

	if (checkInput(url)) sendBlog(url);

	form.removeEventListener("submit", () => {});
});

getBlogs();
