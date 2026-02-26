namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A hierarchy of <see cref="Godot.Bone2D"/>s can be bound to a <see cref="Godot.Skeleton2D"/> to control and animate other <see cref="Godot.Node2D"/> nodes.</para>
/// <para>You can use <see cref="Godot.Bone2D"/> and <see cref="Godot.Skeleton2D"/> nodes to animate 2D meshes created with the <see cref="Godot.Polygon2D"/> UV editor.</para>
/// <para>Each bone has a <see cref="Godot.Bone2D.Rest"/> transform that you can reset to with <see cref="Godot.Bone2D.ApplyRest()"/>. These rest poses are relative to the bone's parent.</para>
/// <para>If in the editor, you can set the rest pose of an entire skeleton using a menu option, from the code, you need to iterate over the bones to set their individual rest poses.</para>
/// </summary>
public partial class Bone2D : Node2D
{
    /// <summary>
    /// <para>Rest transform of the bone. You can reset the node's transforms to this value using <see cref="Godot.Bone2D.ApplyRest()"/>.</para>
    /// </summary>
    public Transform2D Rest
    {
        get
        {
            return GetRest();
        }
        set
        {
            SetRest(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Bone2D);

    private static readonly StringName NativeName = "Bone2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Bone2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Bone2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Bone2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRest, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRest(Transform2D rest)
    {
        NativeCalls.godot_icall_1_218(MethodBind0, GodotObject.GetPtr(this), &rest);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRest, 3814499831ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetRest()
    {
        return NativeCalls.godot_icall_0_219(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyRest, 3218959716ul);

    /// <summary>
    /// <para>Resets the bone to the rest pose. This is equivalent to setting <see cref="Godot.Node2D.Transform"/> to <see cref="Godot.Bone2D.Rest"/>.</para>
    /// </summary>
    public void ApplyRest()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeletonRest, 3814499831ul);

    /// <summary>
    /// <para>Returns the node's <see cref="Godot.Bone2D.Rest"/> <see cref="Godot.Transform2D"/> if it doesn't have a parent, or its rest pose relative to its parent.</para>
    /// </summary>
    public Transform2D GetSkeletonRest()
    {
        return NativeCalls.godot_icall_0_219(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndexInSkeleton, 3905245786ul);

    /// <summary>
    /// <para>Returns the node's index as part of the entire skeleton. See <see cref="Godot.Skeleton2D"/>.</para>
    /// </summary>
    public int GetIndexInSkeleton()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutocalculateLengthAndAngle, 2586408642ul);

    /// <summary>
    /// <para>When set to <see langword="true"/>, the <see cref="Godot.Bone2D"/> node will attempt to automatically calculate the bone angle and length using the first child <see cref="Godot.Bone2D"/> node, if one exists. If none exist, the <see cref="Godot.Bone2D"/> cannot automatically calculate these values and will print a warning.</para>
    /// </summary>
    public void SetAutocalculateLengthAndAngle(bool autoCalculate)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), autoCalculate.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutocalculateLengthAndAngle, 36873697ul);

    /// <summary>
    /// <para>Returns whether this <see cref="Godot.Bone2D"/> is going to autocalculate its length and bone angle using its first <see cref="Godot.Bone2D"/> child node, if one exists. If there are no <see cref="Godot.Bone2D"/> children, then it cannot autocalculate these values and will print a warning.</para>
    /// </summary>
    public bool GetAutocalculateLengthAndAngle()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLength, 373806689ul);

    /// <summary>
    /// <para>Sets the length of the bone in the <see cref="Godot.Bone2D"/>.</para>
    /// </summary>
    public void SetLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 1740695150ul);

    /// <summary>
    /// <para>Returns the length of the bone in the <see cref="Godot.Bone2D"/> node.</para>
    /// </summary>
    public float GetLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneAngle, 373806689ul);

    /// <summary>
    /// <para>Sets the bone angle for the <see cref="Godot.Bone2D"/>. This is typically set to the rotation from the <see cref="Godot.Bone2D"/> to a child <see cref="Godot.Bone2D"/> node.</para>
    /// <para><b>Note:</b> This is different from the <see cref="Godot.Bone2D"/>'s rotation. The bone's angle is the rotation of the bone shown by the gizmo, which is unaffected by the <see cref="Godot.Bone2D"/>'s <see cref="Godot.Node2D.Transform"/>.</para>
    /// </summary>
    public void SetBoneAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneAngle, 1740695150ul);

    /// <summary>
    /// <para>Returns the angle of the bone in the <see cref="Godot.Bone2D"/>.</para>
    /// <para><b>Note:</b> This is different from the <see cref="Godot.Bone2D"/>'s rotation. The bone's angle is the rotation of the bone shown by the gizmo, which is unaffected by the <see cref="Godot.Bone2D"/>'s <see cref="Godot.Node2D.Transform"/>.</para>
    /// </summary>
    public float GetBoneAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
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
        /// Cached name for the 'rest' property.
        /// </summary>
        public static readonly StringName Rest = "rest";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_rest' method.
        /// </summary>
        public static readonly StringName SetRest = "set_rest";
        /// <summary>
        /// Cached name for the 'get_rest' method.
        /// </summary>
        public static readonly StringName GetRest = "get_rest";
        /// <summary>
        /// Cached name for the 'apply_rest' method.
        /// </summary>
        public static readonly StringName ApplyRest = "apply_rest";
        /// <summary>
        /// Cached name for the 'get_skeleton_rest' method.
        /// </summary>
        public static readonly StringName GetSkeletonRest = "get_skeleton_rest";
        /// <summary>
        /// Cached name for the 'get_index_in_skeleton' method.
        /// </summary>
        public static readonly StringName GetIndexInSkeleton = "get_index_in_skeleton";
        /// <summary>
        /// Cached name for the 'set_autocalculate_length_and_angle' method.
        /// </summary>
        public static readonly StringName SetAutocalculateLengthAndAngle = "set_autocalculate_length_and_angle";
        /// <summary>
        /// Cached name for the 'get_autocalculate_length_and_angle' method.
        /// </summary>
        public static readonly StringName GetAutocalculateLengthAndAngle = "get_autocalculate_length_and_angle";
        /// <summary>
        /// Cached name for the 'set_length' method.
        /// </summary>
        public static readonly StringName SetLength = "set_length";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
        /// <summary>
        /// Cached name for the 'set_bone_angle' method.
        /// </summary>
        public static readonly StringName SetBoneAngle = "set_bone_angle";
        /// <summary>
        /// Cached name for the 'get_bone_angle' method.
        /// </summary>
        public static readonly StringName GetBoneAngle = "get_bone_angle";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
