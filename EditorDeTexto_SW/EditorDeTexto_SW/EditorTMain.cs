using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditorDeTexto_SW
{
    public partial class EditorTMain : Form
    {
        public EditorTMain()
        {
            InitializeComponent();
        }

        private void EditorTMain_Load(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           EditorSW.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            System.IO.StreamReader myStreamReader = null;
            Open.Filter = "Text [*.txt*]|*.txt|All Files [*,*]|*,*";
            Open.CheckFileExists = true;
            Open.Title = "Abrir Archivo";
            Open.ShowDialog(this);
            try
            {
                Open.OpenFile();
                myStreamReader = System.IO.File.OpenText(Open.FileName);
                EditorSW.Text = myStreamReader.ReadToEnd();

            }
            catch (Exception) { }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Save = new SaveFileDialog();
            System.IO.StreamWriter myStreamWriter = null;
           Save.Filter = "Text (*.txt)|*.txt|HTML(*.html*)|*.html|All files(*.*)|*.*";
            Save.CheckPathExists = true;
            Save.Title = "Guardar como";
            Save.ShowDialog(this);
            try
            {
                myStreamWriter = System.IO.File.AppendText(Save.FileName);
                myStreamWriter.Write(EditorSW.Text);
                myStreamWriter.Flush();

            }
            catch (Exception) { }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fuenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();         
            font.Font = EditorSW.Font;
            if (font.ShowDialog() == DialogResult.OK)
            {
                EditorSW.Font = font.Font;
            }
        }

        private void colorDeLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
           if (color.ShowDialog() == DialogResult.OK)
            {
                EditorSW.ForeColor = color.Color;
            }
        }

        private void colorDeFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fondo = new ColorDialog();
            if (fondo.ShowDialog() == DialogResult.OK)
            {
                EditorSW.BackColor = fondo.Color;
            }
        }

        private void nosotrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nostros frm = new Nostros();
            frm.Show();
        }
    }
}
