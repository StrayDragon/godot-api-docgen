namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Can have <see cref="Godot.PathFollow3D"/> child nodes moving along the <see cref="Godot.Curve3D"/>. See <see cref="Godot.PathFollow3D"/> for more information on the usage.</para>
/// <para>Note that the path is considered as relative to the moved nodes (children of <see cref="Godot.PathFollow3D"/>). As such, the curve should usually start with a zero vector <c>(0, 0, 0)</c>.</para>
/// </summary>
public partial class Path3D : Node3D
{
    /// <summary>
    /// <para>A <see cref="Godot.Curve3D"/> describing the path.</para>
    /// </summary>
    public Curve3D Curve
    {
        get
        {
            return GetCurve();
        }
        set
        {
            SetCurve(value);
        }
    }

    /// <summary>
    /// <para>The custom color used to draw the path in the editor. If set to <c>Color.BLACK</c> (as by default), the color set in <c>ProjectSettings.debug/shapes/paths/geometry_color</c> is used.</para>
    /// </summary>
    public Color DebugCustomColor
    {
        get
        {
            return GetDebugCustomColor();
        }
        set
        {
            SetDebugCustomColor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Path3D);

    private static readonly StringName NativeName = "Path3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Path3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Path3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Path3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurve, 408955118ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurve(Curve3D curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurve, 4244715212ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve3D GetCurve()
    {
        return (Curve3D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugCustomColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDebugCustomColor(Color debugCustomColor)
    {
        NativeCalls.godot_icall_1_213(MethodBind2, GodotObject.GetPtr(this), &debugCustomColor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDebugCustomColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetDebugCustomColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind3, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Path3D.Curve"/> changes.</para>
    /// </summary>
    public event Action CurveChanged
    {
        add => Connect(SignalName.CurveChanged, Callable.From(value));
        remove => Disconnect(SignalName.CurveChanged, Callable.From(value));
    }

    protected void EmitSignalCurveChanged()
    {
        EmitSignal(SignalName.CurveChanged);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Path3D.DebugCustomColor"/> changes.</para>
    /// </summary>
    public event Action DebugColorChanged
    {
        add => Connect(SignalName.DebugColorChanged, Callable.From(value));
        remove => Disconnect(SignalName.DebugColorChanged, Callable.From(value));
    }

    protected void EmitSignalDebugColorChanged()
    {
        EmitSignal(SignalName.DebugColorChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_curve_changed = "CurveChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_debug_color_changed = "DebugColorChanged";

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
        if (signal == SignalName.CurveChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_curve_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DebugColorChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_debug_color_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'curve' property.
        /// </summary>
        public static readonly StringName Curve = "curve";
        /// <summary>
        /// Cached name for the 'debug_custom_color' property.
        /// </summary>
        public static readonly StringName DebugCustomColor = "debug_custom_color";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_curve' method.
        /// </summary>
        public static readonly StringName SetCurve = "set_curve";
        /// <summary>
        /// Cached name for the 'get_curve' method.
        /// </summary>
        public static readonly StringName GetCurve = "get_curve";
        /// <summary>
        /// Cached name for the 'set_debug_custom_color' method.
        /// </summary>
        public static readonly StringName SetDebugCustomColor = "set_debug_custom_color";
        /// <summary>
        /// Cached name for the 'get_debug_custom_color' method.
        /// </summary>
        public static readonly StringName GetDebugCustomColor = "get_debug_custom_color";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'curve_changed' signal.
        /// </summary>
        public static readonly StringName CurveChanged = "curve_changed";
        /// <summary>
        /// Cached name for the 'debug_color_changed' signal.
        /// </summary>
        public static readonly StringName DebugColorChanged = "debug_color_changed";
    }
}
