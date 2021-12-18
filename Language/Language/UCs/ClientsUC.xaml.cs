using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace Language.UCs
{
    /// <summary>
    /// Логика взаимодействия для ClientsUC.xaml
    /// </summary>
    public partial class ClientsUC : UserControl
    {
        public ClientsUC()
        {
            InitializeComponent();
            clientsDataTable = new DataTable();
            clientsDataTable.TableName = "clientsDT";
        }

        public static DataTable clientsDataTable;

        public static void formatClientDT(DataTable dataTable)
        {
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("First name",typeof(string));
            dataTable.Columns.Add("Last name", typeof(string));
            dataTable.Columns.Add("Patronymic", typeof(string));
            dataTable.Columns.Add("Birthday", typeof(DateTime));
            dataTable.Columns.Add("RegistrationDate", typeof(DateTime));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("GenderCode", typeof(string));
            dataTable.Columns.Add("PhotoPath", typeof(string));
        }

        public void newClientInDT(DataTable dataTable, int ID, string FirstName, string LastName, string Patronymic, DateTime Birthday, DateTime RegistrationDate, string Email, string Phone, string GenderCode, string PhotoPath)
        {
            dataTable.Rows.Add(ID, FirstName, LastName, Patronymic, Birthday, RegistrationDate, Email, Phone, GenderCode, PhotoPath);
        }

        public void DTtoTrace(DataTable dataTable)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Общая информация");
            try
            {
                Trace.WriteLine(dataTable.TableName);
            }
            catch
            {
                Trace.WriteLine("Имени нет");
            }
            Trace.WriteLine(String.Format("x = " + dataTable.Columns.Count));
            Trace.WriteLine(String.Format("y = " + dataTable.Rows.Count));

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Trace.Write("|");
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Trace.Write(String.Format("{0,3}", dataTable.Rows[i].ItemArray[j].ToString()));
                    Trace.Write("|");
                }
                Trace.WriteLine("");
            }

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                Trace.WriteLine(String.Format(dataTable.Columns[i].ColumnName + " " + dataTable.Columns[i].DataType));
            }
        }

        public void viewClient(DataTable dataTable, int i)
        {
            int ID = Convert.ToInt32(dataTable.Rows[i].ItemArray[0].ToString());
            string FirstName = dataTable.Rows[i].ItemArray[1].ToString();
            string LastName = dataTable.Rows[i].ItemArray[2].ToString();
            string Patronymic = dataTable.Rows[i].ItemArray[3].ToString();
            DateTime Birthday = Convert.ToDateTime(dataTable.Rows[i].ItemArray[4].ToString());
            DateTime RegistrationDate = Convert.ToDateTime(dataTable.Rows[i].ItemArray[5].ToString());
            string Email = dataTable.Rows[i].ItemArray[6].ToString();
            string Phone = dataTable.Rows[i].ItemArray[7].ToString();
            string GenderCode = dataTable.Rows[i].ItemArray[8].ToString();
            string PhotoPath = dataTable.Rows[i].ItemArray[9].ToString();

            Label labelID = new Label();
            labelID.Content = ID;
            labelID.FontSize = 16;
            labelID.FontFamily = new FontFamily("Comic Sans MS");

            Label labelFirstName = new Label();
            labelFirstName.Content = FirstName;
            labelFirstName.FontSize = 16;
            labelFirstName.FontFamily = new FontFamily("Comic Sans MS");

            Label labelLastName = new Label();
            labelLastName.Content = LastName;
            labelLastName.FontSize = 16;
            labelLastName.FontFamily = new FontFamily("Comic Sans MS");

            Label labelPatronymic = new Label();
            labelPatronymic.Content = Patronymic;
            labelPatronymic.FontSize = 16;
            labelPatronymic.FontFamily = new FontFamily("Comic Sans MS");

            DatePicker datePickerBirthday = new DatePicker();
            datePickerBirthday.SelectedDate = Birthday;

            DatePicker datePickerRegistrationDate = new DatePicker();
            datePickerRegistrationDate.SelectedDate = RegistrationDate;

            Label labelEmail = new Label();
            labelEmail.Content = Email;
            labelEmail.FontSize = 16;
            labelEmail.FontFamily = new FontFamily("Comic Sans MS");

            Label labelPhone = new Label();
            labelPhone.Content = Phone;
            labelPhone.FontSize = 16;
            labelPhone.FontFamily = new FontFamily("Comic Sans MS");

            Label labelGenderCode = new Label();
            labelGenderCode.Content = GenderCode;
            labelGenderCode.FontSize = 16;
            labelGenderCode.FontFamily = new FontFamily("Comic Sans MS");

            Label labelPhotoPath = new Label();
            labelPhotoPath.Content = PhotoPath;
            labelPhotoPath.FontSize = 16;
            labelPhotoPath.FontFamily = new FontFamily("Comic Sans MS");

            StackPanel stackPanelClient = new StackPanel();
            stackPanelClient.Orientation = Orientation.Horizontal;
            stackPanelClient.Children.Add(labelID);
            stackPanelClient.Children.Add(labelFirstName);
            stackPanelClient.Children.Add(labelLastName);
            stackPanelClient.Children.Add(labelPatronymic);
            stackPanelClient.Children.Add(datePickerBirthday);
            stackPanelClient.Children.Add(datePickerRegistrationDate);
            stackPanelClient.Children.Add(labelEmail);
            stackPanelClient.Children.Add(labelPhone);
            stackPanelClient.Children.Add(labelGenderCode);
            stackPanelClient.Children.Add(labelPhotoPath);

            this.ClientSP.Children.Add(stackPanelClient);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //clientsDataTable = Class.SQLClass.SQLDT("SELECT ID, FirstName, LastName, Patronymic, Birthday, RegistrationDate, Email, Phone, GenderCode, PhotoPath FROM Client");
            formatClientDT(clientsDataTable);
            DTtoTrace(clientsDataTable);
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 7, "Алла", "Мироновна", "Ермакова", new DateTime(1976, 01, 22), new DateTime(2017, 02, 09, 00, 00, 00, 000), "whimsy@aol.com", "7(060)437-13-73", "ж", @"Клиенты\48.jpg");
            newClientInDT(clientsDataTable, 8, "Глеб", "Максимович", "Селиверстов", new DateTime(1999, 06, 20), new DateTime(2016, 01, 07, 00, 00, 00, 000), "jigsaw@sbcglobal.net", "7(200)554-28-68", "м", @"Клиенты\m37.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            newClientInDT(clientsDataTable, 5, "Иосиф", "Голубев", "Тимофеевич", new DateTime(1982, 05, 06), new DateTime(2018, 08, 18, 00, 00, 00, 000), "smcnabb@att.net", "7(78)972-73-11 ", "м", @"Клиенты\m18.jpg");
            DTtoTrace(clientsDataTable);
            updateNowPagination();
            for(int i = 0; i < clientsDataTable.Rows.Count; i++)
            {
                viewClient(clientsDataTable, i);
            }
        }

        private void CreateB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReadB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteB_Click(object sender, RoutedEventArgs e)
        {

        }

        uint pagination = 1;
        uint clientOnOneList = 2;
        uint paginationMax = 1;

        public void paginationMaxF()
        {
            paginationMax = (Convert.ToUInt32(clientsDataTable.Rows.Count) / clientOnOneList);
            if ((Convert.ToUInt32(clientsDataTable.Rows.Count) % clientOnOneList) > 0)
                paginationMax++;
        }

        public void updateNowPagination()
        {
            paginationTB.Text = Convert.ToString(pagination);
        }

        public void updateNowPagination(uint i)
        {
            pagination = i;
            updateNowPagination();
        }

        private void pastB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pagination > 1)
                    pagination--;
                updateNowPagination();
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void firstB_Click(object sender, RoutedEventArgs e)
        {
            updateNowPagination(1);
        }

        private void endB_Click(object sender, RoutedEventArgs e)
        {
            updateNowPagination(paginationMax);
        }

        private void nextB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pagination < paginationMax)
                    pagination++;
                updateNowPagination();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void clientsBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.ChangeUC(MainWindow.getPastUC());
        }
    }
}
