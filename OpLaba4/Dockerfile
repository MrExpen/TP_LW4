﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OpLaba4/OpLaba4.csproj", "OpLaba4/"]
RUN dotnet restore "OpLaba4/OpLaba4.csproj"
COPY . .
WORKDIR "/src/OpLaba4"
RUN dotnet build "OpLaba4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpLaba4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpLaba4.dll"]
