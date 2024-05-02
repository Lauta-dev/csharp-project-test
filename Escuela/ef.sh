#!/bin/bash

create_migration() {
  echo "CREANDO MIGRACIÓN..."
  dotnet ef migrations add "$1"
  echo "MIGRACIÓN CREADA."
}

update_db() {
  echo "Actualizando Base de datos"
  dotnet ef database update
  echo "Base de datos actualizada"
}

create_migration_and_update_db() {
  create_migration $1
  update_db
}

_help() {
  echo " AYUDA OwO
    -m o --migration [nombre] 'Crear migración'
    -udb o --update-db 'Actualizar la base de datos'
    -mu o --migration-update [nombre] 'Crear migración y actualizar la base de datos'
  "
}

case $1 in
  "-h") _help
  ;;
  "--help") _help
  ;;
  "-m") create_migration $2 
  ;;
  "--migration") create_migration $2 
  ;;
  "-udb") update_db 
  ;;
  "--update-db") update_db 
  ;;
  "-mu") create_migration_and_update_db $2 
  ;;
  "--migration-update") create_migration_and_update_db $2
  ;;
  *)
   _help
  ;;
esac
