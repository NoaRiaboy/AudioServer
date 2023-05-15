# Use the official .NET SDK image as the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory to /AudioServer
WORKDIR /AudioServer

# Copy the project file into the container
COPY *.csproj .

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code into the container
COPY . .

# Build the application
RUN dotnet build -c Release -o /app

# Publish the application
RUN dotnet publish -c Release -o /AudioServer

# Use the official .NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory to /app
WORKDIR /AudioServer

# Copy the application files from the build image
COPY --from=build /AudioServer .

# Expose port 7019
EXPOSE 7019

# Start the application
ENTRYPOINT ["dotnet", "AudioServer.dll"]
