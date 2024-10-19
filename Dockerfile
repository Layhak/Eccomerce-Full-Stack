FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

ENV DB_HOST=localhost
ENV DB_PORT=5435
ENV DB_NAME=ss20-eccommerce
ENV DB_USERNAME=postgres
ENV DB_PASSWORD=root

EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Eccomerce-Full-Stack.csproj ./
RUN dotnet restore ./webapp.csproj
COPY . .
WORKDIR "/src/."
RUN dotnet build "Eccomerce-Full-Stack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eccomerce-Full-Stack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eccomerce-Full-Stack.dll"]
