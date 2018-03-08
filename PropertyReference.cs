using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPPSVN {
    class PropertyReference<Type> {
        public delegate Type DelegateGet();
        
        public DelegateGet Get {
            get; set;
        }
        
        public Type Value {
            get => Get();
        }

        public PropertyReference(DelegateGet get) {
            Get = get;
        }
    }
}
