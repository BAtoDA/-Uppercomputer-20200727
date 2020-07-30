USE [master]
GO
/****** Object:  Database [Uppercomputer]    Script Date: 2020/9/7 19:51:05 ******/
CREATE DATABASE [Uppercomputer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Uppercomputer', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.WINCC\MSSQL\DATA\Uppercomputer.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Uppercomputer_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.WINCC\MSSQL\DATA\Uppercomputer_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Uppercomputer] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Uppercomputer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Uppercomputer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Uppercomputer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Uppercomputer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Uppercomputer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Uppercomputer] SET ARITHABORT OFF 
GO
ALTER DATABASE [Uppercomputer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Uppercomputer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Uppercomputer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Uppercomputer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Uppercomputer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Uppercomputer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Uppercomputer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Uppercomputer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Uppercomputer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Uppercomputer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Uppercomputer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Uppercomputer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Uppercomputer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Uppercomputer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Uppercomputer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Uppercomputer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Uppercomputer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Uppercomputer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Uppercomputer] SET  MULTI_USER 
GO
ALTER DATABASE [Uppercomputer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Uppercomputer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Uppercomputer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Uppercomputer] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Uppercomputer] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Uppercomputer]
GO
/****** Object:  User [SIMATIC HMI VIEWER User]    Script Date: 2020/9/7 19:51:05 ******/
CREATE USER [SIMATIC HMI VIEWER User] FOR LOGIN [DESKTOP-E3JO5HA\SIMATIC HMI VIEWER]
GO
/****** Object:  User [SIMATIC HMI User]    Script Date: 2020/9/7 19:51:05 ******/
CREATE USER [SIMATIC HMI User] FOR LOGIN [DESKTOP-E3JO5HA\SIMATIC HMI]
GO
/****** Object:  DatabaseRole [SIMATIC HMI VIEWER role]    Script Date: 2020/9/7 19:51:05 ******/
CREATE ROLE [SIMATIC HMI VIEWER role]
GO
/****** Object:  DatabaseRole [SIMATIC HMI role]    Script Date: 2020/9/7 19:51:05 ******/
CREATE ROLE [SIMATIC HMI role]
GO
ALTER ROLE [SIMATIC HMI VIEWER role] ADD MEMBER [SIMATIC HMI VIEWER User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI VIEWER User]
GO
ALTER ROLE [SIMATIC HMI role] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI VIEWER role]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [SIMATIC HMI role]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI role]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [SIMATIC HMI role]
GO
/****** Object:  Table [dbo].[AnalogMeter_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnalogMeter_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[资料格式] [nchar](50) NOT NULL,
	[数据类型] [nchar](50) NOT NULL,
	[小数点以上位数] [nchar](50) NOT NULL,
	[小数点以下位数] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NOT NULL,
	[Min] [int] NOT NULL,
	[Max] [int] NOT NULL,
	[刷新时间] [int] NOT NULL,
 CONSTRAINT [PK_AnalogMeter_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Button_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Button_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[位指示灯] [nchar](10) NOT NULL,
	[位切换开关] [nchar](10) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[操作模式] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NULL,
 CONSTRAINT [PK_Button一般参数] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Control_layer]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Control_layer](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](100) NOT NULL,
	[type] [nchar](100) NOT NULL,
	[Upper_layer] [int] NOT NULL,
 CONSTRAINT [PK_Control_layer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[control-location]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[control-location](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[location] [nchar](50) NOT NULL,
	[size] [nchar](50) NOT NULL,
 CONSTRAINT [PK_control-location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[doughnut_Chart_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doughnut_Chart_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[资料格式] [nchar](50) NOT NULL,
	[数据类型] [nchar](50) NOT NULL,
	[小数点以上位数] [nchar](50) NOT NULL,
	[小数点以下位数] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NOT NULL,
	[通道数量] [int] NOT NULL,
	[Name_Text] [nchar](500) NULL,
 CONSTRAINT [PK_doughnut_Chart_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event_message]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_message](
	[ID] [int] NOT NULL,
	[类型] [int] NOT NULL,
	[设备] [nchar](100) NOT NULL,
	[设备_地址] [nchar](100) NOT NULL,
	[设备_具体地址] [nchar](100) NOT NULL,
	[位触发条件] [nchar](50) NOT NULL,
	[字触发条件] [nchar](50) NOT NULL,
	[字触发条件_具体] [nchar](50) NOT NULL,
	[报警内容] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Event_message] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[General parameters of picture]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[General parameters of picture](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](50) NOT NULL,
	[Control-type] [nchar](50) NOT NULL,
	[Control-state-0] [int] NOT NULL,
	[Control-state-0-list] [int] NOT NULL,
	[Control-state-0-picture] [int] NOT NULL,
	[Control-state-1] [int] NOT NULL,
	[Control-state-1-list] [int] NOT NULL,
	[Control-state-1-picture] [int] NOT NULL,
 CONSTRAINT [PK_General parameters of picture_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupBox_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupBox_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
 CONSTRAINT [PK_GroupBox_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[histogram_Chart_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[histogram_Chart_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[资料格式] [nchar](50) NOT NULL,
	[数据类型] [nchar](50) NOT NULL,
	[小数点以上位数] [nchar](50) NOT NULL,
	[小数点以下位数] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NOT NULL,
	[通道数量] [int] NOT NULL,
	[Name_Text] [nchar](500) NULL,
 CONSTRAINT [PK_histogram_Chart_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ihatetheqrcode_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ihatetheqrcode_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[资料格式] [nchar](50) NOT NULL,
	[数据类型] [nchar](50) NOT NULL,
	[小数点以上位数] [nchar](50) NOT NULL,
	[小数点以下位数] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NOT NULL,
	[二维码/条形码] [bit] NOT NULL,
	[显示宽-高] [nchar](100) NOT NULL,
 CONSTRAINT [PK_ihatetheqrcode_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImageButton_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageButton_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[位指示灯] [nchar](10) NOT NULL,
	[位切换开关] [nchar](10) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[操作模式] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NULL,
 CONSTRAINT [PK_ImageButton_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[label_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[label_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](50) NOT NULL,
 CONSTRAINT [PK_label_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedBulb_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedBulb_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[位指示灯] [nchar](10) NOT NULL,
	[位切换开关] [nchar](10) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[操作模式] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NULL,
 CONSTRAINT [PK_LedBulb_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedDisplay_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedDisplay_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[资料格式] [nchar](50) NOT NULL,
	[数据类型] [nchar](50) NOT NULL,
	[小数点以上位数] [nchar](50) NOT NULL,
	[小数点以下位数] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NOT NULL,
 CONSTRAINT [PK_LedDisplay_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[numerical_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[numerical_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[资料格式] [nchar](50) NOT NULL,
	[数据类型] [nchar](50) NOT NULL,
	[小数点以上位数] [nchar](50) NOT NULL,
	[小数点以下位数] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NOT NULL,
 CONSTRAINT [PK_numerical_parameter_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[oscillogram_Chart_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[oscillogram_Chart_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[资料格式] [nchar](50) NOT NULL,
	[数据类型] [nchar](50) NOT NULL,
	[小数点以上位数] [nchar](50) NOT NULL,
	[小数点以下位数] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NOT NULL,
	[通道数量] [int] NOT NULL,
	[Name_Text] [nchar](500) NULL,
	[Min] [int] NOT NULL,
	[Max] [int] NOT NULL,
	[刷新时间] [int] NOT NULL,
	[折线图/曲线图] [int] NOT NULL,
 CONSTRAINT [PK_oscillogram_Chart_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[picture_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[picture_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](50) NOT NULL,
 CONSTRAINT [PK_picture_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PLC_macroinstruction]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLC_macroinstruction](
	[ID] [int] NOT NULL,
	[方法索引] [int] NOT NULL,
	[宏指令名称] [nchar](100) NOT NULL,
	[运行时间间隔] [int] NOT NULL,
	[是否周期执行] [bit] NOT NULL,
	[内容] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PLC_macroinstruction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PLC_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLC_parameter](
	[ID] [int] NOT NULL,
	[三菱PLC-IP] [nchar](50) NOT NULL,
	[三菱PLC-端口] [nchar](50) NOT NULL,
	[三菱PLC-类型] [nchar](50) NOT NULL,
	[三菱PLC-链接类型] [nchar](50) NOT NULL,
	[西门子PLC-IP] [nchar](50) NOT NULL,
	[西门子PLC-端口] [nchar](50) NOT NULL,
	[西门子PLC-类型] [nchar](50) NOT NULL,
	[西门子PLC-链接类型] [nchar](50) NOT NULL,
	[MODBUS-TCP-PLC-IP] [nchar](50) NOT NULL,
	[MODBUS-TCP-PLC-端口11] [nchar](50) NOT NULL,
	[MODBUS-TCP-PLC-类型] [nchar](50) NOT NULL,
	[MODBUS-TCP-PLC-链接类型] [nchar](50) NOT NULL,
 CONSTRAINT [PK_PLC_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profile]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[ID] [int] NOT NULL,
	[Profilepicture] [image] NOT NULL,
	[ProfilepictureText] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ScrollingText_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScrollingText_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
 CONSTRAINT [PK_ScrollingText_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Switch_parameter]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Switch_parameter](
	[ID] [nchar](100) NOT NULL,
	[FORM] [nchar](20) NOT NULL,
	[位指示灯] [nchar](10) NOT NULL,
	[位切换开关] [nchar](10) NOT NULL,
	[读写设备] [nchar](50) NOT NULL,
	[读写设备_地址] [nchar](50) NOT NULL,
	[读写设备_地址-具体地址] [nchar](50) NOT NULL,
	[读写不同地址_ON_OFF] [int] NOT NULL,
	[写设备_复选] [nchar](50) NOT NULL,
	[写设备_地址_复选] [nchar](50) NOT NULL,
	[写设备_地址-具体地址_复选] [nchar](50) NOT NULL,
	[操作模式] [nchar](50) NOT NULL,
	[操作安全时间] [nchar](50) NULL,
 CONSTRAINT [PK_Switch_parameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag common parameters]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag common parameters](
	[ID] [nchar](100) NOT NULL,
	[FROM] [nchar](50) NOT NULL,
	[Control-type] [nchar](50) NOT NULL,
	[Control-state-0] [int] NOT NULL,
	[Control-state-0_typeface] [nchar](50) NOT NULL,
	[Control-state-0_colour] [nchar](50) NOT NULL,
	[Control-state-0_size] [nchar](50) NOT NULL,
	[Control-state-0_aligning] [nchar](50) NOT NULL,
	[Control-state-0_content] [nchar](100) NOT NULL,
	[Control-state-0_flicker] [int] NOT NULL,
	[Control-state-1] [int] NOT NULL,
	[Control-state-1_typeface] [nchar](50) NOT NULL,
	[Control-state-1_colour] [nchar](50) NOT NULL,
	[Control-state-1_size] [nchar](50) NOT NULL,
	[Control-state-1_aligning] [nchar](50) NOT NULL,
	[Control-state-1_content1] [nchar](100) NOT NULL,
	[Control-state-1_flicker] [int] NOT NULL,
 CONSTRAINT [PK_Tag common parameters——1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[AnalogMeter_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AnalogMeter_Class]
AS
SELECT   dbo.AnalogMeter_parameter.ID, dbo.AnalogMeter_parameter.FORM, dbo.AnalogMeter_parameter.读写设备, 
                dbo.AnalogMeter_parameter.读写设备_地址, dbo.AnalogMeter_parameter.[读写设备_地址-具体地址], 
                dbo.AnalogMeter_parameter.读写不同地址_ON_OFF, dbo.AnalogMeter_parameter.写设备_复选, 
                dbo.AnalogMeter_parameter.写设备_地址_复选, dbo.AnalogMeter_parameter.[写设备_地址-具体地址_复选], 
                dbo.AnalogMeter_parameter.资料格式, dbo.AnalogMeter_parameter.数据类型, 
                dbo.AnalogMeter_parameter.小数点以上位数, dbo.AnalogMeter_parameter.小数点以下位数, 
                dbo.AnalogMeter_parameter.操作安全时间, dbo.AnalogMeter_parameter.Min, dbo.AnalogMeter_parameter.Max, 
                dbo.AnalogMeter_parameter.刷新时间, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.AnalogMeter_parameter INNER JOIN
                dbo.[control-location] ON dbo.AnalogMeter_parameter.ID = dbo.[control-location].ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.AnalogMeter_parameter.ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[Button_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Button_Class]
AS
SELECT   dbo.Button_parameter.ID, dbo.Button_parameter.FORM, dbo.Button_parameter.位指示灯, 
                dbo.Button_parameter.位切换开关, dbo.Button_parameter.读写设备, dbo.Button_parameter.读写设备_地址, 
                dbo.Button_parameter.[读写设备_地址-具体地址], dbo.Button_parameter.读写不同地址_ON_OFF, 
                dbo.Button_parameter.写设备_复选, dbo.Button_parameter.写设备_地址_复选, 
                dbo.Button_parameter.[写设备_地址-具体地址_复选], dbo.Button_parameter.操作模式, 
                dbo.Button_parameter.操作安全时间, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size, dbo.[General parameters of picture].[Control-type] AS Expr1, 
                dbo.[General parameters of picture].[Control-state-0] AS Expr2, dbo.[General parameters of picture].[Control-state-0-list], 
                dbo.[General parameters of picture].[Control-state-0-picture], 
                dbo.[General parameters of picture].[Control-state-1] AS Expr3, dbo.[General parameters of picture].[Control-state-1-list], 
                dbo.[General parameters of picture].[Control-state-1-picture]
FROM      dbo.Button_parameter INNER JOIN
                dbo.[control-location] ON dbo.Button_parameter.ID = dbo.[control-location].ID INNER JOIN
                dbo.[General parameters of picture] ON dbo.Button_parameter.ID = dbo.[General parameters of picture].ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.Button_parameter.ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[doughnut_Chart_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[doughnut_Chart_Class]
AS
SELECT   dbo.doughnut_Chart_parameter.*, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.doughnut_Chart_parameter ON dbo.[control-location].ID = dbo.doughnut_Chart_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[GroupBox_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GroupBox_Class]
AS
SELECT   dbo.GroupBox_parameter.*, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.GroupBox_parameter ON dbo.[control-location].ID = dbo.GroupBox_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[histogram_Chart_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[histogram_Chart_Class]
AS
SELECT   dbo.histogram_Chart_parameter.*, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.histogram_Chart_parameter ON dbo.[control-location].ID = dbo.histogram_Chart_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[ihatetheqrcode_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ihatetheqrcode_Class]
AS
SELECT   dbo.ihatetheqrcode_parameter.*, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.ihatetheqrcode_parameter ON dbo.[control-location].ID = dbo.ihatetheqrcode_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[ImageButton_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ImageButton_Class]
AS
SELECT   dbo.ImageButton_parameter.*, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.ImageButton_parameter ON dbo.[control-location].ID = dbo.ImageButton_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[label_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[label_Class]
AS
SELECT  dbo.[Tag common parameters].ID, dbo.[Tag common parameters].[FROM], dbo.[Tag common parameters].[Control-type], 
                   dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                   dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                   dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                   dbo.[control-location].location, dbo.[control-location].size, dbo.[Tag common parameters].[Control-state-0_flicker]
FROM      dbo.[control-location] INNER JOIN
                   dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID INNER JOIN
                   dbo.label_parameter ON dbo.[control-location].ID = dbo.label_parameter.ID

GO
/****** Object:  View [dbo].[LedBulb_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LedBulb_Class]
AS
SELECT   dbo.LedBulb_parameter.*, dbo.[Tag common parameters].[Control-type], dbo.[Tag common parameters].[Control-state-0], 
                dbo.[Tag common parameters].[Control-state-0_typeface], dbo.[Tag common parameters].[Control-state-0_colour], 
                dbo.[Tag common parameters].[Control-state-0_size], dbo.[Tag common parameters].[Control-state-0_aligning], 
                dbo.[Tag common parameters].[Control-state-0_content], dbo.[Tag common parameters].[Control-state-0_flicker], 
                dbo.[Tag common parameters].[Control-state-1], dbo.[Tag common parameters].[Control-state-1_typeface], 
                dbo.[Tag common parameters].[Control-state-1_colour], dbo.[Tag common parameters].[Control-state-1_size], 
                dbo.[Tag common parameters].[Control-state-1_aligning], dbo.[Tag common parameters].[Control-state-1_content1], 
                dbo.[Tag common parameters].[Control-state-1_flicker], dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.LedBulb_parameter ON dbo.[control-location].ID = dbo.LedBulb_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[LedDisplay_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LedDisplay_Class]
AS
SELECT   dbo.LedDisplay_parameter.*, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.LedDisplay_parameter ON dbo.[control-location].ID = dbo.LedDisplay_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[numerical_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[numerical_Class]
AS
SELECT  dbo.numerical_parameter.*, dbo.[Tag common parameters].[Control-type], dbo.[Tag common parameters].[Control-state-0], 
                   dbo.[Tag common parameters].[Control-state-0_typeface], dbo.[Tag common parameters].[Control-state-0_colour], 
                   dbo.[Tag common parameters].[Control-state-0_size], dbo.[Tag common parameters].[Control-state-0_aligning], 
                   dbo.[Tag common parameters].[Control-state-0_content], dbo.[Tag common parameters].[Control-state-0_flicker], 
                   dbo.[Tag common parameters].[Control-state-1], dbo.[Tag common parameters].[Control-state-1_typeface], 
                   dbo.[Tag common parameters].[Control-state-1_colour], dbo.[Tag common parameters].[Control-state-1_size], 
                   dbo.[Tag common parameters].[Control-state-1_aligning], dbo.[Tag common parameters].[Control-state-1_content1], 
                   dbo.[Tag common parameters].[Control-state-1_flicker], dbo.[General parameters of picture].[Control-type] AS Expr1, 
                   dbo.[General parameters of picture].[Control-state-0] AS Expr2, dbo.[General parameters of picture].[Control-state-0-list], 
                   dbo.[General parameters of picture].[Control-state-0-picture], 
                   dbo.[General parameters of picture].[Control-state-1] AS Expr3, dbo.[General parameters of picture].[Control-state-1-list], 
                   dbo.[General parameters of picture].[Control-state-1-picture], dbo.[control-location].location, 
                   dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                   dbo.[General parameters of picture] ON dbo.[control-location].ID = dbo.[General parameters of picture].ID INNER JOIN
                   dbo.numerical_parameter ON dbo.[control-location].ID = dbo.numerical_parameter.ID INNER JOIN
                   dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[oscillogram_Chart_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[oscillogram_Chart_Class]
AS
SELECT   dbo.oscillogram_Chart_parameter.*, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.oscillogram_Chart_parameter ON dbo.[control-location].ID = dbo.oscillogram_Chart_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[picture_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[picture_Class]
AS
SELECT  dbo.[General parameters of picture].ID, dbo.[General parameters of picture].FORM, 
                   dbo.[General parameters of picture].[Control-type], dbo.[General parameters of picture].[Control-state-0], 
                   dbo.[General parameters of picture].[Control-state-0-list], dbo.[General parameters of picture].[Control-state-0-picture], 
                   dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                   dbo.[General parameters of picture] ON dbo.[control-location].ID = dbo.[General parameters of picture].ID INNER JOIN
                   dbo.picture_parameter ON dbo.[control-location].ID = dbo.picture_parameter.ID

GO
/****** Object:  View [dbo].[ScrollingText_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ScrollingText_Class]
AS
SELECT   dbo.ScrollingText_parameter.ID, dbo.ScrollingText_parameter.FORM, dbo.[Tag common parameters].[Control-type], 
                dbo.[Tag common parameters].[Control-state-0], dbo.[Tag common parameters].[Control-state-0_typeface], 
                dbo.[Tag common parameters].[Control-state-0_colour], dbo.[Tag common parameters].[Control-state-0_size], 
                dbo.[Tag common parameters].[Control-state-0_aligning], dbo.[Tag common parameters].[Control-state-0_content], 
                dbo.[Tag common parameters].[Control-state-0_flicker], dbo.[Tag common parameters].[Control-state-1], 
                dbo.[Tag common parameters].[Control-state-1_typeface], dbo.[Tag common parameters].[Control-state-1_colour], 
                dbo.[Tag common parameters].[Control-state-1_size], dbo.[Tag common parameters].[Control-state-1_aligning], 
                dbo.[Tag common parameters].[Control-state-1_content1], dbo.[Tag common parameters].[Control-state-1_flicker], 
                dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.ScrollingText_parameter ON dbo.[control-location].ID = dbo.ScrollingText_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  View [dbo].[Switch_Class]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Switch_Class]
AS
SELECT   dbo.Switch_parameter.*, dbo.[Tag common parameters].[Control-type], dbo.[Tag common parameters].[Control-state-0], 
                dbo.[Tag common parameters].[Control-state-0_typeface], dbo.[Tag common parameters].[Control-state-0_colour], 
                dbo.[Tag common parameters].[Control-state-0_size], dbo.[Tag common parameters].[Control-state-0_aligning], 
                dbo.[Tag common parameters].[Control-state-0_content], dbo.[Tag common parameters].[Control-state-0_flicker], 
                dbo.[Tag common parameters].[Control-state-1], dbo.[Tag common parameters].[Control-state-1_typeface], 
                dbo.[Tag common parameters].[Control-state-1_colour], dbo.[Tag common parameters].[Control-state-1_size], 
                dbo.[Tag common parameters].[Control-state-1_aligning], dbo.[Tag common parameters].[Control-state-1_content1], 
                dbo.[Tag common parameters].[Control-state-1_flicker], dbo.[control-location].location, dbo.[control-location].size
FROM      dbo.[control-location] INNER JOIN
                dbo.Switch_parameter ON dbo.[control-location].ID = dbo.Switch_parameter.ID INNER JOIN
                dbo.[Tag common parameters] ON dbo.[control-location].ID = dbo.[Tag common parameters].ID

GO
/****** Object:  DdlTrigger [OnTriggerDboSchema]    Script Date: 2020/9/7 19:51:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [OnTriggerDboSchema] ON database FOR create_table, create_view AS BEGIN   DECLARE @xmlEventData xml   SELECT    @xmlEventData = eventdata()   DECLARE @schemaName nvarchar(max)   DECLARE @objectName nvarchar(max)   DECLARE @DynSql nvarchar(max)      SET @schemaName    = convert(nvarchar(max), @xmlEventData.query('/EVENT_INSTANCE/SchemaName/text()'))   SET @objectName    = convert(nvarchar(max), @xmlEventData.query('/EVENT_INSTANCE/ObjectName/text()'))   IF(@schemaName='')   BEGIN     SET @DynSql = N'alter schema [dbo] transfer [' + @schemaName + N'].[' + @objectName + N']'     EXEC sp_executesql @statement=@DynSql   END END SET QUOTED_IDENTIFIER ON SET ANSI_NULLS ON 
GO
ENABLE TRIGGER [OnTriggerDboSchema] ON DATABASE
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
         Begin Table = "AnalogMeter_parameter"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "control-location"
            Begin Extent = 
               Top = 6
               Left = 312
               Bottom = 146
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 150
               Left = 38
               Bottom = 290
               Right = 270
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AnalogMeter_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AnalogMeter_Class'
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
         Begin Table = "Button_parameter"
            Begin Extent = 
               Top = 7
               Left = 0
               Bottom = 170
               Right = 280
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "control-location"
            Begin Extent = 
               Top = 6
               Left = 318
               Bottom = 146
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "General parameters of picture"
            Begin Extent = 
               Top = 174
               Left = 38
               Bottom = 314
               Right = 260
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 318
               Left = 38
               Bottom = 458
               Right = 270
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
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
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Button_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Button_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Button_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 31
               Left = 751
               Bottom = 202
               Right = 902
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "doughnut_Chart_parameter"
            Begin Extent = 
               Top = 2
               Left = 28
               Bottom = 142
               Right = 264
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 0
               Left = 259
               Bottom = 140
               Right = 491
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'doughnut_Chart_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'doughnut_Chart_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 27
               Left = 435
               Bottom = 167
               Right = 577
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GroupBox_parameter"
            Begin Extent = 
               Top = 25
               Left = 0
               Bottom = 127
               Right = 142
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 26
               Left = 166
               Bottom = 150
               Right = 398
            End
            DisplayFlags = 280
            TopColumn = 14
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GroupBox_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GroupBox_Class'
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
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "control-location"
            Begin Extent = 
               Top = 4
               Left = 513
               Bottom = 144
               Right = 655
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "histogram_Chart_parameter"
            Begin Extent = 
               Top = 8
               Left = 0
               Bottom = 148
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 4
               Left = 251
               Bottom = 144
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'histogram_Chart_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'histogram_Chart_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 0
               Left = 525
               Bottom = 140
               Right = 667
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ihatetheqrcode_parameter"
            Begin Extent = 
               Top = 0
               Left = 25
               Bottom = 140
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 0
               Left = 270
               Bottom = 140
               Right = 502
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ihatetheqrcode_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ihatetheqrcode_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 128
               Left = 570
               Bottom = 268
               Right = 712
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ImageButton_parameter"
            Begin Extent = 
               Top = 133
               Left = 69
               Bottom = 273
               Right = 305
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 130
               Left = 317
               Bottom = 270
               Right = 549
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ImageButton_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ImageButton_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 0
               Left = 522
               Bottom = 163
               Right = 683
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 0
               Left = 219
               Bottom = 163
               Right = 499
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "label_parameter"
            Begin Extent = 
               Top = 9
               Left = 26
               Bottom = 128
               Right = 187
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'label_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'label_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 5
               Left = 582
               Bottom = 145
               Right = 724
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LedBulb_parameter"
            Begin Extent = 
               Top = 9
               Left = 67
               Bottom = 149
               Right = 303
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 11
               Left = 323
               Bottom = 151
               Right = 555
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LedBulb_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LedBulb_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 0
               Left = 556
               Bottom = 140
               Right = 698
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LedDisplay_parameter"
            Begin Extent = 
               Top = 0
               Left = 41
               Bottom = 140
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 0
               Left = 305
               Bottom = 140
               Right = 537
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LedDisplay_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LedDisplay_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 0
               Left = 824
               Bottom = 163
               Right = 985
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "General parameters of picture"
            Begin Extent = 
               Top = 0
               Left = 540
               Bottom = 163
               Right = 805
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "numerical_parameter"
            Begin Extent = 
               Top = 0
               Left = 0
               Bottom = 163
               Right = 280
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 0
               Left = 269
               Bottom = 163
               Right = 549
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'numerical_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'numerical_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 2
               Left = 562
               Bottom = 142
               Right = 704
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "oscillogram_Chart_parameter"
            Begin Extent = 
               Top = 10
               Left = 72
               Bottom = 150
               Right = 308
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 9
               Left = 313
               Bottom = 149
               Right = 545
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'oscillogram_Chart_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'oscillogram_Chart_Class'
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
         Top = -120
         Left = 0
      End
      Begin Tables = 
         Begin Table = "control-location"
            Begin Extent = 
               Top = 137
               Left = 562
               Bottom = 300
               Right = 723
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "General parameters of picture"
            Begin Extent = 
               Top = 147
               Left = 283
               Bottom = 310
               Right = 548
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "picture_parameter"
            Begin Extent = 
               Top = 158
               Left = 51
               Bottom = 277
               Right = 212
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'picture_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'picture_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 0
               Left = 469
               Bottom = 140
               Right = 611
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ScrollingText_parameter"
            Begin Extent = 
               Top = 2
               Left = 23
               Bottom = 104
               Right = 165
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 0
               Left = 190
               Bottom = 140
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ScrollingText_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ScrollingText_Class'
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
         Begin Table = "control-location"
            Begin Extent = 
               Top = 9
               Left = 531
               Bottom = 149
               Right = 673
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Switch_parameter"
            Begin Extent = 
               Top = 6
               Left = 0
               Bottom = 146
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tag common parameters"
            Begin Extent = 
               Top = 4
               Left = 249
               Bottom = 144
               Right = 481
            End
            DisplayFlags = 280
            TopColumn = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Switch_Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Switch_Class'
GO
USE [master]
GO
ALTER DATABASE [Uppercomputer] SET  READ_WRITE 
GO
