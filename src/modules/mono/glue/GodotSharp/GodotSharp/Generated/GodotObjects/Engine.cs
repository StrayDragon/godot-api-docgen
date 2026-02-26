namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.Engine"/> singleton allows you to query and modify the project's run-time parameters, such as frames per second, time scale, and others. It also stores information about the current build of Godot, such as the current version.</para>
/// </summary>
public static partial class Engine
{
    /// <summary>
    /// <para>If <see langword="false"/>, stops printing error and warning messages to the console and editor Output log. This can be used to hide error and warning messages during unit test suite runs. This property is equivalent to the <c>ProjectSettings.application/run/disable_stderr</c> project setting.</para>
    /// <para><b>Note:</b> This property does not impact the editor's Errors tab when running a project from the editor.</para>
    /// <para><b>Warning:</b> If set to <see langword="false"/> anywhere in the project, important error messages may be hidden even if they are emitted from other scripts. In a <c>@tool</c> script, this will also impact the editor itself. Do <i>not</i> report bugs before ensuring error messages are enabled (as they are by default).</para>
    /// </summary>
    public static bool PrintErrorMessages
    {
        get
        {
            return IsPrintingErrorMessages();
        }
        set
        {
            SetPrintErrorMessages(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, stops printing messages (for example using <c>@GlobalScope.print</c>) to the console, log files, and editor Output log. This property is equivalent to the <c>ProjectSettings.application/run/disable_stdout</c> project setting.</para>
    /// <para><b>Note:</b> This does not stop printing errors or warnings produced by scripts to the console or log files, for more details see <see cref="Godot.Engine.PrintErrorMessages"/>.</para>
    /// </summary>
    public static bool PrintToStdOut
    {
        get
        {
            return IsPrintingToStdOut();
        }
        set
        {
            SetPrintToStdOut(value);
        }
    }

    /// <summary>
    /// <para>The number of fixed iterations per second. This controls how often physics simulation and the <see cref="Godot.Node._PhysicsProcess(double)"/> method are run.</para>
    /// <para>CPU usage scales approximately with the physics tick rate. However, at very low tick rates (usually below 30), physics behavior can break down. Input can also become less responsive at low tick rates as there can be a gap between input being registered, and the response on the next physics tick. High tick rates give more accurate physics simulation, particularly for fast moving objects. For example, racing games may benefit from increasing the tick rate above the default 60.</para>
    /// <para>See also <see cref="Godot.Engine.MaxFps"/> and <c>ProjectSettings.physics/common/physics_ticks_per_second</c>.</para>
    /// <para><b>Note:</b> Only <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> physics ticks may be simulated per rendered frame at most. If more physics ticks have to be simulated per rendered frame to keep up with rendering, the project will appear to slow down (even if <c>delta</c> is used consistently in physics calculations). Therefore, it is recommended to also increase <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> if increasing <see cref="Godot.Engine.PhysicsTicksPerSecond"/> significantly above its default value.</para>
    /// <para><b>Note:</b> Consider enabling <a href="$DOCS_URL/tutorials/physics/interpolation/index.html">physics interpolation</a> if you change <see cref="Godot.Engine.PhysicsTicksPerSecond"/> to a value that is not a multiple of <c>60</c>. Using physics interpolation will avoid jittering when the monitor refresh rate and physics update rate don't exactly match.</para>
    /// </summary>
    public static int PhysicsTicksPerSecond
    {
        get
        {
            return GetPhysicsTicksPerSecond();
        }
        set
        {
            SetPhysicsTicksPerSecond(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of physics steps that can be simulated each rendered frame.</para>
    /// <para><b>Note:</b> The default value is tuned to prevent expensive physics simulations from triggering even more expensive simulations indefinitely. However, the game will appear to slow down if the rendering FPS is less than <c>1 / max_physics_steps_per_frame</c> of <see cref="Godot.Engine.PhysicsTicksPerSecond"/>. This occurs even if <c>delta</c> is consistently used in physics calculations. To avoid this, increase <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> if you have increased <see cref="Godot.Engine.PhysicsTicksPerSecond"/> significantly above its default value.</para>
    /// </summary>
    public static int MaxPhysicsStepsPerFrame
    {
        get
        {
            return GetMaxPhysicsStepsPerFrame();
        }
        set
        {
            SetMaxPhysicsStepsPerFrame(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of frames that can be rendered every second (FPS). A value of <c>0</c> means the framerate is uncapped.</para>
    /// <para>Limiting the FPS can be useful to reduce the host machine's power consumption, which reduces heat, noise emissions, and improves battery life.</para>
    /// <para>If <c>ProjectSettings.display/window/vsync/vsync_mode</c> is <b>Enabled</b> or <b>Adaptive</b>, the setting takes precedence and the max FPS number cannot exceed the monitor's refresh rate. See also <see cref="Godot.DisplayServer.ScreenGetRefreshRate(int)"/>.</para>
    /// <para>If <c>ProjectSettings.display/window/vsync/vsync_mode</c> is <b>Enabled</b>, on monitors with variable refresh rate enabled (G-Sync/FreeSync), using an FPS limit a few frames lower than the monitor's refresh rate will <a href="https://blurbusters.com/howto-low-lag-vsync-on/">reduce input lag while avoiding tearing</a>. At higher refresh rates, the difference between the FPS limit and the monitor refresh rate should be increased to ensure frames to account for timing inaccuracies. The optimal formula for the FPS limit value in this scenario is <c>r - (r * r) / 3600.0</c>, where <c>r</c> is the monitor's refresh rate.</para>
    /// <para><b>Note:</b> The actual number of frames per second may still be below this value if the CPU or GPU cannot keep up with the project's logic and rendering.</para>
    /// <para><b>Note:</b> If <c>ProjectSettings.display/window/vsync/vsync_mode</c> is <b>Disabled</b>, limiting the FPS to a high value that can be consistently reached on the system can reduce input lag compared to an uncapped framerate. Since this works by ensuring the GPU load is lower than 100%, this latency reduction is only effective in GPU-bottlenecked scenarios, not CPU-bottlenecked scenarios.</para>
    /// </summary>
    public static int MaxFps
    {
        get
        {
            return GetMaxFps();
        }
        set
        {
            SetMaxFps(value);
        }
    }

    /// <summary>
    /// <para>The speed multiplier at which the in-game clock updates, compared to real time. For example, if set to <c>2.0</c> the game runs twice as fast, and if set to <c>0.5</c> the game runs half as fast.</para>
    /// <para>This value affects <see cref="Godot.Timer"/>, <see cref="Godot.SceneTreeTimer"/>, and all other simulations that make use of <c>delta</c> time (such as <see cref="Godot.Node._Process(double)"/> and <see cref="Godot.Node._PhysicsProcess(double)"/>).</para>
    /// <para><b>Note:</b> It's recommended to keep this property above <c>0.0</c>, as the game may behave unexpectedly otherwise.</para>
    /// <para><b>Note:</b> This does not affect audio playback speed. Use <see cref="Godot.AudioServer.PlaybackSpeedScale"/> to adjust audio playback speed independently of <see cref="Godot.Engine.TimeScale"/>.</para>
    /// <para><b>Note:</b> This does not automatically adjust <see cref="Godot.Engine.PhysicsTicksPerSecond"/>. With values above <c>1.0</c> physics simulation may become less precise, as each physics tick will stretch over a larger period of engine time. If you're modifying <see cref="Godot.Engine.TimeScale"/> to speed up simulation by a large factor, consider also increasing <see cref="Godot.Engine.PhysicsTicksPerSecond"/> to make the simulation more reliable.</para>
    /// </summary>
    public static double TimeScale
    {
        get
        {
            return GetTimeScale();
        }
        set
        {
            SetTimeScale(value);
        }
    }

    /// <summary>
    /// <para>How much physics ticks are synchronized with real time. If <c>0</c> or less, the ticks are fully synchronized. Higher values cause the in-game clock to deviate more from the real clock, but they smooth out framerate jitters.</para>
    /// <para><b>Note:</b> The default value of <c>0.5</c> should be good enough for most cases; values above <c>2</c> could cause the game to react to dropped frames with a noticeable delay and are not recommended.</para>
    /// <para><b>Note:</b> When using a custom physics interpolation solution, or within a network game, it's recommended to disable the physics jitter fix by setting this property to <c>0</c>.</para>
    /// </summary>
    public static double PhysicsJitterFix
    {
        get
        {
            return GetPhysicsJitterFix();
        }
        set
        {
            SetPhysicsJitterFix(value);
        }
    }

    private static readonly StringName NativeName = "Engine";

    private static EngineInstance singleton;

    public static EngineInstance Singleton =>
        singleton ??= (EngineInstance)InteropUtils.EngineGetSingleton("Engine");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsTicksPerSecond, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetPhysicsTicksPerSecond(int physicsTicksPerSecond)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(Singleton), physicsTicksPerSecond);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsTicksPerSecond, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int GetPhysicsTicksPerSecond()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxPhysicsStepsPerFrame, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetMaxPhysicsStepsPerFrame(int maxPhysicsSteps)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(Singleton), maxPhysicsSteps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxPhysicsStepsPerFrame, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int GetMaxPhysicsStepsPerFrame()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsJitterFix, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetPhysicsJitterFix(double physicsJitterFix)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(Singleton), physicsJitterFix);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsJitterFix, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static double GetPhysicsJitterFix()
    {
        return NativeCalls.godot_icall_0_144(MethodBind5, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsInterpolationFraction, 1740695150ul);

    /// <summary>
    /// <para>Returns the fraction through the current physics tick we are at the time of rendering the frame. This can be used to implement fixed timestep interpolation.</para>
    /// </summary>
    public static double GetPhysicsInterpolationFraction()
    {
        return NativeCalls.godot_icall_0_144(MethodBind6, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxFps, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetMaxFps(int maxFps)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(Singleton), maxFps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxFps, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int GetMaxFps()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTimeScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetTimeScale(double timeScale)
    {
        NativeCalls.godot_icall_1_127(MethodBind9, GodotObject.GetPtr(Singleton), timeScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeScale, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static double GetTimeScale()
    {
        return NativeCalls.godot_icall_0_144(MethodBind10, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFramesDrawn, 2455072627ul);

    /// <summary>
    /// <para>Returns the total number of frames drawn since the engine started.</para>
    /// <para><b>Note:</b> On headless platforms, or if rendering is disabled with <c>--disable-render-loop</c> via command line, this method always returns <c>0</c>. See also <see cref="Godot.Engine.GetProcessFrames()"/>.</para>
    /// </summary>
    public static int GetFramesDrawn()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFramesPerSecond, 1740695150ul);

    /// <summary>
    /// <para>Returns the average frames rendered every second (FPS), also known as the framerate.</para>
    /// </summary>
    public static double GetFramesPerSecond()
    {
        return NativeCalls.godot_icall_0_144(MethodBind12, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsFrames, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of frames passed since the engine started. This number is increased every <b>physics frame</b>. See also <see cref="Godot.Engine.GetProcessFrames()"/>.</para>
    /// <para>This method can be used to run expensive logic less often without relying on a <see cref="Godot.Timer"/>:</para>
    /// <para><code>
    /// public override void _PhysicsProcess(double delta)
    /// {
    /// 	base._PhysicsProcess(delta);
    /// 
    /// 	if (Engine.GetPhysicsFrames() % 2 == 0)
    /// 	{
    /// 		// Run expensive logic only once every 2 physics frames here.
    /// 	}
    /// }
    /// </code></para>
    /// </summary>
    public static ulong GetPhysicsFrames()
    {
        return NativeCalls.godot_icall_0_137(MethodBind13, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessFrames, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of frames passed since the engine started. This number is increased every <b>process frame</b>, regardless of whether the render loop is enabled. See also <see cref="Godot.Engine.GetFramesDrawn()"/> and <see cref="Godot.Engine.GetPhysicsFrames()"/>.</para>
    /// <para>This method can be used to run expensive logic less often without relying on a <see cref="Godot.Timer"/>:</para>
    /// <para><code>
    /// public override void _Process(double delta)
    /// {
    /// 	base._Process(delta);
    /// 
    /// 	if (Engine.GetProcessFrames() % 5 == 0)
    /// 	{
    /// 		// Run expensive logic only once every 5 process (render) frames here.
    /// 	}
    /// }
    /// </code></para>
    /// </summary>
    public static ulong GetProcessFrames()
    {
        return NativeCalls.godot_icall_0_137(MethodBind14, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMainLoop, 1016888095ul);

    /// <summary>
    /// <para>Returns the instance of the <see cref="Godot.MainLoop"/>. This is usually the main <see cref="Godot.SceneTree"/> and is the same as <see cref="Godot.Node.GetTree()"/>.</para>
    /// <para><b>Note:</b> The type instantiated as the main loop can changed with <c>ProjectSettings.application/run/main_loop_type</c>.</para>
    /// </summary>
    public static MainLoop GetMainLoop()
    {
        return (MainLoop)NativeCalls.godot_icall_0_53(MethodBind15, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVersionInfo, 3102165223ul);

    /// <summary>
    /// <para>Returns the current engine version information as a <see cref="Godot.Collections.Dictionary"/> containing the following entries:</para>
    /// <para>- <c>major</c> - Major version number as an int;</para>
    /// <para>- <c>minor</c> - Minor version number as an int;</para>
    /// <para>- <c>patch</c> - Patch version number as an int;</para>
    /// <para>- <c>hex</c> - Full version encoded as a hexadecimal int with one byte (2 hex digits) per number (see example below);</para>
    /// <para>- <c>status</c> - Status (such as "beta", "rc1", "rc2", "stable", etc.) as a String;</para>
    /// <para>- <c>build</c> - Build name (e.g. "custom_build") as a String;</para>
    /// <para>- <c>hash</c> - Full Git commit hash as a String;</para>
    /// <para>- <c>timestamp</c> - Holds the Git commit date UNIX timestamp in seconds as an int, or <c>0</c> if unavailable;</para>
    /// <para>- <c>string</c> - <c>major</c>, <c>minor</c>, <c>patch</c>, <c>status</c>, and <c>build</c> in a single String.</para>
    /// <para>The <c>hex</c> value is encoded as follows, from left to right: one byte for the major, one byte for the minor, one byte for the patch version. For example, "3.1.12" would be <c>0x03010C</c>.</para>
    /// <para><b>Note:</b> The <c>hex</c> value is still an <see cref="int"/> internally, and printing it will give you its decimal representation, which is not particularly meaningful. Use hexadecimal literals for quick version comparisons from code:</para>
    /// <para><code>
    /// if ((int)Engine.GetVersionInfo()["hex"] &gt;= 0x040100)
    /// {
    /// 	// Do things specific to version 4.1 or later.
    /// }
    /// else
    /// {
    /// 	// Do things specific to versions before 4.1.
    /// }
    /// </code></para>
    /// </summary>
    public static Godot.Collections.Dictionary GetVersionInfo()
    {
        return NativeCalls.godot_icall_0_122(MethodBind16, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAuthorInfo, 3102165223ul);

    /// <summary>
    /// <para>Returns the engine author information as a <see cref="Godot.Collections.Dictionary"/>, where each entry is an <see cref="Godot.Collections.Array"/> of strings with the names of notable contributors to the Godot Engine: <c>lead_developers</c>, <c>founders</c>, <c>project_managers</c>, and <c>developers</c>.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetAuthorInfo()
    {
        return NativeCalls.godot_icall_0_122(MethodBind17, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCopyrightInfo, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of dictionaries with copyright information for every component of Godot's source code.</para>
    /// <para>Every <see cref="Godot.Collections.Dictionary"/> contains a <c>name</c> identifier, and a <c>parts</c> array of dictionaries. It describes the component in detail with the following entries:</para>
    /// <para>- <c>files</c> - <see cref="Godot.Collections.Array"/> of file paths from the source code affected by this component;</para>
    /// <para>- <c>copyright</c> - <see cref="Godot.Collections.Array"/> of owners of this component;</para>
    /// <para>- <c>license</c> - The license applied to this component (such as "<a href="https://en.wikipedia.org/wiki/MIT_License#Ambiguity_and_variants">Expat</a>" or "<a href="https://creativecommons.org/licenses/by/4.0/">CC-BY-4.0</a>").</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Dictionary> GetCopyrightInfo()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind18, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDonorInfo, 3102165223ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> of categorized donor names. Each entry is an <see cref="Godot.Collections.Array"/> of strings:</para>
    /// <para>{<c>platinum_sponsors</c>, <c>gold_sponsors</c>, <c>silver_sponsors</c>, <c>bronze_sponsors</c>, <c>mini_sponsors</c>, <c>gold_donors</c>, <c>silver_donors</c>, <c>bronze_donors</c>}</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetDonorInfo()
    {
        return NativeCalls.godot_icall_0_122(MethodBind19, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLicenseInfo, 3102165223ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> of licenses used by Godot and included third party components. Each entry is a license name (such as "<a href="https://en.wikipedia.org/wiki/MIT_License#Ambiguity_and_variants">Expat</a>") and its associated text.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetLicenseInfo()
    {
        return NativeCalls.godot_icall_0_122(MethodBind20, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLicenseText, 201670096ul);

    /// <summary>
    /// <para>Returns the full Godot license text.</para>
    /// </summary>
    public static string GetLicenseText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind21, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetArchitectureName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the CPU architecture the Godot binary was built for. Possible return values include <c>"x86_64"</c>, <c>"x86_32"</c>, <c>"arm64"</c>, <c>"arm32"</c>, <c>"rv64"</c>, <c>"ppc64"</c>, <c>"loongarch64"</c>, <c>"wasm64"</c>, and <c>"wasm32"</c>.</para>
    /// <para>To detect whether the current build is 64-bit, or the type of architecture, don't use the architecture name. Instead, use <see cref="Godot.OS.HasFeature(string)"/> to check for the <c>"64"</c> feature tag, or tags such as <c>"x86"</c> or <c>"arm"</c>. See the <a href="$DOCS_URL/tutorials/export/feature_tags.html">Feature Tags</a> documentation for more details.</para>
    /// <para><b>Note:</b> This method does <i>not</i> return the name of the system's CPU architecture (like <see cref="Godot.OS.GetProcessorName()"/>). For example, when running an <c>x86_32</c> Godot binary on an <c>x86_64</c> system, the returned value will still be <c>"x86_32"</c>.</para>
    /// </summary>
    public static string GetArchitectureName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind22, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInPhysicsFrame, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the engine is inside the fixed physics process step of the main loop.</para>
    /// <para><code>
    /// func _enter_tree():
    /// 	# Depending on when the node is added to the tree,
    /// 	# prints either "true" or "false".
    /// 	print(Engine.is_in_physics_frame())
    /// 
    /// func _process(delta):
    /// 	print(Engine.is_in_physics_frame()) # Prints false
    /// 
    /// func _physics_process(delta):
    /// 	print(Engine.is_in_physics_frame()) # Prints true
    /// </code></para>
    /// </summary>
    public static bool IsInPhysicsFrame()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSingleton, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a singleton with the given <paramref name="name"/> exists in the global scope. See also <see cref="Godot.Engine.GetSingleton(StringName)"/>.</para>
    /// <para><code>
    /// GD.Print(Engine.HasSingleton("OS"));          // Prints True
    /// GD.Print(Engine.HasSingleton("Engine"));      // Prints True
    /// GD.Print(Engine.HasSingleton("AudioServer")); // Prints True
    /// GD.Print(Engine.HasSingleton("Unknown"));     // Prints False
    /// </code></para>
    /// <para><b>Note:</b> Global singletons are not the same as autoloaded nodes, which are configurable in the project settings.</para>
    /// </summary>
    public static bool HasSingleton(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind24, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSingleton, 1371597918ul);

    /// <summary>
    /// <para>Returns the global singleton with the given <paramref name="name"/>, or <see langword="null"/> if it does not exist. Often used for plugins. See also <see cref="Godot.Engine.HasSingleton(StringName)"/> and <see cref="Godot.Engine.GetSingletonList()"/>.</para>
    /// <para><b>Note:</b> Global singletons are not the same as autoloaded nodes, which are configurable in the project settings.</para>
    /// </summary>
    public static GodotObject GetSingleton(StringName name)
    {
        return (GodotObject)NativeCalls.godot_icall_1_545(MethodBind25, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterSingleton, 965313290ul);

    /// <summary>
    /// <para>Registers the given <see cref="Godot.GodotObject"/> <paramref name="instance"/> as a singleton, available globally under <paramref name="name"/>. Useful for plugins.</para>
    /// </summary>
    public static void RegisterSingleton(StringName name, GodotObject instance)
    {
        NativeCalls.godot_icall_2_159(MethodBind26, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(instance));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterSingleton, 3304788590ul);

    /// <summary>
    /// <para>Removes the singleton registered under <paramref name="name"/>. The singleton object is <i>not</i> freed. Only works with user-defined singletons registered with <see cref="Godot.Engine.RegisterSingleton(StringName, GodotObject)"/>.</para>
    /// </summary>
    public static void UnregisterSingleton(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind27, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSingletonList, 1139954409ul);

    /// <summary>
    /// <para>Returns a list of names of all available global singletons. See also <see cref="Godot.Engine.GetSingleton(StringName)"/>.</para>
    /// </summary>
    public static string[] GetSingletonList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind28, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterScriptLanguage, 1850254898ul);

    /// <summary>
    /// <para>Registers a <see cref="Godot.ScriptLanguage"/> instance to be available with <c>ScriptServer</c>.</para>
    /// <para>Returns:</para>
    /// <para>- <see cref="Godot.Error.Ok"/> on success;</para>
    /// <para>- <see cref="Godot.Error.Unavailable"/> if <c>ScriptServer</c> has reached the limit and cannot register any new language;</para>
    /// <para>- <see cref="Godot.Error.AlreadyExists"/> if <c>ScriptServer</c> already contains a language with similar extension/name/type.</para>
    /// </summary>
    public static Error RegisterScriptLanguage(ScriptLanguage language)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind29, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(language));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterScriptLanguage, 1850254898ul);

    /// <summary>
    /// <para>Unregisters the <see cref="Godot.ScriptLanguage"/> instance from <c>ScriptServer</c>.</para>
    /// <para>Returns:</para>
    /// <para>- <see cref="Godot.Error.Ok"/> on success;</para>
    /// <para>- <see cref="Godot.Error.DoesNotExist"/> if the language is not registered in <c>ScriptServer</c>.</para>
    /// </summary>
    public static Error UnregisterScriptLanguage(ScriptLanguage language)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind30, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(language));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptLanguageCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of available script languages. Use with <see cref="Godot.Engine.GetScriptLanguage(int)"/>.</para>
    /// </summary>
    public static int GetScriptLanguageCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptLanguage, 2151255799ul);

    /// <summary>
    /// <para>Returns an instance of a <see cref="Godot.ScriptLanguage"/> with the given <paramref name="index"/>.</para>
    /// </summary>
    public static ScriptLanguage GetScriptLanguage(int index)
    {
        return (ScriptLanguage)NativeCalls.godot_icall_1_335(MethodBind32, GodotObject.GetPtr(Singleton), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CaptureScriptBacktraces, 873284517ul);

    /// <summary>
    /// <para>Captures and returns backtraces from all registered script languages.</para>
    /// <para>By default, the returned <see cref="Godot.ScriptBacktrace"/> will only contain stack frames in editor builds and debug builds. To enable them for release builds as well, you need to enable <c>ProjectSettings.debug/settings/gdscript/always_track_call_stacks</c>.</para>
    /// <para>If <paramref name="includeVariables"/> is <see langword="true"/>, the backtrace will also include the names and values of any global variables (e.g. autoload singletons) at the point of the capture, as well as local variables and class member variables at each stack frame. This will however will only be respected when running the game with a debugger attached, like when running the game from the editor. To enable it for export builds as well, you need to enable <c>ProjectSettings.debug/settings/gdscript/always_track_local_variables</c>.</para>
    /// <para><b>Warning:</b> When <paramref name="includeVariables"/> is <see langword="true"/>, any captured variables can potentially (e.g. with GDScript backtraces) be their actual values, including any object references. This means that storing such a <see cref="Godot.ScriptBacktrace"/> will prevent those objects from being deallocated, so it's generally recommended not to do so.</para>
    /// </summary>
    public static Godot.Collections.Array<ScriptBacktrace> CaptureScriptBacktraces(bool includeVariables = false)
    {
        return new Godot.Collections.Array<ScriptBacktrace>(NativeCalls.godot_icall_1_546(MethodBind33, GodotObject.GetPtr(Singleton), includeVariables.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditorHint, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the script is currently running inside the editor, otherwise returns <see langword="false"/>. This is useful for <c>@tool</c> scripts to conditionally draw editor helpers, or prevent accidentally running "game" code that would affect the scene state while in the editor:</para>
    /// <para><code>
    /// if (Engine.IsEditorHint())
    /// 	DrawGizmos();
    /// else
    /// 	SimulatePhysics();
    /// </code></para>
    /// <para>See <a href="$DOCS_URL/tutorials/plugins/running_code_in_the_editor.html">Running code in the editor</a> in the documentation for more information.</para>
    /// <para><b>Note:</b> To detect whether the script is running on an editor <i>build</i> (such as when pressing F5), use <see cref="Godot.OS.HasFeature(string)"/> with the <c>"editor"</c> argument instead. <c>OS.has_feature("editor")</c> evaluate to <see langword="true"/> both when the script is running in the editor and when running the project from the editor, but returns <see langword="false"/> when run from an exported project.</para>
    /// </summary>
    public static bool IsEditorHint()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmbeddedInEditor, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the engine is running embedded in the editor. This is useful to prevent attempting to update window mode or window flags that are not supported when running the project embedded in the editor.</para>
    /// </summary>
    public static bool IsEmbeddedInEditor()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWriteMoviePath, 201670096ul);

    /// <summary>
    /// <para>Returns the path to the <see cref="Godot.MovieWriter"/>'s output file, or an empty string if the engine wasn't started in Movie Maker mode. The default path can be changed in <c>ProjectSettings.editor/movie_writer/movie_file</c>.</para>
    /// </summary>
    public static string GetWriteMoviePath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind36, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrintToStdOut, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetPrintToStdOut(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(Singleton), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPrintingToStdOut, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsPrintingToStdOut()
    {
        return NativeCalls.godot_icall_0_15(MethodBind38, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrintErrorMessages, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetPrintErrorMessages(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind39, GodotObject.GetPtr(Singleton), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPrintingErrorMessages, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsPrintingErrorMessages()
    {
        return NativeCalls.godot_icall_0_15(MethodBind40, GodotObject.GetPtr(Singleton)).ToBool();
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'print_error_messages' property.
        /// </summary>
        public static readonly StringName PrintErrorMessages = "print_error_messages";
        /// <summary>
        /// Cached name for the 'print_to_stdout' property.
        /// </summary>
        public static readonly StringName PrintToStdOut = "print_to_stdout";
        /// <summary>
        /// Cached name for the 'physics_ticks_per_second' property.
        /// </summary>
        public static readonly StringName PhysicsTicksPerSecond = "physics_ticks_per_second";
        /// <summary>
        /// Cached name for the 'max_physics_steps_per_frame' property.
        /// </summary>
        public static readonly StringName MaxPhysicsStepsPerFrame = "max_physics_steps_per_frame";
        /// <summary>
        /// Cached name for the 'max_fps' property.
        /// </summary>
        public static readonly StringName MaxFps = "max_fps";
        /// <summary>
        /// Cached name for the 'time_scale' property.
        /// </summary>
        public static readonly StringName TimeScale = "time_scale";
        /// <summary>
        /// Cached name for the 'physics_jitter_fix' property.
        /// </summary>
        public static readonly StringName PhysicsJitterFix = "physics_jitter_fix";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'set_physics_ticks_per_second' method.
        /// </summary>
        public static readonly StringName SetPhysicsTicksPerSecond = "set_physics_ticks_per_second";
        /// <summary>
        /// Cached name for the 'get_physics_ticks_per_second' method.
        /// </summary>
        public static readonly StringName GetPhysicsTicksPerSecond = "get_physics_ticks_per_second";
        /// <summary>
        /// Cached name for the 'set_max_physics_steps_per_frame' method.
        /// </summary>
        public static readonly StringName SetMaxPhysicsStepsPerFrame = "set_max_physics_steps_per_frame";
        /// <summary>
        /// Cached name for the 'get_max_physics_steps_per_frame' method.
        /// </summary>
        public static readonly StringName GetMaxPhysicsStepsPerFrame = "get_max_physics_steps_per_frame";
        /// <summary>
        /// Cached name for the 'set_physics_jitter_fix' method.
        /// </summary>
        public static readonly StringName SetPhysicsJitterFix = "set_physics_jitter_fix";
        /// <summary>
        /// Cached name for the 'get_physics_jitter_fix' method.
        /// </summary>
        public static readonly StringName GetPhysicsJitterFix = "get_physics_jitter_fix";
        /// <summary>
        /// Cached name for the 'get_physics_interpolation_fraction' method.
        /// </summary>
        public static readonly StringName GetPhysicsInterpolationFraction = "get_physics_interpolation_fraction";
        /// <summary>
        /// Cached name for the 'set_max_fps' method.
        /// </summary>
        public static readonly StringName SetMaxFps = "set_max_fps";
        /// <summary>
        /// Cached name for the 'get_max_fps' method.
        /// </summary>
        public static readonly StringName GetMaxFps = "get_max_fps";
        /// <summary>
        /// Cached name for the 'set_time_scale' method.
        /// </summary>
        public static readonly StringName SetTimeScale = "set_time_scale";
        /// <summary>
        /// Cached name for the 'get_time_scale' method.
        /// </summary>
        public static readonly StringName GetTimeScale = "get_time_scale";
        /// <summary>
        /// Cached name for the 'get_frames_drawn' method.
        /// </summary>
        public static readonly StringName GetFramesDrawn = "get_frames_drawn";
        /// <summary>
        /// Cached name for the 'get_frames_per_second' method.
        /// </summary>
        public static readonly StringName GetFramesPerSecond = "get_frames_per_second";
        /// <summary>
        /// Cached name for the 'get_physics_frames' method.
        /// </summary>
        public static readonly StringName GetPhysicsFrames = "get_physics_frames";
        /// <summary>
        /// Cached name for the 'get_process_frames' method.
        /// </summary>
        public static readonly StringName GetProcessFrames = "get_process_frames";
        /// <summary>
        /// Cached name for the 'get_main_loop' method.
        /// </summary>
        public static readonly StringName GetMainLoop = "get_main_loop";
        /// <summary>
        /// Cached name for the 'get_version_info' method.
        /// </summary>
        public static readonly StringName GetVersionInfo = "get_version_info";
        /// <summary>
        /// Cached name for the 'get_author_info' method.
        /// </summary>
        public static readonly StringName GetAuthorInfo = "get_author_info";
        /// <summary>
        /// Cached name for the 'get_copyright_info' method.
        /// </summary>
        public static readonly StringName GetCopyrightInfo = "get_copyright_info";
        /// <summary>
        /// Cached name for the 'get_donor_info' method.
        /// </summary>
        public static readonly StringName GetDonorInfo = "get_donor_info";
        /// <summary>
        /// Cached name for the 'get_license_info' method.
        /// </summary>
        public static readonly StringName GetLicenseInfo = "get_license_info";
        /// <summary>
        /// Cached name for the 'get_license_text' method.
        /// </summary>
        public static readonly StringName GetLicenseText = "get_license_text";
        /// <summary>
        /// Cached name for the 'get_architecture_name' method.
        /// </summary>
        public static readonly StringName GetArchitectureName = "get_architecture_name";
        /// <summary>
        /// Cached name for the 'is_in_physics_frame' method.
        /// </summary>
        public static readonly StringName IsInPhysicsFrame = "is_in_physics_frame";
        /// <summary>
        /// Cached name for the 'has_singleton' method.
        /// </summary>
        public static readonly StringName HasSingleton = "has_singleton";
        /// <summary>
        /// Cached name for the 'get_singleton' method.
        /// </summary>
        public static readonly StringName GetSingleton = "get_singleton";
        /// <summary>
        /// Cached name for the 'register_singleton' method.
        /// </summary>
        public static readonly StringName RegisterSingleton = "register_singleton";
        /// <summary>
        /// Cached name for the 'unregister_singleton' method.
        /// </summary>
        public static readonly StringName UnregisterSingleton = "unregister_singleton";
        /// <summary>
        /// Cached name for the 'get_singleton_list' method.
        /// </summary>
        public static readonly StringName GetSingletonList = "get_singleton_list";
        /// <summary>
        /// Cached name for the 'register_script_language' method.
        /// </summary>
        public static readonly StringName RegisterScriptLanguage = "register_script_language";
        /// <summary>
        /// Cached name for the 'unregister_script_language' method.
        /// </summary>
        public static readonly StringName UnregisterScriptLanguage = "unregister_script_language";
        /// <summary>
        /// Cached name for the 'get_script_language_count' method.
        /// </summary>
        public static readonly StringName GetScriptLanguageCount = "get_script_language_count";
        /// <summary>
        /// Cached name for the 'get_script_language' method.
        /// </summary>
        public static readonly StringName GetScriptLanguage = "get_script_language";
        /// <summary>
        /// Cached name for the 'capture_script_backtraces' method.
        /// </summary>
        public static readonly StringName CaptureScriptBacktraces = "capture_script_backtraces";
        /// <summary>
        /// Cached name for the 'is_editor_hint' method.
        /// </summary>
        public static readonly StringName IsEditorHint = "is_editor_hint";
        /// <summary>
        /// Cached name for the 'is_embedded_in_editor' method.
        /// </summary>
        public static readonly StringName IsEmbeddedInEditor = "is_embedded_in_editor";
        /// <summary>
        /// Cached name for the 'get_write_movie_path' method.
        /// </summary>
        public static readonly StringName GetWriteMoviePath = "get_write_movie_path";
        /// <summary>
        /// Cached name for the 'set_print_to_stdout' method.
        /// </summary>
        public static readonly StringName SetPrintToStdOut = "set_print_to_stdout";
        /// <summary>
        /// Cached name for the 'is_printing_to_stdout' method.
        /// </summary>
        public static readonly StringName IsPrintingToStdOut = "is_printing_to_stdout";
        /// <summary>
        /// Cached name for the 'set_print_error_messages' method.
        /// </summary>
        public static readonly StringName SetPrintErrorMessages = "set_print_error_messages";
        /// <summary>
        /// Cached name for the 'is_printing_error_messages' method.
        /// </summary>
        public static readonly StringName IsPrintingErrorMessages = "is_printing_error_messages";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
