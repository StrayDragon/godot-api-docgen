namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Occludes light cast by a Light2D, casting shadows. The LightOccluder2D must be provided with an <see cref="Godot.OccluderPolygon2D"/> in order for the shadow to be computed.</para>
/// </summary>
public partial class LightOccluder2D : Node2D
{
    /// <summary>
    /// <para>The <see cref="Godot.OccluderPolygon2D"/> used to compute the shadow.</para>
    /// </summary>
    public OccluderPolygon2D Occluder
    {
        get
        {
            return GetOccluderPolygon();
        }
        set
        {
            SetOccluderPolygon(value);
        }
    }

    /// <summary>
    /// <para>If enabled, the occluder will be part of a real-time generated signed distance field that can be used in custom shaders.</para>
    /// </summary>
    public bool SdfCollision
    {
        get
        {
            return IsSetAsSdfCollision();
        }
        set
        {
            SetAsSdfCollision(value);
        }
    }

    /// <summary>
    /// <para>The LightOccluder2D's occluder light mask. The LightOccluder2D will cast shadows only from Light2D(s) that have the same light mask(s).</para>
    /// </summary>
    public int OccluderLightMask
    {
        get
        {
            return GetOccluderLightMask();
        }
        set
        {
            SetOccluderLightMask(value);
        }
    }

    private static readonly System.Type CachedType = typeof(LightOccluder2D);

    private static readonly StringName NativeName = "LightOccluder2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public LightOccluder2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal LightOccluder2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal LightOccluder2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOccluderPolygon, 3258315893ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOccluderPolygon(OccluderPolygon2D polygon)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(polygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOccluderPolygon, 3962317075ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OccluderPolygon2D GetOccluderPolygon()
    {
        return (OccluderPolygon2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOccluderLightMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOccluderLightMask(int mask)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOccluderLightMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOccluderLightMask()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsSdfCollision, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAsSdfCollision(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSetAsSdfCollision, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSetAsSdfCollision()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'occluder' property.
        /// </summary>
        public static readonly StringName Occluder = "occluder";
        /// <summary>
        /// Cached name for the 'sdf_collision' property.
        /// </summary>
        public static readonly StringName SdfCollision = "sdf_collision";
        /// <summary>
        /// Cached name for the 'occluder_light_mask' property.
        /// </summary>
        public static readonly StringName OccluderLightMask = "occluder_light_mask";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_occluder_polygon' method.
        /// </summary>
        public static readonly StringName SetOccluderPolygon = "set_occluder_polygon";
        /// <summary>
        /// Cached name for the 'get_occluder_polygon' method.
        /// </summary>
        public static readonly StringName GetOccluderPolygon = "get_occluder_polygon";
        /// <summary>
        /// Cached name for the 'set_occluder_light_mask' method.
        /// </summary>
        public static readonly StringName SetOccluderLightMask = "set_occluder_light_mask";
        /// <summary>
        /// Cached name for the 'get_occluder_light_mask' method.
        /// </summary>
        public static readonly StringName GetOccluderLightMask = "get_occluder_light_mask";
        /// <summary>
        /// Cached name for the 'set_as_sdf_collision' method.
        /// </summary>
        public static readonly StringName SetAsSdfCollision = "set_as_sdf_collision";
        /// <summary>
        /// Cached name for the 'is_set_as_sdf_collision' method.
        /// </summary>
        public static readonly StringName IsSetAsSdfCollision = "is_set_as_sdf_collision";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
