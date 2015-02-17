USE [Trader]
GO

/****** Object:  StoredProcedure [dbo].[GetAdvertUrl]    Script Date: 05/16/2012 15:23:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAdvertUrl]
@AdvertId int  = 0
AS
BEGIN
  SET NOCOUNT ON;
  IF @AdvertId != 0
  BEGIN
     select kontakt from allads with(nolock) where id = @AdvertId
  END
END

GO