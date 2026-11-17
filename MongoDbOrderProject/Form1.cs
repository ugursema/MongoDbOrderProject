using MongoDbOrderProject.Entities;
using MongoDbOrderProject.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MongoDbOrderProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OrderOperation orderOperation = new OrderOperation();
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                CustomerName = txtCustomer.Text,
                District = txtDisctrict.Text,
                City = txtCity.Text,
                TotalPrice = decimal.Parse(txtTotalPrice.Text),
                //otomatik gelecek ? 
                //OrderId = txtID.Text
            };
            orderOperation.AddOrder(order);
            MessageBox.Show("Ekleme İşlemi Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Listele()
        { 
            List<Order> orders = orderOperation.GetAllOrders();
            dataGridView1.DataSource = orders;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string orderId = txtID.Text;
            orderOperation.DeleteOrder(orderId);
            MessageBox.Show("Silme İşlemi başarı ile gerçekleşti","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id =txtID.Text;
            var updateOrder = new Order
            {
                City = txtCity.Text,
                CustomerName = txtCustomer.Text,
                District = txtDisctrict.Text,
                OrderId = id,
                TotalPrice = decimal.Parse(txtTotalPrice.Text)
            };
            orderOperation.UpdateOrder(updateOrder);
            MessageBox.Show("Güncelleme İşlemi başarı ile gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBring_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            Order orders = orderOperation.GetOrderById(id);
            dataGridView1.DataSource = new List<Order> { orders };
        }
    }
}
