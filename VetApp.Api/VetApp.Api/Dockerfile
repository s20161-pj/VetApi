FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VetApp.Api/VetApp.Api.csproj", "VetApp.Api/"]
RUN dotnet restore "VetApp.Api/VetApp.Api.csproj"
COPY . .
WORKDIR "/src/VetApp.Api"
RUN dotnet build "VetApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VetApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VetApp.Api.dll"]
