FROM microsoft/dotnet:2.0-sdk

COPY node3.conf /opt
COPY bin/Debug/netcoreapp2.0/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "node3.dll", "node3.conf"] 
