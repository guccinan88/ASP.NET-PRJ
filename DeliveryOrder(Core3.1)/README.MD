<h1>基於ASP.NET CORE框架的出貨單</h1>
<dl>
<dt>開發環境及工具</dt>
<dd>VS2022</dd>
<dd>MS-SQL 2019</dd>
<dd>Core3.1425</dd>
<dd>第一次使用需在命令視窗安裝dotnet ef(dotnet tool install --global dotnet-ef)</dd>
<dd>Microsoft.EntityFrameworkCore.Tools @3.1.31</dd>
<dd>Microsoft.EntityFrameworkCore.SqlServer @3.1.31</dd>
<dd>Microsoft.EntityFrameworkCore.Design @3.1.31</dd>
</dl>
<dl>
<dt>建立DBContext類別</dt>
<dt>appsettings.json新增資料庫連線</dt>
<dt>在DI Container中註冊DBContext，若未註冊使用Add-Migration指令會出錯</dt>
<dt>在PM控制台新增Migration</dt>
<dd>Add-Migration InitDB(InitDB代表異動名稱)</dd>
<dt>更新資料庫</dt>
<dd>Update-Database</dd>
</dl>
<p>資料庫產生之後會看到一筆種子資料</p>