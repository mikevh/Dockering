# build
FROM microsoft/aspnetcore-build:2 as build
WORKDIR /dockering

# restore
COPY Dockering.Web/Dockering.Web.csproj ./Dockering.Web/
RUN dotnet restore Dockering.Web/Dockering.Web.csproj
COPY Dockering.Test/Dockering.Test.csproj ./Dockering.Test/
RUN dotnet restore Dockering.Test/Dockering.Test.csproj

# copy src
COPY . .

# test
RUN dotnet test Dockering.Test/Dockering.Test.csproj

# publish
RUN dotnet publish Dockering.Web/Dockering.Web.csproj -o /publish

# runtime
FROM microsoft/aspnetcore:2
WORKDIR /
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Dockering.Web.dll"]
