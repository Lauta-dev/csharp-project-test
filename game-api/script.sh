#!/bin/bash

echo "-----------------------------------------"
echo "> 0: Crea una nueva migración e base de datos"
echo "> 1: Actualiza la base de datos existente"
echo "> 2: Realiza una migración"
echo "> 3: Eliminar la base de datos"
echo "-----------------------------------------"

read -r opt

update_db ()
{
  clear
  echo "-----------------------------------------"
  echo "Actualización de la base de datos"
  echo "> dotnet ef database update"
  echo "-----------------------------------------"


  dotnet ef database update # Crea la base de datos
}

create_migration()
{
  clear
  echo "Nombre de la migración:"
  read -r migration_name
  echo "-----------------------------------------"
  echo "Proceso de migración"
  echo "> dotnet ef migration add $migration_name"
  echo "-----------------------------------------"

  dotnet ef migrations add $migration_name # Crea una migración
}

drop_db()
{
  clear
  echo "-----------------------------------------"
  echo "Proceso para eliminar la base de dato"
  echo "> dotnet ef database drop"
  echo "-----------------------------------------"

  echo "# Esta seguro de esto? y/n"
  
  read -r confirm

  if [[ $confirm == "y" ]]; then
    dotnet ef database drop -f --no-build
  fi
}

migration_and_db_creation ()
{
  create_migration
  update_db
}

case $opt in
  0) migration_and_db_creation
  ;;
  1) update_db
  ;;
  2) create_migration
  ;;
  3) drop_db
  ;;
  *) "Desconocido"
  ;;
esac

