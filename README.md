# WebAPI

- Tecnologais: C#, Aps.net MVC, Framework=4.6.2
- Comunicação de dados com SQL Server
- Script de dados no arquivo:  nas pasta do projeto ScriptsDB, arquivo : ScripotDbAssociado.sql
- Configuração do ceonx~]ao com banco em: Web.Config : 
  <connectionStrings>
    <add name="PVProautoEntities"       connectionString="metadata=res://*/Models.ModeloAssociados.csdl|res://*/Models.ModeloAssociados.ssdl|res://*/Models.ModeloAssociados.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=localhost\sql2019;initial catalog=PVProauto;persist security info=True;user id=sa;password=123456;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
