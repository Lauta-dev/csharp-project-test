const getElementById = (id) => document.getElementById(id);
const querySelector = (id) => document.querySelector(id);

const app = getElementById("blogs");
const seeFechError = getElementById("see-fetch-error");
const form = querySelector("form");
const seedBlog = getElementById("send-blog");
const dialog = getElementById("dialog");
const post = getElementById("posts");

const urls = {
	local: "http://localhost:5027",
	prod: "", // TODO: Poner aqui la URL de production
};

const baseUrl = urls.local;

function notify(body) {
	const notify = document.getElementById("notify");
	const baseHtml = `<h2>Notificación</h2>`;
	notify.innerHTML += baseHtml;

	notify.innerHTML += body;
	setTimeout(() => (notify.innerHTML = ""), 6000);
}
