
# crea la imagen
#docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=MSS-fernando-sql" -p 1433:1433 --name sql2 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest

# para volverla a correr, usar
docker start sql2
