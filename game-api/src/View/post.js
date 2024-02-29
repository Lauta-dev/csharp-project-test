let prevState = [];
let lastTake = 10;
let lastSkip = 5;

function checkInput(input) {
	if (input.length < 1) {
		notify("<b>No se puede enviar vacío el enlace</b>");
		return false;
	}

	return input;
}

async function loadPost({ take = 5, skip = 0 }) {
	const f = await fetch(`${baseUrl}/posts?take=${take}&skip=${skip}`);

	// NOTE: Cuando no hay más registros en la base de datos, la API devuelve un array vacío
	const json = await f.json();
	prevState = prevState.concat(json);

	let html =
		"<ol style='display: flex; flex-direction: column; gap: 1rem; width: 45rem;'>";

	prevState.forEach((x) => {
		const title = x.title;
		const content = x.content.replaceAll("`", "");
		let span = "";

		title.split(" ").find((x) =>
			// TODO: Agregar una forma para que más de un elemento HTML se pinto, por ejemplo con "AI" y "Linux"
			x == "IA" ? (span = `<span style="color: white;">${x}</span>`) : null,
		);

		const newTitle = title.replace("IA", span);

		html += `<li style='padding: 1rem;' id='post-list'>
         <h2>${newTitle}</h2>
          <p>${content}</p>
    </li>`;
	});

	json.length < 1
		? (html += `<li><b>Todos los post cargados</b></li>`)
		: (html += `<li><button id="load-more">Cargar más elementos</button></li>`);

	html += "</ol>";
	post.innerHTML = html;

	const loadMorePosts = () =>
		getElementById("load-more").addEventListener("click", () => {
			loadPost({
				skip: lastSkip,
				take: lastTake,
			});

			lastSkip += 5;
			lastTake += 5;
		});

	json.length < 1 ? null : loadMorePosts();
}

loadPost(5, 0);
