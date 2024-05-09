using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.ui.Models
{
	internal class Sobre
	{
		public string Title => AppInfo.Name;
		public string Version => AppInfo.VersionString;
		public string MaisInfoURL => "https://aka.ms/maui";
		public string Message => "Aplicativo feito com XAML e C# em .NET MAUI";
	}
}
