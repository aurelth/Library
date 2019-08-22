using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Category
    {

        private int _categoryId;
        private int _parentId;
        private string _name;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Category(int categoryId, int parentId, string name)
        {
            _categoryId = categoryId;
            _parentId = parentId;
            _name = name;
        }
    }

    public class CategoryCollection : List<Category>
    {

        public CategoryCollection()
            : base()
        {
        }
    }
}
