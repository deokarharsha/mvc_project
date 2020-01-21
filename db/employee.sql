SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[crud_employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[address] [varchar](255) NULL,
	[department] [varchar](25) NULL,
	[city] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--_____________________________________________________________________________________________ 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[crud_empInfo](
	[empID] [int] NOT NULL,
	[name] [varchar](100) NOT NULL,
	[basic] [int] NULL,
	[hra] [numeric](9, 2) NULL,
	[td] [numeric](9, 2) NULL,
	[da] [numeric](9, 2) NULL,
	[salary] [numeric](9, 2) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[crud_empInfo]  WITH CHECK ADD FOREIGN KEY([empID])
REFERENCES [dbo].[crud_employee] ([ID])
GO

--_____________________________________________________________________________________________________

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[crud_getEmployees]
  
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM crud_employee

END 
GO
--_____________________________________________________________________________________________________
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCrud_Employees]
    @action             VARCHAR(10),
	@ID                 INT NULL, 
	@name               VARCHAR(100) NULL,
	@address            VARCHAR(255) NULL,
	@department         VARCHAR(25) NULL,
	@city               VARCHAR(100) NULL,
	@basic              [numeric](9, 2) NULL,
	@hra                [numeric](9, 2) NULL,
	@td                 [numeric](9, 2) NUll,
	@da                 [numeric](9, 2) NULL,
	@salary             [numeric](9, 2) NULL
	
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @newID int; 
	IF @action = 'add'
        BEGIN
            INSERT INTO crud_employee
            (
                [name],
                [address],
                department,
                city
            )
            values
            (
                @name,
                @address,
                @department,
                @city
            )
        SET @newID = SCOPE_IDENTITY()
        INSERT INTO crud_empInfo
            (
                empID,
                [name],
                [basic],
                hra,
                td,
                da,
                salary
            )
            values
            (
                @newID,
                @name,
                @basic,
                @hra,
                @td,
                @da,
                @salary
            )
        END
	
	ELSE IF @action = 'edit' 
		UPDATE crud_empInfo
		SET
	        [basic]         =   @basic,
            hra             =   @hra,    
            td              =   @td,
            da              =   @da,
            salary          =   @salary
		WHERE 
			empID = @ID; 
    ELSE IF @action = 'delete' 
        BEGIN
             DELETE 
                FROM 
                    crud_empInfo 
                WHERE 
                    empID = @ID
            
            DELETE 
                FROM 
                    crud_employee 
                WHERE 
                    ID = @ID;
        END
    ELSE
        SELECT 
                * 
            FROM 
                crud_employee e
            LEFT JOIN
                crud_empInfo ei 
                on ei.empID = e.ID
END 
GO
