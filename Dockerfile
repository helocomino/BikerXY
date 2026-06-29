# Estructura para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar los archivos del proyecto y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Estructura final para correr la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Configurar el puerto dinámico para Render
ENV ASPNETCORE_URLS=http://*:$PORT

ENTRYPOINT ["dotnet", "BikerXY.dll"]