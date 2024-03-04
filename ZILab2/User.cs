namespace ZILab2
{
    class User
    {
        private string _name;
        private int[] _access;
        private int _objectsForAccess;

        public User(string name, int[] access, int O)
        {
            this._name = name;
            this._access = access;
            this._objectsForAccess = O;
        }

        public string Name { get =>  _name; }

        public void modif(int num, string ri)
        {
            if (ri == "Чтение")            
                this._access[num] = this._access[num] | 4;            

            if (ri == "Запись")            
                this._access[num] = this._access[num] | 2;            

            if (ri == "Передача прав")            
                this._access[num] = this._access[num] | 1;            
        }

        public void right()
        {
            Console.WriteLine("Ваши права");
            for (int i = 0; i < this._objectsForAccess; i++)
            {
                int userRights = this._access[i];
                int read = (userRights / (int)Math.Pow(2, (3 - 1))) % 2;
                int write = (userRights / (int)Math.Pow(2, (2 - 1))) % 2;
                int rgh = (userRights / (int)Math.Pow(2, (1 - 1))) % 2;
                if (read == 1 && write == 1 && rgh == 1)
                {
                    Console.WriteLine("Файл" + (i + 1) + ": Полные права");
                }
                else
                {
                    string rez = "Файл" + (i + 1).ToString() + ": ";
                    if (read == 1) rez += "Чтение. ";
                    if (write == 1) rez += "Запись. ";
                    if (rgh == 1) rez += "Передача прав. ";
                    if (read == 0 && write == 0 && rgh == 0) rez += "Запрет.";
                    Console.WriteLine(rez);
                }
            }
        }

        public void direct(List<User> obj)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите команду (Чтение, Запись, Передача прав, Выход): ");
                    string command = Console.ReadLine();
                    if (command == "Чтение")
                    {
                        Console.WriteLine("Введите номер файла: ");
                        int num_obj = Convert.ToInt32(Console.ReadLine());
                        int userRights = this._access[num_obj - 1];
                        int read = (userRights / (int)Math.Pow(2, (3 - 1))) % 2;
                        if (read == 1)
                        {
                            Console.WriteLine("Операция прошла успешно. \n");
                        }
                        else Console.WriteLine("Отказ в выполнении операции. Вы не обладаете соответствующими правами. \n");
                    }

                    else if (command == "Запись")
                    {
                        Console.WriteLine("Введите номер файла: ");
                        int num_obj = Convert.ToInt32(Console.ReadLine());
                        int userRights = this._access[num_obj - 1];
                        int write = (userRights / (int)Math.Pow(2, (2 - 1))) % 2;
                        if (write == 1)
                        {
                            Console.WriteLine("Операция прошла успешно. \n");
                        }
                        else Console.WriteLine("Отказ в выполнении операции. Вы не обладаете соответствующими правами. \n");
                    }
                    else if (command == "Передача прав")
                    {
                        Console.WriteLine("Право на какой объект передаётся?");
                        int num_obj = Convert.ToInt32(Console.ReadLine());
                        int userRights = this._access[num_obj - 1];
                        int rgh = (userRights / (int)Math.Pow(2, (1 - 1))) % 2;
                        if (rgh == 1)
                        {
                            Console.WriteLine("Какое право передаётся?");
                            string ri = Console.ReadLine();
                            int read = (userRights / (int)Math.Pow(2, (3 - 1))) % 2;
                            int write = (userRights / (int)Math.Pow(2, (2 - 1))) % 2;
                            if ((ri == "Чтение" && read == 1) || (ri == "Запись" && write == 1) || (ri == "Передача прав" && rgh == 1))
                            {
                                Console.WriteLine("Какому пользователю передаётся право? Введите имя пользователя: ");
                                string recievedRightsUserName = Console.ReadLine();
                                foreach (User user in obj)
                                {
                                    if (recievedRightsUserName == user.Name)
                                    {
                                        user.modif(num_obj - 1, ri);
                                        Console.WriteLine("Передача произошла успешно. \n");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Невозможно передать права, которых нет. \n");
                            }
                        }
                        else if (rgh == 0)
                        {
                            Console.WriteLine("Отказ в выполнении операции. Вы не обладаете соответствующими правами. \n");
                        }

                    }

                    else if (command == "Выход")
                    {
                        Console.WriteLine("Осуществлён выход из системы. Всего доброго, " + this._name + ". \n\n");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Некорректный ввод. \n");
                    }

                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. \n");
                }
            }
        }

    }
}
