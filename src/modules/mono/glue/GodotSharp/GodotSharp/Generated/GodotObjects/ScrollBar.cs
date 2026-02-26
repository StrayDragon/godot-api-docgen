namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class for scrollbars, typically used to navigate through content that extends beyond the visible area of a control. Scrollbars are <see cref="Godot.Range"/>-based controls.</para>
/// </summary>
public partial class ScrollBar : Range
{
    /// <summary>
    /// <para>Overrides the step used when clicking increment and decrement buttons or when using arrow keys when the <see cref="Godot.ScrollBar"/> is focused.</para>
    /// </summary>
    public float CustomStep
    {
        get
        {
            return GetCustomStep();
        }
        set
        {
            SetCustomStep(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ScrollBar);

    private static readonly StringName NativeName = "ScrollBar";

    internal ScrollBar() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScrollBar(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScrollBar(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomStep(float step)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), step);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCustomStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the scrollbar is being scrolled.</para>
    /// </summary>
    public event Action Scrolling
    {
        add => Connect(SignalName.Scrolling, Callable.From(value));
        remove => Disconnect(SignalName.Scrolling, Callable.From(value));
    }

    protected void EmitSignalScrolling()
    {
        EmitSignal(SignalName.Scrolling);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scrolling = "Scrolling";

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
        if (signal == SignalName.Scrolling)
        {
            if (HasGodotClassSignal(SignalProxyName_scrolling.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Range.PropertyName
    {
        /// <summary>
        /// Cached name for the 'custom_step' property.
        /// </summary>
        public static readonly StringName CustomStep = "custom_step";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Range.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_custom_step' method.
        /// </summary>
        public static readonly StringName SetCustomStep = "set_custom_step";
        /// <summary>
        /// Cached name for the 'get_custom_step' method.
        /// </summary>
        public static readonly StringName GetCustomStep = "get_custom_step";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Range.SignalName
    {
        /// <summary>
        /// Cached name for the 'scrolling' signal.
        /// </summary>
        public static readonly StringName Scrolling = "scrolling";
    }
}
