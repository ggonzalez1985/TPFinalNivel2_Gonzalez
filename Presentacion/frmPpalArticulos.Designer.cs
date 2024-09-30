namespace Presentacion
{
    partial class frmPpalArticulos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPpalArticulos));
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVisualizarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVisualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVisualizarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ptbCancelar = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPrecioMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPrecioMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCancelar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvArticulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(16, 53);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 51;
            this.dgvArticulos.RowTemplate.Height = 24;
            this.dgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(1075, 226);
            this.dgvArticulos.TabIndex = 1;
            this.dgvArticulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellClick);
            this.dgvArticulos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArticulos_CellMouseDoubleClick);
            this.dgvArticulos.CurrentCellChanged += new System.EventHandler(this.dgvArticulos_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Articulo a buscar:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(131, 25);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(339, 22);
            this.txtBuscador.TabIndex = 0;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.marcasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1461, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarVisualizarToolStripMenuItem2});
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.articulosToolStripMenuItem.Text = "Articulos";
            // 
            // agregarVisualizarToolStripMenuItem2
            // 
            this.agregarVisualizarToolStripMenuItem2.Name = "agregarVisualizarToolStripMenuItem2";
            this.agregarVisualizarToolStripMenuItem2.Size = new System.Drawing.Size(215, 26);
            this.agregarVisualizarToolStripMenuItem2.Text = "Agregar/Visualizar";
            this.agregarVisualizarToolStripMenuItem2.Click += new System.EventHandler(this.agregarVisualizarToolStripMenuItem2_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarVisualizarToolStripMenuItem});
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // agregarVisualizarToolStripMenuItem
            // 
            this.agregarVisualizarToolStripMenuItem.Name = "agregarVisualizarToolStripMenuItem";
            this.agregarVisualizarToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.agregarVisualizarToolStripMenuItem.Text = "Agregar/Visualizar";
            this.agregarVisualizarToolStripMenuItem.Click += new System.EventHandler(this.agregarVisualizarToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarVisualizarToolStripMenuItem1});
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.marcasToolStripMenuItem.Text = "Marcas";
            // 
            // agregarVisualizarToolStripMenuItem1
            // 
            this.agregarVisualizarToolStripMenuItem1.Name = "agregarVisualizarToolStripMenuItem1";
            this.agregarVisualizarToolStripMenuItem1.Size = new System.Drawing.Size(215, 26);
            this.agregarVisualizarToolStripMenuItem1.Text = "Agregar/Visualizar";
            this.agregarVisualizarToolStripMenuItem1.Click += new System.EventHandler(this.agregarVisualizarToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ptbCancelar);
            this.groupBox1.Controls.Add(this.dgvArticulos);
            this.groupBox1.Controls.Add(this.txtBuscador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1106, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador";
            // 
            // ptbCancelar
            // 
            this.ptbCancelar.Image = global::Presentacion.Properties.Resources.X;
            this.ptbCancelar.Location = new System.Drawing.Point(438, 25);
            this.ptbCancelar.Name = "ptbCancelar";
            this.ptbCancelar.Size = new System.Drawing.Size(30, 21);
            this.ptbCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCancelar.TabIndex = 3;
            this.ptbCancelar.TabStop = false;
            this.ptbCancelar.Click += new System.EventHandler(this.ptbCancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbxImagen);
            this.groupBox2.Location = new System.Drawing.Point(1133, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 306);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imagen";
            // 
            // pbxImagen
            // 
            this.pbxImagen.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxImagen.ErrorImage")));
            this.pbxImagen.Image = global::Presentacion.Properties.Resources.img_no_disponibleNVO;
            this.pbxImagen.Location = new System.Drawing.Point(6, 21);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(285, 279);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 1;
            this.pbxImagen.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEliminar);
            this.groupBox3.Controls.Add(this.btnEditar);
            this.groupBox3.Controls.Add(this.btnAgregarArticulo);
            this.groupBox3.Location = new System.Drawing.Point(12, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 76);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opciones";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Presentacion.Properties.Resources.elminararticulo;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(290, 27);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(94, 34);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::Presentacion.Properties.Resources.Editaarticulo;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(106, 27);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(94, 34);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "    Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Image = global::Presentacion.Properties.Resources.articulonuevo1;
            this.btnAgregarArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(6, 27);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(94, 34);
            this.btnAgregarArticulo.TabIndex = 6;
            this.btnAgregarArticulo.Text = "Nuevo";
            this.btnAgregarArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1270, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cantidad de registros:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(1414, 37);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(11, 16);
            this.lblCantidad.TabIndex = 14;
            this.lblCantidad.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Categoria:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Items.AddRange(new object[] {
            "\"\""});
            this.cboCategoria.Location = new System.Drawing.Point(81, 32);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(121, 24);
            this.cboCategoria.TabIndex = 0;
            this.cboCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCategoria_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Marca:";
            // 
            // cboMarca
            // 
            this.cboMarca.Location = new System.Drawing.Point(272, 33);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(121, 24);
            this.cboMarca.TabIndex = 1;
            this.cboMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMarca_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPrecioMax);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cboMarca);
            this.groupBox4.Controls.Add(this.btnBuscar);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtPrecioMin);
            this.groupBox4.Controls.Add(this.cboCategoria);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(408, 368);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(945, 76);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtrar";
            // 
            // txtPrecioMax
            // 
            this.txtPrecioMax.Location = new System.Drawing.Point(679, 32);
            this.txtPrecioMax.Name = "txtPrecioMax";
            this.txtPrecioMax.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioMax.TabIndex = 3;
            this.txtPrecioMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMax_KeyPress);
            this.txtPrecioMax.Leave += new System.EventHandler(this.txtPrecioMax_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(597, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Precio Max.:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Presentacion.Properties.Resources.buscararticulo;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(813, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 34);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPrecioMin
            // 
            this.txtPrecioMin.Location = new System.Drawing.Point(491, 33);
            this.txtPrecioMin.Name = "txtPrecioMin";
            this.txtPrecioMin.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioMin.TabIndex = 2;
            this.txtPrecioMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMin_KeyPress);
            this.txtPrecioMin.Leave += new System.EventHandler(this.txtPrecioMin_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Precio Min.:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = global::Presentacion.Properties.Resources.salir_nuevo;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1374, 397);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 29);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmPpalArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 453);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPpalArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo";
            this.Load += new System.EventHandler(this.frmArticulos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPpalArticulos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCancelar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarVisualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarVisualizarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem agregarVisualizarToolStripMenuItem2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCantidad;
        public System.Windows.Forms.DataGridView dgvArticulos;
        public System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.PictureBox ptbCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtPrecioMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioMax;
        private System.Windows.Forms.Label label6;
    }
}

