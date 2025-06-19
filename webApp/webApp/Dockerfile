# Usa la imagen oficial de SDK de .NET 8.0 para compilacion
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Está configurando el directorio de trabajo dentro del contenedor. Esto significa que cualquier comando que se ejecute 
# después de este punto, se ejecutará dentro del directorio /source, como por ejemplo copy o run.
WORKDIR /source 

# Copia el archivo del proyecto (.csproj) que se encuentra en la raiz, y el pegado lo hara sobre la carpeta /sources 
# (directorio de trabajo de docker)
COPY *.csproj .
# Una vez copiada la data del .csproj este comando se encarga de instalar las dependencias (paquetes NuGet) del proyecto
RUN dotnet restore

# Este comando copia todos los archivos y carpetas desde el contexto de construcción (es decir, el directorio donde ejecutas 
# docker build) al directorio de trabajo dentro del contenedor (que configuraste previamente como /source)
# La sintaxis COPY . . significa "copiar todo desde el directorio actual del host al directorio de trabajo actual del contenedor".
COPY . .
# Esta linea manda a compilar y publicar la aplicacion en el directorio de trabajo de docker
RUN dotnet publish -c Release -o /app/publish

# Usa la imagen oficial de ASP.NET 8.0 para runtime y configuro el directorio de trabajo
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
# Copio los archivos del SDK ya compilados para poder usarlos en la ejecucion de la app
COPY --from=build /app/publish .

# Expone el puerto 80
EXPOSE 80

# Configura el punto de entrada para ejecutar la aplicacion
ENTRYPOINT ["dotnet", "webApp.dll"]
