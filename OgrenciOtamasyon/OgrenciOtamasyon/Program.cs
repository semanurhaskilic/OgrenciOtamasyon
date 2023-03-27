using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OgrenciOtamasyon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            file_create();
            Console.WriteLine("ÖĞRENCİ OTOMASYON SİSTEMİ");
            int choice;
            do
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz...");
               
                Console.WriteLine("(1)-Kayıt Ekle");
                Console.WriteLine("(3)-Kayıt Güncelle");
                Console.WriteLine("(4)-Kayıt Göster");
                Console.WriteLine("(5)-Kayıt Sil");
                Console.WriteLine("(6)-Not Ortalamasını Göster");
                Console.WriteLine("(2)-Çıkış");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        add_registration();
                        break;
                    case 2:
                        Console.WriteLine("Program Sonlandırıldı...");
                        break;
                    case 3:                        
                        update_registration();
                        break;
                    case 4:
                        show_registration();
                        break;
                    case 5:
                        delete_registration();
                        break;
                    case 6:
                       show_grade_average();
                        break;
                    default:
                        Console.WriteLine("Lütfen belirtilen secenekler arasından bir değer giriniz...");
                        break;
                }
            }while(choice!=6);

            Console.ReadLine(); 
        }
            static void file_create()
        {
            if (!File.Exists("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt"))
            {
                File.Create("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt");
            }
        }
            static void add_registration()
        {
            int id;
            string fullname;
            int age;
            double grade;
            Console.WriteLine("Lütfen Öğrencinin id numarasını giriniz.");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lütfen Öğrencinin ismini giriniz.");
            fullname=Console.ReadLine();
            Console.WriteLine("Lütfen Öğrencinin yaşını giriniz.");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lütfen Öğrencinin notunu giriniz.");
            grade = double.Parse(Console.ReadLine());          
            File.AppendAllText("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt",id +" "+ fullname + " " + age + " " + " " + grade +Environment.NewLine);
            Console.WriteLine();
        }
            static void update_registration()
        {
            string[] students = File.ReadAllLines("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt");
            int changeid;
            Console.WriteLine("Lütfen güncellemek istediğiniz öğrencinin id numaraısnı giriiniz...");
            changeid=int.Parse(Console.ReadLine());
            changeid--;            

            int id;
            string fullname;
            int age;
            double grade;

            int[] ids = new int[students.Length];
            string[] fullnames = new string[students.Length];
            int[] ages = new int[students.Length];
            double[] grades = new double[students.Length];
            string[] datapiece;

            int i = 0;
            foreach (string student in students)
            {
                datapiece = student.Split(' ');

                ids[i] = int.Parse(datapiece[0]);
                fullnames[i] = datapiece[1];
                ages[i] = int.Parse(datapiece[2]);
                grades[i] = double.Parse(datapiece[3]);
                i++;
            }
            int update_line_index = 0;

            while (true)
            {
                if (ids[update_line_index] == changeid)
                    break;
                update_line_index++;
            }

                id=ids[update_line_index];
                fullname=fullnames[update_line_index];
                age=ages[update_line_index];
                grade=grades[update_line_index];
            int choice;
            
                Console.WriteLine("güncellemek istediğiniz veriyi giriniz.");
                Console.WriteLine("1-) İsim değiştir.");
                Console.WriteLine("2-) yaş değiştir.");
                Console.WriteLine("3-) Not değiştir.");
            
                choice = int.Parse(Console.ReadLine());
            do
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("yeni isim değeriniz giriniz.");
                        fullname = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("yeni yaş değeriniz giriniz.");
                        age = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("yeni not değeriniz giriniz.");
                        grade = double.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Güncelleme İptal edildi!");
                        break;
                    case 5:
                        Console.WriteLine("Kayıt Silindi");
                        break;
                    default:
                        Console.WriteLine("Lütfen 1-5 arası bir seçim yapınız...");
                        break;
                }
            } while (choice > 5 || choice < 1) ;


            string newdata = changeid.ToString() + " " + fullname + " " + age.ToString() + " " + grade.ToString();
            students[update_line_index] = newdata;
            File.WriteAllLines("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt",students);
        }
            static void show_registration()
         {
            string[] students = File.ReadAllLines("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt");


            int[] ids=new int[students.Length];
            string[] fullnames=new string[students.Length];
            int[] ages=new int[students.Length];
            double[] grades=new double[students.Length];
            string[] datapiece;

            int i = 0;
            foreach (string student in students)
            {
               datapiece=student.Split(' ');

                ids[i] = int.Parse(datapiece[0]);
                fullnames[i] = datapiece[1];
                ages[i] = int.Parse(datapiece[2]);
                grades[i] = double.Parse(datapiece[3]);
                i++;
                for(i=0;i<ids.Length;i++)
                {
                    Console.WriteLine(fullnames[i] + " " + ages[i] + " " + grades[i]);
                }

            }

         }
            static void delete_registration()
        {
            string[] students = File.ReadAllLines("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt");

            int delete_id;
            Console.WriteLine("Lütfen silmek istediğiniz öğrencinin id numaraısnı giriiniz...");
            delete_id = int.Parse(Console.ReadLine());
           
            int[] ids = new int[students.Length];
            string[] fullnames = new string[students.Length];
            int[] ages = new int[students.Length];
            double[] grades = new double[students.Length];
            string[] datapiece;

            int i = 0;
            foreach (string student in students)
            {
                datapiece = student.Split(' ');

                ids[i] = int.Parse(datapiece[0]);
                fullnames[i] = datapiece[1];
                ages[i] = int.Parse(datapiece[2]);
                grades[i] = double.Parse(datapiece[3]);
                i++;
            }
            int delete_line_index = 0;

            while (true)
            {
                if (ids[delete_line_index] == delete_id)
                    break;
                delete_line_index++;
            }

            string[] new_add_registration = new string[students.Length];
            int count = 0;
            for (i = 0; i < students.Length; i++)
            {
                if (i != delete_line_index)
                {
                    new_add_registration[count] = students[i];
                    count++;
                }
            }
            File.Delete("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt");
            File.Create("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt");
            File.AppendAllLines("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt", new_add_registration);
        }            
            static void show_grade_average()
        {
            string[] students = File.ReadAllLines("C:\\Users\\SemaNur\\Desktop\\ogrenciotomasyon\\ogrencibiligleri.txt");
            double grade;
            double sum = 0;
            for (int i = 0; i < students.Length; i++)
            {
                grade = double.Parse(students[i].Split(' ')[3]);
                sum += grade;
            }
            Console.WriteLine("Öğrencileirn note ortalaması:{0}", sum / students.Length);

        }

    }
}
