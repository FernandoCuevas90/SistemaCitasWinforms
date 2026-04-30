namespace SistemaCitasWinforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGuardar = new Button();
            txtNombre = new TextBox();
            dgvCitas = new DataGridView();
            btnEliminar = new Button();
            btnEditar = new Button();
            txtID = new TextBox();
            cmbTipoEstudio = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            btnBuscar = new Button();
            txtIdBusqueda = new TextBox();
            cmbTipoEstudioUl = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(34, 197);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(34, 59);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 1;
            // 
            // dgvCitas
            // 
            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.Location = new Point(34, 242);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.Size = new Size(959, 281);
            dgvCitas.TabIndex = 6;
            dgvCitas.CellClick += dgvCitas_CellClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(340, 197);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(610, 197);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(34, 12);
            txtID.Name = "txtID";
            txtID.PlaceholderText = "Número ID";
            txtID.Size = new Size(125, 27);
            txtID.TabIndex = 0;
            txtID.TextChanged += txtID_TextChanged;
            txtID.KeyPress += txtID_KeyPress;
            // 
            // cmbTipoEstudio
            // 
            cmbTipoEstudio.FormattingEnabled = true;
            cmbTipoEstudio.Location = new Point(34, 106);
            cmbTipoEstudio.Name = "cmbTipoEstudio";
            cmbTipoEstudio.Size = new Size(151, 28);
            cmbTipoEstudio.TabIndex = 2;
            cmbTipoEstudio.Text = "Tipo de Estudio";
            cmbTipoEstudio.SelectedIndexChanged += cmbTipoEstudio_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "\"dd/MM/yyyy HH:mm\"";
            dateTimePicker1.Location = new Point(34, 152);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(899, 197);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtIdBusqueda
            // 
            txtIdBusqueda.Location = new Point(199, 12);
            txtIdBusqueda.Name = "txtIdBusqueda";
            txtIdBusqueda.PlaceholderText = "ID Búsqueda";
            txtIdBusqueda.Size = new Size(125, 27);
            txtIdBusqueda.TabIndex = 9;
            // 
            // cmbTipoEstudioUl
            // 
            cmbTipoEstudioUl.FormattingEnabled = true;
            cmbTipoEstudioUl.Location = new Point(539, 106);
            cmbTipoEstudioUl.Name = "cmbTipoEstudioUl";
            cmbTipoEstudioUl.Size = new Size(273, 28);
            cmbTipoEstudioUl.TabIndex = 10;
            cmbTipoEstudioUl.Text = "Tipo de Ultrasonido";
            cmbTipoEstudioUl.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 535);
            Controls.Add(cmbTipoEstudioUl);
            Controls.Add(txtIdBusqueda);
            Controls.Add(btnBuscar);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbTipoEstudio);
            Controls.Add(txtID);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvCitas);
            Controls.Add(txtNombre);
            Controls.Add(btnGuardar);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda de Citas";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblResultado;
        private Button btnGuardar;
        private TextBox txtNombre;
        private DataGridView dgvCitas;
        private Button btnEliminar;
        private Button btnEditar;
        private TextBox txtID;
        private ComboBox cmbTipoEstudio;
        private DateTimePicker dateTimePicker1;
        private Button btnBuscar;
        private TextBox txtIdBusqueda;
        private ComboBox cmbTipoEstudioUl;
    }
}
