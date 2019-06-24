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
    public partial class Form2 : Form
    {
        private readonly EplEntities eplEntities;
        public Form2()
        {
            InitializeComponent();
            eplEntities = new EplEntities();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            //Why cannot i apply SELECT instead of Partial Class ???
            cmbFullname.Items.AddRange(eplEntities.EPLplayers.ToArray());
            cmbPosition.Items.AddRange(eplEntities.EPLpositions.ToArray());
            cmbClub.Items.AddRange(eplEntities.EPLclubs.ToArray());
            lblPosition.Visible = false;
            lblClub.Visible = false;
            cmbPosition.Visible = false;
            cmbClub.Visible = false;
        }

        private void CmbFullname_SelectedIndexChanged(object sender, EventArgs e)
        {
            EPLplayer selectedEplplayer = cmbFullname.SelectedItem as EPLplayer;

            cmbPosition.SelectedIndex = Convert.ToInt32(selectedEplplayer.positionId - 1); // Convertion ???
            cmbClub.SelectedIndex = Convert.ToInt32(selectedEplplayer.clubId - 1);

            lblPosition.Visible = true;
            cmbPosition.Visible = true;
            lblClub.Visible = true;
            cmbClub.Visible = true;
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            EPLplayer fullnameText = (EPLplayer)cmbFullname.SelectedItem;
            EPLclub eplclub = (EPLclub)cmbClub.SelectedItem;

            fullnameText.clubId = eplclub.id;
            MessageBox.Show("Updated");
            await eplEntities.SaveChangesAsync();
        }

    
    }
}
