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
            for (int i = pach.PachFillName.Length - 1; i >= 0; i--)
            {
                if (pach.PachFillName[i] == '.')
                {
                    MessageBox.Show("нашел точку");

                    char[] copyFileName = new char[i + 15];

                    string copyIndex = pach.CopyIndex + "-копия-";

                    for (int j = copyFileName.Length; j < i; j++)
                    {
                        if (i <=j )
                        {
                            copyFileName[j] = pach.PachFillName[i];
                        }
                        else
                        {
                            //copyIndex[]
                        }
                    }

                }
            }

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
