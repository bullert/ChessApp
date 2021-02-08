CREATE DATABASE ChessApp
GO
USE ChessApp
GO
CREATE TABLE dbo.Users (
	ID int IDENTITY(1,1) NOT NULL,
    Username varchar(20) NOT NULL,
    Password varchar(64) NOT NULL,
	IsOnline bit NOT NULL,
       	CONSTRAINT PK_Users_ID PRIMARY KEY (ID)
)
GO
CREATE TABLE dbo.Rooms (
    ID int IDENTITY(1,1) NOT NULL,
        CONSTRAINT PK_Rooms_ID PRIMARY KEY (ID)
)
GO
CREATE TABLE dbo.RoomsUsers (
    RoomID int NOT NULL,
    UserID int NOT NULL,
	    CONSTRAINT FK_RoomsUsers_RoomID FOREIGN KEY (RoomID)
            REFERENCES dbo.Rooms (ID),
	    CONSTRAINT FK_RoomsUsers_UserID FOREIGN KEY (UserID)
            REFERENCES dbo.Users (ID)
)
GO

insert into Rooms default values;
GO
insert into Rooms default values;
GO
insert into Rooms default values;
GO