using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;

namespace OgrenciKayıt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yol = @"C:\Users\cihan\OneDrive\Desktop\\";
            string dosya = @"Kayıt.txt";
            string dosya2 = @"Liste.txt";
            string full = yol + dosya;
            string full2 = yol + dosya2;

            if (File.Exists(full))
            {
                Console.WriteLine("DOSYA BULUNDU");
            }
            else
            {
                Console.WriteLine("DOSYA BULUNAMADI...");
                Thread.Sleep(1000);
                File.WriteAllText(full, "admin | 1234" + Environment.NewLine);
                Console.WriteLine("OLUŞTURULDU");
            }

            if (!File.Exists(full2))
            {
                Console.WriteLine("LİSTE BULUNAMADI...");
                Thread.Sleep(1000);
                File.Create(full2).Close();
                Console.WriteLine("OLUŞTURULDU");
            }
            else
            {
                Console.WriteLine("LİSTE BULUNDU");
            }

            while (true)
            {
                Console.WriteLine("--------\n1.Kayıt\n2.Giriş\n3.Çıkış\n--------");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.Write("Kullanıcı Adı: ");
                    string ad = Console.ReadLine();
                    Console.Write("Şifre: ");
                    string şifre = Console.ReadLine();

                    string kfull = ad + " | " + şifre;
                    string[] kontrol = File.ReadAllLines(full);

                    if (kontrol.Length > 0 && kontrol[0] == kfull)
                    {
                        Console.WriteLine("Admin Girişi Yapıldı");
                        while (true)
                        {
                            Console.WriteLine("--------\n1.Öğrenci Ekle\n2.Liste Oluştur\n3.Çıkış\n--------");
                            int cevap = Int32.Parse(Console.ReadLine());
                            if (cevap == 1)
                            {
                                Console.Write("Kullanıcı Adı: ");
                                string kullanıcı = Console.ReadLine();

                                Console.Write("Şifre: ");
                                string şif = Console.ReadLine();

                                string ekle = kullanıcı + " | " + şif;
                                File.AppendAllText(full, ekle + Environment.NewLine);
                            }
                            else if (cevap == 2)
                            {
                                Console.Write("--------\nÖğrenci Giriniz: ");
                                string öğrenci = Console.ReadLine();
                                string listele = " | " + öğrenci;
                                File.AppendAllText(full2, listele + Environment.NewLine);
                            }
                            else if (cevap == 3)
                            {
                                break;
                            }
                            else
                                Console.WriteLine("TANIMLANAMADI");
                        }
                    }
                    else
                    {
                        Console.WriteLine("İŞLEM BAŞARISIZ");
                    }
                }
                else if (secim == "2")
                {
                    Console.Write("Kullanıcı Adı: ");
                    string ad = Console.ReadLine();
                    Console.Write("Şifre: ");
                    string şifre = Console.ReadLine();

                    string gfull = ad + " | " + şifre;
                    string[] giriş = File.ReadAllLines(full);
                    bool bulundu = false;

                    for (int i = 1; i < giriş.Length; i++)
                    {
                        if (giriş[i] == gfull)
                        {
                            bulundu = true;
                            Console.WriteLine("GİRİŞ BAŞARILI");

                            while (true)
                            {
                                Console.WriteLine("--------\n1.Liste\n2.Çıkış");
                                int cevap = Int32.Parse(Console.ReadLine());
                                if (cevap == 1)
                                {
                                    string list = File.ReadAllText(full2);
                                    Console.WriteLine("--------\n" + list);
                                }
                                else if (cevap == 2)
                                    break;
                                else
                                    Console.WriteLine("TANIMLANAMADI");
                            }
                            break;
                        }
                    }

                    if (!bulundu)
                    {
                        Console.WriteLine("GİRİŞ BAŞARISIZ");
                    }
                }
                else if (secim == "3")
                {
                    Console.WriteLine("Kapatılıyor...");
                    Thread.Sleep(1000);
                    break;
                }
                else
                    Console.WriteLine("TANIMLANAMADI");
            }
        }
    }
}
