using System;
using System.Collections.Generic;

namespace Travelling
{
    public class RouteManager<T>
    {
        private List<T> items = new List<T>();
        public List<T> GetItems()
        {
            return items;
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public int Count
        {
            get { return items.Count; }
        }
        
        public override string ToString()
        {
            string result = string.Join( " -> ", items);
            return result; 
        }
    }
}