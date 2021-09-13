namespace CompulsoryCow.DateTime.Abstractions
{
    public partial class DateTime
    {
        #region Methods used for testing and not production.

        /// <summary>This method sets the function used for <see cref="Compare(DateTime, DateTime)"/>.
        /// By default it is set to <see cref="System.DateTime.Compare(System.DateTime, System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Compare(DateTime, DateTime)"/> return <see cref="System.DateTime.Compare(System.DateTime, System.DateTime)"/>.
        /// </summary>
        /// <param name="func"></param>
        public static void SetCompare(System.Func<int> func)
        {
            _compare = func;
        }

        /// <summary>This method sets the function used for <see cref="DaysInMonth(int, int)"/>.
        /// By default it is set to <see cref="System.DateTime.DaysInMonth(int, int)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="DaysInMonth(int, int)"/> use its default function.
        /// </summary>
        /// <param name="func"></param>
        public static void SetDaysInMonth(System.Func<int> func)
        {
            _daysInMonth = func;
        }

        /// <summary>This method sets the function used for <see cref="Equals(DateTime, DateTime)"/>.
        /// By default it is set to <see cref="System.DateTime.Equals(System.DateTime, System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Equals(DateTime, DateTime)"/> use its default function.
        /// </summary>
        /// <param name="func"></param>
        public static void SetEquals(System.Func<bool> func)
        {
            _equals = func;
        }

        /// <summary>This method sets the function used for <see cref="FromBinary(long)"/>.
        /// By default it is set to <see cref="System.DateTime.FromBinary(long)"/>.
        /// 
        /// This method should onl be used for testing and really not bi in this class at all.
        /// Set to null to have <see cref="FromBinary(long)"/> use its default function.
        /// </summary>
        /// <param name="func"></param>
        public static void SetFromBinary(System.Func<DateTime> func)
        {
            _fromBinary = func;
        }

        /// <summary>This method sets the <see cref="FromFileTime(long)"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromFileTime(long)"/> return <see cref="System.DateTime.FromFileTime(long)"/>.
        /// </summary>
        /// <param name="func"></param>
        public static void SetFromFileTime(System.Func<DateTime> func) => _fromFileTime = func;

        /// <summary>This method sets the <see cref="FromFileTimeUtc(long)"/> method.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromFileTimeUtc(long)"/> return <see cref="System.DateTime.FromFileTimeUtc(long)"/>.
        /// </summary>
        /// <param name="func"></param>
        public static void SetFromFileTimeUtc(System.Func<DateTime> func) => _fromFileTimeUtc = func;

        /// <summary>This method sets the <see cref="FromOADate(double)"/> method.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromOADate(double)"/> return <see cref="System.DateTime.FromOADate(double)"/>.
        /// </summary>
        /// <param name="func"></param>
        public static void SetFromOADate(System.Func<DateTime> func) => _fromOADate = func;

        /// <summary>This method sets the <see cref="IsLeapYear(int)"/> method.
        /// Set to null to have <see cref="IsLeapYear(int)"/> return <see cref="System.DateTime.IsLeapYear(int)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all
        /// </summary>
        /// <param name="func"></param>
        public static void SetIsLeapYear(System.Func<bool> func) => _isLeapYear = func;

        /// <summary>This method sets the <see cref="Parse(string, System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="Parse(string, System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.Parse(string, System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        public static void SetParseStringFormatProviderStyle(System.Func<IDateTime> func) => _parseStringFormatProviderStyle = func;

        /// <summary>This method set the <see cref="Parse(string, System.IFormatProvider)"/> method.
        /// Set to null to have <see cref="Parse(string, System.IFormatProvider)"/> return <see cref="System.DateTime.Parse(string, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and should really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        public static void SetParseStringFormatProvider(System.Func<IDateTime> func) => _parseStringFormatProvider = func;

        /// <summary>This method set the <see cref="Parse(string)"/> method.
        /// Set to null to have <see cref="Parse(string)"/> return <see cref="System.DateTime.Parse(string)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="func"></param>
        public static void SetParseString(System.Func<IDateTime> func) => _parseString = func;

        /// <summary>This method set the <see cref="ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="parse"></param>
        public static void SetParseExactStringStringArrayFormatProviderStyle(System.Func<IDateTime> parse) =>
            _parseExactStringStringArrayFormatProviderStyle = parse;

        /// <summary>This method set the <see cref="ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="func"></param>
        public static void SetParseExactStringStringFormatProviderStyle(System.Func<IDateTime> func) =>
            _parseExactStringStringFormatProviderStyle = func;

        /// <summary>This method sets the <see cref="ParseExact(string, string, System.IFormatProvider)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string, System.IFormatProvider)"/> return <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="func"></param>
        public static void SetParseExactStringStringFormatProvider(System.Func<IDateTime> func) =>
            _parseExactStringStringFormatProvider = func;

        /// <summary>This method sets the <see cref="SpecifyKind(DateTime, System.DateTimeKind)"/> method.
        /// Set to null to have <see cref="SpecifyKind(DateTime, System.DateTimeKind)"/> return <see cref="System.DateTime.SpecifyKind(System.DateTime, System.DateTimeKind)"/>.
        /// </summary>
        /// <param name="func"></param>
        public static void SetSpecifyKind(System.Func<DateTime> func) => _specifyKind = func;

        /// <summary>This method sets the <see cref="TryParse(string, System.IFormatProvider, DateTimeStyles, out DateTime)"/> method.
        /// Set to null to have <see cref="TryParse(string, System.IFormatProvider, DateTimeStyles, out DateTime)"/> return <see cref="System.DateTime.TryParse(string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        public static void SetTryParseStringIFormatProviderDateTimeStylesDateTime(
            System.Func<bool> returnFunc,
            System.Func<DateTime> outFunc)
        {
            _setTryParseStringIFormatProviderDateTimeStylesDateTime.Return = returnFunc;
            _setTryParseStringIFormatProviderDateTimeStylesDateTime.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParse(string, out DateTime)"/> method.
        /// Set to null to have <see cref="TryParse(string, out DateTime)"/> return <see cref="System.DateTime.TryParse(string, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        public static void SetTryParseStringDateTime(
            System.Func<bool> returnFunc,
            System.Func<DateTime> outFunc)
        {
            _setTryParseStringDateTime.Return = returnFunc;
            _setTryParseStringDateTime.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> method.
        /// Set to null to have <see cref="TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> return <see cref="System.DateTime.TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        public static void SetTryParseExactStringStringIFormatProviderDateTimeStyles(
            System.Func<bool> returnFunc,
            System.Func<IDateTime> outFunc)
        {
            _setTryParseExactStringStringIFormatProviderDateTimeStyles.Return = returnFunc;
            _setTryParseExactStringStringIFormatProviderDateTimeStyles.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> method.
        /// Set to null to have <see cref="TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> return <see cref="System.DateTime.TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        public static void SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(
            System.Func<bool> returnFunc,
            System.Func<IDateTime> outFunc)
        {
            _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Return = returnFunc;
            _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="Now"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="DateTime.Now"/> return <see cref="System.DateTime.Now"/>.
        /// </summary>
        /// <param name="nowFunc"></param>
        public static void SetNow(System.Func<DateTime> nowFunc) => _now = nowFunc;

        /// <summary>This method sets the <see cref="Today"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Today"/> return <see cref="System.DateTime.Today"/>.
        /// </summary>
        /// <param name="todayFunc"></param>
        public static void SetToday(System.Func<DateTime> todayFunc) => _today = todayFunc;

        /// <summary>This method sets the <see cref="DateTime.UtcNow"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="UtcNow"/> return <see cref="System.DateTime.UtcNow"/>.
        /// </summary>
        /// <param name="utcNowFunc"></param>
        public static void SetUtcNow(System.Func<DateTime> utcNowFunc) => _utcNow = utcNowFunc;

        /// <summary>This method sets the <see cref="operator +(DateTime, TimeSpan)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetAddOperator(System.Func<Abstractions.DateTime> func)
        {
            _addOperator = func;
        }

        /// <summary>This method sets the <see cref="operator -(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetSubtractDateTimeDateTimeOperator(System.Func<TimeSpan> func)
        {
            _subtractDateTimeDateTimeOperator = func;
        }

        /// <summary>This method sets the <see cref="operator -(DateTime, TimeSpan)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetSubtractDateTimeTimeSpanOperator(System.Func<DateTime> func)
        {
            _subtractDateTimeTimeSpanOperator = func;
        }

        /// <summary>This method sets the <see cref="operator ==(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetEqualsOperator(System.Func<bool> func)
        {
            _equalsOperator = func;
        }

        /// <summary>This method sets the <see cref="operator !=(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetNotEqualsOperator(System.Func<bool> func)
        {
            _notEqualsOperator = func;
        }

        /// <summary>This method sets the <see cref="operator <(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetEarlierThanOperator(System.Func<bool> func)
        {
            _earlierThanOperator = func;
        }

        /// <summary>This method sets the <see cref="operator >(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetLaterThanOperator(System.Func<bool> func)
        {
            _laterThanOperator = func;
        }

        /// <summary>This method sets the <see cref="operator <=(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetEarlierThanOrEqualOperator(System.Func<bool> func)
        {
            _earlierThanOrEqualOperator = func;
        }

        /// <summary>This method sets the <see cref="operator >=(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        public static void SetLaterThanOrEqualOperator(System.Func<bool> func)
        {
            _laterThanOrEqualOperator = func;
        }

        #endregion  //  Methods used for testing and not production.
    }
}
