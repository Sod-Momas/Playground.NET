# ���ʹ��docker��װMS SQL Server

����Ҫ��
- Docker ����汾 1.8+
- 3.25 GB ���ϵĿ����ڴ�
- ���»�������
    -  `ACCEPT_EULA=Y`
    -  `SA_PASSWORD=<your_strong_password>`
    -  `MSSQL_PID=<your_product_id | edition_name> (default: Developer)`
- ��ǿ�����루8λ��Сд��ĸ���ּӷ��ţ�

> �������ʹ�� PowerShell����ѵ������滻��˫���ţ�Ĭ���û��� `sa`�������� `yourStrong(!)Password`

```
# *nix ����
docker pull mcr.microsoft.com/mssql/server:2017-latest
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

```
# PowerShell
docker pull mcr.microsoft.com/mssql/server:2017-latest
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```


## �ο�����

- [microsoft-mssql-server - Docker Hub](https://hub.docker.com/_/microsoft-mssql-server)