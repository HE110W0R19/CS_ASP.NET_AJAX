using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Reflection
{
    internal class Changing
    {
        public void PrivateChanger_Task1(object someClass)
        {
            var type = someClass.GetType();
            var fields = type.GetFields(
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static | 
                System.Reflection.BindingFlags.Instance);

            foreach ( var field in fields )
            {
                field.SetValue(someClass, (field.GetValue(someClass) as int?) * 2);
            }
        }

        public void PrivateChanger_WithAutoTypeFinder_Task2(object someClass)
        {
            var type = someClass.GetType();
            var fields = type.GetFields(
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (field.FieldType.FullName == "System.String")
                {
                    field.SetValue(someClass, (field.GetValue(someClass) as string) + "/Broken/");
                }
                else if (field.FieldType.FullName == "System.Int32")
                {
                    field.SetValue(someClass, (field.GetValue(someClass) as int?) + 10);
                }
                else if (field.FieldType.FullName == "System.Boolean")
                {
                    field.SetValue(someClass, !(field.GetValue(someClass) as bool?));
                }
            }
        }

        public void PrivateAndAttribute_ChangerWithAutoTypeFinder_Task3(object someClass)
        {
            var type = someClass.GetType();
            var fields = type.GetFields(System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Static);

            foreach (var field in fields)
            {
                var attrs = field.CustomAttributes;
                foreach (var attr in attrs)
                {
                    if (attr.AttributeType.Name == "MyModifiedAttribute")
                    {
                        switch (field.GetValue(someClass))
                        {
                            case bool _:
                                field.SetValue(someClass, !(field.GetValue(someClass) as bool?));
                                break;
                            case int _:
                                field.SetValue(someClass, (field.GetValue(someClass) as int?) + 10);
                                break;
                            case string _:
                                field.SetValue(someClass, (field.GetValue(someClass) as string) + "/Broken/");
                                break;
                        }
                    }
                }
            }
        }
    }
}
