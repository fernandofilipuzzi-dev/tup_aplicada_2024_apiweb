# Usa una imagen base de Windows con .NET Framework y SDK
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

# Establece el directorio de trabajo
WORKDIR /src

# Copia el archivo de solución y el proyecto
COPY webapi/webapi.csproj ./webapi/
COPY webapi/. ./webapi/

# Restaura las dependencias
RUN nuget restore ./webapi/webapi.csproj

# Compila el proyecto
RUN msbuild ./webapi/webapi.sln /p:Configuration=Release /p:Platform="Any CPU"

# Usa una imagen base de Windows con IIS para la ejecución
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019

# Establece el directorio de trabajo en IIS
WORKDIR /inetpub/wwwroot

# Copia los archivos de la aplicación desde la etapa de compilación
COPY --from=build /src/webapi/bin/Release/ .

# Expone el puerto 80 para acceder a la API Web
EXPOSE 80

# Inicia IIS para servir la API
ENTRYPOINT ["cmd.exe", "/c", "C:\\ServiceMonitor.exe w3svc"]
