using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GPServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGPDriver" in both code and config file together.
    [ServiceContract]
    public interface IGPDriver
    {
        [OperationContract]
        void DoWork();
    }
}
