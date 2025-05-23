using ClassLibrary;

namespace TestSingletoFrontend.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public LiveConditions LiveConditions { get; } = LiveConditions.Instance;
        Logic logic = new Logic();

        public MainWindowViewModel() {
            LiveConditions.Instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(LiveConditions.Instance.ButtonClicked)) {
                    // Reagiere auf ButtonClicked
                }
            };
        }

        public void ToggleLed1() {
            LiveConditions.Instance.Led1On = !LiveConditions.Instance.Led1On;
        }
        public void ToggleLed2() {
            LiveConditions.Instance.Led2On = !LiveConditions.Instance.Led2On;
        }
    }
}
