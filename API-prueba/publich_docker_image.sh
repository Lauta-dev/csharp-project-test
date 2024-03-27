#!/bin/bash

echo " " &&
echo "--------------------------------------" &&
echo "--- Compilando proyecto para prod ----" &&
echo "--------------------------------------" &&
echo " " &&

dotnet publish &&

echo " " &&
echo "| -------------------- |" &&
echo "| Construyendo imagen  |" &&
echo "| -------------------- |" &&
echo " " &&

docker build -t api-prueba . &&

echo " " &&
echo "| ---------------- |" &&
echo "| Añadiendo Tag    |" &&
echo "| ---------------- |" &&
echo " " &&

docker tag api-prueba laut4/api-prueba:csharp &&


echo " " &&
echo "| ------------------- |" &&
echo "| Subiendo la Imagen  |" &&
echo "| ------------------- |" &&
echo " " &&


docker push laut4/api-prueba:csharp 

