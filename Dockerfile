#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Budget.Service.Api/Budget.Service.Api.csproj", "Budget.Service.Api/"]
RUN dotnet restore "Budget.Service.Api/Budget.Service.Api.csproj"
COPY . .
WORKDIR "/src/Budget.Service.Api"
RUN dotnet build "Budget.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Budget.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Budget.Service.Api.dll"]