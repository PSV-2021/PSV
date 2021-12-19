FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY Hospital/*.csproj ./Hospital/
COPY HospitalAPI/HospitalAPI/HospitalAPI.sln ./HospitalAPI/HospitalAPI/
COPY HospitalAPI/HospitalAPI/HospitalAPI/*.csproj ./HospitalAPI/HospitalAPI/HospitalAPI/
COPY HospitalAPI/HospitalAPI/HospitalApiTests/*.csproj ./HospitalAPI/HospitalAPI/HospitalApiTests/

RUN dotnet restore HospitalAPI/HospitalAPI
COPY . ./

WORKDIR /src/Hospital
RUN dotnet build -c Release -o /app

WORKDIR /src/HospitalAPI/HospitalAPI
RUN dotnet build -c Release -o /app

FROM build-env as Publish
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet","HospitalAPI.dll" ]


##/src{
# Hospital
# HospitalAPI
#       HospitalAPI
#           HospitalAPI.sln
#           HospitalAPI    
#               HospitalAPI.csproj
#           HospitalAPITests
#               HospitalAPiTests.csproj
#
