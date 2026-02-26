namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A one-shot timer managed by the scene tree, which emits <see cref="Godot.SceneTreeTimer.Timeout"/> on completion. See also <see cref="Godot.SceneTree.CreateTimer(double, bool, bool, bool)"/>.</para>
/// <para>As opposed to <see cref="Godot.Timer"/>, it does not require the instantiation of a node. Commonly used to create a one-shot delay timer as in the following example:</para>
/// <para><code>
/// public async Task SomeFunction()
/// {
/// 	GD.Print("Timer started.");
/// 	await ToSignal(GetTree().CreateTimer(1.0f), SceneTreeTimer.SignalName.Timeout);
/// 	GD.Print("Timer ended.");
/// }
/// </code></para>
/// <para>The timer will be dereferenced after its time elapses. To preserve the timer, you can keep a reference to it. See <see cref="Godot.RefCounted"/>.</para>
/// <para><b>Note:</b> The timer is processed after all of the nodes in the current frame, i.e. node's <see cref="Godot.Node._Process(double)"/> method would be called before the timer (or <see cref="Godot.Node._PhysicsProcess(double)"/> if <c>process_in_physics</c> in <see cref="Godot.SceneTree.CreateTimer(double, bool, bool, bool)"/> has been set to <see langword="true"/>).</para>
/// </summary>
public partial class SceneTreeTimer : RefCounted
{
    /// <summary>
    /// <para>The time remaining (in seconds).</para>
    /// </summary>
    public double TimeLeft
    {
        get
        {
            return GetTimeLeft();
        }
        set
        {
            SetTimeLeft(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SceneTreeTimer);

    private static readonly StringName NativeName = "SceneTreeTimer";

    internal SceneTreeTimer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneTreeTimer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneTreeTimer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTimeLeft, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTimeLeft(double time)
    {
        NativeCalls.godot_icall_1_127(MethodBind0, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeLeft, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetTimeLeft()
    {
        return NativeCalls.godot_icall_0_144(MethodBind1, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the timer reaches 0.</para>
    /// </summary>
    public event Action Timeout
    {
        add => Connect(SignalName.Timeout, Callable.From(value));
        remove => Disconnect(SignalName.Timeout, Callable.From(value));
    }

    protected void EmitSignalTimeout()
    {
        EmitSignal(SignalName.Timeout);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_timeout = "Timeout";

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
        if (signal == SignalName.Timeout)
        {
            if (HasGodotClassSignal(SignalProxyName_timeout.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'time_left' property.
        /// </summary>
        public static readonly StringName TimeLeft = "time_left";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_time_left' method.
        /// </summary>
        public static readonly StringName SetTimeLeft = "set_time_left";
        /// <summary>
        /// Cached name for the 'get_time_left' method.
        /// </summary>
        public static readonly StringName GetTimeLeft = "get_time_left";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'timeout' signal.
        /// </summary>
        public static readonly StringName Timeout = "timeout";
    }
}
