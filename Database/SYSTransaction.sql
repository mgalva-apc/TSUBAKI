CREATE TABLE [dbo].[SYSTransaction](
	[TRNS_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRNS_Name] [varchar](50) NOT NULL,
	[TRNS_Status] [varchar](50) NOT NULL,
	[TRNS_Type] [varchar](50) NOT NULL,
	[TRNS_StartDate] [datetime] DEFAULT GETDATE() NOT NULL,
	[TRNS_EndDate] [datetime] NOT NULL,
	[STAFF_ID] [int] FOREIGN KEY REFERENCES SYSStaff(STAFF_ID) NOT NULL,
	[CLI_ID] [int] FOREIGN KEY REFERENCES SYSClient(CLI_ID) NOT NULL,
	PRIMARY KEY (TRNS_ID);
GO