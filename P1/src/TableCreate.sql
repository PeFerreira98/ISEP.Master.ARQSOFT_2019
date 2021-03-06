/****** Object:  Table [dbo].[Meal]    Script Date: 08/11/2019 17:20:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Meal](
	[MealID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NOT NULL,
	[Suffix] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MealID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MealItem](
	[MealItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductionDate] [datetime2](7) NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
	[AvailableStatus] [bit] NOT NULL,
	[MealIdentificationNumber] [nvarchar](50) NOT NULL,
	[MealID] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MealItemID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MealItem]  WITH CHECK ADD  CONSTRAINT [FK_Meal_MealItem] FOREIGN KEY([MealID])
REFERENCES [dbo].[Meal] ([MealID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MealItem] CHECK CONSTRAINT [FK_Meal_MealItem]
GO


