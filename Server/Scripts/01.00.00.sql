/*  
Create Sms table
*/

CREATE TABLE [dbo].[TresSms](
	[SmsId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[PhoneNbr] [nvarchar](9) NOT NULL,
	[Message] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_TresSms] PRIMARY KEY CLUSTERED 
  (
	[SmsId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[TresSms]  WITH CHECK ADD  CONSTRAINT [FK_TresSms_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO