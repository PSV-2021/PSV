FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY Hospital/*.csproj ./Hospital/
COPY HospitalAPI/HospitalAPI/HospitalAPI.sln ./HospitalAPI/HospitalAPI/
COPY HospitalAPI/HospitalAPI/HospitalAPI/*.csproj ./HospitalAPI/HospitalAPI/HospitalAPI/
COPY HospitalAPI/HospitalAPI/HospitalApiTests/*.csproj ./HospitalAPI/HospitalAPI/HospitalApiTests/
COPY HospitalAPI/HospitalAPI/SeleniumTests/*.csproj ./HospitalAPI/HospitalAPI/SeleniumTests/
RUN dotnet restore HospitalAPI/HospitalAPI
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
WORKDIR /src/HospitalAPI/HospitalAPI/HospitalApiTests
#RUN dotnet test --filter Type=IntegrationTest --no-restore