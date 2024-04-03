#!/bin/bash

function ayuda() {
  echo "
  --watch
    Cada que cambie el archivo se vuelve a compilar la APP 
    Comando: dotnet watch run

  --run
    Se ejecua una vez la aplicación
    Comando: dotnet run
  "
}

case "$1" in
  "--help")
    ayuda
  ;;
  "-h")
    ayuda
  ;;
  "--watch")
    dotnet watch run
  ;;
  "--run")
    dotnet run
  ;;
  *)
    ayuda
  ;;
esac
