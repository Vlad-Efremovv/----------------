using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ghjdjlybr
{
    internal class DeleteFile
    {
        public DeleteFile(ref Pach pach)
        {
            try
            {
                if (Directory.Exists(System.IO.Path.GetDirectoryName(pach.PachFillName))) //проверка на существование
                {
                    if (!File.Exists(pach.PachFillName)) //проверка
                    {
                        return;
                    }

                    bool isDeleted = false; //флажок
                    while (!isDeleted)
                    {
                        try
                        {
                            File.Delete(pach.PachFillName); //удаление
                            isDeleted = true;

                            MessageBox.Show("Файл успешно удален!"); //сообщение 
                        }
                        catch { }

                        try
                        {
                            Directory.Delete(pach.PachFillName); //удаление
                            isDeleted = true;

                            MessageBox.Show("Файл успешно удален!"); //сообщение 
                        }
                        catch { }

                    }

                }
            }
            catch
            {
                MessageBox.Show("Не получилось удалить файл!"); //сообщение 
            }
        }
    }
}
