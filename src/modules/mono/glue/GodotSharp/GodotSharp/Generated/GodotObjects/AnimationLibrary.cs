namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An animation library stores a set of animations accessible through <see cref="Godot.StringName"/> keys, for use with <see cref="Godot.AnimationPlayer"/> nodes.</para>
/// </summary>
public partial class AnimationLibrary : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary _Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(AnimationLibrary);

    private static readonly StringName NativeName = "AnimationLibrary";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationLibrary() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationLibrary(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationLibrary(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAnimation, 1811855551ul);

    /// <summary>
    /// <para>Adds the <paramref name="animation"/> to the library, accessible by the key <paramref name="name"/>.</para>
    /// </summary>
    public Error AddAnimation(StringName name, Animation animation)
    {
        return (Error)NativeCalls.godot_icall_2_117(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(animation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAnimation, 3304788590ul);

    /// <summary>
    /// <para>Removes the <see cref="Godot.Animation"/> with the key <paramref name="name"/>.</para>
    /// </summary>
    public void RemoveAnimation(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenameAnimation, 3740211285ul);

    /// <summary>
    /// <para>Changes the key of the <see cref="Godot.Animation"/> associated with the key <paramref name="name"/> to <paramref name="newname"/>.</para>
    /// </summary>
    public void RenameAnimation(StringName name, StringName newname)
    {
        NativeCalls.godot_icall_2_118(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(newname?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAnimation, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the library stores an <see cref="Godot.Animation"/> with <paramref name="name"/> as the key.</para>
    /// </summary>
    public bool HasAnimation(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimation, 2933122410ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Animation"/> with the key <paramref name="name"/>. If the animation does not exist, <see langword="null"/> is returned and an error is logged.</para>
    /// </summary>
    public Animation GetAnimation(StringName name)
    {
        return (Animation)NativeCalls.godot_icall_1_119(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationList, 3995934104ul);

    /// <summary>
    /// <para>Returns the keys for the <see cref="Godot.Animation"/>s stored in the library.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetAnimationList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationListSize, 3905245786ul);

    /// <summary>
    /// <para>Returns the key count for the <see cref="Godot.Animation"/>s stored in the library.</para>
    /// </summary>
    public int GetAnimationListSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 4155329257ul);

    internal void _SetData(Godot.Collections.Dictionary data)
    {
        NativeCalls.godot_icall_1_121(MethodBind7, GodotObject.GetPtr(this), (godot_dictionary)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3102165223ul);

    internal Godot.Collections.Dictionary _GetData()
    {
        return NativeCalls.godot_icall_0_122(MethodBind8, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationLibrary.AnimationAdded"/> event of a <see cref="Godot.AnimationLibrary"/> class.
    /// </summary>
    public delegate void AnimationAddedEventHandler(StringName name);

    private static void AnimationAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((AnimationAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an <see cref="Godot.Animation"/> is added, under the key <c>name</c>.</para>
    /// </summary>
    public unsafe event AnimationAddedEventHandler AnimationAdded
    {
        add => Connect(SignalName.AnimationAdded, Callable.CreateWithUnsafeTrampoline(value, &AnimationAddedTrampoline));
        remove => Disconnect(SignalName.AnimationAdded, Callable.CreateWithUnsafeTrampoline(value, &AnimationAddedTrampoline));
    }

    protected void EmitSignalAnimationAdded(StringName name)
    {
        EmitSignal(SignalName.AnimationAdded, name);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationLibrary.AnimationRemoved"/> event of a <see cref="Godot.AnimationLibrary"/> class.
    /// </summary>
    public delegate void AnimationRemovedEventHandler(StringName name);

    private static void AnimationRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((AnimationRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an <see cref="Godot.Animation"/> stored with the key <c>name</c> is removed.</para>
    /// </summary>
    public unsafe event AnimationRemovedEventHandler AnimationRemoved
    {
        add => Connect(SignalName.AnimationRemoved, Callable.CreateWithUnsafeTrampoline(value, &AnimationRemovedTrampoline));
        remove => Disconnect(SignalName.AnimationRemoved, Callable.CreateWithUnsafeTrampoline(value, &AnimationRemovedTrampoline));
    }

    protected void EmitSignalAnimationRemoved(StringName name)
    {
        EmitSignal(SignalName.AnimationRemoved, name);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationLibrary.AnimationRenamed"/> event of a <see cref="Godot.AnimationLibrary"/> class.
    /// </summary>
    public delegate void AnimationRenamedEventHandler(StringName name, StringName toName);

    private static void AnimationRenamedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((AnimationRenamedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the key for an <see cref="Godot.Animation"/> is changed, from <c>name</c> to <c>toName</c>.</para>
    /// </summary>
    public unsafe event AnimationRenamedEventHandler AnimationRenamed
    {
        add => Connect(SignalName.AnimationRenamed, Callable.CreateWithUnsafeTrampoline(value, &AnimationRenamedTrampoline));
        remove => Disconnect(SignalName.AnimationRenamed, Callable.CreateWithUnsafeTrampoline(value, &AnimationRenamedTrampoline));
    }

    protected void EmitSignalAnimationRenamed(StringName name, StringName toName)
    {
        EmitSignal(SignalName.AnimationRenamed, name, toName);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationLibrary.AnimationChanged"/> event of a <see cref="Godot.AnimationLibrary"/> class.
    /// </summary>
    public delegate void AnimationChangedEventHandler(StringName name);

    private static void AnimationChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((AnimationChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when there's a change in one of the animations, e.g. tracks are added, moved or have changed paths. <c>name</c> is the key of the animation that was changed.</para>
    /// <para>See also <see cref="Godot.Resource.Changed"/>, which this acts as a relay for.</para>
    /// </summary>
    public unsafe event AnimationChangedEventHandler AnimationChanged
    {
        add => Connect(SignalName.AnimationChanged, Callable.CreateWithUnsafeTrampoline(value, &AnimationChangedTrampoline));
        remove => Disconnect(SignalName.AnimationChanged, Callable.CreateWithUnsafeTrampoline(value, &AnimationChangedTrampoline));
    }

    protected void EmitSignalAnimationChanged(StringName name)
    {
        EmitSignal(SignalName.AnimationChanged, name);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_added = "AnimationAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_removed = "AnimationRemoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_renamed = "AnimationRenamed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_changed = "AnimationChanged";

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
        if (signal == SignalName.AnimationAdded)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_added.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationRenamed)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_renamed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_changed.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_data' property.
        /// </summary>
        public static readonly StringName _Data = "_data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_animation' method.
        /// </summary>
        public static readonly StringName AddAnimation = "add_animation";
        /// <summary>
        /// Cached name for the 'remove_animation' method.
        /// </summary>
        public static readonly StringName RemoveAnimation = "remove_animation";
        /// <summary>
        /// Cached name for the 'rename_animation' method.
        /// </summary>
        public static readonly StringName RenameAnimation = "rename_animation";
        /// <summary>
        /// Cached name for the 'has_animation' method.
        /// </summary>
        public static readonly StringName HasAnimation = "has_animation";
        /// <summary>
        /// Cached name for the 'get_animation' method.
        /// </summary>
        public static readonly StringName GetAnimation = "get_animation";
        /// <summary>
        /// Cached name for the 'get_animation_list' method.
        /// </summary>
        public static readonly StringName GetAnimationList = "get_animation_list";
        /// <summary>
        /// Cached name for the 'get_animation_list_size' method.
        /// </summary>
        public static readonly StringName GetAnimationListSize = "get_animation_list_size";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'animation_added' signal.
        /// </summary>
        public static readonly StringName AnimationAdded = "animation_added";
        /// <summary>
        /// Cached name for the 'animation_removed' signal.
        /// </summary>
        public static readonly StringName AnimationRemoved = "animation_removed";
        /// <summary>
        /// Cached name for the 'animation_renamed' signal.
        /// </summary>
        public static readonly StringName AnimationRenamed = "animation_renamed";
        /// <summary>
        /// Cached name for the 'animation_changed' signal.
        /// </summary>
        public static readonly StringName AnimationChanged = "animation_changed";
    }
}
