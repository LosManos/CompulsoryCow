namespace CompulsoryCow.DateTime.Abstractions
{
    public static class DateTimeExtensions
    {
        /// <summary>This method is for converting a <see cref="Abstractions.DateTime"/> 
        /// to a <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static System.DateTime ToSystemDateTime(this DateTime me)
        {
            // Hopefully dotnetcore3 can make sure ` me`  is not null instead of throwing.
            if( me == null)
            {
                throw new System.ArgumentNullException(nameof(me));
            }
            return new System.DateTime(me.Ticks, me.Kind);
        }

        /// <summary>This method is for convertng a <see cref="System.DateTime"/>
        /// to a <see cref="Abstractions.DateTime"/>.
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static DateTime ToAbstractionsDateTime(this System.DateTime me)
        {
            return new DateTime(me.Ticks, me.Kind);
        }
    }
}
