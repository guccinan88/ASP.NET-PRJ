<h1>使用ViewModel打造一個Bom表</h1>
分別建立存放產品(Product)與物料(Material)兩個資料表<br>
產品資料表欄位:ProductId(PK)、ProductName、ProductSize、ProductDescription<br>
物料資料表欄位:ProductId(FK_Prdocut.ProductId)、MaterialId(PK)、MaterialName、MaterialModel、MaterialDescription<br>
欲建立的物料資料表所對應的產品必須存在<br>