using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.ComponentModel;
using System.Timers;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    public class Program : System.Windows.Forms.Form
    {
        static string base64chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        static bool controlupdate = false;
        bool girdigirmedi = false;
        public static string g_oyun;
        public static string loginkey = "";
        public static bool autoreconnect = false;
        public static string servicename1 = "";
        public static string servicename2 = "";

        private static System.Timers.Timer myTimer1 = new System.Timers.Timer();
        private System.Timers.Timer myTimer6 = new System.Timers.Timer();

        private TextBox textBox5;
        private Button button1;
        private Button button2;
        private Button button3;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private Label label1;
        private LinkLabel linkLabel1;
        public static List<string> hadibuloc = new List<string>();
        private Button button6;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox textBox4;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Label label2;
        private static string ServerIP = "164.132.233.203";


        [STAThreadAttribute]
        static void Main()
        {
            Application.Run(new Program());
        }
        public Program()
        {
            InitializeComponent();
            this.ResumeLayout(false);
            this.Text = "Minecraft";
            LoadConfig();
            myTimer6.Interval = 100;
            myTimer6.Elapsed += MyTimer6_Elapsed;
            myTimer6.Start();
            control = true;
            byte[] key2 = new byte[] {
189,
121,
222,
117,
172,
128,
191,
23,
36,
169,
121,
233,
132,
171,
57,
227,
178,
194,
24,
160,
163,
227,
249,
46,
76,
128,
93,
107,
193,
155,
143,
209
            };
            byte[] iv2 = Encoding.UTF8.GetBytes("qGt07Pp8GSS5Zmdg");
            byte[] cipherarray = Encoding.UTF8.GetBytes("ULLuBt3tuGX8nLeJ");

            string url3 = "24.133.249.85|BFEBFBFF000306D41EB918F9|005056C00001|Ad_Soyad|4/DESKTOP-SRHBRSN/DESKTOP-SRHBRSN\\User/1|UkZOak5FRkVlRkpGZW1OVlJubzBibEJUTkRsRVZuQmlSMVJqVWxGdVdXOUpVbFYxU0hjd05FZHFVbmxLWjFVMVkwVlJXRlpwVVZGSVVqbGpaVVJaTVZWbk1FcE1VM1JZU1hoelBRPT0=|BSN12345678901234567|bbbbbbbb|Windows8|VTJsSmEwRm5VbXBHVTAxTFVIaG9VME51T1c1SmEyczBTMEpqWlZoU2MxWkphV05KU25kamJXSkhRa1JXYUc5cVJEQlJORXRuWTFSRGQyOUhSSGd3WmxwbmJ6ZE1WREUzWTBFd1MweENWVFpWWnpScVJVRnNaRU5UTUhKV2VVMWlSVk5qV1VOUlBUMD0=|V0hwdlJFWjZOVkJMYVRGRlRsRnZXa3Q1WjBWaWEwa3ZTbmR2UTFocE5IQlRhVEJ5UW14TmNFVlJRamxDYW5RclFqSkJhMFI2WXpCRWVqZzRTVU0wZEdSNmNHRkdla0ZIVDBKWmJFRlVORnBFZVc5SVRsRm9Za05UTUhKV2VVMWlSVk5qV1VOUlBUMD0=|asustekcomputerinc.|X555LNB|UkZaSldrRXpORVZPYkZsNVRHZzBObFpUYTFKQldFbHFTa0pyV2xKUmMwSlNTRUZaUTFGamRVNXFWbE5FVVd0MA==|UkZaSmFVWjZNVmhCZURGRlFXbHZPRWhDYjBaR1ZtZEZRVVJyYTFsNVZWWlJXRkZaUTFGamRVNXFWbE5FVVd0MA==|UkZOd1pXVlNkRlZQTVZwWlRGUXdjVWxTVmpkSlNFazRVVU5OWTFKVVFVdERhbVJQU0VFd05raDRVbTVMVkVvMlFXeEpUMFI0WTNsRlFWa3pUa2RCVmtOQlkybExVbXd3U2tGRk1FbDVjMlJKYVRBclNWZHZUVU5EYXpkVmQyeE1SVmhCU2tsVE1FTlFlbXhDUVZGM1RrbHVZMFJQYWxFNFJVWm5kR1o1WTNobFozTkZTM2wwVWtrd05GSkJaMjlIUVhkelZGcHVlRVZJVWxWVVdVSkZNRTVDZHk5TlZXOXJSM2xDUjBSUmJ6bFFNVWx3UkhoSmQwMXBWVXRJZVVWdVpVTTBjV1JwUWxkTmVsRXlTMmhTWVZoVWIwRkpSbXRGUkhwVlkySklRVXhMYmxWd1QzcFJkbG95T0daSlFWbERVRWRqYzFCRVkxaFVaM2N4Wm1oelpsZ3hjMkpLZDA1WlJrTnpWbUpyYjFwQ1FXZDNTbXRWSzFkVVoxcFJVV2M1U0VoSk1rZDNkMjVJYVdSdldFWjNZVTlWUmpSUVJITjVVV3BzVW1WVVdURlZaekJLVEZOMFdFbDRjejA9|0|WVZGTmJrWlNhMEZGZHpScVFrRXdSRUYzWXpGWmQwVXZTMUZ3TlZSNGEzZFJWRTVPUVZRNE5VVnBPVUZITVdnMFpsaG5jVTlEVFRGUVExVnlaVkY0T0ZKVWMwOUVSSGhUVG5kTmQyWkRTV05JTXpoelpVRldaVU5UTUhKV2VVMWlSVk5qV1VOUlBUMD0=|UkZOQlVFTlliMGhqZWxWc1VFSkphRUZ1T0M5UVFWSmpUMWgzU0ZWM1VYQkhNMDVKUkdsUlJreFNSbTVKZDAxMFQxWjBNVVYzUVdkT1V6VldabnBaTVZWbk1FcE1VM1JZU1hoelBRPT0=|UkZGM1UwTnFOV1pMZWxwTFExVTBZME4zWkM5T1oxVkpTR28wZDFoNVdsZElTRlV6VnpGUlYwNTZXbU5ZYWtsd1EyMVJVVXRUVVcxSVFVNVNaVlJaTVZWbk1FcE1VM1JZU1hoelBRPT0=|UkZaS1lrRjNPVk5LYVhOaFpHdEpaMHBuYzJsYVFWbElTbE5qZDFwQmIyWlNia0ZaUTFGamRVNXFWbE5FVVd0MA==|UkZGQ1ZFZHFlSFpOUTJzMFFtbEpOMWhFTUZwYVNFbGpUWGxSYVdWWVVVOVNhbmRpUWtKallsQkVVbXhZUTBGMVdXdzBaMUJGUlRGSlExSmtabnBaTVZWbk1FcE1VM1JZU1hoelBRPT0=|UkZRMFMwNTNPWGhFYUhOR1JGTnJRVTVCVVdKTlNHZEZUMEpaWVZKNU9VdEtiVFJsU2tRd2FFaEVXa0ZRZVZVdlJURnJWVTFvWnpCVE1YUlNaVlJaTVZWbk1FcE1VM1JZU1hoelBRPT0=|VWtGQmIwRlliR2hPYTNjeVFVUm5MMEZuU1RoUFVWRkVWMVJ2VkZocWMxbEtWRVZ2VWtaQlQwVnFiMGRCWnpSaFNsVlpiRk5VU1ZCRVEwVlVaRlJCV2xkNmJHSkNRVGt6UmtNME1rMVNSVzVEZW5kU1IzZGtZME5UTUhKV2VVMWlSVk5qV1VOUlBUMD0=";
            string url2 = "31.210.107.200|BFEBFBFF00008619009E577A|54728E590C77|Kranello_Layne|8/Monster/3\\5/2|UkZNMFRVaHBhRk5EUkVWU1JYcHpaRTFvV25ObVJVRkhWM3AwYlVGVGQxUkxWMjl3VldsT05FSkVSbFZQYUUxc1JIZFJXRWxUYzFaSFJrcFVaVWRhYTBOV09XUm1VVEJFUVd0M1BRPT0=|CC220C03C1CE8D|1469882A|Windows10|VjNoV1FVa3pOVGhFYVd0bFJUQk5Ra2gzUlRaT1ZuTmhWM2ROT0VKRFkwRkxkMjl2UlZGak5FVlRZMlpFUVVseFJHeEZSVWw0YjBSRlF6UnVVRk14ZGxwVE1ITkllRFZWUmxSblFWQkRiMlJKZURndlVHZGFZbGhJTVRsQlVVNVBVVzR4U2t0blBUMD0=|UW5kWmMwSkNiR2xIVkhCR1NrSnpVRUZSTVc1WldHZE5UMU5GVkZsb1RVMUpRamhhUld0d2FrSnRWbXRNYVRoa1dXeDNORkZDV1dsRWR6bGtTMUZSZFVoM05FOWxVVXA1WkdoQmJrWjRRV2hGYVRSMFFVRmFZa3R1YkRaQ1FVcExVVmhLVEZoM1BUMD0=|hp|DESKTOP-086131|UkZaSlRVdG5TbnBIUlVGeVJubEJSMHhFYTI1SFZVVkpVRUl3ZGtSUmQyZFNXRVpKUzBaWlQySkNXakJNUmpVeg==|UkZaSmEyVjZUbVJEVWsxUlEwTjRXVWxJTkVSSU1UUmxSMmN3TmtKNWMweFRNMUpNV0ZaalNrVlNTbnBYUm10Tw==|UkZJNFIwZFlNRU5qVkRRelNtcDNia1JuVFc1SlNFMHJXR2xaWWxoQlZrOUtlVEIzU21kd09FOVJZMEpHVmpVMVRGWlJia1Y1UlVOSlFWRlJUR2haUm1OM1RXTkNXSGhpWTJ0dk4xQlVjMDVOZVVFMlJHNXpSa2Q1Vm5oYVEzTmpSV2RaVkVOV1kydE5ha3BpUzFGalMyVllaMUJHYTFWbVEyZFJiazlIZHpaRFJITlFabWwwT1U5RlFUaE1lREE0UkRNeGJrVXlVVGRWWjNBMVFtbHZNRXBJV1VOUGFXaHVUVmRCU0ZBeE5EZEpNV3RMVG1wM2NsTlJWbVJJVkdjMFVYaGpTVVJJUm5STFFrVkdUbmhOVkZadWEyaE9WMWxLVEc1NE5tTklVVlpIUVhoUFFVSkpaVUZVVW1oSGJHdFBXbTVqTkU5R1oxTk5kMk4xVDIxWlprTlNZMWxMVW1oYVQxTm5jR1I0VlhwTWFtZEdURmhSYzB4UmRHbEJaMUpPVDBFNGRVb3hNRWRQYVZGaVMyd3dhRTlXYUhsSlVWbFFTRkU1WkdaWE1YWkRVM2hsWm1kelRXTjZiejA9|0|Wkdvd2FraFNRbUpMUlRCUlRucDNTMVZwVG0xT2JrazBUVzR3WWtKdVZVdEpVVEIwVEdzMGFrRnBOVGhZYkVvM1dXNHdhVk13V1ZaVGFVMXpTRUZSUldWblowSkRRVlpJUkdkdlptUkRjRmxMVkRRMFQxRk9ZMWRSTVRkRVdFcE5VMjVhVFV0blBUMD0=|UkZKcmVFWm9PVGhLZWpoR1FrTndZa1puYTNSR1dGRkJWME5vTDFwNlNYRkhTSGhRUVhsRlFVWm9OWEZKUVVGeFQydFNNa1pCVlhSTFEwNVhaakpCVkdNeGRHWkRkekYzUVd0RlBRPT0=|UkZSclNHWllSbU5EZDBWTVJXY3dSRmhEYTFsTlJtTXhVRkZLSzJScE9EQlFkMEZ4VUhwRmNVbEhTa2xDYkc5c1JWWnpkVkJuU1dSTU1VNVhaakpXYWtGRGNHVmxkMjlHWTFWelBRPT0=|UkZaSmJGQjVUbWRHUVRoclFXcFpSVUZwWkd0RlNHODFSMUpyY1ZGRE5IUlJTRnBFVEd4Q0sxcFNTakZYTVRFMw==|UkZGV1dVaDZiR2RNVkVreFVGTnJaMVZUUVdORU1HTkNUME5yZG1Ob2MweExWRVpOUVZGblpVNHlPV2RPZVRFMVdXeE9NMEY1VVhWTWVVWlhaakpTYW1Oc05XRmxibmRHWTJ0blBRPT0=|UkZRd1RVSnVPRUZrUkZseFFuaEZiVVF6YnpaUFVXUmFVRzVyV1ZoQmEzRkhTSGhRUVhsRlFVWm9OWEZKUVVGeFQydFNNa1pCVlhSTFEwNVhabmhrWjBJeGRHUmxTRGt5UVd0RlBRPT0=|UWtSemVHWnBaMFpLUWxWblRtazRZVVpFWnpORVZVWlhWM2RCYkZsNWEzbFJkelJWUzBOalNFRm9NVWxFVWsxMFVGaGpSMDlCVFdsRVZHeFZSa2RSTjJaNVFVaExiakV3UVVVMFkwcHFUbVZOVXpCdFduZE9ZMWRJZDB0alFVNUtVVmhGSzB4blBUMD0=";

            foreach (string za in url2.Split('|'))
            {

                if (za.Length > 50 || za.EndsWith("="))
                {
                    try
                    {
                        string zaza = Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(za))))));
                        string qweqeqwe = XORdecrypt(zaza, Encoding.UTF8.GetString(cipherarray));
                        string qweasd = nullagar(qweqeqwe);
                        //Console.WriteLine(qweasd);
                        //Console.WriteLine("OLD " + DecryptString2(qweasd, key2, iv2));
                    }
                    catch
                    {
                        //Console.WriteLine("hatalı : " + za);

                    }
                }
                else
                {
                    //Console.WriteLine("OLD ---> " + za);

                }
            }

            foreach (string za in url3.Split('|'))
            {

                if (za.Length > 50 || za.EndsWith("="))
                {
                    try
                    {
                        string zaza = Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(za))))));
                        
                        string qweqeqwe = XORdecrypt(zaza, Encoding.UTF8.GetString(cipherarray));
                        string qweasd = nullagar(qweqeqwe);
                        //Console.WriteLine(qweasd);
                      //  Console.WriteLine("NEW " + DecryptString2(qweasd, key2, iv2));
                    }
                    catch
                    {
                        //Console.WriteLine("hatalı : " + za);

                    }
                }
                else
                {
                    //Console.WriteLine("NEW ---> " + za);

                }
            }
        }

        public static string saboAGA(string input)
        {
            int za = (int)input.ToCharArray()[10];
            return input.Remove(10, 1).Insert(10, ((char)(za + 74)).ToString());
        }

        public static string saboAGAR(string input)
        {
            int za = (int)input.ToCharArray()[10];
            Console.WriteLine(za);

            return input.Remove(10, 1).Insert(10, ((char)(za - 74)).ToString());
        }

        private void MyTimer6_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (checkBox3.Checked && autoreconnect)
            {
                startGame();
                autoreconnect = false;
            }
        }

        public static string RSAEncrypt()
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "WL5olLAi9R1QvnkemXzy";
            param.Flags = CspProviderFlags.UseMachineKeyStore;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = System.Text.Encoding.Default.GetBytes(rsa.CspKeyContainerInfo.UniqueKeyContainerName);
                byte[] encryptdata = rsa.Encrypt(plaindata, false);
                string encryptstring = Convert.ToBase64String(encryptdata);
                
                return encryptstring;
            }
        }

        public static string RSADecrypt(string data)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "wVjVwspocrBWWAnFz53M";
            param.Flags = CspProviderFlags.UseMachineKeyStore;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] databyte = Convert.FromBase64String(data);
                string plaintext = Encoding.ASCII.GetString(rsa.Decrypt(databyte, false));
                return plaintext;
            }
        }
        public static string XORdecrypt(string text, string key)
        {
            var decoded = text;

            byte[] result = new byte[decoded.Length];

            for (int c = 0; c < decoded.Length; c++)
            {
                result[c] = (byte)((uint)decoded[c] ^ (uint)key[c % key.Length]);
            }

            string dexored = Encoding.UTF8.GetString(result);

            return dexored;
        }
        static bool control = false;

        static string nullaga(string data)
        {
            Random rand = new Random();
            int kural = controlupdate ? 32 : rand.Next(10, 50);
            char[] basechar = base64chars.ToCharArray();
            char[] dataar = data.ToCharArray();
            char[] encryptedMessage = new char[dataar.Length];
            for (int i = 0; i < dataar.Length; i++)
            {
                if (dataar[i] == '+' || dataar[i] == '=' || dataar[i] == '/')
                {
                    encryptedMessage[i] = dataar[i];
                    continue;
                }
                char secretItem = dataar[i];
                int index = Array.IndexOf(basechar, secretItem);
                int letterPosition = (index += kural) % base64chars.Length;
                char encryptedCharacter = basechar[letterPosition];
                encryptedMessage[i] = encryptedCharacter;
            }
            string nullagaout = new string(encryptedMessage);
            if (control && !controlupdate)
            {
                string nullagarev = Reverse(nullagaout) + Reverse(Convert.ToString(kural)) + RandomString(10);
                return nullagarev;
            }
            if (controlupdate)
            {
                return nullagaout;
            }
            return null;
        }
        public static string xorCipher(string cipher, byte[] cipherarray)
        {
            int count = 0;
            int count2 = 0;

            StringBuilder sb = new StringBuilder();

            foreach (char c in cipher)
            {
                if (count2 == 16)
                {
                    count2 = 0;
                }
                int val = (int)c ^ cipherarray[count2];
                sb.Append((char)val);
                int intValue = val;
                string hexValue = intValue.ToString("X").Length == 1 ? "0" + intValue.ToString("X") : intValue.ToString("X");

                ++count2;
                ++count;
            }
            string result = sb.ToString();
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(result))))));
        }

        static string nullagar(string data)
        {
            int kural = 0;
            if (!control)
            {
                string findrule = data;
                findrule = findrule.Remove(0, 10);
                kural = Convert.ToInt32(Convert.ToString(findrule.ToCharArray()[0]) + Convert.ToString(findrule.ToCharArray()[1]));
                data = data.Remove(0, 12);
            }
            else
            {
                string findrule = Reverse(data);
                findrule = findrule.Remove(0, 10);
                kural = Convert.ToInt32(Convert.ToString(findrule.ToCharArray()[0]) + Convert.ToString(findrule.ToCharArray()[1]));
                data = Reverse(data).Remove(0, 12);
            }

            char[] basechar = base64chars.ToCharArray();
            char[] dataar = data.ToCharArray();
            char[] encryptedMessage = new char[dataar.Length];
            for (int i = 0; i < dataar.Length; i++)
            {
                if (dataar[i] == '+' || dataar[i] == '=' || dataar[i] == '/')
                {
                    encryptedMessage[i] = dataar[i];
                    continue;
                }
                char secretItem = dataar[i];
                int index = Array.IndexOf(basechar, secretItem);
                int letterPosition = (index += (62 - kural)) % base64chars.Length;
                char encryptedCharacter = basechar[letterPosition];
                encryptedMessage[i] = encryptedCharacter;
            }

            return new string(encryptedMessage);
        }

        public int randomNumberForKey()
        {
            Random rnd = new Random();
            int result = rnd.Next(28000, 34000);
            return result;
        }

        private void MyTimer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            asd();
        }
        void asd()
        {
            if (getUncrypted().Length > 7)
            {
                zatenyapild = true;
                RegistryKey registrySamp = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE\\SAMP", true);
                registrySamp.SetValue("gta_sa_exe", g_oyun + "\\gta_sa.exe");
                string sep = "|";
                RegistryKey registryGameyr = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\gameyr", true);
                byte[] key2 = new byte[] {
189,
121,
222,
117,
172,
128,
191,
23,
36,
169,
121,
233,
132,
171,
57,
227,
178,
194,
24,
160,
163,
227,
249,
46,
76,
128,
93,
107,
193,
155,
143,
209
            };
                byte[] iv2 = Encoding.UTF8.GetBytes("qGt07Pp8GSS5Zmdg");
                byte[] cipherarray = Encoding.UTF8.GetBytes("ULLuBt3tuGX8nLeJ");
                controlupdate = true;
                string updateLink = EncryptString1(registryGameyr.GetValue("serial").ToString() + sep + getUncrypted() + sep + count, key2, iv2);
                updateLink = nullaga(updateLink);
                updateLink = Reverse(RandomString(10) + updateLink);
                updateLink = xorCipher(updateLink, cipherarray);

                string s = ReadTextFromUrl("http://164.132.233.203/data/r_update.php?uq=" + updateLink);
                if (!girdigirmedi)
                {
                    Process p = new Process();
                    p.StartInfo.WorkingDirectory = g_oyun;
                    p.StartInfo.FileName = "samp.exe";
                    p.StartInfo.Arguments = ServerIP + " -nRina_" + getUncrypted();
                    p.Start();
                    Console.WriteLine("[LOG] Oyun açıldı.");
                    girdigirmedi = true;
                }
                Console.WriteLine("[LOG] " + count + ". packet gönderildi onay bekliyor...");

                if (s.Contains("lol"))
                {
                    Console.WriteLine("[LOG] " + count + ". packet onaylandı!");
                }
                else
                {
                    Console.WriteLine("[LOG] Oyundan çıkış yapıldı.");
                    if (checkBox3.Checked)
                    {
                        autoreconnect = true;
                    }
                    myTimer1.Stop();
                }
                count = count + 1;
            }
        }



        private void MyTimer4_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Exit();
        }
        public static string DecryptString2(string cipherText, byte[] key, byte[] iv)
        {
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            byte[] array = new byte[32];
            Array.Copy(key, 0, array, 0, 32);
            aes.Key = array;
            aes.IV = iv;
            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform transform = aes.CreateDecryptor();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            string result = string.Empty;
            try
            {
                byte[] array2 = Convert.FromBase64String(cipherText);
                cryptoStream.Write(array2, 0, array2.Length);
                cryptoStream.FlushFinalBlock();
                byte[] array3 = memoryStream.ToArray();
                result = Encoding.ASCII.GetString(array3, 0, array3.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }
            return result;
        }

        public static string DecryptString(string cipherText, byte[] key, byte[] iv)
        {
            cipherText = nullagar(cipherText);
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            byte[] array = new byte[32];
            Array.Copy(key, 0, array, 0, 32);
            aes.Key = array;
            aes.IV = iv;
            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform transform = aes.CreateDecryptor();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            string result = string.Empty;
            try
            {
                byte[] array2 = Convert.FromBase64String(cipherText);
                cryptoStream.Write(array2, 0, array2.Length);
                cryptoStream.FlushFinalBlock();
                byte[] array3 = memoryStream.ToArray();
                result = Encoding.ASCII.GetString(array3, 0, array3.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }
            return result;
        }
        public static string EncryptString(string plainText, byte[] key, byte[] iv)
        {
            byte[] cipherarray = Encoding.UTF8.GetBytes("ULLuBt3tuGX8nLeJ");
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            byte[] array = new byte[32];
            Array.Copy(key, 0, array, 0, 32);
            aes.Key = array;
            aes.IV = iv;
            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform transform = aes.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            byte[] bytes = Encoding.ASCII.GetBytes(plainText);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array2 = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string converted = Convert.ToBase64String(array2, 0, array2.Length);
            string charza = nullaga(converted);
            string xorcipher = controlupdate ? xorCipher(charza, cipherarray).Replace("=", "") : xorCipher(charza, cipherarray);
            return Uri.EscapeDataString(xorcipher);
        }


        public static string EncryptString1(string plainText, byte[] key, byte[] iv)
        {

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            byte[] array = new byte[32];
            Array.Copy(key, 0, array, 0, 32);
            aes.Key = array;
            aes.IV = iv;
            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform transform = aes.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            byte[] bytes = Encoding.ASCII.GetBytes(plainText);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array2 = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string converted = Convert.ToBase64String(array2, 0, array2.Length);
            string result = string.Empty;
            return converted;
        }

        public static string GenerateNumber(int length)
        {
            Random random = new Random();
            string text = "";
            for (int i = 1; i < length; i++)
            {
                text += random.Next(0, 9).ToString();
            }
            return text;
        }

        public static string Reverse(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        Random rand = new Random();
        static Random rand1 = new Random();

        public const string AlphabetGenel =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public const string Alphabet =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public const string Alphabet2 =
        "abcdefghijklmnopqrstuvwxyz0123456789";

        public const string HexAlphabet =
        "ABCDE0123456789";

        public static string RandomString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = HexAlphabet[rand1.Next(HexAlphabet.Length)];
            }
            return new string(chars);
        }

        public string RandomStringWithoutCapi(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = HexAlphabet[rand.Next(HexAlphabet.Length)];
            }
            return new string(chars);
        }

        public string RandomStringOnlyCapi(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = HexAlphabet[rand.Next(HexAlphabet.Length)];
            }
            return new string(chars);
        }

        string version = "1.8";
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        string rpchelp = "";
        int count = 0;
        bool keys = false;

        private void button1_Click(object sender, EventArgs e)
        {
            loginkey = "";
            girdigirmedi = false;
            count = 0;
            zatenyapild = false;
            donusmuskey = "";
            controlupdate = false;

            startGame();

            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("772545308025552957", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("772545308025552957", ref this.handlers, true, null);
            this.presence.details = "IP : " + ServerIP;
            this.presence.state = "By Sabo :)";
            this.presence.largeImageKey = "logo";
            this.presence.smallImageKey = "";
            this.presence.startTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            string imagetext = "";
            if (rpchelp.Equals("BFEBFBFF000806E9"))
            {
                imagetext = "Yeneni Olmayan Aspect";
            }
            if (rpchelp.Equals("BFEBFBFF000906EA"))
            {
                imagetext = "The Coder Bilen Bilir";
            }
            if (rpchelp.Equals("BFEBFBFF000306C3"))
            {
                imagetext = "Jerdy the retarded cat";
            }
            if (rpchelp.Equals("BFEBFBFF000A0652"))
            {
                imagetext = "Deccal adam";
            }
            if (rpchelp.Equals("178BFBFF00810F81"))
            {
                imagetext = "Aim God E X E C";
            }
            if (rpchelp.Equals("178BFBFF00810F10"))
            {
                imagetext = "Afk adam bayagreff";
            }
            if (rpchelp.Equals("BFEBFBFF000906ED"))
            {
                imagetext = "Vantilator Pervanesi Ato";
            }
            if (rpchelp.Equals("BFEBFBFF0001067A"))
            {
                imagetext = "Yemekci Adam Aow";
            }
            if (rpchelp.Equals("BFEBFBFF0001067A"))
            {
                imagetext = "Kolsuz Dewandiers";
            }
            if (rpchelp.Equals("178BFBFF00870F10"))
            {
                imagetext = "Regnalt furtul crime organizatsiya";
            }
            if (rpchelp.Equals("BFEBFBFF00040651"))
            {
                imagetext = "Torbacı w1nz";
            }
            this.presence.largeImageText = imagetext.Equals("") ? "Bu kim la sj" : imagetext;
            DiscordRpc.UpdatePresence(ref this.presence);

        }

        private Random genz = new Random();
        private Random genz1 = new Random();
        private Random genz2 = new Random();
        private Random genz3 = new Random();

        DateTime RandomDay()
        {
            DateTime start = new DateTime(2015, 1, 1, genz1.Next(1, 23), genz2.Next(1, 59), genz3.Next(1, 30));
            int range = (DateTime.Today - start).Days;
            DateTime daysadded = start.AddDays(genz.Next(range));

            return daysadded;
        }

        void startGame()
        {
            Random qwe1 = new Random();
            Random qwe2 = new Random();
            int mailrandom1 = qwe1.Next(0, 500);
            int mailrandom2 = qwe2.Next(0, 1000);


            Process[] rinacheck = Process.GetProcessesByName("Rina Roleplay");
            if (rinacheck.Length > 0)
            {
                foreach (var rina in rinacheck)
                {
                    rina.Kill();
                }
            }
            Process[] gtacheck = Process.GetProcessesByName("gta_sa");
            if (gtacheck.Length > 0)
            {
                foreach (var rina in gtacheck)
                {
                    rina.Kill();
                }
            }

            if (!File.Exists(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt")))
            {
                File.Create(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt")).Close();
                File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), "0\n0\n0\n0\n0\n0\n0\n0\n0\n0");
                lineChanger(GenerateNumber(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 1);
                lineChanger(RandomStringOnlyCapi(14), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 2);
                lineChanger(RandomStringOnlyCapi(8), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 3);
                lineChanger(RandomStringOnlyCapi(32), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 4);
                lineChanger(GenerateNumber(7), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 5);
                lineChanger(Convert.ToString(randomNumberForKey()), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 6);
                lineChanger(RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 7);
                lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 8);
                lineChanger(RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 9);
                lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 10);

            }

            string[] lines = File.ReadAllLines(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"));
            MD5 md5 = MD5.Create();
            RegistryKey rg7 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\gameyr", true);
            SHA256 sha2 = SHA256.Create();
            byte[] key2 = new byte[] {
189,
121,
222,
117,
172,
128,
191,
23,
36,
169,
121,
233,
132,
171,
57,
227,
178,
194,
24,
160,
163,
227,
249,
46,
76,
128,
93,
107,
193,
155,
143,
209
            };
            byte[] iv2 = Encoding.UTF8.GetBytes("qGt07Pp8GSS5Zmdg");
            Random rand = new Random();
            string mias = "http://164.132.233.203/data/r_dance.php?identity=";
            string url =  textBox1.Text + "|" + "BFEBFBFF000" + lines[0] + RandomString(10) + "|" + RandomString(12) + "|" + textBox3.Text.Trim() + "|" + "DESKTOP/" + textBox4.Text + "/" + RandomString(10) + "\\" + "User" + "/DESKTOP" + "|" + EncryptString(rg7.GetValue("serial").ToString(), key2, iv2) + "|" + lines[1] + "|" + RandomString(8) + "|" + "Windows10" + "|" + EncryptString(lines[3], key2, iv2) + "|" + EncryptString(File.ReadAllText(@"C:\Windows\FontVariables\FontVariables_is.dat"), key2, iv2) + "|" + "hp" + "|" + "DESKTOP" + "-" + lines[4] + "|" + EncryptString(lines[5].ToString(), key2, iv2) + "|" + EncryptString(ReadTextFromUrl("http://164.132.233.203/data/r_assver.php"), key2, iv2) + "|" + EncryptString(RSAEncrypt(), key2, iv2) + "|" + "0" + "|" + EncryptString(lines[6], key2, iv2) + "|" + EncryptString(/*lines[7].Replace(".","/") + " PM" */ lines[7].Replace(".", "/") + " AM", key2, iv2) + "|" + EncryptString(lines[8], key2, iv2) + "|" + EncryptString("Windows 10 Home", key2, iv2) + "|" + EncryptString("Windows Kullanıcısı", key2, iv2) + "|" +  EncryptString(lines[9].Replace(".", "/") + " AM", key2,iv2);
            Console.WriteLine("[LOG] " + "Link üretildi, hash bekleniyor.");
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(url));
            StringBuilder builder = new StringBuilder();
            for (int i1 = 0; i1 < hash.Length; i1++)
            {
                builder.Append(hash[i1].ToString("x2"));
            }
            Console.WriteLine("[LOG] Hash üretildi, key bekleniyor...");

            string hashconc = EncryptString(builder.ToString(), key2, iv2);

            string encryption = url + "|" + hashconc;

            string hashedlink = Uri.EscapeDataString(encryption);

            loginkey = ReadTextFromUrl(mias + hashedlink);
            if (!loginkey.Contains("=="))
            {
                Console.WriteLine("[LOG] Key üretilemedi, ip'ni resleyip ban tuşuna basıp rinayla girip gene deneyiniz.");
                return;
            }
            Console.WriteLine("[LOG] Key üretildi.");
            sha2.Dispose();
            asd();
            myTimer1.Elapsed += MyTimer1_Elapsed;
            myTimer1.Interval = 30000;
            myTimer1.Start();
        }
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
        private static string GetHash(string s)
        {
            HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();
            byte[] bytes = new ASCIIEncoding().GetBytes(s);
            return GetHexString(hashAlgorithm.ComputeHash(bytes));
        }

        private static string GetHexString(byte[] bt)
        {
            string text = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];
                int num = (int)(b & 15);
                int num2 = b >> 4 & 15;
                if (num2 > 9)
                {
                    text += ((char)(num2 - 10 + 65)).ToString();
                }
                else
                {
                    text += num2.ToString();
                }
                if (num > 9)
                {
                    text += ((char)(num - 10 + 65)).ToString();
                }
                else
                {
                    text += num.ToString();
                }
                if (i + 1 != bt.Length && (i + 1) % 2 == 0)
                {
                    text += "-";
                }
            }
            return text;
        }
        private void InitializeComponent()
        {
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 180);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(260, 20);
            this.textBox5.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Start";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(62, 238);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Auto";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 206);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(260, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(65, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "NHF Team";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(235, 238);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(43, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Discord";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(197, 122);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "Ban";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 96);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(206, 20);
            this.textBox3.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 27;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(72, 44);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(206, 20);
            this.textBox4.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "PC Ismi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "IP Adresin";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "IC Isim";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(179, 154);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(99, 17);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.Text = "Auto reconnect";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(12, 151);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(123, 17);
            this.checkBox4.TabIndex = 34;
            this.checkBox4.Text = "Client BAN Remover";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 26);
            this.label2.TabIndex = 35;
            this.label2.Text = "Developed by : Sabo | Hellside | NULL\nTeam NHF - VOID";
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE\\SAMP", true);
            string[] lines = File.ReadAllLines(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "Config.txt"));
            registryKey.SetValue("gta_sa_exe", lines[0] + "\\gta_sa.exe");
            Process[] suspend2 = Process.GetProcessesByName("samp");
            Process[] suspend3 = Process.GetProcessesByName("ConsoleApp1");
            Process[] suspend1 = Process.GetProcessesByName("Rina Roleplay");
            Process[] suspend4 = Process.GetProcessesByName("Baronov Connector v" + version);
            if (suspend2.Length > 0)
            {
                foreach (Process item in suspend2)
                {
                    item.Kill();
                }
            }
            if (suspend3.Length > 0)
            {
                foreach (Process item in suspend3)
                {
                    item.Kill();
                }
            }

            if (suspend4.Length > 0)
            {
                foreach (Process iem2 in suspend4)
                {
                    iem2.Kill();
                }
            }
        }

        public void LoadConfig()
        {
            count = 0;

            FileInfo fi = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "Config.txt"));
            if (!File.Exists(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "Config.txt")))
            {
                File.Create(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "Config.txt"));

            }
            else
            {
                if (!fi.Length.Equals(0))
                {
                    string[] lines = File.ReadAllLines(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "Config.txt"));
                    RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE\\SAMP", true);
                    registryKey.SetValue("gta_sa_exe", lines[0] + "\\gta_sa.exe");
                    g_oyun = lines[0];
                    textBox3.Text = lines[1];
                    textBox4.Text = lines[2];
                }
            }
            string url2 = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url2);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];

            if (!a4.Equals(textBox1.Text))
            {
                textBox1.Text = a4;
            }

        }
        public static string ReadTextFromUrl(string url)
        {
            string empty = string.Empty;
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0);
            string cleaned = ts.TotalSeconds.ToString().Substring(0, 10);
            CookieContainer cookieContainer = new CookieContainer();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.UserAgent = "Keep-Delived";
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding(httpWebResponse.CharacterSet)).ReadToEnd();
        }

        public static bool CheckForInternetConnection()
        {
            bool result;
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    using (webClient.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://discord.gg/Ph7nXJp9ph");
            Process.Start("https://discord.gg/dvjUhmUGND");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            RegistryKey rg1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
            RegistryKey rg7 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft", true);
            RegistryKey rg2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\RemovalTools\\MRT", true);
            RegistryKey rg3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\ControlSet001\\Enum\\SCSI", true);

            if (rg7.GetSubKeyNames().Contains("gameyr"))
            {
                rg7.DeleteSubKey("gameyr");
            }
            if (rg1.GetValueNames().Contains("MachineGuid"))
            {
                rg1.DeleteValue("MachineGuid");
            }
            if (rg2.GetValueNames().Contains("GUID"))
            {
                rg2.DeleteValue("GUID");
            }
            if (File.Exists(@"C:\Windows\FontVariables\FontVariables_is.dat"))
            {
                File.Delete(@"C:\Windows\FontVariables\FontVariables_is.dat");

                DirectoryInfo directory = new DirectoryInfo(@"C:\Windows\FontVariables");
                if (directory.Exists)
                {
                    directory.Delete();
                }
                DirectoryInfo directory3 = new DirectoryInfo("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Microsoft\\.MicrosoftService");
                if (directory3.Exists)
                {
                    directory3.Delete();
                }
            }

            DirectoryInfo directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Spend");
            if (directory2.Exists)
            {
                directory2.Delete();
            }

            DirectoryInfo directory5 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WinRAR\\Datas");
            if (directory5.Exists)
            {
                directory5.Delete();
            }

            if (checkBox4.Checked)
            {
                try
                {
                    foreach (var subkeys in rg3.GetSubKeyNames())
                    {
                        Random rand = new Random();
                        RegistryKey rg4 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\ControlSet001\\Enum\\SCSI\\" + subkeys, true);
                        foreach (var subkeys2 in rg4.GetSubKeyNames())
                        {
                            RegistryKey rg5 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\ControlSet001\\Enum\\SCSI\\" + subkeys + "\\" + subkeys2, true);
                            if (rg5.GetValueNames().Contains("FriendlyName"))
                            {
                                if (!File.Exists("BunuSilme.txt"))
                                {
                                    File.Create("BunuSilme.txt").Close();

                                    rg5.SetValue("FriendlyName", rg5.GetValue("FriendlyName").ToString() + "O" + rand.Next(1000, 9999));
                                }
                                else
                                {
                                    rg5.SetValue("FriendlyName", rg5.GetValue("FriendlyName").ToString() + "O" + rand.Next(1000, 9999));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("1. etapda hata aldınız (Regeditden programa erişim izni verin)", "Hata Kodu #1");
                }
                try {
                    clientBanRemover();
                }
                catch
                {
                    MessageBox.Show("2. etapda hata aldınız bunun olmaması lazım", "Hata Kodu #2");
                }
            }
            Random qwe1 = new Random();
            Random qwe2 = new Random();
            int mailrandom1 =qwe1.Next(0, 500);
            int mailrandom2 = qwe2.Next(0, 1000);
            if (!File.Exists(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt")))
            {
                File.Create(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt")).Close();
                File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), "0\n0\n0\n0\n0\n0\n0\n0\n0\n0");
                lineChanger(GenerateNumber(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 1);
                lineChanger(RandomStringOnlyCapi(14), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 2);
                lineChanger(RandomStringOnlyCapi(8), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 3);
                lineChanger(RandomStringOnlyCapi(32), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 4);
                lineChanger(GenerateNumber(7), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 5);
                lineChanger(Convert.ToString(randomNumberForKey()), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 6);
                lineChanger(RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 7);
                lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 8);
                lineChanger(RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 9);
                lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 10);
            }
            else
            {
                if (File.ReadAllText(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt")).Contains("0"))
                {
                    lineChanger(GenerateNumber(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 1);
                    lineChanger(RandomStringOnlyCapi(14), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 2);
                    lineChanger(RandomStringOnlyCapi(8), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 3);
                    lineChanger(RandomStringOnlyCapi(32), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 4);
                    lineChanger(GenerateNumber(7), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 5);
                    lineChanger(Convert.ToString(randomNumberForKey()), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 6);
                    lineChanger(RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 7);
                    lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 8);
                    lineChanger(RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 9);
                    lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 10);
                }
                else
                {
                    File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), "0\n0\n0\n0\n0\n0\n0\n0\n0\n0");
                    lineChanger(GenerateNumber(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 1);
                    lineChanger(RandomStringOnlyCapi(14), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 2);
                    lineChanger(RandomStringOnlyCapi(8), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 3);
                    lineChanger(RandomStringOnlyCapi(32), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 4);
                    lineChanger(GenerateNumber(7), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 5);
                    lineChanger(Convert.ToString(randomNumberForKey()), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 6);
                    lineChanger(RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4) + "-" + RandomStringOnlyCapi(4), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 7);
                    lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 8);
                    lineChanger(RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5) + "-" + RandomStringOnlyCapi(5), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 9);
                    lineChanger(RandomDay().ToString(), System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "BanKontrol.txt"), 10);
                }
            }
        }

        public void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void clientBanRemover()
        {
            if (checkBox4.Checked)
            {
                RegistryKey rgBan = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);

                bool installdate = false;
                bool installtime = false;
                bool regowner = false;
                bool productid = false;

                foreach (string za in rgBan.GetValueNames())
                {
                    if (za.Contains("InstallTime"))
                    {
                        installtime = true;
                    }
                    if (za.Contains("InstallDate"))
                    {
                        installdate = true;
                    }
                    if (za.Contains("RegisteredOwner"))
                    {
                        regowner = true;
                    }
                    if (za.Contains("ProductId"))
                    {
                        productid = true;
                    }
                }
                string idrand = GenerateNumber(5) + "-" + GenerateNumber(5) + "-" + GenerateNumber(5) + "-" + RandomStringOnlyCapi(5);
                TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0);
                long cleaned = ts.Ticks;
                string oldvalues = "InstallDate : " + (installdate ? rgBan.GetValue("InstallDate").ToString() : "Yok") + "\n"
                + "InstallTime : " + (installtime ? rgBan.GetValue("InstallTime").ToString() : "Yok") + "\n"
                + "RegisteredOwner : " + (regowner ? rgBan.GetValue("RegisteredOwner").ToString() : "Yok") + "\n"
                + "ID : " + (productid ? rgBan.GetValue("ProductId").ToString() : "Yok");
                if (!File.Exists("OldValues.txt"))
                {
                    File.Create("OldValues.txt").Close();
                    File.WriteAllText("OldValues.txt", oldvalues);
                }
                if (installdate)
                {
                    rgBan.SetValue("InstallDate", cleaned);
                }
                if (installtime)
                {
                    rgBan.SetValue("InstallTime", cleaned);
                }
                if (regowner)
                {
                    rgBan.SetValue("RegisteredOwner", RandomString(20) + "@gmail.com");
                }
                if (productid)
                {
                    rgBan.SetValue("ProductId", idrand);
                }
            }
        }

        static string donusmuskey = "";
        static bool zatenyapild = false;
        private string getUncrypted()
        {
            SHA256 sha3 = SHA256.Create();
            byte[] key3 = new byte[] {
                0x6A,
                0xF8,
                0xCA,
                0x84,
                0x89,
                0x13,
                0x09,
                0x75,
                0xFC,
                0x51,
                0xFD,
                0x54,
                0xAB,
                0x65,
                0xB6,
                0x00,
                0x9E,
                0xFE,
                0x1C,
                0xC0,
                0xA6,
                0xE3,
                0x40,
                0x81,
                0x8B,
                0x93,
                0x51,
                0xED,
                0xC0,
                0x68,
                0x50,
                0xB5
            };
            byte[] iv3 = new byte[] {
                0x6E,
                0x4E,
                0x77,
                0x78,
                0x50,
                0x34,
                0x31,
                0x44,
                0x43,
                0x72,
                0x6D,
                0x43,
                0x4A,
                0x41,
                0x30,
                0x6A
            };
            if (!zatenyapild)
            {
                donusmuskey = DecryptString(loginkey, key3, iv3);
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 100;
                timer.Tick += Timer_Tick;
                timer.Start();
                int rootvalue = DateTime.Now.Day * 4 + DateTime.Now.Month * 4 + DateTime.Now.Hour + 3;

                RegistryKey keygen = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\ASP.NET", true);
                foreach (string keyname in keygen.GetValueNames())
                {
                    if (keyname.Contains("RootKey"))
                    {
                        keygen.SetValue(keyname, RandomString(8));
                    }
                    if (keyname.Contains("KeyGen"))
                    {
                        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0);
                        string cleaned = ts.TotalSeconds.ToString().Substring(0, 10);
                        keygen.SetValue(keyname, new Random().Next(10000, 99999) + "-" + new Random().Next(10000, 99999) + "-" + Reverse(cleaned) + "-" + new Random().Next(10000, 99999));
                    }
                    if (keyname.Contains("RootKey" + rootvalue))
                    {
                        keygen.SetValue(keyname, donusmuskey);
                    }
                }
            }
            sha3.Dispose();
            return donusmuskey;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (girdigirmedi)
            {
                Process[] process = Process.GetProcessesByName("gta_sa");
                if (process.Length > 0)
                {
                    RegistryKey keygen = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\ASP.NET", true);
                    int numb = process.FirstOrDefault().Id + 200;

                    if (!keygen.GetValue("MainKeyF").ToString().Equals(numb.ToString()))
                    {
                        keygen.SetValue("MainKeyF", numb.ToString());
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            Clipboard.SetText(a4);
        }
    }
}   