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

insert into t_user_info values ( 'admin', 'C33367701511b4f6020ec61ded352059', 'adm@163.com', 'admin', N'你是哪里人', '8FF1BF5F2845959D00BCE4799AA79A99');
insert into t_message (muser,mcontent) values ('admin', N'留言');