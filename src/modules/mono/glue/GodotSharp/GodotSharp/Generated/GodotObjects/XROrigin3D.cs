namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is a special node within the AR/VR system that maps the physical location of the center of our tracking space to the virtual location within our game world.</para>
/// <para>Multiple origin points can be added to the scene tree, but only one can used at a time. All the <see cref="Godot.XRCamera3D"/>, <see cref="Godot.XRController3D"/>, and <see cref="Godot.XRAnchor3D"/> nodes should be direct children of this node for spatial tracking to work correctly.</para>
/// <para>It is the position of this node that you update when your character needs to move through your game world while we're not moving in the real world. Movement in the real world is always in relation to this origin point.</para>
/// <para>For example, if your character is driving a car, the <see cref="Godot.XROrigin3D"/> node should be a child node of this car. Or, if you're implementing a teleport system to move your character, you should change the position of this node.</para>
/// </summary>
public partial class XROrigin3D : Node3D
{
    /// <summary>
    /// <para>The scale of the game world compared to the real world. This is the same as <see cref="Godot.XRServer.WorldScale"/>. By default, most AR/VR platforms assume that 1 game unit corresponds to 1 real world meter.</para>
    /// </summary>
    public float WorldScale
    {
        get
        {
            return GetWorldScale();
        }
        set
        {
            SetWorldScale(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this origin node is currently being used by the <see cref="Godot.XRServer"/>. Only one origin point can be used at a time.</para>
    /// </summary>
    public bool Current
    {
        get
        {
            return IsCurrent();
        }
        set
        {
            SetCurrent(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XROrigin3D);

    private static readonly StringName NativeName = "XROrigin3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XROrigin3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal XROrigin3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XROrigin3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWorldScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWorldScale(float worldScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), worldScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorldScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWorldScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrent, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrent(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCurrent, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCurrent()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'world_scale' property.
        /// </summary>
        public static readonly StringName WorldScale = "world_scale";
        /// <summary>
        /// Cached name for the 'current' property.
        /// </summary>
        public static readonly StringName Current = "current";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_world_scale' method.
        /// </summary>
        public static readonly StringName SetWorldScale = "set_world_scale";
        /// <summary>
        /// Cached name for the 'get_world_scale' method.
        /// </summary>
        public static readonly StringName GetWorldScale = "get_world_scale";
        /// <summary>
        /// Cached name for the 'set_current' method.
        /// </summary>
        public static readonly StringName SetCurrent = "set_current";
        /// <summary>
        /// Cached name for the 'is_current' method.
        /// </summary>
        public static readonly StringName IsCurrent = "is_current";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
