
using ProyectoFinal.Controller;
using ProyectoFinal.Model;
using System;
using System.Net.Http.Headers;
using System.Reflection.Emit;

namespace View
{

    class View
    {
        

        static void Main(string[]args)
        {
            Console.WriteLine("--------BIENVENIDO A LA MÁQUINA EXPENDEDORA DE PRODUCTOS CONSUMIBLES---------");

            List<Consumable> Products = new List<Consumable>()
            {
                new Consumable("Doritos", 4000,2),
                new Consumable("Pepsi", 3000,2),
                new Consumable("Chocolatina", 2000,2),
                new Consumable("Agua", 1000,2),

            };
            Controller<Consumable> controller = new Controller<Consumable>(Products);

            Console.WriteLine("----Este es el menú principal, para salir de la máquina, escriba la palabra *** salir ***----\n");

            do
            {
                Console.WriteLine("¿Es cliente o proveedor?");

                //Input del usuario que indica si es cliente o proveedor
                string input_client_type = Console.ReadLine();


                try
                {

                    if (input_client_type == "cliente")

                    {
                        Console.WriteLine("----------------\n");
                        Console.WriteLine("*** Ingrese la cantidad de dinero a pagar ***");

                        int input_client_money = Convert.ToInt32(Console.ReadLine());

                        if (input_client_money > 1000)
                        {
                            Console.WriteLine("----------------\n");
                            Console.WriteLine("*** Listado de productos ***");
                            foreach (Consumable product in controller.GetProducts())
                            {
                                if (product.Quantity <= 0)
                                {
                                    Console.WriteLine($"Producto: {product.Name} , producto no disponible");
                                }
                                else
                                {
                                    Console.WriteLine($"Producto: {product.Name} , precio: $ {product.Price}");
                                }

                            }

                            Consumable objProduct = null;
                            var nameProductInput = "";
                            while (true)
                            {
                                Console.WriteLine("----------------\n");
                                Console.WriteLine("*** Ingrese el producto a comprar ***");
                                nameProductInput = Console.ReadLine();
                                Console.WriteLine("----------------\n");
                                objProduct = controller.Products.Find(x => x.Name == nameProductInput);
                                if (objProduct != null)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("---¡El producto no existe! ingreselo nuevamente---\n");
                                }
                            }



                            if (objProduct.Quantity > 0)
                            {
                                if (input_client_money >= objProduct.Price)
                                {
                                    Console.WriteLine($"---El producto {nameProductInput} fue comprado---");
                                    objProduct.Quantity -= 1;
                                    var valuecallback = input_client_money - objProduct.Price;
                                    var moneyBack500 = valuecallback / 500;
                                    if (valuecallback % 500 != 0)
                                    {
                                        valuecallback = valuecallback - (moneyBack500 * 500);
                                        var moneyBack200 = valuecallback / 200;
                                        if (valuecallback % 200 != 0)
                                        {
                                            valuecallback = valuecallback - (moneyBack200 * 200);
                                            var moneyBack100 = valuecallback / 100;
                                            if (valuecallback % 100 != 0)
                                            {
                                                valuecallback = valuecallback - (moneyBack100 * 100);
                                                var moneyBack50 = valuecallback / 50;
                                                Console.WriteLine($"Su regreso son {moneyBack50} monedas de 50");
                                            }
                                            Console.WriteLine($"Su regreso son {moneyBack100} monedas de 100");
                                        }
                                        Console.WriteLine($"Su regreso son {moneyBack200} monedas de 200");
                                    }
                                    Console.WriteLine($"Su regreso son {moneyBack500} monedas de 500");

                                    Console.WriteLine($"****La operación terminó*****\n");
                                }
                                else
                                {
                                    Console.WriteLine("*** Dinero insuficiente para ese producto ***\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("--- El producto no esta disponible ---\n");
                            }

                        }
                        else
                        {
                            Console.WriteLine("*** Debe ingresar una cantidad de dinero mayor a mil ***\n");
                        }
                    }


                    else if (input_client_type == "proveedor")
                    {
                        while (true)
                        {
                            Console.WriteLine("--- Agregue el producto en el siguiente formato: nombre, precio, cantidad ---");


                            //Func<int, int, int> sum = (x,y)=> x + y;

                            //Func<string, int> convert = (x) => Convert.ToInt32(x);


                            //Action<string> print = (x) =>
                            // {
                            //Console.WriteLine(x);
                            //Console.WriteLine(x + "Hola");
                            // };

                            string input_product = Console.ReadLine();


                            string[] product_values = input_product.Split(',');//[nombre , precio , cantidad] product_values[1]

                        

                                var objConsumable = controller.Products.Find(x => x.Name == product_values[0]);
                                if (objConsumable != null)
                                {
                                    objConsumable.reStocking(Convert.ToInt32(product_values[2]));
                                    Console.WriteLine("*** El Restocking del producto fue actualizado ***\n");
                                }
                                else
                                {
                                    var roundPrice = Math.Round(Convert.ToDecimal(product_values[1]) / 50, 0) * 50;
                                    Consumable product = new Consumable(
                                    product_values[0],
                                    Convert.ToInt32(roundPrice),
                                    Convert.ToInt32(product_values[2])
                                  //Agregar un producto
                                  );
                                    controller.AddProduct(product);
                                    Console.WriteLine("*** ¡Producto ingresado exitosamente!, el resultado de la operación ***\n");
                                    Console.WriteLine($"Producto: {product_values[0]}, cantidad de productos: {product_values[2]}, precio: {roundPrice}");
                                }
                            


                        }




                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("*** Ingrese un valor adecuado ***\n");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\nIngrese los  valores, separados por coma (,) ");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ocurrio un error, intentelo de nuevo");
                }
            } while (true);

        }
    }
}
