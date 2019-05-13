# https://docs.docker.com/engine/examples/dotnetcore/


FROM microsoft/dotnet:sdk AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
run dotnet restore

# copy everything else and build
copy . ./
run dotnet publish -c release -o out

# build runtime image
from microsoft/dotnet:aspnetcore-runtime
workdir /app
expose 80
expose 443
copy --from=build-env /app/out .
entrypoint ["dotnet", "WebCore.API.dll"]
