using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace toli.db
{
    public partial class Form1 : Form
    {
        private string dbPath = "";

        private string connectionString = "";

        private int selectedId = 0;
        private bool databaseReady = false;
        private bool showSavedOnly = false;

        public Form1()
        {
            InitializeComponent();
            string appDir = AppDomain.CurrentDomain.BaseDirectory;

            string dataDir = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "Toli"
            );

            Directory.CreateDirectory(dataDir);

            dbPath = Path.Combine(dataDir, "toli.db");

            if (!File.Exists(dbPath))
            {
                File.Copy(
                    Path.Combine(appDir, "toli.db"),
                    dbPath
                );
            }

            connectionString = $"Data Source={dbPath}";

            // Button holbolt
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;

            // Haih
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;

            // Hel songoh
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // Husnegt songoh
            dataGridView1.CellClick += dataGridView1_CellClick;

            // Sanasan ug
            textBox6.Click += textBox6_Click;
            textBox7.Click += textBox7_Click;
        }
        // 1. DATABASE HOLBOH

        private void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(dbPath))
                {
                    MessageBox.Show(
                        "toli.db өгөгдлийн сан олдсонгүй!\n" + dbPath
                    );
                    return;
                }

                using (var con = new SqliteConnection(connectionString))
                {
                    con.Open();

                    // Words husnegt shalgah
                    using (var check = new SqliteCommand(
                        "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='words'",
                        con))
                    {
                        int result = Convert.ToInt32(check.ExecuteScalar());

                        if (result == 0)
                        {
                            MessageBox.Show("words хүснэгт олдсонгүй!");
                            return;
                        }
                    }

                    // Sanasan ugiin husnegt uusgeh
                    string sql = @"
                    CREATE TABLE IF NOT EXISTS saved_words
                    (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        word_id INTEGER UNIQUE,
                        FOREIGN KEY(word_id) REFERENCES words(id)
                    );";

                    using (var cmd = new SqliteCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // DataGridView tohirgoo
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;

                dataGridView1.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dataGridView1.MultiSelect = false;

                // ComboBox
                comboBox1.Items.Clear();

                comboBox1.Items.Add("Бүгд");
                comboBox1.Items.Add("Англи");
                comboBox1.Items.Add("Монгол");
                comboBox1.Items.Add("Орос");

                comboBox1.SelectedIndex = 0;

                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;

                lblDbInfo.Text = "toli.db · words";

                databaseReady = true;

                LoadWords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Өгөгдлийн сантай холбогдоход алдаа гарлаа:\n" +
                    ex.Message
                );
            }
        }
        // 2. UGSIIG HUSNEGTED HARUULAH
        private void LoadWords()
        {
            if (!databaseReady)
                return;

            try
            {
                using (var con = new SqliteConnection(connectionString))
                {
                    con.Open();

                    string search = textBox1.Text.Trim();

                    if (search == "Хайх үг...")
                        search = "";

                    string sql;

                    if (showSavedOnly)
                    {
                        sql = @"
                        SELECT w.id, w.eng, w.mon, w.rus
                        FROM words w
                        INNER JOIN saved_words s
                        ON w.id = s.word_id";
                    }
                    else
                    {
                        sql = @"
                        SELECT w.id, w.eng, w.mon, w.rus
                        FROM words w";
                    }

                    if (search != "")
                    {
                        if (comboBox1.Text == "Англи")
                        {
                            sql += " WHERE w.eng LIKE @search";
                        }
                        else if (comboBox1.Text == "Монгол")
                        {
                            sql += " WHERE w.mon LIKE @search";
                        }
                        else if (comboBox1.Text == "Орос")
                        {
                            sql += " WHERE w.rus LIKE @search";
                        }
                        else
                        {
                            sql += @"
                            WHERE w.eng LIKE @search
                            OR w.mon LIKE @search
                            OR w.rus LIKE @search";
                        }
                    }

                    sql += " ORDER BY w.id";

                    using (var cmd = new SqliteCommand(sql, con))
                    {
                        if (search != "")
                        {
                            cmd.Parameters.AddWithValue(
                                "@search", "%" + search + "%"
                            );
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            dataGridView1.Rows.Clear();

                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);

                                int index = dataGridView1.Rows.Add(
                                    id,
                                    reader["eng"].ToString(),
                                    reader["mon"].ToString(),
                                    reader["rus"].ToString()
                                );

                                // ID-g Tag-d hadgalah
                                dataGridView1.Rows[index].Tag = id;
                            }
                        }
                    }
                }

                UpdateCount();

                selectedId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Үг уншихад алдаа гарлаа:\n" + ex.Message
                );
            }
        }
        // 3. NIIT UG TOLOH
        private void UpdateCount()
        {
            using (var con = new SqliteConnection(connectionString))
            {
                con.Open();

                using (var cmd = new SqliteCommand(
                    "SELECT COUNT(*) FROM words", con))
                {
                    int total = Convert.ToInt32(cmd.ExecuteScalar());

                    using (var cmd2 = new SqliteCommand(
                        "SELECT COUNT(*) FROM saved_words", con))
                    {
                        int saved = Convert.ToInt32(cmd2.ExecuteScalar());

                        textBox5.Text =
                            $"Нийт: {total} үг • Санасан: {saved}";
                    }
                }
            }
        }
        // 4. SHINE UG NEMEH
        private void button1_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Гурван хэлний үгийг бүрэн оруулна уу!");
                return;
            }

            try
            {
                using (var con = new SqliteConnection(connectionString))
                {
                    con.Open();

                    string sql = @"
                    INSERT INTO words (eng, mon, rus)
                    VALUES (@eng, @mon, @rus)";

                    using (var cmd = new SqliteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@eng", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@mon", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@rus", textBox4.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Шинэ үг амжилттай нэмэгдлээ!");

                showSavedOnly = false;

                ClearFields();

                textBox1.Text = "";

                LoadWords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Үг нэмэхэд алдаа гарлаа:\n" + ex.Message);
            }
        }
        // 5. UG ZASAH
        private void button2_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Эхлээд засах үгээ сонгоно уу!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Бүх талбарыг бөглөнө үү!");
                return;
            }

            try
            {
                using (var con = new SqliteConnection(connectionString))
                {
                    con.Open();

                    string sql = @"
                    UPDATE words
                    SET eng=@eng,
                        mon=@mon,
                        rus=@rus
                    WHERE id=@id";

                    using (var cmd = new SqliteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@eng", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@mon", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@rus", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Үг амжилттай засагдлаа!");

                ClearFields();
                LoadWords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Үг засахад алдаа гарлаа:\n" + ex.Message);
            }
        }
        // 6. UG USTGAH

        private void button3_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Устгах үгээ сонгоно уу!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Сонгосон үгийг устгах уу?",
                "Баталгаажуулалт",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var con = new SqliteConnection(connectionString))
                    {
                        con.Open();

                        using (var transaction = con.BeginTransaction())
                        {
                            using (var cmd1 = new SqliteCommand(
                                "DELETE FROM saved_words WHERE word_id=@id",
                                con, transaction))
                            {
                                cmd1.Parameters.AddWithValue("@id", selectedId);
                                cmd1.ExecuteNonQuery();
                            }

                            using (var cmd2 = new SqliteCommand(
                                "DELETE FROM words WHERE id=@id",
                                con, transaction))
                            {
                                cmd2.Parameters.AddWithValue("@id", selectedId);
                                cmd2.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                    }

                    MessageBox.Show("Үг амжилттай устгагдлаа!");

                    ClearFields();
                    LoadWords();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Устгахад алдаа гарлаа:\n" + ex.Message);
                }
            }
        }
        // 7. TALBAR TSEVERLEH

        private void button4_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            selectedId = 0;

            dataGridView1.ClearSelection();
        }

        // 8. SANASAN UG HADGALAH

        private void button5_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Санах үгээ хүснэгтээс сонгоно уу!");
                return;
            }

            try
            {
                using (var con = new SqliteConnection(connectionString))
                {
                    con.Open();

                    string sql = @"
                    INSERT OR IGNORE INTO saved_words (word_id)
                    VALUES (@id)";

                    using (var cmd = new SqliteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                            MessageBox.Show("Үг санасан үгсэд хадгалагдлаа!");
                        else
                            MessageBox.Show("Энэ үг өмнө нь хадгалагдсан байна!");
                    }
                }

                UpdateCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Хадгалахад алдаа гарлаа:\n" + ex.Message);
            }
        }
        // 9. HUSNEGTES UG SONGOH
   
        private void dataGridView1_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dataGridView1.Rows.Count)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (row.Tag == null)
                return;

            selectedId = Convert.ToInt32(row.Tag);

            textBox2.Text = row.Cells[1].Value?.ToString() ?? "";
            textBox3.Text = row.Cells[2].Value?.ToString() ?? "";
            textBox4.Text = row.Cells[3].Value?.ToString() ?? "";
        }
        // 10. UG HAIRAH

        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
            LoadWords();
        }
        // 11. HEL SONGOH
        private void comboBox1_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            LoadWords();
        }
        // 12. SANASAN UGS HARAH
        private void textBox6_Click(object? sender, EventArgs e)
        {
            showSavedOnly = true;

            lblDbInfo.Text = "Санасан үгс";

            LoadWords();
        }
        // 13. SANASAN UGS HOOSLOH
        private void textBox7_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Санасан бүх үгийг арилгах уу?",
                "Баталгаажуулалт",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var con = new SqliteConnection(connectionString))
                    {
                        con.Open();

                        using (var cmd = new SqliteCommand(
                            "DELETE FROM saved_words", con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    showSavedOnly = false;

                    lblDbInfo.Text = "toli.db · words";

                    MessageBox.Show("Санасан үгс цэвэрлэгдлээ!");

                    LoadWords();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // 14. HAIRALTIIN PLACEHOLDER
       
        private void textBox1_Enter(object? sender, EventArgs e)
        {
            if (textBox1.Text == "Хайх үг...")
                textBox1.Clear();
        }

        private void textBox1_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                textBox1.Text = "Хайх үг...";
        }
        // BUSAD EVENT

        private void label1_Click(object? sender, EventArgs e) { }

        private void label2_Click(object? sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(
            object? sender, DataGridViewCellEventArgs e)
        { }

        private void comboBox2_SelectedIndexChanged(
            object? sender, EventArgs e)
        { }

        private void lblDbInfo_Click(object? sender, EventArgs e) { }

        private void panel1_Paint(object? sender, PaintEventArgs e) { }

        private void label6_Click(object? sender, EventArgs e) { }

        private void label7_Click(object? sender, EventArgs e) { }
    }
}