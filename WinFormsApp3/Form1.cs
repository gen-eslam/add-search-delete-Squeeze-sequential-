namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//insert data to file
        {
            FileStream fileStream = new FileStream(textBox1.Text, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStream);
            String line = textBox5.Text + ',' + textBox2.Text;
            sw.WriteLine(line);
            sw.Flush();
            sw.Close();
            fileStream.Close();
            MessageBox.Show("inserted");
            textBox5.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)//search by id
        {
            StreamReader sr = new StreamReader(textBox1.Text);
            String line;
            while ((line = sr.ReadLine()) != null) 
            {
                String[] split = line.Split(',');
                if (textBox6.Text == split[0]) 
                {
                    textBox3.Text = split[1];
                    sr.Close();
                    return;
                }

            }
            MessageBox.Show("not found");
            sr.Close();

        }

        private void button4_Click(object sender, EventArgs e)//delete
        {
            FileStream fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            StreamWriter sw = new StreamWriter(fs);
            String line;
            int count = 0;
            
            while ((line = sr.ReadLine()) != null)
            {
                String[] split = line.Split(',');
                if (textBox4.Text == split[0])
                {
                    fs.Seek(count, SeekOrigin.Begin);
                    fs.Flush();
                    sw.Write("*");
                    sw.Flush();
                    MessageBox.Show("done");
                    textBox4.Clear();
                    sw.Close();
                    sr.Close();

                    fs.Close();

                    return;
                }
                count += line.Length + 2;

            }
            MessageBox.Show("not found");
            sw.Close();
            sr.Close();
           
            fs.Close();




        }

        private void button6_Click(object sender, EventArgs e)//squeeze   same copy file with condition
        {
            StreamReader streamReader = new StreamReader(textBox1.Text);
            FileStream file = new FileStream("fares.txt", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(file);
            String? line;
            while ((line = streamReader.ReadLine()) != null) 
            {
                if (line[0] != '*') 
                {
                    streamWriter.WriteLine(line);
                    streamWriter.Flush();
                    
                }
                


            }
            streamReader.Close();  
            streamWriter.Close();
            file.Close();   


        }

        private void button5_Click(object sender, EventArgs e)//read all file
        {
            FileStream fileStream = new FileStream(textBox1.Text,FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader (fileStream);
            textBox7.Text = streamReader.ReadToEnd();
            streamReader.Close();
            fileStream.Close();

        }
    }
}