#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CRUD.UserManagement.API/CRUD.UserManagment.API.csproj", "CRUD.UserManagement.API/"]
COPY ["CRUD.UserManagement.Services/CRUD.UserManagement.Services.csproj", "CRUD.UserManagement.Services/"]
COPY ["CRUD.UserManagement.Domain/CRUD.UserManagement.Domain.csproj", "CRUD.UserManagement.Domain/"]
COPY ["CRUD.UserManagement.Infrastructure/CRUD.UserManagment.Infrastructure.csproj", "CRUD.UserManagement.Infrastructure/"]
RUN dotnet restore "CRUD.UserManagement.API/CRUD.UserManagment.API.csproj"
COPY . .
WORKDIR "/src/CRUD.UserManagement.API"
RUN dotnet build "CRUD.UserManagment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CRUD.UserManagment.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRUD.UserManagment.API.dll"]