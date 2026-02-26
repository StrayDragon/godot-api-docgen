namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.SkeletonModifier3D"/> for aligning bones along a <see cref="Godot.Path3D"/>. The smoothness of the fitting depends on the <see cref="Godot.Curve3D.BakeInterval"/>.</para>
/// <para>If you want the <see cref="Godot.Path3D"/> to attach to a specific bone, it is recommended to place a <see cref="Godot.ModifierBoneTarget3D"/> before the <see cref="Godot.SplineIK3D"/> in the <see cref="Godot.SkeletonModifier3D"/> list (children of the <see cref="Godot.Skeleton3D"/>), and then place a <see cref="Godot.Path3D"/> as the <see cref="Godot.ModifierBoneTarget3D"/>'s child.</para>
/// <para>Bone twist is determined based on the <see cref="Godot.Curve3D.GetPointTilt(int)"/>.</para>
/// <para>If the root bone joint and the start point of the <see cref="Godot.Curve3D"/> are separated, it assumes that there is a linear line segment between them. This means that the vector pointing toward the start point of the <see cref="Godot.Curve3D"/> takes precedence over the shortest intersection point along the <see cref="Godot.Curve3D"/>.</para>
/// <para>If the end bone joint exceeds the path length, it is bent as close as possible to the end point of the <see cref="Godot.Curve3D"/>.</para>
/// </summary>
public partial class SplineIK3D : ChainIK3D
{
    /// <summary>
    /// <para>The number of settings.</para>
    /// </summary>
    public int SettingCount
    {
        get
        {
            return GetSettingCount();
        }
        set
        {
            SetSettingCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SplineIK3D);

    private static readonly StringName NativeName = "SplineIK3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SplineIK3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SplineIK3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SplineIK3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPath3D, 2761262315ul);

    /// <summary>
    /// <para>Sets the node path of the <see cref="Godot.Path3D"/> which is describing the path.</para>
    /// </summary>
    public void SetPath3D(int index, NodePath path3D)
    {
        NativeCalls.godot_icall_2_75(MethodBind0, GodotObject.GetPtr(this), index, (godot_node_path)(path3D?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPath3D, 408788394ul);

    /// <summary>
    /// <para>Returns the node path of the <see cref="Godot.Path3D"/> which is describing the path.</para>
    /// </summary>
    public NodePath GetPath3D(int index)
    {
        return NativeCalls.godot_icall_1_74(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTiltEnabled, 300928843ul);

    /// <summary>
    /// <para>Sets if the tilt property of the <see cref="Godot.Curve3D"/> should affect the bone twist.</para>
    /// </summary>
    public void SetTiltEnabled(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind2, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTiltEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns if the tilt property of the <see cref="Godot.Curve3D"/> affects the bone twist.</para>
    /// </summary>
    public bool IsTiltEnabled(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind3, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTiltFadeIn, 3937882851ul);

    /// <summary>
    /// <para>If <paramref name="size"/> is greater than <c>0</c>, the tilt is interpolated between <paramref name="size"/> start bones from the start point of the <see cref="Godot.Curve3D"/> when they are apart.</para>
    /// <para>If <paramref name="size"/> is equal <c>0</c>, the tilts between the root bone head and the start point of the <see cref="Godot.Curve3D"/> are unified with a tilt of the start point of the <see cref="Godot.Curve3D"/>.</para>
    /// <para>If <paramref name="size"/> is less than <c>0</c>, the tilts between the root bone and the start point of the <see cref="Godot.Curve3D"/> are <c>0.0</c>.</para>
    /// </summary>
    public void SetTiltFadeIn(int index, int size)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), index, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTiltFadeIn, 923996154ul);

    /// <summary>
    /// <para>Returns the tilt interpolation method used between the root bone and the start point of the <see cref="Godot.Curve3D"/> when they are apart. See also <see cref="Godot.SplineIK3D.SetTiltFadeIn(int, int)"/>.</para>
    /// </summary>
    public int GetTiltFadeIn(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTiltFadeOut, 3937882851ul);

    /// <summary>
    /// <para>If <paramref name="size"/> is greater than <c>0</c>, the tilt is interpolated between <paramref name="size"/> end bones from the end point of the <see cref="Godot.Curve3D"/> when they are apart.</para>
    /// <para>If <paramref name="size"/> is equal <c>0</c>, the tilts between the end bone tail and the end point of the <see cref="Godot.Curve3D"/> are unified with a tilt of the end point of the <see cref="Godot.Curve3D"/>.</para>
    /// <para>If <paramref name="size"/> is less than <c>0</c>, the tilts between the end bone and the end point of the <see cref="Godot.Curve3D"/> are <c>0.0</c>.</para>
    /// </summary>
    public void SetTiltFadeOut(int index, int size)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), index, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTiltFadeOut, 923996154ul);

    /// <summary>
    /// <para>Returns the tilt interpolation method used between the end bone and the end point of the <see cref="Godot.Curve3D"/> when they are apart. See also <see cref="Godot.SplineIK3D.SetTiltFadeOut(int, int)"/>.</para>
    /// </summary>
    public int GetTiltFadeOut(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), index);
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
    public new class PropertyName : ChainIK3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'setting_count' property.
        /// </summary>
        public static readonly StringName SettingCount = "setting_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ChainIK3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_path_3d' method.
        /// </summary>
        public static readonly StringName SetPath3D = "set_path_3d";
        /// <summary>
        /// Cached name for the 'get_path_3d' method.
        /// </summary>
        public static readonly StringName GetPath3D = "get_path_3d";
        /// <summary>
        /// Cached name for the 'set_tilt_enabled' method.
        /// </summary>
        public static readonly StringName SetTiltEnabled = "set_tilt_enabled";
        /// <summary>
        /// Cached name for the 'is_tilt_enabled' method.
        /// </summary>
        public static readonly StringName IsTiltEnabled = "is_tilt_enabled";
        /// <summary>
        /// Cached name for the 'set_tilt_fade_in' method.
        /// </summary>
        public static readonly StringName SetTiltFadeIn = "set_tilt_fade_in";
        /// <summary>
        /// Cached name for the 'get_tilt_fade_in' method.
        /// </summary>
        public static readonly StringName GetTiltFadeIn = "get_tilt_fade_in";
        /// <summary>
        /// Cached name for the 'set_tilt_fade_out' method.
        /// </summary>
        public static readonly StringName SetTiltFadeOut = "set_tilt_fade_out";
        /// <summary>
        /// Cached name for the 'get_tilt_fade_out' method.
        /// </summary>
        public static readonly StringName GetTiltFadeOut = "get_tilt_fade_out";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ChainIK3D.SignalName
    {
    }
}
