using Newtonsoft.Json;

namespace FileExampleApp
{
    public partial class MainPage : ContentPage
    {
        /* private string _name;

         public string Name
         {
             get { return _name; }
             set { _name = value;

                 OnPropertyChanged();
             }
         }

         private string _studentNumber;

         public string StudentNumber
         {
             get { return _studentNumber; }
             set { _studentNumber = value; 

                 OnPropertyChanged();
             }
         }
        */

        private Student _student;

        public Student CurrentStudent
        {
            get { return _student; }
            set { _student = value;

                OnPropertyChanged();
            }
        }




        public MainPage()
        {
            InitializeComponent();

            CurrentStudent = LoadData();

            BindingContext = this;

        }


        public void SaveData(Student student)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fullFileName = Path.Combine(filePath, "myfile.txt");
            string studentJson = JsonConvert.SerializeObject(student);
            File.WriteAllText(fullFileName, studentJson);
        }

        public Student LoadData()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fullFileName = Path.Combine(filePath, "myfile.txt");

            if (File.Exists(fullFileName))
            {

                string fileContent = File.ReadAllText(fullFileName);

                Student savedStudent = JsonConvert.DeserializeObject<Student>(fileContent);

                return savedStudent;
            }
            else
                return new Student();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SaveData(CurrentStudent);

        }
    }

}
