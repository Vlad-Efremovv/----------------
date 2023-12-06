using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ghjdjlybr.Fun
{
    internal class CopyFile
    {
        public CopyFile(ref Pach pach)
        {
            try
            {
                File.Copy(pach.PachFillName, pach.PachFillName + "-копия-" + pach.CopyIndex); // копирование файла
                MessageBox.Show("Копия файла успешно создана!"); //сообщение 
            }
            catch
            {
                MessageBox.Show("Копия файла не создана! \nВозможно файл с таким именем уже существует!");//сообщение 
            }

            pach.CopyIndex++; //прибавление индекса 
        }
    }
}
