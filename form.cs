 private void button1_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server = IP; user id = visual; password = password;persistsecurityinfo=True;database=quotes;";

            
                int quoteID = Convert.ToInt32(inQuoteID.Text);

                try
                {
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    string sql = "Select * FROM quotes where id = @id";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", quoteID);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        outPerson.Text = (string)reader["person"];
                        outQuote.Text = (string)reader["quote"];
                        randomQuoteID();
                    }
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
