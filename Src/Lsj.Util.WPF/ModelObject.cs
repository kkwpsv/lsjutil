using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lsj.Util.WPF
{
    public class ModelObject : INotifyPropertyChanged, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                var vc = new ValidationContext(this);
                vc.MemberName = columnName;
                var result = new List<ValidationResult>();

                var value = this.GetType().GetProperty(columnName)?.GetValue(this, null);
                if (value != null)
                {
                    Validator.TryValidateProperty(value, vc, result);
                    var stringResult = result.Select(x => x.ErrorMessage).ToList();
                    this.Validate(columnName, value, stringResult);
                    if (stringResult.Count > 0)
                    {
                        return string.Join(Environment.NewLine, stringResult);
                    }
                }
                return string.Empty;
            }
        }

        protected virtual void Validate(string name, object value, List<string> result)
        {
        }

        public string Error => "";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetField<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                this.OnPropertyChanged(propertyName);
            }
        }
    }
}
