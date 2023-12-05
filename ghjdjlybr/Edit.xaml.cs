using System;
using System.Collections.Generic;
using System.IO;
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

namespace ghjdjlybr
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit(ref Pach pach)
        {
            InitializeComponent();

            oldNameFile.Text = pach.PachFillName;   //передача полного пути и имяни файла
            newNameFile.Text = pach.PachFillName;   //передача полного пути и имяни файла
        }

        /// <summary>
        /// Выполняет смену имяни файла
        /// и сохраняет изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;

            try
            {
                File.Move(oldNameFile.Text, newNameFile.Text);  //переименование файла 

                MessageBox.Show("Файл удачно переименован!");   //вывод сообщения 
                flag = true;
            }
            catch { }

            try
            {
                Directory.Move(oldNameFile.Text, newNameFile.Text);  //переименование файла 

                MessageBox.Show("Директория удачно переименован!");   //вывод сообщения 
                flag = true;
            }
            catch { }

            if (!flag)
            {
                MessageBox.Show("Не удалось переименовать!");  //вывод сообщения 
            }
            Close();
        }
    }
}
