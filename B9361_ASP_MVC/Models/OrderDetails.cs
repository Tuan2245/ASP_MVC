using System.ComponentModel.DataAnnotations.Schema;

namespace B9361_ASP_MVC.Models
{
	public class OrderDetails
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string OrderCode { get; set; }
		public int ProductId { get; set; }
		public float Price { get; set; }
		public int Quantity { get; set; }
        public float Total
        {
            get { return Quantity * Price; }
        }
        //[ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
	}
}
