namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource is used by the Skeleton and holds a stack of <see cref="Godot.SkeletonModification2D"/>s.</para>
/// <para>This controls the order of the modifications and how they are applied. Modification order is especially important for full-body IK setups, as you need to execute the modifications in the correct order to get the desired results. For example, you want to execute a modification on the spine <i>before</i> the arms on a humanoid skeleton.</para>
/// <para>This resource also controls how strongly all of the modifications are applied to the <see cref="Godot.Skeleton2D"/>.</para>
/// </summary>
public partial class SkeletonModificationStack2D : Resource
{
    /// <summary>
    /// <para>If <see langword="true"/>, the modification's in the stack will be called. This is handled automatically through the <see cref="Godot.Skeleton2D"/> node.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return GetEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>The interpolation strength of the modifications in stack. A value of <c>0</c> will make it where the modifications are not applied, a strength of <c>0.5</c> will be half applied, and a strength of <c>1</c> will allow the modifications to be fully applied and override the <see cref="Godot.Skeleton2D"/> <see cref="Godot.Bone2D"/> poses.</para>
    /// </summary>
    public float Strength
    {
        get
        {
            return GetStrength();
        }
        set
        {
            SetStrength(value);
        }
    }

    /// <summary>
    /// <para>The number of modifications in the stack.</para>
    /// </summary>
    public int ModificationCount
    {
        get
        {
            return GetModificationCount();
        }
        set
        {
            SetModificationCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonModificationStack2D);

    private static readonly StringName NativeName = "SkeletonModificationStack2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModificationStack2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModificationStack2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModificationStack2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Setup, 3218959716ul);

    /// <summary>
    /// <para>Sets up the modification stack so it can execute. This function should be called by <see cref="Godot.Skeleton2D"/> and shouldn't be manually called unless you know what you are doing.</para>
    /// </summary>
    public void Setup()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Execute, 1005356550ul);

    /// <summary>
    /// <para>Executes all of the <see cref="Godot.SkeletonModification2D"/>s in the stack that use the same execution mode as the passed-in <paramref name="executionMode"/>, starting from index <c>0</c> to <see cref="Godot.SkeletonModificationStack2D.ModificationCount"/>.</para>
    /// <para><b>Note:</b> The order of the modifications can matter depending on the modifications. For example, modifications on a spine should operate before modifications on the arms in order to get proper results.</para>
    /// </summary>
    public void Execute(float delta, int executionMode)
    {
        NativeCalls.godot_icall_2_1268(MethodBind1, GodotObject.GetPtr(this), delta, executionMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnableAllModifications, 2586408642ul);

    /// <summary>
    /// <para>Enables all <see cref="Godot.SkeletonModification2D"/>s in the stack.</para>
    /// </summary>
    public void EnableAllModifications(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModification, 2570274329ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.SkeletonModification2D"/> at the passed-in index, <paramref name="modIdx"/>.</para>
    /// </summary>
    public SkeletonModification2D GetModification(int modIdx)
    {
        return (SkeletonModification2D)NativeCalls.godot_icall_1_71(MethodBind3, GodotObject.GetPtr(this), modIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddModification, 354162120ul);

    /// <summary>
    /// <para>Adds the passed-in <see cref="Godot.SkeletonModification2D"/> to the stack.</para>
    /// </summary>
    public void AddModification(SkeletonModification2D modification)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(modification));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeleteModification, 1286410249ul);

    /// <summary>
    /// <para>Deletes the <see cref="Godot.SkeletonModification2D"/> at the index position <paramref name="modIdx"/>, if it exists.</para>
    /// </summary>
    public void DeleteModification(int modIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), modIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModification, 1098262544ul);

    /// <summary>
    /// <para>Sets the modification at <paramref name="modIdx"/> to the passed-in modification, <paramref name="modification"/>.</para>
    /// </summary>
    public void SetModification(int modIdx, SkeletonModification2D modification)
    {
        NativeCalls.godot_icall_2_70(MethodBind6, GodotObject.GetPtr(this), modIdx, GodotObject.GetPtr(modification));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModificationCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetModificationCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModificationCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetModificationCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIsSetup, 36873697ul);

    /// <summary>
    /// <para>Returns a boolean that indicates whether the modification stack is setup and can execute.</para>
    /// </summary>
    public bool GetIsSetup()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeleton, 1697361217ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Skeleton2D"/> node that the SkeletonModificationStack2D is bound to.</para>
    /// </summary>
    public Skeleton2D GetSkeleton()
    {
        return (Skeleton2D)NativeCalls.godot_icall_0_53(MethodBind14, GodotObject.GetPtr(this));
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
        /// <summary>
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'strength' property.
        /// </summary>
        public static readonly StringName Strength = "strength";
        /// <summary>
        /// Cached name for the 'modification_count' property.
        /// </summary>
        public static readonly StringName ModificationCount = "modification_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'setup' method.
        /// </summary>
        public static readonly StringName Setup = "setup";
        /// <summary>
        /// Cached name for the 'execute' method.
        /// </summary>
        public static readonly StringName Execute = "execute";
        /// <summary>
        /// Cached name for the 'enable_all_modifications' method.
        /// </summary>
        public static readonly StringName EnableAllModifications = "enable_all_modifications";
        /// <summary>
        /// Cached name for the 'get_modification' method.
        /// </summary>
        public static readonly StringName GetModification = "get_modification";
        /// <summary>
        /// Cached name for the 'add_modification' method.
        /// </summary>
        public static readonly StringName AddModification = "add_modification";
        /// <summary>
        /// Cached name for the 'delete_modification' method.
        /// </summary>
        public static readonly StringName DeleteModification = "delete_modification";
        /// <summary>
        /// Cached name for the 'set_modification' method.
        /// </summary>
        public static readonly StringName SetModification = "set_modification";
        /// <summary>
        /// Cached name for the 'set_modification_count' method.
        /// </summary>
        public static readonly StringName SetModificationCount = "set_modification_count";
        /// <summary>
        /// Cached name for the 'get_modification_count' method.
        /// </summary>
        public static readonly StringName GetModificationCount = "get_modification_count";
        /// <summary>
        /// Cached name for the 'get_is_setup' method.
        /// </summary>
        public static readonly StringName GetIsSetup = "get_is_setup";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'get_enabled' method.
        /// </summary>
        public static readonly StringName GetEnabled = "get_enabled";
        /// <summary>
        /// Cached name for the 'set_strength' method.
        /// </summary>
        public static readonly StringName SetStrength = "set_strength";
        /// <summary>
        /// Cached name for the 'get_strength' method.
        /// </summary>
        public static readonly StringName GetStrength = "get_strength";
        /// <summary>
        /// Cached name for the 'get_skeleton' method.
        /// </summary>
        public static readonly StringName GetSkeleton = "get_skeleton";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
