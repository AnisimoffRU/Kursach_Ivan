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
    /// Логика взаимодействия для ExaminatorAddForm.xaml
    /// </summary>
    public partial class ExaminatorAddForm : Window
    {
        ApplicationContext db;
        DataGrid dataGrid;
        public ExaminatorAddForm(ApplicationContext db , DataGrid dataGrid)
        {
            InitializeComponent();
            this.db = db;
            this.dataGrid = dataGrid;
            
        }

        private void ButtonAdd_Click(object sender , RoutedEventArgs e)
        {
            Examinator examinator = new Examinator();

            examinator.FullName = nameTextBox.Text;
            examinator.Position = positionTextBox.Text;

            db.Examinators.Add(examinator);
            db.SaveChanges();

            dataGrid.ItemsSource = db.Examinators.Local.ToBindingList();

            this.Close();
        }

        private void ButtonCancel_Click(object sender , RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
