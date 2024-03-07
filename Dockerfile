# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia los archivos csproj y restaura las dependencias
COPY *.sln .
COPY Models/*.csproj Models/
COPY Business/*.csproj Business/
COPY Data/*.csproj Data/
COPY Api/*.csproj Api/
RUN dotnet restore

# Copia el resto de los archivos y construye la aplicación
COPY . .
WORKDIR /src/Api
RUN dotnet publish -c Release -o /app/out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "UrbanTheater.Api.dll"]
