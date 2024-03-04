using ZILab2;

class Program
{
    static void Main(string[] args)
    {
        int SubjectsInSystem = 8;
        int objectsForAccess = 3;

        List<string> names = new List<string>() { "Дамир", "Андрей", "Булат", "Айнур", "Русик", "Марсель", "Николай" };
        List<User> Users = new List<User>() { };
        List<string> data = new List<string>() { };

        string AdminName = "Данил";
        int[] AdminAccess = new int[objectsForAccess];

        for (int i = 0; i < objectsForAccess; i++) 
            AdminAccess[i] = 7;

        Users.Add(new User(AdminName, AdminAccess, objectsForAccess));
        data.Add(AdminName);

        Random tim = new Random();
        for (int i = 0; i < (SubjectsInSystem - 1); i++)
        {
            int[] UserAccess = new int[objectsForAccess];
            for (int j = 0; j < objectsForAccess; j++)
            {
                UserAccess[j] = tim.Next(0, 7);
            }
            string UserName = names[i];
            Users.Add(new User(UserName, UserAccess, objectsForAccess));
            data.Add(UserName);
        }

        while (true)
        {
            Console.WriteLine("Введите ваше имя: ");
            string enter_name = Console.ReadLine();
            if (Users.Any(x => x.Name == enter_name))
            {
                Console.WriteLine("Идентификация прошла успешно. Добро пожаловать, " + enter_name + ". \n");
                var user = Users.FirstOrDefault(x => x.Name == enter_name);
                user?.right();
                user?.direct(Users);
            }
            else if (enter_name == "Выход")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("Такого пользователя нет \n");
            }
        }
    }
}
