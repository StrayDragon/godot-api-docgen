namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Displays the content of an external buffer provided by the platform.</para>
/// <para>Requires the <a href="https://registry.khronos.org/OpenGL/extensions/OES/OES_EGL_image_external.txt">OES_EGL_image_external</a> extension (OpenGL) or <a href="https://registry.khronos.org/vulkan/specs/1.1-extensions/html/vkspec.html#VK_ANDROID_external_memory_android_hardware_buffer">VK_ANDROID_external_memory_android_hardware_buffer</a> extension (Vulkan).</para>
/// <para><b>Note:</b> This is currently only supported in Android builds.</para>
/// </summary>
public partial class ExternalTexture : Texture2D
{
    /// <summary>
    /// <para>External texture size.</para>
    /// </summary>
    public Vector2 Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ExternalTexture);

    private static readonly StringName NativeName = "ExternalTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ExternalTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ExternalTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ExternalTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector2 size)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExternalTextureId, 3905245786ul);

    /// <summary>
    /// <para>Returns the external texture ID.</para>
    /// <para>Depending on your use case, you may need to pass this to platform APIs, for example, when creating an <c>android.graphics.SurfaceTexture</c> on Android.</para>
    /// </summary>
    public ulong GetExternalTextureId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExternalBufferId, 1286410249ul);

    /// <summary>
    /// <para>Sets the external buffer ID.</para>
    /// <para>Depending on your use case, you may need to call this with data received from a platform API, for example, <c>SurfaceTexture.getHardwareBuffer()</c> on Android.</para>
    /// </summary>
    public void SetExternalBufferId(ulong externalBufferId)
    {
        NativeCalls.godot_icall_1_544(MethodBind2, GodotObject.GetPtr(this), externalBufferId);
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_external_texture_id' method.
        /// </summary>
        public static readonly StringName GetExternalTextureId = "get_external_texture_id";
        /// <summary>
        /// Cached name for the 'set_external_buffer_id' method.
        /// </summary>
        public static readonly StringName SetExternalBufferId = "set_external_buffer_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
