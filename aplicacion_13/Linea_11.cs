using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace aplicacion_13
{
    public partial class Linea_11 : Form
    {
        private int numeroGuia;
        private string rutaArchivo = "txtNroDeGuia"; // Archivo para almacenar el número de guía
        private Form1 _form1; // Referencia a Form1
        private PrintDocument printDocument = new PrintDocument();

        public Linea_11(Form1 form1)
        {
            InitializeComponent();
            ConfigurarImpresion();
            _form1 = form1; // Archivo para almacenar el número de guía

        }

        private void Form2_Click(object sender, EventArgs e)
        {

        }

        private void Linea_11_Load(object sender, EventArgs e)
        {
            int numeroGuia = LeerNumeroGuiaDesdeArchivo();
            numeroGuia ++;
            MostrarEnCampo(numeroGuia);
            GuardarNumeroGuiaEnArchivo(numeroGuia);
        }

        // Método para leer el número de guía desde un archivo
        private int LeerNumeroGuiaDesdeArchivo()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    return int.Parse(File.ReadAllText(rutaArchivo));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        // Método para guardar el número de guía en un archivo
        private void GuardarNumeroGuiaEnArchivo(int numeroGuia)
        {
            File.WriteAllText(rutaArchivo, numeroGuia.ToString());
        }

        // Método para mostrar el número en el campo correspondiente
        private void MostrarEnCampo(int numeroGuia)
        {
            txtNumeroGuia.Text = numeroGuia.ToString(); // Cambia 'txtNroDeGuia' por el nombre de tu campo

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
              ImprimirGuia(e.Graphics);
  
        }

        private void ConfigurarImpresion()
        {

            printDocument.PrintPage += PrintDocument1_PrintPage;
        }

        private void ImprimirGuia(Graphics g)
        {
            // Fuente
            Font titleFont = new Font("Arial", 12, FontStyle.Bold);
            Font subtitleFont = new Font("Arial", 10, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10);

            // Posición inicial
            int x = 50;
            int y = 20;
            int lineHeight = 20;

            // Dibuja el rectángulo para el encabezado
            int headerWidth = 600;
            int headerHeight = 7 * lineHeight;
            g.DrawRectangle(Pens.Black, x - 10, y - 10, headerWidth, headerHeight);

            // Encabezado
            g.DrawString("ASOCIACIÓN COLECTIVOS", titleFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("SAN FELIPE", subtitleFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("\"ACOSAN LINEA 11\"", subtitleFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("LA TROYA S/N", normalFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("SAN FELIPE", normalFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("RUT: 74.023.900-7", normalFont, Brushes.Black, x, y);
            y += lineHeight;

            // Espaciado entre secciones
            y += 20;

            // Datos principales
            int labelWidth = 150; // Ancho de las etiquetas
            int valueX = x + labelWidth;

            g.DrawString("N° de Guía:", subtitleFont, Brushes.Black, x, y);
            g.DrawString(txtNumeroGuia.Text, normalFont, Brushes.Black, valueX, y);
            y += lineHeight;

            g.DrawString("Conductor:", subtitleFont, Brushes.Black, x, y);
            g.DrawString(txtConductor.Text, normalFont, Brushes.Black, valueX, y);
            y += lineHeight;

            g.DrawString("Patente:", subtitleFont, Brushes.Black, x, y);
            g.DrawString(txtPatente.Text, normalFont, Brushes.Black, valueX, y);
            y += lineHeight;

            g.DrawString("Despacho:", subtitleFont, Brushes.Black, x, y);
            g.DrawString(txtDespacho.Text, normalFont, Brushes.Black, valueX, y);
            y += lineHeight;

            g.DrawString("Fecha:", subtitleFont, Brushes.Black, x, y);
            g.DrawString(txtFecha.Text, normalFont, Brushes.Black, valueX, y);
            y += lineHeight;

            g.DrawString("Rut:", subtitleFont, Brushes.Black, x, y);
            g.DrawString(txtRut.Text, normalFont, Brushes.Black, valueX, y);
            y += lineHeight;

            // Espaciado
            y += 20;

            // Detalle de Operaciones
            g.DrawString("Detalle de Operaciones", titleFont, Brushes.Black, x, y);
            y += lineHeight;

            g.DrawString("Ingreso", subtitleFont, Brushes.Black, x, y);
            g.DrawString("Llegada", subtitleFont, Brushes.Black, x + 100, y);
            g.DrawString("Salida", subtitleFont, Brushes.Black, x + 200, y);
            g.DrawString("Planilla", subtitleFont, Brushes.Black, x + 300, y);
            y += lineHeight;

            // Datos de la tabla
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Omitir la fila vacía al final
                g.DrawString(row.Cells[0].Value?.ToString() ?? "", new Font("Arial", 10), Brushes.Black, x, y);
                g.DrawString(row.Cells[1].Value?.ToString() ?? "", new Font("Arial", 10), Brushes.Black, x + 100, y);
                g.DrawString(row.Cells[2].Value?.ToString() ?? "", new Font("Arial", 10), Brushes.Black, x + 200, y);
                g.DrawString(row.Cells[3].Value?.ToString() ?? "", new Font("Arial", 10), Brushes.Black, x + 300, y);
                y += lineHeight;
            }
            y += lineHeight; // Espacio extra después de la tabla


            // Espaciado
            y += 20;
            // Pie de página
            
            g.DrawString("Todos los derechos reservados.", normalFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("Gracias por utilizar nuestros servicios.", normalFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("© 2024-2025 - Diseño profesional generado automáticamente.", normalFont, Brushes.Black, x, y);
            y += lineHeight;
            g.DrawString("(ARIEL RIVERA CORDOVA).", normalFont, Brushes.Black, x, y);


        }


        private void btndescargar_Click(object sender, EventArgs e)
        {
            // Validación de campos antes de imprimir
            if (string.IsNullOrEmpty(txtRut.Text) || string.IsNullOrEmpty(txtPatente.Text) ||
                string.IsNullOrEmpty(txtConductor.Text) || string.IsNullOrEmpty(txtDespacho.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Mostrar el cuadro de diálogo de impresión
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta Form2

            if (_form1 == null) // Verifica si _form1 es null
            {
                _form1 = new Form1(); // Inicializa si es necesario
            }
            _form1.Show(); // Muestra Form1 de nuevo

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevisualizar_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };
            previewDialog.ShowDialog();
        }
    }
}




