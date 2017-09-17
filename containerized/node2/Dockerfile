FROM microsoft/dotnet:2.0-sdk

COPY node2.conf /opt
COPY bin/Debug/netcoreapp2.0/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "node2.dll", "node2.conf"] 
