数据源支持ServerSql和MySQL

数据源更换步骤
	1.修改业务层BusinessService.cs中对应的数据驱动服务类型
		a. SqlServer对应的数据驱动服务:	SqlServerDataService dataService = new SqlServerDataService()
		b. MySql对应的数据驱动服务：		MySqlDataService dataService = new MySqlDataService()
	2.修改Web.config中对应的数据库连接文件，改成对应的数据库类型


SqlServer导出到MySql的技巧
	1.安装mysql-connector-net-x.x.x.msi(http://dev.mysql.com/downloads/connector/net)
	2.通过SqlServer的数据导入导出功能复制数据到MySql


MySql部署要求
	1.服务器安装mysql-connector-net-x.x.x.msi(http://dev.mysql.com/downloads/connector/net)
	2.安装IIS服务