# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the solution and project files
COPY ["../DAL.sln", "DAL.sln"]
COPY ["../PL/PL.csproj", "PL/"]
COPY ["../BLL/BLL.csproj", "BLL/"]
COPY ["../DTO/DTO.csproj", "DTO/"]
COPY ["../DAL/DAL.csproj", "DAL/"]

# Restore dependencies
RUN dotnet restore "DAL.sln"

# Copy the entire project and build it
COPY .. .
WORKDIR "/src/PL"
RUN dotnet build "PL.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PL.csproj" -c Release -o /app/publish

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PL.dll"]
