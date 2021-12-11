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
        }

        DataTable dataTable;

        public void DTtoTrace(DataTable dataTable)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Общая информация");
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

            Label labelFirstName = new Label();
            labelFirstName.Content = FirstName;

            Label labelLastName = new Label();
            labelLastName.Content = LastName;

            Label labelPatronymic = new Label();
            labelPatronymic.Content = Patronymic;

            DatePicker datePickerBirthday = new DatePicker();
            datePickerBirthday.SelectedDate = Birthday;

            DatePicker datePickerRegistrationDate = new DatePicker();
            datePickerRegistrationDate.SelectedDate = RegistrationDate;

            Label labelEmail = new Label();
            labelEmail.Content = Email;

            Label labelPhone = new Label();
            labelPhone.Content = Phone;

            Label labelGenderCode = new Label();
            labelGenderCode.Content = GenderCode;

            Label labelPhotoPath = new Label();
            labelPhotoPath.Content = PhotoPath;

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
            dataTable = Class.SQLClass.SQLDT("SELECT ID, FirstName, LastName, Patronymic, Birthday, RegistrationDate, Email, Phone, GenderCode, PhotoPath FROM Client");
            DTtoTrace(dataTable);
            updateNowPagination();
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                viewClient(dataTable, i);
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
            paginationMax = (Convert.ToUInt32(dataTable.Rows.Count) / clientOnOneList);
            if ((Convert.ToUInt32(dataTable.Rows.Count) % clientOnOneList) > 0)
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
    }
}
