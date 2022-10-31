<h1>WIP系統</h1>
<p>在SQL SERVER建立一張WIP資料表用來存放生產相關資料</p>
<p>Table Schema:Id(nchar(10)),Model(nvarchar(50)),WorkStation(nchar(10)),Machine(nchar(10)),
Total_Count(int),Produced_Count(int)</p>
<p>後端使用Controller提供路由並返回一個頁面</p>
<p>前後端通訊使用RESTful API+AJAX操作CRUD</p>
<p>後續可將API操作資料庫功能額外封裝在SERVICE，讓API的工作更單純</p>
<p>若要在生產環境上線，SQL建議使用正規化分割成多表關聯</p>