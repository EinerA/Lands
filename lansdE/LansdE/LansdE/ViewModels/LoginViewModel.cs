namespace LansdE.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using View;

    public   class LoginViewModel : BaseViewModel
    {
       
        #region Atributes
        private string password;
        private string email;
        private bool isRunning;
        private bool isEnabled;


        #endregion

        #region Propeties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembed
        {
            get; set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }

        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembed = true;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

    

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Your must enter an email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Your must enter an Password.",
                    "Accept");
                return;

            }

            this.IsRunning = true;
            this.IsEnabled = false;


            if (this.Email !="einer@gmail.com" || this.Password !="123")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept");
                this.Password = string.Empty;
                return;

            }
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
