using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Expander_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<Product> Products;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadPreviewData();
        }

        private void LoadPreviewData()
        {
            Products = new BindingList<Product>()
            {
                new Product("Смарт-часы \"TechTime Pro\"", "Эти смарт-часы оснащены AMOLED-дисплеем, отслеживанием сердечного ритма, GPS и множеством фитнес-функций. " +
                "Водонепроницаемые до 50 метров, с поддержкой уведомлений и до 10 дней автономной работы.", 199.99m, DateTime.Now),
                new Product("Рюкзак \"Urban Explorer\"", "Стильный и функциональный рюкзак для городских жителей. Вмещает ноутбук до 15 дюймов, имеет много карманов для аксессуаров и защищен от воды. " +
                "Идеально подходит для учебы и работы.", 59.99m, DateTime.Now)
            };
            foreach (Product p in Products)
            {
                productsListBox.Items.Add(CreateProductExpander(p));
            }
        }
        private Expander CreateProductExpander(Product product)
        {
            Expander expander = new Expander()
            {
                Header = product.Name
            };

            StackPanel stackPanel = new StackPanel();
            TextBlock priceTextBlock = new TextBlock()
            {
                Text = $"Цена : {product.Price}$",
                FontWeight = FontWeights.Bold
            };
            TextBlock descriptionTextBlock = new TextBlock()
            {
                Text = $"\nОписание : {product.Description}",
                FontWeight = FontWeights.Bold
            };

            TextBlock addDateTextBlock = new TextBlock()
            {
                Text = $"\nВремя добавления : {product.AddDate}",
                FontStyle = FontStyles.Italic
            };
            expander.Tag = product;
            stackPanel.Children.Add(priceTextBlock);
            stackPanel.Children.Add(descriptionTextBlock);
            stackPanel.Children.Add(addDateTextBlock);

            expander.Content = stackPanel;
            return expander;
        }
        private void RefreshExpander()
        {
            productsListBox.Items.Clear();
            foreach (Product p in Products)
            {
                productsListBox.Items.Add(CreateProductExpander(p));
            }
        }
        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.AddProduct += AddProductForm_AddProduct;
            addProductForm.ShowDialog();
        }

        private void AddProductForm_AddProduct(Product obj)
        {
            Products.Add(obj);
            RefreshExpander();
        }

        private void deleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if(productsListBox.SelectedItem != null)
            {
                Products.Remove((productsListBox.SelectedItem as Expander).Tag as Product);
                RefreshExpander();
            }           
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }

    public class Product
    {
        public Product(string name, string description, decimal price, DateTime addTime)
        {
            Name = name;
            Description = description;
            Price = price;
            AddDate = addTime;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime AddDate { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}