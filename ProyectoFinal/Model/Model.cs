

namespace ProyectoFinal.Model
{
    // Modelos de nuestro proyecto
    public class Consumable:StoreProduct
    {

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        
        public Consumable(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public void reStocking(int auxQuantity) {
            this.Quantity += auxQuantity;
        }
    }
    public interface StoreProduct
    {
        public void reStocking(int auxQuantity);

    }

}
