#!/bin/bash

dotnet build --configuration Release --runtime linux-x64
docker build -t app .
docker tag app laut4/app-csharp:ta
docker push laut4/app-csharp:ta

