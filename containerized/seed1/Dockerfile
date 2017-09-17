FROM microsoft/dotnet:2.0-sdk

COPY seed1.conf /opt
COPY bin/Debug/netcoreapp2.0/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "seed1.dll", "seed1.conf"] 
