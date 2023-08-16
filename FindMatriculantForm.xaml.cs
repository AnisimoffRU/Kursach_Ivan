using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для FindMatriculantForm.xaml
    /// </summary>
    public partial class FindMatriculantForm : Window
    {
        ApplicationContext db;
        DataGrid dataGrid;
       
        public FindMatriculantForm(ApplicationContext _db)
        {
            InitializeComponent();
            db = _db;
            
            var students = db.Matriculants.ToList();
            var grades = db.Exams.ToList();

            /*var names = from s in students
                        join g in grades on s.ExamId equals g.Id
                        select new { Name = s.FullName, Grade = g.Grade };*/

           var names = db.Matriculants.FromSqlRaw("SELECT * FROM Matriculants")
                                                    .Include(c => c.Exam).ToList();

            string paramString = "%" + textBox.Text + "%";
            SqliteParameter param = new SqliteParameter("@name" , paramString);

            names = db.Matriculants.FromSqlRaw("SELECT * FROM Matriculants WHERE FullName LIKE @name", param).ToList();
            
            
            

            mainDg.ItemsSource = names;

        }

        private void buttonFind_Click(object sender , RoutedEventArgs e)
        {
            string paramString = "%" + textBox.Text + "%";
            SqliteParameter param = new SqliteParameter("@name" , paramString);

           var names = db.Matriculants.FromSqlRaw("SELECT * FROM Matriculants WHERE (FullName LIKE @name) " , param).ToList();

           mainDg.ItemsSource = names;

        }
    }

    public class Student{
        public string Name { get; set; }
        public int Grade { get; set; }
    }
}
