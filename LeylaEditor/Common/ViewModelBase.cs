using System.ComponentModel;
using System.Runtime.Serialization;

namespace LeylaEditor
{
	[DataContract(IsReference = true)]
	public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}