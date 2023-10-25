CREATE TABLE [dbo].[SYSClient](
[CLI_ID] [int] IDENTITY(1,1) NOT NULL,
[ACC_ID] [int] FOREIGN KEY REFERENCES SYSAccount(ACC_ID) NOT NULL,
[CLI_FirstName] [varchar](50) NOT NULL,
[CLI_LastName] [varchar](50) NOT NULL,
[CLI_Address] [varchar](255) NOT NULL,
[CLI_Gender] [char](1) NOT NULL,
[CLI_ConNum] [char](12) NOT NULL,
[CLI_Birth] [date] NOT NULL,
[CLI_CreateDate] [datetime] DEFAULT GETDATE(),
[CLI_ModDate] [datetime] DEFAULT GETDATE(),
PRIMARY KEY (CLI_ID)
)
GO
