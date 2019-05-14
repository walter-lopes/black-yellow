FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# copy everything and build the project

COPY . ./
RUN dotnet restore ShopManagementAPI.csproj
RUN dotnet publish ShopManagementAPI.csproj -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime
ENV ASPNETCORE_URLS=http://+:5002
WORKDIR /app
COPY --from=build-env /app/ShopManagementAPI/out ./


ENTRYPOINT ["dotnet", "BlackYellow.ShopManagementAPI.dll"]