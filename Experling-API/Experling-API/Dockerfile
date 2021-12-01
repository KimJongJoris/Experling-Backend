FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Experling-API/Experling-API.csproj", "Experling-API/"]
RUN dotnet restore "Experling-API/Experling-API.csproj"
COPY . .
WORKDIR "/src/Experling-API"
RUN dotnet build "Experling-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Experling-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Experling-API.dll"]
