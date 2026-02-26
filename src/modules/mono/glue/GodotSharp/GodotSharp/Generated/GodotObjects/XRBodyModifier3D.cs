namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node uses body tracking data from an <see cref="Godot.XRBodyTracker"/> to pose the skeleton of a body mesh.</para>
/// <para>Positioning of the body is performed by creating an <see cref="Godot.XRNode3D"/> ancestor of the body mesh driven by the same <see cref="Godot.XRBodyTracker"/>.</para>
/// <para>The body tracking position-data is scaled by <see cref="Godot.Skeleton3D.MotionScale"/> when applied to the skeleton, which can be used to adjust the tracked body to match the scale of the body model.</para>
/// </summary>
public partial class XRBodyModifier3D : SkeletonModifier3D
{
    [System.Flags]
    public enum BodyUpdateEnum : long
    {
        /// <summary>
        /// <para>The skeleton's upper body joints are updated.</para>
        /// </summary>
        UpperBody = 1,
        /// <summary>
        /// <para>The skeleton's lower body joints are updated.</para>
        /// </summary>
        LowerBody = 2,
        /// <summary>
        /// <para>The skeleton's hand joints are updated.</para>
        /// </summary>
        Hands = 4
    }

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
        /// <para>Represents the size of the <see cref="Godot.XRBodyModifier3D.BoneUpdateEnum"/> enum.</para>
        /// </summary>
        Max = 2
    }

    /// <summary>
    /// <para>The name of the <see cref="Godot.XRBodyTracker"/> registered with <see cref="Godot.XRServer"/> to obtain the body tracking data from.</para>
    /// </summary>
    public StringName BodyTracker
    {
        get
        {
            return GetBodyTracker();
        }
        set
        {
            SetBodyTracker(value);
        }
    }

    /// <summary>
    /// <para>Specifies the body parts to update.</para>
    /// </summary>
    public XRBodyModifier3D.BodyUpdateEnum BodyUpdate
    {
        get
        {
            return GetBodyUpdate();
        }
        set
        {
            SetBodyUpdate(value);
        }
    }

    /// <summary>
    /// <para>Specifies the type of updates to perform on the bones.</para>
    /// </summary>
    public XRBodyModifier3D.BoneUpdateEnum BoneUpdate
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

    private static readonly System.Type CachedType = typeof(XRBodyModifier3D);

    private static readonly StringName NativeName = "XRBodyModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRBodyModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRBodyModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRBodyModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBodyTracker, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBodyTracker(StringName trackerName)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(trackerName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBodyTracker, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetBodyTracker()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBodyUpdate, 2211199417ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBodyUpdate(XRBodyModifier3D.BodyUpdateEnum bodyUpdate)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)bodyUpdate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBodyUpdate, 2642335328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRBodyModifier3D.BodyUpdateEnum GetBodyUpdate()
    {
        return (XRBodyModifier3D.BodyUpdateEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneUpdate, 3356796943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneUpdate(XRBodyModifier3D.BoneUpdateEnum boneUpdate)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)boneUpdate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneUpdate, 1309305964ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRBodyModifier3D.BoneUpdateEnum GetBoneUpdate()
    {
        return (XRBodyModifier3D.BoneUpdateEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'body_tracker' property.
        /// </summary>
        public static readonly StringName BodyTracker = "body_tracker";
        /// <summary>
        /// Cached name for the 'body_update' property.
        /// </summary>
        public static readonly StringName BodyUpdate = "body_update";
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
        /// Cached name for the 'set_body_tracker' method.
        /// </summary>
        public static readonly StringName SetBodyTracker = "set_body_tracker";
        /// <summary>
        /// Cached name for the 'get_body_tracker' method.
        /// </summary>
        public static readonly StringName GetBodyTracker = "get_body_tracker";
        /// <summary>
        /// Cached name for the 'set_body_update' method.
        /// </summary>
        public static readonly StringName SetBodyUpdate = "set_body_update";
        /// <summary>
        /// Cached name for the 'get_body_update' method.
        /// </summary>
        public static readonly StringName GetBodyUpdate = "get_body_update";
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
