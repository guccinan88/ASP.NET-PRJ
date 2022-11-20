
using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryOrder.Models
{
    public class Delivery_Order
    {
        public int Id { get; set; }
        [Display(Name ="出貨產品")]
        public string ProductName { get; set; }
        [Display(Name = "出貨數量")]
        public int ProductCount { get; set; }
        [Display(Name = "客戶名稱")]
        public string Customer_Name { get; set; }
        [Display(Name = "出貨日期")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
