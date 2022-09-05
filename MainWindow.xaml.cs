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
using arbejdsplads.Props;   



namespace arbejdsplads
{
    /// <summary>
    /// Interaction logic for MainWin'dow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        ArbejdspladsContext maContext = new();
        List<Medarbejder> getMedarbejderList;



        public MainWindow()
        {
            InitializeComponent();
            FirstNameInput.Clear();
            LastNameInput.Clear();

            UpdateData();
        }

     


        public void UpdateData()
        {
            NameList.Items.Clear();
            getMedarbejderList = (from m in maContext.medarbejder
                                  where m.FirstName != null &&
                                        m.LastName != null &&
                                        m.ArbejderID != 0
                                  select m).ToList();

            void AddItem(int ArbejderID, string? FirstName, string? LastName)
            {
                NameList.Items.Add(new Medarbejder()
                {
                    ArbejderID = ArbejderID,
                    FirstName = FirstName,
                    LastName = LastName,
                });

            }
            foreach (var m in getMedarbejderList)
                AddItem(m.ArbejderID, m.FirstName, m.LastName);
        }

        public  void CreateData()
        {
            

            var firstName = FirstNameInput.Text.ToString();
            var lastName = LastNameInput.Text.ToString();

            Medarbejder newMa = new()
            {
                FirstName = firstName,
                LastName = lastName
            };
            maContext.Add(newMa);

            maContext.SaveChanges();
            FirstNameInput.Clear();
            LastNameInput.Clear();
        
            
            
        }

        public void DeleteData()
        {
            maContext.ChangeTracker.Clear();

            if (NameList.SelectedItem != null)
            {
                maContext.Remove(NameList.SelectedItem);
                NameList.Items.Remove(NameList.SelectedItem);
               
            }

            maContext.SaveChanges();
            FirstNameInput.Clear();
            LastNameInput.Clear();



        }

       

        public void EditData()
        {
            Medarbejder? maToEdit = NameList.SelectedItem as Medarbejder;
         

            var FirstNameText = FirstNameInput.Text;
            var LastNameText = LastNameInput.Text;
           
            if(FirstNameInput.Text == "" & LastNameInput.Text == "")
            {
                if(maToEdit != null)
                {
                    FirstNameInput.Text = maToEdit.FirstName;
                    LastNameInput.Text = maToEdit.LastName;
                }
            }
            if (FirstNameInput.Text != "" & LastNameInput.Text != "")
            {
                if (maToEdit != null)
                {
                    var NameCheck = maContext.medarbejder.First(a => a.ArbejderID == maToEdit.ArbejderID);
                    
                    NameCheck.ArbejderID = maToEdit.ArbejderID;
                    NameCheck.FirstName = FirstNameInput.Text;
                    NameCheck.LastName = LastNameInput.Text;
                    maContext.SaveChanges();
                   
                    
                    
                }
            }



            maContext.SaveChanges();
        }

        private void NameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
        }

        private void CREATE_Click(object sender, RoutedEventArgs e) {
            CreateData();
            UpdateData();
        }

        private void DELETE_Click(object sender, RoutedEventArgs e) {
           DeleteData();
            UpdateData();

        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            EditData();
            UpdateData();
        }

        private void FirstNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

     
    }
}

