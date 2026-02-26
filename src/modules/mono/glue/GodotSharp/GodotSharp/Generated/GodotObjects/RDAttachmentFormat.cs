namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDAttachmentFormat : RefCounted
{
    /// <summary>
    /// <para>The attachment's data format.</para>
    /// </summary>
    public RenderingDevice.DataFormat Format
    {
        get
        {
            return GetFormat();
        }
        set
        {
            SetFormat(value);
        }
    }

    /// <summary>
    /// <para>The number of samples used when sampling the attachment.</para>
    /// </summary>
    public RenderingDevice.TextureSamples Samples
    {
        get
        {
            return GetSamples();
        }
        set
        {
            SetSamples(value);
        }
    }

    /// <summary>
    /// <para>The attachment's usage flags, which determine what can be done with it.</para>
    /// </summary>
    public uint UsageFlags
    {
        get
        {
            return GetUsageFlags();
        }
        set
        {
            SetUsageFlags(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDAttachmentFormat);

    private static readonly StringName NativeName = "RDAttachmentFormat";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDAttachmentFormat() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDAttachmentFormat(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDAttachmentFormat(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFormat, 565531219ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFormat(RenderingDevice.DataFormat pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 2235804183ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.DataFormat GetFormat()
    {
        return (RenderingDevice.DataFormat)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSamples, 3774171498ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSamples(RenderingDevice.TextureSamples pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSamples, 407791724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.TextureSamples GetSamples()
    {
        return (RenderingDevice.TextureSamples)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUsageFlags, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUsageFlags(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind4, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsageFlags, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetUsageFlags()
    {
        return NativeCalls.godot_icall_0_209(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'format' property.
        /// </summary>
        public static readonly StringName Format = "format";
        /// <summary>
        /// Cached name for the 'samples' property.
        /// </summary>
        public static readonly StringName Samples = "samples";
        /// <summary>
        /// Cached name for the 'usage_flags' property.
        /// </summary>
        public static readonly StringName UsageFlags = "usage_flags";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_format' method.
        /// </summary>
        public static readonly StringName SetFormat = "set_format";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'set_samples' method.
        /// </summary>
        public static readonly StringName SetSamples = "set_samples";
        /// <summary>
        /// Cached name for the 'get_samples' method.
        /// </summary>
        public static readonly StringName GetSamples = "get_samples";
        /// <summary>
        /// Cached name for the 'set_usage_flags' method.
        /// </summary>
        public static readonly StringName SetUsageFlags = "set_usage_flags";
        /// <summary>
        /// Cached name for the 'get_usage_flags' method.
        /// </summary>
        public static readonly StringName GetUsageFlags = "get_usage_flags";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
