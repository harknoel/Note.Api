FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 80
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Note.Api/Note.Api.csproj", "src/Note.Api/"]
RUN dotnet restore "src/Note.Api/Note.Api.csproj" 

WORKDIR "/src/src/Note.Api"
COPY src/Note.Api .

RUN dotnet build "Note.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Note.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish/ -p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Note.Api.dll" ]