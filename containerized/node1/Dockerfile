FROM microsoft/dotnet:2.0-sdk

COPY node1.conf /opt
COPY bin/Debug/netcoreapp2.0/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "node1.dll", "node1.conf"] 
