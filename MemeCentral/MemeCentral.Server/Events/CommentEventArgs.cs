using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeCentral.Server.Events
{
    public class CommentEventArgs : EventArgs
    {
        public CommentEventArgs(int dataID, string content)
        {
            this.DataID = dataID;
            this.Content = content;
        }

        public int DataID { get; set; }
        public string Content { get; set; }
    }
}