using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace SuncorpNetwork
{
	public class TapViewModel : INotifyPropertyChanged{
		ICommand tapCommand;

		public TapViewModel (){
			tapCommand = new Command (OnTapped);
		}

		public ICommand TapCommand{
			get{return tapCommand;}
		}

		void OnTapped (object s){
			Debug.WriteLine ("Parameter:  " + s.ToString ());
		}
	}
}

