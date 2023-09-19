using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace bd
{
    public partial class Menu : Form
    {
        private SQLiteConnection DB;
        public Menu()
        {
            InitializeComponent();
        }
        private async void ShowStreamers(int phId)
        {
            DB = new SQLiteConnection(Database.connection);
            await DB.OpenAsync();
            Str newForm = new Str();
            string queryString = "SELECT NmId FROM Name Where Id = @NmId";
            SQLiteCommand command = new SQLiteCommand(queryString, DB);
            command.Parameters.AddWithValue("@NmId", phId);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string NameInfo = reader.GetString(0);
                newForm.textBox1.Text = NameInfo;
            }

            string queryStringPhoto = "SELECT Foto1, Foto2 FROM Foto Where Id = @PhId";
            SQLiteCommand commandPhoto = new SQLiteCommand(queryStringPhoto, DB);
            commandPhoto.Parameters.AddWithValue("@PhId", phId);

            SQLiteDataReader readerPhoto = commandPhoto.ExecuteReader();
            while (readerPhoto.Read())
            {
                string Photo1 = readerPhoto.GetString(0);
                string Photo2 = readerPhoto.GetString(1);

                newForm.pictureBox1.Image = Image.FromFile(Photo1);
                newForm.pictureBox2.Image = Image.FromFile(Photo2);
            }

            reader.Close();
            readerPhoto.Close();
            DB.Close();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowStreamers(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowStreamers(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowStreamers(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowStreamers(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowStreamers(5);
        }
    }
}
