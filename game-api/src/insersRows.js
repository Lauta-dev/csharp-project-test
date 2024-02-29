const urls = [
	"https://blog.dev/web/frontend/react",
	"https://blog.dev/web/frontend/vuejs",
	"https://blog.dev/web/frontend/angular",
	"https://blog.dev/web/frontend/html",
	"https://blog.dev/web/frontend/css",
	"https://blog.dev/web/frontend/js",
	"https://blog.dev/web/backend/js-nodejs",
	"https://blog.dev/web/backend/node/express",
	"https://blog.dev/web/backend/node/framework/nestjs",
	"https://blog.dev/csharp/dotnet",
	"https://blog.dev/csharp/ef",
	"https://blog.dev/py/web/create-http-server",
];

/*

urls.forEach((url) => {
	const urlToJson = JSON.stringify({ url });

	fetch("http://localhost:5027/blog/create", {
		method: "POST",
		headers: { "Content-Type": "application/json" },
		body: urlToJson,
	});
});

*/

const data = [
	{
		title: "La IA de OpenIA se vuelve loca!",
		content: "Esta IA dio comportamiento inesperados",
	},
	{
		title: "Uso de las pipes (Tuberias) en Linux",
		content:
			"El uso de las pipes (Tuberias) en Linux es muy común. Se puede ver su uso en cat archivo.json | json_pp, cual '|' sería la tuberia. Esta tuberia toma la salida del primer comando y la envia al segundo",
	},
	{
		title: "El framework de NodeJS del futuro",
		content:
			"NestJS es un framework de NodeJS para el BackEnd que usa ExpressJS o Fastify",
	},
	{
		title: "Formatear un archivo JSON usando 'json_pp'",
		content:
			"La herramienta `json_pp` se usa para formatear JSONs, se puede usar de esta forma: `archivo.json | json_pp`",
	},
	{
		title: "La versión del Engine para Nintendo Swith se cancelo",
		content:
			"El 'Engine' de RockStar Games famoso por el GTA VI, GTA V e otros fue cancelado para Nintendo",
	},
	{
		title: "La música LO-FI es linda",
		content: "Esta música esta siendo famosa entre jovenes",
	},
	{
		title: "The Reguetton is a shit",
		content:
			"shit shit shit shit shit shit shit shit shit shit shit shit shit ",
	},
	{
		title: "La mejor versión de Hellsing",
		content: "Es Hellsing Ultime",
	},
	{
		title: "La secuela de Naruto",
		content: "La nueva secuela de Naruto desarrollada por 'Estudio Blazor'",
	},
	{
		title: "Kentaro Miura",
		content: "El dios de Berserk",
	},
];

data.forEach(({ title, content, id }) => {
	const body = JSON.stringify({
		title,
		content,
	});

	fetch("http://localhost:5027/post/create", {
		method: "POST",
		headers: { "Content-Type": "application/json" },
		body,
	});

	console.log(`${title} agregado`);
});
