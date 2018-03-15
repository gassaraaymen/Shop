using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shop
{
    public partial class MainPage : ContentPage
    {


        private List<Product> products = new List<Product>
        {

            new Product
            {
                Name = "BROWNIE HIP SUNGLASSES",
                State = "Almost New",
                Price = "770.00 SAR",
                Image = "Pic1.png",
                Category = "Accessoreis",
                IsVisible = true
            },
            new Product
            {
                Name = "BROWNIE GLASSES HOLDER",
                State = "Acceptable",
                Price = "2200 SAR",
                Image = "Pic2.png",
                Category = "Accessoreis",
                IsVisible = true
            },

            new Product
            {
                Name = "HANDBAG NATURAL LEATHER",
                State = "New",
                Price = "770.00 SAR",
                Image = "Pic3.png",
                Category = "Bags",
                IsVisible = true
            },
            new Product
            {
                Name = "CONCORD HANDWATCH",
                State = "Almost New",
                Price = "3000.00 SAR",
                Image = "Pic4.png",
                Category = "Accessoreis",
                IsVisible = true
            },

            new Product
            {
                Name = "EVENING SHOES HIGH HEAL",
                State = "Almost New",
                Price = "2200 SAR",
                Image = "Pic5.png",
                Category = "Shoes",
                IsVisible = true
            },

            new Product
            {
                Name = "BELT NATURAL LEATHER",
                State = "Almost New",
                Price = "770.00 SAR",
                Image = "Pic6.png",
                Category = "Travel",
                IsVisible = true

            }
        };



        public MainPage()
        {
            InitializeComponent();


            var productsPair = new List<ProductPair>();

            for (int i = 0; i < products.Count; i++)
            {
                if (products.Count % 2 == 0)
                {
                    productsPair.Add(new ProductPair(products[i],
                        products[i + 1]));
                }
                else
                {
                    if (i < products.Count - 1)
                    {
                        productsPair.Add(new ProductPair(products[i],
                            products[i + 1]));
                    }
                    else
                    {
                        productsPair.Add(new ProductPair(products[i], null));
                    }

                }
                i++;
            }

            ProductslistView.ItemsSource = productsPair;


        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            if (sender.Equals(Shoes))
            {
                Shoes.TextColor = Color.White;
                Shoes.FontSize = 20;
                GetDataByCategory("Shoes");
                Bag.TextColor = Color.Gray;
                Bag.FontSize = 14;
                Accessoreis.TextColor = Color.Gray;
                Accessoreis.FontSize = 14;
                Travel.TextColor = Color.Gray;
                Travel.FontSize = 14;
            }
            else if (sender.Equals(Bag))
            {
                Bag.TextColor = Color.White;
                Bag.FontSize = 20;
                GetDataByCategory("Bags");
                Shoes.TextColor = Color.Gray;
                Shoes.FontSize = 14;
                Accessoreis.TextColor = Color.Gray;
                Accessoreis.FontSize = 14;
                Travel.TextColor = Color.Gray;
                Travel.FontSize = 14;
            }
            else if (sender.Equals(Accessoreis))
            {
                Accessoreis.TextColor = Color.White;
                Accessoreis.FontSize = 20;
                GetDataByCategory("Accessoreis");
                Shoes.TextColor = Color.Gray;
                Shoes.FontSize = 14;
                Bag.TextColor = Color.Gray;
                Bag.FontSize = 14;
                Travel.TextColor = Color.Gray;
                Travel.FontSize = 14;
            }
            else if (sender.Equals(Travel))
            {
                Travel.TextColor = Color.White;
                Travel.FontSize = 20;
                GetDataByCategory("Travel");
                Shoes.TextColor = Color.Gray;
                Shoes.FontSize = 14;
                Bag.TextColor = Color.Gray;
                Bag.FontSize = 14;
                Accessoreis.TextColor = Color.Gray;
                Accessoreis.FontSize = 14;
            }
        }


        void GetDataByCategory(string category)
        {


            List<Product> searchReasult = products.Where(product => product.Category.ToLower().Contains(category.ToLower())).ToList();

            var productsPair = new List<ProductPair>();

            for (int i = 0; i < searchReasult.Count; i++)
            {
                if (searchReasult.Count % 2 == 0)
                {
                    productsPair.Add(new ProductPair(searchReasult[i],
                        products[i + 1]));
                }
                else
                {
                    if (i < searchReasult.Count - 1)
                    {
                        productsPair.Add(new ProductPair(searchReasult[i],
                            searchReasult[i + 1]));
                    }
                    else
                    {
                        productsPair.Add(new ProductPair(searchReasult[i], null));
                    }

                }


                i++;
            }
            ProductslistView.ItemsSource = productsPair;
        }





        private void FrameTapGestureRecognizer_OnTapped(object sender, EventArgs e)

        {

            Frame senderFrame = (Frame)sender;

            Product Prod = new Product();

            Prod = senderFrame.BindingContext as Product;

            DisplayAlert(Prod.Name , "Product Category : " + Prod.Category + " Product Price : " + Prod.Price,
                "Ok");

        }


        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            var keyword = MainSearchBar.Text;

            List<Product> searchReasult = products.Where(product => product.Name.ToLower().Contains(keyword.ToLower())).ToList();
            var productsPair = new List<ProductPair>();

            for (int i = 0; i < searchReasult.Count; i++)
            {
                if (searchReasult.Count % 2 == 0)
                {
                    productsPair.Add(new ProductPair(searchReasult[i],
                        products[i + 1]));
                }
                else
                {
                    if (i < searchReasult.Count - 1)
                    {
                        productsPair.Add(new ProductPair(searchReasult[i],
                            searchReasult[i + 1]));
                    }
                    else
                    {
                        productsPair.Add(new ProductPair(searchReasult[i], null));
                    }

                }


                i++;
            }
            ProductslistView.ItemsSource = productsPair;

        }






    }
}
