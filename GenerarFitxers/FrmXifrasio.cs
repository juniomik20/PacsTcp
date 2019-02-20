using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace GenerarFitxers
{
    public partial class FrmXifrasio : Form
    {
        public FrmXifrasio()
        {
            InitializeComponent();
        }
        string sourceDir = Application.StartupPath + @"\\Fitxers\\Cifrar\\";
        public String[] lletres = new String[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public String[] crearLletres(int numeroFitxer)
        {
            String rutaFi =  Application.StartupPath+ @"\\Fitxers\\Cifrar\\LetrasPacs" + numeroFitxer+".txt";
            Random obj = new Random();
           String[] lletresRandom = new String[1000000];
            
            String codi = "";
            StreamWriter file = new StreamWriter(rutaFi, true);
                for (int x = 0; x < lletresRandom.Length; x++)
                {
                    int randomNumero = obj.Next(0,25);
                    codi = lletres[randomNumero];
                    file.Write(codi);
                    lletresRandom[x] = codi;
                }
                file.Close();
            return lletresRandom;
        }
        public void crearFitxers() {
            String[] lletresRandom = new String[16000000];
            for (int i = 1; i< 5; i++) {
               lletresRandom = crearLletres(i);
                XifrarLLetraNum(lletresRandom, i);
            }
            concatArxius(Application.StartupPath + @"\\Fitxers\\PacsSolServer.txt");
        }
        public string[] CodiLletraCreacio()
        {
            SqlConnection connexxion = new SqlConnection();
            connexxion.ConnectionString = ConfigurationManager.ConnectionStrings["RepublicSystemConnectionString"].ConnectionString;
            connexxion.Open();

            DataSet dtsCli = new DataSet();

            string query = "SELECT Numbers from InnerEncryptionData where IdInnerEncryption = 24"; // and b.Day = '" + Convert.ToDateTime(DateTime.Today).ToString("yyyy-MM-dd") + "'";
           
            SqlDataAdapter adapter = new SqlDataAdapter(query, connexxion);
            adapter.Fill(dtsCli);

            string[] LletraCodi = new string[26];

            for (int i = 0; i < LletraCodi.Length; i++)
            {
                
                LletraCodi[i] = dtsCli.Tables[0].Rows[i][0].ToString();
                
            }

            return LletraCodi;
        }
        public void  borrarArchivos() {
            string[] txtList = Directory.GetFiles(sourceDir, "*.txt");
            string[] txtDirList = Directory.GetFiles(Application.StartupPath + @"\\Fitxers\\", "*.txt");
            string[] zipList = Directory.GetFiles(Application.StartupPath + @"\\Fitxers\\", "*.zip");

            foreach (string f in txtList)
            {
                File.Delete(f);
            }
            foreach (string f in txtDirList)
            {
                File.Delete(f);
            }
            foreach (string f in zipList)
            {
                File.Delete(f);
            }





        }
        private void XifrarLLetraNum(string [] crearLletres, int z)
        {
            string[] codiLletra = new string[26];

            bool verifica;
            string rutaFitxer = Application.StartupPath + @"\\Fitxers\\Cifrar\\PACS" + z+".txt";
            codiLletra = CodiLletraCreacio();
            StreamWriter XifratNums = new StreamWriter(rutaFitxer);
            for (int i = 0; i < crearLletres.Length; i++)
            {
                verifica = false;
                for (int x = 0; x < lletres.Length && verifica == false; x++)
                {
                    if (crearLletres[i].Equals(lletres[x]))
                    {
                        XifratNums.Write(codiLletra[x]);
                        verifica = true;
                    }
                }
            }

            XifratNums.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            borrarArchivos();
            crearFitxers();
            MessageBox.Show("Has generat una moguda que flipas");
        }

        public void concatArxius(string ruta)
        {
            string A1 = File.ReadAllText(Application.StartupPath + @"\\Fitxers\\Cifrar\\LetrasPacs1.txt");
            string A2 = File.ReadAllText(Application.StartupPath + @"\\Fitxers\\Cifrar\\LetrasPacs2.txt");
            string A3 = File.ReadAllText(Application.StartupPath + @"\\Fitxers\\Cifrar\\LetrasPacs3.txt");
            string A4 = File.ReadAllText(Application.StartupPath + @"\\Fitxers\\Cifrar\\LetrasPacs4.txt");

            File.WriteAllText(ruta, A1 + A2 + A3 + A4);

            string[] txtList = Directory.GetFiles(sourceDir, "LetrasPacs*.txt");

            foreach (string f in txtList)
            {
                File.Delete(f);
            }
        }

    }
}
