using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileReader.Contract;
using System.Net.Http;
using System.IO;

using Newtonsoft.Json;

namespace FileReaderClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string res = "";
            SearchFile( res);

        }


        public async void SearchFile( string jsonContent)
        {
                string baseURL = "https://localhost:44344/api/myfile";
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            HttpResponseMessage response = await client.GetAsync("");
            string result = await response.Content.ReadAsStringAsync();
            result = result;

            List<MyFile>  myList =JsonConvert.DeserializeObject<List<MyFile>>(result);

            lbFiles.Items.Clear();
            ListBox.ObjectCollection objs = new ListBox.ObjectCollection(lbFiles);
            foreach(var f in myList)
            {
                objs.Add(f.Filename);
            }
            //objs.AddRange(myList.ToArray());
            //lbFiles.Items.AddRange(objs);
           
          
        }
    }
}
