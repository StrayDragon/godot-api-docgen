namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class stores the result of a 3D navigation path query from the <see cref="Godot.NavigationServer3D"/>.</para>
/// </summary>
public partial class NavigationPathQueryResult3D : RefCounted
{
    public enum PathSegmentType : long
    {
        /// <summary>
        /// <para>This segment of the path goes through a region.</para>
        /// </summary>
        Region = 0,
        /// <summary>
        /// <para>This segment of the path goes through a link.</para>
        /// </summary>
        Link = 1
    }

    /// <summary>
    /// <para>The resulting path array from the navigation query. All path array positions are in global coordinates. Without customized query parameters this is the same path as returned by <see cref="Godot.NavigationServer3D.MapGetPath(Rid, Vector3, Vector3, bool, uint)"/>.</para>
    /// </summary>
    public Vector3[] Path
    {
        get
        {
            return GetPath();
        }
        set
        {
            SetPath(value);
        }
    }

    /// <summary>
    /// <para>The type of navigation primitive (region or link) that each point of the path goes through.</para>
    /// </summary>
    public int[] PathTypes
    {
        get
        {
            return GetPathTypes();
        }
        set
        {
            SetPathTypes(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Rid"/>s of the regions and links that each point of the path goes through.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> PathRids
    {
        get
        {
            return GetPathRids();
        }
        set
        {
            SetPathRids(value);
        }
    }

    /// <summary>
    /// <para>The <c>ObjectID</c>s of the <see cref="Godot.GodotObject"/>s which manage the regions and links each point of the path goes through.</para>
    /// </summary>
    public long[] PathOwnerIds
    {
        get
        {
            return GetPathOwnerIds();
        }
        set
        {
            SetPathOwnerIds(value);
        }
    }

    /// <summary>
    /// <para>Returns the length of the path.</para>
    /// </summary>
    public float PathLength
    {
        get
        {
            return GetPathLength();
        }
        set
        {
            SetPathLength(value);
        }
    }

    private static readonly System.Type CachedType = typeof(NavigationPathQueryResult3D);

    private static readonly StringName NativeName = "NavigationPathQueryResult3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationPathQueryResult3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationPathQueryResult3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationPathQueryResult3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPath, 334873810ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPath(Vector3[] path)
    {
        NativeCalls.godot_icall_1_187(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPath(ReadOnlySpan<Vector3> path)
    {
        NativeCalls.godot_icall_1_187(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPath, 497664490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3[] GetPath()
    {
        return NativeCalls.godot_icall_0_228(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathTypes, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathTypes(int[] pathTypes)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), pathTypes);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathTypes(ReadOnlySpan<int> pathTypes)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), pathTypes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathTypes, 1930428628ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetPathTypes()
    {
        return NativeCalls.godot_icall_0_151(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathRids, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathRids(Godot.Collections.Array<Rid> pathRids)
    {
        NativeCalls.godot_icall_1_138(MethodBind4, GodotObject.GetPtr(this), (godot_array)(pathRids ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathRids, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Rid> GetPathRids()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathOwnerIds, 3709968205ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathOwnerIds(long[] pathOwnerIds)
    {
        NativeCalls.godot_icall_1_844(MethodBind6, GodotObject.GetPtr(this), pathOwnerIds);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathOwnerIds(ReadOnlySpan<long> pathOwnerIds)
    {
        NativeCalls.godot_icall_1_844(MethodBind6, GodotObject.GetPtr(this), pathOwnerIds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathOwnerIds, 235988956ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long[] GetPathOwnerIds()
    {
        return NativeCalls.godot_icall_0_13(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPathLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reset, 3218959716ul);

    /// <summary>
    /// <para>Reset the result object to its initial state. This is useful to reuse the object across multiple queries.</para>
    /// </summary>
    public void Reset()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
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
        /// Cached name for the 'path' property.
        /// </summary>
        public static readonly StringName Path = "path";
        /// <summary>
        /// Cached name for the 'path_types' property.
        /// </summary>
        public static readonly StringName PathTypes = "path_types";
        /// <summary>
        /// Cached name for the 'path_rids' property.
        /// </summary>
        public static readonly StringName PathRids = "path_rids";
        /// <summary>
        /// Cached name for the 'path_owner_ids' property.
        /// </summary>
        public static readonly StringName PathOwnerIds = "path_owner_ids";
        /// <summary>
        /// Cached name for the 'path_length' property.
        /// </summary>
        public static readonly StringName PathLength = "path_length";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_path' method.
        /// </summary>
        public static readonly StringName SetPath = "set_path";
        /// <summary>
        /// Cached name for the 'get_path' method.
        /// </summary>
        public static readonly StringName GetPath = "get_path";
        /// <summary>
        /// Cached name for the 'set_path_types' method.
        /// </summary>
        public static readonly StringName SetPathTypes = "set_path_types";
        /// <summary>
        /// Cached name for the 'get_path_types' method.
        /// </summary>
        public static readonly StringName GetPathTypes = "get_path_types";
        /// <summary>
        /// Cached name for the 'set_path_rids' method.
        /// </summary>
        public static readonly StringName SetPathRids = "set_path_rids";
        /// <summary>
        /// Cached name for the 'get_path_rids' method.
        /// </summary>
        public static readonly StringName GetPathRids = "get_path_rids";
        /// <summary>
        /// Cached name for the 'set_path_owner_ids' method.
        /// </summary>
        public static readonly StringName SetPathOwnerIds = "set_path_owner_ids";
        /// <summary>
        /// Cached name for the 'get_path_owner_ids' method.
        /// </summary>
        public static readonly StringName GetPathOwnerIds = "get_path_owner_ids";
        /// <summary>
        /// Cached name for the 'set_path_length' method.
        /// </summary>
        public static readonly StringName SetPathLength = "set_path_length";
        /// <summary>
        /// Cached name for the 'get_path_length' method.
        /// </summary>
        public static readonly StringName GetPathLength = "get_path_length";
        /// <summary>
        /// Cached name for the 'reset' method.
        /// </summary>
        public static readonly StringName Reset = "reset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
