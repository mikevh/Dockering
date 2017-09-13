FROM microsoft/aspnetcore-build:2 as build
WORKDIR /src
COPY Dockering.Web.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -o /publish

FROM microsoft/aspnetcore:2
WORKDIR /publish
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Dockering.Web.dll"]
