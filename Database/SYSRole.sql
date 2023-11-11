CREATE TABLE [dbo].[SYSRole](
[SYSUserRoleID] [int] IDENTITY(1,1) NOT NULL,
[ACC_ID] [int] NOT NULL,
[LOOKUPRoleID] [int] NOT NULL,
[IsActive] [bit] DEFAULT (1),
[RowCreatedSYSUserID] [int] NOT NULL,
[RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
[RowModifiedSYSUserID] [int] NOT NULL,
[RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
PRIMARY KEY (SYSUserRoleID)
)
GO
ALTER TABLE [dbo].[SYSRole] WITH CHECK ADD FOREIGN KEY([LOOKUPRoleID])
REFERENCES [dbo].[SYSLOOKUPRole] ([LOOKUPRoleID])
GO
ALTER TABLE [dbo].[SYSUserRole] WITH CHECK ADD FOREIGN KEY([ACC_ID])
REFERENCES [dbo].[SYSAccount] ([ACC_ID])
GO
