# 使用ChartJS + .NET Core將各縣市米價圖表化
<h1>Controller程式碼內容</h1>
<p>使用DI方式將IHostingEnvironment介面注入控制器，用來取得環境資訊，這裡是用來取得工作目錄</p>
<p>GetDate方法將西元年轉換成民國年，這裡需要注意的是日期格式必須是"yyy.M.d"</p>
<p>每日的米價資料來自於農委會的API，所以使用HttpClient類別請求與接收HTTP</p>
<p>將取得的資料寫入RicePrice.json</p>
<p>因取得的資料類型是JSON，為了方便操作所以透過JsonConvert.DeserializeObject反序列為LIST類型</p>
<p>Chart.js所需要的資料是城市名稱與每日價格，所以透過LINQ查詢並將查詢結果放入ViewBag</p>
<p>Action分別設置GET方法的Index與POST方法的Index，GET方法是初步進入頁面，POST方法則是回應查詢結果</p>
<hr>
<h1>Index View程式碼內容</h1>
<p>進入頁面只有查詢日期控制項</p>
<P>按下查詢之後會將日期傳送到POST方法的Index</p>
<p>ViewBag.Status用來判斷是否有查詢資料，若為true則呼叫Partil View</p>
<h1>Partial View程式碼內容</h1>
<p>Partial View純粹用來顯示Chart.js圖表內容</p>
<p>使用Newtonsoft Package將ViewBag內容序列化成JSON類型</p>
<p>圖表所顯示的資料只有城市名稱與當日米價</p>