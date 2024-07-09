# Login
### Use sa, sa to login.

# Setup


### We need a table to store data and a connection string to it.
### Create TODO table, database name is also TODO 

```sh
USE [TODO]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Todo](
	[todoid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[details] [varchar](5000) NULL,
	[dodate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[todoid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

### Get connection string to database using this query, place output string in default.aspx.cs line 24 (string cs)

```sh
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()
```

## NOTE

Comment line 
```sh
Remind.ReminderExample(todoid, startdate)
```
from default.aspx.cs (~line 129) if you do not want to use Outlook reminders