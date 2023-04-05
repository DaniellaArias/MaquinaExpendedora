using ProyectoFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Controller
{
    public class Controller<T>

    {
        public List<T> Products { get; set; }

        public Controller(List<T> products)
        {

            this.Products = products;

        }

        public List<T> GetProducts()
        {
            return this.Products;
        }

        public bool AddProduct(T consumable)
        {
            int last_size = this.Products.Count;

            this.Products.Add(consumable);
             
            if(this.Products.Count > last_size && this.Products[this.Products.Count-1] != null)
            { 
            return true;
            }
            else
            {
                return false;
            }
        }

    }
       
    
}
