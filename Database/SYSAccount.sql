CREATE TABLE [dbo].[SYSAccount](
[ACC_ID] [int] IDENTITY(1,1) NOT NULL,
[ACC_Username] [varchar](50) NOT NULL,
[ACC_Password] [varchar](255) NOT NULL,
[Salt] [varchar](128) NOT NULL,
[ACC_Type] [varchar](10) NOT NULL,
[ACC_Email] [varchar](150) NOT NULL,
[ACC_Image] [varchar](MAX) NULL,
[ACC_CreateDate] [datetime] DEFAULT GETDATE(),
[ACC_ModDate] [datetime] DEFAULT GETDATE(),
PRIMARY KEY (ACC_ID)
)
GO
