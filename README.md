# TestIncident
SQL Server - PostgreSQL.
https://jasonwatmore.com/post/2021/10/21/net-5-connect-to-sql-server-with-entity-framework-core change that if you want to use MSSQL.
And go to DataAccess/Repositories/IncedentsDBContext.cs change uuid_generate_v4() to newid() in line 20 and uuid to UNIQUEIDENTIFIER in line 19. (change it in all migrations if it's necessary)
