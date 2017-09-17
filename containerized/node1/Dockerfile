FROM microsoft/dotnet:2.0-sdk

COPY . /opt
WORKDIR /opt

RUN dotnet restore
RUN dotnet build
RUN dotnet publish

ENTRYPOINT ["dotnet", "./bin/Debug/netcoreapp2.0/publish/node1.dll", "node1.conf"] 
