FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TP_LW5/TP_LW5.csproj", "TP_LW5/"]
RUN dotnet restore "TP_LW5/TP_LW5.csproj"
COPY . .
WORKDIR "/src/TP_LW5"
RUN dotnet build "TP_LW5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TP_LW5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TP_LW5.dll"]
