namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Editor facility that helps you draw a 2D polygon used as resource for <see cref="Godot.LightOccluder2D"/>.</para>
/// </summary>
public partial class OccluderPolygon2D : Resource
{
    public enum CullModeEnum : long
    {
        /// <summary>
        /// <para>Culling is disabled. See <see cref="Godot.OccluderPolygon2D.CullMode"/>.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Culling is performed in the clockwise direction. See <see cref="Godot.OccluderPolygon2D.CullMode"/>.</para>
        /// </summary>
        Clockwise = 1,
        /// <summary>
        /// <para>Culling is performed in the counterclockwise direction. See <see cref="Godot.OccluderPolygon2D.CullMode"/>.</para>
        /// </summary>
        CounterClockwise = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, closes the polygon. A closed OccluderPolygon2D occludes the light coming from any direction. An opened OccluderPolygon2D occludes the light only at its outline's direction.</para>
    /// </summary>
    public bool Closed
    {
        get
        {
            return IsClosed();
        }
        set
        {
            SetClosed(value);
        }
    }

    /// <summary>
    /// <para>The culling mode to use.</para>
    /// </summary>
    public OccluderPolygon2D.CullModeEnum CullMode
    {
        get
        {
            return GetCullMode();
        }
        set
        {
            SetCullMode(value);
        }
    }

    /// <summary>
    /// <para>A <see cref="Godot.Vector2"/> array with the index for polygon's vertices positions.</para>
    /// </summary>
    public Vector2[] Polygon
    {
        get
        {
            return GetPolygon();
        }
        set
        {
            SetPolygon(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OccluderPolygon2D);

    private static readonly StringName NativeName = "OccluderPolygon2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OccluderPolygon2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OccluderPolygon2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OccluderPolygon2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClosed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClosed(bool closed)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), closed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClosed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsClosed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMode, 3500863002ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCullMode(OccluderPolygon2D.CullModeEnum cullMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)cullMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMode, 33931036ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OccluderPolygon2D.CullModeEnum GetCullMode()
    {
        return (OccluderPolygon2D.CullModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPolygon, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(Vector2[] polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind4, GodotObject.GetPtr(this), polygon);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(ReadOnlySpan<Vector2> polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind4, GodotObject.GetPtr(this), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygon, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetPolygon()
    {
        return NativeCalls.godot_icall_0_225(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'closed' property.
        /// </summary>
        public static readonly StringName Closed = "closed";
        /// <summary>
        /// Cached name for the 'cull_mode' property.
        /// </summary>
        public static readonly StringName CullMode = "cull_mode";
        /// <summary>
        /// Cached name for the 'polygon' property.
        /// </summary>
        public static readonly StringName Polygon = "polygon";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_closed' method.
        /// </summary>
        public static readonly StringName SetClosed = "set_closed";
        /// <summary>
        /// Cached name for the 'is_closed' method.
        /// </summary>
        public static readonly StringName IsClosed = "is_closed";
        /// <summary>
        /// Cached name for the 'set_cull_mode' method.
        /// </summary>
        public static readonly StringName SetCullMode = "set_cull_mode";
        /// <summary>
        /// Cached name for the 'get_cull_mode' method.
        /// </summary>
        public static readonly StringName GetCullMode = "get_cull_mode";
        /// <summary>
        /// Cached name for the 'set_polygon' method.
        /// </summary>
        public static readonly StringName SetPolygon = "set_polygon";
        /// <summary>
        /// Cached name for the 'get_polygon' method.
        /// </summary>
        public static readonly StringName GetPolygon = "get_polygon";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
