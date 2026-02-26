namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.MainLoop"/> is the abstract base class for a Godot project's game loop. It is inherited by <see cref="Godot.SceneTree"/>, which is the default game loop implementation used in Godot projects, though it is also possible to write and use one's own <see cref="Godot.MainLoop"/> subclass instead of the scene tree.</para>
/// <para>Upon the application start, a <see cref="Godot.MainLoop"/> implementation must be provided to the OS; otherwise, the application will exit. This happens automatically (and a <see cref="Godot.SceneTree"/> is created) unless a <see cref="Godot.MainLoop"/> <see cref="Godot.Script"/> is provided from the command line (with e.g. <c>godot -s my_loop.gd</c>) or the <c>ProjectSettings.application/run/main_loop_type</c> project setting is overwritten.</para>
/// <para>Here is an example script implementing a simple <see cref="Godot.MainLoop"/>:</para>
/// <para><code>
/// using Godot;
/// 
/// [GlobalClass]
/// public partial class CustomMainLoop : MainLoop
/// {
/// 	private double _timeElapsed = 0;
/// 
/// 	public override void _Initialize()
/// 	{
/// 		GD.Print("Initialized:");
/// 		GD.Print($"  Starting Time: {_timeElapsed}");
/// 	}
/// 
/// 	public override bool _Process(double delta)
/// 	{
/// 		_timeElapsed += delta;
/// 		// Return true to end the main loop.
/// 		return Input.GetMouseButtonMask() != 0 || Input.IsKeyPressed(Key.Escape);
/// 	}
/// 
/// 	private void _Finalize()
/// 	{
/// 		GD.Print("Finalized:");
/// 		GD.Print($"  End Time: {_timeElapsed}");
/// 	}
/// }
/// </code></para>
/// </summary>
public partial class MainLoop : GodotObject
{
    /// <summary>
    /// <para>Notification received from the OS when the application is exceeding its allocated memory.</para>
    /// <para>Specific to the iOS platform.</para>
    /// </summary>
    public const long NotificationOsMemoryWarning = 2009;
    /// <summary>
    /// <para>Notification received when translations may have changed. Can be triggered by the user changing the locale. Can be used to respond to language changes, for example to change the UI strings on the fly. Useful when working with the built-in translation support, like <see cref="Godot.GodotObject.Tr(StringName, StringName)"/>.</para>
    /// </summary>
    public const long NotificationTranslationChanged = 2010;
    /// <summary>
    /// <para>Notification received from the OS when a request for "About" information is sent.</para>
    /// <para>Specific to the macOS platform.</para>
    /// </summary>
    public const long NotificationWMAbout = 2011;
    /// <summary>
    /// <para>Notification received from Godot's crash handler when the engine is about to crash.</para>
    /// <para>Implemented on desktop platforms if the crash handler is enabled.</para>
    /// </summary>
    public const long NotificationCrash = 2012;
    /// <summary>
    /// <para>Notification received from the OS when an update of the Input Method Engine occurs (e.g. change of IME cursor position or composition string).</para>
    /// <para>Implemented on desktop and web platforms.</para>
    /// </summary>
    public const long NotificationOsImeUpdate = 2013;
    /// <summary>
    /// <para>Notification received from the OS when the application is resumed.</para>
    /// <para>Specific to the Android and iOS platforms.</para>
    /// </summary>
    public const long NotificationApplicationResumed = 2014;
    /// <summary>
    /// <para>Notification received from the OS when the application is paused.</para>
    /// <para>Specific to the Android and iOS platforms.</para>
    /// <para><b>Note:</b> On iOS, you only have approximately 5 seconds to finish a task started by this signal. If you go over this allotment, iOS will kill the app instead of pausing it.</para>
    /// </summary>
    public const long NotificationApplicationPaused = 2015;
    /// <summary>
    /// <para>Notification received from the OS when the application is focused, i.e. when changing the focus from the OS desktop or a thirdparty application to any open window of the Godot instance.</para>
    /// <para>Implemented on desktop and mobile platforms.</para>
    /// </summary>
    public const long NotificationApplicationFocusIn = 2016;
    /// <summary>
    /// <para>Notification received from the OS when the application is defocused, i.e. when changing the focus from any open window of the Godot instance to the OS desktop or a thirdparty application.</para>
    /// <para>Implemented on desktop and mobile platforms.</para>
    /// </summary>
    public const long NotificationApplicationFocusOut = 2017;
    /// <summary>
    /// <para>Notification received when text server is changed.</para>
    /// </summary>
    public const long NotificationTextServerChanged = 2018;

    private static readonly System.Type CachedType = typeof(MainLoop);

    private static readonly StringName NativeName = "MainLoop";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MainLoop() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MainLoop(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MainLoop(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called before the program exits.</para>
    /// </summary>
    public virtual void _Finalize()
    {
    }

    /// <summary>
    /// <para>Called once during initialization.</para>
    /// </summary>
    public virtual void _Initialize()
    {
    }

    /// <summary>
    /// <para>Called each physics tick. <paramref name="delta"/> is the logical time between physics ticks in seconds and is equal to <see cref="Godot.Engine.TimeScale"/> / <see cref="Godot.Engine.PhysicsTicksPerSecond"/>. Equivalent to <see cref="Godot.Node._PhysicsProcess(double)"/>.</para>
    /// <para>If implemented, the method must return a boolean value. <see langword="true"/> ends the main loop, while <see langword="false"/> lets it proceed to the next step.</para>
    /// <para><b>Note:</b> <see cref="Godot.MainLoop._PhysicsProcess(double)"/> may be called up to <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> times per (idle) frame. This step limit may be reached when the engine is suffering performance issues.</para>
    /// <para><b>Note:</b> Accumulated <paramref name="delta"/> may diverge from real world seconds.</para>
    /// </summary>
    public virtual bool _PhysicsProcess(double delta)
    {
        return default;
    }

    /// <summary>
    /// <para>Called on each idle frame, prior to rendering, and after physics ticks have been processed. <paramref name="delta"/> is the time between frames in seconds. Equivalent to <see cref="Godot.Node._Process(double)"/>.</para>
    /// <para>If implemented, the method must return a boolean value. <see langword="true"/> ends the main loop, while <see langword="false"/> lets it proceed to the next frame.</para>
    /// <para><b>Note:</b> When the engine is struggling and the frame rate is lowered, <paramref name="delta"/> will increase. When <paramref name="delta"/> is increased, it's capped at a maximum of <see cref="Godot.Engine.TimeScale"/> * <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> / <see cref="Godot.Engine.PhysicsTicksPerSecond"/>. As a result, accumulated <paramref name="delta"/> may not represent real world time.</para>
    /// <para><b>Note:</b> When <c>--fixed-fps</c> is enabled or the engine is running in Movie Maker mode (see <see cref="Godot.MovieWriter"/>), process <paramref name="delta"/> will always be the same for every frame, regardless of how much time the frame took to render.</para>
    /// <para><b>Note:</b> Frame delta may be post-processed by <see cref="Godot.OS.DeltaSmoothing"/> if this is enabled for the project.</para>
    /// </summary>
    public virtual bool _Process(double delta)
    {
        return default;
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.MainLoop.OnRequestPermissionsResult"/> event of a <see cref="Godot.MainLoop"/> class.
    /// </summary>
    public delegate void OnRequestPermissionsResultEventHandler(string permission, bool granted);

    private static void OnRequestPermissionsResultTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((OnRequestPermissionsResultEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a user responds to a permission request.</para>
    /// </summary>
    public unsafe event OnRequestPermissionsResultEventHandler OnRequestPermissionsResult
    {
        add => Connect(SignalName.OnRequestPermissionsResult, Callable.CreateWithUnsafeTrampoline(value, &OnRequestPermissionsResultTrampoline));
        remove => Disconnect(SignalName.OnRequestPermissionsResult, Callable.CreateWithUnsafeTrampoline(value, &OnRequestPermissionsResultTrampoline));
    }

    protected void EmitSignalOnRequestPermissionsResult(string permission, bool granted)
    {
        EmitSignal(SignalName.OnRequestPermissionsResult, permission, granted);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__finalize = "_Finalize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__initialize = "_Initialize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__physics_process = "_PhysicsProcess";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__process = "_Process";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_on_request_permissions_result = "OnRequestPermissionsResult";

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
        if ((method == MethodProxyName__finalize || method == MethodName._Finalize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__finalize.NativeValue))
        {
            _Finalize();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__initialize || method == MethodName._Initialize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__initialize.NativeValue))
        {
            _Initialize();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__physics_process || method == MethodName._PhysicsProcess) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__physics_process.NativeValue))
        {
            var callRet = _PhysicsProcess(VariantUtils.ConvertTo<double>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__process || method == MethodName._Process) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__process.NativeValue))
        {
            var callRet = _Process(VariantUtils.ConvertTo<double>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._Finalize)
        {
            if (HasGodotClassMethod(MethodProxyName__finalize.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Initialize)
        {
            if (HasGodotClassMethod(MethodProxyName__initialize.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PhysicsProcess)
        {
            if (HasGodotClassMethod(MethodProxyName__physics_process.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Process)
        {
            if (HasGodotClassMethod(MethodProxyName__process.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.OnRequestPermissionsResult)
        {
            if (HasGodotClassSignal(SignalProxyName_on_request_permissions_result.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the '_finalize' method.
        /// </summary>
        public static readonly StringName _Finalize = "_finalize";
        /// <summary>
        /// Cached name for the '_initialize' method.
        /// </summary>
        public static readonly StringName _Initialize = "_initialize";
        /// <summary>
        /// Cached name for the '_physics_process' method.
        /// </summary>
        public static readonly StringName _PhysicsProcess = "_physics_process";
        /// <summary>
        /// Cached name for the '_process' method.
        /// </summary>
        public static readonly StringName _Process = "_process";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'on_request_permissions_result' signal.
        /// </summary>
        public static readonly StringName OnRequestPermissionsResult = "on_request_permissions_result";
    }
}
