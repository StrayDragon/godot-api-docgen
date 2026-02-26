namespace Godot;

using System;

public static partial class GD
{
    /// <summary>
    /// Returns true if this byte array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The byte array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this byte[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this byte array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The byte array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this byte[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this byte array to a string with brackets.
    /// </summary>
    /// <param name="instance">The byte array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this byte[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this int array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The int array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this int[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this int array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The int array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this int[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this int array to a string with brackets.
    /// </summary>
    /// <param name="instance">The int array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this int[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this long array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The long array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this long[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this long array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The long array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this long[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this long array to a string with brackets.
    /// </summary>
    /// <param name="instance">The long array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this long[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this float array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The float array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this float[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this float array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The float array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this float[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this float array to a string with brackets.
    /// </summary>
    /// <param name="instance">The float array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this float[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this double array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The double array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this double[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this double array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The double array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this double[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this double array to a string with brackets.
    /// </summary>
    /// <param name="instance">The double array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this double[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this string array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The string array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this string[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this string array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The string array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this string[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this string array to a string with brackets.
    /// </summary>
    /// <param name="instance">The string array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this string[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this Color array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The Color array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this Color[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this Color array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The Color array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this Color[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this Color array to a string with brackets.
    /// </summary>
    /// <param name="instance">The Color array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this Color[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this Vector2 array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The Vector2 array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this Vector2[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this Vector2 array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The Vector2 array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this Vector2[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this Vector2 array to a string with brackets.
    /// </summary>
    /// <param name="instance">The Vector2 array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this Vector2[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this Vector2I array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The Vector2I array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this Vector2I[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this Vector2I array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The Vector2I array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this Vector2I[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this Vector2I array to a string with brackets.
    /// </summary>
    /// <param name="instance">The Vector2I array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this Vector2I[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this Vector3 array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The Vector3 array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this Vector3[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this Vector3 array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The Vector3 array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this Vector3[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this Vector3 array to a string with brackets.
    /// </summary>
    /// <param name="instance">The Vector3 array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this Vector3[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this Vector3I array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The Vector3I array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this Vector3I[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this Vector3I array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The Vector3I array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this Vector3I[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this Vector3I array to a string with brackets.
    /// </summary>
    /// <param name="instance">The Vector3I array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this Vector3I[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this Vector4 array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The Vector4 array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this Vector4[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this Vector4 array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The Vector4 array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this Vector4[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this Vector4 array to a string with brackets.
    /// </summary>
    /// <param name="instance">The Vector4 array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this Vector4[] instance)
    {
        return "[" + instance.Join() + "]";
    }

    /// <summary>
    /// Returns true if this Vector4I array is empty or doesn't exist.
    /// </summary>
    /// <param name="instance">The Vector4I array check.</param>
    /// <returns>Whether or not the array is empty.</returns>
    public static bool IsEmpty(this Vector4I[] instance)
    {
        return instance == null || instance.Length == 0;
    }

    /// <summary>
    /// Converts this Vector4I array to a string delimited by the given string.
    /// </summary>
    /// <param name="instance">The Vector4I array to convert.</param>
    /// <param name="delimiter">The delimiter to use between items.</param>
    /// <returns>A single string with all items.</returns>
    public static string Join(this Vector4I[] instance, string delimiter = ", ")
    {
        return String.Join(delimiter, instance);
    }

    /// <summary>
    /// Converts this Vector4I array to a string with brackets.
    /// </summary>
    /// <param name="instance">The Vector4I array to convert.</param>
    /// <returns>A single string with all items.</returns>
    public static string Stringify(this Vector4I[] instance)
    {
        return "[" + instance.Join() + "]";
    }
}
