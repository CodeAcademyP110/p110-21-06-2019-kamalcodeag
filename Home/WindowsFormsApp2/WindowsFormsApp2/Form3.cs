using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        private readonly EplEntities eplEntities;

        public Form3()
        {
            InitializeComponent();
            eplEntities = new EplEntities();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbPlayers.Items.AddRange(eplEntities.EPLplayers.ToArray());
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            EPLplayer eplplayer = (EPLplayer)cmbPlayers.SelectedItem;
            eplEntities.EPLplayers.Remove(eplplayer);
            MessageBox.Show("Deleted");
            await eplEntities.SaveChangesAsync();
            cmbPlayers.Items.Clear();
            cmbPlayers.Items.AddRange(eplEntities.EPLplayers.ToArray());
        }
    }
}
