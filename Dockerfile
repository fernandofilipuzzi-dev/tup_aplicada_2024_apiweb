# etapa: construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# directorio de trabajo
WORKDIR /src

# copiando archivos 
COPY webapi/webapiNetCore.csproj ./webapi/
COPY webapi/webapiNetCore/. ./webapi/

# restaurando dependencias
RUN dotnet restore ./webapi/webapi/webapiNetCore.csproj

# compilando
RUN dotnet build ./webapi/webapiNetCore.csproj -c Release -o /app/build

# publicando
RUN dotnet publish ./webapi/webapi.csproj -c Release -o /app/publish

# etapa: ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# directorio de trabajo del contenedor
WORKDIR /app

# copiando los archivos a publicar
COPY --from=build /app/publish .

# exponiendo el puerto 8080 para acceder - activar el public en forwader port
EXPOSE 8080

# punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "webapi.dll"]
