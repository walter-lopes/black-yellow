FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app


COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT Development
WORKDIR /app
CMD ls
COPY --from=build-env  /app/out/ .

ENTRYPOINT ["dotnet", "BlackYellow.CustomerManagementAPI.dll"]