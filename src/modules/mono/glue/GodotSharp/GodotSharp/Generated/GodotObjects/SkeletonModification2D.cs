namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource provides an interface that can be expanded so code that operates on <see cref="Godot.Bone2D"/> nodes in a <see cref="Godot.Skeleton2D"/> can be mixed and matched together to create complex interactions.</para>
/// <para>This is used to provide Godot with a flexible and powerful Inverse Kinematics solution that can be adapted for many different uses.</para>
/// </summary>
public partial class SkeletonModification2D : Resource
{
    /// <summary>
    /// <para>If <see langword="true"/>, the modification's <see cref="Godot.SkeletonModification2D._Execute(double)"/> function will be called by the <see cref="Godot.SkeletonModificationStack2D"/>.</para>
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
    /// <para>The execution mode for the modification. This tells the modification stack when to execute the modification. Some modifications have settings that are only available in certain execution modes.</para>
    /// </summary>
    public int ExecutionMode
    {
        get
        {
            return GetExecutionMode();
        }
        set
        {
            SetExecutionMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonModification2D);

    private static readonly StringName NativeName = "SkeletonModification2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2D(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Used for drawing <b>editor-only</b> modification gizmos. This function will only be called in the Godot editor and can be overridden to draw custom gizmos.</para>
    /// <para><b>Note:</b> You will need to use the Skeleton2D from <see cref="Godot.SkeletonModificationStack2D.GetSkeleton()"/> and it's draw functions, as the <see cref="Godot.SkeletonModification2D"/> resource cannot draw on its own.</para>
    /// </summary>
    public virtual void _DrawEditorGizmo()
    {
    }

    /// <summary>
    /// <para>Executes the given modification. This is where the modification performs whatever function it is designed to do.</para>
    /// </summary>
    public virtual void _Execute(double delta)
    {
    }

    /// <summary>
    /// <para>Called when the modification is setup. This is where the modification performs initialization.</para>
    /// </summary>
    public virtual void _SetupModification(SkeletonModificationStack2D modificationStack)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnabled, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModificationStack, 2137761694ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.SkeletonModificationStack2D"/> that this modification is bound to. Through the modification stack, you can access the Skeleton2D the modification is operating on.</para>
    /// </summary>
    public SkeletonModificationStack2D GetModificationStack()
    {
        return (SkeletonModificationStack2D)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIsSetup, 2586408642ul);

    /// <summary>
    /// <para>Manually allows you to set the setup state of the modification. This function should only rarely be used, as the <see cref="Godot.SkeletonModificationStack2D"/> the modification is bound to should handle setting the modification up.</para>
    /// </summary>
    public void SetIsSetup(bool isSetup)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), isSetup.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIsSetup, 36873697ul);

    /// <summary>
    /// <para>Returns whether this modification has been successfully setup or not.</para>
    /// </summary>
    public bool GetIsSetup()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExecutionMode, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExecutionMode(int executionMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), executionMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExecutionMode, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetExecutionMode()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClampAngle, 1229502682ul);

    /// <summary>
    /// <para>Takes an angle and clamps it so it is within the passed-in <paramref name="min"/> and <paramref name="max"/> range. <paramref name="invert"/> will inversely clamp the angle, clamping it to the range outside of the given bounds.</para>
    /// </summary>
    public float ClampAngle(float angle, float min, float max, bool invert)
    {
        return NativeCalls.godot_icall_4_1273(MethodBind7, GodotObject.GetPtr(this), angle, min, max, invert.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditorDrawGizmo, 2586408642ul);

    /// <summary>
    /// <para>Sets whether this modification will call <see cref="Godot.SkeletonModification2D._DrawEditorGizmo()"/> in the Godot editor to draw modification-specific gizmos.</para>
    /// </summary>
    public void SetEditorDrawGizmo(bool drawGizmo)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), drawGizmo.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorDrawGizmo, 36873697ul);

    /// <summary>
    /// <para>Returns whether this modification will call <see cref="Godot.SkeletonModification2D._DrawEditorGizmo()"/> in the Godot editor to draw modification-specific gizmos.</para>
    /// </summary>
    public bool GetEditorDrawGizmo()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__draw_editor_gizmo = "_DrawEditorGizmo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__execute = "_Execute";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__setup_modification = "_SetupModification";

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
        if ((method == MethodProxyName__draw_editor_gizmo || method == MethodName._DrawEditorGizmo) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__draw_editor_gizmo.NativeValue))
        {
            _DrawEditorGizmo();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__execute || method == MethodName._Execute) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__execute.NativeValue))
        {
            _Execute(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__setup_modification || method == MethodName._SetupModification) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__setup_modification.NativeValue))
        {
            _SetupModification(VariantUtils.ConvertTo<SkeletonModificationStack2D>(args[0]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._DrawEditorGizmo)
        {
            if (HasGodotClassMethod(MethodProxyName__draw_editor_gizmo.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Execute)
        {
            if (HasGodotClassMethod(MethodProxyName__execute.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetupModification)
        {
            if (HasGodotClassMethod(MethodProxyName__setup_modification.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'execution_mode' property.
        /// </summary>
        public static readonly StringName ExecutionMode = "execution_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_draw_editor_gizmo' method.
        /// </summary>
        public static readonly StringName _DrawEditorGizmo = "_draw_editor_gizmo";
        /// <summary>
        /// Cached name for the '_execute' method.
        /// </summary>
        public static readonly StringName _Execute = "_execute";
        /// <summary>
        /// Cached name for the '_setup_modification' method.
        /// </summary>
        public static readonly StringName _SetupModification = "_setup_modification";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'get_enabled' method.
        /// </summary>
        public static readonly StringName GetEnabled = "get_enabled";
        /// <summary>
        /// Cached name for the 'get_modification_stack' method.
        /// </summary>
        public static readonly StringName GetModificationStack = "get_modification_stack";
        /// <summary>
        /// Cached name for the 'set_is_setup' method.
        /// </summary>
        public static readonly StringName SetIsSetup = "set_is_setup";
        /// <summary>
        /// Cached name for the 'get_is_setup' method.
        /// </summary>
        public static readonly StringName GetIsSetup = "get_is_setup";
        /// <summary>
        /// Cached name for the 'set_execution_mode' method.
        /// </summary>
        public static readonly StringName SetExecutionMode = "set_execution_mode";
        /// <summary>
        /// Cached name for the 'get_execution_mode' method.
        /// </summary>
        public static readonly StringName GetExecutionMode = "get_execution_mode";
        /// <summary>
        /// Cached name for the 'clamp_angle' method.
        /// </summary>
        public static readonly StringName ClampAngle = "clamp_angle";
        /// <summary>
        /// Cached name for the 'set_editor_draw_gizmo' method.
        /// </summary>
        public static readonly StringName SetEditorDrawGizmo = "set_editor_draw_gizmo";
        /// <summary>
        /// Cached name for the 'get_editor_draw_gizmo' method.
        /// </summary>
        public static readonly StringName GetEditorDrawGizmo = "get_editor_draw_gizmo";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
