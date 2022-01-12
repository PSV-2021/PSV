FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY ./IntegrationAPI/*.sln /src/IntegrationAPI/
COPY ./IntegrationAPI/*.csproj /src/IntegrationAPI/
COPY ./Integration/*.csproj /src/Integration/
COPY ./IntegrationApiTests/*.csproj /src/IntegrationApiTests/
COPY ./IntegrationSeleniumTests/*.csproj /src/IntegrationSeleniumTests/
RUN dotnet restore ./IntegrationAPI

COPY . ./

ARG DBServer
ENV DBServer=${DBServer}

ARG DBUser
ENV DBUser=${DBUser}

ARG DBPassword=DBPassword
ENV DBPassword=${DBPassword}

ARG DBTest
ENV DBTest=${DBTest}

RUN echo ${DBServer}
WORKDIR /src/IntegrationApiTests
#RUN dotnet test --filter Type=IntegrationTest --no-restore

