using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ghjdjlybr
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Pach pachFillName = new Pach();

        public Add(ref Pach pach)
        {
            InitializeComponent();
            pachFillName.PachFillName = pach.PachFillName; // получение ссылки на путь куда хотим добавить папку
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            
            pachFillName.PachFillName += '\\' + nameFile.Text; // полный путь к файлу + имя

            try
            {
                File.WriteAllText(pachFillName.PachFillName, textFale.Text); // создание файла и вписывание в него инфы
                MessageBox.Show("Файл успешно создан!\n" + "Путь: " + pachFillName.PachFillName);         // вывод полного пути к файлу и показывает что все прошло удачно 
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не создан"); // информирует об ошибке
            }

            Close(); // закрытие окна

        }

        private void txt_Click(object sender, RoutedEventArgs e)
        {
            nameFile.Text += ".txt";    //добавление пеписки
        }

        private void exe_Click(object sender, RoutedEventArgs e)
        {
            nameFile.Text += ".exe";    //добавление пеписки
        }

        private void bat_Click(object sender, RoutedEventArgs e)
        {
            nameFile.Text += ".bat";    //добавление пеписки
        }
                        
    }
}
