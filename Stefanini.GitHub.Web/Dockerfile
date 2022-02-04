#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Stefanini.GitHub.Web/Stefanini.GitHub.Web.csproj", "Stefanini.GitHub.Web/"]
RUN dotnet restore "Stefanini.GitHub.Web/Stefanini.GitHub.Web.csproj"
COPY . .
WORKDIR "/src/Stefanini.GitHub.Web"
RUN dotnet build "Stefanini.GitHub.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stefanini.GitHub.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stefanini.GitHub.Web.dll"]