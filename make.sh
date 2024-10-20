docker stop webapi2
docker rm webapi2
docker build --no-cache -f Dockerfile.webapiNetCore -t webapi2:v2.2 .
docker run --name webapi2 -p 8080:8080  -d webapi2:v2.2