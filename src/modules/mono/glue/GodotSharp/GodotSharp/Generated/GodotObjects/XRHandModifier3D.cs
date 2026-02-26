namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node uses hand tracking data from an <see cref="Godot.XRHandTracker"/> to pose the skeleton of a hand mesh.</para>
/// <para>Positioning of hands is performed by creating an <see cref="Godot.XRNode3D"/> ancestor of the hand mesh driven by the same <see cref="Godot.XRHandTracker"/>.</para>
/// <para>The hand tracking position-data is scaled by <see cref="Godot.Skeleton3D.MotionScale"/> when applied to the skeleton, which can be used to adjust the tracked hand to match the scale of the hand model.</para>
/// </summary>
public partial class XRHandModifier3D : SkeletonModifier3D
{
    public enum BoneUpdateEnum : long
    {
        /// <summary>
        /// <para>The skeleton's bones are fully updated (both position and rotation) to match the tracked bones.</para>
        /// </summary>
        Full = 0,
        /// <summary>
        /// <para>The skeleton's bones are only rotated to align with the tracked bones, preserving bone length.</para>
        /// </summary>
        RotationOnly = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.XRHandModifier3D.BoneUpdateEnum"/> enum.</para>
        /// </summary>
        Max = 2
    }

    /// <summary>
    /// <para>The name of the <see cref="Godot.XRHandTracker"/> registered with <see cref="Godot.XRServer"/> to obtain the hand tracking data from.</para>
    /// </summary>
    public StringName HandTracker
    {
        get
        {
            return GetHandTracker();
        }
        set
        {
            SetHandTracker(value);
        }
    }

    /// <summary>
    /// <para>Specifies the type of updates to perform on the bones.</para>
    /// </summary>
    public XRHandModifier3D.BoneUpdateEnum BoneUpdate
    {
        get
        {
            return GetBoneUpdate();
        }
        set
        {
            SetBoneUpdate(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRHandModifier3D);

    private static readonly StringName NativeName = "XRHandModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRHandModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRHandModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRHandModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandTracker, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandTracker(StringName trackerName)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(trackerName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandTracker, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetHandTracker()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneUpdate, 3635701455ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneUpdate(XRHandModifier3D.BoneUpdateEnum boneUpdate)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)boneUpdate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneUpdate, 2873665691ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRHandModifier3D.BoneUpdateEnum GetBoneUpdate()
    {
        return (XRHandModifier3D.BoneUpdateEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
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
    public new class PropertyName : SkeletonModifier3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'hand_tracker' property.
        /// </summary>
        public static readonly StringName HandTracker = "hand_tracker";
        /// <summary>
        /// Cached name for the 'bone_update' property.
        /// </summary>
        public static readonly StringName BoneUpdate = "bone_update";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_hand_tracker' method.
        /// </summary>
        public static readonly StringName SetHandTracker = "set_hand_tracker";
        /// <summary>
        /// Cached name for the 'get_hand_tracker' method.
        /// </summary>
        public static readonly StringName GetHandTracker = "get_hand_tracker";
        /// <summary>
        /// Cached name for the 'set_bone_update' method.
        /// </summary>
        public static readonly StringName SetBoneUpdate = "set_bone_update";
        /// <summary>
        /// Cached name for the 'get_bone_update' method.
        /// </summary>
        public static readonly StringName GetBoneUpdate = "get_bone_update";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
