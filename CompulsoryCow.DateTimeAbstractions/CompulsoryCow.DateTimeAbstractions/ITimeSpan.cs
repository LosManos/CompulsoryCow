namespace CompulsoryCow.DateTime.Abstractions
{
    public interface ITimeSpan
    {
        /// <summary>
        /// <see cref="System.TimeSpan.TotalMilliseconds"/>
        /// </summary>
        double TotalMilliseconds { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.TotalHours"/>
        /// </summary>
        double TotalHours { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.TotalDays"/>
        /// </summary>
        double TotalDays { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.Ticks"/>
        /// </summary>
        long Ticks { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.Seconds"/>
        /// </summary>
        int Seconds { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.Minutes"/>
        /// </summary>
        int Minutes { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.Milliseconds"/>
        /// </summary>
        int Milliseconds { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.Hours"/>
        int Hours { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.Days"/>
        /// </summary>
        int Days { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.TotalMinutes"/>
        /// </summary>
        double TotalMinutes { get; }

        /// <summary>
        /// <see cref="System.TimeSpan.TotalSeconds"/>
        /// </summary>
        double TotalSeconds { get; }
    }
}
