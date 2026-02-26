namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The Time singleton allows converting time between various formats and also getting time information from the system.</para>
/// <para>This class conforms with as many of the ISO 8601 standards as possible. All dates follow the Proleptic Gregorian calendar. As such, the day before <c>1582-10-15</c> is <c>1582-10-14</c>, not <c>1582-10-04</c>. The year before 1 AD (aka 1 BC) is number <c>0</c>, with the year before that (2 BC) being <c>-1</c>, etc.</para>
/// <para>Conversion methods assume "the same timezone", and do not handle timezone conversions or DST automatically. Leap seconds are also not handled, they must be done manually if desired. Suffixes such as "Z" are not handled, you need to strip them away manually.</para>
/// <para>When getting time information from the system, the time can either be in the local timezone or UTC depending on the <c>utc</c> parameter. However, the <see cref="Godot.Time.GetUnixTimeFromSystem()"/> method always uses UTC as it returns the seconds passed since the <a href="https://en.wikipedia.org/wiki/Unix_time">Unix epoch</a>.</para>
/// <para><b>Important:</b> The <c>_from_system</c> methods use the system clock that the user can manually set. <b>Never use</b> this method for precise time calculation since its results are subject to automatic adjustments by the user or the operating system. <b>Always use</b> <see cref="Godot.Time.GetTicksUsec()"/> or <see cref="Godot.Time.GetTicksMsec()"/> for precise time calculation instead, since they are guaranteed to be monotonic (i.e. never decrease).</para>
/// </summary>
public static partial class Time
{
    public enum Month : long
    {
        /// <summary>
        /// <para>The month of January, represented numerically as <c>01</c>.</para>
        /// </summary>
        January = 1,
        /// <summary>
        /// <para>The month of February, represented numerically as <c>02</c>.</para>
        /// </summary>
        February = 2,
        /// <summary>
        /// <para>The month of March, represented numerically as <c>03</c>.</para>
        /// </summary>
        March = 3,
        /// <summary>
        /// <para>The month of April, represented numerically as <c>04</c>.</para>
        /// </summary>
        April = 4,
        /// <summary>
        /// <para>The month of May, represented numerically as <c>05</c>.</para>
        /// </summary>
        May = 5,
        /// <summary>
        /// <para>The month of June, represented numerically as <c>06</c>.</para>
        /// </summary>
        June = 6,
        /// <summary>
        /// <para>The month of July, represented numerically as <c>07</c>.</para>
        /// </summary>
        July = 7,
        /// <summary>
        /// <para>The month of August, represented numerically as <c>08</c>.</para>
        /// </summary>
        August = 8,
        /// <summary>
        /// <para>The month of September, represented numerically as <c>09</c>.</para>
        /// </summary>
        September = 9,
        /// <summary>
        /// <para>The month of October, represented numerically as <c>10</c>.</para>
        /// </summary>
        October = 10,
        /// <summary>
        /// <para>The month of November, represented numerically as <c>11</c>.</para>
        /// </summary>
        November = 11,
        /// <summary>
        /// <para>The month of December, represented numerically as <c>12</c>.</para>
        /// </summary>
        December = 12
    }

    public enum Weekday : long
    {
        /// <summary>
        /// <para>The day of the week Sunday, represented numerically as <c>0</c>.</para>
        /// </summary>
        Sunday = 0,
        /// <summary>
        /// <para>The day of the week Monday, represented numerically as <c>1</c>.</para>
        /// </summary>
        Monday = 1,
        /// <summary>
        /// <para>The day of the week Tuesday, represented numerically as <c>2</c>.</para>
        /// </summary>
        Tuesday = 2,
        /// <summary>
        /// <para>The day of the week Wednesday, represented numerically as <c>3</c>.</para>
        /// </summary>
        Wednesday = 3,
        /// <summary>
        /// <para>The day of the week Thursday, represented numerically as <c>4</c>.</para>
        /// </summary>
        Thursday = 4,
        /// <summary>
        /// <para>The day of the week Friday, represented numerically as <c>5</c>.</para>
        /// </summary>
        Friday = 5,
        /// <summary>
        /// <para>The day of the week Saturday, represented numerically as <c>6</c>.</para>
        /// </summary>
        Saturday = 6
    }

    private static readonly StringName NativeName = "Time";

    private static TimeInstance singleton;

    public static TimeInstance Singleton =>
        singleton ??= (TimeInstance)InteropUtils.EngineGetSingleton("Time");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDatetimeDictFromUnixTime, 3485342025ul);

    /// <summary>
    /// <para>Converts the given Unix timestamp to a dictionary of keys: <c>year</c>, <c>month</c>, <c>day</c>, <c>weekday</c>, <c>hour</c>, <c>minute</c>, and <c>second</c>.</para>
    /// <para>The returned Dictionary's values will be the same as the <see cref="Godot.Time.GetDatetimeDictFromSystem(bool)"/> if the Unix timestamp is the current time, with the exception of Daylight Savings Time as it cannot be determined from the epoch.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetDatetimeDictFromUnixTime(long unixTimeVal)
    {
        return NativeCalls.godot_icall_1_1460(MethodBind0, GodotObject.GetPtr(Singleton), unixTimeVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDateDictFromUnixTime, 3485342025ul);

    /// <summary>
    /// <para>Converts the given Unix timestamp to a dictionary of keys: <c>year</c>, <c>month</c>, <c>day</c>, and <c>weekday</c>.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetDateDictFromUnixTime(long unixTimeVal)
    {
        return NativeCalls.godot_icall_1_1460(MethodBind1, GodotObject.GetPtr(Singleton), unixTimeVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeDictFromUnixTime, 3485342025ul);

    /// <summary>
    /// <para>Converts the given time to a dictionary of keys: <c>hour</c>, <c>minute</c>, and <c>second</c>.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetTimeDictFromUnixTime(long unixTimeVal)
    {
        return NativeCalls.godot_icall_1_1460(MethodBind2, GodotObject.GetPtr(Singleton), unixTimeVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDatetimeStringFromUnixTime, 2311239925ul);

    /// <summary>
    /// <para>Converts the given Unix timestamp to an ISO 8601 date and time string (YYYY-MM-DDTHH:MM:SS).</para>
    /// <para>If <paramref name="useSpace"/> is <see langword="true"/>, the date and time bits are separated by an empty space character instead of the letter T.</para>
    /// </summary>
    public static string GetDatetimeStringFromUnixTime(long unixTimeVal, bool useSpace = false)
    {
        return NativeCalls.godot_icall_2_1461(MethodBind3, GodotObject.GetPtr(Singleton), unixTimeVal, useSpace.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDateStringFromUnixTime, 844755477ul);

    /// <summary>
    /// <para>Converts the given Unix timestamp to an ISO 8601 date string (YYYY-MM-DD).</para>
    /// </summary>
    public static string GetDateStringFromUnixTime(long unixTimeVal)
    {
        return NativeCalls.godot_icall_1_908(MethodBind4, GodotObject.GetPtr(Singleton), unixTimeVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeStringFromUnixTime, 844755477ul);

    /// <summary>
    /// <para>Converts the given Unix timestamp to an ISO 8601 time string (HH:MM:SS).</para>
    /// </summary>
    public static string GetTimeStringFromUnixTime(long unixTimeVal)
    {
        return NativeCalls.godot_icall_1_908(MethodBind5, GodotObject.GetPtr(Singleton), unixTimeVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDatetimeDictFromDatetimeString, 3253569256ul);

    /// <summary>
    /// <para>Converts the given ISO 8601 date and time string (YYYY-MM-DDTHH:MM:SS) to a dictionary of keys: <c>year</c>, <c>month</c>, <c>day</c>, <c>weekday</c>, <c>hour</c>, <c>minute</c>, and <c>second</c>.</para>
    /// <para>If <paramref name="weekday"/> is <see langword="false"/>, then the <c>weekday</c> entry is excluded (the calculation is relatively expensive).</para>
    /// <para><b>Note:</b> Any decimal fraction in the time string will be ignored silently.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetDatetimeDictFromDatetimeString(string datetime, bool weekday)
    {
        return NativeCalls.godot_icall_2_1462(MethodBind6, GodotObject.GetPtr(Singleton), datetime, weekday.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDatetimeStringFromDatetimeDict, 1898123706ul);

    /// <summary>
    /// <para>Converts the given dictionary of keys to an ISO 8601 date and time string (YYYY-MM-DDTHH:MM:SS).</para>
    /// <para>The given dictionary can be populated with the following keys: <c>year</c>, <c>month</c>, <c>day</c>, <c>hour</c>, <c>minute</c>, and <c>second</c>. Any other entries (including <c>dst</c>) are ignored.</para>
    /// <para>If the dictionary is empty, <c>0</c> is returned. If some keys are omitted, they default to the equivalent values for the Unix epoch timestamp 0 (1970-01-01 at 00:00:00).</para>
    /// <para>If <paramref name="useSpace"/> is <see langword="true"/>, the date and time bits are separated by an empty space character instead of the letter T.</para>
    /// </summary>
    public static string GetDatetimeStringFromDatetimeDict(Godot.Collections.Dictionary datetime, bool useSpace)
    {
        return NativeCalls.godot_icall_2_1463(MethodBind7, GodotObject.GetPtr(Singleton), (godot_dictionary)(datetime ?? new()).NativeValue, useSpace.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnixTimeFromDatetimeDict, 3021115443ul);

    /// <summary>
    /// <para>Converts a dictionary of time values to a Unix timestamp.</para>
    /// <para>The given dictionary can be populated with the following keys: <c>year</c>, <c>month</c>, <c>day</c>, <c>hour</c>, <c>minute</c>, and <c>second</c>. Any other entries (including <c>dst</c>) are ignored.</para>
    /// <para>If the dictionary is empty, <c>0</c> is returned. If some keys are omitted, they default to the equivalent values for the Unix epoch timestamp 0 (1970-01-01 at 00:00:00).</para>
    /// <para>You can pass the output from <see cref="Godot.Time.GetDatetimeDictFromUnixTime(long)"/> directly into this function and get the same as what was put in.</para>
    /// <para><b>Note:</b> Unix timestamps are often in UTC. This method does not do any timezone conversion, so the timestamp will be in the same timezone as the given datetime dictionary.</para>
    /// </summary>
    public static long GetUnixTimeFromDatetimeDict(Godot.Collections.Dictionary datetime)
    {
        return NativeCalls.godot_icall_1_1464(MethodBind8, GodotObject.GetPtr(Singleton), (godot_dictionary)(datetime ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnixTimeFromDatetimeString, 1321353865ul);

    /// <summary>
    /// <para>Converts the given ISO 8601 date and/or time string to a Unix timestamp. The string can contain a date only, a time only, or both.</para>
    /// <para><b>Note:</b> Unix timestamps are often in UTC. This method does not do any timezone conversion, so the timestamp will be in the same timezone as the given datetime string.</para>
    /// <para><b>Note:</b> Any decimal fraction in the time string will be ignored silently.</para>
    /// </summary>
    public static long GetUnixTimeFromDatetimeString(string datetime)
    {
        return NativeCalls.godot_icall_1_1225(MethodBind9, GodotObject.GetPtr(Singleton), datetime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffsetStringFromOffsetMinutes, 844755477ul);

    /// <summary>
    /// <para>Converts the given timezone offset in minutes to a timezone offset string. For example, -480 returns "-08:00", 345 returns "+05:45", and 0 returns "+00:00".</para>
    /// </summary>
    public static string GetOffsetStringFromOffsetMinutes(long offsetMinutes)
    {
        return NativeCalls.godot_icall_1_908(MethodBind10, GodotObject.GetPtr(Singleton), offsetMinutes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDatetimeDictFromSystem, 205769976ul);

    /// <summary>
    /// <para>Returns the current date as a dictionary of keys: <c>year</c>, <c>month</c>, <c>day</c>, <c>weekday</c>, <c>hour</c>, <c>minute</c>, <c>second</c>, and <c>dst</c> (Daylight Savings Time).</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetDatetimeDictFromSystem(bool utc = false)
    {
        return NativeCalls.godot_icall_1_759(MethodBind11, GodotObject.GetPtr(Singleton), utc.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDateDictFromSystem, 205769976ul);

    /// <summary>
    /// <para>Returns the current date as a dictionary of keys: <c>year</c>, <c>month</c>, <c>day</c>, and <c>weekday</c>.</para>
    /// <para>The returned values are in the system's local time when <paramref name="utc"/> is <see langword="false"/>, otherwise they are in UTC.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetDateDictFromSystem(bool utc = false)
    {
        return NativeCalls.godot_icall_1_759(MethodBind12, GodotObject.GetPtr(Singleton), utc.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeDictFromSystem, 205769976ul);

    /// <summary>
    /// <para>Returns the current time as a dictionary of keys: <c>hour</c>, <c>minute</c>, and <c>second</c>.</para>
    /// <para>The returned values are in the system's local time when <paramref name="utc"/> is <see langword="false"/>, otherwise they are in UTC.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetTimeDictFromSystem(bool utc = false)
    {
        return NativeCalls.godot_icall_1_759(MethodBind13, GodotObject.GetPtr(Singleton), utc.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDatetimeStringFromSystem, 1136425492ul);

    /// <summary>
    /// <para>Returns the current date and time as an ISO 8601 date and time string (YYYY-MM-DDTHH:MM:SS).</para>
    /// <para>The returned values are in the system's local time when <paramref name="utc"/> is <see langword="false"/>, otherwise they are in UTC.</para>
    /// <para>If <paramref name="useSpace"/> is <see langword="true"/>, the date and time bits are separated by an empty space character instead of the letter T.</para>
    /// </summary>
    public static string GetDatetimeStringFromSystem(bool utc = false, bool useSpace = false)
    {
        return NativeCalls.godot_icall_2_1465(MethodBind14, GodotObject.GetPtr(Singleton), utc.ToGodotBool(), useSpace.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDateStringFromSystem, 1162154673ul);

    /// <summary>
    /// <para>Returns the current date as an ISO 8601 date string (YYYY-MM-DD).</para>
    /// <para>The returned values are in the system's local time when <paramref name="utc"/> is <see langword="false"/>, otherwise they are in UTC.</para>
    /// </summary>
    public static string GetDateStringFromSystem(bool utc = false)
    {
        return NativeCalls.godot_icall_1_351(MethodBind15, GodotObject.GetPtr(Singleton), utc.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeStringFromSystem, 1162154673ul);

    /// <summary>
    /// <para>Returns the current time as an ISO 8601 time string (HH:MM:SS).</para>
    /// <para>The returned values are in the system's local time when <paramref name="utc"/> is <see langword="false"/>, otherwise they are in UTC.</para>
    /// </summary>
    public static string GetTimeStringFromSystem(bool utc = false)
    {
        return NativeCalls.godot_icall_1_351(MethodBind16, GodotObject.GetPtr(Singleton), utc.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeZoneFromSystem, 3102165223ul);

    /// <summary>
    /// <para>Returns the current time zone as a dictionary of keys: <c>bias</c> and <c>name</c>.</para>
    /// <para>- <c>bias</c> is the offset from UTC in minutes, since not all time zones are multiples of an hour from UTC.</para>
    /// <para>- <c>name</c> is the localized name of the time zone, according to the OS locale settings of the current user.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetTimeZoneFromSystem()
    {
        return NativeCalls.godot_icall_0_122(MethodBind17, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnixTimeFromSystem, 1740695150ul);

    /// <summary>
    /// <para>Returns the current Unix timestamp in seconds based on the system time in UTC. This method is implemented by the operating system and always returns the time in UTC. The Unix timestamp is the number of seconds passed since 1970-01-01 at 00:00:00, the <a href="https://en.wikipedia.org/wiki/Unix_time">Unix epoch</a>.</para>
    /// <para><b>Note:</b> Unlike other methods that use integer timestamps, this method returns the timestamp as a <see cref="float"/> for sub-second precision.</para>
    /// </summary>
    public static double GetUnixTimeFromSystem()
    {
        return NativeCalls.godot_icall_0_144(MethodBind18, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTicksMsec, 3905245786ul);

    /// <summary>
    /// <para>Returns the amount of time passed in milliseconds since the engine started.</para>
    /// <para>Will always be positive or 0 and uses a 64-bit value (it will wrap after roughly 500 million years).</para>
    /// </summary>
    public static ulong GetTicksMsec()
    {
        return NativeCalls.godot_icall_0_137(MethodBind19, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTicksUsec, 3905245786ul);

    /// <summary>
    /// <para>Returns the amount of time passed in microseconds since the engine started.</para>
    /// <para>Will always be positive or 0 and uses a 64-bit value (it will wrap after roughly half a million years).</para>
    /// </summary>
    public static ulong GetTicksUsec()
    {
        return NativeCalls.godot_icall_0_137(MethodBind20, GodotObject.GetPtr(Singleton));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'get_datetime_dict_from_unix_time' method.
        /// </summary>
        public static readonly StringName GetDatetimeDictFromUnixTime = "get_datetime_dict_from_unix_time";
        /// <summary>
        /// Cached name for the 'get_date_dict_from_unix_time' method.
        /// </summary>
        public static readonly StringName GetDateDictFromUnixTime = "get_date_dict_from_unix_time";
        /// <summary>
        /// Cached name for the 'get_time_dict_from_unix_time' method.
        /// </summary>
        public static readonly StringName GetTimeDictFromUnixTime = "get_time_dict_from_unix_time";
        /// <summary>
        /// Cached name for the 'get_datetime_string_from_unix_time' method.
        /// </summary>
        public static readonly StringName GetDatetimeStringFromUnixTime = "get_datetime_string_from_unix_time";
        /// <summary>
        /// Cached name for the 'get_date_string_from_unix_time' method.
        /// </summary>
        public static readonly StringName GetDateStringFromUnixTime = "get_date_string_from_unix_time";
        /// <summary>
        /// Cached name for the 'get_time_string_from_unix_time' method.
        /// </summary>
        public static readonly StringName GetTimeStringFromUnixTime = "get_time_string_from_unix_time";
        /// <summary>
        /// Cached name for the 'get_datetime_dict_from_datetime_string' method.
        /// </summary>
        public static readonly StringName GetDatetimeDictFromDatetimeString = "get_datetime_dict_from_datetime_string";
        /// <summary>
        /// Cached name for the 'get_datetime_string_from_datetime_dict' method.
        /// </summary>
        public static readonly StringName GetDatetimeStringFromDatetimeDict = "get_datetime_string_from_datetime_dict";
        /// <summary>
        /// Cached name for the 'get_unix_time_from_datetime_dict' method.
        /// </summary>
        public static readonly StringName GetUnixTimeFromDatetimeDict = "get_unix_time_from_datetime_dict";
        /// <summary>
        /// Cached name for the 'get_unix_time_from_datetime_string' method.
        /// </summary>
        public static readonly StringName GetUnixTimeFromDatetimeString = "get_unix_time_from_datetime_string";
        /// <summary>
        /// Cached name for the 'get_offset_string_from_offset_minutes' method.
        /// </summary>
        public static readonly StringName GetOffsetStringFromOffsetMinutes = "get_offset_string_from_offset_minutes";
        /// <summary>
        /// Cached name for the 'get_datetime_dict_from_system' method.
        /// </summary>
        public static readonly StringName GetDatetimeDictFromSystem = "get_datetime_dict_from_system";
        /// <summary>
        /// Cached name for the 'get_date_dict_from_system' method.
        /// </summary>
        public static readonly StringName GetDateDictFromSystem = "get_date_dict_from_system";
        /// <summary>
        /// Cached name for the 'get_time_dict_from_system' method.
        /// </summary>
        public static readonly StringName GetTimeDictFromSystem = "get_time_dict_from_system";
        /// <summary>
        /// Cached name for the 'get_datetime_string_from_system' method.
        /// </summary>
        public static readonly StringName GetDatetimeStringFromSystem = "get_datetime_string_from_system";
        /// <summary>
        /// Cached name for the 'get_date_string_from_system' method.
        /// </summary>
        public static readonly StringName GetDateStringFromSystem = "get_date_string_from_system";
        /// <summary>
        /// Cached name for the 'get_time_string_from_system' method.
        /// </summary>
        public static readonly StringName GetTimeStringFromSystem = "get_time_string_from_system";
        /// <summary>
        /// Cached name for the 'get_time_zone_from_system' method.
        /// </summary>
        public static readonly StringName GetTimeZoneFromSystem = "get_time_zone_from_system";
        /// <summary>
        /// Cached name for the 'get_unix_time_from_system' method.
        /// </summary>
        public static readonly StringName GetUnixTimeFromSystem = "get_unix_time_from_system";
        /// <summary>
        /// Cached name for the 'get_ticks_msec' method.
        /// </summary>
        public static readonly StringName GetTicksMsec = "get_ticks_msec";
        /// <summary>
        /// Cached name for the 'get_ticks_usec' method.
        /// </summary>
        public static readonly StringName GetTicksUsec = "get_ticks_usec";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
