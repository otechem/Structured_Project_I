using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        private ShoppingCartItem _product1;
        private ShoppingCartItem _product2;
        private ShoppingCartItem _product3;

        public ShoppingCart(Customer aCustomer)
        {
            _customer = aCustomer;
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            if (_product1 != null && _product1.GetProduct().GetId() == prod.GetId())
            {
                _product1.SetQuantity(_product1.GetQuantity() + quantity);
                return _product1;
            }

            if (_product2 != null && _product2.GetProduct().GetId() == prod.GetId())
            {
                _product2.SetQuantity(_product2.GetQuantity() + quantity);
                return _product2;
            }

            if (_product3 != null && _product3.GetProduct().GetId() == prod.GetId())
            {
                _product3.SetQuantity(_product3.GetQuantity() + quantity);
                return _product3;
            }

            else
            {
                if(_product1 == null)
                {
                    _product1 = new ShoppingCartItem(prod, quantity);
                    return _product1;
                }

                if (_product2 == null)
                {
                    _product2 = new ShoppingCartItem(prod, quantity);
                    return _product2;
                }

                if (_product3 == null)
                {
                    _product3 = new ShoppingCartItem(prod, quantity);
                    return _product3;
                }
                return null;
            }
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            if (_product1 != null && _product1.GetProduct().GetId() == prod.GetId())
            {
                if (_product1.GetQuantity() - quantity > 0)
                {
                    _product1.SetQuantity(_product1.GetQuantity() - quantity);
                    return _product1;
                }
                _product1.SetQuantity(0);
                return _product1;
            }

            if (_product2 != null && _product2.GetProduct().GetId() == prod.GetId())
            {
                if (_product2.GetQuantity() - quantity > 0)
                {
                    _product2.SetQuantity(_product2.GetQuantity() - quantity);
                    return _product2;
                }
                _product2.SetQuantity(0);
                return _product2;
            }

            if (_product3 != null && _product3.GetProduct().GetId() == prod.GetId())
            {
                if (_product3.GetQuantity() - quantity > 0)
                {
                    _product3.SetQuantity(_product3.GetQuantity() - quantity);
                    return _product3;
                }
                _product1.SetQuantity(0);
                return _product3;
            }

            return null;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (_product1.GetProduct().GetId() == id)
            {
                return _product1;
            }

            if (_product2.GetProduct().GetId() == id)
            {
                return _product2;
            }

            if (_product3.GetProduct().GetId() == id)
            {
                return _product3;
            }

            else
            {
                return null;
            }
        }

        public decimal GetTotal()
        {
            var grandTotal = 0m;

            if (_product1 != null)
            {
                grandTotal += _product1.GetQuantity() * _product1.GetProduct().GetPrice();
            }

            if (_product2 != null)
            {
                grandTotal += _product2.GetQuantity() * _product2.GetProduct().GetPrice();
            }

            if (_product3 != null)
            {
                grandTotal += _product3.GetQuantity() * _product3.GetProduct().GetPrice();
            }

            return grandTotal;
        }

        public ShoppingCartItem GetProduct(int productNum)
        {
            if (productNum == 1)
            {
                return _product1;
            }
            
            if (productNum == 2)
            {
                return _product2;
            }

            if (productNum == 3)
            {
                return _product3;
            }

            else
            {
                return null;
            }
        }
    }
}
