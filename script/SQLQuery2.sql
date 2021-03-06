USE [master]
GO
/****** Object:  Database [TestGissa]    Script Date: 10/08/2021 10:55:11 ******/
CREATE DATABASE [TestGissa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestGissa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.JOEL\MSSQL\DATA\TestGissa.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestGissa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.JOEL\MSSQL\DATA\TestGissa_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestGissa] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestGissa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestGissa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestGissa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestGissa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestGissa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestGissa] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestGissa] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TestGissa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestGissa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestGissa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestGissa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestGissa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestGissa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestGissa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestGissa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestGissa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestGissa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestGissa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestGissa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestGissa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestGissa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestGissa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestGissa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestGissa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestGissa] SET  MULTI_USER 
GO
ALTER DATABASE [TestGissa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestGissa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestGissa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestGissa] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TestGissa] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TestGissa]
GO
/****** Object:  UserDefinedTableType [dbo].[test_type_phones]    Script Date: 10/08/2021 10:55:12 ******/
CREATE TYPE [dbo].[test_type_phones] AS TABLE(
	[phoneId] [int] NULL,
	[phoneNumber] [int] NULL,
	[userId] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[test_type_user_skills]    Script Date: 10/08/2021 10:55:12 ******/
CREATE TYPE [dbo].[test_type_user_skills] AS TABLE(
	[userSkillId] [int] NULL,
	[userId] [int] NULL,
	[sofSkillId] [int] NULL
)
GO
/****** Object:  Table [dbo].[test_phone]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_phone](
	[phoneId] [int] IDENTITY(1,1) NOT NULL,
	[phoneNumber] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [IX_test_phone] UNIQUE NONCLUSTERED 
(
	[phoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[phoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[test_soft_skill]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_soft_skill](
	[softSkillId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](25) NOT NULL,
 CONSTRAINT [PK_test_soft_skill] PRIMARY KEY CLUSTERED 
(
	[softSkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[test_user]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_user](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nchar](50) NOT NULL,
	[cardId] [int] NOT NULL,
	[username] [nchar](10) NOT NULL,
	[password] [nchar](100) NOT NULL,
	[email] [nchar](60) NOT NULL,
	[typeID] [int] NOT NULL,
	[rol] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_test_user] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_TestUser] UNIQUE NONCLUSTERED 
(
	[username] ASC,
	[cardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[test_user_skill]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_user_skill](
	[userSkillId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[sofSkillId] [int] NOT NULL,
 CONSTRAINT [PK_test_user_skill] PRIMARY KEY CLUSTERED 
(
	[userSkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[test_user_view]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[test_user_view]
as
	SELECT tUser.userId, tUser.fullName, tUser.cardId, tUser.username, tUser.rol, tUser.typeID,tPhone.phoneId, tPhone.phoneNumber, tSoftSkill.softSkillId,tSoftSkill.name  FROM test_user_skill tSkill
	INNER JOIN test_user tUser on tSkill.userId = tUser.userId
	INNER JOIN test_soft_skill tSoftSkill on tSkill.sofSkillId = tSoftSkill.softSkillId
	INNER JOIN test_phone tPhone on tUser.userId = tPhone.userId
	WHERE tUser.isActive = 1

GO
ALTER TABLE [dbo].[test_phone]  WITH CHECK ADD  CONSTRAINT [FK_test_phone_test_user] FOREIGN KEY([userId])
REFERENCES [dbo].[test_user] ([userId])
GO
ALTER TABLE [dbo].[test_phone] CHECK CONSTRAINT [FK_test_phone_test_user]
GO
ALTER TABLE [dbo].[test_user_skill]  WITH CHECK ADD  CONSTRAINT [FK_test_user_skill_test_soft_skill] FOREIGN KEY([sofSkillId])
REFERENCES [dbo].[test_soft_skill] ([softSkillId])
GO
ALTER TABLE [dbo].[test_user_skill] CHECK CONSTRAINT [FK_test_user_skill_test_soft_skill]
GO
ALTER TABLE [dbo].[test_user_skill]  WITH CHECK ADD  CONSTRAINT [FK_test_user_skill_test_user] FOREIGN KEY([userId])
REFERENCES [dbo].[test_user] ([userId])
GO
ALTER TABLE [dbo].[test_user_skill] CHECK CONSTRAINT [FK_test_user_skill_test_user]
GO
/****** Object:  StoredProcedure [dbo].[test_user_delete]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[test_user_delete](
	@UserId int
)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	UPDATE test_user SET isActive = 0 WHERE userId = @UserId;
	commit transaction
	END TRY
	BEGIN CATCH
		ROLLBACK
		RAISERROR (N'ha ocurrido al intentar ingresar los datos %s %d.', -- Message text.  
           10,
           1 
		   )
	END CATCH

END


GO
/****** Object:  StoredProcedure [dbo].[test_user_register]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[test_user_register](
	@Fullname nchar(50) ,
	@CardId int ,
	@Username nchar(10),
	@Password nchar(100),
	@Email nchar(60),
	@Rol int,
	@TypeID int,
	@Phones test_type_phones readonly,
	@UserSkills test_type_user_skills readonly
)
AS
	
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @Id int;
	
	INSERT INTO test_user VALUES(@Fullname,@CardId,@Username,@Password,@Email,@TypeID,@Rol,1);
	set @Id = @@IDENTITY;

	INSERT INTO test_phone(phoneNumber, userId)
		SELECT phoneNumber, @Id  FROM @Phones

	INSERT INTO test_user_skill(userId,sofSkillId)
		SELECT @Id, sofSkillId FROM @UserSkills
	commit transaction
	END TRY
	BEGIN CATCH
		ROLLBACK
		RAISERROR (N'ha ocurrido al intentar ingresar los datos %s %d.',
           10,
           1 
		   )
	END CATCH

END





GO
/****** Object:  StoredProcedure [dbo].[test_user_update]    Script Date: 10/08/2021 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[test_user_update](
	@UserId int,
	@Fullname nchar(50),
	@CardId int,
	@Username nchar(10),
	@Password nchar(100),
	@Email nchar(60),
	@Phones test_type_phones readonly,
	@Rol int,
	@TypeID int,
	@IsActive bit,
	@UserSkills test_type_user_skills readonly
)
AS
	
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	
	UPDATE test_user SET fullName=@Fullname,cardId=@CardId,
		username=@Username,password=@Password,email=@Email,typeID=@TypeID,rol=@Rol,isActive=@IsActive
		WHERE userId = @userId;

	DELETE FROM test_phone WHERE userId = @UserId;
	INSERT INTO test_phone(phoneNumber, userId)
					SELECT phoneNumber, @UserId  FROM @Phones

	DELETE FROM test_user_skill WHERE userId = @UserId;
	INSERT INTO test_user_skill(userId,sofSkillId)
				SELECT @UserId, sofSkillId FROM @UserSkills

		commit transaction
	END TRY
	BEGIN CATCH
		ROLLBACK
		RAISERROR (N'ha ocurrido al intentar ingresar los datos %s %d.',
           10,   
           1 
		   )
	END CATCH

END



GO
USE [master]
GO
ALTER DATABASE [TestGissa] SET  READ_WRITE 
GO
