CREATE TABLE [dbo].[UserDetail] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [UserID]       NVARCHAR (450) NULL,
    [FirstName]    NVARCHAR (MAX) NULL,
    [LastName]     NVARCHAR (MAX) NULL,
    [Country]      NVARCHAR (MAX) NULL,
    [City]         NVARCHAR (MAX) NULL,
    [Street]       NVARCHAR (MAX) NULL,
    [StreetNumber] INT            NOT NULL,
    [StreetLetter] NVARCHAR (1)   NULL,
    [ZipCode]      NVARCHAR (MAX) NULL,
    [PhoneNumber]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserDetail] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_UserDetail_User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserDetail_UserID]
    ON [dbo].[UserDetail]([UserID] ASC) WHERE ([UserID] IS NOT NULL);

