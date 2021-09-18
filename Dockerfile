FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Cars.csproj",""]
RUN dotnet restore "./Cars.csproj" 
COPY . .
WORKDIR "/src/."
RUN dotnet build "Cars.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cars.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cars.dll"]
