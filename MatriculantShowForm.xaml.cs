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
using System.Windows.Shapes;

namespace Kursach_Ivan
{
    /// <summary>
    /// Логика взаимодействия для MatriculantShowForm.xaml
    /// </summary>
    public partial class MatriculantShowForm : Window
    {
        ApplicationContext db;
        DataGrid dataGrid;
        Matriculant matriculant;
        Image profileImage;
        public MatriculantShowForm(ApplicationContext _db, DataGrid _dataGrid)
        {
            InitializeComponent();
            db = _db;
            dataGrid = _dataGrid;
            matriculant = dataGrid.SelectedItem as Matriculant;

            MatriculantId.Content = matriculant.Id.ToString();
            MatriculantName.Content = matriculant.FullName.ToString();
            MatriculantSchoolNumber.Content = matriculant.SchoolNumber.ToString();
            MatriculantExamId.Content = matriculant.ExamId.ToString();
            MatriculantExamGrade.Content = matriculant.Exam.Grade.ToString();


            if (matriculant.ImageUri != null)
            {
                profileImage = MatriculantImage;

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(matriculant.ImageUri.ToString());
                bi.EndInit();


                profileImage.Source = bi;
            }
           
        }
    }
}
