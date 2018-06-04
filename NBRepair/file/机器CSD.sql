/*database NBREPAIER*/

CREATE TABLE [dbo].[BOMCompare](
	[SKU_LNO] [nvarchar](50) NULL,
	[SKU_NO] [nvarchar](50) NULL,
	[KEY_TOPIC] [nvarchar](50) NULL,
	[TOPIC_ITEM] [nvarchar](50) NULL,
	[ITEM_DESCRIPTION] [nvarchar](50) NULL,
	[LCFC_PN] [nvarchar](128) NULL,
	[LNV_PN] [nvarchar](128) NULL,
	[KP_QTY] [nvarchar](128) NULL,
	[KP_REL] [nvarchar](50) NULL,
	[REMARK] [nvarchar](128) NULL,
	[INDICATOR_TYPE] [nvarchar](50) NULL,
	[PARENT_PN] [nvarchar](50) NULL,
	[GRAND_PN] [nvarchar](50) NULL,
	[ACTION_TYPE] [nvarchar](50) NULL,
	[STEP_SEQUENCE] [nvarchar](50) NULL
)

/*����Ʒ���Ͽⷿ*/
create table materialNgHouse
(
Id INT PRIMARY KEY IDENTITY, 
materialNo NVARCHAR(128),/*�Ϻ�*/
number NVARCHAR(128), /*�������*/
)

/*����Ʒ��������¼*/
create table materialNgHouseRecord
(
Id INT PRIMARY KEY IDENTITY, 
materialNo NVARCHAR(128),/*�Ϻ�*/
number NVARCHAR(128), /*�������*/
input_date date,/*���ʱ��*/
)

/*���Ͽⷿ*/
create table materialhouse
(
Id INT PRIMARY KEY IDENTITY, 
materialNo NVARCHAR(128),/*�Ϻ�*/
number NVARCHAR(128), /*�������*/
)

/*ԭ�������*/
CREATE TABLE [dbo].[RuKu](
	[countfile] [varchar](50) NULL,
	[partsno] [varchar](50) NULL,
	[qty] [int] NULL,
	[price] [float] NULL,
	[keyinman] [varchar](50) NULL,
	[rukudate] [date] NULL,
	[delearNo] [nvarchar](100) NULL, /*���뵥��*/
)


CREATE TABLE [dbo].[ChuKu](
	[countfile] [nvarchar](100) NULL,
	[partsno] [nvarchar](100) NULL,
	[serial] [nvarchar](100) NULL,
	[qty] [int] NULL,
	[price] [float] NULL,
	[keyinman] [nvarchar](100) NULL,
	[chukudate] [date] NULL
) 

/*��ά���������*/
CREATE TABLE [dbo].[INNBRUKU](
	[vender] [nvarchar](50) NULL,
	[customer] [nvarchar](50) NULL,
	[NBID] [nvarchar](50) NULL,
	[NBSerial] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[qty] [int] NULL,
	[rukudate] [date] NULL
) 

/*��ά����������*/
CREATE TABLE [dbo].[INNBCHUKU](
	[vender] [nvarchar](50) NULL,
	[customer] [nvarchar](50) NULL,
	[NBID] [nvarchar](50) NULL,
	[NBSerial] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[qty] [int] NULL,
	[chukudate] [date] NULL
) 

/*��Ʒ�����ⷿ*/
create table NBHouse
(
Id INT PRIMARY KEY IDENTITY, 
model NVARCHAR(128),/*����*/
number NVARCHAR(128), /*�������*/
)

/*��Ʒ���*/
CREATE TABLE [dbo].[OUTNBRUKU](
	[vender] [nvarchar](50) NULL,
	[customer] [nvarchar](50) NULL,
	[NBID] [nvarchar](50) NULL,
	[NBSerial] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[qty] [int] NULL,
	[rukudate] [date] NULL
)

/*��Ʒ���⣬��Ҫ����*/
CREATE TABLE [dbo].[OUTNBCHUKU](
	[vender] [nvarchar](50) NULL,
	[customer] [nvarchar](50) NULL,
	[NBID] [nvarchar](50) NULL,
	[NBSerial] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[qty] [int] NULL,
	[chukudate] [date] NULL
)

/*��Ʒ�����ϴ�������Ϣ*/
CREATE TABLE repaired_out_house_excel_table(
Id INT PRIMARY KEY IDENTITY, 
track_serial_no NVARCHAR(128) NOT NULL, /*��������*/
custom_materialNo NVARCHAR(128) NOT NULL,/*�ͻ��Ϻ�*/
declare_number NVARCHAR(128), /*���ص���*/
input_date date, /*��������*/
)

CREATE TABLE [dbo].[RatingLabel](
	[����] [nvarchar](50) NULL,
	[��ѹ] [nvarchar](50) NULL,
	[����] [nvarchar](50) NULL,
	[�Ϻ�] [nvarchar](50) NULL,
	[EAN] [nvarchar](50) NULL,
	[CPMID] [nvarchar](50) NULL,
	[CMIIT] [nvarchar](50) NULL,
	[CPU] [nvarchar](50) NULL,
	[MEM] [nvarchar](50) NULL,
	[HDD] [nvarchar](50) NULL,
	[SSD] [nvarchar](50) NULL,
	[SSHD] [nvarchar](50) NULL,
	[MSATA] [nvarchar](50) NULL,
	[LCD] [nvarchar](50) NULL,
	[WEIGHT] [nvarchar](50) NULL,
	[CCLABEL] [nvarchar](50) NULL
) 


CREATE TABLE [dbo].[NBShouLiao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[vendor] [nvarchar](128) NULL,
	[customer] [nvarchar](128) NULL,
	[NBID] [nvarchar](128) NULL,
	[NBSerial] [nvarchar](128) NULL,
	[SKU] [nvarchar](128) NULL,
	[NBSN] [nvarchar](128) NULL,
	[Model] [nvarchar](128) NULL,
	[UUID] [nvarchar](128) NULL,
	[AdapterSN] [nvarchar](128) NULL,
	[PowerCodeSN] [nvarchar](128) NULL,
	[FunctionOK] [nvarchar](128) NULL,
	[ConfigDesc] [nvarchar](128) NULL,
	[Checkman] [nvarchar](128) NULL,
	[CheckDate] [date] NULL,
	[BatterySN] [nvarchar](128) NULL,
	[BatterySN1] [nvarchar](128) NULL,
	[KBSN] [nvarchar](128) NULL,
	[LCDSN] [nvarchar](128) NULL,
	[MBSN] [nvarchar](128) NULL,
	[MBPN] [nvarchar](128) NULL,
	[MBMAC] [nvarchar](128) NULL,
	[Memory1SN] [nvarchar](128) NULL,
	[Memory2SN] [nvarchar](128) NULL,
	[HDDSN] [nvarchar](128) NULL,
	[SSDSN] [nvarchar](128) NULL,
	[WLANSN] [nvarchar](128) NULL,
	[WLANMAC] [nvarchar](128) NULL,
	[FANSN] [nvarchar](128) NULL,
	[COVERSN] [nvarchar](128) NULL,
	[BRZELSN] [nvarchar](128) NULL,
	[UPSN] [nvarchar](128) NULL,
	[LOWSN] [nvarchar](128) NULL,
	[OTHERSN] [nvarchar](128) NULL,
	[materials] [nvarchar](800) NULL,
	[RepairDesc] [nvarchar](128) NULL,
	[RepairMan] [nvarchar](128) NULL,
	[RepairDate] [date] NULL,
	[Status] [nvarchar](128) NULL,
	[NewAdapterSN] [nvarchar](128) NULL,
	[NewPowerCodeSN] [nvarchar](128) NULL,
	[PackDate] [date] NULL,
	[NewNBSerial] [nvarchar](128) NULL,
	[ShipDate] [date] NULL,

)