#!/bin/bash

function ayuda() {
  echo "
  --hot
    Cada que cambie el archivo se vuelve a compilar la APP 
    Command: [dotnet watch run]

  --run
    Se ejecua una vez la aplicación
    Command: [dotnet run]
  "
}

case "$1" in
  "--help")
    ayuda
  ;;
  "-h")
    ayuda
  ;;
  "--hot")
    echo "Ejecutando [dotnet watch run]"
    dotnet watch run
  ;;
  "--run")
    echo "Ejecutando [dotnet run]"
    dotnet run
  ;;
  *)
    ayuda
  ;;
esac
