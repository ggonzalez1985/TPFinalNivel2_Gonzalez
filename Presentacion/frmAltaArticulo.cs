using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAltaArticulo : Form
    {
        private OpenFileDialog archivo = null;
        private Articulo miarticulo = null;
        private Articulo articulo = null;
        private bool datosCargados = false;
        frmPpalArticulos frmPpalArticulos = new frmPpalArticulos();

        public frmAltaArticulo()
        {
            InitializeComponent();
            btnEditar.Enabled = false;
        }

        public frmAltaArticulo(frmPpalArticulos frmPpalArt)
        {
            InitializeComponent();
            this.frmPpalArticulos = frmPpalArt;
            
        }

        public frmAltaArticulo(Articulo articulo, List<Marca> lista1, List<Categoria> lista2, bool datosCargados)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.datosCargados = datosCargados;

            Text = "Modificar Articulo";
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtImagen.Text = articulo.ImagenUrl;
            txtPrecio.Text = articulo.Precio.ToString("N2");                    

            cargarImagen(articulo.ImagenUrl);

            cboMarca.DataSource = lista1;
            cboMarca.DisplayMember = "Descripcion"; 
            cboMarca.ValueMember = "Id"; 

            cboCategoria.DataSource = lista2;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "Id";

            if (articulo.IdMarca != null)
            {
                cboMarca.SelectedValue = articulo.IdMarca.Id;
                
            }
            if (articulo.IdCategoria != null)
            {
                cboCategoria.SelectedValue = articulo.IdCategoria.Id;
                
            }

        }

        public frmAltaArticulo(Articulo articulo, List<Marca> lista1, List<Categoria> lista2, bool datosCargados, int aux)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.datosCargados = datosCargados;
            aux = 1;

            Text = "Modificar Articulo";
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtImagen.Text = articulo.ImagenUrl;
            txtPrecio.Text = articulo.Precio.ToString("N2");

            btnEditar.Enabled = false;
            txtCodigo.Enabled = false;
          
            cargarImagen(articulo.ImagenUrl);

            cboMarca.DataSource = lista1;
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.ValueMember = "Id";

            cboCategoria.DataSource = lista2;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "Id";

            if (articulo.IdMarca != null)
            {
                cboMarca.SelectedValue = articulo.IdMarca.Id;

            }
            if (articulo.IdCategoria != null)
            {
                cboCategoria.SelectedValue = articulo.IdCategoria.Id;

            }

        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            if (!datosCargados)
            {
                MarcaNegocio elementoMarca = new MarcaNegocio();
                CategoriaNegocio elementoCategoria = new CategoriaNegocio();

                try
                {

                    cboMarca.DataSource = elementoMarca.listar();
                    cboMarca.ValueMember = "Id";
                    cboMarca.DisplayMember = "Descripcion";
                    cboCategoria.DataSource = elementoCategoria.listar();
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";
                    datosCargados = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }

        }

        private void cargarImagen(string DireccionImagen)
        {
            try
            {
                ptbArticulo.Load(DireccionImagen);
            }
            catch (Exception ex)
            {
                string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "Resources", "img-no-disponibleNVO.jpg");
                ptbArticulo.Load(rutaImagenRespaldo);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio Negocio = new ArticulosNegocio();

            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtDescripcion.Text != "")
            { 
                try
                {
                    if (miarticulo == null)
                    {
                        miarticulo = new Articulo();

                        miarticulo.Codigo = txtCodigo.Text;
                        miarticulo.Nombre = txtNombre.Text;
                        miarticulo.Descripcion = txtDescripcion.Text;
                        miarticulo.IdMarca = (Marca)cboMarca.SelectedItem;
                        miarticulo.IdCategoria = (Categoria)cboCategoria.SelectedItem;

                        if (txtImagen.Text != "")
                        {
                            miarticulo.ImagenUrl = txtImagen.Text;
                        } else
                        {
                            miarticulo.ImagenUrl = "-";
                        }

                        if (txtPrecio.Text != "")
                        {
                            miarticulo.Precio = decimal.Parse(txtPrecio.Text);
                        }else
                        {
                            miarticulo.Precio = 0.00m;
                        }
                        
                    }

                    if (txtCodigo.Text != "") ;
                        string CodAux = txtCodigo.Text;

                        miarticulo.Id = Negocio.ObtenerIdArticulos(CodAux); 

                    if (miarticulo.Id != 0)
                    {
                        Negocio.EditarArticulo(miarticulo);
                        LimpiarControles();
                        MessageBox.Show("Articulo Modificado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Helper.BloquearCampos(this);
                    
                        btnEditar.Enabled = false;

                }
                    else
                    {
                        Negocio.Agregar(miarticulo);
                        LimpiarControles();
                        MessageBox.Show("Articulo Agregado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                    catch (Exception)
                    {
                        throw;
                    }
            } else
            {
                if (txtCodigo.Text == "") 
                {
                    MessageBox.Show("El campo CODIGO es obligatorio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Focus();
                } else
                {
                    if (txtNombre.Text == "")
                    { 
                        MessageBox.Show("El campo NOMBRE es obligatorio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNombre.Focus();
                    }else
                    {
                        if (txtDescripcion.Text == "")
                        {
                            MessageBox.Show("El campo DESCRIPCION es obligatorio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDescripcion.Focus();
                        }   
                    }
                }    
            }
        }

        public void LimpiarControles()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtImagen.Text = "";
            txtPrecio.Text = "";
            ptbArticulo.Image = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" || txtNombre.Text != "" || txtDescripcion.Text != "")
            {
                DialogResult respuesta = MessageBox.Show("¿Desea cancelar la operacion?", "Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    Close();
                }
            }   
                Close();
        }

        public void ActualizarComboMarcaConId(string Marca)
        {
            MarcaNegocio elementoMarca = new MarcaNegocio();

            try
            {
                cboMarca.DataSource = elementoMarca.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                foreach (var item in cboMarca.Items)
                {
                    
                    Marca marca = (Marca)item;
                    if (marca.Descripcion == Marca)
                    {
                        cboMarca.SelectedItem = item;
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ActualizarComboCategoriaConId(string IdCategoriaCargadaNueva)
        {
            CategoriaNegocio elementoCategoria = new CategoriaNegocio();

            try
            {
                cboCategoria.DataSource = elementoCategoria.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                foreach (var item in cboCategoria.Items)
                {
                    
                    Categoria Catego = (Categoria)item;
                    if (Catego.Descripcion == IdCategoriaCargadaNueva)
                    {
                        cboCategoria.SelectedItem = item;
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            } 


        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategorias = new frmCategorias(this);
            frmCategorias.ShowDialog();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            frmMarcas frmMarcas = new frmMarcas(this);
            frmMarcas.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Helper.HabilitarCampos(this);
            txtNombre.Focus();
        }

        private void frmAltaArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmPpalArticulos != null)
            {
                frmPpalArticulos.ActualizarDataGridView();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            txtCodigo.Text = txtCodigo.Text.ToUpper();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            TextBox txtPrecioMin = (TextBox)sender;

            if (!string.IsNullOrWhiteSpace(txtPrecioMin.Text))
            {
                txtPrecioMin.Text = string.Format(CultureInfo.CurrentCulture, "{0:N0}", decimal.Parse(txtPrecioMin.Text));
            }
        }

        private void frmAltaArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtCodigo.Text != "" || txtNombre.Text != "" || txtDescripcion.Text != "")
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
            

