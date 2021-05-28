# MessageBoard 莫莫砂留言板

使用ASP.NET 实现的留言板

## 如何启动

1. 请安装 .NET Framework 4.7.2
2. 保存在本地启动了Microsoft SQL Server ，用户名为 `sa`，密码为 `yourStrong(!)Password` (该配置在 `Web.config` 里，可以修改)
3. 有可用于部署的 IIS 服务器，或使用 Visual Studio 启动 IIS Express, 即可访问

## 数据库DDL 

```sql
-- 用户信息表，用于存储用户信息
create table t_user_info
(
    uname varchar(50) primary key,
    upwd varchar(50),
    uemail varchar(50),
    ulevel varchar(50),
    uquestion Nvarchar(100),
    uanswer varchar(100)
)
go

-- 留言表，用于存储用户的留言信息
create table t_message
(
    mid int primary key identity(1,1),
    muser varchar(50) not null foreign key(muser) references t_user_info(uname),
    mcontent NvarChar(MAX),
    mtime datetime default getdate()
)
GO
```

> version 2017 移植于 2021.05.29