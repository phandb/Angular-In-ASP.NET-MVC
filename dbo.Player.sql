CREATE TABLE [dbo].[Player]
(
	[PlayerId] INT NOT NULL PRIMARY KEY, 
    [PlayerName] NVARCHAR(50) NULL, 
    [Club] NVARCHAR(50) NULL, 
    [Position] NVARCHAR(50) NULL, 
    [JoinedClubOn] DATETIME NULL
)
