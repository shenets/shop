USE [CMS]
GO

/****** Object:  Table [dbo].[ShopProduct]    Script Date: 04/11/2017 13:00:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ShopProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShopId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [text] NOT NULL,
 CONSTRAINT [PK_ShopProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ShopProduct]  WITH CHECK ADD  CONSTRAINT [Reference_ShopProduct_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[ShopProduct] CHECK CONSTRAINT [Reference_ShopProduct_ProductId]
GO

ALTER TABLE [dbo].[ShopProduct]  WITH CHECK ADD  CONSTRAINT [Reference_ShopProduct_ShopId] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO

ALTER TABLE [dbo].[ShopProduct] CHECK CONSTRAINT [Reference_ShopProduct_ShopId]
GO


