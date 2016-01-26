using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeCentral.Server.Events
{
    public class DislikeEventArgs : EventArgs
    {
        public DislikeEventArgs(int dataID, int dislikeValue)
        {
            this.DataID = dataID;
            this.DislikeValue = dislikeValue;
        }

        public int DataID { get; set; }
        public int DislikeValue { get; set; }
    }
}