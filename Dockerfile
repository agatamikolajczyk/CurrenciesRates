FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Move source files to /src folder
COPY ./src /src

# Build the release executable
WORKDIR /src
COPY . .
WORKDIR /src/CurrenciesRates.Api
RUN dotnet publish "CurrenciesRates.Api.csproj" -c Release -o /out

# Release image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
#Set Environment
ARG ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ENVIRONMENT
ENV ASPNETCORE_URLS=http://*:80

# Copy binaries from build-env /out to app folder (/app)
COPY --from=build-env /out /app
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
WORKDIR /app

EXPOSE 80
ENTRYPOINT ["dotnet", "CurrenciesRates.Api.dll"]

