#!/bin/bash


docker stop webapi2

sleep 2

docker rm webapi2

sleep 2

docker rmi webapi2:v2.2

# elimina solo ls imagenes colgantes o dangling- none
docker image prune -f

docker build --no-cache -f Dockerfile.webapiNetCore -t webapi2:v2.2 .
docker run --name webapi2 -p 8080:8080  -d webapi2:v2.2

# para correrla sin compilar
# docker start webapi2