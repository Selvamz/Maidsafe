using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maidsafe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentList : ContentPage
	{
		public StudentList ()
		{
			InitializeComponent ();
            this.BindingContext = new StudentListViewModel(this.Navigation);
		}
	}
}