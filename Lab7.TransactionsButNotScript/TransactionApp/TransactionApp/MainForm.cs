using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionApp
{
    public partial class MainForm : Form
    {
        private static readonly string _sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Database = "postgres",
            Username = "postgres",
            Password = "1234",
            MaxAutoPrepare = 10,
            AutoPrepareMinUsages = 2
        }.ConnectionString;
        NpgsqlConnection sConn = new NpgsqlConnection(_sConnStr);
        public MainForm()
        {
            sConn.Open();
            InitializeComponent(); 
            InitializeLvVideocard();
            cbMode.Text = "Read committed"; 
        }

        private void InitializeLvVideocard()
        {
            lvRam.Clear();
            lvRam.Columns.Add("id");
            lvRam.Columns.Add("Model");
            lvRam.Columns.Add("Memory");
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"
			         select ram_id, ram_model, ram_memory_size
                    from pcbs.ram_information;"
            };
            var reader = sCommand.ExecuteReader();
            while (reader.Read())
            {
                var lvi = new ListViewItem(new[] {
                    reader["ram_id"].ToString(),
                    reader["ram_model"].ToString(),
                    reader["ram_memory_size"].ToString()
                });
                lvRam.Items.Add(lvi);
            }
            reader.Close();
            lvRam.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvRam.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            var str = "This was inserted at " + DateTime.Now.ToString();
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"Insert into pcbs.ram_information(ram_model,ram_memory_size) values (@model,2);"
            };
            sCommand.Parameters.AddWithValue("@model", str);
            sCommand.ExecuteNonQuery();
            InitializeLvVideocard();
        }

        private void btTransStart_Click(object sender, EventArgs e)
        {
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"Begin transaction isolation level "+cbMode.Text+";"
            };
            sCommand.ExecuteNonQuery();
        }

        private void btRollback_Click(object sender, EventArgs e)
        {
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"Rollback;"
            };
            sCommand.ExecuteNonQuery();
            InitializeLvVideocard();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            InitializeLvVideocard();
        }

        private void btSavepoint_Click(object sender, EventArgs e)
        {
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"Savepoint mysave;"
            };
            sCommand.ExecuteNonQuery();
        }

        private void btRollebackTo_Click(object sender, EventArgs e)
        {
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"Rollback to mysave;"
            };
            sCommand.ExecuteNonQuery();
            InitializeLvVideocard();
        }

        private void btCommit_Click(object sender, EventArgs e)
        {
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"Commit;"
            };
            sCommand.ExecuteNonQuery();
            InitializeLvVideocard();
        }

        private void btAggregate_Click(object sender, EventArgs e)
        {
            var sCommand = new NpgsqlCommand
            {
                Connection = sConn,
                CommandText = @"select count(*) from pcbs.ram_information  where ram_memory_size = 2;"
            };
            var count = (long)sCommand.ExecuteScalar();
            MessageBox.Show("Количество строк в таблице, где значение количества памяти четно: " + count);
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            var message = @"Уровень read committed — Аномалия ""Неповторяющееся чтение"". 
Повторное чтение элемента данных дает другой результат, поскольку значение элемента было изменено другой транзакцией.

Уровень repeatable read - Аномалия ""Фантомное чтение"". 
Повторный поиск данных по предикату возвращает результат, отличающийся от первого, потому что другая транзакция 
добавила, удалила или изменила записи таким образом, что они стали удовлетворять (или перестали удовлетворять) предикату.

Уровень serializable - Транзакции полностью изолируются друг от друга, каждая выполняется так, как будто параллельных транзакций не существует.";
            MessageBox.Show(message, "Уровни изоляции");
        }
    }
}
