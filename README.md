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

### Create table for users: Users, add sample data

```sh

USE [TODO]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Username] [varchar](15) NOT NULL,
	[Pwd] [varchar](25) NOT NULL,
	[userRole] [varchar](25) NOT NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


### Get connection string to database using this query, place output string in web.config, it is the last element there.

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

## NOTES

Has reference to Microsoft.Office.Interop.Outlook for reminders.
Remove reference and comment out 

```sh
Remind.ReminderExample(todoid, startdate)
```
from default.aspx.cs (~line 129) if you do not want to use Outlook reminders


