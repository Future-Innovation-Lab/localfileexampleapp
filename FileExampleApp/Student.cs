using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExampleApp
{
    public class Student : INotifyPropertyChanged
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
		}

		private string _studentNumber;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string StudentNumber
		{
			get { return _studentNumber; }
			set { _studentNumber = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StudentNumber)));

            }
        }




	}
}
