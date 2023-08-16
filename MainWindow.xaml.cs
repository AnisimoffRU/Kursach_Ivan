using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Kursach_Ivan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        User currentUser;

        public MainWindow(AutorizationWindow autorizationWindow, User _currentUser)
        {
            InitializeComponent();
            autorizationWindow.Close();
            currentUser = _currentUser;
            db = new ApplicationContext();

            db.Exams.Load();
            db.Matriculants.Load();
            db.Users.Load();
            db.Examinators.Load();

            dgMatriculant.ItemsSource = db.Matriculants.Local.ToBindingList();
            dgExam.ItemsSource = db.Exams.Local.ToBindingList();
            dgExaminator.ItemsSource = db.Examinators.Local.ToBindingList();

            /*Examinator examinator1 = new Examinator { FullName = "Степан Иванович" , Position = "Преподаватель" };
            Examinator examinator2 = new Examinator { FullName = "Иван Евгеньевич" , Position = "Декан" };

            Exam exam1 = new Exam { Grade = 5 , Examinator = examinator1 };
            Exam exam2 = new Exam { Grade = 3 , Examinator = examinator2 };



            Matriculant matriculant1 = new Matriculant { FullName = "Петр Лимонадов" , SchoolNumber = 447 , Exam = exam1 };
            Matriculant matriculant2 = new Matriculant { FullName = "Наташа Озонова" , SchoolNumber = 163 , Exam = exam2 };
            Matriculant matriculant3 = new Matriculant { FullName = "Сергей Петров" , SchoolNumber = 332 , Exam = exam2, ImageUri = @"D:\Polytech_3\ТРЗБД\Kursach_Ivan\image\abiturient.jpg" };

            db.Examinators.AddRange(examinator1 , examinator2);
            db.Exams.AddRange(exam1 , exam2);
            db.Matriculants.AddRange(matriculant1 , matriculant2 , matriculant3);*/
            db.SaveChanges();


        }

        private void ButtonDelete_Click(object sender , RoutedEventArgs e)
        {
            if (currentUser.Role == "admin")
            {
                if (dgMatriculant.SelectedItems.Count > 0)
                {
                    for (int i = 0;i < dgMatriculant.SelectedItems.Count;i++)
                    {
                        Matriculant matriculant = dgMatriculant.SelectedItems[i] as Matriculant;
                        if (matriculant != null)
                        {
                            db.Matriculants.Remove(matriculant);
                        }
                    }
                }
                else if (dgExam.SelectedItems.Count > 0)
                {
                    for (int i = 0;i < dgExam.SelectedItems.Count;i++)
                    {
                        Exam exam = dgExam.SelectedItems[i] as Exam;
                        if (exam != null)
                        {
                            db.Exams.Remove(exam);
                        }
                    }
                }
                else if (dgExaminator.SelectedItems.Count > 0)
                {
                    for (int i = 0;i < dgExaminator.SelectedItems.Count;i++)
                    {
                        Examinator examinator = dgExaminator.SelectedItems[i] as Examinator;
                        if (examinator != null)
                        {
                            db.Examinators.Remove(examinator);
                        }
                    }
                }
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("У вас нет прав на удаление");
            }
            
        }

        private void ExaminatorAdd_Click(object sender , RoutedEventArgs e)
        {
            ExaminatorAddForm examinatorAddForm = new ExaminatorAddForm(db, dgExaminator);
            examinatorAddForm.ShowDialog();
        }

        private void MatriculantAdd_Click(object sender , RoutedEventArgs e)
        {
            MatriculantAddForm matriculantAddForm = new MatriculantAddForm(db , dgMatriculant);
            matriculantAddForm.ShowDialog();
        }

        private void ExamAdd_Click(object sender , RoutedEventArgs e)
        {
            ExamAddForm examAddForm = new ExamAddForm(db , dgExam);
            examAddForm.ShowDialog();
        }

        private void Row_DoubleClick(object sender , MouseButtonEventArgs e)
        {
            MatriculantShowForm matriculantShowForm = new MatriculantShowForm(db, dgMatriculant);
            matriculantShowForm.ShowDialog();
        }

        private void FindFormClick(object sender , RoutedEventArgs e)
        {
            FindMatriculantForm findMatriculantForm = new FindMatriculantForm(db);
            findMatriculantForm.ShowDialog();
        }
    }
}
