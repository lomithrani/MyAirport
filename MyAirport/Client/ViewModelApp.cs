using System.ComponentModel;

namespace Client
{
    public class ViewModelApp : INotifyPropertyChanged
    {
        private string currentPage;


        public ViewModelApp()
        {
            CurrentPage = "/Client;component/Views/Vols.xaml";
        }

        public string CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnNotifyPropertyChange("currentPage");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChange(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, args);
        }

        protected void OnNotifyPropertyChange(string propertyName)
        {
            OnNotifyPropertyChange(new PropertyChangedEventArgs(propertyName));
        }
    }
}