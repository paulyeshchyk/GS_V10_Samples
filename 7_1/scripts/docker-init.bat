
docker run --name sql_server_py -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=user123!" -e "MSSQL_PID=Enterprise" -v sqlvolume:/var/opt/mssql -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

docker cp ankara-db-init.sql sql_server_py:/var/opt/mssql

docker exec -it sql_server_py /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P user123! -i /var/opt/mssql/ankara-db-init.sql

cd ..\..\7_1_2
rmdir /s /q Migrations

dotnet ef migrations add Initial
dotnet ef database update