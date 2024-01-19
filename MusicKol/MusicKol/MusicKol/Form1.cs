using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicKol
{
    public partial class Form1 : Form
    {

        readonly AlbumsBusiness a = new AlbumsBusiness();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            listBox1.Items.Clear();

            foreach(var al in a.GetAllAlbums())
            {
                listBox1.Items.Add($"{al.Title}, {al.Price}, Id:{al.Id}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Album album = new Album()
            {
                Title = textBox1.Text,
                Artist = textBox2.Text,
                Price = Convert.ToDecimal(textBox3.Text)
            };

            a.InsertAlbum(album);

            RefreshList();

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int id = 0;

            try
            {
                id = Convert.ToInt32(textBox4.Text);
            }
            catch {
                MessageBox.Show("UNESI ID");
            }

            a.DeleteAlbum(id);

            textBox4.Text = string.Empty;

            RefreshList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Album alb = new Album()
            {
                Id = Convert.ToInt32(textBox4.Text),
                Title = textBox1.Text,
                Artist = textBox2.Text,
                Price = Convert.ToDecimal(textBox3.Text)
            };

            a.UpdateAlbum(alb);

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            RefreshList();
        }
    }
}
