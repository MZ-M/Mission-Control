using System;
using System.Collections.Generic;
using System.IO;

namespace Travelling
{
    public class Logger<T>
    {
        private List<T> entries = new List<T>();

        public void Add(T entry)
        {
            entries.Add(entry);
        }

        public void Flush(string filePath)
        {
            foreach (T entry in entries)
            {
                File.AppendAllText(filePath, entry.ToString() + Environment.NewLine);
            }

            entries.Clear();
        }
    }
}