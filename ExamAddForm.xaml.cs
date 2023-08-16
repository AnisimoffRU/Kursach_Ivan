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
    /// Логика взаимодействия для ExamAddForm.xaml
    /// </summary>
    public partial class ExamAddForm : Window
    {
        ApplicationContext db;
        DataGrid dataGrid;
        public ExamAddForm(ApplicationContext db , DataGrid dataGrid)
        {
            InitializeComponent();
            this.db = db;
            this.dataGrid = dataGrid;

            examinatorComboBox.ItemsSource = db.Examinators.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Exam exam = new Exam();
            var currentExaminator = examinatorComboBox.SelectedItem as Examinator;

            exam.Grade = Convert.ToInt32(gradeTextBox.Text);
            exam.Examinator = currentExaminator;

            db.Exams.Add(exam);
            db.SaveChanges();

            dataGrid.ItemsSource = db.Exams.Local.ToBindingList();

            this.Close();
        }

        private void ButtonCancel_Click (object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
