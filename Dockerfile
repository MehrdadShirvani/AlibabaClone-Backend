# ------------ Build Stage ------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY AlibabaClone-Backend.sln ./
COPY AlibabaClone.Application/*.csproj ./AlibabaClone.Application/
COPY AlibabaClone.Domain/*.csproj ./AlibabaClone.Domain/
COPY AlibabaClone.Infrastructure/*.csproj ./AlibabaClone.Infrastructure/
COPY AlibabaClone.WebAPI/*.csproj ./AlibabaClone.WebAPI/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code
COPY . .


# Publish the WebAPI project
RUN dotnet publish AlibabaClone.WebAPI/AlibabaClone.WebAPI.csproj -c Release -o /app/publish

# ------------ Runtime Stage ------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Open port 80
EXPOSE 80

ENTRYPOINT ["dotnet", "AlibabaClone.WebAPI.dll"]