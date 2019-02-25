using Lsj.Util.APIs.UmeTrip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Tests.APIs.UmeTrip
{
    [TestClass]
    public class UmeTripAPIDebugger
    {
        [TestMethod]
        public void Debug()
        {
            var api = new UmeTripAPI();
            api.GetFlights("PEK", "SHA", DateTime.Now);
            
        }
    }
}
