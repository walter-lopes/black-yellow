FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# copy everything and build the project

COPY . ./
RUN dotnet restore CustomerManagementAPI/*.csproj
RUN dotnet publish CustomerManagementAPI/*.csproj -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/CustomerManagementAPI/out ./


ENTRYPOINT ["dotnet", "BlackYellow.CustomerManagementAPI.dll"]