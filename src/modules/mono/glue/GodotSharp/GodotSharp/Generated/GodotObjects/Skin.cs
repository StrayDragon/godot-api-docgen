namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class Skin : Resource
{
    private static readonly System.Type CachedType = typeof(Skin);

    private static readonly StringName NativeName = "Skin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Skin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Skin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Skin(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBindCount, 1286410249ul);

    public void SetBindCount(int bindCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), bindCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindCount, 3905245786ul);

    public int GetBindCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBind, 3616898986ul);

    public unsafe void AddBind(int bone, Transform3D pose)
    {
        NativeCalls.godot_icall_2_800(MethodBind2, GodotObject.GetPtr(this), bone, &pose);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddNamedBind, 3154712474ul);

    public unsafe void AddNamedBind(string name, Transform3D pose)
    {
        NativeCalls.godot_icall_2_1274(MethodBind3, GodotObject.GetPtr(this), name, &pose);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBindPose, 3616898986ul);

    public unsafe void SetBindPose(int bindIndex, Transform3D pose)
    {
        NativeCalls.godot_icall_2_800(MethodBind4, GodotObject.GetPtr(this), bindIndex, &pose);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindPose, 1965739696ul);

    public Transform3D GetBindPose(int bindIndex)
    {
        return NativeCalls.godot_icall_1_803(MethodBind5, GodotObject.GetPtr(this), bindIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBindName, 3780747571ul);

    public void SetBindName(int bindIndex, StringName name)
    {
        NativeCalls.godot_icall_2_178(MethodBind6, GodotObject.GetPtr(this), bindIndex, (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindName, 659327637ul);

    public StringName GetBindName(int bindIndex)
    {
        return NativeCalls.godot_icall_1_162(MethodBind7, GodotObject.GetPtr(this), bindIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBindBone, 3937882851ul);

    public void SetBindBone(int bindIndex, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind8, GodotObject.GetPtr(this), bindIndex, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindBone, 923996154ul);

    public int GetBindBone(int bindIndex)
    {
        return NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), bindIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBinds, 3218959716ul);

    public void ClearBinds()
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
    public new class PropertyName : Resource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bind_count' method.
        /// </summary>
        public static readonly StringName SetBindCount = "set_bind_count";
        /// <summary>
        /// Cached name for the 'get_bind_count' method.
        /// </summary>
        public static readonly StringName GetBindCount = "get_bind_count";
        /// <summary>
        /// Cached name for the 'add_bind' method.
        /// </summary>
        public static readonly StringName AddBind = "add_bind";
        /// <summary>
        /// Cached name for the 'add_named_bind' method.
        /// </summary>
        public static readonly StringName AddNamedBind = "add_named_bind";
        /// <summary>
        /// Cached name for the 'set_bind_pose' method.
        /// </summary>
        public static readonly StringName SetBindPose = "set_bind_pose";
        /// <summary>
        /// Cached name for the 'get_bind_pose' method.
        /// </summary>
        public static readonly StringName GetBindPose = "get_bind_pose";
        /// <summary>
        /// Cached name for the 'set_bind_name' method.
        /// </summary>
        public static readonly StringName SetBindName = "set_bind_name";
        /// <summary>
        /// Cached name for the 'get_bind_name' method.
        /// </summary>
        public static readonly StringName GetBindName = "get_bind_name";
        /// <summary>
        /// Cached name for the 'set_bind_bone' method.
        /// </summary>
        public static readonly StringName SetBindBone = "set_bind_bone";
        /// <summary>
        /// Cached name for the 'get_bind_bone' method.
        /// </summary>
        public static readonly StringName GetBindBone = "get_bind_bone";
        /// <summary>
        /// Cached name for the 'clear_binds' method.
        /// </summary>
        public static readonly StringName ClearBinds = "clear_binds";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
