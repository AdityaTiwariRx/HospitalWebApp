USE [master]
GO
/****** Object:  Database [HospitalDB]    Script Date: 4/28/2020 1:17:01 PM ******/
CREATE DATABASE [HospitalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HospitalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HospitalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HospitalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HospitalDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HospitalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HospitalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HospitalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HospitalDB] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HospitalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HospitalDB] SET QUERY_STORE = OFF
GO
USE [HospitalDB]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](30) NOT NULL,
	[PatientAddress] [varchar](50) NOT NULL,
	[PatientAge] [int] NOT NULL,
	[PatientGender] [varchar](10) NOT NULL,
	[PatientDiseases] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [varchar](30) NOT NULL,
	[DoctorGender] [varchar](10) NOT NULL,
	[DoctorAge] [int] NOT NULL,
	[Qualification] [varchar](50) NOT NULL,
	[Experience] [int] NOT NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vTreat]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vTreat]
AS
SELECT dbo.Doctors.DoctorName, dbo.Patients.PatientName, dbo.Departments.DepartmentName
FROM     dbo.Departments CROSS JOIN
                  dbo.Doctors CROSS JOIN
                  dbo.Patients
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[AppointmentDateTime] [datetime] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assistants]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assistants](
	[AssistantId] [int] IDENTITY(1,1) NOT NULL,
	[AssistantName] [varchar](30) NOT NULL,
	[AssistantGender] [varchar](10) NOT NULL,
	[AssistantAge] [int] NOT NULL,
	[DeptartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Assistants] PRIMARY KEY CLUSTERED 
(
	[AssistantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrugDetails]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugDetails](
	[DrugId] [int] IDENTITY(1,1) NOT NULL,
	[DrugName] [varchar](30) NOT NULL,
	[DrugDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DrugDetails] PRIMARY KEY CLUSTERED 
(
	[DrugId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientDrugDetails]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientDrugDetails](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[MorningDrugId] [int] NOT NULL,
	[AfternoonDrugId] [int] NOT NULL,
	[EveningDrugId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treats]    Script Date: 4/28/2020 1:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treats](
	[TreatmentId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Treats] PRIMARY KEY CLUSTERED 
(
	[TreatmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Doctors]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Patients]
GO
ALTER TABLE [dbo].[Assistants]  WITH CHECK ADD  CONSTRAINT [FK_Assistants_Departments] FOREIGN KEY([DeptartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Assistants] CHECK CONSTRAINT [FK_Assistants_Departments]
GO
ALTER TABLE [dbo].[PatientDrugDetails]  WITH CHECK ADD  CONSTRAINT [FK_PatientDrugDetails_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[PatientDrugDetails] CHECK CONSTRAINT [FK_PatientDrugDetails_Patients]
GO
ALTER TABLE [dbo].[Treats]  WITH CHECK ADD  CONSTRAINT [FK_Treats_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Treats] CHECK CONSTRAINT [FK_Treats_Departments]
GO
ALTER TABLE [dbo].[Treats]  WITH CHECK ADD  CONSTRAINT [FK_Treats_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
GO
ALTER TABLE [dbo].[Treats] CHECK CONSTRAINT [FK_Treats_Doctors]
GO
ALTER TABLE [dbo].[Treats]  WITH CHECK ADD  CONSTRAINT [FK_Treats_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[Treats] CHECK CONSTRAINT [FK_Treats_Patients]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Departments"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 126
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Doctors"
            Begin Extent = 
               Top = 7
               Left = 311
               Bottom = 170
               Right = 505
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patients"
            Begin Extent = 
               Top = 7
               Left = 553
               Bottom = 170
               Right = 751
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreat'
GO
USE [master]
GO
ALTER DATABASE [HospitalDB] SET  READ_WRITE 
GO
