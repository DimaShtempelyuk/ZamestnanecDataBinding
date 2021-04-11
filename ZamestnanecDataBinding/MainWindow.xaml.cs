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
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace ZamestnanecDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        Zamestnanecc zam;

        public MainWindow()
        {
            InitializeComponent();
            zam = new Zamestnanecc { Name = "Nic", Surname = "Nic", Dob = DateTime.Today, Edu = "Nic", PracPos = "Nic", Mon = 0 }; 
            this.DataContext = zam;
            NameAlert.DataContext = this;
            SurenameAlert.DataContext = this;
            this.DobTB.SelectedDate = DateTime.Today;//Nevim jak na datePicker
            this.DobTB.SelectedDateChanged += DobTB_SelectedDateChanged;//Nevim jak na datePicker

            EduAlert.DataContext = this;
            PracPosAlert.DataContext = this;
            MonAlert.DataContext = this;
        }

        private void DobTB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckDobOK();
        }

        private string _NameErr = "Name is required";
        public string NameErr { get { return _NameErr; } }
        private bool CheckNameOK()
        {
            if (zam.Name.Length > 0)
            {
                NameErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                NameErrorVisible = Visibility.Visible;
                return false;
            }
        }

      

        private Visibility _NameErrorVisible;
        public Visibility NameErrorVisible
        {
            get { return _NameErrorVisible; }
            set
            {
                _NameErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NameErrorVisible"));
            }
        }


        private string _SurErr = "Surname is required";
        public string SurErr { get { return _SurErr; } }

        private bool CheckSurnameOK()
        {
            if (zam.Surname.Length > 2)
            {
                SurErrVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                SurErrVisible = Visibility.Visible;
                return false;
            }
        }



        private Visibility _SurErrVisible;
        public Visibility SurErrVisible
        {
            get { return _SurErrVisible; }
            set
            {
                _SurErrVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SurErrVisible"));
            }
        }

        private string _DobErr = "DateOfBirth is required, you must be born before 2000";
        public string DobErr { get { return _DobErr; } }

        private bool CheckDobOK()//Nevim jak na datePicker
        {
            if (zam.Dob.Year <= 2000)
            {
                DobErrVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                DobErrVisible = Visibility.Visible;
                return false;
            }
        }



        private Visibility _DobErrVisible;//Nevim jak na datePicker
        public Visibility DobErrVisible//Nevim jak na datePicker
        {
            get { return _DobErrVisible; }//Nevim jak na datePicker
            set
            {//Nevim jak na datePicker
                _DobErrVisible = value;//Nevim jak na datePicker
                if (PropertyChanged != null)//Nevim jak na datePicker
                    PropertyChanged(this, new PropertyChangedEventArgs("DobErrVisible"));//Nevim jak na datePicker
            }
        }

        private string _EduErr = "Education is required";
        public string EduErr { get { return _EduErr; } }

        private bool CheckEduOK()
        {
            if (zam.Edu.Length > 0)
            {
                EduErrVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                EduErrVisible = Visibility.Visible;
                return false;
            }
        }



        private Visibility _EduErrVisible;
        public Visibility EduErrVisible
        {
            get { return _EduErrVisible; }
            set
            {
                _EduErrVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EduErrVisible"));
            }
        }

        private string _PracPosErr = "WorkSpot is required";
        public string PracPosErr { get { return _PracPosErr; } }

        private bool PracPosOK()
        {
            if (zam.PracPos.Length > 0)
            {
                PracPosErrVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                PracPosErrVisible = Visibility.Visible;
                return false;
            }
        }



        private Visibility _PracPosErrVisible;
        public Visibility PracPosErrVisible
        {
            get { return _PracPosErrVisible; }
            set
            {
                _PracPosErrVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PracPosErrVisible"));
            }
        }

        private string _MoneyErr = "Money are required";
        public string MoneyErr { get { return _MoneyErr; } }

        private bool MoneyOK()
        {
            if (zam.Mon >0)
            {
                MoneyErrVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                MoneyErrVisible = Visibility.Visible;
                return false;
            }
        }



        private Visibility _MoneyErrVisible;
        public Visibility MoneyErrVisible
        {
            get { return _MoneyErrVisible; }
            set
            {
                _MoneyErrVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MoneyErrVisible"));
            }
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                MessageBox.Show($@"
          Jmeno: {zam.Name}
       Prijmeni: {zam.Surname}
 Datum Narozeni: {zam.Dob}
       Vzdelani: {zam.Edu}
Pracovni Pozice: {zam.PracPos}
 Hruby plat ($): {zam.Mon}");
                Zamestnanecc.AllZamestameccs.Add(zam);
                zam = new Zamestnanecc { Name = "No", Surname = "Nic", Dob = DateTime.MinValue, Edu = "Nic", PracPos = "Nic", Mon = 1 };
                this.DataContext = zam;
            }
            catch
            {
                MessageBox.Show("Chyba");
            }

        }

        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckNameOK();
        }

        private void SurTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckSurnameOK();
        }
        private void  Dob_SelectedDateChanged(object sender, PropertyChangedEventArgs e)
        {
            CheckDobOK();//Nevim jak na datePicker
        }

        private void EduTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEduOK();
        }

        private void PracPosTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            PracPosOK();
        }

        private void MoneyTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            MoneyOK();
        }
    }
}
