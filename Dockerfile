FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy necessary files and restore as distinct layer
COPY ["Cars.csproj","Cars/"]
RUN dotnet restore "Cars/Cars.csproj" -s https://api.nuget.org/v3/index.json 

# Copy everything else and build
COPY . ./
WORKDIR "/app/Cars"
RUN dotnet publish "Cars.csproj" -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env "/app/Cars/out" .

# Expose ports
EXPOSE 80/tcp


# Start
ENTRYPOINT ["dotnet", "Cars.dll"]
