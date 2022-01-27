FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY . ./
RUN dotnet restore IntegrationSeleniumTests
ARG MF_HOST
ENV MF_HOST=${MF_HOST}

WORKDIR /src/IntegrationSeleniumTests
#RUN dotnet test --filter Type=IntegrationTest --no-restore

