namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The JavaClassWrapper singleton provides a way for the Godot application to send and receive data through the <a href="https://developer.android.com/training/articles/perf-jni">Java Native Interface</a> (JNI).</para>
/// <para><b>Note:</b> This singleton is only available in Android builds.</para>
/// <para><code>
/// var LocalDateTime = JavaClassWrapper.wrap("java.time.LocalDateTime")
/// var DateTimeFormatter = JavaClassWrapper.wrap("java.time.format.DateTimeFormatter")
/// 
/// var datetime = LocalDateTime.now()
/// var formatter = DateTimeFormatter.ofPattern("dd-MM-yyyy HH:mm:ss")
/// 
/// print(datetime.format(formatter))
/// </code></para>
/// <para><b>Warning:</b> When calling Java methods, be sure to check <see cref="Godot.JavaClassWrapper.GetException()"/> to check if the method threw an exception.</para>
/// </summary>
public static partial class JavaClassWrapper
{
    private static readonly StringName NativeName = "JavaClassWrapper";

    private static JavaClassWrapperInstance singleton;

    public static JavaClassWrapperInstance Singleton =>
        singleton ??= (JavaClassWrapperInstance)InteropUtils.EngineGetSingleton("JavaClassWrapper");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Wrap, 1124367868ul);

    /// <summary>
    /// <para>Wraps a class defined in Java, and returns it as a <see cref="Godot.JavaClass"/> <see cref="Godot.GodotObject"/> type that Godot can interact with.</para>
    /// <para>When wrapping inner (nested) classes, use <c>$</c> instead of <c>.</c> to separate them. For example, <c>JavaClassWrapper.wrap("android.view.WindowManager$LayoutParams")</c> wraps the <b>WindowManager.LayoutParams</b> class.</para>
    /// <para><b>Note:</b> To invoke a constructor, call a method with the same name as the class. For example:</para>
    /// <para><code>
    /// var Intent = JavaClassWrapper.wrap("android.content.Intent")
    /// var intent = Intent.Intent()
    /// </code></para>
    /// <para><b>Note:</b> This method only works on Android. On every other platform, this method does nothing and returns an empty <see cref="Godot.JavaClass"/>.</para>
    /// </summary>
    public static JavaClass Wrap(string name)
    {
        return (JavaClass)NativeCalls.godot_icall_1_533(MethodBind0, GodotObject.GetPtr(Singleton), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetException, 3277089691ul);

    /// <summary>
    /// <para>Returns the Java exception from the last call into a Java class. If there was no exception, it will return <see langword="null"/>.</para>
    /// <para><b>Note:</b> This method only works on Android. On every other platform, this method will always return <see langword="null"/>.</para>
    /// </summary>
    public static JavaObject GetException()
    {
        return (JavaObject)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'wrap' method.
        /// </summary>
        public static readonly StringName Wrap = "wrap";
        /// <summary>
        /// Cached name for the 'get_exception' method.
        /// </summary>
        public static readonly StringName GetException = "get_exception";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
