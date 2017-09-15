FROM microsoft/dotnet:2-sdk
WORKDIR /integration

COPY Dockering.IntegrationTests.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build

ENTRYPOINT ["dotnet", "test"]
