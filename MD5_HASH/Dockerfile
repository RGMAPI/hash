#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MD5_HASH/MD5_HASH.csproj", "MD5_HASH/"]
RUN dotnet restore "MD5_HASH/MD5_HASH.csproj"
COPY . .
WORKDIR "/src/MD5_HASH"
RUN dotnet build "MD5_HASH.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MD5_HASH.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MD5_HASH.dll"]