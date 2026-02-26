namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDTextureView : RefCounted
{
    /// <summary>
    /// <para>Optional override for the data format to return sampled values in. The corresponding <see cref="Godot.RDTextureFormat"/> must have had this added as a shareable format. The default value of <see cref="Godot.RenderingDevice.DataFormat.Max"/> does not override the format.</para>
    /// </summary>
    public RenderingDevice.DataFormat FormatOverride
    {
        get
        {
            return GetFormatOverride();
        }
        set
        {
            SetFormatOverride(value);
        }
    }

    /// <summary>
    /// <para>The channel to sample when sampling the red color channel.</para>
    /// </summary>
    public RenderingDevice.TextureSwizzle SwizzleR
    {
        get
        {
            return GetSwizzleR();
        }
        set
        {
            SetSwizzleR(value);
        }
    }

    /// <summary>
    /// <para>The channel to sample when sampling the green color channel.</para>
    /// </summary>
    public RenderingDevice.TextureSwizzle SwizzleG
    {
        get
        {
            return GetSwizzleG();
        }
        set
        {
            SetSwizzleG(value);
        }
    }

    /// <summary>
    /// <para>The channel to sample when sampling the blue color channel.</para>
    /// </summary>
    public RenderingDevice.TextureSwizzle SwizzleB
    {
        get
        {
            return GetSwizzleB();
        }
        set
        {
            SetSwizzleB(value);
        }
    }

    /// <summary>
    /// <para>The channel to sample when sampling the alpha channel.</para>
    /// </summary>
    public RenderingDevice.TextureSwizzle SwizzleA
    {
        get
        {
            return GetSwizzleA();
        }
        set
        {
            SetSwizzleA(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDTextureView);

    private static readonly StringName NativeName = "RDTextureView";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDTextureView() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDTextureView(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDTextureView(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFormatOverride, 565531219ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFormatOverride(RenderingDevice.DataFormat pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormatOverride, 2235804183ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.DataFormat GetFormatOverride()
    {
        return (RenderingDevice.DataFormat)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwizzleR, 3833362581ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwizzleR(RenderingDevice.TextureSwizzle pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwizzleR, 4150792614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.TextureSwizzle GetSwizzleR()
    {
        return (RenderingDevice.TextureSwizzle)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwizzleG, 3833362581ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwizzleG(RenderingDevice.TextureSwizzle pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwizzleG, 4150792614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.TextureSwizzle GetSwizzleG()
    {
        return (RenderingDevice.TextureSwizzle)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwizzleB, 3833362581ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwizzleB(RenderingDevice.TextureSwizzle pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwizzleB, 4150792614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.TextureSwizzle GetSwizzleB()
    {
        return (RenderingDevice.TextureSwizzle)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwizzleA, 3833362581ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwizzleA(RenderingDevice.TextureSwizzle pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwizzleA, 4150792614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.TextureSwizzle GetSwizzleA()
    {
        return (RenderingDevice.TextureSwizzle)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
        /// Cached name for the 'format_override' property.
        /// </summary>
        public static readonly StringName FormatOverride = "format_override";
        /// <summary>
        /// Cached name for the 'swizzle_r' property.
        /// </summary>
        public static readonly StringName SwizzleR = "swizzle_r";
        /// <summary>
        /// Cached name for the 'swizzle_g' property.
        /// </summary>
        public static readonly StringName SwizzleG = "swizzle_g";
        /// <summary>
        /// Cached name for the 'swizzle_b' property.
        /// </summary>
        public static readonly StringName SwizzleB = "swizzle_b";
        /// <summary>
        /// Cached name for the 'swizzle_a' property.
        /// </summary>
        public static readonly StringName SwizzleA = "swizzle_a";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_format_override' method.
        /// </summary>
        public static readonly StringName SetFormatOverride = "set_format_override";
        /// <summary>
        /// Cached name for the 'get_format_override' method.
        /// </summary>
        public static readonly StringName GetFormatOverride = "get_format_override";
        /// <summary>
        /// Cached name for the 'set_swizzle_r' method.
        /// </summary>
        public static readonly StringName SetSwizzleR = "set_swizzle_r";
        /// <summary>
        /// Cached name for the 'get_swizzle_r' method.
        /// </summary>
        public static readonly StringName GetSwizzleR = "get_swizzle_r";
        /// <summary>
        /// Cached name for the 'set_swizzle_g' method.
        /// </summary>
        public static readonly StringName SetSwizzleG = "set_swizzle_g";
        /// <summary>
        /// Cached name for the 'get_swizzle_g' method.
        /// </summary>
        public static readonly StringName GetSwizzleG = "get_swizzle_g";
        /// <summary>
        /// Cached name for the 'set_swizzle_b' method.
        /// </summary>
        public static readonly StringName SetSwizzleB = "set_swizzle_b";
        /// <summary>
        /// Cached name for the 'get_swizzle_b' method.
        /// </summary>
        public static readonly StringName GetSwizzleB = "get_swizzle_b";
        /// <summary>
        /// Cached name for the 'set_swizzle_a' method.
        /// </summary>
        public static readonly StringName SetSwizzleA = "set_swizzle_a";
        /// <summary>
        /// Cached name for the 'get_swizzle_a' method.
        /// </summary>
        public static readonly StringName GetSwizzleA = "get_swizzle_a";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
