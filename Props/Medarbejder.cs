using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arbejdsplads.Props
{
    public class Medarbejder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private string? firstname;
        private string? lastname;

        [Key]
        public int ArbejderID { get; set; }

       
        public string? FirstName
        {
           get => firstname;
           set => SetField(ref firstname, value);
        }
        public string? LastName {

            get => lastname;
            set => SetField(ref lastname, value);
        }
    }
}
