using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bd
{
    public partial class Avtor : Form
    {
       
        public Avtor()
        {
            InitializeComponent();
        }
        private SQLiteConnection db;

        private async void Avtor_Load(object sender, EventArgs e)
        {
            db = new SQLiteConnection(Database.connection);

            await db.OpenAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            SQLiteDataReader sqlReader = null;
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{User_table.main}] WHERE [{User_table.Name}]" +
                $" = '" + textBox1.Text + $"' AND [{User_table.Pass}] = '" + textBox2.Text + "'", db);
            try
            {
                
                adapter.SelectCommand = command;
                _ = adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                      
                        Menu newForm = new Menu();
                        newForm.Show();
                        Hide();
                    }
                }
              
                else
                {
                    _ = MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации");
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"{ex.Message}", $"{ex.Source}");
            }
            // Освобождение ресурсов
            finally
            {
                sqlReader?.Close();
            }
        }
    }
}
