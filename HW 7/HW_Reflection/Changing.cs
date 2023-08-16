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

            foreach (var field in fields)
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

        public void AttributeOnClass_Task4(object someClass)
        {
            var type = someClass.GetType();

            var fields = type.GetFields(System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Static);

            object[] attrs = type.GetCustomAttributes(true);

            foreach (var attr in attrs)
            {
                MyModifiedAttribute MyAtr = attr as MyModifiedAttribute;
                if (MyAtr != null)
                {
                    switch (MyAtr.TargetType.Name.ToLower())
                    {
                        case "int32":
                            if (MyAtr.TargetModificationValue.ToString().ToLower() == "add 10")
                            {
                                foreach (var field in fields)
                                {
                                    switch (field.GetValue(someClass))
                                    {
                                        case int _:
                                            field.SetValue(someClass, (field.GetValue(someClass) as int?) + 10);
                                            break;
                                    }
                                }
                            }
                            break; 

                        case "string":
                            if (MyAtr.TargetModificationValue.ToString().ToLower() == "add broken")
                            {
                                foreach (var field in fields)
                                {
                                    switch (field.GetValue(someClass))
                                    {
                                        case string _:
                                            field.SetValue(someClass, (field.GetValue(someClass) as string) + "/Broken/");
                                            break;
                                    }
                                }
                            }
                            break;

                        case "boolean":
                            if (MyAtr.TargetModificationValue.ToString().ToLower() == "inversion")
                            {
                                foreach (var field in fields)
                                {
                                    switch (field.GetValue(someClass))
                                    {
                                        case bool _:
                                            field.SetValue(someClass, !(field.GetValue(someClass) as bool?));
                                            break;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
