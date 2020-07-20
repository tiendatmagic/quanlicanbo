using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace quanlysinhvien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnKetnoi_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                using (SqlConnection connection =

                    new SqlConnection(@"Server=./;Database=quanlicanbo; Integrated Security=SSPI"))

                {

                    connection.Open();

                }

                MessageBox.Show("Mo va dong co so du lieu thanh cong.");

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);

            }
        }

        private void btnDulieu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<SinhVien> DanhSachSinhVien = new List<SinhVien>();
                using (SqlConnection connection =
                    new SqlConnection(@"Server=./;Database=quanlicanbo; Integrated Security=SSPI"))
                using (SqlCommand command =
                    new SqlCommand("select phongbanID, tenphongban from phongban", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sv = new SinhVien();
                            sv.phongbanID = reader.GetString(0);
                            sv.tenphongban = reader.GetString(1);
                            DanhSachSinhVien.Add(sv);
                        }
                    }
                }
                MessageBox.Show("Mo va dong co so du lieu thanh cong.");
                dulieu.ItemsSource = DanhSachSinhVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo  ket noi: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.phongbanID = txtMaSV.Text;
            sv.tenphongban = txtTenSV.Text;

            if (Them_sinh_vien(sv) > 0)
                MessageBox.Show("Du lieu duoc them thanh cong!");
        }
        //© 2020 Copyright by Tiendatmagic - All Rights Reserved | Designed by Tiendatmagic
        private int Them_sinh_vien(SinhVien sinhvien)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(@"Server=./;Database=quanlicanbo;
        Integrated Security=SSPI"))
                using (SqlCommand command = new SqlCommand("INSERT INTO phongban(phongbanID,tenphongban )" + "VALUES(@phongbanID,@tenphongban );", connection))
                {
                    command.Parameters.Add("phongbanID", SqlDbType.Char, 10).Value =
                        sinhvien.phongbanID;
                    object dbtenphongban = sinhvien.tenphongban;
                    if (dbtenphongban == null)
                    {
                        dbtenphongban = DBNull.Value;
                    }
                    
                    command.Parameters.Add("tenphongban", SqlDbType.NVarChar, 30).Value = dbtenphongban;
                    
                    /*
                     * dbEmail = sinhvien.Email;
                    if (dbEmail == null)
                    {
                        dbEmail = DBNull.Value;
                    }
                    command.Parameters.Add("Email", SqlDbType.NVarChar, 50).Value =
                        dbEmail;
                    command.Parameters.Add("MaKH", SqlDbType.NChar, 10).Value =
                        sinhvien.MaKH;

                    */
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);
                return -1;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.phongbanID = txtMaSV.Text;
            if (Xoa_sinh_vien(sv) > 0)
                MessageBox.Show("Du lieu duoc xoa thanh cong!");
        }


        private int Xoa_sinh_vien(SinhVien sinhvien)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(@"Server=./;Database=quanlicanbo;Integrated Security=SSPI"))
                using (SqlCommand command = new SqlCommand("DELETE FROM phongban " + "WHERE phongbanID = @phongbanID", connection))
                {
                    command.Parameters.Add("phongbanID", SqlDbType.NChar, 10).Value = sinhvien.phongbanID;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);
                return -1;
            }







        }

        private void btnCapnhat_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.phongbanID = txtMaSV.Text;
            sv.tenphongban = txtTenSV.Text;

            if (Cap_nhat_sinh_vien(sv) > 0)
                MessageBox.Show("Du lieu duoc cap nhat thanh cong!");

        }




        private int Cap_nhat_sinh_vien(SinhVien sinhvien)
        {
            try
            {
                using (SqlConnection connection =
                new SqlConnection(@"Server=./;Database=quanlicanbo; Integrated Security=SSPI"))
                using (SqlCommand command = new SqlCommand("UPDATE phongban " + "SET tenphongban = @tenphongban " + "WHERE phongbanID = @phongbanID", connection))
                {
                    command.Parameters.Add("phongbanID", SqlDbType.Char, 10).Value = sinhvien.phongbanID; command.Parameters.Add("tenphongban", SqlDbType.NVarChar, 30).Value = sinhvien.tenphongban;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);
                return -1;
            }
        }

    }
}

//© 2020 Copyright by Tiendatmagic - All Rights Reserved | Designed by Tiendatmagic


