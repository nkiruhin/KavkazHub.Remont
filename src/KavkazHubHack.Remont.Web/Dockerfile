#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/KavkazHubHack.Remont.Web/KavkazHub.Remont.Web.csproj", "src/KavkazHubHack.Remont.Web/"]
COPY ["src/KavkazHub.Remont.Core/KavkazHub.Remont.Core.csproj", "src/KavkazHub.Remont.Core/"]
COPY ["src/KavkazHub.Remont.ML/KavkazHub.Remont.ML.csproj", "src/KavkazHub.Remont.ML/"]
RUN dotnet restore "src/KavkazHubHack.Remont.Web/KavkazHub.Remont.Web.csproj"
COPY . .
WORKDIR "/src/src/KavkazHubHack.Remont.Web"
RUN dotnet build "KavkazHub.Remont.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KavkazHub.Remont.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KavkazHub.Remont.Web.dll"]