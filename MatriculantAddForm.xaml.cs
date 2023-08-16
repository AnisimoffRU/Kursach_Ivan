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
    /// Логика взаимодействия для MatriculantAddForm.xaml
    /// </summary>
    public partial class MatriculantAddForm : Window
    {
        ApplicationContext db;
        DataGrid dataGrid;
        public MatriculantAddForm(ApplicationContext db , DataGrid dataGrid)
        {
            InitializeComponent();
            this.db = db;
            this.dataGrid = dataGrid;

            examComboBox.ItemsSource = db.Exams.ToList();
        }

        private void ButtonAdd_Click(object sender , RoutedEventArgs e)
        {
            Matriculant matriculant = new Matriculant();
            var currentExam = examComboBox.SelectedItem as Exam;

            matriculant.FullName = nameTextBox.Text;
            matriculant.SchoolNumber = Convert.ToInt32(schoolTextBox.Text);
            matriculant.Exam = currentExam;

            db.Matriculants.Add(matriculant);
            db.SaveChanges();

            dataGrid.ItemsSource = db.Matriculants.Local.ToBindingList();

            this.Close();
        }

        private void ButtonCancel_Click(object sender , RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
