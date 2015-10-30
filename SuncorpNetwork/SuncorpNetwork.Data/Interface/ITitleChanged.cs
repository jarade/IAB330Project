using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuncorpNetwork.Data
{
	public class ITitleChanged : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string title;
		public string Title {
			get { return title; }
			set {
				if (value.Equals (title, StringComparison.Ordinal)) {
					return; // No change
				}

				title = value;
				OnPropertyChanged ();
			}
		}

		void OnPropertyChanged([CallerMemberName] string propertyName = null){
			var handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

