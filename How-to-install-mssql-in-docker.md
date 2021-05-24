# 如何使用docker安装MS SQL Server

环境要求：
- Docker 引擎版本 1.8+
- 3.25 GB 以上的可用内存
- 以下环境变量
    -  `ACCEPT_EULA=Y`
    -  `SA_PASSWORD=<your_strong_password>`
    -  `MSSQL_PID=<your_product_id | edition_name> (default: Developer)`
- 高强度密码（8位大小写字母数字加符号）

> 如果您是使用 PowerShell，请把单引号替换成双引号；默认用户是 `sa`，密码是 `yourStrong(!)Password`

```
# *nix 环境
docker pull mcr.microsoft.com/mssql/server:2017-latest
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

```
# PowerShell
docker pull mcr.microsoft.com/mssql/server:2017-latest
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```


## 参考链接

- [microsoft-mssql-server - Docker Hub](https://hub.docker.com/_/microsoft-mssql-server)