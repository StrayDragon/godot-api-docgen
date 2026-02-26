namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node selects a bone in a <see cref="Godot.Skeleton3D"/> and attaches to it. This means that the <see cref="Godot.ModifierBoneTarget3D"/> node will dynamically copy the 3D transform of the selected bone.</para>
/// <para>The functionality is similar to <see cref="Godot.BoneAttachment3D"/>, but this node adopts the <see cref="Godot.SkeletonModifier3D"/> cycle and is intended to be used as another <see cref="Godot.SkeletonModifier3D"/>'s target.</para>
/// </summary>
public partial class ModifierBoneTarget3D : SkeletonModifier3D
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

    private static readonly System.Type CachedType = typeof(ModifierBoneTarget3D);

    private static readonly StringName NativeName = "ModifierBoneTarget3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ModifierBoneTarget3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ModifierBoneTarget3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ModifierBoneTarget3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneName(string boneName)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetBoneName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBone, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBone(int bone)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBone, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBone()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'bone_name' property.
        /// </summary>
        public static readonly StringName BoneName = "bone_name";
        /// <summary>
        /// Cached name for the 'bone' property.
        /// </summary>
        public static readonly StringName Bone = "bone";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
    {
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
