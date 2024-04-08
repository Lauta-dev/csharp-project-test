import json from "./students.json"

// Este sera el parametro que se pasa desde la terminal
let arg: string = process.argv[2]
const randomYears: number[] = [2003, 2000, 1998, 1980, 2005, 2010, 2004]
let d: typeof json = []

for (let i = 0; i < json.length; i++) {
  const data = json[i]
  data.fechaDeNacimiento = new Date(randomYears[i].toString()).toISOString(),
  data.age = (new Date().getUTCFullYear() - randomYears[i]).toString()
  data.ClassroomsId = arg ?? crypto.randomUUID()

  d.push({
    ...data
  })

}

console.log(JSON.stringify(d))

