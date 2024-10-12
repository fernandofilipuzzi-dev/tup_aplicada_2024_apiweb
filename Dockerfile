# Usa una imagen base de Windows con IIS y .NET Framework
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019

# Establece el directorio de trabajo en IIS
WORKDIR /inetpub/wwwroot

# Copia los archivos de la API Web a la carpeta del servidor IIS
COPY ./publicado/ .

# Expone el puerto 80 para acceder a la API Web
EXPOSE 80

# Inicia IIS para servir la API
ENTRYPOINT ["cmd.exe", "/c", "C:\\ServiceMonitor.exe w3svc"]
