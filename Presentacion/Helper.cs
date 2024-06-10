using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.IO;

namespace Presentacion
{
    public static class Helper
    {
            public static void ConfigurarDG(DataGridView dgv)
            {
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                               
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                dgv.DefaultCellStyle.Font = new Font("Arial", 10);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                dgv.EnableHeadersVisualStyles = false;

                dgv.AllowUserToResizeRows = false;
                dgv.AllowUserToResizeColumns = false;
                dgv.RowHeadersVisible = true;
                dgv.RowHeadersWidth = 25;            
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

        public static void AjustarColumnas(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name == "Precio")
                    dgv.Columns["Precio"].DefaultCellStyle.Format = "$ #,##0.00";

                else if (column.Name == "Descripcion")
                    dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    else if (column.Name == "Codigo")
                            dgv.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                            else if (column.Name == "Nombre")
                            dgv.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            }

           

        }

        public static void ActualizarIndiceDataGridView(DataGridView dgv, int rowIndex)
        {

            if (rowIndex >= 0 && rowIndex < dgv.Rows.Count)
            {
                dgv.CurrentCell = dgv.Rows[rowIndex].Cells[1];
            }
        }

        public static void cargarImagen(string DireccionImagen, PictureBox pvxAux)
        {
            try
            {
                pvxAux.Load(DireccionImagen);
            }
            catch (Exception ex)
            {
                string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "Resources", "img-no-disponibleNVO.jpg");
                pvxAux.Load(rutaImagenRespaldo);
            }

        }

        

        public static void ActualizarImagenConIndice(DataGridView dgv, int FilaIndedx, PictureBox pvxAux)
        {
            if (FilaIndedx >= 0 && FilaIndedx < dgv.Rows.Count)
            {
                string urlImagen = dgv.Rows[FilaIndedx].Cells["ImagenUrl"].Value.ToString();
                cargarImagen(urlImagen, pvxAux);
            }

        }

        public static void BloquearCampos(frmAltaArticulo FormArticulo)
        {
            FormArticulo.txtCodigo.Enabled = false;
            FormArticulo.txtNombre.Enabled = false;
            FormArticulo.txtDescripcion.Enabled = false;
            FormArticulo.cboMarca.Enabled = false;
            FormArticulo.cboCategoria.Enabled = false;
            FormArticulo.txtImagen.Enabled = false;
            FormArticulo.txtPrecio.Enabled = false;
            FormArticulo.btnImagen.Enabled = false;
            FormArticulo.btnCategoria.Enabled = false;
            FormArticulo.btnMarca.Enabled = false;
            FormArticulo.btnAceptar.Enabled = false;
        }

        public static void HabilitarCampos(frmAltaArticulo FormArticulo)
        {
            FormArticulo.txtCodigo.Enabled = true;
            FormArticulo.txtNombre.Enabled = true;
            FormArticulo.txtDescripcion.Enabled = true;
            FormArticulo.txtCodigo.Enabled = false;
            FormArticulo.cboMarca.Enabled = true;
            FormArticulo.cboCategoria.Enabled = true;
            FormArticulo.txtImagen.Enabled = true;
            FormArticulo.txtPrecio.Enabled = true;
            FormArticulo.btnImagen.Enabled = true;
            FormArticulo.btnCategoria.Enabled = true;
            FormArticulo.btnMarca.Enabled = true;
            FormArticulo.btnAceptar.Enabled = true;
        }



    }
}
