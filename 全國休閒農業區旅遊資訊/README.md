<h1>使用農業開放資料服務平台的JSON資料，設計出全國休閒農業區旅遊資訊</h1>
1.首先先到農業開放資料服務平台網站將全國休閒農業區旅遊資訊的JSON資料存到專案內JSON資料夾，並命名為ODwsvAttractions.json<br>
2.在NuGet安裝Json.NET套件Newtonsoft.Json<br>
3.Controller內的Index Action為頁面首頁<br>
4.另外再準備HTTP POST連線的Index Action用來接收城市搜尋並將搜尋返回到View<br>
5.NET使用JSON資料須透過反序列化，所以Action內使用Newtonsoft.Json的JsonConvert.DeserializeObject方法<br>
6.前端頁面使用select標籤選擇城市<br>
7.JSON資料內城市資料會有重複，所以使用HashSet不重複值資料結構特性儲存城市<br>
8.將所得到的城市資料存到ViewBag，前端頁面使用此Model內容<br>
9.後續可再修改部分:<br>
select標籤城市搜尋完之後不會停留在目前城市<br>
地圖頁面需轉向到Google Map，可更改成使用Bootstrap的Modal方式顯示<br>
農業開放資料服務平台的JSON資料可修改成透過GET方式取得<br>