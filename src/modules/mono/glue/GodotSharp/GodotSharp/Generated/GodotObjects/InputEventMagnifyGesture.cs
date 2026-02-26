namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Stores the factor of a magnifying touch gesture. This is usually performed when the user pinches the touch screen and used for zooming in/out.</para>
/// <para><b>Note:</b> On Android, this requires the <c>ProjectSettings.input_devices/pointing/android/enable_pan_and_scale_gestures</c> project setting to be enabled.</para>
/// </summary>
public partial class InputEventMagnifyGesture : InputEventGesture
{
    /// <summary>
    /// <para>The amount (or delta) of the event. This value is closer to <c>1.0</c> the slower the gesture is performed.</para>
    /// </summary>
    public float Factor
    {
        get
        {
            return GetFactor();
        }
        set
        {
            SetFactor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventMagnifyGesture);

    private static readonly StringName NativeName = "InputEventMagnifyGesture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventMagnifyGesture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMagnifyGesture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMagnifyGesture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFactor(float factor)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), factor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFactor, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : InputEventGesture.PropertyName
    {
        /// <summary>
        /// Cached name for the 'factor' property.
        /// </summary>
        public static readonly StringName Factor = "factor";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEventGesture.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_factor' method.
        /// </summary>
        public static readonly StringName SetFactor = "set_factor";
        /// <summary>
        /// Cached name for the 'get_factor' method.
        /// </summary>
        public static readonly StringName GetFactor = "get_factor";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEventGesture.SignalName
    {
    }
}
