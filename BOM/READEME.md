#使用ViewModel打造一個Bom表
分別建立存放產品(Product)與物料(Material)兩個資料表
產品資料表欄位:ProductId(PK)、ProductName、ProductSize、ProductDescription
物料資料表欄位:ProductId(FK_Prdocut.ProductId)、MaterialId(PK)、MaterialName、MaterialModel、MaterialDescription
欲建立的物料資料表所對應的產品必須存在