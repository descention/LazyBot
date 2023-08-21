using System;

namespace LazyLib.Helpers
{
    public class Timeout
    {
        private int Time;
        private int TimeoutTick;

        public Timeout(int Milseconds)
        {
            this.Time = Milseconds;
            this.Reset();
        }

        public void Reset()
        {
            this.TimeoutTick = Environment.TickCount + this.Time;
        }

        public bool IsTimedOut
        {
            get
            {
                return (Environment.TickCount >= this.TimeoutTick);
            }
        }
    }
}
