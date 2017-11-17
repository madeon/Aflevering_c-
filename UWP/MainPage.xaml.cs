using ClassLibrary;
using System;
using System.Linq;
using Windows.UI.Popups;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace UWP
{
    
    public sealed partial class MainPage : Page
    {
        
        private SerialKey serial;
        private Submission submission;
        private DataPersistance data;

        public MainPage()
        {
            this.InitializeComponent();
            Initialize();
        }

        //Initializes and sets up the program
        private void Initialize()
        {
            serial = new SerialKey();
            data = new DataPersistance();
            GenerateKeys(100);
            AddKeysToListView();
        }


        /*
         * Displayers a pop-up message
         * The method is async to avoid blocking the GUI thread.
         * */
        private async void DisplayMessage(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        //Checks if the submission has the correct data
        private bool CheckIfValidSubmission()
        {
            
            if(String.IsNullOrEmpty(firstNameTextBox.Text))
            {
                DisplayMessage("You need to enter a first name");
                return false;
            }

            if(String.IsNullOrEmpty(lastNameTextBox.Text))
            {
                DisplayMessage("You need to enter a last name");
                return false;
            }

            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                DisplayMessage("You need to enter an e-mail address");
                return false;
            }

            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                DisplayMessage("You need to enter a phone number");
                return false;
            }

            if (String.IsNullOrEmpty(datePicker.Date.ToString()))
            {
                DisplayMessage("You need to select a date");
                return false;
            }

            if (String.IsNullOrEmpty(serialNumberTextBox.Text))
            {
                DisplayMessage("You need select a Serial Number from the list");
                return false;
            }

            if (!serial.Keys.Contains(serialNumberTextBox.Text))
            {
                DisplayMessage("The inserted key does not exist in the system. Check for spelling errors.");
                return false;
            }


            return true;
        }

        //Creates a new submission
        private void submission_button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfValidSubmission())
            {
                submission = new Submission(firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text, phoneTextBox.Text, datePicker.Date.ToString(), serialNumberTextBox.Text);
                PrintSuccessfulSubmissionMessage();
                //SwitchView();
            }
        }


        //Prints a message of the entered information in the submission
        private void PrintSuccessfulSubmissionMessage()
        {
            DisplayMessage(
                    "Succes! \nYou entered: \nName: " + submission.FirstName
                    + "\nLastname: " + submission.LastName + "\nEmail: " + submission.Email
                    + "\nPhone: " + submission.Phone + "\nDate: " + submission.Birthday
                    + "\nSerial Number: " + submission.SerialNumber);
        }

        //Generates unique 100 keys
        private void GenerateKeys(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                serial.Keys.Add(serial.GenerateKey());
            }
        }

        //Adds the keys to the listview
        private void AddKeysToListView()
        {

            foreach(String key in serial.Keys)
            {
                listView.Items.Add(key);
            }
        }

        //When a key is selected in the listview it is inserted into the serial number textbox
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView.SelectedIndex;
            serialNumberTextBox.Text = serial.Keys.ElementAt(index);
        }

        //Changes the view to Second Page
        public void SwitchView()
        {
            Frame.Navigate(typeof(SecondPage));
        }

        //Changes the view to Second Page
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SecondPage));
        }

        private void XMLButton_Click(object sender, RoutedEventArgs e)
        {

            //data.SaveDataToXML(submission, "submission");
            data.Save(submission, @"C:\Users\Mathias\Desktop\data.xml");
            textBlock1.Text = "Succes!";
        }
    }
}
