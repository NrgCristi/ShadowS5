using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Net;
using System.Collections;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using ShadowS5.Utils;
namespace ShadowS5
{
    public partial class Form1 : Form
    {
        private string exchange;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.exchange = new RestClient("https://e01a4dfd-fc0a-4703-a22a-cd2bc83bfaf1.id.repl.co/").Execute(new RestRequest("/exchange?code=" + this.AuthCode.Text, Method.Get)).Content;
            if (this.exchange.ToString() == "[]")
            {
                int num = (int)MessageBox.Show("The authorization code you supplied was invalid, please try again with a valid code!");
            }
            else
            {
                CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
                commonOpenFileDialog.Title = "Please select the path for 5.10";
                commonOpenFileDialog.IsFolderPicker = true;
                commonOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                commonOpenFileDialog.AddToMostRecentlyUsedList = false;
                commonOpenFileDialog.AllowNonFileSystemItems = false;
                commonOpenFileDialog.DefaultDirectory = "Desktop";
                commonOpenFileDialog.EnsureFileExists = true;
                commonOpenFileDialog.EnsurePathExists = true;
                commonOpenFileDialog.EnsureReadOnly = false;
                commonOpenFileDialog.EnsureValidNames = true;
                commonOpenFileDialog.Multiselect = false;
                commonOpenFileDialog.ShowPlacesList = true;
                if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string fileName1 = commonOpenFileDialog.FileName;
                    string str1 = fileName1 + "\\FortniteGame\\Binaries\\Win64";
                    if (!System.IO.File.Exists(str1 + "/FortniteClient-Win64-Shipping.exe"))
                    {
                        int num = (int)MessageBox.Show("The path selected does not have Fortnite installed correctly: " + fileName1 + "\\nPlease retry with a valid path");
                    }
                    if (System.IO.File.Exists(str1 + "/FortniteClient-Win64-Shipping.exe"))
                    {
                        WebClient webClient = new WebClient();
                        string fileName2 = fileName1 + "\\FortniteGame\\Binaries\\Win64\\ShadowFN.dll";
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/1015700319671423006/1057965071885684736/FortniteTools.dll", fileName2);
                        string fileName3 = Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
                        string str2 = Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe");
                        string str3 = Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe");
                        string arguments = "-AUTH_LOGIN=unused -AUTH_PASSWORD=" + this.exchange + " -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -nobe -fromfl=eac -fltoken=3db3ba5dcbd2e16703f3978d -caldera=eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQwN2IyZjQwZWJhYWQ4NTlhZDQiLCJnZW5lcmF0ZWQiOjE2Mzg3MTcyNzgsImNhbGRlcmFHdWlkIjoiMzgxMGI4NjMtMmE2NS00NDU3LTliNTgtNGRhYjNiNDgyYTg2IiwiYWNQcm92aWRlciI6IkVhc3lBbnRpQ2hlYXQiLCJub3RlcyI6IiIsImZhbGxiYWNrIjpmYWxzZX0.VAWQB67RTxhiWOxx7DBjnzDnXyyEnX7OljJm-j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ - skippatchcheck";
                        Process process1 = new Process();
                        ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName3, arguments);
                        processStartInfo.UseShellExecute = false;
                        processStartInfo.RedirectStandardOutput = false;
                        processStartInfo.CreateNoWindow = true;
                        process1.StartInfo = processStartInfo;
                        Process process2 = process1;
                        Process process3 = new Process();
                        process3.StartInfo.FileName = str3;
                        process3.Start();
                        foreach (ProcessThread thread in (ReadOnlyCollectionBase)process3.Threads)
                            win32.SuspendThread(win32.OpenThread(2, false, thread.Id));
                        Process process4 = new Process();
                        process4.StartInfo.FileName = str2;
                        process4.StartInfo.Arguments = "-epiclocale = en - nobe - fromfl = eac - fltoken = 3db3ba5dcbd2e16703f3978d - caldera = eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQwN2IyZjQwZWJhYWQ4NTlhZDQiLCJnZW5lcmF0ZWQiOjE2Mzg3MTcyNzgsImNhbGRlcmFHdWlkIjoiMzgxMGI4NjMtMmE2NS00NDU3LTliNTgtNGRhYjNiNDgyYTg2IiwiYWNQcm92aWRlciI6IkVhc3lBbnRpQ2hlYXQiLCJub3RlcyI6IiIsImZhbGxiYWNrIjpmYWxzZX0.VAWQB67RTxhiWOxx7DBjnzDnXyyEnX7OljJm - j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ";
                        process4.Start();
                        foreach (ProcessThread thread in (ReadOnlyCollectionBase)process4.Threads)
                            win32.SuspendThread(win32.OpenThread(2, false, thread.Id));
                        process2.Start();
                        Thread.Sleep(2000);
                        Thread.Sleep(6000);
                        System.IO.File.Delete(fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe");
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/823233042788122685/828311722036690984/Injector.exe", fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe");
                        process2.WaitForInputIdle();
                        Process process5 = new Process();
                        process5.StartInfo.Arguments = string.Format("\"{0}\" \"{1}\"", (object)process2.Id, (object)fileName2);
                        process5.StartInfo.CreateNoWindow = true;
                        process5.StartInfo.UseShellExecute = false;
                        process5.StartInfo.FileName = fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe";
                        process5.Start();
                        Thread.Sleep(10);
                        process2.WaitForExit();
                        try
                        {
                            process3.Close();
                            process4.Close();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }
}