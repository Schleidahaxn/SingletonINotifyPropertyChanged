using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClassLibrary {
    public class LiveConditions : INotifyPropertyChanged {
        // Singleton-Instanz
        private static readonly Lazy<LiveConditions> _instance = new(() => new LiveConditions());
        public static LiveConditions Instance => _instance.Value;

        private LiveConditions() { }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool _buttonClicked;
        public bool ButtonClicked {
            get => _buttonClicked;
            set {
                if (_buttonClicked != value) {
                    _buttonClicked = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _led1On;
        public bool Led1On {
            get => _led1On;
            set {
                if (_led1On != value) {
                    _led1On = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _led2On;
        public bool Led2On {
            get => _led2On;
            set {
                if (_led2On != value) {
                    _led2On = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _led3On;
        public bool Led3On {
            get => _led3On;
            set {
                if (_led3On != value) {
                    _led3On = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
