#!/bin/bash

watch_large="--watch"
watch_less="-w"

run_large="--run"
run_less="-r"

build_large="--build"
build_less="-b"

dotnet_build () {
  dotnet build
}

dotnet_watch () {
  dotnet watch run
}

dotnet_run () {
  dotnet run
}

function show_help() {
  echo "
  $watch_large | $watch_less
    Cada que cambie el archivo se vuelve a compilar la APP 
    Comando: dotnet watch run

  $run_large | $run_less
    Se ejecua una vez la aplicación
    Comando: dotnet run
  
  $build_large | $build_less
    crea un build
  "
}

case "$1" in
  "--help" | "-h")
    show_help
  ;;
  $watch_large | $watch_less)
     dotnet_watch
  ;;
  $run_large | $run_less)
    dotnet_run
  ;;
  $build_large | $build_less)
    dotnet_build
  ;;
  *)
    show_help
  ;;
esac
