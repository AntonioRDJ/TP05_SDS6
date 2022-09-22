using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace TP05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = inputPath.Text;  //./voosCorreto.xml ./voosErro.xml
            try
            {                            // Set the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.ValidationType = ValidationType.DTD;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                // Referências externas no XML
                settings.XmlResolver = new XmlUrlResolver();
                // Create the XmlReader object.
                XmlReader reader = XmlReader.Create(path, settings);
                // Parse the file. 
                while (reader.Read()) ;
                textBoxMessage.Text = "Analisado!";
            }
            catch (Exception exception)
            {
                textBoxMessage.Text = exception.Message;
            }
        }

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            textBoxMessage.Text = "Validation Error: " + e.Message;
        }

    }
}
