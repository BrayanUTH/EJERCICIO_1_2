using EJERCICIO_1_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EJERCICIO_1_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSendInfo_Clicked(object sender, EventArgs e)
        {
            string response = ValidateEmptyFields();

            if (response !=  "OK")
            {
                await DisplayAlert("Advertencia", response, "OK");
            }
            else
            {
                Employee employee = new Employee()
                {
                    names = "Nombre Completo: "+txtNames.Text,
                    surnames = "Apellidos: "+txtSurnames.Text,
                    age = Convert.ToInt32(txtAge.Text),
                    email = "Email: "+txtEmail.Text,
                };
                ReceivingPage receivingPage = new ReceivingPage();
                receivingPage.BindingContext = employee;

                await Navigation.PushAsync(receivingPage);
            }

        }

        private string ValidateEmptyFields()
        {
            string names = txtNames.Text;
            string surnames = txtSurnames.Text;
            string age = txtAge.Text;
            string email = txtEmail.Text;
            const string ER_EMAIL = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (string.IsNullOrEmpty(names))
            {
                return "Debes ingresar tus nombres";
            }
            else if (string.IsNullOrEmpty(surnames))
            {
                return "Debes ingresar tus apellidos";
            }
            else if (string.IsNullOrEmpty(age))
            {
                return "Debes ingresar tu edad";
            }
            else if (string.IsNullOrEmpty(email))
            {
                return "Debes ingresar tu correo electronico";
            }
            else if (!Regex.IsMatch(email, ER_EMAIL))
            {
                return "Debes ingresar un correo electronico valido";
            }
            else
            {
                return "OK";
            }

        }
    }
}
