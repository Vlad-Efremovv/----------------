using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MenuItem = System.Web.UI.WebControls.MenuItem;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using ghjdjlybr.Fun;

namespace ghjdjlybr
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        Pach pach = new Pach(); //путь к файлу
        public Menu()
        {
            InitializeComponent();


            foreach (var drive in DriveInfo.GetDrives()) //получение и передача в trv именa дисков 
            {
                var dir = drive.RootDirectory; // имя директирии
                trvStructure.Items.Add(GetDirNode(dir));
            }
        }

        /// <summary>
        /// Заполнение trv файлами и папками            
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeViewItemExpanded(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (TreeViewItem)e.OriginalSource; //передача в item путей для поиска файлов и папок
                item.Items.Clear();
                var dirs = ((DirectoryInfo)item.Tag).GetDirectories(); // кол папок
                var files = ((DirectoryInfo)item.Tag).GetFiles();   //кол файлов       

                // циклы заполняют item папками и файлами для дальнейшего паредставления пользователю
                foreach (var dir in dirs)
                {
                    item.Items.Add(GetDirNode(dir));
                }
                foreach (var file in files)
                {
                    item.Items.Add(GetFileNode(file));
                }
            }
            catch { }
        }

        private TreeViewItem GetNode(FileSystemInfo info)
        {
            var result = new TreeViewItem();
            result.Header = info.ToString(); // имя
            result.Tag = info;  //тег 
            return result;
        }

        private TreeViewItem GetFileNode(FileInfo fileInfo)
        {
            return GetNode(fileInfo);
        }

        private TreeViewItem GetDirNode(DirectoryInfo directoryInfo)
        {
            var result = GetNode(directoryInfo);
            result.Items.Add("*");
            return result;
        }

        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            textBox.Text = ((e.NewValue as TreeViewItem).Tag as FileSystemInfo).FullName; // вывод пути выделенного обьекта для пользователя
            
            pach.PachFullName = textBox.Text; // сохранения пути 
        }

        /// <summary>
        /// Cоздание нового файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add(ref pach); // открыть окно создания
            add.Show();
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_Click(object sender, RoutedEventArgs e)
        {
            DeleteFile delete = new DeleteFile(ref pach);
        }

        /// <summary>
        /// Pедактирование имяни файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit(ref pach); //открытие окна редактирования
            edit.Show();
        }

        /// <summary>
        /// Создание копии файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copy_Click(object sender, RoutedEventArgs e)
        {
            CopyFile copy = new CopyFile(ref pach);
        }

    }
}

