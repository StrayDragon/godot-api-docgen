namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A collision can be a child of <see cref="Godot.SpringBoneSimulator3D"/>. If it is not a child of <see cref="Godot.SpringBoneSimulator3D"/>, it has no effect.</para>
/// <para>The colliding and sliding are done in the <see cref="Godot.SpringBoneSimulator3D"/>'s modification process in order of its collision list which is set by <see cref="Godot.SpringBoneSimulator3D.SetCollisionPath(int, int, NodePath)"/>. If <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="true"/>, the order matches <see cref="Godot.SceneTree"/>.</para>
/// <para>If <see cref="Godot.SpringBoneCollision3D.Bone"/> is set, it synchronizes with the bone pose of the ancestor <see cref="Godot.Skeleton3D"/>, which is done in before the <see cref="Godot.SpringBoneSimulator3D"/>'s modification process as the pre-process.</para>
/// <para><b>Warning:</b> A scaled <see cref="Godot.SpringBoneCollision3D"/> will likely not behave as expected. Make sure that the parent <see cref="Godot.Skeleton3D"/> and its bones are not scaled.</para>
/// </summary>
public partial class SpringBoneCollision3D : Node3D
{
    /// <summary>
    /// <para>The name of the attached bone.</para>
    /// </summary>
    public string BoneName
    {
        get
        {
            return GetBoneName();
        }
        set
        {
            SetBoneName(value);
        }
    }

    /// <summary>
    /// <para>The index of the attached bone.</para>
    /// </summary>
    public int Bone
    {
        get
        {
            return GetBone();
        }
        set
        {
            SetBone(value);
        }
    }

    /// <summary>
    /// <para>The offset of the position from <see cref="Godot.Skeleton3D"/>'s <see cref="Godot.SpringBoneCollision3D.Bone"/> pose position.</para>
    /// </summary>
    public Vector3 PositionOffset
    {
        get
        {
            return GetPositionOffset();
        }
        set
        {
            SetPositionOffset(value);
        }
    }

    /// <summary>
    /// <para>The offset of the rotation from <see cref="Godot.Skeleton3D"/>'s <see cref="Godot.SpringBoneCollision3D.Bone"/> pose rotation.</para>
    /// </summary>
    public Quaternion RotationOffset
    {
        get
        {
            return GetRotationOffset();
        }
        set
        {
            SetRotationOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SpringBoneCollision3D);

    private static readonly StringName NativeName = "SpringBoneCollision3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SpringBoneCollision3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpringBoneCollision3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpringBoneCollision3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeleton, 1488626673ul);

    /// <summary>
    /// <para>Get parent <see cref="Godot.Skeleton3D"/> node of the parent <see cref="Godot.SpringBoneSimulator3D"/> if found.</para>
    /// </summary>
    public Skeleton3D GetSkeleton()
    {
        return (Skeleton3D)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneName(string boneName)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetBoneName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBone, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBone(int bone)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBone, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBone()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionOffset, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPositionOffset(Vector3 offset)
    {
        NativeCalls.godot_icall_1_177(MethodBind5, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionOffset, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetPositionOffset()
    {
        return NativeCalls.godot_icall_0_125(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationOffset, 1727505552ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRotationOffset(Quaternion offset)
    {
        NativeCalls.godot_icall_1_649(MethodBind7, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationOffset, 1222331677ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quaternion GetRotationOffset()
    {
        return NativeCalls.godot_icall_0_126(MethodBind8, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'bone_name' property.
        /// </summary>
        public static readonly StringName BoneName = "bone_name";
        /// <summary>
        /// Cached name for the 'bone' property.
        /// </summary>
        public static readonly StringName Bone = "bone";
        /// <summary>
        /// Cached name for the 'position_offset' property.
        /// </summary>
        public static readonly StringName PositionOffset = "position_offset";
        /// <summary>
        /// Cached name for the 'rotation_offset' property.
        /// </summary>
        public static readonly StringName RotationOffset = "rotation_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_skeleton' method.
        /// </summary>
        public static readonly StringName GetSkeleton = "get_skeleton";
        /// <summary>
        /// Cached name for the 'set_bone_name' method.
        /// </summary>
        public static readonly StringName SetBoneName = "set_bone_name";
        /// <summary>
        /// Cached name for the 'get_bone_name' method.
        /// </summary>
        public static readonly StringName GetBoneName = "get_bone_name";
        /// <summary>
        /// Cached name for the 'set_bone' method.
        /// </summary>
        public static readonly StringName SetBone = "set_bone";
        /// <summary>
        /// Cached name for the 'get_bone' method.
        /// </summary>
        public static readonly StringName GetBone = "get_bone";
        /// <summary>
        /// Cached name for the 'set_position_offset' method.
        /// </summary>
        public static readonly StringName SetPositionOffset = "set_position_offset";
        /// <summary>
        /// Cached name for the 'get_position_offset' method.
        /// </summary>
        public static readonly StringName GetPositionOffset = "get_position_offset";
        /// <summary>
        /// Cached name for the 'set_rotation_offset' method.
        /// </summary>
        public static readonly StringName SetRotationOffset = "set_rotation_offset";
        /// <summary>
        /// Cached name for the 'get_rotation_offset' method.
        /// </summary>
        public static readonly StringName GetRotationOffset = "get_rotation_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
