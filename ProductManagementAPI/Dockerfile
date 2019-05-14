FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# copy everything and build the project

COPY . ./
RUN dotnet restore ProductManagementAPI.csproj
RUN dotnet publish ProductManagementAPI.csproj -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime
ENV ASPNETCORE_URLS=http://+:5001
WORKDIR /app
COPY --from=build-env /app/ProductManagementAPI/out ./


ENTRYPOINT ["dotnet", "BlackYellow.ProductManagementAPI.dll"]