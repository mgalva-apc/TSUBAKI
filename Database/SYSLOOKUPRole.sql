CREATE TABLE [dbo].[SYSLOOKUPRole](
[LOOKUPRoleID] [int] IDENTITY(1,1) NOT NULL,
[RoleName] [varchar](100) DEFAULT '',
[RoleDescription] [varchar](500) DEFAULT '',
[RowCreatedSYSUserID] [int] NOT NULL,
[RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
[RowModifiedSYSUserID] [int] NOT NULL,
[RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
PRIMARY KEY (LOOKUPRoleID)
)
GO

INSERT INTO LOOKUPRole
(RoleName,RoleDescription,RowCreatedSYSUserID,RowModifiedSYSUserID)
VALUES ('Staff','Can Edit, Update, Delete',1,1)
INSERT INTO LOOKUPRole
(RoleName,RoleDescription,RowCreatedSYSUserID,RowModifiedSYSUserID)
VALUES ('Client','Read only',1,1)
