using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCrudSystem.Class
{
    public class Elements
    {
        int lists = 0;
        public List<MyItem> items = new List<MyItem>()
        {

        };
        public List<MyItem> itemses = new List<MyItem>()
        {

        };
        public List<Korzina> korzinas = new List<Korzina>()
        {

        };
        public List<Korzina> korzinass = new List<Korzina>()
        {

        };
        public List<MyItem> delete_korzina(int l, List<MyItem> list)
        {
            vivodmain();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Loopback, 8080);
            using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);    
            List<MyItem> people = new List<MyItem>();
            people.Add(new MyItem(list[l].name2, list[l].cena2, list[l].kol2, list[l].opis2, list[l].img2, list[l].cat));
            string json = JsonSerializer.Serialize(people);
            socket.Send(Encoding.UTF8.GetBytes(json));
            string[] paslog = JsonSerializer.Deserialize<string>(File.ReadAllText("Malik.json")).Split(";");
            string text2 = "";
            list.RemoveAt(l);
            string qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("korzina.json"));
            string[] arr = qwe.Split(";");
            for (int i = 0; i < arr.Length; i++)
            {
                string[] kizi = arr[i].Split("?");
                string[] polzovateli = kizi[0].Split("!");
                string[] us1 = kizi[1].Split("%");
                string[] us = us1[0].Split(",");
                if (polzovateli[0].ToString() != paslog[0] && polzovateli[1].ToString() != paslog[1])
                {
                    korzinas.Add(new Korzina(polzovateli[0], polzovateli[1], us[0], us[1], us[2], us[3], us[4], us[1]));
                }
            }
            using (StreamWriter sws = new StreamWriter("korzina.json"))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list.Count == 0) { }
                    else
                    {
                        if (i == 0)
                        {
                            text2 += paslog[0] + "!" + paslog[1] + "?" + items[l].name2 + "," + items[l].cena2 + "," + items[l].kol2 + "," + items[l].opis2 + "," + items[l].img2 + "%" + items[i].cat;
                        }
                        else
                        {
                            text2 += ";" + paslog[0] + "!" + paslog[1] + "?" + items[l].name2 + "," + items[l].cena2 + "," + items[l].kol2 + "," + items[l].opis2 + "," + items[l].img2 + "%" + items[i].cat;
                        }
                    }
                }
            }
            for (int i = 0; i < korzinas.Count; i++)
            {
                if (text2 == "" || text2 == null)
                {
                    text2 += korzinas[i].login + "!" + korzinas[i].password + "?" + korzinas[i].name2 + "," + korzinas[i].cena2 + "," + korzinas[i].kol2 + "," + korzinas[i].opis2 + "," + korzinas[i].img2 + "%" + korzinas[i].kat;
                }
                else
                {
                    text2 += ";" + korzinas[i].login + "!" + korzinas[i].password + "?" + korzinas[i].name2 + "," + korzinas[i].cena2 + "," + korzinas[i].kol2 + "," + korzinas[i].opis2 + "," + korzinas[i].img2 + "%" + korzinas[i].kat;

                }
            }
            File.WriteAllText("korzina.json", JsonSerializer.Serialize(text2));

            return list;

        }
        public List<MyItem> vivod_kor()
        {
            List<MyItem> itemsess = new List<MyItem>()
            {

            };
            string[] paslog;
            using (StreamReader sr = new StreamReader("Malik.json"))
            {
                paslog = JsonSerializer.Deserialize<string>(sr.ReadToEnd()).Split(";");
            }
            string qwe = "";
            using (StreamReader sr = new StreamReader("korzina.json")) { qwe = sr.ReadToEnd(); }
            try
            {
                if (!string.IsNullOrEmpty(qwe))
                {
                    string text2 = JsonSerializer.Deserialize<string>(qwe);
                    string[] arr = text2.Split(";");
                    for (int i = 0; i < arr.Length; i++)
                    {
                        string[] kizi = arr[i].Split("?");
                        string[] polzovateli = kizi[0].Split("!");
                        string[] us1 = kizi[1].Split("%");
                        string[] us = us1[0].Split(",");
                        if (polzovateli[0].ToString() == paslog[0] && polzovateli[1].ToString() == paslog[1])
                        {
                            itemsess.Add(new MyItem(us[0], us[1], us[2], us[3], us[4], us1[1]));
                        }
                    }
                    return itemsess;
                }
            }
            catch
            {
                MessageBox.Show("корзина пуста");
            }
            return null;
        }
        public void kor_add(int l, string log, string pass, int r)
        {
            string qwe = "";
            vivodmain();
            if (!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(log))
            {
                using (StreamReader sr = new StreamReader("korzina.json")) { qwe = sr.ReadToEnd(); }
                if (!string.IsNullOrEmpty(qwe))
                {
                    string text2 = JsonSerializer.Deserialize<string>(qwe);
                    string[] arr = text2.Split(";");

                    using (StreamWriter sws = new StreamWriter("korzina.json"))
                    {
                        for (int i = 0; i < arr.Length; i += 6)
                        {
                            if (arr.Length == 0 || arr[0] == "")
                            {
                                if (r <= Convert.ToInt32(items[l].kol2))
                                {
                                    text2 += log + "!" + pass + "?" + items[l].name2 + "," + items[l].cena2 + "," + r.ToString() + "," + items[l].opis2 + "," + items[l].img2 + "%" + items[l].cat;
                                }
                                else
                                {
                                    MessageBox.Show("максимум товаров");
                                }
                            }
                            else
                            {
                                if (r <= Convert.ToInt32(items[l].kol2))
                                {
                                    text2 += ";" + log + "!" + pass + "?" + items[l].name2 + "," + items[l].cena2 + "," + r.ToString() + "," + items[l].opis2 + "," + items[l].img2 + "%" + items[l].cat;
                                }
                                else
                                {
                                    MessageBox.Show("максимум товаров");
                                }
                            }
                        }
                        sws.Write(JsonSerializer.Serialize(text2));
                    }
                }
                else
                {
                    using (StreamWriter sws = new StreamWriter("korzina.json"))
                    {
                        sws.Write(JsonSerializer.Serialize(log + "!" + pass + "?" + items[l].name2 + "," + items[l].cena2 + "," + items[l].kol2 + "," + items[l].opis2 + "," + items[l].img2 + "%" + items[l].cat));
                    }
                }
            }
        }
        public void vivodmain()
        {
            try
            {
                string text1 = File.ReadAllText("tovar.json");
                if (!string.IsNullOrEmpty(text1))
                {

                    string text2 = JsonSerializer.Deserialize<string>(text1);
                    string[] arr = text2.Split(';');
                    for (int i = 0; i < arr.Length; i += 6)
                    {
                        items.Add(new MyItem(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4], arr[i + 5]));
                        Tovar tovar = new Tovar(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4]);
                    }
                }
            }
            catch { }
        }
        public void delete_admin(int l)
        {
            vivodmain();
            string text2 = "";
            items.RemoveAt(l);
            for (int i = 0; i < items.Count; i++)
            {
                if (i == 0)
                {
                    text2 += items[i].name2 + ";" + items[i].cena2 + ";" + items[i].kol2 + ";" + items[i].opis2 + ";" + items[i].img2 + ";" + items[i].cat;
                }
                else
                {
                    text2 += ";" + items[i].name2 + ";" + items[i].cena2 + ";" + items[i].kol2 + ";" + items[i].opis2 + ";" + items[i].img2 + ";" + items[i].cat;
                }
            }
            File.WriteAllText("tovar.json", JsonSerializer.Serialize(text2));
        }
        public void update(string nametovtext1, string nameopistext1, string namekoltext1, string namecwenatext1, dynamic nameimgtext1, int l, string category)
        {
            delete_admin(l);
            add_admin(nametovtext1, nameopistext1, namekoltext1, namecwenatext1, nameimgtext1, category);
        }
        public void add_admin(string nametovtext1, string nameopistext1, string namekoltext1, string namecwenatext1, dynamic nameimgtext1, string category)
        {
            vivodmain();
            string text;
            string asd;
            bool goornot;
            using (StreamReader sr = new StreamReader("tovar.json"))
            {
                asd = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(asd))
                {
                    goornot = false;
                }
                else
                {
                    goornot = true;
                }
            }
            if (goornot)
            {
                using (StreamWriter sw = new StreamWriter("tovar.json"))
                {
                    string te = nametovtext1 + ";" + nameopistext1 + ";" + namekoltext1 + ";" + namecwenatext1 + ";" + nameimgtext1 + ";" + category;
                    string personJson = JsonSerializer.Serialize(te);
                    sw.Write(personJson);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("tovar.json"))
                {
                    text = JsonSerializer.Deserialize<string>(asd);
                    if (text != "")
                    {
                        string te = text + ";" + nametovtext1 + ";" + nameopistext1 + ";" + namekoltext1 + ";" + namecwenatext1 + ";" + nameimgtext1 + ";" + category;
                        string personJson = JsonSerializer.Serialize(te);
                        sw.Write(personJson);
                    }
                    else
                    {
                        string te = nametovtext1 + ";" + nameopistext1 + ";" + namekoltext1 + ";" + namecwenatext1 + ";" + nameimgtext1 + ";" + category;
                        string personJson = JsonSerializer.Serialize(te);
                        sw.Write(personJson);
                    }
                }
            }

        }
    }
}
