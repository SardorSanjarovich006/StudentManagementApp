using StudentManagementApp.Aplication;
using StudentManagementApp.Domain.Interfaces;
using StudentManagementApp.Infrastucture.Data;
using StudentManagementApp.Infrastucture.Repositories;

namespace StudentManagementApp.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();
            IStudentRepository repo = new StudentRepository(db);
            StudentService service = new StudentService(repo);

            while (true)
            {
                Console.WriteLine("\n=== STUDENT MANAGEMENT ===");
                Console.WriteLine("1. Student qo‘shish");
                Console.WriteLine("2. Studentni o‘zgartirish");
                Console.WriteLine("3. ID bo‘yicha qidirish");
                Console.WriteLine("4. Name bo‘yicha qidirish");
                Console.WriteLine("5. Barcha studentlarni ko‘rish");
                Console.WriteLine("6. ID bo‘yicha o‘chirish");
                Console.WriteLine("0. Chiqish");
                Console.Write("Tanlang: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 0)
                    break;

                switch (choice)
                {
                    case 1:
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Ism Familiya: ");
                        string name = Console.ReadLine();

                        Console.Write("Yosh: ");
                        int age = int.Parse(Console.ReadLine());

                        service.Add(id, name, age);
                        Console.WriteLine("Student qo‘shildi!");
                        break;

                    case 2:
                        Console.Write("O‘zgartiriladigan ID: ");
                        int uid = int.Parse(Console.ReadLine());

                        Console.Write("Yangi ism: ");
                        string uname = Console.ReadLine();

                        Console.Write("Yangi yosh: ");
                        int uage = int.Parse(Console.ReadLine());

                        if (service.Update(uid, uname, uage))
                            Console.WriteLine("Yangilandi!");
                        else
                            Console.WriteLine("Topilmadi!");
                        break;

                    case 3:
                        Console.Write("ID kiriting: ");
                        int sid = int.Parse(Console.ReadLine());

                        var st = service.GetById(sid);
                        if (st == null) Console.WriteLine("Topilmadi!");
                        else Console.WriteLine($"{st.Id} | {st.FullName} | {st.Age}");
                        break;

                    case 4:
                        Console.Write("Ism kiriting: ");
                        string nm = Console.ReadLine();

                        foreach (var s in service.GetByName(nm))
                            Console.WriteLine($"{s.Id} | {s.FullName} | {s.Age}");
                        break;

                    case 5:
                        foreach (var s in service.GetAll())
                            Console.WriteLine($"{s.Id} | {s.FullName} | {s.Age}");
                        break;

                    case 6:
                        Console.Write("O‘chiriladigan ID: ");
                        int did = int.Parse(Console.ReadLine());

                        if (service.Delete(did))
                            Console.WriteLine("O‘chirildi!");
                        else
                            Console.WriteLine("Topilmadi!");
                        break;

                    default:
                        Console.WriteLine("Noto‘g‘ri tanlov!");
                        break;

                }
            }
        }
    }
}
