
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY . ./
RUN dotnet restore SeleniumTests
ARG MF_HOST
ENV MF_HOST=${MF_HOST}
ARG MP_HOST
ENV MP_HOST=${MP_HOST}

WORKDIR /src/SeleniumTests
#RUN dotnet test --filter Type=IntegrationTest --no-restore