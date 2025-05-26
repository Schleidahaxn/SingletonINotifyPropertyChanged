using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary {
    public class IOCContainer {
        private static IOCContainer _instance = new();
        public static IOCContainer Instance => _instance;
        protected Dictionary<Type, Type> _types = new();
        protected Dictionary<Type, object> _instances = new();
        private IOCContainer() {

        }

        public void Register<I, T>(bool singleton = false) where T : I {
            if (singleton) {
                // Register as singleton
                var instance = Activator.CreateInstance(typeof(T));
                if (instance is I i) {
                    _instances[typeof(I)] = i;
                }
            }

            // Register as transient
            _types[typeof(I)] = typeof(T);

        }

        public I Resolve<I>() {
            if (_instances.ContainsKey(typeof(I))) {
                return (I)_instances[typeof(I)];
            }
            else if (_types.ContainsKey(typeof(I))) {
                var type = _types[typeof(I)];
                var instance = Activator.CreateInstance(type);
                if (instance is I i) {
                    return i;
                }
            }
            throw new Exception($"Type {typeof(I)} not registered");
        }
    }
}
