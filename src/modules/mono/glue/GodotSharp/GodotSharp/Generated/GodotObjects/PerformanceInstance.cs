namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class provides access to a number of different monitors related to performance, such as memory usage, draw calls, and FPS. These are the same as the values displayed in the <b>Monitor</b> tab in the editor's <b>Debugger</b> panel. By using the <see cref="Godot.PerformanceInstance.GetMonitor(Performance.Monitor)"/> method of this class, you can access this data from your code.</para>
/// <para>You can add custom monitors using the <see cref="Godot.PerformanceInstance.AddCustomMonitor(StringName, Callable, Godot.Collections.Array, Performance.MonitorType)"/> method. Custom monitors are available in <b>Monitor</b> tab in the editor's <b>Debugger</b> panel together with built-in monitors.</para>
/// <para><b>Note:</b> Some of the built-in monitors are only available in debug mode and will always return <c>0</c> when used in a project exported in release mode.</para>
/// <para><b>Note:</b> Some of the built-in monitors are not updated in real-time for performance reasons, so there may be a delay of up to 1 second between changes.</para>
/// <para><b>Note:</b> Custom monitors do not support negative values. Negative values are clamped to 0.</para>
/// </summary>
[GodotClassName("Performance")]
public partial class PerformanceInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(PerformanceInstance);

    private static readonly StringName NativeName = "Performance";

    internal PerformanceInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PerformanceInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PerformanceInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMonitor, 1943275655ul);

    /// <summary>
    /// <para>Returns the value of one of the available built-in monitors. You should provide one of the <see cref="Godot.Performance.Monitor"/> constants as the argument, like this:</para>
    /// <para><code>
    /// GD.Print(Performance.GetMonitor(Performance.Monitor.TimeFps)); // Prints the FPS to the console.
    /// </code></para>
    /// <para>See <see cref="Godot.PerformanceInstance.GetCustomMonitor(StringName)"/> to query custom performance monitors' values.</para>
    /// </summary>
    public double GetMonitor(Performance.Monitor monitor)
    {
        return NativeCalls.godot_icall_1_460(MethodBind0, GodotObject.GetPtr(this), (int)monitor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCustomMonitor, 3655788610ul);

    /// <summary>
    /// <para>Adds a custom monitor with the name <paramref name="id"/>. You can specify the category of the monitor using slash delimiters in <paramref name="id"/> (for example: <c>"Game/NumberOfNPCs"</c>). If there is more than one slash delimiter, then the default category is used. The default category is <c>"Custom"</c>. Prints an error if given <paramref name="id"/> is already present.</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	var monitorValue = new Callable(this, MethodName.GetMonitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "MyCategory".
    /// 	Performance.AddCustomMonitor("MyCategory/MyMonitor", monitorValue);
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyCategory/MyMonitor" and "MyMonitor" have same name but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyMonitor" and "Custom/MyMonitor" have same name and same category but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("Custom/MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyCategoryOne/MyCategoryTwo/MyMonitor" to category "Custom".
    /// 	Performance.AddCustomMonitor("MyCategoryOne/MyCategoryTwo/MyMonitor", monitorValue);
    /// }
    /// 
    /// public int GetMonitorValue()
    /// {
    /// 	return GD.Randi() % 25;
    /// }
    /// </code></para>
    /// <para>The debugger calls the callable to get the value of custom monitor. The callable must return a zero or positive integer or floating-point number.</para>
    /// <para>Callables are called with arguments supplied in argument array.</para>
    /// </summary>
    public void AddCustomMonitor(StringName id, Callable callable, Godot.Collections.Array arguments = null, Performance.MonitorType type = (Performance.MonitorType)(0))
    {
        NativeCalls.godot_icall_4_975(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(id?.NativeValue ?? default), callable, (godot_array)(arguments ?? new()).NativeValue, (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCustomMonitor, 3304788590ul);

    /// <summary>
    /// <para>Removes the custom monitor with given <paramref name="id"/>. Prints an error if the given <paramref name="id"/> is already absent.</para>
    /// </summary>
    public void RemoveCustomMonitor(StringName id)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(id?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasCustomMonitor, 2041966384ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if custom monitor with the given <paramref name="id"/> is present, <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool HasCustomMonitor(StringName id)
    {
        return NativeCalls.godot_icall_1_105(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(id?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMonitor, 2138907829ul);

    /// <summary>
    /// <para>Returns the value of custom monitor with given <paramref name="id"/>. The callable is called to get the value of custom monitor. See also <see cref="Godot.PerformanceInstance.HasCustomMonitor(StringName)"/>. Prints an error if the given <paramref name="id"/> is absent.</para>
    /// </summary>
    public Variant GetCustomMonitor(StringName id)
    {
        return NativeCalls.godot_icall_1_143(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(id?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMonitorModificationTime, 2455072627ul);

    /// <summary>
    /// <para>Returns the last tick in which custom monitor was added/removed (in microseconds since the engine started). This is set to <see cref="Godot.Time.GetTicksUsec()"/> when the monitor is updated.</para>
    /// </summary>
    public ulong GetMonitorModificationTime()
    {
        return NativeCalls.godot_icall_0_137(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMonitorNames, 2915620761ul);

    /// <summary>
    /// <para>Returns the names of active custom monitors in an <see cref="Godot.Collections.Array"/>.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetCustomMonitorNames()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind6, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMonitorTypes, 969006518ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Performance.MonitorType"/> values of active custom monitors in an <see cref="Godot.Collections.Array"/>.</para>
    /// </summary>
    public int[] GetCustomMonitorTypes()
    {
        return NativeCalls.godot_icall_0_151(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCustomMonitor, 4099036814ul);

    /// <summary>
    /// <para>Adds a custom monitor with the name <paramref name="id"/>. You can specify the category of the monitor using slash delimiters in <paramref name="id"/> (for example: <c>"Game/NumberOfNPCs"</c>). If there is more than one slash delimiter, then the default category is used. The default category is <c>"Custom"</c>. Prints an error if given <paramref name="id"/> is already present.</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	var monitorValue = new Callable(this, MethodName.GetMonitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "MyCategory".
    /// 	Performance.AddCustomMonitor("MyCategory/MyMonitor", monitorValue);
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyCategory/MyMonitor" and "MyMonitor" have same name but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyMonitor" and "Custom/MyMonitor" have same name and same category but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("Custom/MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyCategoryOne/MyCategoryTwo/MyMonitor" to category "Custom".
    /// 	Performance.AddCustomMonitor("MyCategoryOne/MyCategoryTwo/MyMonitor", monitorValue);
    /// }
    /// 
    /// public int GetMonitorValue()
    /// {
    /// 	return GD.Randi() % 25;
    /// }
    /// </code></para>
    /// <para>The debugger calls the callable to get the value of custom monitor. The callable must return a zero or positive integer or floating-point number.</para>
    /// <para>Callables are called with arguments supplied in argument array.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddCustomMonitor(StringName id, Callable callable, Godot.Collections.Array arguments)
    {
        NativeCalls.godot_icall_3_976(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(id?.NativeValue ?? default), callable, (godot_array)(arguments ?? new()).NativeValue);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_monitor' method.
        /// </summary>
        public static readonly StringName GetMonitor = "get_monitor";
        /// <summary>
        /// Cached name for the 'add_custom_monitor' method.
        /// </summary>
        public static readonly StringName AddCustomMonitor = "add_custom_monitor";
        /// <summary>
        /// Cached name for the 'remove_custom_monitor' method.
        /// </summary>
        public static readonly StringName RemoveCustomMonitor = "remove_custom_monitor";
        /// <summary>
        /// Cached name for the 'has_custom_monitor' method.
        /// </summary>
        public static readonly StringName HasCustomMonitor = "has_custom_monitor";
        /// <summary>
        /// Cached name for the 'get_custom_monitor' method.
        /// </summary>
        public static readonly StringName GetCustomMonitor = "get_custom_monitor";
        /// <summary>
        /// Cached name for the 'get_monitor_modification_time' method.
        /// </summary>
        public static readonly StringName GetMonitorModificationTime = "get_monitor_modification_time";
        /// <summary>
        /// Cached name for the 'get_custom_monitor_names' method.
        /// </summary>
        public static readonly StringName GetCustomMonitorNames = "get_custom_monitor_names";
        /// <summary>
        /// Cached name for the 'get_custom_monitor_types' method.
        /// </summary>
        public static readonly StringName GetCustomMonitorTypes = "get_custom_monitor_types";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
