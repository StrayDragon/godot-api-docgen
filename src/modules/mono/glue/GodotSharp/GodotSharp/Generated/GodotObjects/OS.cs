namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.OS"/> class wraps the most common functionalities for communicating with the host operating system, such as the video driver, delays, environment variables, execution of binaries, command line, etc.</para>
/// <para><b>Note:</b> In Godot 4, <see cref="Godot.OS"/> functions related to window management, clipboard, and TTS were moved to the <see cref="Godot.DisplayServer"/> singleton (and the <see cref="Godot.Window"/> class). Functions related to time were removed and are only available in the <see cref="Godot.Time"/> class.</para>
/// </summary>
public static partial class OS
{
    public enum RenderingDriver : long
    {
        /// <summary>
        /// <para>The Vulkan rendering driver. It requires Vulkan 1.0 support and automatically uses features from Vulkan 1.1 and 1.2 if available.</para>
        /// </summary>
        Vulkan = 0,
        /// <summary>
        /// <para>The OpenGL 3 rendering driver. It uses OpenGL 3.3 Core Profile on desktop platforms, OpenGL ES 3.0 on mobile devices, and WebGL 2.0 on Web.</para>
        /// </summary>
        Opengl3 = 1,
        /// <summary>
        /// <para>The Direct3D 12 rendering driver.</para>
        /// </summary>
        D3D12 = 2,
        /// <summary>
        /// <para>The Metal rendering driver.</para>
        /// </summary>
        Metal = 3
    }

    public enum SystemDir : long
    {
        /// <summary>
        /// <para>Refers to the Desktop directory path.</para>
        /// </summary>
        Desktop = 0,
        /// <summary>
        /// <para>Refers to the DCIM (Digital Camera Images) directory path.</para>
        /// </summary>
        Dcim = 1,
        /// <summary>
        /// <para>Refers to the Documents directory path.</para>
        /// </summary>
        Documents = 2,
        /// <summary>
        /// <para>Refers to the Downloads directory path.</para>
        /// </summary>
        Downloads = 3,
        /// <summary>
        /// <para>Refers to the Movies (or Videos) directory path.</para>
        /// </summary>
        Movies = 4,
        /// <summary>
        /// <para>Refers to the Music directory path.</para>
        /// </summary>
        Music = 5,
        /// <summary>
        /// <para>Refers to the Pictures directory path.</para>
        /// </summary>
        Pictures = 6,
        /// <summary>
        /// <para>Refers to the Ringtones directory path.</para>
        /// </summary>
        Ringtones = 7
    }

    public enum StdHandleType : long
    {
        /// <summary>
        /// <para>Standard I/O device is invalid. No data can be received from or sent to these standard I/O devices.</para>
        /// </summary>
        Invalid = 0,
        /// <summary>
        /// <para>Standard I/O device is a console. This typically occurs when Godot is run from a terminal with no redirection. This is also used for all standard I/O devices when running Godot from the editor, at least on desktop platforms.</para>
        /// </summary>
        Console = 1,
        /// <summary>
        /// <para>Standard I/O device is a regular file. This typically occurs with redirection from a terminal, e.g. <c>godot &gt; stdout.txt</c>, <c>godot &lt; stdin.txt</c> or <c>godot &gt; stdout_stderr.txt 2&gt;&amp;1</c>.</para>
        /// </summary>
        File = 2,
        /// <summary>
        /// <para>Standard I/O device is a FIFO/pipe. This typically occurs with pipe usage from a terminal, e.g. <c>echo "Hello" | godot</c>.</para>
        /// </summary>
        Pipe = 3,
        /// <summary>
        /// <para>Standard I/O device type is unknown.</para>
        /// </summary>
        Unknown = 4
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the engine optimizes for low processor usage by only refreshing the screen if needed. Can improve battery consumption on mobile.</para>
    /// <para><b>Note:</b> On start-up, this is the same as <c>ProjectSettings.application/run/low_processor_mode</c>.</para>
    /// </summary>
    public static bool LowProcessorUsageMode
    {
        get
        {
            return IsInLowProcessorUsageMode();
        }
        set
        {
            SetLowProcessorUsageMode(value);
        }
    }

    /// <summary>
    /// <para>The amount of sleeping between frames when the low-processor usage mode is enabled, in microseconds. Higher values will result in lower CPU usage. See also <see cref="Godot.OS.LowProcessorUsageMode"/>.</para>
    /// <para><b>Note:</b> On start-up, this is the same as <c>ProjectSettings.application/run/low_processor_mode_sleep_usec</c>.</para>
    /// </summary>
    public static int LowProcessorUsageModeSleepUsec
    {
        get
        {
            return GetLowProcessorUsageModeSleepUsec();
        }
        set
        {
            SetLowProcessorUsageModeSleepUsec(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the engine filters the time delta measured between each frame, and attempts to compensate for random variation. This only works on systems where V-Sync is active.</para>
    /// <para><b>Note:</b> On start-up, this is the same as <c>ProjectSettings.application/run/delta_smoothing</c>.</para>
    /// </summary>
    public static bool DeltaSmoothing
    {
        get
        {
            return IsDeltaSmoothingEnabled();
        }
        set
        {
            SetDeltaSmoothing(value);
        }
    }

    private static readonly StringName NativeName = "OS";

    private static OSInstance singleton;

    public static OSInstance Singleton =>
        singleton ??= (OSInstance)InteropUtils.EngineGetSingleton("OS");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEntropy, 47165747ul);

    /// <summary>
    /// <para>Generates a <see cref="byte"/>[] of cryptographically secure random bytes with given <paramref name="size"/>.</para>
    /// <para><b>Note:</b> Generating large quantities of bytes using this method can result in locking and entropy of lower quality on most platforms. Using <see cref="Godot.Crypto.GenerateRandomBytes(int)"/> is preferred in most cases.</para>
    /// </summary>
    public static byte[] GetEntropy(int size)
    {
        return NativeCalls.godot_icall_1_343(MethodBind0, GodotObject.GetPtr(Singleton), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemCaCertificates, 2841200299ul);

    /// <summary>
    /// <para>Returns the list of certification authorities trusted by the operating system as a string of concatenated certificates in PEM format.</para>
    /// </summary>
    public static string GetSystemCaCertificates()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectedMidiInputs, 2981934095ul);

    /// <summary>
    /// <para>Returns an array of connected MIDI device names, if they exist. Returns an empty array if the system MIDI driver has not previously been initialized with <see cref="Godot.OS.OpenMidiInputs()"/>. See also <see cref="Godot.OS.CloseMidiInputs()"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, Windows, and Web.</para>
    /// <para><b>Note:</b> On the Web platform, Web MIDI needs to be supported by the browser. <a href="https://caniuse.com/midi">For the time being</a>, it is currently supported by all major browsers, except Safari.</para>
    /// <para><b>Note:</b> On the Web platform, using MIDI input requires a browser permission to be granted first. This permission request is performed when calling <see cref="Godot.OS.OpenMidiInputs()"/>. The browser will refrain from processing MIDI input until the user accepts the permission request.</para>
    /// </summary>
    public static string[] GetConnectedMidiInputs()
    {
        return NativeCalls.godot_icall_0_108(MethodBind2, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenMidiInputs, 3218959716ul);

    /// <summary>
    /// <para>Initializes the singleton for the system MIDI driver, allowing Godot to receive <see cref="Godot.InputEventMidi"/>. See also <see cref="Godot.OS.GetConnectedMidiInputs()"/> and <see cref="Godot.OS.CloseMidiInputs()"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, Windows, and Web.</para>
    /// <para><b>Note:</b> On the Web platform, Web MIDI needs to be supported by the browser. <a href="https://caniuse.com/midi">For the time being</a>, it is currently supported by all major browsers, except Safari.</para>
    /// <para><b>Note:</b> On the Web platform, using MIDI input requires a browser permission to be granted first. This permission request is performed when calling <see cref="Godot.OS.OpenMidiInputs()"/>. The browser will refrain from processing MIDI input until the user accepts the permission request.</para>
    /// </summary>
    public static void OpenMidiInputs()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CloseMidiInputs, 3218959716ul);

    /// <summary>
    /// <para>Shuts down the system MIDI driver. Godot will no longer receive <see cref="Godot.InputEventMidi"/>. See also <see cref="Godot.OS.OpenMidiInputs()"/> and <see cref="Godot.OS.GetConnectedMidiInputs()"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, Windows, and Web.</para>
    /// </summary>
    public static void CloseMidiInputs()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Alert, 1783970740ul);

    /// <summary>
    /// <para>Displays a modal dialog box using the host platform's implementation. The engine execution is blocked until the dialog is closed.</para>
    /// </summary>
    public static void Alert(string text, string title = "Alert!")
    {
        NativeCalls.godot_icall_2_303(MethodBind5, GodotObject.GetPtr(Singleton), text, title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Crash, 83702148ul);

    /// <summary>
    /// <para>Crashes the engine (or the editor if called within a <c>@tool</c> script). See also <see cref="Godot.OS.Kill(int)"/>.</para>
    /// <para><b>Note:</b> This method should <i>only</i> be used for testing the system's crash handler, not for any other purpose. For general error reporting, use (in order of preference) <c>@GDScript.assert</c>, <c>@GlobalScope.push_error</c>, or <see cref="Godot.OS.Alert(string, string)"/>.</para>
    /// </summary>
    public static void Crash(string message)
    {
        NativeCalls.godot_icall_1_57(MethodBind6, GodotObject.GetPtr(Singleton), message);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLowProcessorUsageMode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetLowProcessorUsageMode(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInLowProcessorUsageMode, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsInLowProcessorUsageMode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLowProcessorUsageModeSleepUsec, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetLowProcessorUsageModeSleepUsec(int usec)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(Singleton), usec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLowProcessorUsageModeSleepUsec, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int GetLowProcessorUsageModeSleepUsec()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeltaSmoothing, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetDeltaSmoothing(bool deltaSmoothingEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(Singleton), deltaSmoothingEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDeltaSmoothingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsDeltaSmoothingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessorCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of <i>logical</i> CPU cores available on the host machine. On CPUs with HyperThreading enabled, this number will be greater than the number of <i>physical</i> CPU cores.</para>
    /// </summary>
    public static int GetProcessorCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessorName, 201670096ul);

    /// <summary>
    /// <para>Returns the full name of the CPU model on the host machine (e.g. <c>"Intel(R) Core(TM) i7-6700K CPU @ 4.00GHz"</c>).</para>
    /// <para><b>Note:</b> This method is only implemented on Windows, macOS, Linux and iOS. On Android and Web, <see cref="Godot.OS.GetProcessorName()"/> returns an empty string.</para>
    /// </summary>
    public static string GetProcessorName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind14, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemFonts, 1139954409ul);

    /// <summary>
    /// <para>Returns the list of font family names available.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Linux, macOS and Windows.</para>
    /// </summary>
    public static string[] GetSystemFonts()
    {
        return NativeCalls.godot_icall_0_108(MethodBind15, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemFontPath, 626580860ul);

    /// <summary>
    /// <para>Returns the path to the system font file with <paramref name="fontName"/> and style. Returns an empty string if no matching fonts found.</para>
    /// <para>The following aliases can be used to request default fonts: "sans-serif", "serif", "monospace", "cursive", and "fantasy".</para>
    /// <para><b>Note:</b> Returned font might have different style if the requested style is not available.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Linux, macOS and Windows.</para>
    /// </summary>
    public static string GetSystemFontPath(string fontName, int weight = 400, int stretch = 100, bool italic = false)
    {
        return NativeCalls.godot_icall_4_906(MethodBind16, GodotObject.GetPtr(Singleton), fontName, weight, stretch, italic.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemFontPathForText, 197317981ul);

    /// <summary>
    /// <para>Returns an array of the system substitute font file paths, which are similar to the font with <paramref name="fontName"/> and style for the specified text, locale, and script. Returns an empty array if no matching fonts found.</para>
    /// <para>The following aliases can be used to request default fonts: "sans-serif", "serif", "monospace", "cursive", and "fantasy".</para>
    /// <para><b>Note:</b> Depending on OS, it's not guaranteed that any of the returned fonts will be suitable for rendering specified text. Fonts should be loaded and checked in the order they are returned, and the first suitable one used.</para>
    /// <para><b>Note:</b> Returned fonts might have different style if the requested style is not available or belong to a different font family.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Linux, macOS and Windows.</para>
    /// </summary>
    public static string[] GetSystemFontPathForText(string fontName, string text, string locale = "", string script = "", int weight = 400, int stretch = 100, bool italic = false)
    {
        return NativeCalls.godot_icall_7_907(MethodBind17, GodotObject.GetPtr(Singleton), fontName, text, locale, script, weight, stretch, italic.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExecutablePath, 201670096ul);

    /// <summary>
    /// <para>Returns the file path to the current engine executable.</para>
    /// <para><b>Note:</b> On macOS, if you want to launch another instance of Godot, always use <see cref="Godot.OS.CreateInstance(string[])"/> instead of relying on the executable path.</para>
    /// </summary>
    public static string GetExecutablePath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind18, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReadStringFromStdIn, 723587915ul);

    /// <summary>
    /// <para>Reads a user input as a UTF-8 encoded string from the standard input. This operation can be <i>blocking</i>, which causes the window to freeze if <see cref="Godot.OS.ReadStringFromStdIn(long)"/> is called on the main thread.</para>
    /// <para>- If standard input is console, this method will block until the program receives a line break in standard input (usually by the user pressing Enter).</para>
    /// <para>- If standard input is pipe, this method will block until a specific amount of data is read or pipe is closed.</para>
    /// <para>- If standard input is a file, this method will read a specific amount of data (or less if end-of-file is reached) and return immediately.</para>
    /// <para><b>Note:</b> This method automatically replaces <c>\r\n</c> line breaks with <c>\n</c> and removes them from the end of the string. Use <see cref="Godot.OS.ReadBufferFromStdIn(long)"/> to read the unprocessed data.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> On exported Windows builds, run the console wrapper executable to access the terminal. If standard input is console, calling this method without console wrapped will freeze permanently. If standard input is pipe or file, it can be used without console wrapper. If you need a single executable with full console support, use a custom build compiled with the <c>windows_subsystem=console</c> flag.</para>
    /// </summary>
    public static string ReadStringFromStdIn(long bufferSize = (long)(1024))
    {
        return NativeCalls.godot_icall_1_908(MethodBind19, GodotObject.GetPtr(Singleton), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReadBufferFromStdIn, 3249455752ul);

    /// <summary>
    /// <para>Reads a user input as raw data from the standard input. This operation can be <i>blocking</i>, which causes the window to freeze if <see cref="Godot.OS.ReadBufferFromStdIn(long)"/> is called on the main thread.</para>
    /// <para>- If standard input is console, this method will block until the program receives a line break in standard input (usually by the user pressing Enter).</para>
    /// <para>- If standard input is pipe, this method will block until a specific amount of data is read or pipe is closed.</para>
    /// <para>- If standard input is a file, this method will read a specific amount of data (or less if end-of-file is reached) and return immediately.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> On exported Windows builds, run the console wrapper executable to access the terminal. If standard input is console, calling this method without console wrapped will freeze permanently. If standard input is pipe or file, it can be used without console wrapper. If you need a single executable with full console support, use a custom build compiled with the <c>windows_subsystem=console</c> flag.</para>
    /// </summary>
    public static byte[] ReadBufferFromStdIn(long bufferSize = (long)(1024))
    {
        return NativeCalls.godot_icall_1_563(MethodBind20, GodotObject.GetPtr(Singleton), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStdInType, 1704816237ul);

    /// <summary>
    /// <para>Returns the type of the standard input device.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> On exported Windows builds, run the console wrapper executable to access the standard input. If you need a single executable with full console support, use a custom build compiled with the <c>windows_subsystem=console</c> flag.</para>
    /// </summary>
    public static OS.StdHandleType GetStdInType()
    {
        return (OS.StdHandleType)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStdOutType, 1704816237ul);

    /// <summary>
    /// <para>Returns the type of the standard output device.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// </summary>
    public static OS.StdHandleType GetStdOutType()
    {
        return (OS.StdHandleType)NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStderrType, 1704816237ul);

    /// <summary>
    /// <para>Returns the type of the standard error device.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// </summary>
    public static OS.StdHandleType GetStderrType()
    {
        return (OS.StdHandleType)NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Execute, 1488299882ul);

    /// <summary>
    /// <para>Executes the given process in a <i>blocking</i> way. The file specified in <paramref name="path"/> must exist and be executable. The system path resolution will be used. The <paramref name="arguments"/> are used in the given order, separated by spaces, and wrapped in quotes.</para>
    /// <para>If an <paramref name="output"/> array is provided, the complete shell output of the process is appended to <paramref name="output"/> as a single <see cref="string"/> element. If <paramref name="readStderr"/> is <see langword="true"/>, the output to the standard error stream is also appended to the array.</para>
    /// <para>On Windows, if <paramref name="openConsole"/> is <see langword="true"/> and the process is a console app, a new terminal window is opened.</para>
    /// <para>This method returns the exit code of the command, or <c>-1</c> if the process fails to execute.</para>
    /// <para><b>Note:</b> The main thread will be blocked until the executed command terminates. Use <see cref="Godot.GodotThread"/> to create a separate thread that will not block the main thread, or use <see cref="Godot.OS.CreateProcess(string, string[], bool)"/> to create a completely independent process.</para>
    /// <para>For example, to retrieve a list of the working directory's contents:</para>
    /// <para><code>
    /// Godot.Collections.Array output = [];
    /// int exitCode = OS.Execute("ls", ["-l", "/tmp"], output);
    /// </code></para>
    /// <para>If you wish to access a shell built-in or execute a composite command, a platform-specific shell can be invoked. For example:</para>
    /// <para><code>
    /// Godot.Collections.Array output = [];
    /// OS.Execute("CMD.exe", ["/C", "cd %TEMP% &amp;&amp; dir"], output);
    /// </code></para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> To execute a Windows command interpreter built-in command, specify <c>cmd.exe</c> in <paramref name="path"/>, <c>/c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a PowerShell built-in command, specify <c>powershell.exe</c> in <paramref name="path"/>, <c>-Command</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a Unix shell built-in command, specify shell executable name in <paramref name="path"/>, <c>-c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export.</para>
    /// <para><b>Note:</b> On Android, system commands such as <c>dumpsys</c> can only be run on a rooted device.</para>
    /// </summary>
    public static int Execute(string path, string[] arguments, Godot.Collections.Array output = null, bool readStderr = false, bool openConsole = false)
    {
        return NativeCalls.godot_icall_5_909(MethodBind24, GodotObject.GetPtr(Singleton), path, arguments, (godot_array)(output ?? new()).NativeValue, readStderr.ToGodotBool(), openConsole.ToGodotBool());
    }

    /// <summary>
    /// <para>Executes the given process in a <i>blocking</i> way. The file specified in <paramref name="path"/> must exist and be executable. The system path resolution will be used. The <paramref name="arguments"/> are used in the given order, separated by spaces, and wrapped in quotes.</para>
    /// <para>If an <paramref name="output"/> array is provided, the complete shell output of the process is appended to <paramref name="output"/> as a single <see cref="string"/> element. If <paramref name="readStderr"/> is <see langword="true"/>, the output to the standard error stream is also appended to the array.</para>
    /// <para>On Windows, if <paramref name="openConsole"/> is <see langword="true"/> and the process is a console app, a new terminal window is opened.</para>
    /// <para>This method returns the exit code of the command, or <c>-1</c> if the process fails to execute.</para>
    /// <para><b>Note:</b> The main thread will be blocked until the executed command terminates. Use <see cref="Godot.GodotThread"/> to create a separate thread that will not block the main thread, or use <see cref="Godot.OS.CreateProcess(string, string[], bool)"/> to create a completely independent process.</para>
    /// <para>For example, to retrieve a list of the working directory's contents:</para>
    /// <para><code>
    /// Godot.Collections.Array output = [];
    /// int exitCode = OS.Execute("ls", ["-l", "/tmp"], output);
    /// </code></para>
    /// <para>If you wish to access a shell built-in or execute a composite command, a platform-specific shell can be invoked. For example:</para>
    /// <para><code>
    /// Godot.Collections.Array output = [];
    /// OS.Execute("CMD.exe", ["/C", "cd %TEMP% &amp;&amp; dir"], output);
    /// </code></para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> To execute a Windows command interpreter built-in command, specify <c>cmd.exe</c> in <paramref name="path"/>, <c>/c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a PowerShell built-in command, specify <c>powershell.exe</c> in <paramref name="path"/>, <c>-Command</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a Unix shell built-in command, specify shell executable name in <paramref name="path"/>, <c>-c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export.</para>
    /// <para><b>Note:</b> On Android, system commands such as <c>dumpsys</c> can only be run on a rooted device.</para>
    /// </summary>
    public static int Execute(string path, ReadOnlySpan<string> arguments, Godot.Collections.Array output, bool readStderr, bool openConsole)
    {
        return NativeCalls.godot_icall_5_909(MethodBind24, GodotObject.GetPtr(Singleton), path, arguments, (godot_array)(output ?? new()).NativeValue, readStderr.ToGodotBool(), openConsole.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ExecuteWithPipe, 2851312030ul);

    /// <summary>
    /// <para>Creates a new process that runs independently of Godot with redirected IO. It will not terminate when Godot terminates. The path specified in <paramref name="path"/> must exist and be an executable file or macOS <c>.app</c> bundle. The path is resolved based on the current platform. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>If <paramref name="blocking"/> is <see langword="false"/>, created pipes work in non-blocking mode, i.e. read and write operations will return immediately. Use <see cref="Godot.FileAccess.GetError()"/> to check if the last read/write operation was successful.</para>
    /// <para>If the process cannot be created, this method returns an empty <see cref="Godot.Collections.Dictionary"/>. Otherwise, this method returns a <see cref="Godot.Collections.Dictionary"/> with the following keys:</para>
    /// <para>- <c>"stdio"</c> - <see cref="Godot.FileAccess"/> to access the process stdin and stdout pipes (read/write).</para>
    /// <para>- <c>"stderr"</c> - <see cref="Godot.FileAccess"/> to access the process stderr pipe (read only).</para>
    /// <para>- <c>"pid"</c> - Process ID as an <see cref="int"/>, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>).</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> To execute a Windows command interpreter built-in command, specify <c>cmd.exe</c> in <paramref name="path"/>, <c>/c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a PowerShell built-in command, specify <c>powershell.exe</c> in <paramref name="path"/>, <c>-Command</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a Unix shell built-in command, specify shell executable name in <paramref name="path"/>, <c>-c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export or system .app bundle, system .app bundles will ignore arguments.</para>
    /// </summary>
    public static Godot.Collections.Dictionary ExecuteWithPipe(string path, string[] arguments, bool blocking = true)
    {
        return NativeCalls.godot_icall_3_910(MethodBind25, GodotObject.GetPtr(Singleton), path, arguments, blocking.ToGodotBool());
    }

    /// <summary>
    /// <para>Creates a new process that runs independently of Godot with redirected IO. It will not terminate when Godot terminates. The path specified in <paramref name="path"/> must exist and be an executable file or macOS <c>.app</c> bundle. The path is resolved based on the current platform. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>If <paramref name="blocking"/> is <see langword="false"/>, created pipes work in non-blocking mode, i.e. read and write operations will return immediately. Use <see cref="Godot.FileAccess.GetError()"/> to check if the last read/write operation was successful.</para>
    /// <para>If the process cannot be created, this method returns an empty <see cref="Godot.Collections.Dictionary"/>. Otherwise, this method returns a <see cref="Godot.Collections.Dictionary"/> with the following keys:</para>
    /// <para>- <c>"stdio"</c> - <see cref="Godot.FileAccess"/> to access the process stdin and stdout pipes (read/write).</para>
    /// <para>- <c>"stderr"</c> - <see cref="Godot.FileAccess"/> to access the process stderr pipe (read only).</para>
    /// <para>- <c>"pid"</c> - Process ID as an <see cref="int"/>, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>).</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> To execute a Windows command interpreter built-in command, specify <c>cmd.exe</c> in <paramref name="path"/>, <c>/c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a PowerShell built-in command, specify <c>powershell.exe</c> in <paramref name="path"/>, <c>-Command</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a Unix shell built-in command, specify shell executable name in <paramref name="path"/>, <c>-c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export or system .app bundle, system .app bundles will ignore arguments.</para>
    /// </summary>
    public static Godot.Collections.Dictionary ExecuteWithPipe(string path, ReadOnlySpan<string> arguments, bool blocking)
    {
        return NativeCalls.godot_icall_3_910(MethodBind25, GodotObject.GetPtr(Singleton), path, arguments, blocking.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateProcess, 2903767230ul);

    /// <summary>
    /// <para>Creates a new process that runs independently of Godot. It will not terminate when Godot terminates. The path specified in <paramref name="path"/> must exist and be an executable file or macOS <c>.app</c> bundle. The path is resolved based on the current platform. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>On Windows, if <paramref name="openConsole"/> is <see langword="true"/> and the process is a console app, a new terminal window will be opened.</para>
    /// <para>If the process is successfully created, this method returns its process ID, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>). Otherwise, this method returns <c>-1</c>.</para>
    /// <para><b>Example:</b> Run another instance of the project:</para>
    /// <para><code>
    /// var pid = OS.CreateProcess(OS.GetExecutablePath(), []);
    /// </code></para>
    /// <para>See <see cref="Godot.OS.Execute(string, string[], Godot.Collections.Array, bool, bool)"/> if you wish to run an external command and retrieve the results.</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export or system .app bundle, system .app bundles will ignore arguments.</para>
    /// </summary>
    public static int CreateProcess(string path, string[] arguments, bool openConsole = false)
    {
        return NativeCalls.godot_icall_3_911(MethodBind26, GodotObject.GetPtr(Singleton), path, arguments, openConsole.ToGodotBool());
    }

    /// <summary>
    /// <para>Creates a new process that runs independently of Godot. It will not terminate when Godot terminates. The path specified in <paramref name="path"/> must exist and be an executable file or macOS <c>.app</c> bundle. The path is resolved based on the current platform. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>On Windows, if <paramref name="openConsole"/> is <see langword="true"/> and the process is a console app, a new terminal window will be opened.</para>
    /// <para>If the process is successfully created, this method returns its process ID, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>). Otherwise, this method returns <c>-1</c>.</para>
    /// <para><b>Example:</b> Run another instance of the project:</para>
    /// <para><code>
    /// var pid = OS.CreateProcess(OS.GetExecutablePath(), []);
    /// </code></para>
    /// <para>See <see cref="Godot.OS.Execute(string, string[], Godot.Collections.Array, bool, bool)"/> if you wish to run an external command and retrieve the results.</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export or system .app bundle, system .app bundles will ignore arguments.</para>
    /// </summary>
    public static int CreateProcess(string path, ReadOnlySpan<string> arguments, bool openConsole)
    {
        return NativeCalls.godot_icall_3_911(MethodBind26, GodotObject.GetPtr(Singleton), path, arguments, openConsole.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateInstance, 1080601263ul);

    /// <summary>
    /// <para>Creates a new instance of Godot that runs independently. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>If the process is successfully created, this method returns the new process' ID, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>). If the process cannot be created, this method returns <c>-1</c>.</para>
    /// <para>See <see cref="Godot.OS.CreateProcess(string, string[], bool)"/> if you wish to run a different process.</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS and Windows.</para>
    /// </summary>
    public static int CreateInstance(string[] arguments)
    {
        return NativeCalls.godot_icall_1_912(MethodBind27, GodotObject.GetPtr(Singleton), arguments);
    }

    /// <summary>
    /// <para>Creates a new instance of Godot that runs independently. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>If the process is successfully created, this method returns the new process' ID, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>). If the process cannot be created, this method returns <c>-1</c>.</para>
    /// <para>See <see cref="Godot.OS.CreateProcess(string, string[], bool)"/> if you wish to run a different process.</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS and Windows.</para>
    /// </summary>
    public static int CreateInstance(ReadOnlySpan<string> arguments)
    {
        return NativeCalls.godot_icall_1_912(MethodBind27, GodotObject.GetPtr(Singleton), arguments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenWithProgram, 2848259907ul);

    /// <summary>
    /// <para>Opens one or more files/directories with the specified application. The <paramref name="programPath"/> specifies the path to the application to use for opening the files, and <paramref name="paths"/> contains an array of file/directory paths to open.</para>
    /// <para><b>Note:</b> This method is mostly only relevant for macOS, where opening files using <see cref="Godot.OS.CreateProcess(string, string[], bool)"/> might fail. On other platforms, this falls back to using <see cref="Godot.OS.CreateProcess(string, string[], bool)"/>.</para>
    /// <para><b>Note:</b> On macOS, <paramref name="programPath"/> should ideally be the path to a <c>.app</c> bundle.</para>
    /// </summary>
    public static Error OpenWithProgram(string programPath, string[] paths)
    {
        return (Error)NativeCalls.godot_icall_2_553(MethodBind28, GodotObject.GetPtr(Singleton), programPath, paths);
    }

    /// <summary>
    /// <para>Opens one or more files/directories with the specified application. The <paramref name="programPath"/> specifies the path to the application to use for opening the files, and <paramref name="paths"/> contains an array of file/directory paths to open.</para>
    /// <para><b>Note:</b> This method is mostly only relevant for macOS, where opening files using <see cref="Godot.OS.CreateProcess(string, string[], bool)"/> might fail. On other platforms, this falls back to using <see cref="Godot.OS.CreateProcess(string, string[], bool)"/>.</para>
    /// <para><b>Note:</b> On macOS, <paramref name="programPath"/> should ideally be the path to a <c>.app</c> bundle.</para>
    /// </summary>
    public static Error OpenWithProgram(string programPath, ReadOnlySpan<string> paths)
    {
        return (Error)NativeCalls.godot_icall_2_553(MethodBind28, GodotObject.GetPtr(Singleton), programPath, paths);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Kill, 844576869ul);

    /// <summary>
    /// <para>Kill (terminate) the process identified by the given process ID (<paramref name="pid"/>), such as the ID returned by <see cref="Godot.OS.Execute(string, string[], Godot.Collections.Array, bool, bool)"/> in non-blocking mode. See also <see cref="Godot.OS.Crash(string)"/>.</para>
    /// <para><b>Note:</b> This method can also be used to kill processes that were not spawned by the engine.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Linux, macOS and Windows.</para>
    /// </summary>
    public static Error Kill(int pid)
    {
        return (Error)NativeCalls.godot_icall_1_60(MethodBind29, GodotObject.GetPtr(Singleton), pid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShellOpen, 166001499ul);

    /// <summary>
    /// <para>Requests the OS to open a resource identified by <paramref name="uri"/> with the most appropriate program. For example:</para>
    /// <para>- <c>OS.shell_open("C:\\Users\\name\\Downloads")</c> on Windows opens the file explorer at the user's Downloads folder.</para>
    /// <para>- <c>OS.shell_open("C:/Users/name/Downloads")</c> also works on Windows and opens the file explorer at the user's Downloads folder.</para>
    /// <para>- <c>OS.shell_open("https://godotengine.org")</c> opens the default web browser on the official Godot website.</para>
    /// <para>- <c>OS.shell_open("mailto:example@example.com")</c> opens the default email client with the "To" field set to <c>example@example.com</c>. See <a href="https://datatracker.ietf.org/doc/html/rfc2368">RFC 2368 - The <c>mailto</c> URL scheme</a> for a list of fields that can be added.</para>
    /// <para>Use <see cref="Godot.ProjectSettings.GlobalizePath(string)"/> to convert a <c>res://</c> or <c>user://</c> project path into a system path for use with this method.</para>
    /// <para><b>Note:</b> Use <c>String.uri_encode</c> to encode characters within URLs in a URL-safe, portable way. This is especially required for line breaks. Otherwise, <see cref="Godot.OS.ShellOpen(string)"/> may not work correctly in a project exported to the Web platform.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux, macOS and Windows.</para>
    /// </summary>
    public static Error ShellOpen(string uri)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind30, GodotObject.GetPtr(Singleton), uri);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShellShowInFileManager, 3565188097ul);

    /// <summary>
    /// <para>Requests the OS to open the file manager, navigate to the given <paramref name="fileOrDirPath"/> and select the target file or folder.</para>
    /// <para>If <paramref name="openFolder"/> is <see langword="true"/> and <paramref name="fileOrDirPath"/> is a valid directory path, the OS will open the file manager and navigate to the target folder without selecting anything.</para>
    /// <para>Use <see cref="Godot.ProjectSettings.GlobalizePath(string)"/> to convert a <c>res://</c> or <c>user://</c> project path into a system path to use with this method.</para>
    /// <para><b>Note:</b> This method is currently only implemented on Windows and macOS. On other platforms, it will fallback to <see cref="Godot.OS.ShellOpen(string)"/> with a directory path of <paramref name="fileOrDirPath"/> prefixed with <c>file://</c>.</para>
    /// </summary>
    public static Error ShellShowInFileManager(string fileOrDirPath, bool openFolder = true)
    {
        return (Error)NativeCalls.godot_icall_2_350(MethodBind31, GodotObject.GetPtr(Singleton), fileOrDirPath, openFolder.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessRunning, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the child process ID (<paramref name="pid"/>) is still running or <see langword="false"/> if it has terminated. <paramref name="pid"/> must be a valid ID generated from <see cref="Godot.OS.CreateProcess(string, string[], bool)"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Linux, macOS, and Windows.</para>
    /// </summary>
    public static bool IsProcessRunning(int pid)
    {
        return NativeCalls.godot_icall_1_62(MethodBind32, GodotObject.GetPtr(Singleton), pid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessExitCode, 923996154ul);

    /// <summary>
    /// <para>Returns the exit code of a spawned process once it has finished running (see <see cref="Godot.OS.IsProcessRunning(int)"/>).</para>
    /// <para>Returns <c>-1</c> if the <paramref name="pid"/> is not a PID of a spawned child process, the process is still running, or the method is not implemented for the current platform.</para>
    /// <para><b>Note:</b> Returns <c>-1</c> if the <paramref name="pid"/> is a macOS bundled app process.</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS and Windows.</para>
    /// </summary>
    public static int GetProcessExitCode(int pid)
    {
        return NativeCalls.godot_icall_1_60(MethodBind33, GodotObject.GetPtr(Singleton), pid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessId, 3905245786ul);

    /// <summary>
    /// <para>Returns the number used by the host machine to uniquely identify this application.</para>
    /// <para><b>Note:</b> On Web, this method always returns <c>0</c>.</para>
    /// </summary>
    public static int GetProcessId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind34, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasEnvironment, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the environment variable with the name <paramref name="variable"/> exists.</para>
    /// <para><b>Note:</b> Double-check the casing of <paramref name="variable"/>. Environment variable names are case-sensitive on all platforms except Windows.</para>
    /// </summary>
    public static bool HasEnvironment(string variable)
    {
        return NativeCalls.godot_icall_1_131(MethodBind35, GodotObject.GetPtr(Singleton), variable).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironment, 3135753539ul);

    /// <summary>
    /// <para>Returns the value of the given environment variable, or an empty string if <paramref name="variable"/> doesn't exist.</para>
    /// <para><b>Note:</b> Double-check the casing of <paramref name="variable"/>. Environment variable names are case-sensitive on all platforms except Windows.</para>
    /// <para><b>Note:</b> On macOS, applications do not have access to shell environment variables.</para>
    /// </summary>
    public static string GetEnvironment(string variable)
    {
        return NativeCalls.godot_icall_1_304(MethodBind36, GodotObject.GetPtr(Singleton), variable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironment, 3605043004ul);

    /// <summary>
    /// <para>Sets the value of the environment variable <paramref name="variable"/> to <paramref name="value"/>. The environment variable will be set for the Godot process and any process executed with <see cref="Godot.OS.Execute(string, string[], Godot.Collections.Array, bool, bool)"/> after running <see cref="Godot.OS.SetEnvironment(string, string)"/>. The environment variable will <i>not</i> persist to processes run after the Godot process was terminated.</para>
    /// <para><b>Note:</b> Environment variable names are case-sensitive on all platforms except Windows. The <paramref name="variable"/> name cannot be empty or include the <c>=</c> character. On Windows, there is a 32767 characters limit for the combined length of <paramref name="variable"/>, <paramref name="value"/>, and the <c>=</c> and null terminator characters that will be registered in the environment block.</para>
    /// </summary>
    public static void SetEnvironment(string variable, string value)
    {
        NativeCalls.godot_icall_2_303(MethodBind37, GodotObject.GetPtr(Singleton), variable, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.UnsetEnvironment, 3089850668ul);

    /// <summary>
    /// <para>Removes the given environment variable from the current environment, if it exists. The <paramref name="variable"/> name cannot be empty or include the <c>=</c> character. The environment variable will be removed for the Godot process and any process executed with <see cref="Godot.OS.Execute(string, string[], Godot.Collections.Array, bool, bool)"/> after running <see cref="Godot.OS.UnsetEnvironment(string)"/>. The removal of the environment variable will <i>not</i> persist to processes run after the Godot process was terminated.</para>
    /// <para><b>Note:</b> Environment variable names are case-sensitive on all platforms except Windows.</para>
    /// </summary>
    public static void UnsetEnvironment(string variable)
    {
        NativeCalls.godot_icall_1_57(MethodBind38, GodotObject.GetPtr(Singleton), variable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the host platform.</para>
    /// <para>- On Windows, this is <c>"Windows"</c>.</para>
    /// <para>- On macOS, this is <c>"macOS"</c>.</para>
    /// <para>- On Linux-based operating systems, this is <c>"Linux"</c>.</para>
    /// <para>- On BSD-based operating systems, this is <c>"FreeBSD"</c>, <c>"NetBSD"</c>, <c>"OpenBSD"</c>, or <c>"BSD"</c> as a fallback.</para>
    /// <para>- On Android, this is <c>"Android"</c>.</para>
    /// <para>- On iOS, this is <c>"iOS"</c>.</para>
    /// <para>- On Web, this is <c>"Web"</c>.</para>
    /// <para><b>Note:</b> Custom builds of the engine may support additional platforms, such as consoles, possibly returning other names.</para>
    /// <para><code>
    /// switch (OS.GetName())
    /// {
    /// 	case "Windows":
    /// 		GD.Print("Welcome to Windows");
    /// 		break;
    /// 	case "macOS":
    /// 		GD.Print("Welcome to macOS!");
    /// 		break;
    /// 	case "Linux":
    /// 	case "FreeBSD":
    /// 	case "NetBSD":
    /// 	case "OpenBSD":
    /// 	case "BSD":
    /// 		GD.Print("Welcome to Linux/BSD!");
    /// 		break;
    /// 	case "Android":
    /// 		GD.Print("Welcome to Android!");
    /// 		break;
    /// 	case "iOS":
    /// 		GD.Print("Welcome to iOS!");
    /// 		break;
    /// 	case "Web":
    /// 		GD.Print("Welcome to the Web!");
    /// 		break;
    /// }
    /// </code></para>
    /// <para><b>Note:</b> On Web platforms, it is still possible to determine the host platform's OS with feature tags. See <see cref="Godot.OS.HasFeature(string)"/>.</para>
    /// </summary>
    public static string GetName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind39, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDistributionName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the distribution for Linux and BSD platforms (e.g. "Ubuntu", "Manjaro", "OpenBSD", etc.).</para>
    /// <para>Returns the same value as <see cref="Godot.OS.GetName()"/> for stock Android ROMs, but attempts to return the custom ROM name for popular Android derivatives such as "LineageOS".</para>
    /// <para>Returns the same value as <see cref="Godot.OS.GetName()"/> for other platforms.</para>
    /// <para><b>Note:</b> This method is not supported on the Web platform. It returns an empty string.</para>
    /// </summary>
    public static string GetDistributionName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind40, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVersion, 201670096ul);

    /// <summary>
    /// <para>Returns the exact production and build version of the operating system. This is different from the branded version used in marketing. This helps to distinguish between different releases of operating systems, including minor versions, and insider and custom builds.</para>
    /// <para>- For Windows, the major and minor version are returned, as well as the build number. For example, the returned string may look like <c>10.0.9926</c> for a build of Windows 10.</para>
    /// <para>- For rolling distributions, such as Arch Linux, an empty string is returned.</para>
    /// <para>- For macOS and iOS, the major and minor version are returned, as well as the patch number.</para>
    /// <para>- For Android, the SDK version and the incremental build number are returned. If it's a custom ROM, it attempts to return its version instead.</para>
    /// <para><b>Note:</b> This method is not supported on the Web platform. It returns an empty string.</para>
    /// </summary>
    public static string GetVersion()
    {
        return NativeCalls.godot_icall_0_58(MethodBind41, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVersionAlias, 201670096ul);

    /// <summary>
    /// <para>Returns the branded version used in marketing, followed by the build number (on Windows), the version number (on macOS), or the SDK version and incremental build number (on Android). Examples include <c>11 (build 22000)</c>, <c>Sequoia (15.0.0)</c>, and <c>15 (SDK 35 build abc528-11988f)</c>.</para>
    /// <para>This value can then be appended to <see cref="Godot.OS.GetName()"/> to get a full, human-readable operating system name and version combination for the operating system. Windows feature updates such as 24H2 are not contained in the resulting string, but Windows Server is recognized as such (e.g. <c>2025 (build 26100)</c> for Windows Server 2025).</para>
    /// <para><b>Note:</b> This method is only supported on Windows, macOS, and Android. On other operating systems, it returns the same value as <see cref="Godot.OS.GetVersion()"/>.</para>
    /// </summary>
    public static string GetVersionAlias()
    {
        return NativeCalls.godot_icall_0_58(MethodBind42, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCmdlineArgs, 2981934095ul);

    /// <summary>
    /// <para>Returns the command-line arguments passed to the engine, excluding arguments processed by the engine, such as <c>--headless</c> and <c>--fullscreen</c>.</para>
    /// <para><code>
    /// # Godot has been executed with the following command:
    /// # godot --headless --verbose --scene my_scene.tscn --custom
    /// OS.get_cmdline_args() # Returns ["--scene", "my_scene.tscn", "--custom"]
    /// </code></para>
    /// <para>Command-line arguments can be written in any form, including both <c>--key value</c> and <c>--key=value</c> forms so they can be properly parsed, as long as custom command-line arguments do not conflict with engine arguments.</para>
    /// <para>You can also incorporate environment variables using the <see cref="Godot.OS.GetEnvironment(string)"/> method.</para>
    /// <para>You can set <c>ProjectSettings.editor/run/main_run_args</c> to define command-line arguments to be passed by the editor when running the project.</para>
    /// <para><b>Example:</b> Parse command-line arguments into a <see cref="Godot.Collections.Dictionary"/> using the <c>--key=value</c> form for arguments:</para>
    /// <para><code>
    /// var arguments = new Dictionary&lt;string, string&gt;();
    /// foreach (var argument in OS.GetCmdlineArgs())
    /// {
    /// 	if (argument.Contains('='))
    /// 	{
    /// 		string[] keyValue = argument.Split("=");
    /// 		arguments[keyValue[0].TrimPrefix("--")] = keyValue[1];
    /// 	}
    /// 	else
    /// 	{
    /// 		// Options without an argument will be present in the dictionary,
    /// 		// with the value set to an empty string.
    /// 		arguments[argument.TrimPrefix("--")] = "";
    /// 	}
    /// }
    /// </code></para>
    /// <para><b>Note:</b> Passing custom user arguments directly is not recommended, as the engine may discard or modify them. Instead, pass the standard UNIX double dash (<c>--</c>) and then the custom arguments, which the engine will ignore by design. These can be read via <see cref="Godot.OS.GetCmdlineUserArgs()"/>.</para>
    /// </summary>
    public static string[] GetCmdlineArgs()
    {
        return NativeCalls.godot_icall_0_108(MethodBind43, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCmdlineUserArgs, 2981934095ul);

    /// <summary>
    /// <para>Returns the command-line user arguments passed to the engine. User arguments are ignored by the engine and reserved for the user. They are passed after the double dash <c>--</c> argument. <c>++</c> may be used when <c>--</c> is intercepted by another program (such as <c>startx</c>).</para>
    /// <para><code>
    /// # Godot has been executed with the following command:
    /// # godot --fullscreen --custom -- --level=2 --hardcore
    /// 
    /// OS.get_cmdline_args()      # Returns ["--custom"]
    /// OS.get_cmdline_user_args() # Returns ["--level=2", "--hardcore"]
    /// </code></para>
    /// <para>To get arguments passed before <c>--</c> or <c>++</c>, use <see cref="Godot.OS.GetCmdlineArgs()"/>.</para>
    /// </summary>
    public static string[] GetCmdlineUserArgs()
    {
        return NativeCalls.godot_icall_0_108(MethodBind44, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterDriverInfo, 1139954409ul);

    /// <summary>
    /// <para>Returns the video adapter driver name and version for the user's currently active graphics card, as a <see cref="string"/>[]. See also <see cref="Godot.RenderingServer.GetVideoAdapterApiVersion()"/>.</para>
    /// <para>The first element holds the driver name, such as <c>nvidia</c>, <c>amdgpu</c>, etc.</para>
    /// <para>The second element holds the driver version. For example, on the <c>nvidia</c> driver on a Linux/BSD platform, the version is in the format <c>510.85.02</c>. For Windows, the driver's format is <c>31.0.15.1659</c>.</para>
    /// <para><b>Note:</b> This method is only supported on Linux/BSD and Windows when not running in headless mode. On other platforms, it returns an empty array.</para>
    /// <para><b>Note:</b> This method will run slowly the first time it is called in a session; it can take several seconds depending on the operating system and hardware. It is blocking if called on the main thread, so it's recommended to call it on a separate thread using <see cref="Godot.GodotThread"/>. This allows the engine to keep running while the information is being retrieved. However, <see cref="Godot.OS.GetVideoAdapterDriverInfo()"/> is <i>not</i> thread-safe, so it should not be called from multiple threads at the same time.</para>
    /// <para></para>
    /// </summary>
    public static string[] GetVideoAdapterDriverInfo()
    {
        return NativeCalls.godot_icall_0_108(MethodBind45, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRestartOnExit, 3331453935ul);

    /// <summary>
    /// <para>If <paramref name="restart"/> is <see langword="true"/>, restarts the project automatically when it is exited with <see cref="Godot.SceneTree.Quit(int)"/> or <see cref="Godot.Node.NotificationWMCloseRequest"/>. Command-line <paramref name="arguments"/> can be supplied. To restart the project with the same command line arguments as originally used to run the project, pass <see cref="Godot.OS.GetCmdlineArgs()"/> as the value for <paramref name="arguments"/>.</para>
    /// <para>This method can be used to apply setting changes that require a restart. See also <see cref="Godot.OS.IsRestartOnExitSet()"/> and <see cref="Godot.OS.GetRestartOnExitArguments()"/>.</para>
    /// <para><b>Note:</b> This method is only effective on desktop platforms, and only when the project isn't started from the editor. It will have no effect on mobile and Web platforms, or when the project is started from the editor.</para>
    /// <para><b>Note:</b> If the project process crashes or is <i>killed</i> by the user (by sending <c>SIGKILL</c> instead of the usual <c>SIGTERM</c>), the project won't restart automatically.</para>
    /// </summary>
    /// <param name="arguments">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    public static void SetRestartOnExit(bool restart, string[] arguments = null)
    {
        string[] argumentsOrDefVal = arguments != null ? arguments : Array.Empty<string>();
        NativeCalls.godot_icall_2_913(MethodBind46, GodotObject.GetPtr(Singleton), restart.ToGodotBool(), argumentsOrDefVal);
    }

    /// <summary>
    /// <para>If <paramref name="restart"/> is <see langword="true"/>, restarts the project automatically when it is exited with <see cref="Godot.SceneTree.Quit(int)"/> or <see cref="Godot.Node.NotificationWMCloseRequest"/>. Command-line <paramref name="arguments"/> can be supplied. To restart the project with the same command line arguments as originally used to run the project, pass <see cref="Godot.OS.GetCmdlineArgs()"/> as the value for <paramref name="arguments"/>.</para>
    /// <para>This method can be used to apply setting changes that require a restart. See also <see cref="Godot.OS.IsRestartOnExitSet()"/> and <see cref="Godot.OS.GetRestartOnExitArguments()"/>.</para>
    /// <para><b>Note:</b> This method is only effective on desktop platforms, and only when the project isn't started from the editor. It will have no effect on mobile and Web platforms, or when the project is started from the editor.</para>
    /// <para><b>Note:</b> If the project process crashes or is <i>killed</i> by the user (by sending <c>SIGKILL</c> instead of the usual <c>SIGTERM</c>), the project won't restart automatically.</para>
    /// </summary>
    public static void SetRestartOnExit(bool restart, ReadOnlySpan<string> arguments)
    {
        NativeCalls.godot_icall_2_913(MethodBind46, GodotObject.GetPtr(Singleton), restart.ToGodotBool(), arguments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRestartOnExitSet, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the project will automatically restart when it exits for any reason, <see langword="false"/> otherwise. See also <see cref="Godot.OS.SetRestartOnExit(bool, string[])"/> and <see cref="Godot.OS.GetRestartOnExitArguments()"/>.</para>
    /// </summary>
    public static bool IsRestartOnExitSet()
    {
        return NativeCalls.godot_icall_0_15(MethodBind47, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRestartOnExitArguments, 1139954409ul);

    /// <summary>
    /// <para>Returns the list of command line arguments that will be used when the project automatically restarts using <see cref="Godot.OS.SetRestartOnExit(bool, string[])"/>. See also <see cref="Godot.OS.IsRestartOnExitSet()"/>.</para>
    /// </summary>
    public static string[] GetRestartOnExitArguments()
    {
        return NativeCalls.godot_icall_0_108(MethodBind48, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DelayUsec, 998575451ul);

    /// <summary>
    /// <para>Delays execution of the current thread by <paramref name="usec"/> microseconds. <paramref name="usec"/> must be greater than or equal to <c>0</c>. Otherwise, <see cref="Godot.OS.DelayUsec(int)"/> does nothing and prints an error message.</para>
    /// <para><b>Note:</b> <see cref="Godot.OS.DelayUsec(int)"/> is a <i>blocking</i> way to delay code execution. To delay code execution in a non-blocking way, you may use <see cref="Godot.SceneTree.CreateTimer(double, bool, bool, bool)"/>. Awaiting with a <see cref="Godot.SceneTreeTimer"/> delays the execution of code placed below the <c>await</c> without affecting the rest of the project (or editor, for <c>EditorPlugin</c>s and <c>EditorScript</c>s).</para>
    /// <para><b>Note:</b> When <see cref="Godot.OS.DelayUsec(int)"/> is called on the main thread, it will freeze the project and will prevent it from redrawing and registering input until the delay has passed. When using <see cref="Godot.OS.DelayUsec(int)"/> as part of an <c>EditorPlugin</c> or <c>EditorScript</c>, it will freeze the editor but won't freeze the project if it is currently running (since the project is an independent child process).</para>
    /// </summary>
    public static void DelayUsec(int usec)
    {
        NativeCalls.godot_icall_1_38(MethodBind49, GodotObject.GetPtr(Singleton), usec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DelayMsec, 998575451ul);

    /// <summary>
    /// <para>Delays execution of the current thread by <paramref name="msec"/> milliseconds. <paramref name="msec"/> must be greater than or equal to <c>0</c>. Otherwise, <see cref="Godot.OS.DelayMsec(int)"/> does nothing and prints an error message.</para>
    /// <para><b>Note:</b> <see cref="Godot.OS.DelayMsec(int)"/> is a <i>blocking</i> way to delay code execution. To delay code execution in a non-blocking way, you may use <see cref="Godot.SceneTree.CreateTimer(double, bool, bool, bool)"/>. Awaiting with <see cref="Godot.SceneTreeTimer"/> delays the execution of code placed below the <c>await</c> without affecting the rest of the project (or editor, for <c>EditorPlugin</c>s and <c>EditorScript</c>s).</para>
    /// <para><b>Note:</b> When <see cref="Godot.OS.DelayMsec(int)"/> is called on the main thread, it will freeze the project and will prevent it from redrawing and registering input until the delay has passed. When using <see cref="Godot.OS.DelayMsec(int)"/> as part of an <c>EditorPlugin</c> or <c>EditorScript</c>, it will freeze the editor but won't freeze the project if it is currently running (since the project is an independent child process).</para>
    /// </summary>
    public static void DelayMsec(int msec)
    {
        NativeCalls.godot_icall_1_38(MethodBind50, GodotObject.GetPtr(Singleton), msec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocale, 201670096ul);

    /// <summary>
    /// <para>Returns the host OS locale as a <see cref="string"/> of the form <c>language_Script_COUNTRY_VARIANT@extra</c>. Every substring after <c>language</c> is optional and may not exist.</para>
    /// <para>- <c>language</c> - 2 or 3-letter <a href="https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes">language code</a>, in lower case.</para>
    /// <para>- <c>Script</c> - 4-letter <a href="https://en.wikipedia.org/wiki/ISO_15924">script code</a>, in title case.</para>
    /// <para>- <c>COUNTRY</c> - 2 or 3-letter <a href="https://en.wikipedia.org/wiki/ISO_3166-1">country code</a>, in upper case.</para>
    /// <para>- <c>VARIANT</c> - language variant, region and sort order. The variant can have any number of underscored keywords.</para>
    /// <para>- <c>extra</c> - semicolon separated list of additional key words. This may include currency, calendar, sort order and numbering system information.</para>
    /// <para>If you want only the language code and not the fully specified locale from the OS, you can use <see cref="Godot.OS.GetLocaleLanguage()"/>.</para>
    /// </summary>
    public static string GetLocale()
    {
        return NativeCalls.godot_icall_0_58(MethodBind51, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocaleLanguage, 201670096ul);

    /// <summary>
    /// <para>Returns the host OS locale's 2 or 3-letter <a href="https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes">language code</a> as a string which should be consistent on all platforms. This is equivalent to extracting the <c>language</c> part of the <see cref="Godot.OS.GetLocale()"/> string.</para>
    /// <para>This can be used to narrow down fully specified locale strings to only the "common" language code, when you don't need the additional information about country code or variants. For example, for a French Canadian user with <c>fr_CA</c> locale, this would return <c>fr</c>.</para>
    /// </summary>
    public static string GetLocaleLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind52, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModelName, 201670096ul);

    /// <summary>
    /// <para>Returns the model name of the current device.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, macOS, and Windows. Returns <c>"GenericDevice"</c> on unsupported platforms.</para>
    /// </summary>
    public static string GetModelName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind53, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUserfsPersistent, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <c>user://</c> file system is persistent, that is, its state is the same after a player quits and starts the game again. Relevant to the Web platform, where this persistence may be unavailable.</para>
    /// </summary>
    public static bool IsUserfsPersistent()
    {
        return NativeCalls.godot_icall_0_15(MethodBind54, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStdOutVerbose, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the engine was executed with the <c>--verbose</c> or <c>-v</c> command line argument, or if <c>ProjectSettings.debug/settings/stdout/verbose_stdout</c> is <see langword="true"/>. See also <c>@GlobalScope.print_verbose</c>.</para>
    /// </summary>
    public static bool IsStdOutVerbose()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDebugBuild, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the Godot binary used to run the project is a <i>debug</i> export template, or when running in the editor.</para>
    /// <para>Returns <see langword="false"/> if the Godot binary used to run the project is a <i>release</i> export template.</para>
    /// <para><b>Note:</b> To check whether the Godot binary used to run the project is an export template (debug or release), use <c>OS.has_feature("template")</c> instead.</para>
    /// </summary>
    public static bool IsDebugBuild()
    {
        return NativeCalls.godot_icall_0_15(MethodBind56, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStaticMemoryUsage, 3905245786ul);

    /// <summary>
    /// <para>Returns the amount of static memory being used by the program in bytes. Only works in debug builds.</para>
    /// </summary>
    public static ulong GetStaticMemoryUsage()
    {
        return NativeCalls.godot_icall_0_137(MethodBind57, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStaticMemoryPeakUsage, 3905245786ul);

    /// <summary>
    /// <para>Returns the maximum amount of static memory used. Only works in debug builds.</para>
    /// </summary>
    public static ulong GetStaticMemoryPeakUsage()
    {
        return NativeCalls.godot_icall_0_137(MethodBind58, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMemoryInfo, 3102165223ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> containing information about the current memory with the following entries:</para>
    /// <para>- <c>"physical"</c> - total amount of usable physical memory in bytes. This value can be slightly less than the actual physical memory amount, since it does not include memory reserved by the kernel and devices.</para>
    /// <para>- <c>"free"</c> - amount of physical memory, that can be immediately allocated without disk access or other costly operations, in bytes. The process might be able to allocate more physical memory, but this action will require moving inactive pages to disk, which can be expensive.</para>
    /// <para>- <c>"available"</c> - amount of memory that can be allocated without extending the swap file(s), in bytes. This value includes both physical memory and swap.</para>
    /// <para>- <c>"stack"</c> - size of the current thread stack in bytes.</para>
    /// <para><b>Note:</b> Each entry's value may be <c>-1</c> if it is unknown.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetMemoryInfo()
    {
        return NativeCalls.godot_icall_0_122(MethodBind59, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveToTrash, 2113323047ul);

    /// <summary>
    /// <para>Moves the file or directory at the given <paramref name="path"/> to the system's recycle bin. See also <see cref="Godot.DirAccess.Remove(string)"/>.</para>
    /// <para>The method takes only global paths, so you may need to use <see cref="Godot.ProjectSettings.GlobalizePath(string)"/>. Do not use it for files in <c>res://</c> as it will not work in exported projects.</para>
    /// <para>Returns <see cref="Godot.Error.Failed"/> if the file or directory cannot be found, or the system does not support this method.</para>
    /// <para><code>
    /// var fileToRemove = "user://slot1.save";
    /// OS.MoveToTrash(ProjectSettings.GlobalizePath(fileToRemove));
    /// </code></para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS and Windows.</para>
    /// <para><b>Note:</b> If the user has disabled the recycle bin on their system, the file will be permanently deleted instead.</para>
    /// </summary>
    public static Error MoveToTrash(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind60, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUserDataDir, 201670096ul);

    /// <summary>
    /// <para>Returns the absolute directory path where user data is written (the <c>user://</c> directory in Godot). The path depends on the project name and <c>ProjectSettings.application/config/use_custom_user_dir</c>.</para>
    /// <para>- On Windows, this is <c>%AppData%\Godot\app_userdata\[project_name]</c>, or <c>%AppData%\[custom_name]</c> if <c>use_custom_user_dir</c> is set. <c>%AppData%</c> expands to <c>%UserProfile%\AppData\Roaming</c>.</para>
    /// <para>- On macOS, this is <c>~/Library/Application Support/Godot/app_userdata/[project_name]</c>, or <c>~/Library/Application Support/[custom_name]</c> if <c>use_custom_user_dir</c> is set.</para>
    /// <para>- On Linux and BSD, this is <c>~/.local/share/godot/app_userdata/[project_name]</c>, or <c>~/.local/share/[custom_name]</c> if <c>use_custom_user_dir</c> is set.</para>
    /// <para>- On Android and iOS, this is a sandboxed directory in either internal or external storage, depending on the user's configuration.</para>
    /// <para>- On Web, this is a virtual directory managed by the browser.</para>
    /// <para>If the project name is empty, <c>[project_name]</c> falls back to <c>[unnamed project]</c>.</para>
    /// <para>Not to be confused with <see cref="Godot.OS.GetDataDir()"/>, which returns the <i>global</i> (non-project-specific) user home directory.</para>
    /// </summary>
    public static string GetUserDataDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind61, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemDir, 3073895123ul);

    /// <summary>
    /// <para>Returns the path to commonly used folders across different platforms, as defined by <paramref name="dir"/>. See the <see cref="Godot.OS.SystemDir"/> constants for available locations.</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS and Windows.</para>
    /// <para><b>Note:</b> Shared storage is implemented on Android and allows to differentiate between app specific and shared directories, if <paramref name="sharedStorage"/> is <see langword="true"/>. Shared directories have additional restrictions on Android.</para>
    /// </summary>
    public static string GetSystemDir(OS.SystemDir dir, bool sharedStorage = true)
    {
        return NativeCalls.godot_icall_2_914(MethodBind62, GodotObject.GetPtr(Singleton), (int)dir, sharedStorage.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConfigDir, 201670096ul);

    /// <summary>
    /// <para>Returns the <i>global</i> user configuration directory according to the operating system's standards.</para>
    /// <para>On the Linux/BSD platform, this path can be overridden by setting the <c>XDG_CONFIG_HOME</c> environment variable before starting the project. See <a href="$DOCS_URL/tutorials/io/data_paths.html">File paths in Godot projects</a> in the documentation for more information. See also <see cref="Godot.OS.GetCacheDir()"/> and <see cref="Godot.OS.GetDataDir()"/>.</para>
    /// <para>Not to be confused with <see cref="Godot.OS.GetUserDataDir()"/>, which returns the <i>project-specific</i> user data path.</para>
    /// </summary>
    public static string GetConfigDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind63, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDataDir, 201670096ul);

    /// <summary>
    /// <para>Returns the <i>global</i> user data directory according to the operating system's standards.</para>
    /// <para>On the Linux/BSD platform, this path can be overridden by setting the <c>XDG_DATA_HOME</c> environment variable before starting the project. See <a href="$DOCS_URL/tutorials/io/data_paths.html">File paths in Godot projects</a> in the documentation for more information. See also <see cref="Godot.OS.GetCacheDir()"/> and <see cref="Godot.OS.GetConfigDir()"/>.</para>
    /// <para>Not to be confused with <see cref="Godot.OS.GetUserDataDir()"/>, which returns the <i>project-specific</i> user data path.</para>
    /// </summary>
    public static string GetDataDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind64, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheDir, 201670096ul);

    /// <summary>
    /// <para>Returns the <i>global</i> cache data directory according to the operating system's standards.</para>
    /// <para>On the Linux/BSD platform, this path can be overridden by setting the <c>XDG_CACHE_HOME</c> environment variable before starting the project. See <a href="$DOCS_URL/tutorials/io/data_paths.html">File paths in Godot projects</a> in the documentation for more information. See also <see cref="Godot.OS.GetConfigDir()"/> and <see cref="Godot.OS.GetDataDir()"/>.</para>
    /// <para>Not to be confused with <see cref="Godot.OS.GetUserDataDir()"/>, which returns the <i>project-specific</i> user data path.</para>
    /// </summary>
    public static string GetCacheDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind65, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTempDir, 201670096ul);

    /// <summary>
    /// <para>Returns the <i>global</i> temporary data directory according to the operating system's standards.</para>
    /// </summary>
    public static string GetTempDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind66, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUniqueId, 201670096ul);

    /// <summary>
    /// <para>Returns a string that is unique to the device.</para>
    /// <para><b>Note:</b> This string may change without notice if the user reinstalls their operating system, upgrades it, or modifies their hardware. This means it should generally not be used to encrypt persistent data, as the data saved before an unexpected ID change would become inaccessible. The returned string may also be falsified using external programs, so do not rely on the string returned by this method for security purposes.</para>
    /// <para><b>Note:</b> On Web, returns an empty string and generates an error, as this method cannot be implemented for security reasons.</para>
    /// </summary>
    public static string GetUniqueId()
    {
        return NativeCalls.godot_icall_0_58(MethodBind67, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeycodeString, 2261993717ul);

    /// <summary>
    /// <para>Returns the given keycode as a <see cref="string"/>.</para>
    /// <para><code>
    /// GD.Print(OS.GetKeycodeString(Key.C));                                    // Prints "C"
    /// GD.Print(OS.GetKeycodeString(Key.Escape));                               // Prints "Escape"
    /// GD.Print(OS.GetKeycodeString((Key)KeyModifierMask.MaskShift | Key.Tab)); // Prints "Shift+Tab"
    /// </code></para>
    /// <para>See also <see cref="Godot.OS.FindKeycodeFromString(string)"/>, <see cref="Godot.InputEventKey.Keycode"/>, and <see cref="Godot.InputEventKey.GetKeycodeWithModifiers()"/>.</para>
    /// </summary>
    public static string GetKeycodeString(Key code)
    {
        return NativeCalls.godot_icall_1_133(MethodBind68, GodotObject.GetPtr(Singleton), (int)code);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsKeycodeUnicode, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the input keycode corresponds to a Unicode character. For a list of codes, see the <see cref="Godot.Key"/> constants.</para>
    /// <para><code>
    /// GD.Print(OS.IsKeycodeUnicode((long)Key.G));      // Prints True
    /// GD.Print(OS.IsKeycodeUnicode((long)Key.Kp4));    // Prints True
    /// GD.Print(OS.IsKeycodeUnicode((long)Key.Tab));    // Prints False
    /// GD.Print(OS.IsKeycodeUnicode((long)Key.Escape)); // Prints False
    /// </code></para>
    /// </summary>
    public static bool IsKeycodeUnicode(long code)
    {
        return NativeCalls.godot_icall_1_11(MethodBind69, GodotObject.GetPtr(Singleton), code).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FindKeycodeFromString, 1084858572ul);

    /// <summary>
    /// <para>Finds the keycode for the given string. The returned values are equivalent to the <see cref="Godot.Key"/> constants.</para>
    /// <para><code>
    /// GD.Print(OS.FindKeycodeFromString("C"));         // Prints C (Key.C)
    /// GD.Print(OS.FindKeycodeFromString("Escape"));    // Prints Escape (Key.Escape)
    /// GD.Print(OS.FindKeycodeFromString("Shift+Tab")); // Prints 37748738 (KeyModifierMask.MaskShift | Key.Tab)
    /// GD.Print(OS.FindKeycodeFromString("Unknown"));   // Prints None (Key.None)
    /// </code></para>
    /// <para>See also <see cref="Godot.OS.GetKeycodeString(Key)"/>.</para>
    /// </summary>
    public static Key FindKeycodeFromString(string @string)
    {
        return (Key)NativeCalls.godot_icall_1_134(MethodBind70, GodotObject.GetPtr(Singleton), @string);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseFileAccessSaveAndSwap, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, when opening a file for writing, a temporary file is used in its place. When closed, it is automatically applied to the target file.</para>
    /// <para>This can useful when files may be opened by other applications, such as antiviruses, text editors, or even the Godot editor itself.</para>
    /// </summary>
    public static void SetUseFileAccessSaveAndSwap(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind71, GodotObject.GetPtr(Singleton), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThreadName, 166001499ul);

    /// <summary>
    /// <para>Assigns the given name to the current thread. Returns <see cref="Godot.Error.Unavailable"/> if unavailable on the current platform.</para>
    /// </summary>
    public static Error SetThreadName(string name)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind72, GodotObject.GetPtr(Singleton), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThreadCallerId, 3905245786ul);

    /// <summary>
    /// <para>Returns the ID of the current thread. This can be used in logs to ease debugging of multi-threaded applications.</para>
    /// <para><b>Note:</b> Thread IDs are not deterministic and may be reused across application restarts.</para>
    /// </summary>
    public static ulong GetThreadCallerId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind73, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMainThreadId, 3905245786ul);

    /// <summary>
    /// <para>Returns the ID of the main thread. See <see cref="Godot.OS.GetThreadCallerId()"/>.</para>
    /// <para><b>Note:</b> Thread IDs are not deterministic and may be reused across application restarts.</para>
    /// </summary>
    public static ulong GetMainThreadId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind74, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFeature, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the feature for the given feature tag is supported in the currently running instance, depending on the platform, build, etc. Can be used to check whether you're currently running a debug build, on a certain platform or arch, etc. Refer to the <a href="$DOCS_URL/tutorials/export/feature_tags.html">Feature Tags</a> documentation for more details.</para>
    /// <para><b>Note:</b> Tag names are case-sensitive.</para>
    /// <para><b>Note:</b> On the Web platform, one of the following additional tags is defined to indicate the host platform: <c>web_android</c>, <c>web_ios</c>, <c>web_linuxbsd</c>, <c>web_macos</c>, or <c>web_windows</c>.</para>
    /// </summary>
    public static bool HasFeature(string tagName)
    {
        return NativeCalls.godot_icall_1_131(MethodBind75, GodotObject.GetPtr(Singleton), tagName).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSandboxed, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the application is running in the sandbox.</para>
    /// <para><b>Note:</b> This method is only implemented on macOS and Linux.</para>
    /// </summary>
    public static bool IsSandboxed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind76, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestPermission, 2323990056ul);

    /// <summary>
    /// <para>Requests permission from the OS for the given <paramref name="name"/>. Returns <see langword="true"/> if the permission has already been granted. See also <see cref="Godot.MainLoop.OnRequestPermissionsResult"/>.</para>
    /// <para>The <paramref name="name"/> must be the full permission name. For example:</para>
    /// <para>- <c>OS.request_permission("android.permission.READ_EXTERNAL_STORAGE")</c></para>
    /// <para>- <c>OS.request_permission("android.permission.POST_NOTIFICATIONS")</c></para>
    /// <para>- <c>OS.request_permission("macos.permission.RECORD_SCREEN")</c></para>
    /// <para>- <c>OS.request_permission("appleembedded.permission.AUDIO_RECORD")</c></para>
    /// <para><b>Note:</b> On Android, permission must be checked during export.</para>
    /// <para><b>Note:</b> This method is implemented on Android, macOS, and visionOS platforms.</para>
    /// </summary>
    public static bool RequestPermission(string name)
    {
        return NativeCalls.godot_icall_1_131(MethodBind77, GodotObject.GetPtr(Singleton), name).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestPermissions, 2240911060ul);

    /// <summary>
    /// <para>Requests <i>dangerous</i> permissions from the OS. Returns <see langword="true"/> if permissions have already been granted. See also <see cref="Godot.MainLoop.OnRequestPermissionsResult"/>.</para>
    /// <para><b>Note:</b> Permissions must be checked during export.</para>
    /// <para><b>Note:</b> This method is only implemented on Android. Normal permissions are automatically granted at install time in Android applications.</para>
    /// </summary>
    public static bool RequestPermissions()
    {
        return NativeCalls.godot_icall_0_15(MethodBind78, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGrantedPermissions, 1139954409ul);

    /// <summary>
    /// <para>On Android devices: Returns the list of dangerous permissions that have been granted.</para>
    /// <para>On macOS: Returns the list of granted permissions and user selected folders accessible to the application (sandboxed applications only). Use the native file dialog to request folder access permission.</para>
    /// <para>On iOS, visionOS: Returns the list of granted permissions.</para>
    /// </summary>
    public static string[] GetGrantedPermissions()
    {
        return NativeCalls.godot_icall_0_108(MethodBind79, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RevokeGrantedPermissions, 3218959716ul);

    /// <summary>
    /// <para>On macOS (sandboxed applications only), this function clears list of user selected folders accessible to the application.</para>
    /// </summary>
    public static void RevokeGrantedPermissions()
    {
        NativeCalls.godot_icall_0_3(MethodBind80, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddLogger, 4261188958ul);

    /// <summary>
    /// <para>Add a custom logger to intercept the internal message stream.</para>
    /// </summary>
    public static void AddLogger(Logger logger)
    {
        NativeCalls.godot_icall_1_56(MethodBind81, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(logger));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveLogger, 4261188958ul);

    /// <summary>
    /// <para>Remove a custom logger added by <see cref="Godot.OS.AddLogger(Logger)"/>.</para>
    /// </summary>
    public static void RemoveLogger(Logger logger)
    {
        NativeCalls.godot_icall_1_56(MethodBind82, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(logger));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ExecuteWithPipe, 3845631403ul);

    /// <summary>
    /// <para>Creates a new process that runs independently of Godot with redirected IO. It will not terminate when Godot terminates. The path specified in <paramref name="path"/> must exist and be an executable file or macOS <c>.app</c> bundle. The path is resolved based on the current platform. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>If <paramref name="blocking"/> is <see langword="false"/>, created pipes work in non-blocking mode, i.e. read and write operations will return immediately. Use <see cref="Godot.FileAccess.GetError()"/> to check if the last read/write operation was successful.</para>
    /// <para>If the process cannot be created, this method returns an empty <see cref="Godot.Collections.Dictionary"/>. Otherwise, this method returns a <see cref="Godot.Collections.Dictionary"/> with the following keys:</para>
    /// <para>- <c>"stdio"</c> - <see cref="Godot.FileAccess"/> to access the process stdin and stdout pipes (read/write).</para>
    /// <para>- <c>"stderr"</c> - <see cref="Godot.FileAccess"/> to access the process stderr pipe (read only).</para>
    /// <para>- <c>"pid"</c> - Process ID as an <see cref="int"/>, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>).</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> To execute a Windows command interpreter built-in command, specify <c>cmd.exe</c> in <paramref name="path"/>, <c>/c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a PowerShell built-in command, specify <c>powershell.exe</c> in <paramref name="path"/>, <c>-Command</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a Unix shell built-in command, specify shell executable name in <paramref name="path"/>, <c>-c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export or system .app bundle, system .app bundles will ignore arguments.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Godot.Collections.Dictionary ExecuteWithPipe(string path, string[] arguments)
    {
        return NativeCalls.godot_icall_2_915(MethodBind83, GodotObject.GetPtr(Singleton), path, arguments);
    }

    /// <summary>
    /// <para>Creates a new process that runs independently of Godot with redirected IO. It will not terminate when Godot terminates. The path specified in <paramref name="path"/> must exist and be an executable file or macOS <c>.app</c> bundle. The path is resolved based on the current platform. The <paramref name="arguments"/> are used in the given order and separated by a space.</para>
    /// <para>If <paramref name="blocking"/> is <see langword="false"/>, created pipes work in non-blocking mode, i.e. read and write operations will return immediately. Use <see cref="Godot.FileAccess.GetError()"/> to check if the last read/write operation was successful.</para>
    /// <para>If the process cannot be created, this method returns an empty <see cref="Godot.Collections.Dictionary"/>. Otherwise, this method returns a <see cref="Godot.Collections.Dictionary"/> with the following keys:</para>
    /// <para>- <c>"stdio"</c> - <see cref="Godot.FileAccess"/> to access the process stdin and stdout pipes (read/write).</para>
    /// <para>- <c>"stderr"</c> - <see cref="Godot.FileAccess"/> to access the process stderr pipe (read only).</para>
    /// <para>- <c>"pid"</c> - Process ID as an <see cref="int"/>, which you can use to monitor the process (and potentially terminate it with <see cref="Godot.OS.Kill(int)"/>).</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> To execute a Windows command interpreter built-in command, specify <c>cmd.exe</c> in <paramref name="path"/>, <c>/c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a PowerShell built-in command, specify <c>powershell.exe</c> in <paramref name="path"/>, <c>-Command</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> To execute a Unix shell built-in command, specify shell executable name in <paramref name="path"/>, <c>-c</c> as the first argument, and the desired command as the second argument.</para>
    /// <para><b>Note:</b> On macOS, sandboxed applications are limited to run only embedded helper executables, specified during export or system .app bundle, system .app bundles will ignore arguments.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Godot.Collections.Dictionary ExecuteWithPipe(string path, ReadOnlySpan<string> arguments)
    {
        return NativeCalls.godot_icall_2_915(MethodBind83, GodotObject.GetPtr(Singleton), path, arguments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReadStringFromStdIn, 2841200299ul);

    /// <summary>
    /// <para>Reads a user input as a UTF-8 encoded string from the standard input. This operation can be <i>blocking</i>, which causes the window to freeze if <see cref="Godot.OS.ReadStringFromStdIn(long)"/> is called on the main thread.</para>
    /// <para>- If standard input is console, this method will block until the program receives a line break in standard input (usually by the user pressing Enter).</para>
    /// <para>- If standard input is pipe, this method will block until a specific amount of data is read or pipe is closed.</para>
    /// <para>- If standard input is a file, this method will read a specific amount of data (or less if end-of-file is reached) and return immediately.</para>
    /// <para><b>Note:</b> This method automatically replaces <c>\r\n</c> line breaks with <c>\n</c> and removes them from the end of the string. Use <see cref="Godot.OS.ReadBufferFromStdIn(long)"/> to read the unprocessed data.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> On exported Windows builds, run the console wrapper executable to access the terminal. If standard input is console, calling this method without console wrapped will freeze permanently. If standard input is pipe or file, it can be used without console wrapper. If you need a single executable with full console support, use a custom build compiled with the <c>windows_subsystem=console</c> flag.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string ReadStringFromStdIn()
    {
        return NativeCalls.godot_icall_0_58(MethodBind84, GodotObject.GetPtr(Singleton));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'low_processor_usage_mode' property.
        /// </summary>
        public static readonly StringName LowProcessorUsageMode = "low_processor_usage_mode";
        /// <summary>
        /// Cached name for the 'low_processor_usage_mode_sleep_usec' property.
        /// </summary>
        public static readonly StringName LowProcessorUsageModeSleepUsec = "low_processor_usage_mode_sleep_usec";
        /// <summary>
        /// Cached name for the 'delta_smoothing' property.
        /// </summary>
        public static readonly StringName DeltaSmoothing = "delta_smoothing";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'get_entropy' method.
        /// </summary>
        public static readonly StringName GetEntropy = "get_entropy";
        /// <summary>
        /// Cached name for the 'get_system_ca_certificates' method.
        /// </summary>
        public static readonly StringName GetSystemCaCertificates = "get_system_ca_certificates";
        /// <summary>
        /// Cached name for the 'get_connected_midi_inputs' method.
        /// </summary>
        public static readonly StringName GetConnectedMidiInputs = "get_connected_midi_inputs";
        /// <summary>
        /// Cached name for the 'open_midi_inputs' method.
        /// </summary>
        public static readonly StringName OpenMidiInputs = "open_midi_inputs";
        /// <summary>
        /// Cached name for the 'close_midi_inputs' method.
        /// </summary>
        public static readonly StringName CloseMidiInputs = "close_midi_inputs";
        /// <summary>
        /// Cached name for the 'alert' method.
        /// </summary>
        public static readonly StringName Alert = "alert";
        /// <summary>
        /// Cached name for the 'crash' method.
        /// </summary>
        public static readonly StringName Crash = "crash";
        /// <summary>
        /// Cached name for the 'set_low_processor_usage_mode' method.
        /// </summary>
        public static readonly StringName SetLowProcessorUsageMode = "set_low_processor_usage_mode";
        /// <summary>
        /// Cached name for the 'is_in_low_processor_usage_mode' method.
        /// </summary>
        public static readonly StringName IsInLowProcessorUsageMode = "is_in_low_processor_usage_mode";
        /// <summary>
        /// Cached name for the 'set_low_processor_usage_mode_sleep_usec' method.
        /// </summary>
        public static readonly StringName SetLowProcessorUsageModeSleepUsec = "set_low_processor_usage_mode_sleep_usec";
        /// <summary>
        /// Cached name for the 'get_low_processor_usage_mode_sleep_usec' method.
        /// </summary>
        public static readonly StringName GetLowProcessorUsageModeSleepUsec = "get_low_processor_usage_mode_sleep_usec";
        /// <summary>
        /// Cached name for the 'set_delta_smoothing' method.
        /// </summary>
        public static readonly StringName SetDeltaSmoothing = "set_delta_smoothing";
        /// <summary>
        /// Cached name for the 'is_delta_smoothing_enabled' method.
        /// </summary>
        public static readonly StringName IsDeltaSmoothingEnabled = "is_delta_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'get_processor_count' method.
        /// </summary>
        public static readonly StringName GetProcessorCount = "get_processor_count";
        /// <summary>
        /// Cached name for the 'get_processor_name' method.
        /// </summary>
        public static readonly StringName GetProcessorName = "get_processor_name";
        /// <summary>
        /// Cached name for the 'get_system_fonts' method.
        /// </summary>
        public static readonly StringName GetSystemFonts = "get_system_fonts";
        /// <summary>
        /// Cached name for the 'get_system_font_path' method.
        /// </summary>
        public static readonly StringName GetSystemFontPath = "get_system_font_path";
        /// <summary>
        /// Cached name for the 'get_system_font_path_for_text' method.
        /// </summary>
        public static readonly StringName GetSystemFontPathForText = "get_system_font_path_for_text";
        /// <summary>
        /// Cached name for the 'get_executable_path' method.
        /// </summary>
        public static readonly StringName GetExecutablePath = "get_executable_path";
        /// <summary>
        /// Cached name for the 'read_string_from_stdin' method.
        /// </summary>
        public static readonly StringName ReadStringFromStdIn = "read_string_from_stdin";
        /// <summary>
        /// Cached name for the 'read_buffer_from_stdin' method.
        /// </summary>
        public static readonly StringName ReadBufferFromStdIn = "read_buffer_from_stdin";
        /// <summary>
        /// Cached name for the 'get_stdin_type' method.
        /// </summary>
        public static readonly StringName GetStdInType = "get_stdin_type";
        /// <summary>
        /// Cached name for the 'get_stdout_type' method.
        /// </summary>
        public static readonly StringName GetStdOutType = "get_stdout_type";
        /// <summary>
        /// Cached name for the 'get_stderr_type' method.
        /// </summary>
        public static readonly StringName GetStderrType = "get_stderr_type";
        /// <summary>
        /// Cached name for the 'execute' method.
        /// </summary>
        public static readonly StringName Execute = "execute";
        /// <summary>
        /// Cached name for the 'execute_with_pipe' method.
        /// </summary>
        public static readonly StringName ExecuteWithPipe = "execute_with_pipe";
        /// <summary>
        /// Cached name for the 'create_process' method.
        /// </summary>
        public static readonly StringName CreateProcess = "create_process";
        /// <summary>
        /// Cached name for the 'create_instance' method.
        /// </summary>
        public static readonly StringName CreateInstance = "create_instance";
        /// <summary>
        /// Cached name for the 'open_with_program' method.
        /// </summary>
        public static readonly StringName OpenWithProgram = "open_with_program";
        /// <summary>
        /// Cached name for the 'kill' method.
        /// </summary>
        public static readonly StringName Kill = "kill";
        /// <summary>
        /// Cached name for the 'shell_open' method.
        /// </summary>
        public static readonly StringName ShellOpen = "shell_open";
        /// <summary>
        /// Cached name for the 'shell_show_in_file_manager' method.
        /// </summary>
        public static readonly StringName ShellShowInFileManager = "shell_show_in_file_manager";
        /// <summary>
        /// Cached name for the 'is_process_running' method.
        /// </summary>
        public static readonly StringName IsProcessRunning = "is_process_running";
        /// <summary>
        /// Cached name for the 'get_process_exit_code' method.
        /// </summary>
        public static readonly StringName GetProcessExitCode = "get_process_exit_code";
        /// <summary>
        /// Cached name for the 'get_process_id' method.
        /// </summary>
        public static readonly StringName GetProcessId = "get_process_id";
        /// <summary>
        /// Cached name for the 'has_environment' method.
        /// </summary>
        public static readonly StringName HasEnvironment = "has_environment";
        /// <summary>
        /// Cached name for the 'get_environment' method.
        /// </summary>
        public static readonly StringName GetEnvironment = "get_environment";
        /// <summary>
        /// Cached name for the 'set_environment' method.
        /// </summary>
        public static readonly StringName SetEnvironment = "set_environment";
        /// <summary>
        /// Cached name for the 'unset_environment' method.
        /// </summary>
        public static readonly StringName UnsetEnvironment = "unset_environment";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'get_distribution_name' method.
        /// </summary>
        public static readonly StringName GetDistributionName = "get_distribution_name";
        /// <summary>
        /// Cached name for the 'get_version' method.
        /// </summary>
        public static readonly StringName GetVersion = "get_version";
        /// <summary>
        /// Cached name for the 'get_version_alias' method.
        /// </summary>
        public static readonly StringName GetVersionAlias = "get_version_alias";
        /// <summary>
        /// Cached name for the 'get_cmdline_args' method.
        /// </summary>
        public static readonly StringName GetCmdlineArgs = "get_cmdline_args";
        /// <summary>
        /// Cached name for the 'get_cmdline_user_args' method.
        /// </summary>
        public static readonly StringName GetCmdlineUserArgs = "get_cmdline_user_args";
        /// <summary>
        /// Cached name for the 'get_video_adapter_driver_info' method.
        /// </summary>
        public static readonly StringName GetVideoAdapterDriverInfo = "get_video_adapter_driver_info";
        /// <summary>
        /// Cached name for the 'set_restart_on_exit' method.
        /// </summary>
        public static readonly StringName SetRestartOnExit = "set_restart_on_exit";
        /// <summary>
        /// Cached name for the 'is_restart_on_exit_set' method.
        /// </summary>
        public static readonly StringName IsRestartOnExitSet = "is_restart_on_exit_set";
        /// <summary>
        /// Cached name for the 'get_restart_on_exit_arguments' method.
        /// </summary>
        public static readonly StringName GetRestartOnExitArguments = "get_restart_on_exit_arguments";
        /// <summary>
        /// Cached name for the 'delay_usec' method.
        /// </summary>
        public static readonly StringName DelayUsec = "delay_usec";
        /// <summary>
        /// Cached name for the 'delay_msec' method.
        /// </summary>
        public static readonly StringName DelayMsec = "delay_msec";
        /// <summary>
        /// Cached name for the 'get_locale' method.
        /// </summary>
        public static readonly StringName GetLocale = "get_locale";
        /// <summary>
        /// Cached name for the 'get_locale_language' method.
        /// </summary>
        public static readonly StringName GetLocaleLanguage = "get_locale_language";
        /// <summary>
        /// Cached name for the 'get_model_name' method.
        /// </summary>
        public static readonly StringName GetModelName = "get_model_name";
        /// <summary>
        /// Cached name for the 'is_userfs_persistent' method.
        /// </summary>
        public static readonly StringName IsUserfsPersistent = "is_userfs_persistent";
        /// <summary>
        /// Cached name for the 'is_stdout_verbose' method.
        /// </summary>
        public static readonly StringName IsStdOutVerbose = "is_stdout_verbose";
        /// <summary>
        /// Cached name for the 'is_debug_build' method.
        /// </summary>
        public static readonly StringName IsDebugBuild = "is_debug_build";
        /// <summary>
        /// Cached name for the 'get_static_memory_usage' method.
        /// </summary>
        public static readonly StringName GetStaticMemoryUsage = "get_static_memory_usage";
        /// <summary>
        /// Cached name for the 'get_static_memory_peak_usage' method.
        /// </summary>
        public static readonly StringName GetStaticMemoryPeakUsage = "get_static_memory_peak_usage";
        /// <summary>
        /// Cached name for the 'get_memory_info' method.
        /// </summary>
        public static readonly StringName GetMemoryInfo = "get_memory_info";
        /// <summary>
        /// Cached name for the 'move_to_trash' method.
        /// </summary>
        public static readonly StringName MoveToTrash = "move_to_trash";
        /// <summary>
        /// Cached name for the 'get_user_data_dir' method.
        /// </summary>
        public static readonly StringName GetUserDataDir = "get_user_data_dir";
        /// <summary>
        /// Cached name for the 'get_system_dir' method.
        /// </summary>
        public static readonly StringName GetSystemDir = "get_system_dir";
        /// <summary>
        /// Cached name for the 'get_config_dir' method.
        /// </summary>
        public static readonly StringName GetConfigDir = "get_config_dir";
        /// <summary>
        /// Cached name for the 'get_data_dir' method.
        /// </summary>
        public static readonly StringName GetDataDir = "get_data_dir";
        /// <summary>
        /// Cached name for the 'get_cache_dir' method.
        /// </summary>
        public static readonly StringName GetCacheDir = "get_cache_dir";
        /// <summary>
        /// Cached name for the 'get_temp_dir' method.
        /// </summary>
        public static readonly StringName GetTempDir = "get_temp_dir";
        /// <summary>
        /// Cached name for the 'get_unique_id' method.
        /// </summary>
        public static readonly StringName GetUniqueId = "get_unique_id";
        /// <summary>
        /// Cached name for the 'get_keycode_string' method.
        /// </summary>
        public static readonly StringName GetKeycodeString = "get_keycode_string";
        /// <summary>
        /// Cached name for the 'is_keycode_unicode' method.
        /// </summary>
        public static readonly StringName IsKeycodeUnicode = "is_keycode_unicode";
        /// <summary>
        /// Cached name for the 'find_keycode_from_string' method.
        /// </summary>
        public static readonly StringName FindKeycodeFromString = "find_keycode_from_string";
        /// <summary>
        /// Cached name for the 'set_use_file_access_save_and_swap' method.
        /// </summary>
        public static readonly StringName SetUseFileAccessSaveAndSwap = "set_use_file_access_save_and_swap";
        /// <summary>
        /// Cached name for the 'set_thread_name' method.
        /// </summary>
        public static readonly StringName SetThreadName = "set_thread_name";
        /// <summary>
        /// Cached name for the 'get_thread_caller_id' method.
        /// </summary>
        public static readonly StringName GetThreadCallerId = "get_thread_caller_id";
        /// <summary>
        /// Cached name for the 'get_main_thread_id' method.
        /// </summary>
        public static readonly StringName GetMainThreadId = "get_main_thread_id";
        /// <summary>
        /// Cached name for the 'has_feature' method.
        /// </summary>
        public static readonly StringName HasFeature = "has_feature";
        /// <summary>
        /// Cached name for the 'is_sandboxed' method.
        /// </summary>
        public static readonly StringName IsSandboxed = "is_sandboxed";
        /// <summary>
        /// Cached name for the 'request_permission' method.
        /// </summary>
        public static readonly StringName RequestPermission = "request_permission";
        /// <summary>
        /// Cached name for the 'request_permissions' method.
        /// </summary>
        public static readonly StringName RequestPermissions = "request_permissions";
        /// <summary>
        /// Cached name for the 'get_granted_permissions' method.
        /// </summary>
        public static readonly StringName GetGrantedPermissions = "get_granted_permissions";
        /// <summary>
        /// Cached name for the 'revoke_granted_permissions' method.
        /// </summary>
        public static readonly StringName RevokeGrantedPermissions = "revoke_granted_permissions";
        /// <summary>
        /// Cached name for the 'add_logger' method.
        /// </summary>
        public static readonly StringName AddLogger = "add_logger";
        /// <summary>
        /// Cached name for the 'remove_logger' method.
        /// </summary>
        public static readonly StringName RemoveLogger = "remove_logger";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
