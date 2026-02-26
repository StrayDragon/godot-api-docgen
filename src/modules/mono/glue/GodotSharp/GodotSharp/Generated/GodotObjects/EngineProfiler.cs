namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class can be used to implement custom profilers that are able to interact with the engine and editor debugger.</para>
/// <para>See <see cref="Godot.EngineDebugger"/> and <c>EditorDebuggerPlugin</c> for more information.</para>
/// </summary>
public partial class EngineProfiler : RefCounted
{
    private static readonly System.Type CachedType = typeof(EngineProfiler);

    private static readonly StringName NativeName = "EngineProfiler";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EngineProfiler() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EngineProfiler(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EngineProfiler(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when data is added to profiler using <see cref="Godot.EngineDebugger.ProfilerAddFrameData(StringName, Godot.Collections.Array)"/>.</para>
    /// </summary>
    public virtual void _AddFrame(Godot.Collections.Array data)
    {
    }

    /// <summary>
    /// <para>Called once every engine iteration when the profiler is active with information about the current frame. All time values are in seconds. Lower values represent faster processing times and are therefore considered better.</para>
    /// </summary>
    public virtual void _Tick(double frameTime, double processTime, double physicsTime, double physicsFrameTime)
    {
    }

    /// <summary>
    /// <para>Called when the profiler is enabled/disabled, along with a set of <paramref name="options"/>.</para>
    /// </summary>
    public virtual void _Toggle(bool enable, Godot.Collections.Array options)
    {
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__add_frame = "_AddFrame";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__tick = "_Tick";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__toggle = "_Toggle";

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
        if ((method == MethodProxyName__add_frame || method == MethodName._AddFrame) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__add_frame.NativeValue))
        {
            _AddFrame(VariantUtils.ConvertTo<Godot.Collections.Array>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__tick || method == MethodName._Tick) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__tick.NativeValue))
        {
            _Tick(VariantUtils.ConvertTo<double>(args[0]), VariantUtils.ConvertTo<double>(args[1]), VariantUtils.ConvertTo<double>(args[2]), VariantUtils.ConvertTo<double>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__toggle || method == MethodName._Toggle) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__toggle.NativeValue))
        {
            _Toggle(VariantUtils.ConvertTo<bool>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Array>(args[1]));
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
        if (method == MethodName._AddFrame)
        {
            if (HasGodotClassMethod(MethodProxyName__add_frame.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Tick)
        {
            if (HasGodotClassMethod(MethodProxyName__tick.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Toggle)
        {
            if (HasGodotClassMethod(MethodProxyName__toggle.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_add_frame' method.
        /// </summary>
        public static readonly StringName _AddFrame = "_add_frame";
        /// <summary>
        /// Cached name for the '_tick' method.
        /// </summary>
        public static readonly StringName _Tick = "_tick";
        /// <summary>
        /// Cached name for the '_toggle' method.
        /// </summary>
        public static readonly StringName _Toggle = "_toggle";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
