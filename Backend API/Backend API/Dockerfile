# Use the official .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore any dependencies (via 'dotnet restore')
COPY ["Backend API/Backend API.csproj", "Backend API/"]
RUN dotnet restore "Backend API/Backend API.csproj"

# Copy the rest of the code
COPY . .

# Build the application
WORKDIR "/src/Backend API"
RUN dotnet build "Backend API.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "Backend API.csproj" -c Release -o /app/publish

# Use the official .NET 8 runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 80

# Set the entry point to run the app
ENTRYPOINT ["dotnet", "Backend API.dll"]
