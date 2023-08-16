using HW_Reflection;
using System.Threading.Tasks;

class Program
{
    public static void Main(string[] args)
    {
        //Class changer
        Changing changer = new Changing();

        //Task 1
        ChangebleTask1 task1 = new ChangebleTask1();
        Task1_Checker(changer, ref task1);

        //Task 2
        ChangebleTask2 task2 = new ChangebleTask2();
        Task2_Checker(changer, ref task2);

        //Task 3
        ChangebleTask3 task3 = new ChangebleTask3();
        Task3_Checker(changer, ref task3);

        ChangebleTask4 task4 = new ChangebleTask4();
        changer.AttributeOnClass_Task4(task4);
    }
    public static void Task1_Checker(Changing changer, ref ChangebleTask1 task1)
    {
        Console.WriteLine($"...Task1\n\nBefore changing: Id: {task1.Id}, Age: {task1.Age}");

        changer.PrivateChanger_Task1(task1);

        Console.WriteLine($"After changing: Id: {task1.Id}, Age: {task1.Age}");

    }

    private static void Task2_Checker(Changing changer, ref ChangebleTask2 task2)
    {
        Console.WriteLine($"\n...Task2\n\nBefore changing: Id: {task2.Id}, Name: {task2.Name} ,IsHuman: {task2.IsHuman}");

        changer.PrivateChanger_WithAutoTypeFinder_Task2(task2);

        Console.WriteLine($"After changing: Id: {task2.Id}, Name: {task2.Name} ,IsHuman: {task2.IsHuman}");
    }

    private static void Task3_Checker(Changing changer, ref ChangebleTask3 task3)
    {
        Console.WriteLine($"\n...Task3\n\nBefore changing:\n" +
            $"(attr)Id: {task3.Id}, (attr)Name: {task3.Name} ,(attr)IsHuman: {task3.IsHuman}\n" +
            $"(no attr)Id: {task3.IdNoAttr}, (no attr)Name: {task3.NameNoAttr} ,(no attr)IsHuman: {task3.IsHumanNoAttr}\n");

        changer.PrivateAndAttribute_ChangerWithAutoTypeFinder_Task3(task3);

        Console.WriteLine($"After changing:\n" +
            $"(attr)Id: {task3.Id}, (attr)Name: {task3.Name} ,(attr)IsHuman: {task3.IsHuman}\n" +
            $"(no attr)Id: {task3.IdNoAttr}, (no attr)Name: {task3.NameNoAttr} ,(no attr)IsHuman: {task3.IsHumanNoAttr}");
    }
}
