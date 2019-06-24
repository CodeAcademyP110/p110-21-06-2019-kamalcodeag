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
    public partial class Form1 : Form
    {
        //Connection connected
        private  readonly EplEntities eplEntities;
        public Form1()
        {
            InitializeComponent();
            eplEntities = new EplEntities();
        }

        private void LoadDataBase()
        {
            //eplEntities = new EplEntities();
            dgw.DataSource = eplEntities.EPLplayers
                .Select(delegate (EPLplayer eplplayer)
                {
                    return new
                    {
                        Id = eplplayer.id,
                        Name = eplplayer.name,
                        Surname = eplplayer.surname,
                        Age = eplplayer.age,
                        Club = eplplayer.EPLclub,
                        Position = eplplayer.EPLposition
                    };  
                })
                .ToList();
            cmbPosition.Items.AddRange(eplEntities.EPLpositions.ToArray());
            cmbClub.Items.AddRange(eplEntities.EPLclubs.ToArray());
            
        }

        private void ResetInputs()
        {
            txtName.Text = txtSurname.Text = txtAge.Text = string.Empty;
            cmbPosition.SelectedIndex = cmbClub.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataBase();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            string nameText = txtName.Text.Trim();
            string surnameText = txtSurname.Text.Trim();
            string ageText = txtAge.Text.Trim();

            EPLposition SelectedEplposition = cmbPosition.SelectedItem as EPLposition;
            EPLclub SelectedEplclub = cmbClub.SelectedItem as EPLclub;

            EPLplayer eplplayer = new EPLplayer
            {
                name = nameText,
                surname = surnameText,
                age = Convert.ToByte(ageText),
                positionId = SelectedEplposition.id,
                clubId = SelectedEplclub.id
            };

            eplEntities.EPLplayers.Add(eplplayer);
            await eplEntities.SaveChangesAsync();
            MessageBox.Show("Successfully added");
            ResetInputs();
            LoadDataBase();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.FormClosed += OnFormClosed;
            form2.ShowDialog();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDataBase();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
