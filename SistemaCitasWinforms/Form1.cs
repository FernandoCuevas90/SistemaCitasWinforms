using System.Diagnostics.Eventing.Reader;

namespace SistemaCitasWinforms
{
    public partial class Form1 : Form
    {
        List<Cita> listaCitas = new List<Cita>();
        CitaService citaService;
        int indiceSeleccionado = -1;
        public Form1()
        {
            InitializeComponent();

            Helper helper = new Helper();

            listaCitas = Helper.CargarDesdeJson();
            citaService = new CitaService(listaCitas);
        }

        Cita citaSeleccionada;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar campos con el método ValidarCampos
            if (!ValidarCampos())
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            if (!EsIdValido(txtID.Text))
            {
                txtID.BackColor = Color.LightCoral;
                MessageBox.Show("El ID debe ser un número");
                return;
            }

            if (!EsNombreValido(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede tener más de 20 caracteres");
                return;
            }
            Cita nuevaCita = new Cita();

            int id = int.Parse(txtID.Text);

            //Valida si un ID esta duplicado
            if (citaService.EsIdDuplicado(id))
            {
                MessageBox.Show("El id ya existe");
                return;
            }

            nuevaCita.Id = id;
            nuevaCita.Nombre = txtNombre.Text;
            nuevaCita.TipoEstudio = cmbTipoEstudio.Text;
            nuevaCita.Fecha = dateTimePicker1.Value;
            nuevaCita.TipoUltrasonido = cmbTipoEstudioUl.Text;
            //cmbTipoEstudioUl.SelectedIndex != 0
            //evita la opción "Selecciona tipo de Ultrasonido
            //Solo guarda valores reales
            if (cmbTipoEstudio.Text == "Ultrasonido" && cmbTipoEstudioUl.SelectedIndex != 0)
            {
                nuevaCita.TipoUltrasonido = cmbTipoEstudioUl.Text;
            }
            else
            {
                nuevaCita.TipoUltrasonido = "";
            }

            listaCitas.Add(nuevaCita);
            RefrescarGrid();
            ActualizarEstadoBotones();
            Helper.GuardarEnJson(listaCitas);


            //Esto le dice al DataGridView:
            //1.Olvida lo que tenías
            //2.Vuelve a cargar con la nueva lista
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = listaCitas;

            MessageBox.Show("Cita guardada correctamente");

            //Limpia los campos de ID, nombre y tipo estudio y después guarda la cita
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow != null) //CurrentRow = fila seleccionada
            {
                int indice = dgvCitas.CurrentRow.Index; //index = posición en la lista

                DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar esta cita?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    listaCitas.RemoveAt(indice);
                    RefrescarGrid(); //Se llama el método 
                    ActualizarEstadoBotones();
                    Helper.GuardarEnJson(listaCitas);
                    indiceSeleccionado = -1;

                    LimpiarCampos();
                }
            }
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceSeleccionado = e.RowIndex;
                txtID.Text = listaCitas[indiceSeleccionado].Id.ToString();
                txtNombre.Text = listaCitas[indiceSeleccionado].Nombre;
                cmbTipoEstudio.SelectedItem = listaCitas[indiceSeleccionado].TipoEstudio;
                dateTimePicker1.Value = listaCitas[indiceSeleccionado].Fecha;

                //Indica que estas editando 
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;

                txtID.ReadOnly = true;

                indiceSeleccionado = e.RowIndex;

                CargarCitasEnFormulario(indiceSeleccionado);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado >= 0)
            {
                if (!ValidarCampos())
                {
                    MessageBox.Show("El nombre es obligatorio");
                    return;
                }
                if (!EsIdValido(txtID.Text))
                {
                    txtID.BackColor = Color.LightCoral;
                    MessageBox.Show("El ID debe ser un número");
                    return;
                }

                int id = int.Parse(txtID.Text);


                if (citaService.EsIdDuplicado(id, indiceSeleccionado))
                {
                    MessageBox.Show("El id ya existe");
                    return;
                }


                //Validar si hubo cambios
                Cita citaActual = listaCitas[indiceSeleccionado];

                if (citaActual.Id == id &&
                    citaActual.Nombre == txtNombre.Text &&
                    citaActual.TipoEstudio == cmbTipoEstudio.Text &&
                    citaActual.Fecha == dateTimePicker1.Value &&
                    citaActual.TipoUltrasonido == cmbTipoEstudioUl.Text)
                {
                    MessageBox.Show("No se realizaron cambios");
                    return;
                }

                //Editar
                //listaCitas[indiceSeleccionado].Id = id; el id no se modifica
                listaCitas[indiceSeleccionado].Nombre = txtNombre.Text;
                listaCitas[indiceSeleccionado].TipoEstudio = cmbTipoEstudio.Text;
                listaCitas[indiceSeleccionado].Fecha = dateTimePicker1.Value;

                if(cmbTipoEstudio.Text == "Ultrasonido")
                {
                    listaCitas[indiceSeleccionado].TipoUltrasonido = cmbTipoEstudioUl.Text;
                }
                else
                {
                    listaCitas[indiceSeleccionado].TipoUltrasonido = "";
                }

                RefrescarGrid();
                ActualizarEstadoBotones();
                Helper.GuardarEnJson(listaCitas);

                MessageBox.Show("Cita actualizada");

                LimpiarCampos();
                indiceSeleccionado = -1;

                btnGuardar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Primero debes buscar o seleccionar una cita");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtID.Focus();

            txtNombre.MaxLength = 20;

            cmbTipoEstudio.Items.Add("Rayos X");
            cmbTipoEstudio.Items.Add("Sangre");
            cmbTipoEstudio.Items.Add("Ultrasonido");

            cmbTipoEstudioUl.Items.Add("Selecciona el tipo de ultrasonido");
            cmbTipoEstudioUl.Items.Add("Próstata");
            cmbTipoEstudioUl.Items.Add("Pélvico");
            cmbTipoEstudioUl.Items.Add("Renal");
            cmbTipoEstudioUl.Items.Add("Hígado y Vías Biliares");
            cmbTipoEstudioUl.Items.Add("Obstétrico");

            //Una vez seleccionado el tipo de estudio (Ultrasonido) se habilita el 
            //combobox de Tipo de Estudio (ultrasonido)
            cmbTipoEstudio.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            cmbTipoEstudioUl.SelectedIndex = 0;
            cmbTipoEstudioUl.Enabled = false;

            cmbTipoEstudioUl.DropDownStyle = ComboBoxStyle.DropDownList;

            //Evita que el usuario escriba, solo puede seleccionar
            cmbTipoEstudio.DropDownStyle = ComboBoxStyle.DropDownList;

            listaCitas = Helper.CargarDesdeJson();
            RefrescarGrid();
            ActualizarEstadoBotones();

            if (listaCitas.Count == 0)
            {
                MessageBox.Show("No hay citas registradas");
            }

            //Solo permite seleccionar desde hoy en adelante 
            dateTimePicker1.MinDate = DateTime.Today;

            //Limitar la selección futura de un año
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(1);

        }

        private bool ValidarCampos()
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                txtID.BackColor = Color.LightCoral;
                valido = false;
            }
            else
            {
                txtID.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.BackColor = Color.LightCoral;
                valido = false;
            }
            else
            {
                txtNombre.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(cmbTipoEstudio.Text))
            {
                cmbTipoEstudio.BackColor = Color.LightCoral;
                valido = false;
            }
            else
            {
                cmbTipoEstudio.BackColor = Color.White;
            }

            return valido;
        }

        private void LimpiarCampos()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            cmbTipoEstudio.SelectedIndex = -1;
            txtIdBusqueda.Text = "";

            txtID.BackColor = Color.White;
            txtNombre.BackColor = Color.White;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;

            txtID.ReadOnly = false;
        }

        private void RefrescarGrid()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = listaCitas;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idBuscado;

            if (!int.TryParse(txtIdBusqueda.Text, out idBuscado))
            {
                MessageBox.Show("Ingresa un ID válido");
                return;
            }

            int indice = citaService.BuscarIndicePorId(idBuscado);

            if (indice == -1)
            {
                MessageBox.Show("No se encontró una cita con ese ID");
                return;
            }
            else
            {
                indiceSeleccionado = indice;
                dgvCitas.ClearSelection();
                dgvCitas.Rows[indice].Selected = true;
                CargarCitasEnFormulario(indice);
            }
        }

        //Se despliega las opciones del comboBox del Tipo De Ultrasonido
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoEstudio.Text == "Ultrasonido")
            {
                cmbTipoEstudioUl.Enabled = true;
            }
            else
            {
                cmbTipoEstudioUl.Enabled = false;
                cmbTipoEstudioUl.SelectedIndex = 0;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica si la tecla presionada no es un número ni una tecla de control (como borrar)
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; //ignora la tecla
            }
        }

        private bool EsIdValido(string textoId)
        {
            return int.TryParse(textoId, out int id);
        }

        private bool EsNombreValido(string nombre)
        {
            return nombre.Length <= 20;
        }

        private void ActualizarEstadoBotones()
        {
            if (listaCitas.Count == 0)
            {
                btnEliminar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
            }
        }

        private void CargarCitasEnFormulario(int indice)
        {
            txtID.Text = listaCitas[indice].Id.ToString();
            txtNombre.Text = listaCitas[indice].Nombre;
            cmbTipoEstudio.SelectedItem = listaCitas[indice].TipoEstudio;

            //Cuando selecciono una cita, tambien carga el tipo de ultrasonido que es
            if (listaCitas[indice].TipoEstudio == "Ultrasonido")

            {   //habilitar combo
                cmbTipoEstudioUl.Enabled = true;
                //Evita asignar el tipo de estudio si está vacío
                if (!string.IsNullOrEmpty(listaCitas[indice].TipoUltrasonido))
                {
                    //asignar valor guardado
                    cmbTipoEstudioUl.SelectedItem = listaCitas[indice].TipoUltrasonido;
                }
            }
            else
            {   //deshabilitar combo
                cmbTipoEstudioUl.Enabled= false;
                //limpiar
                cmbTipoEstudioUl.SelectedIndex = 0;
            }

            dateTimePicker1.Value = listaCitas[indice].Fecha;

            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;

            txtID.ReadOnly = true;
        }


        private void cmbTipoEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
