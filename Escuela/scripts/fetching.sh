#!/bin/bash

port=5000
baseURL="http://localhost:$port"
headers="Content-Type: application/json"
user_agent="Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36"
my_json="$(bun run ./changeIdInStudents.ts "ecf9f4c5-ce98-4e28-bf39-890d1ff83e22" ) "

#-------------------------------#

# post_data: Envía una solicitud HTTP POST a una URL con los datos especificados.
#
# Uso:
#   post_data <método> <cuerpo> <URL>
#
# Parámetros:
#   cuerpo: Los datos que se enviarán en el cuerpo de la solicitud.
#   URL: La URL a la que se enviará la solicitud.
#
# Dependencias:
#   curl: Esta función depende de la herramienta curl para enviar solicitudes HTTP.
#
# Ejemplo:
#   post_data '{"nombre": "Ejemplo", "edad": 30}' "https://ejemplo.com/api"
#
# Retorna:
#   La respuesta del servidor HTTP.
post_data() {
  curl -i -Ss -X "POST" \
    -A "$user_agent" \
    -H "$headers" \
    -d "$1" \
    --compressed \
    "$2"
}

# get_data: Realiza una solicitud HTTP GET a una URL y muestra la respuesta en formato JSON.
#
# Uso:
#   get_data <URL>
#
# Parámetros:
#   URL: La URL desde la cual se obtendrá la información.
#
# Dependencias:
#   curl: Esta función depende de la herramienta curl para realizar solicitudes HTTP.
#   jq: Esta función utiliza jq para formatear la respuesta en formato JSON.
#
# Ejemplo:
#   get_data "https://ejemplo.com/api/data"
#
# Retorna:
#   La respuesta del servidor HTTP en formato JSON.
get_data() {
  # TODO: Verificar que el servidor me devuelve un JSON e darle formato con 'jq', en caso contrario nada

  curl -Ss -X "GET" \
    -A "$user_agent" \
    --compressed \
    "$1"
}

#----------------  Aulas (Classrooms)  ----------------#

#get_data "$baseURL/classroom"
#post_data "$(cat ./classrooms.json)" "$baseURL/classroom/new"

#----------------  Alumnos (Students)  ----------------#

#get_data "$baseURL/students"
post_data "$my_json" "$baseURL/students/add"

#----------------  Tareas (Tasks)  ----------------#

#get_data "$baseURL/task"
#post_data "$(cat ./tasks.json)" "$baseURL/task/new"

#----------------  Profesores (Teachers)  ----------------#

#get_data "$baseURL/profe"
#post_data "$(cat ./teacher.json)" "$baseURL/profe/new"

#---------------------------------------------------------#
