
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2020 14:29:58
-- Generated from EDMX file: D:\C#项目\自定义Uppercomputer-20200727\自定义Uppercomputer-20200727\EF实体模型\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Uppercomputer];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AnalogMeter_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnalogMeter_parameter];
GO
IF OBJECT_ID(N'[dbo].[Button_colour]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Button_colour];
GO
IF OBJECT_ID(N'[dbo].[Button_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Button_parameter];
GO
IF OBJECT_ID(N'[dbo].[Control_layer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Control_layer];
GO
IF OBJECT_ID(N'[dbo].[control-location]', 'U') IS NOT NULL
    DROP TABLE [dbo].[control-location];
GO
IF OBJECT_ID(N'[dbo].[doughnut_Chart_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[doughnut_Chart_parameter];
GO
IF OBJECT_ID(N'[dbo].[Event_message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event_message];
GO
IF OBJECT_ID(N'[dbo].[function_key_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[function_key_parameter];
GO
IF OBJECT_ID(N'[dbo].[General parameters of picture]', 'U') IS NOT NULL
    DROP TABLE [dbo].[General parameters of picture];
GO
IF OBJECT_ID(N'[dbo].[GroupBox_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupBox_parameter];
GO
IF OBJECT_ID(N'[dbo].[histogram_Chart_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[histogram_Chart_parameter];
GO
IF OBJECT_ID(N'[dbo].[HScrollBar_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HScrollBar_parameter];
GO
IF OBJECT_ID(N'[dbo].[ihatetheqrcode_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ihatetheqrcode_parameter];
GO
IF OBJECT_ID(N'[dbo].[ImageButton_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageButton_parameter];
GO
IF OBJECT_ID(N'[dbo].[label_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[label_parameter];
GO
IF OBJECT_ID(N'[dbo].[LedBulb_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LedBulb_parameter];
GO
IF OBJECT_ID(N'[dbo].[LedDisplay_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LedDisplay_parameter];
GO
IF OBJECT_ID(N'[dbo].[numerical_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[numerical_parameter];
GO
IF OBJECT_ID(N'[dbo].[oscillogram_Chart_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[oscillogram_Chart_parameter];
GO
IF OBJECT_ID(N'[dbo].[picture_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[picture_parameter];
GO
IF OBJECT_ID(N'[dbo].[PLC_macroinstruction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PLC_macroinstruction];
GO
IF OBJECT_ID(N'[dbo].[PLC_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PLC_parameter];
GO
IF OBJECT_ID(N'[dbo].[Profile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profile];
GO
IF OBJECT_ID(N'[dbo].[pull_down_menu_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pull_down_menu_parameter];
GO
IF OBJECT_ID(N'[dbo].[pull_down_menuName]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pull_down_menuName];
GO
IF OBJECT_ID(N'[dbo].[RadioButton_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RadioButton_parameter];
GO
IF OBJECT_ID(N'[dbo].[ScrollingText_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScrollingText_parameter];
GO
IF OBJECT_ID(N'[dbo].[Switch_parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Switch_parameter];
GO
IF OBJECT_ID(N'[dbo].[Tag common parameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tag common parameters];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[AnalogMeter_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[AnalogMeter_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[Button_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[Button_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[doughnut_Chart_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[doughnut_Chart_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[function_key_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[function_key_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[GroupBox_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[GroupBox_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[histogram_Chart_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[histogram_Chart_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[HScrollBar_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[HScrollBar_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[ihatetheqrcode_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[ihatetheqrcode_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[ImageButton_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[ImageButton_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[label_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[label_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[LedBulb_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[LedBulb_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[LedDisplay_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[LedDisplay_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[numerical_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[numerical_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[oscillogram_Chart_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[oscillogram_Chart_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[picture_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[picture_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[pull_down_menu_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[pull_down_menu_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[RadioButton_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[RadioButton_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[ScrollingText_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[ScrollingText_Class];
GO
IF OBJECT_ID(N'[UppercomputerModelStoreContainer].[Switch_Class]', 'U') IS NOT NULL
    DROP TABLE [UppercomputerModelStoreContainer].[Switch_Class];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Button_parameter'
CREATE TABLE [dbo].[Button_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL
);
GO

-- Creating table 'control_location'
CREATE TABLE [dbo].[control_location] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- Creating table 'General_parameters_of_picture'
CREATE TABLE [dbo].[General_parameters_of_picture] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_list] int  NOT NULL,
    [Control_state_0_picture] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_list] int  NOT NULL,
    [Control_state_1_picture] int  NOT NULL
);
GO

-- Creating table 'numerical_parameter'
CREATE TABLE [dbo].[numerical_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL
);
GO

-- Creating table 'Profile'
CREATE TABLE [dbo].[Profile] (
    [ID] int  NOT NULL,
    [Profilepicture] varbinary(max)  NOT NULL,
    [ProfilepictureText] nchar(50)  NOT NULL
);
GO

-- Creating table 'Tag_common_parameters'
CREATE TABLE [dbo].[Tag_common_parameters] (
    [ID] nchar(400)  NOT NULL,
    [FROM] nvarchar(max)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL
);
GO

-- Creating table 'Button_Class'
CREATE TABLE [dbo].[Button_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [Expr1] nchar(50)  NOT NULL,
    [Expr2] int  NOT NULL,
    [Control_state_0_list] int  NOT NULL,
    [Control_state_0_picture] int  NOT NULL,
    [Expr3] int  NOT NULL,
    [Control_state_1_list] int  NOT NULL,
    [Control_state_1_picture] int  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'label_Class'
CREATE TABLE [dbo].[label_Class] (
    [ID] nchar(100)  NOT NULL,
    [FROM] nchar(50)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL
);
GO

-- Creating table 'numerical_Class'
CREATE TABLE [dbo].[numerical_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [Expr1] nchar(50)  NOT NULL,
    [Expr2] int  NOT NULL,
    [Control_state_0_list] int  NOT NULL,
    [Control_state_0_picture] int  NOT NULL,
    [Expr3] int  NOT NULL,
    [Control_state_1_list] int  NOT NULL,
    [Control_state_1_picture] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'picture_Class'
CREATE TABLE [dbo].[picture_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(50)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_list] int  NOT NULL,
    [Control_state_0_picture] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- Creating table 'label_parameter'
CREATE TABLE [dbo].[label_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'picture_parameter'
CREATE TABLE [dbo].[picture_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PLC_parameter'
CREATE TABLE [dbo].[PLC_parameter] (
    [ID] int  NOT NULL,
    [三菱PLC_IP] nchar(50)  NOT NULL,
    [三菱PLC_端口] nchar(50)  NOT NULL,
    [三菱PLC_类型] nchar(50)  NOT NULL,
    [三菱PLC_链接类型] nchar(50)  NOT NULL,
    [西门子PLC_IP] nchar(50)  NOT NULL,
    [西门子PLC_端口] nchar(50)  NOT NULL,
    [西门子PLC_类型] nchar(50)  NOT NULL,
    [西门子PLC_链接类型] nchar(50)  NOT NULL,
    [MODBUS_TCP_PLC_IP] nchar(50)  NOT NULL,
    [MODBUS_TCP_PLC_端口11] nchar(50)  NOT NULL,
    [MODBUS_TCP_PLC_类型] nchar(50)  NOT NULL,
    [MODBUS_TCP_PLC_链接类型] nchar(50)  NOT NULL
);
GO

-- Creating table 'Event_message'
CREATE TABLE [dbo].[Event_message] (
    [ID] int  NOT NULL,
    [类型] int  NOT NULL,
    [设备] nchar(100)  NOT NULL,
    [设备_地址] nchar(100)  NOT NULL,
    [设备_具体地址] nchar(100)  NOT NULL,
    [位触发条件] nchar(50)  NOT NULL,
    [字触发条件] nchar(50)  NOT NULL,
    [字触发条件_具体] nchar(50)  NOT NULL,
    [报警内容] nchar(200)  NOT NULL
);
GO

-- Creating table 'Switch_parameter'
CREATE TABLE [dbo].[Switch_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL
);
GO

-- Creating table 'Switch_Class'
CREATE TABLE [dbo].[Switch_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'LedBulb_parameter'
CREATE TABLE [dbo].[LedBulb_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL
);
GO

-- Creating table 'LedBulb_Class'
CREATE TABLE [dbo].[LedBulb_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'GroupBox_parameter'
CREATE TABLE [dbo].[GroupBox_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ImageButton_parameter'
CREATE TABLE [dbo].[ImageButton_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL
);
GO

-- Creating table 'ScrollingText_parameter'
CREATE TABLE [dbo].[ScrollingText_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GroupBox_Class'
CREATE TABLE [dbo].[GroupBox_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'ImageButton_Class'
CREATE TABLE [dbo].[ImageButton_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(20)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- Creating table 'ScrollingText_Class'
CREATE TABLE [dbo].[ScrollingText_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(20)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- Creating table 'doughnut_Chart_parameter'
CREATE TABLE [dbo].[doughnut_Chart_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [通道数量] int  NOT NULL,
    [Name_Text] nchar(500)  NULL
);
GO

-- Creating table 'doughnut_Chart_Class'
CREATE TABLE [dbo].[doughnut_Chart_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [通道数量] int  NOT NULL,
    [Name_Text] nchar(500)  NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'Control_layer'
CREATE TABLE [dbo].[Control_layer] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [type] nchar(100)  NOT NULL,
    [Upper_layer] int  NOT NULL
);
GO

-- Creating table 'histogram_Chart_parameter'
CREATE TABLE [dbo].[histogram_Chart_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [通道数量] int  NOT NULL,
    [Name_Text] nchar(500)  NULL
);
GO

-- Creating table 'oscillogram_Chart_parameter'
CREATE TABLE [dbo].[oscillogram_Chart_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [通道数量] int  NOT NULL,
    [Name_Text] nchar(500)  NULL,
    [Min] int  NOT NULL,
    [Max] int  NOT NULL,
    [刷新时间] int  NOT NULL,
    [折线图_曲线图] int  NOT NULL
);
GO

-- Creating table 'histogram_Chart_Class'
CREATE TABLE [dbo].[histogram_Chart_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [通道数量] int  NOT NULL,
    [Name_Text] nchar(500)  NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'oscillogram_Chart_Class'
CREATE TABLE [dbo].[oscillogram_Chart_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [通道数量] int  NOT NULL,
    [Name_Text] nchar(500)  NULL,
    [Min] int  NOT NULL,
    [Max] int  NOT NULL,
    [刷新时间] int  NOT NULL,
    [折线图_曲线图] int  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'PLC_macroinstruction'
CREATE TABLE [dbo].[PLC_macroinstruction] (
    [ID] int  NOT NULL,
    [方法索引] int  NOT NULL,
    [宏指令名称] nchar(100)  NOT NULL,
    [运行时间间隔] int  NOT NULL,
    [是否周期执行] bit  NOT NULL,
    [内容] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AnalogMeter_parameter'
CREATE TABLE [dbo].[AnalogMeter_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [Min] int  NOT NULL,
    [Max] int  NOT NULL,
    [刷新时间] int  NOT NULL
);
GO

-- Creating table 'LedDisplay_parameter'
CREATE TABLE [dbo].[LedDisplay_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL
);
GO

-- Creating table 'LedDisplay_Class'
CREATE TABLE [dbo].[LedDisplay_Class] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'ihatetheqrcode_parameter'
CREATE TABLE [dbo].[ihatetheqrcode_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [二维码_条形码] bit  NOT NULL,
    [显示宽_高] nchar(100)  NOT NULL
);
GO

-- Creating table 'ihatetheqrcode_Class'
CREATE TABLE [dbo].[ihatetheqrcode_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(20)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [二维码_条形码] bit  NOT NULL,
    [显示宽_高] nchar(100)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- Creating table 'function_key_parameter'
CREATE TABLE [dbo].[function_key_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'function_key_Class'
CREATE TABLE [dbo].[function_key_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'pull_down_menu_parameter'
CREATE TABLE [dbo].[pull_down_menu_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [模式] int  NOT NULL,
    [下拉背景] nchar(50)  NOT NULL,
    [选择背景] nchar(50)  NOT NULL,
    [项目资料来源] int  NOT NULL,
    [项目数量] int  NOT NULL
);
GO

-- Creating table 'pull_down_menuName'
CREATE TABLE [dbo].[pull_down_menuName] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [项目] int  NOT NULL,
    [数据] nchar(100)  NOT NULL,
    [项目资料] nchar(100)  NOT NULL,
    [控件归属] nchar(100)  NOT NULL
);
GO

-- Creating table 'Button_colour'
CREATE TABLE [dbo].[Button_colour] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'AnalogMeter_Class'
CREATE TABLE [dbo].[AnalogMeter_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [Min] int  NOT NULL,
    [Max] int  NOT NULL,
    [刷新时间] int  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- Creating table 'RadioButton_parameter'
CREATE TABLE [dbo].[RadioButton_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL
);
GO

-- Creating table 'RadioButton_Class'
CREATE TABLE [dbo].[RadioButton_Class] (
    [ID] nchar(100)  NOT NULL,
    [FORM] nchar(100)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL,
    [colour_0] nchar(100)  NOT NULL,
    [colour_1] nchar(100)  NOT NULL
);
GO

-- Creating table 'pull_down_menu_Class'
CREATE TABLE [dbo].[pull_down_menu_Class] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [位指示灯] nchar(10)  NOT NULL,
    [位切换开关] nchar(10)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [操作模式] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [模式] int  NOT NULL,
    [下拉背景] nchar(50)  NOT NULL,
    [选择背景] nchar(50)  NOT NULL,
    [项目资料来源] int  NOT NULL,
    [项目数量] int  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- Creating table 'HScrollBar_parameter'
CREATE TABLE [dbo].[HScrollBar_parameter] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [Min] int  NOT NULL,
    [Max] int  NOT NULL,
    [刷新时间] int  NOT NULL
);
GO

-- Creating table 'HScrollBar_Class'
CREATE TABLE [dbo].[HScrollBar_Class] (
    [ID] nchar(400)  NOT NULL,
    [FORM] nvarchar(max)  NOT NULL,
    [读写设备] nchar(50)  NOT NULL,
    [读写设备_地址] nchar(50)  NOT NULL,
    [读写设备_地址_具体地址] nchar(50)  NOT NULL,
    [读写不同地址_ON_OFF] int  NOT NULL,
    [写设备_复选] nchar(50)  NOT NULL,
    [写设备_地址_复选] nchar(50)  NOT NULL,
    [写设备_地址_具体地址_复选] nchar(50)  NOT NULL,
    [资料格式] nchar(50)  NOT NULL,
    [数据类型] nchar(50)  NOT NULL,
    [小数点以上位数] nchar(50)  NOT NULL,
    [小数点以下位数] nchar(50)  NOT NULL,
    [操作安全时间] nchar(50)  NOT NULL,
    [Min] int  NOT NULL,
    [Max] int  NOT NULL,
    [刷新时间] int  NOT NULL,
    [Control_type] nchar(50)  NOT NULL,
    [Control_state_0] int  NOT NULL,
    [Control_state_0_typeface] nchar(50)  NOT NULL,
    [Control_state_0_colour] nchar(50)  NOT NULL,
    [Control_state_0_size] nchar(50)  NOT NULL,
    [Control_state_0_aligning] nchar(50)  NOT NULL,
    [Control_state_0_content] nchar(100)  NOT NULL,
    [Control_state_0_flicker] int  NOT NULL,
    [Control_state_1] int  NOT NULL,
    [Control_state_1_typeface] nchar(50)  NOT NULL,
    [Control_state_1_colour] nchar(50)  NOT NULL,
    [Control_state_1_size] nchar(50)  NOT NULL,
    [Control_state_1_aligning] nchar(50)  NOT NULL,
    [Control_state_1_content1] nchar(100)  NOT NULL,
    [Control_state_1_flicker] int  NOT NULL,
    [location] nchar(50)  NOT NULL,
    [size] nchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Button_parameter'
ALTER TABLE [dbo].[Button_parameter]
ADD CONSTRAINT [PK_Button_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'control_location'
ALTER TABLE [dbo].[control_location]
ADD CONSTRAINT [PK_control_location]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'General_parameters_of_picture'
ALTER TABLE [dbo].[General_parameters_of_picture]
ADD CONSTRAINT [PK_General_parameters_of_picture]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'numerical_parameter'
ALTER TABLE [dbo].[numerical_parameter]
ADD CONSTRAINT [PK_numerical_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Profile'
ALTER TABLE [dbo].[Profile]
ADD CONSTRAINT [PK_Profile]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tag_common_parameters'
ALTER TABLE [dbo].[Tag_common_parameters]
ADD CONSTRAINT [PK_Tag_common_parameters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [Expr1], [Expr2], [Control_state_0_list], [Control_state_0_picture], [Expr3], [Control_state_1_list], [Control_state_1_picture], [colour_0], [colour_1] in table 'Button_Class'
ALTER TABLE [dbo].[Button_Class]
ADD CONSTRAINT [PK_Button_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [Expr1], [Expr2], [Control_state_0_list], [Control_state_0_picture], [Expr3], [Control_state_1_list], [Control_state_1_picture], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID], [FROM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [location], [size], [Control_state_0_flicker] in table 'label_Class'
ALTER TABLE [dbo].[label_Class]
ADD CONSTRAINT [PK_label_Class]
    PRIMARY KEY CLUSTERED ([ID], [FROM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [location], [size], [Control_state_0_flicker] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [Expr1], [Expr2], [Control_state_0_list], [Control_state_0_picture], [Expr3], [Control_state_1_list], [Control_state_1_picture], [location], [size], [colour_0], [colour_1] in table 'numerical_Class'
ALTER TABLE [dbo].[numerical_Class]
ADD CONSTRAINT [PK_numerical_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [Expr1], [Expr2], [Control_state_0_list], [Control_state_0_picture], [Expr3], [Control_state_1_list], [Control_state_1_picture], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_list], [Control_state_0_picture], [location], [size] in table 'picture_Class'
ALTER TABLE [dbo].[picture_Class]
ADD CONSTRAINT [PK_picture_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_list], [Control_state_0_picture], [location], [size] ASC);
GO

-- Creating primary key on [ID] in table 'label_parameter'
ALTER TABLE [dbo].[label_parameter]
ADD CONSTRAINT [PK_label_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'picture_parameter'
ALTER TABLE [dbo].[picture_parameter]
ADD CONSTRAINT [PK_picture_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PLC_parameter'
ALTER TABLE [dbo].[PLC_parameter]
ADD CONSTRAINT [PK_PLC_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Event_message'
ALTER TABLE [dbo].[Event_message]
ADD CONSTRAINT [PK_Event_message]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Switch_parameter'
ALTER TABLE [dbo].[Switch_parameter]
ADD CONSTRAINT [PK_Switch_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'Switch_Class'
ALTER TABLE [dbo].[Switch_Class]
ADD CONSTRAINT [PK_Switch_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID] in table 'LedBulb_parameter'
ALTER TABLE [dbo].[LedBulb_parameter]
ADD CONSTRAINT [PK_LedBulb_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'LedBulb_Class'
ALTER TABLE [dbo].[LedBulb_Class]
ADD CONSTRAINT [PK_LedBulb_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID] in table 'GroupBox_parameter'
ALTER TABLE [dbo].[GroupBox_parameter]
ADD CONSTRAINT [PK_GroupBox_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ImageButton_parameter'
ALTER TABLE [dbo].[ImageButton_parameter]
ADD CONSTRAINT [PK_ImageButton_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ScrollingText_parameter'
ALTER TABLE [dbo].[ScrollingText_parameter]
ADD CONSTRAINT [PK_ScrollingText_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'GroupBox_Class'
ALTER TABLE [dbo].[GroupBox_Class]
ADD CONSTRAINT [PK_GroupBox_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] in table 'ImageButton_Class'
ALTER TABLE [dbo].[ImageButton_Class]
ADD CONSTRAINT [PK_ImageButton_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] ASC);
GO

-- Creating primary key on [ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] in table 'ScrollingText_Class'
ALTER TABLE [dbo].[ScrollingText_Class]
ADD CONSTRAINT [PK_ScrollingText_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] ASC);
GO

-- Creating primary key on [ID] in table 'doughnut_Chart_parameter'
ALTER TABLE [dbo].[doughnut_Chart_parameter]
ADD CONSTRAINT [PK_doughnut_Chart_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [通道数量], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'doughnut_Chart_Class'
ALTER TABLE [dbo].[doughnut_Chart_Class]
ADD CONSTRAINT [PK_doughnut_Chart_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [通道数量], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID] in table 'Control_layer'
ALTER TABLE [dbo].[Control_layer]
ADD CONSTRAINT [PK_Control_layer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'histogram_Chart_parameter'
ALTER TABLE [dbo].[histogram_Chart_parameter]
ADD CONSTRAINT [PK_histogram_Chart_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'oscillogram_Chart_parameter'
ALTER TABLE [dbo].[oscillogram_Chart_parameter]
ADD CONSTRAINT [PK_oscillogram_Chart_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [通道数量], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'histogram_Chart_Class'
ALTER TABLE [dbo].[histogram_Chart_Class]
ADD CONSTRAINT [PK_histogram_Chart_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [通道数量], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [通道数量], [Min], [Max], [刷新时间], [折线图_曲线图], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'oscillogram_Chart_Class'
ALTER TABLE [dbo].[oscillogram_Chart_Class]
ADD CONSTRAINT [PK_oscillogram_Chart_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [通道数量], [Min], [Max], [刷新时间], [折线图_曲线图], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID] in table 'PLC_macroinstruction'
ALTER TABLE [dbo].[PLC_macroinstruction]
ADD CONSTRAINT [PK_PLC_macroinstruction]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AnalogMeter_parameter'
ALTER TABLE [dbo].[AnalogMeter_parameter]
ADD CONSTRAINT [PK_AnalogMeter_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LedDisplay_parameter'
ALTER TABLE [dbo].[LedDisplay_parameter]
ADD CONSTRAINT [PK_LedDisplay_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'LedDisplay_Class'
ALTER TABLE [dbo].[LedDisplay_Class]
ADD CONSTRAINT [PK_LedDisplay_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID] in table 'ihatetheqrcode_parameter'
ALTER TABLE [dbo].[ihatetheqrcode_parameter]
ADD CONSTRAINT [PK_ihatetheqrcode_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [二维码_条形码], [显示宽_高], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] in table 'ihatetheqrcode_Class'
ALTER TABLE [dbo].[ihatetheqrcode_Class]
ADD CONSTRAINT [PK_ihatetheqrcode_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [二维码_条形码], [显示宽_高], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] ASC);
GO

-- Creating primary key on [ID] in table 'function_key_parameter'
ALTER TABLE [dbo].[function_key_parameter]
ADD CONSTRAINT [PK_function_key_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [location], [size], [colour_0], [colour_1] in table 'function_key_Class'
ALTER TABLE [dbo].[function_key_Class]
ADD CONSTRAINT [PK_function_key_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID] in table 'pull_down_menu_parameter'
ALTER TABLE [dbo].[pull_down_menu_parameter]
ADD CONSTRAINT [PK_pull_down_menu_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'pull_down_menuName'
ALTER TABLE [dbo].[pull_down_menuName]
ADD CONSTRAINT [PK_pull_down_menuName]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Button_colour'
ALTER TABLE [dbo].[Button_colour]
ADD CONSTRAINT [PK_Button_colour]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Min], [Max], [刷新时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] in table 'AnalogMeter_Class'
ALTER TABLE [dbo].[AnalogMeter_Class]
ADD CONSTRAINT [PK_AnalogMeter_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Min], [Max], [刷新时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] ASC);
GO

-- Creating primary key on [ID] in table 'RadioButton_parameter'
ALTER TABLE [dbo].[RadioButton_parameter]
ADD CONSTRAINT [PK_RadioButton_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] in table 'RadioButton_Class'
ALTER TABLE [dbo].[RadioButton_Class]
ADD CONSTRAINT [PK_RadioButton_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size], [colour_0], [colour_1] ASC);
GO

-- Creating primary key on [ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [操作安全时间], [模式], [下拉背景], [选择背景], [项目资料来源], [项目数量], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] in table 'pull_down_menu_Class'
ALTER TABLE [dbo].[pull_down_menu_Class]
ADD CONSTRAINT [PK_pull_down_menu_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [位指示灯], [位切换开关], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [操作模式], [操作安全时间], [模式], [下拉背景], [选择背景], [项目资料来源], [项目数量], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] ASC);
GO

-- Creating primary key on [ID] in table 'HScrollBar_parameter'
ALTER TABLE [dbo].[HScrollBar_parameter]
ADD CONSTRAINT [PK_HScrollBar_parameter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Min], [Max], [刷新时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] in table 'HScrollBar_Class'
ALTER TABLE [dbo].[HScrollBar_Class]
ADD CONSTRAINT [PK_HScrollBar_Class]
    PRIMARY KEY CLUSTERED ([ID], [FORM], [读写设备], [读写设备_地址], [读写设备_地址_具体地址], [读写不同地址_ON_OFF], [写设备_复选], [写设备_地址_复选], [写设备_地址_具体地址_复选], [资料格式], [数据类型], [小数点以上位数], [小数点以下位数], [操作安全时间], [Min], [Max], [刷新时间], [Control_type], [Control_state_0], [Control_state_0_typeface], [Control_state_0_colour], [Control_state_0_size], [Control_state_0_aligning], [Control_state_0_content], [Control_state_0_flicker], [Control_state_1], [Control_state_1_typeface], [Control_state_1_colour], [Control_state_1_size], [Control_state_1_aligning], [Control_state_1_content1], [Control_state_1_flicker], [location], [size] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------