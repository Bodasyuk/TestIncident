# TestIncident
SQL Server - PostgreSQL.
https://jasonwatmore.com/post/2021/10/21/net-5-connect-to-sql-server-with-entity-framework-core change that if you want to use MSSQL.
And go to DataAccess/Repositories/IncedentsDBContext.cs and change uuid_generate_v4() to newid()
