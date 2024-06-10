using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using Presentacion.Properties;

namespace Presentacion
{
    public partial class frmPpalArticulos : Form
    {
        private List<Articulo> listaArticulos;
        private int selectedRowIndex = -1;
        private int indiceFilaSeleccionada = -1;
        private int rowIndex;
        private bool limpiandoSeleccion = false;

        public frmPpalArticulos()
        {
            InitializeComponent();
            Helper.ConfigurarDG(dgvArticulos);  
        }

        private void cargar()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            MarcaNegocio elementoMarca = new MarcaNegocio();
            CategoriaNegocio elementoCategoria = new CategoriaNegocio();

            try
            {
                try
                {
                    cboMarca.DataSource = elementoMarca.listar();
                    cboMarca.ValueMember = "Id";
                    cboMarca.DisplayMember = "Descripcion";
                    cboCategoria.DataSource = elementoCategoria.listar();
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

                listaArticulos = negocio.Listararticulos();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                Helper.AjustarColumnas(dgvArticulos);
                lblCantidad.Text = dgvArticulos.RowCount.ToString();
                               
                if (indiceFilaSeleccionada != -1 && indiceFilaSeleccionada < dgvArticulos.Rows.Count)
                {
                    dgvArticulos.Rows[indiceFilaSeleccionada].Selected = true;
                                        
                    string urlImagen = listaArticulos[indiceFilaSeleccionada].ImagenUrl;
                    Helper.cargarImagen(urlImagen, pbxImagen);
                }

                if (indiceFilaSeleccionada == -1 && indiceFilaSeleccionada < dgvArticulos.Rows.Count)
                {
                    cargarImagen(listaArticulos[0].ImagenUrl); //para ver si carga la 1era vez
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void AdjustComboBoxDropDownWidth(System.Windows.Forms.ComboBox comboBox)
        {
            int maxWidth = comboBox.DropDownWidth;
            using (Graphics g = comboBox.CreateGraphics())
            {
                foreach (var item in comboBox.Items)
                {
                    int itemWidth = (int)g.MeasureString(item.ToString(), comboBox.Font).Width;
                    if (itemWidth > maxWidth)
                    {
                        maxWidth = itemWidth;
                    }
                }
            }
            comboBox.DropDownWidth = maxWidth + SystemInformation.VerticalScrollBarWidth;
        }



        private void cargarImagen(string imagen)
        {
            try
            {
                
                pbxImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "Resources", "img-no-disponibleNVO.jpg");
                pbxImagen.Load(rutaImagenRespaldo);
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false; 
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            AdjustComboBoxDropDownWidth(cboCategoria);
            AdjustComboBoxDropDownWidth(cboMarca);
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo AltaArticulo = new frmAltaArticulo();  
            AltaArticulo.ShowDialog();
            cargar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void agregarVisualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias AltaCategoria = new frmCategorias(this);
            AltaCategoria.ShowDialog();
        }

        private void agregarVisualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMarcas AltaMarca = new frmMarcas(this);
            AltaMarca.ShowDialog();
        }

        public void ActualizarDataGridView()
        {
            dgvArticulos.DataSource = null; 
            cargar();
        }

        private void agregarVisualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAltaArticulo AltaNva = new frmAltaArticulo();
            AltaNva.ShowDialog();
            cargar() ;
        }


        private void txtBuscador_TextChanged(object sender, EventArgs e) 
        {

            string textoBuscado = txtBuscador.Text.Trim().ToLower();

            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvArticulos.DataSource];
            currencyManager.SuspendBinding();

            try
            {
                foreach (DataGridViewRow fila in dgvArticulos.Rows)
                {
                    string descripcion = fila.Cells["Nombre"].Value.ToString().ToLower();

                    bool todosFragmentosEncontrados = true;
                    foreach (string fragmento in textoBuscado.Split(' '))
                    {
                        if (!descripcion.Contains(fragmento))
                        {
                            todosFragmentosEncontrados = false;
                            break;
                        }
                    }

                    fila.Visible = todosFragmentosEncontrados || string.IsNullOrWhiteSpace(textoBuscado);
                }
            }
            finally
            {
               currencyManager.ResumeBinding();
            }


        }

        private void dgvArticulos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MarcaNegocio elementoMarca = new MarcaNegocio();
            CategoriaNegocio elementoCategoria = new CategoriaNegocio();

            rowIndex = dgvArticulos.SelectedRows[0].Index;

            if (e.RowIndex >= 0)
            {
                Articulo articulo = (Articulo)dgvArticulos.Rows[e.RowIndex].DataBoundItem;
                                
                List<Marca> lista1 = elementoMarca.listar(); 
                List<Categoria> lista2 = elementoCategoria.listar();

                frmAltaArticulo frm = new frmAltaArticulo(articulo, lista1, lista2, true);
                Helper.BloquearCampos(frm);
                frm.ShowDialog();

                cargar();

                Helper.ActualizarIndiceDataGridView(dgvArticulos, rowIndex);
                
            }   
        }

        private void dgvArticulos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentCell != null)
            {
                selectedRowIndex = dgvArticulos.CurrentCell.RowIndex;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0) 
            {
                MarcaNegocio elementoMarca = new MarcaNegocio();
                CategoriaNegocio elementoCategoria = new CategoriaNegocio();

                rowIndex = dgvArticulos.SelectedRows[0].Index;
                int aux = 1;                
                Articulo articulo = (Articulo)dgvArticulos.Rows[selectedRowIndex].DataBoundItem;
                              
                List<Marca> lista1 = elementoMarca.listar();
                List<Categoria> lista2 = elementoCategoria.listar();            

                frmAltaArticulo frm = new frmAltaArticulo(articulo, lista1, lista2, true, aux);
                
                frm.ShowDialog();

                cargar();

                Helper.ActualizarIndiceDataGridView(dgvArticulos, rowIndex);
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo articulo;
            ArticulosNegocio negocio = new ArticulosNegocio();

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar este Articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.Eliminar(articulo.Id);

                    MessageBox.Show("Articulo Eliminado!", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); 
            }

        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceFilaSeleccionada = e.RowIndex;
                DataGridViewRow row = dgvArticulos.Rows[e.RowIndex];
                Articulo articulo = row.DataBoundItem as Articulo;
                Helper.cargarImagen(articulo.ImagenUrl, pbxImagen);
            }
        }

        private void ptbCancelar_Click(object sender, EventArgs e)
        {
            txtBuscador.Text = "";
            txtBuscador.Focus();
            txtPrecioMax.Text = "";
            txtPrecioMin.Text = "";
            cargar();
        }

        private void txtPrecioMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioMin_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txtPrecioMin = (System.Windows.Forms.TextBox)sender;

            if (!string.IsNullOrWhiteSpace(txtPrecioMin.Text))
            {
                txtPrecioMin.Text = string.Format(CultureInfo.CurrentCulture, "{0:N0}", decimal.Parse(txtPrecioMin.Text));
            }
        }

        private void txtPrecioMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioMax_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txtPrecioMin = (System.Windows.Forms.TextBox)sender;

            if (!string.IsNullOrWhiteSpace(txtPrecioMin.Text))
            {
                txtPrecioMin.Text = string.Format(CultureInfo.CurrentCulture, "{0:N0}", decimal.Parse(txtPrecioMin.Text));
            }
        }

        private void cboCategoria_KeyPress(object sender, KeyPressEventArgs e) //poder borrar lo que trae el combobox para hacer un filtro mas general
        {
            // Permitir la tecla de retroceso (Borrar) y la tecla Suprimir (Delete)
            if (e.KeyChar == '\b' || e.KeyChar == 0x7F) // 0x7F representa la tecla Suprimir (Delete)
            {
                // Permitir la tecla
                e.Handled = false;
            }
            else
            {
                // Bloquear todas las demás teclas
                e.Handled = true;
            }
        }

        private void cboMarca_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == '\b' || e.KeyChar == 0x7F) 
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            string CategoriaArticulo = null, MarcaArticulo = null, PrecioMin = null, PrecioMax = null;

            try
            {
                if (!validarFiltro())
                    return;

                if (cboCategoria.SelectedItem != null && cboCategoria.SelectedItem.ToString() != "")
                {
                    CategoriaArticulo = cboCategoria.SelectedItem.ToString();
                }

                if (cboMarca.SelectedItem != null && cboMarca.SelectedItem.ToString() != "" )
                {
                     MarcaArticulo = cboMarca.SelectedItem.ToString();
                }

                if (txtPrecioMin.Text != "")
                {
                     PrecioMin = txtPrecioMin.Text;
                }

                if (txtPrecioMax.Text != "") 
                {
                     PrecioMax = txtPrecioMax.Text;
                }
                                
                lblCantidad.Text = negocio.filtrar(CategoriaArticulo, MarcaArticulo, PrecioMin, PrecioMax).Count.ToString();

                if (negocio.filtrar(CategoriaArticulo, MarcaArticulo, PrecioMin, PrecioMax).Count > 0)
                {
                    dgvArticulos.DataSource = negocio.filtrar(CategoriaArticulo, MarcaArticulo, PrecioMin, PrecioMax); 
                }
                else
                {
                    dgvArticulos.DataSource = negocio.filtrar(CategoriaArticulo, MarcaArticulo, PrecioMin, PrecioMax);
                    MessageBox.Show("No se encontraron resultados.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrecioMax.Text = "";
                    txtPrecioMin.Text = "";
                    txtBuscador.Focus();
                    cargar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool validarFiltro()
        {
            if (!string.IsNullOrEmpty(txtPrecioMin.Text) || !string.IsNullOrEmpty(txtPrecioMax.Text) || cboCategoria.SelectedItem != null || cboMarca.SelectedItem != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Establecer al menos un parametro para realizar el filtrado!", "Filtrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
        }

        private void frmPpalArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                    DialogResult respuesta = MessageBox.Show("¿Desea Salir?", "Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        Close();
                    }
                
            }
        }
    }
   
}
