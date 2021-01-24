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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Text
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		string Name = "a.txt";

		private void cmCreate(object sender, RoutedEventArgs e)
		{
			StreamWriter fw = new StreamWriter(Name);

			fw.WriteLine("Мама мыла раму.");
			fw.WriteLine("Все хорошо");

			fw.Close();
		}

		private void cmOpen(object sender, RoutedEventArgs e)
		{
			//if(!File.Exists("b.txt"))
			//{
			//	MessageBox.Show("Файла не существует!");

			//	return;
			//}

			try
			{
				StreamReader fr = new StreamReader("b.txt");

				while (!fr.EndOfStream)
				{
					string s = fr.ReadLine();

					MessageBox.Show(s);
				}

				fr.Close();
			}
			catch
			{
				MessageBox.Show("Ошибка при работе с файлам!");
			}

		}

		private void cmFile(object sender, RoutedEventArgs e)
		{
			string s = tbNumber.Text;
			double x;

			if (!double.TryParse(s, out x))
			{
				return;
			}

			StreamWriter fw = new StreamWriter("n.txt");

			string s_out = "Значение {0:F" + tbPr.Text + "}";

			fw.WriteLine(s_out, x);

			fw.Close();

			StreamReader fr = new StreamReader("n.txt");

			s = fr.ReadLine();

			fr.Close();

			MessageBox.Show(s);
		}

		private void cmBin(object sender, RoutedEventArgs e)
		{
			double a = 3.14;

			Stream F = File.Open("a.bin", FileMode.Create);

			BinaryWriter f = new BinaryWriter(F);

			f.Write(a);

			f.Close();

			F = File.Open("a.bin", FileMode.Open);

			BinaryReader fr = new BinaryReader(F);

			int x = fr.ReadInt32();

			fr.Close();

			MessageBox.Show(x.ToString());
		}

		private void cmCopy(object sender, RoutedEventArgs e)
		{
			string Name1, Name2;


			Microsoft.Win32.OpenFileDialog dialog1 = new Microsoft.Win32.OpenFileDialog();
			dialog1.Filter = "Text files (*.txt)|*.txt|All files|*.*";

			if (dialog1.ShowDialog() == true)
			{
				Name1 = dialog1.FileName;
			}
			else
			{
				return;
			}

			Microsoft.Win32.SaveFileDialog dialog2 = new Microsoft.Win32.SaveFileDialog();
			dialog2.Filter = "Text files (*.txt)|*.txt|All files|*.*";
			dialog2.FileName = "text";
			dialog2.DefaultExt = ".txt";

			if (dialog2.ShowDialog() == true)
			{
				Name2 = dialog2.FileName;
			}
			else
			{
				return;
			}

			File.Copy(Name1, Name2, true);
		}

	}
}
