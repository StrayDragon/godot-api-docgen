namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class contains a dictionary that uses a list of bone names in <see cref="Godot.SkeletonProfile"/> as key names.</para>
/// <para>By assigning the actual <see cref="Godot.Skeleton3D"/> bone name as the key value, it maps the <see cref="Godot.Skeleton3D"/> to the <see cref="Godot.SkeletonProfile"/>.</para>
/// </summary>
public partial class BoneMap : Resource
{
    /// <summary>
    /// <para>A <see cref="Godot.SkeletonProfile"/> of the mapping target. Key names in the <see cref="Godot.BoneMap"/> are synchronized with it.</para>
    /// </summary>
    public SkeletonProfile Profile
    {
        get
        {
            return GetProfile();
        }
        set
        {
            SetProfile(value);
        }
    }

    private static readonly System.Type CachedType = typeof(BoneMap);

    private static readonly StringName NativeName = "BoneMap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public BoneMap() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal BoneMap(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal BoneMap(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProfile, 4291782652ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkeletonProfile GetProfile()
    {
        return (SkeletonProfile)NativeCalls.godot_icall_0_63(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProfile, 3870374136ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProfile(SkeletonProfile profile)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(profile));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeletonBoneName, 1965194235ul);

    /// <summary>
    /// <para>Returns a skeleton bone name is mapped to <paramref name="profileBoneName"/>.</para>
    /// <para>In the retargeting process, the returned bone name is the bone name of the source skeleton.</para>
    /// </summary>
    public StringName GetSkeletonBoneName(StringName profileBoneName)
    {
        return NativeCalls.godot_icall_1_164(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(profileBoneName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkeletonBoneName, 3740211285ul);

    /// <summary>
    /// <para>Maps a skeleton bone name to <paramref name="profileBoneName"/>.</para>
    /// <para>In the retargeting process, the setting bone name is the bone name of the source skeleton.</para>
    /// </summary>
    public void SetSkeletonBoneName(StringName profileBoneName, StringName skeletonBoneName)
    {
        NativeCalls.godot_icall_2_118(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(profileBoneName?.NativeValue ?? default), (godot_string_name)(skeletonBoneName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindProfileBoneName, 1965194235ul);

    /// <summary>
    /// <para>Returns a profile bone name having <paramref name="skeletonBoneName"/>. If not found, an empty <see cref="Godot.StringName"/> will be returned.</para>
    /// <para>In the retargeting process, the returned bone name is the bone name of the target skeleton.</para>
    /// </summary>
    public StringName FindProfileBoneName(StringName skeletonBoneName)
    {
        return NativeCalls.godot_icall_1_164(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(skeletonBoneName?.NativeValue ?? default));
    }

    /// <summary>
    /// <para>This signal is emitted when change the key value in the <see cref="Godot.BoneMap"/>. This is used to validate mapping and to update <see cref="Godot.BoneMap"/> editor.</para>
    /// </summary>
    public event Action BoneMapUpdated
    {
        add => Connect(SignalName.BoneMapUpdated, Callable.From(value));
        remove => Disconnect(SignalName.BoneMapUpdated, Callable.From(value));
    }

    protected void EmitSignalBoneMapUpdated()
    {
        EmitSignal(SignalName.BoneMapUpdated);
    }

    /// <summary>
    /// <para>This signal is emitted when change the value in profile or change the reference of profile. This is used to update key names in the <see cref="Godot.BoneMap"/> and to redraw the <see cref="Godot.BoneMap"/> editor.</para>
    /// </summary>
    public event Action ProfileUpdated
    {
        add => Connect(SignalName.ProfileUpdated, Callable.From(value));
        remove => Disconnect(SignalName.ProfileUpdated, Callable.From(value));
    }

    protected void EmitSignalProfileUpdated()
    {
        EmitSignal(SignalName.ProfileUpdated);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_bone_map_updated = "BoneMapUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_profile_updated = "ProfileUpdated";

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
        if (signal == SignalName.BoneMapUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_bone_map_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ProfileUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_profile_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'profile' property.
        /// </summary>
        public static readonly StringName Profile = "profile";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_profile' method.
        /// </summary>
        public static readonly StringName GetProfile = "get_profile";
        /// <summary>
        /// Cached name for the 'set_profile' method.
        /// </summary>
        public static readonly StringName SetProfile = "set_profile";
        /// <summary>
        /// Cached name for the 'get_skeleton_bone_name' method.
        /// </summary>
        public static readonly StringName GetSkeletonBoneName = "get_skeleton_bone_name";
        /// <summary>
        /// Cached name for the 'set_skeleton_bone_name' method.
        /// </summary>
        public static readonly StringName SetSkeletonBoneName = "set_skeleton_bone_name";
        /// <summary>
        /// Cached name for the 'find_profile_bone_name' method.
        /// </summary>
        public static readonly StringName FindProfileBoneName = "find_profile_bone_name";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'bone_map_updated' signal.
        /// </summary>
        public static readonly StringName BoneMapUpdated = "bone_map_updated";
        /// <summary>
        /// Cached name for the 'profile_updated' signal.
        /// </summary>
        public static readonly StringName ProfileUpdated = "profile_updated";
    }
}
