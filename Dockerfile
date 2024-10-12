# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establece el directorio de trabajo
WORKDIR /src

# Copia el archivo de solución y el proyecto
COPY webapi/webapi.csproj ./webapi/
COPY webapi/. ./webapi/

# Restaura las dependencias
RUN dotnet restore ./webapi/webapi.csproj

# Compila la aplicación
RUN dotnet build ./webapi/webapi.csproj -c Release -o /app/build

# Publica la aplicación
RUN dotnet publish ./webapi/webapi.csproj -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Establece el directorio de trabajo en el contenedor
WORKDIR /app

# Copia los archivos publicados desde la etapa de construcción
COPY --from=build /app/publish .

# Expone el puerto 80 para acceder a la API Web
EXPOSE 80

# Establece el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "webapi.dll"]
