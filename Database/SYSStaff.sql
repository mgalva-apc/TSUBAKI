CREATE TABLE [dbo].[SYSStaff](
[STAFF_ID] [int] IDENTITY(1,1) NOT NULL,
[ACC_ID] [int] FOREIGN KEY REFERENCES SYSAccount(ACC_ID) NOT NULL,
[STAFF_FirstName] [varchar](50) NOT NULL,
[STAFF_LastName] [varchar](50) NOT NULL,
[STAFF_Role] [varchar](15) NOT NULL,
[STAFF_Gender] [varchar](15) NOT NULL,
[STAFF_ConNum] [char](12) NOT NULL,
[STAFF_Birth] [date] NOT NULL,
[STAFF_CreateDate] [datetime] DEFAULT GETDATE(),
[STAFF_ModDate] [datetime] DEFAULT GETDATE(),
PRIMARY KEY (STAFF_ID)
)
GO
