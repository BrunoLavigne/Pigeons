using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PigeonsLibrairy;
using PigeonsLibrairy.DAO;

namespace FunctionsTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PersonDAO personDAO = new PersonDAO();
            }
            catch (Exception)
            {
                throw;
            }
            MessageBox.Show("A person have been added to the database");
        }
    }
}
