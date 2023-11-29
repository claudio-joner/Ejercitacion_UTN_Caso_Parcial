using Modelo_de_Parcial.Datos;
using Modelo_de_Parcial.Datos.Implementacion;
using Modelo_de_Parcial.Entidades;
using Modelo_de_Parcial.Servicios;
using Modelo_de_Parcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo_de_Parcial
{
    public partial class frmPrincipal : Form
    {
        //OrdenesDao helper;
        IServicio servicio = null;
        OrdenRetiro ordenRet = null;
        int id = 1;
        public frmPrincipal(FactoryServicio fabrica)
        {
            InitializeComponent();
            //helper = new OrdenesDao();
            ordenRet = new OrdenRetiro();
            servicio = fabrica.CrearSerivicio();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //cboMateriales.DataSource = helper.TraerMateriales(); //Usa el toString de cada elemento de la lista
            cboMateriales.DataSource = servicio.TraerMateriales();
            cboMateriales.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpFecha.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea cancelar la orden?", "Cancelar?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Material item = (Material)cboMateriales.SelectedItem;
                int cantidad = Convert.ToInt32(nudNumero.Value);
                DetalleDeOrden detalle = new DetalleDeOrden(id, item, cantidad);
                ordenRet.AgregarDetalle(detalle);
                dgvDetalles.Rows.Add(new object[] { detalle.idDetalle, detalle.Material.Nombre,
                                                    detalle.Material.Stock,detalle.Cantidad});
                id++;
                Limpiar();

            }
            return;
        }

        private void Limpiar()
        {
            nudNumero.Value = 0;
        }

        private bool Validar()
        {
            bool resultado = true;
            Material oMaterial = (Material)cboMateriales.SelectedItem;
            int stock = oMaterial.Stock;

            if(nudNumero.Value > stock)
            {
                MessageBox.Show("Debe seleccionar un stock menor  o igual a: " + stock,"Atencion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                resultado = false;
            }

            if (nudNumero.Value == 0)
            {
                MessageBox.Show("Debe seleccionar un stock mayor a 0. " , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = false;
            }

            foreach (DataGridViewRow d in dgvDetalles.Rows)
            {
                Material material = (Material)cboMateriales.SelectedItem;

                if (d.Cells["ColMaterial"].Value.ToString() == material.Nombre)
                {
                    MessageBox.Show("Este material ya esta seleccionado.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultado = false;
                }
            }

            
            return resultado;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell != null && dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                if (dgvDetalles.CurrentRow != null)
                {
                    int rowIndex = dgvDetalles.CurrentRow.Index;

                    if (rowIndex >= 0 && rowIndex < dgvDetalles.Rows.Count)
                    {
                        dgvDetalles.Rows.RemoveAt(rowIndex);
                        ordenRet.QuitarDetalle(rowIndex);
                        id--;
                        Limpiar();
                    }
                }
            }
            /*
             if (dgvDetalles.CurrentCell.ColumnIndex ==4)
            {
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                ordenRetiro.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                auxDetalle--;
            }
             */
        }

        private void btnaAceptar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar un detalle.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtResponsable.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un responsable.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dtpFecha.Value > DateTime.Now)
            {
                MessageBox.Show("Debe ingresar una fecha valida.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ordenRet.Responsable = txtResponsable.Text;
            ordenRet.Fecha = dtpFecha.Value;

            //if (helper.ConfirmarOrden(ordenRet))
            //{
            //    MessageBox.Show("Orden confirmada exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Dispose();
            //}
            //else
            //{
            //    MessageBox.Show("no pudo confirmarse la orden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
