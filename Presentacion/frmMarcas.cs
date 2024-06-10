using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMarcas : Form
    {
        private List<Marca> listaMarcas;
        private Marca mimarca = null;
        private int rowIndex;
        private string IdMarcaCargadaNueva;
        private frmPpalArticulos _padreForm;
        private frmAltaArticulo frmAltaArticulo;

        public frmMarcas()
        {
            InitializeComponent();
            Helper.ConfigurarDG(dgvMarca);
        }

        public frmMarcas(frmPpalArticulos parentForm) 
        {
            InitializeComponent();
            Helper.ConfigurarDG(dgvMarca);
            _padreForm = parentForm;
        }

        public frmMarcas(frmAltaArticulo padreForm) 
        {
            InitializeComponent();
            Helper.ConfigurarDG(dgvMarca);
            frmAltaArticulo = padreForm;
        }

        private void cargar()
        {
            MarcaNegocio marca = new MarcaNegocio();
            try
            {
                listaMarcas = marca.listar();
                dgvMarca.DataSource = listaMarcas;
                ocultarColumnas();
                Helper.AjustarColumnas(dgvMarca);
                lblCantidad.Text = dgvMarca.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvMarca.Columns["Id"].Visible = false;
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargar();
            txtMarca.ReadOnly = true;
            btnAceptar.Enabled = false;
            
        }

        private void dgvMarca_SelectionChanged(object sender, EventArgs e)
        {
           
            if (dgvMarca.SelectedRows.Count > 0)
            {
                Marca seleccionada = (Marca)dgvMarca.SelectedRows[0].DataBoundItem;
                txtMarca.Text = seleccionada.Descripcion;
            }

        }

        public void btnNuevo_Click_1(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
            btnEditar.Enabled = false;

            txtMarca.ReadOnly=false;
            txtMarca.Text = "";
            txtMarca.Focus();
            mimarca = new Marca();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            {
                MarcaNegocio marca = new MarcaNegocio();

                mimarca.Descripcion = txtMarca.Text;

                if (txtMarca.Text != "")
                {
                    try
                    {
                        if (mimarca.Id != 0)
                        {
                        
                            marca.modificar(mimarca);

                            MessageBox.Show("Marca Modificada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargar();

                        }
                        else
                        {
                            marca.Agregar(mimarca);
                        
                            MessageBox.Show("Marca Agregada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargar();
                            btnEditar.Enabled = true;
                        }

                        IdMarcaCargadaNueva = mimarca.Descripcion;

                        txtMarca.Text = "";
                        dgvMarca.Focus();
                        mimarca = null;
                        txtMarca.ReadOnly = true;
                        btnAceptar.Enabled = false;

                        Helper.ActualizarIndiceDataGridView(dgvMarca, rowIndex);

                    }
                        catch (Exception)
                    {

                        throw;
                    }

                }
                else
                {
                    {
                        MessageBox.Show("El campo NOMBRE es obligatorio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMarca.Focus();
                    }
                }

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                mimarca = new Marca();

                btnAceptar.Enabled = true;
                txtMarca.ReadOnly = false;
                txtMarca.Focus();

                rowIndex = dgvMarca.SelectedRows[0].Index;
                mimarca.Id = (int)dgvMarca.Rows[rowIndex].Cells["Id"].Value;
  
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (!(txtMarca.ReadOnly))
            {
                DialogResult respuesta = MessageBox.Show("¿Desea cancelar la operacion?", "Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void frmMarcas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_padreForm != null) { 
            _padreForm.ActualizarDataGridView();
            }

            if (frmAltaArticulo != null) 
            { 
            frmAltaArticulo.ActualizarComboMarcaConId(IdMarcaCargadaNueva);
            }
        }

        private void frmMarcas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtMarca.Text != "")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea cancelar la operacion?", "Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }
        }
    }
}
