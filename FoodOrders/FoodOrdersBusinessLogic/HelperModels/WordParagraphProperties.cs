using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.HelperModels
{
    class WordParagraphProperties
    {
        public List<(string, WordTextProperties)> Texts { get; set; }
        public WordTextProperties TextProperties { get; set; }
    }
}
