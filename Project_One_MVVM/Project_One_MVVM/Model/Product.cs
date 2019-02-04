using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_One_MVVM.Model
{
    class Product
    {
        public Product(int productId,string productName, int productCount, string measure)
        {
            this.productId = productId;
            this.productName = productName;
            this.productCount = productCount;
            this.measure = measure;
        }
        public const string PRODUCT = "Product";
        public const string PRODUCT_ID = "productId";
        public const string PRODUCT_NAME = "productName";
        public const string PRODUCT_COUNT = "productCount";
        public const string MEASURE = "measure";

        private int productId;
        private string productName;
        private int productCount;
        private string measure;
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        

        public int ProductCount
        {
            get { return productCount; }
            set { productCount = value; }
        }
        

        public string Measure
        {
            get { return measure; }
            set { measure = value; }
        }
        public Product(int productId, string productName, string measure, int count)
        {
            this.productId = productId;
            this.productName = productName;
            this.productCount = count;
            this.measure = measure;
        }
    }
}
