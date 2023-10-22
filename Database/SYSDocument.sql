CREATE TABLE [dbo].[SYSDocument](
	[DOCU_ID] [int] IDENTITY(1,1) NOT NULL,
	[DOCU_Name] [varchar](255) NOT NULL,
	[DOCU_Type] [varchar](4) NOT NULL,
	[DOCU_Content] [varchar](MAX) NOT NULL,
	[DOCU_CreateDate] [datetime] DEFAULT GETDATE(),
	[DOCU_ModDate] [datetime] DEFAULT GETDATE(),
	[STAFF_ID] [int] FOREIGN KEY REFERENCES SYSStaff(STAFF_ID) NOT NULL,
	[CLI_ID] [int] FOREIGN KEY REFERENCES SYSClient(CLI_ID) NOT NULL,
	[TRNS_ID] [int] FOREIGN KEY REFERENCES SYSTransaction(TRNS_ID) NOT NULL
	PRIMARY KEY (DOCU_ID)
	)
GO