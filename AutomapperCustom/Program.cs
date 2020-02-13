using AutomapperCustom.Models;
using AutomapperTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCustom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var listOfElelement = new List<ChildrenElements>() {
                new ChildrenElements() { CityName = "Lahore", SchoolName = "City School Lahore" },
                new ChildrenElements() { CityName = "Karachi", SchoolName = "City School Karachi" }
            };
            var chilCollection = new ChildrenCollection() { DefaultValue = -2, FullName = "Children Name 2", Enabled = true };
            listOfElelement.ForEach(r => chilCollection.Add(r));
            IChildren children1 = new Children() { Name = "Fahad", FatherName = "Anwar UL Haq", childrenCollection = chilCollection };
            Children children2 = new Children(children1, true);
            Children children3 = new Children(children1, false);
            Console.WriteLine("Source Object Values are... ");
            /////////////////////////////////////////////////////////////////////
            ////            Children 1                                        ///
            /////////////////////////////////////////////////////////////////////
            PrintProperties(children1, 1);
            Console.WriteLine("/////////////////////////////////////////////////");
            /////////////////////////////////////////////////////////////////////
            ////            Children 2 After Generic Map                      ///
            /////////////////////////////////////////////////////////////////////
            PrintProperties(children2, 1);
            Console.WriteLine("/////////////////////////////////////////////////");
            /////////////////////////////////////////////////////////////////////
            ////            Children 3 After Assembly Map                              ///
            /////////////////////////////////////////////////////////////////////
            PrintProperties(children3, 1);
            Console.ReadLine();
        }
        public static void PrintProperties(object obj, int indent)
        {
            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                var elems = propValue as IList;
                if (elems != null)
                {
                    foreach (var item in elems)
                    {
                        PrintProperties(item, indent + 3);
                    }
                }
                else
                {
                    // This will not cut-off System.Collections because of the first check
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        Console.WriteLine("{0}{1}:", indentString, property.Name);

                        PrintProperties(propValue, indent + 2);
                    }
                    else
                    {
                        Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                    }
                }
            }
        }
    }

}
