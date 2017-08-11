namespace FriendlyExtensions.DateTime
{
    public static partial class DateTimeExtensions
    {
        public static int GetTimeSlot(this System.DateTime dt)
        {
            return ((dt.Hour == 0) ? dt.Hour : (dt.Hour * 2)) + ((dt.Minute == 30) ? 1 : 0);
        }

        public static System.DateTime RoundDown(this System.DateTime dt, System.TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            return new System.DateTime(dt.Ticks - delta, dt.Kind);
        }

        public static System.DateTime RoundToNearest(this System.DateTime dt, System.TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            bool roundUp = delta > d.Ticks / 2;
            var offset = roundUp ? d.Ticks : 0;

            return new System.DateTime(dt.Ticks + offset - delta, dt.Kind);
        }

        public static System.DateTime RoundUp(this System.DateTime dt, System.TimeSpan d)
        {
            var modTicks = dt.Ticks % d.Ticks;
            var delta = modTicks != 0 ? d.Ticks - modTicks : 0;
            return new System.DateTime(dt.Ticks + delta, dt.Kind);
        }
    }
}