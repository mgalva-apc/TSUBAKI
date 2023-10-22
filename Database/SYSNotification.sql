CREATE TABLE [dbo].[SYSNotification](
[Notif_ID] [int] IDENTITY(1,1) NOT NULL,
[Notif_Content] [varchar](MAX) NOT NULL,
[Notif_SendDate] [datetime] DEFAULT GETDATE(),
[STAFF_ID] [int] FOREIGN KEY REFERENCES SYSStaff(STAFF_ID) NOT NULL,
[STAFF_Email] [varchar](50) FOREIGN KEY REFERENCES SYSStaff(STAFF_Email) NOT NULL,
[CLI_ID] [int] FOREIGN KEY REFERENCES SYSClient(CLI_ID) NOT NULL,
[CLI_Email] [varchar](50) FOREIGN KEY REFERENCES SYSClient(CLI_Email) NOT NULL,
[DOC_ID] [int] FOREIGN KEY REFERENCES SYSDocument(DOC_ID),
[TRNS_ID] [int] FOREIGN KEY REFERENCES SYSTransaction(TRNS_ID) NOT NULL,
PRIMARY KEY (Notif_ID)
)
GO