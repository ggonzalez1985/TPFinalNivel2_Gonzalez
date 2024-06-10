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
    public partial class frmCategorias : Form
    {
        private List<Categoria> listaCategorias;
        private Categoria micategoria = null;
        private frmPpalArticulos _padreForm;
        private frmAltaArticulo frmAltaArticulo;
        private string IdCategoriaCargadaNueva;
        private int rowIndex;

        public frmCategorias()
        {
            InitializeComponent();
            Helper.ConfigurarDG(dgvCategorias);
        }

        public frmCategorias(frmPpalArticulos parentForm)
        {
            InitializeComponent();
            Helper.ConfigurarDG(dgvCategorias);
            _padreForm = parentForm;
        }

        public frmCategorias(frmAltaArticulo padreForm)
        {
            InitializeComponent();
            Helper.ConfigurarDG(dgvCategorias);
            frmAltaArticulo = padreForm;
        }


        private void cargar()
        {
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                listaCategorias = categoria.listar();
                dgvCategorias.DataSource = listaCategorias;
                ocultarColumnas();
                Helper.AjustarColumnas(dgvCategorias);
                lblCantidad.Text = dgvCategorias.RowCount.ToString();
                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvCategorias.Columns["Id"].Visible = false;
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargar();
            txtCategoria.ReadOnly = true;
            btnAceptar.Enabled = false;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!(txtCategoria.ReadOnly))
            {
                DialogResult respuesta = MessageBox.Show("¿Desea cancelar la operacion?", "Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                Categoria seleccionada = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;
                txtCategoria.Text = seleccionada.Descripcion;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
            btnEditar.Enabled = false;
            
            txtCategoria.ReadOnly = false;
            txtCategoria.Text = "";
            txtCategoria.Focus();
            micategoria = new Categoria();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            micategoria.Descripcion = txtCategoria.Text;

            if (txtCategoria.Text != "")
            {
                try
                {
                    if (micategoria.Id != 0)
                    { 
                        negocio.modificar(micategoria);
                        
                        MessageBox.Show("Categoria Modificada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar();
                    }
                    else
                    {
                        negocio.Agregar(micategoria);
                        
                        MessageBox.Show("Categoria Agregada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar();
                        btnEditar.Enabled = true;
                    }

                    IdCategoriaCargadaNueva = micategoria.Descripcion;

                    txtCategoria.Text = "";
                    dgvCategorias.Focus();
                    micategoria = null;
                    txtCategoria.ReadOnly = true;
                    btnAceptar.Enabled = false;

                    Helper.ActualizarIndiceDataGridView(dgvCategorias, rowIndex);

                }
                    catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                MessageBox.Show("El campo NOMBRE es obligatorio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoria.Focus();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            micategoria = new Categoria();

            btnAceptar.Enabled = true;
            txtCategoria.ReadOnly = false ;
            
            rowIndex = dgvCategorias.SelectedRows[0].Index;          

            micategoria.Id = (int)dgvCategorias.Rows[rowIndex].Cells["Id"].Value;

        }

        private void frmCategorias_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_padreForm != null)
            {
                _padreForm.ActualizarDataGridView();
            }

            if (frmAltaArticulo != null)
            {
                frmAltaArticulo.ActualizarComboCategoriaConId(IdCategoriaCargadaNueva);

            }
        }

        private void frmCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtCategoria.Text != "")
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
