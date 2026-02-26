namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Contains the results of a single <see cref="Godot.RegEx"/> match returned by <see cref="Godot.RegEx.Search(string, int, int)"/> and <see cref="Godot.RegEx.SearchAll(string, int, int)"/>. It can be used to find the position and range of the match and its capturing groups, and it can extract its substring for you.</para>
/// </summary>
public partial class RegExMatch : RefCounted
{
    /// <summary>
    /// <para>The source string used with the search pattern to find this matching result.</para>
    /// </summary>
    public string Subject
    {
        get
        {
            return GetSubject();
        }
    }

    /// <summary>
    /// <para>A dictionary of named groups and its corresponding group number. Only groups that were matched are included. If multiple groups have the same name, that name would refer to the first matching one.</para>
    /// </summary>
    public Godot.Collections.Dictionary Names
    {
        get
        {
            return GetNames();
        }
    }

    /// <summary>
    /// <para>An <see cref="Godot.Collections.Array"/> of the match and its capturing groups.</para>
    /// </summary>
    public string[] Strings
    {
        get
        {
            return GetStrings();
        }
    }

    private static readonly System.Type CachedType = typeof(RegExMatch);

    private static readonly StringName NativeName = "RegExMatch";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RegExMatch() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RegExMatch(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RegExMatch(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubject, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSubject()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroupCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of capturing groups.</para>
    /// </summary>
    public int GetGroupCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNames, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetNames()
    {
        return NativeCalls.godot_icall_0_122(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStrings, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetStrings()
    {
        return NativeCalls.godot_icall_0_108(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetString, 687115856ul);

    /// <summary>
    /// <para>Returns the substring of the match from the source string. Capturing groups can be retrieved by providing its group number as an integer or its string name (if it's a named group). The default value of 0 refers to the whole pattern.</para>
    /// <para>Returns an empty string if the group did not match or doesn't exist.</para>
    /// </summary>
    /// <param name="name">If the parameter is null, then the default value is <c>(Variant)(0)</c>.</param>
    public string GetString(Nullable<Variant> name = null)
    {
        Variant nameOrDefVal = name.HasValue ? name.Value : (Variant)(0);
        return NativeCalls.godot_icall_1_1036(MethodBind4, GodotObject.GetPtr(this), nameOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStart, 490464691ul);

    /// <summary>
    /// <para>Returns the starting position of the match within the source string. The starting position of capturing groups can be retrieved by providing its group number as an integer or its string name (if it's a named group). The default value of 0 refers to the whole pattern.</para>
    /// <para>Returns -1 if the group did not match or doesn't exist.</para>
    /// </summary>
    /// <param name="name">If the parameter is null, then the default value is <c>(Variant)(0)</c>.</param>
    public int GetStart(Nullable<Variant> name = null)
    {
        Variant nameOrDefVal = name.HasValue ? name.Value : (Variant)(0);
        return NativeCalls.godot_icall_1_970(MethodBind5, GodotObject.GetPtr(this), nameOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnd, 490464691ul);

    /// <summary>
    /// <para>Returns the end position of the match within the source string. The end position of capturing groups can be retrieved by providing its group number as an integer or its string name (if it's a named group). The default value of 0 refers to the whole pattern.</para>
    /// <para>Returns -1 if the group did not match or doesn't exist.</para>
    /// </summary>
    /// <param name="name">If the parameter is null, then the default value is <c>(Variant)(0)</c>.</param>
    public int GetEnd(Nullable<Variant> name = null)
    {
        Variant nameOrDefVal = name.HasValue ? name.Value : (Variant)(0);
        return NativeCalls.godot_icall_1_970(MethodBind6, GodotObject.GetPtr(this), nameOrDefVal);
    }

    /// <summary>
    /// Invokes the method with the given name, using the given arguments.
    /// This method is used by Godot to invoke methods from the engine side.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to invoke.</param>
    /// <param name="args">Arguments to use with the invoked method.</param>
    /// <param name="ret">Value returned by the invoked method.</param>
#pragma warning disable CS0618 // Member is obsolete
    protected internal override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
#pragma warning restore CS0618

    /// <summary>
    /// Check if the type contains a method with the given name.
    /// This method is used by Godot to check if a method exists before invoking it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to check for.</param>

    protected internal override bool HasGodotClassMethod(in godot_string_name method)
    {
        return base.HasGodotClassMethod(method);
    }

    /// <summary>
    /// Check if the type contains a signal with the given name.
    /// This method is used by Godot to check if a signal exists before raising it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="signal">Name of the signal to check for.</param>

    protected internal override bool HasGodotClassSignal(in godot_string_name signal)
    {
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'subject' property.
        /// </summary>
        public static readonly StringName Subject = "subject";
        /// <summary>
        /// Cached name for the 'names' property.
        /// </summary>
        public static readonly StringName Names = "names";
        /// <summary>
        /// Cached name for the 'strings' property.
        /// </summary>
        public static readonly StringName Strings = "strings";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_subject' method.
        /// </summary>
        public static readonly StringName GetSubject = "get_subject";
        /// <summary>
        /// Cached name for the 'get_group_count' method.
        /// </summary>
        public static readonly StringName GetGroupCount = "get_group_count";
        /// <summary>
        /// Cached name for the 'get_names' method.
        /// </summary>
        public static readonly StringName GetNames = "get_names";
        /// <summary>
        /// Cached name for the 'get_strings' method.
        /// </summary>
        public static readonly StringName GetStrings = "get_strings";
        /// <summary>
        /// Cached name for the 'get_string' method.
        /// </summary>
        public static readonly StringName GetString = "get_string";
        /// <summary>
        /// Cached name for the 'get_start' method.
        /// </summary>
        public static readonly StringName GetStart = "get_start";
        /// <summary>
        /// Cached name for the 'get_end' method.
        /// </summary>
        public static readonly StringName GetEnd = "get_end";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
