create database attendance;

use attendance;

CREATE TABLE [Student] (
    [StuId]     INT          NOT NULL,
    [StuName]   VARCHAR (50) NOT NULL,
    [StuRollNo] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([StuId] ASC)
);

CREATE TABLE [Teacher] (
    [TeaId]        INT          NOT NULL,
    [TeaUsername]  VARCHAR (50) NOT NULL,
    [TeaPassword]  VARCHAR (50) NOT NULL,
    [TeaFirstName] VARCHAR (50) NOT NULL,
    [TeaLastName]  VARCHAR (50) NOT NULL,
    [TeaEmail]     VARCHAR (50) NOT NULL,
    [TeaContactNo] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([TeaId] ASC)
);


CREATE TABLE [Course] (
    [CouId]   INT          NOT NULL,
    [CouName] VARCHAR (50) NOT NULL,
    [TeaId]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([CouId] ASC),
    CONSTRAINT [FK_Course_ToTable_Course] FOREIGN KEY ([TeaId]) REFERENCES [dbo].[Teacher] ([TeaId])
);

CREATE TABLE [Attendance] (
    [AttId]       INT NOT NULL,
    [AttPresents] INT NOT NULL,
    [AttAbsents]  INT NOT NULL,
    [StuId]       INT NOT NULL,
    [CouId]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([AttId] ASC),
    CONSTRAINT [FK_Attendance_ToTable_Attendance_1] FOREIGN KEY ([StuId]) REFERENCES [dbo].[Student] ([StuId]),
    CONSTRAINT [FK_Attendance_ToTable_Attendance_2] FOREIGN KEY ([CouId]) REFERENCES [dbo].[Course] ([CouId])
);

CREATE TABLE [AttendanceHistory] (
    [HisId]        INT      NOT NULL,
    [HisDateTime]  DATETIME NOT NULL,
    [HisIsPresent] BIT      NOT NULL,
    [AttId]        INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([HisId] ASC),
    CONSTRAINT [FK_AttendanceHistory_ToTable] FOREIGN KEY ([AttId]) REFERENCES [dbo].[Attendance] ([AttId])
);

GO

INSERT INTO dbo.Student
           ([StuId]
           ,[StuName]
           ,[StuRollNo])
     VALUES
           (1,'Umer','BSEF14M014'),
			(2,	'Awais','BSEF14M002'),
(3,	'Shakeel'	,'BSEF14M003'),
(4,	'Usama',	'BSEF14M004'),
(5,	'Talha',	'BSEF14M005'),
(6,	'Abubaker',	'BSEF14M006')
GO

GO

INSERT INTO [dbo].[Teacher]
           ([TeaId]
           ,[TeaUsername]
           ,[TeaPassword]
           ,[TeaFirstName]
           ,[TeaLastName]
           ,[TeaEmail]
           ,[TeaContactNo])
     VALUES
           (
1	,'ali',	'123',	'Ali'	,'Ahmad',	'123@abc.xyz',	'03213456789')
GO


GO

INSERT INTO [dbo].[Course]
           ([CouId]
           ,[CouName]
           ,[TeaId])
     VALUES
           (1,	'BSEF14M SDA',	1),
(2	,'BSEF13A LA',	1),
(3,	'BCSF15M PF' ,	1)
GO

GO

INSERT INTO [dbo].[Attendance]
           ([AttId]
           ,[AttPresents]
           ,[AttAbsents]
           ,[StuId]
           ,[CouId])
     VALUES
           (1,	5	,1,	1,	1),
(2,	4,	2,	2	,1),
(3,	3	,3	,3	,1),
(4	,5,	1	,4,	1),
(5,	5,	1,	5,	1),
(6,	3	,3,	3,	2)
GO

GO

INSERT INTO [dbo].[AttendanceHistory]
           ([HisId]
           ,[HisDateTime]
           ,[HisIsPresent]
           ,[AttId])
     VALUES
           (1,	'5/6/2017 9:46:34 PM',	'False'	,3),
(2	,'5/6/2017 9:46:08 PM'	,'True',	3),
(3,	'5/6/2017 9:46:08 PM'	,'True',	2),
(4	,'5/6/2017 9:46:08 PM',	'True',	3)
GO