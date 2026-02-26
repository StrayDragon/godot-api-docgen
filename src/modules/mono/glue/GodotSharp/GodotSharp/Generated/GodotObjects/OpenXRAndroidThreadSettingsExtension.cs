namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>For XR to be comfortable, it is important for applications to deliver frames quickly and consistently. In order to make sure the important application threads get their full share of time, these threads must be identified to the system, which will adjust their scheduling priority accordingly.</para>
/// </summary>
public partial class OpenXRAndroidThreadSettingsExtension : OpenXRExtensionWrapper
{
    public enum ThreadType : long
    {
        /// <summary>
        /// <para>Hints to the XR runtime that the thread is doing time critical CPU tasks.</para>
        /// </summary>
        ApplicationMain = 0,
        /// <summary>
        /// <para>Hints to the XR runtime that the thread is doing background CPU tasks.</para>
        /// </summary>
        ApplicationWorker = 1,
        /// <summary>
        /// <para>Hints to the XR runtime that the thread is doing time critical graphics device tasks.</para>
        /// </summary>
        RendererMain = 2,
        /// <summary>
        /// <para>Hints to the XR runtime that the thread is doing background graphics device tasks.</para>
        /// </summary>
        RendererWorker = 3
    }

    private static readonly System.Type CachedType = typeof(OpenXRAndroidThreadSettingsExtension);

    private static readonly StringName NativeName = "OpenXRAndroidThreadSettingsExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRAndroidThreadSettingsExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRAndroidThreadSettingsExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRAndroidThreadSettingsExtension(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetApplicationThreadType, 1558751158ul);

    /// <summary>
    /// <para>Sets the thread type of the given thread, so that the XR runtime can adjust its scheduling priority accordingly.</para>
    /// <para><paramref name="threadId"/> refers to the OS thread id (ie from <c>gettid()</c>). When <paramref name="threadId"/> is <c>0</c>, it will set the thread type of the current thread.</para>
    /// <para><b>NOTE:</b> The id returned by <see cref="Godot.GodotThread.GetId()"/> is incompatible with <paramref name="threadId"/>.</para>
    /// </summary>
    public bool SetApplicationThreadType(OpenXRAndroidThreadSettingsExtension.ThreadType threadType, uint threadId = (uint)(0))
    {
        return NativeCalls.godot_icall_2_933(MethodBind0, GodotObject.GetPtr(this), (int)threadType, threadId).ToBool();
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
    public new class PropertyName : OpenXRExtensionWrapper.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRExtensionWrapper.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_application_thread_type' method.
        /// </summary>
        public static readonly StringName SetApplicationThreadType = "set_application_thread_type";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRExtensionWrapper.SignalName
    {
    }
}
