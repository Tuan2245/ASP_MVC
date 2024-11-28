namespace B9361_ASP_MVC.Models
{
    public class CartItemModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public float Total 
        {
            get {  return Quantity*Price; }            
        }
        public CartItemModel() { }
		public CartItemModel(ProductModel product) 
        {
            ProductId = product.Id;
            ProductName = product.Name;
            Price = product.Price;
            Quantity = 1;
            Image = product.Image;
        }

	}
}
