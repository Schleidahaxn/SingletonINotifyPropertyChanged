using System;
using System.ComponentModel;

namespace ClassLibrary {
    public class Logic {

        public LiveConditions LiveConditions => LiveConditions.Instance;

        public Logic() {
            LiveConditions.PropertyChanged += LiveConditions_PropertyChanged;
        }

        private void LiveConditions_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == nameof(LiveConditions.Led1On) ||
                e.PropertyName == nameof(LiveConditions.Led2On)) {

                if (LiveConditions.Led1On && LiveConditions.Led2On) {
                    LiveConditions.Led3On = true;
                }
                else {
                    LiveConditions.Led3On = false;
                }
            }
        }
    }
}
