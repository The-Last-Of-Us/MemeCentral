namespace MemeCentral.Server.Events
{
    using System;

    public class LikeEventArgs : EventArgs
    {
        public LikeEventArgs(int dataID, int likeValue)
        {
            this.DataID = dataID;
            this.LikeValue = likeValue;
        }

        public int DataID { get; set; }
        public int LikeValue { get; set; }
    }
}