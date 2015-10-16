use chebohui
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USP_VIP_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[USP_VIP_ADD]
GO
------------------------------------
/*
用途：增加一条数据
表名：VIP
日期：2011/11/1 16:36:24
*/
------------------------------------
CREATE PROCEDURE USP_VIP_ADD
@Type nvarchar(10)=null,
@IsActiv nvarchar(10)=null,
@LoginId nvarchar(200)=null,
@LoginPwd nvarchar(200)=null,
@PinPai nvarchar(200)=null,
@Number nvarchar(200)=null,
@Year nvarchar(50)=null,
@Month nvarchar(50)=null,
@GongLi nvarchar(50)=null,
@Name nvarchar(50)=null,
@Sex nvarchar(50)=null,
@Age nvarchar(50)=null,
@Mobile nvarchar(50)=null,
@Phone nvarchar(50)=null,
@JiaGe nvarchar(50)=null,
@Address nvarchar(500)=null,
@LastLoginTime datetime=null,
@CardNumber nvarchar(50)=null,
@YeWuYuan nvarchar(500)=null,
@GongHao nvarchar(500)=null,
@CheJia nvarchar(500)=null,
@HuiYuanFei nvarchar(500)=null,
@QianNumber nvarchar(500)=null,
@QianBrand nvarchar(500)=null,
@HouNumber nvarchar(500)=null,
@HouBrand nvarchar(500)=null,
@Remark ntext=null,
@Status nvarchar(10)=null,
@CreateDate datetime=null,
@AdminId int=null,
@AdminName nvarchar(50)=null,
@IP varchar(15)=null,
@MAC varchar(17)=null
as
declare @strSql nvarchar(3000),@strSql1 nvarchar(1500),@strSql2 nvarchar(1500)
set @strSql = ''
set @strSql1 = ''
set @strSql2 = ''
if(@Type is not null)
begin
set @strSql1 = @strSql1 + '[Type],'
set @strSql2 = @strSql2 +'@Type,'
end
if(@IsActiv is not null)
begin
set @strSql1 = @strSql1 + '[IsActiv],'
set @strSql2 = @strSql2 +'@IsActiv,'
end
if(@LoginId is not null)
begin
set @strSql1 = @strSql1 + '[LoginId],'
set @strSql2 = @strSql2 +'@LoginId,'
end
if(@LoginPwd is not null)
begin
set @strSql1 = @strSql1 + '[LoginPwd],'
set @strSql2 = @strSql2 +'@LoginPwd,'
end
if(@PinPai is not null)
begin
set @strSql1 = @strSql1 + '[PinPai],'
set @strSql2 = @strSql2 +'@PinPai,'
end
if(@Number is not null)
begin
set @strSql1 = @strSql1 + '[Number],'
set @strSql2 = @strSql2 +'@Number,'
end
if(@Year is not null)
begin
set @strSql1 = @strSql1 + '[Year],'
set @strSql2 = @strSql2 +'@Year,'
end
if(@Month is not null)
begin
set @strSql1 = @strSql1 + '[Month],'
set @strSql2 = @strSql2 +'@Month,'
end
if(@GongLi is not null)
begin
set @strSql1 = @strSql1 + '[GongLi],'
set @strSql2 = @strSql2 +'@GongLi,'
end
if(@Name is not null)
begin
set @strSql1 = @strSql1 + '[Name],'
set @strSql2 = @strSql2 +'@Name,'
end
if(@Sex is not null)
begin
set @strSql1 = @strSql1 + '[Sex],'
set @strSql2 = @strSql2 +'@Sex,'
end
if(@Age is not null)
begin
set @strSql1 = @strSql1 + '[Age],'
set @strSql2 = @strSql2 +'@Age,'
end
if(@Mobile is not null)
begin
set @strSql1 = @strSql1 + '[Mobile],'
set @strSql2 = @strSql2 +'@Mobile,'
end
if(@Phone is not null)
begin
set @strSql1 = @strSql1 + '[Phone],'
set @strSql2 = @strSql2 +'@Phone,'
end
if(@JiaGe is not null)
begin
set @strSql1 = @strSql1 + '[JiaGe],'
set @strSql2 = @strSql2 +'@JiaGe,'
end
if(@Address is not null)
begin
set @strSql1 = @strSql1 + '[Address],'
set @strSql2 = @strSql2 +'@Address,'
end
if(@LastLoginTime is not null)
begin
set @strSql1 = @strSql1 + '[LastLoginTime],'
set @strSql2 = @strSql2 +'@LastLoginTime,'
end
if(@CardNumber is not null)
begin
set @strSql1 = @strSql1 + '[CardNumber],'
set @strSql2 = @strSql2 +'@CardNumber,'
end
if(@YeWuYuan is not null)
begin
set @strSql1 = @strSql1 + '[YeWuYuan],'
set @strSql2 = @strSql2 +'@YeWuYuan,'
end
if(@GongHao is not null)
begin
set @strSql1 = @strSql1 + '[GongHao],'
set @strSql2 = @strSql2 +'@GongHao,'
end
if(@CheJia is not null)
begin
set @strSql1 = @strSql1 + '[CheJia],'
set @strSql2 = @strSql2 +'@CheJia,'
end
if(@HuiYuanFei is not null)
begin
set @strSql1 = @strSql1 + '[HuiYuanFei],'
set @strSql2 = @strSql2 +'@HuiYuanFei,'
end
if(@QianNumber is not null)
begin
set @strSql1 = @strSql1 + '[QianNumber],'
set @strSql2 = @strSql2 +'@QianNumber,'
end
if(@QianBrand is not null)
begin
set @strSql1 = @strSql1 + '[QianBrand],'
set @strSql2 = @strSql2 +'@QianBrand,'
end
if(@HouNumber is not null)
begin
set @strSql1 = @strSql1 + '[HouNumber],'
set @strSql2 = @strSql2 +'@HouNumber,'
end
if(@HouBrand is not null)
begin
set @strSql1 = @strSql1 + '[HouBrand],'
set @strSql2 = @strSql2 +'@HouBrand,'
end
if(@Remark is not null)
begin
set @strSql1 = @strSql1 + '[Remark],'
set @strSql2 = @strSql2 +'@Remark,'
end
if(@Status is not null)
begin
set @strSql1 = @strSql1 + '[Status],'
set @strSql2 = @strSql2 +'@Status,'
end
if(@CreateDate is not null)
begin
set @strSql1 = @strSql1 + '[CreateDate],'
set @strSql2 = @strSql2 +'@CreateDate,'
end
set @strSql1 = substring(@strSql1,0,len(@strSql1))
set @strSql2 = substring(@strSql2,0,len(@strSql2))
set @strSql = 'INSERT INTO [VIP] ('+@strSql1+')VALUES('+@strSql2+')'
exec sp_executesql @strSql,N'@Type nvarchar(10),@IsActiv nvarchar(10),@LoginId nvarchar(200),@LoginPwd nvarchar(200),@PinPai nvarchar(200),@Number nvarchar(200),@Year nvarchar(50),@Month nvarchar(50),@GongLi nvarchar(50),@Name nvarchar(50),@Sex nvarchar(50),@Age nvarchar(50),@Mobile nvarchar(50),@Phone nvarchar(50),@JiaGe nvarchar(50),@Address nvarchar(500),@LastLoginTime datetime,@CardNumber nvarchar(50),@YeWuYuan nvarchar(500),@GongHao nvarchar(500),@CheJia nvarchar(500),@HuiYuanFei nvarchar(500),@QianNumber nvarchar(500),@QianBrand nvarchar(500),@HouNumber nvarchar(500),@HouBrand nvarchar(500),@Remark ntext,@Status nvarchar(10),@CreateDate datetime',@Type,@IsActiv,@LoginId,@LoginPwd,@PinPai,@Number,@Year,@Month,@GongLi,@Name,@Sex,@Age,@Mobile,@Phone,@JiaGe,@Address,@LastLoginTime,@CardNumber,@YeWuYuan,@GongHao,@CheJia,@HuiYuanFei,@QianNumber,@QianBrand,@HouNumber,@HouBrand,@Remark,@Status,@CreateDate
Declare @Id int
SET @Id = @@IDENTITY--写入添加日志
insert into WebLog (Admin_Id,Content,IP,MAC) values (@AdminId,'管理员 '+@AdminName+' 添加 表 [VIP] 编号 ['+ltrim(str(@Id))+']',@IP,@MAC)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USP_VIP_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[USP_VIP_Update]
GO
------------------------------------
/*
用途：修改一条数据
表名：VIP
日期：2011/11/1 16:36:24
*/
------------------------------------
CREATE PROCEDURE USP_VIP_Update
@ID int=null,
@Type nvarchar(10)=null,
@IsActiv nvarchar(10)=null,
@LoginId nvarchar(200)=null,
@LoginPwd nvarchar(200)=null,
@PinPai nvarchar(200)=null,
@Number nvarchar(200)=null,
@Year nvarchar(50)=null,
@Month nvarchar(50)=null,
@GongLi nvarchar(50)=null,
@Name nvarchar(50)=null,
@Sex nvarchar(50)=null,
@Age nvarchar(50)=null,
@Mobile nvarchar(50)=null,
@Phone nvarchar(50)=null,
@JiaGe nvarchar(50)=null,
@Address nvarchar(500)=null,
@LastLoginTime datetime=null,
@CardNumber nvarchar(50)=null,
@YeWuYuan nvarchar(500)=null,
@GongHao nvarchar(500)=null,
@CheJia nvarchar(500)=null,
@HuiYuanFei nvarchar(500)=null,
@QianNumber nvarchar(500)=null,
@QianBrand nvarchar(500)=null,
@HouNumber nvarchar(500)=null,
@HouBrand nvarchar(500)=null,
@Remark ntext=null,
@Status nvarchar(10)=null,
@CreateDate datetime=null,
@AdminId int=null,
@AdminName nvarchar(50)=null,
@IP varchar(15)=null,
@MAC varchar(17)=null
as
declare @strSql nvarchar(3000),@strVal nvarchar(3000)
set @strSql = ''
set @strVal = ''
if(@Type is not null)
begin
set @strVal = @strVal + '[Type] =@Type,'
end
if(@IsActiv is not null)
begin
set @strVal = @strVal + '[IsActiv] =@IsActiv,'
end
if(@LoginId is not null)
begin
set @strVal = @strVal + '[LoginId] =@LoginId,'
end
if(@LoginPwd is not null)
begin
set @strVal = @strVal + '[LoginPwd] =@LoginPwd,'
end
if(@PinPai is not null)
begin
set @strVal = @strVal + '[PinPai] =@PinPai,'
end
if(@Number is not null)
begin
set @strVal = @strVal + '[Number] =@Number,'
end
if(@Year is not null)
begin
set @strVal = @strVal + '[Year] =@Year,'
end
if(@Month is not null)
begin
set @strVal = @strVal + '[Month] =@Month,'
end
if(@GongLi is not null)
begin
set @strVal = @strVal + '[GongLi] =@GongLi,'
end
if(@Name is not null)
begin
set @strVal = @strVal + '[Name] =@Name,'
end
if(@Sex is not null)
begin
set @strVal = @strVal + '[Sex] =@Sex,'
end
if(@Age is not null)
begin
set @strVal = @strVal + '[Age] =@Age,'
end
if(@Mobile is not null)
begin
set @strVal = @strVal + '[Mobile] =@Mobile,'
end
if(@Phone is not null)
begin
set @strVal = @strVal + '[Phone] =@Phone,'
end
if(@JiaGe is not null)
begin
set @strVal = @strVal + '[JiaGe] =@JiaGe,'
end
if(@Address is not null)
begin
set @strVal = @strVal + '[Address] =@Address,'
end
if(@LastLoginTime is not null)
begin
set @strVal = @strVal + '[LastLoginTime] =@LastLoginTime,'
end
if(@CardNumber is not null)
begin
set @strVal = @strVal + '[CardNumber] =@CardNumber,'
end
if(@YeWuYuan is not null)
begin
set @strVal = @strVal + '[YeWuYuan] =@YeWuYuan,'
end
if(@GongHao is not null)
begin
set @strVal = @strVal + '[GongHao] =@GongHao,'
end
if(@CheJia is not null)
begin
set @strVal = @strVal + '[CheJia] =@CheJia,'
end
if(@HuiYuanFei is not null)
begin
set @strVal = @strVal + '[HuiYuanFei] =@HuiYuanFei,'
end
if(@QianNumber is not null)
begin
set @strVal = @strVal + '[QianNumber] =@QianNumber,'
end
if(@QianBrand is not null)
begin
set @strVal = @strVal + '[QianBrand] =@QianBrand,'
end
if(@HouNumber is not null)
begin
set @strVal = @strVal + '[HouNumber] =@HouNumber,'
end
if(@HouBrand is not null)
begin
set @strVal = @strVal + '[HouBrand] =@HouBrand,'
end
if(@Remark is not null)
begin
set @strVal = @strVal + '[Remark] =@Remark,'
end
if(@Status is not null)
begin
set @strVal = @strVal + '[Status] =@Status,'
end
if(@CreateDate is not null)
begin
set @strVal = @strVal + '[CreateDate] =@CreateDate,'
end
set @strVal = substring(@strVal,0,len(@strVal));
set @strSql = 'update [VIP] set '+@strVal+' where ID ='+str(@ID);
exec sp_executesql @strSql,N'@Type nvarchar(10),@IsActiv nvarchar(10),@LoginId nvarchar(200),@LoginPwd nvarchar(200),@PinPai nvarchar(200),@Number nvarchar(200),@Year nvarchar(50),@Month nvarchar(50),@GongLi nvarchar(50),@Name nvarchar(50),@Sex nvarchar(50),@Age nvarchar(50),@Mobile nvarchar(50),@Phone nvarchar(50),@JiaGe nvarchar(50),@Address nvarchar(500),@LastLoginTime datetime,@CardNumber nvarchar(50),@YeWuYuan nvarchar(500),@GongHao nvarchar(500),@CheJia nvarchar(500),@HuiYuanFei nvarchar(500),@QianNumber nvarchar(500),@QianBrand nvarchar(500),@HouNumber nvarchar(500),@HouBrand nvarchar(500),@Remark ntext,@Status nvarchar(10),@CreateDate datetime',@Type,@IsActiv,@LoginId,@LoginPwd,@PinPai,@Number,@Year,@Month,@GongLi,@Name,@Sex,@Age,@Mobile,@Phone,@JiaGe,@Address,@LastLoginTime,@CardNumber,@YeWuYuan,@GongHao,@CheJia,@HuiYuanFei,@QianNumber,@QianBrand,@HouNumber,@HouBrand,@Remark,@Status,@CreateDate
--写入修改日志
insert into WebLog (Admin_Id,Content,IP,MAC) values (@AdminId,'管理员 '+@AdminName+' 修改 表 [VIP] 编号 ['+ltrim((@Id))+']',@IP,@MAC)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USP_VIP_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[USP_VIP_GetModel]
GO
------------------------------------
/*
用途：得到实体对象的详细信息
表名：VIP
日期：2011/11/1 16:36:24
*/
------------------------------------
CREATE PROCEDURE USP_VIP_GetModel
@ID int
AS
	SELECT [ID],[Type],[IsActiv],[LoginId],[LoginPwd],[PinPai],[Number],[Year],[Month],[GongLi],[Name],[Sex],[Age],[Mobile],[Phone],[JiaGe],[Address],[LastLoginTime],[CardNumber],[YeWuYuan],[GongHao],[CheJia],[HuiYuanFei],[QianNumber],[QianBrand],[HouNumber],[HouBrand],[Remark],[Status],[CreateDate] FROM [VIP] WHERE ID=@ID
GO