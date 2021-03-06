#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["NumbersWeb/NumbersWeb.csproj", "NumbersWeb/"]
RUN dotnet restore "NumbersWeb/NumbersWeb.csproj"
COPY . .
WORKDIR "/src/NumbersWeb"
RUN dotnet build "NumbersWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NumbersWeb.csproj" -c Release -o /app/publish --runtime linux-musl-x64 -p:PublishTrimmed=true

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./NumbersWeb"]