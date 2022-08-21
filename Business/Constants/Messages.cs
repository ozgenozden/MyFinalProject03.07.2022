using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 tane ürün olabilir.";
        public static string ProductCountOfProductNameError = "Aynı isimde bir ürün eklenemez";
        public static string CategoryLimitExceded = "Kategori limiti aşıldı.";
    }
}
