# Game Store API

## Starting SQL Server
- https://hub.docker.com/_/microsoft-mssql-server
- https://medium.com/@tarikkaan1koc/apple-m1de-sql-server-nas%C4%B1l-kurulur-ac64f400c485
```terminal
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=112233" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/azure-sql-edge

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Pass@word12" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string to secret manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=sa; Password=$sa_password;TrustServerCertificate=True;"
```