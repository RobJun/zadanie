FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app


COPY ./ ./
RUN dotnet restore --disable-parallel

RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
RUN ls
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "backend.dll"]