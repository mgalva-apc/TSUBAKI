CREATE TABLE [dbo].[SYSSchedule](
	[Sched_ID] [int] IDENTITY(1,1) NOT NULL,
	[Notif_ID] [int] FOREIGN KEY REFERENCES SYSNotification(Notif_ID) NOT NULL,
	[ACC_ID] [int] FOREIGN KEY REFERENCES SYSAccount(ACC_ID) NOT NULL,
	[ClientUsername] [varchar](50) NOT NULL,
	[Sched_Date] date NOT NULL,
	[Sched_Time] [varchar](20) NOT NULL,
	[Sched_CreateDate] [datetime] DEFAULT GETDATE(),
	[Sched_ModDate] [datetime] DEFAULT GETDATE(),
	PRIMARY KEY (ACC_ID))
GO