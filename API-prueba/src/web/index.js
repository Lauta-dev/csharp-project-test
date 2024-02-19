const listUser = document.getElementById("list_users");
const msg = document.getElementById("msg");

async function loadUsers() {
	try {
		const f = await fetch("http://localhost:5073/users/");
		const json = await f.json();

		let html = "";

		json.forEach((data) => (html += `<li>${data.id} - ${data.name}</li>`));

		listUser.innerHTML += html;
	} catch (error) {
		const h3 = "<h3 style='color: red;'>Error al cargar el recurso</h3>";
		msg.innerHTML = `${h3}\n\n${error}`;
	}
}

loadUsers();
