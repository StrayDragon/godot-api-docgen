namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is a generic mobile VR implementation where you need to provide details about the phone and HMD used. It does not rely on any existing framework. This is the most basic interface we have. For the best effect, you need a mobile phone with a gyroscope and accelerometer.</para>
/// <para>Note that even though there is no positional tracking, the camera will assume the headset is at a height of 1.85 meters. You can change this by setting <see cref="Godot.MobileVRInterface.EyeHeight"/>.</para>
/// <para>You can initialize this interface as follows:</para>
/// <para><code>
/// var interface = XRServer.find_interface("Native mobile")
/// if interface and interface.initialize():
/// 	get_viewport().use_xr = true
/// </code></para>
/// <para><b>Note:</b> For Android, <c>ProjectSettings.input_devices/sensors/enable_accelerometer</c>, <c>ProjectSettings.input_devices/sensors/enable_gravity</c>, <c>ProjectSettings.input_devices/sensors/enable_gyroscope</c> and <c>ProjectSettings.input_devices/sensors/enable_magnetometer</c> must be enabled.</para>
/// </summary>
public partial class MobileVRInterface : XRInterface
{
    /// <summary>
    /// <para>The height at which the camera is placed in relation to the ground (i.e. <see cref="Godot.XROrigin3D"/> node).</para>
    /// </summary>
    public double EyeHeight
    {
        get
        {
            return GetEyeHeight();
        }
        set
        {
            SetEyeHeight(value);
        }
    }

    /// <summary>
    /// <para>The interocular distance, also known as the interpupillary distance. The distance between the pupils of the left and right eye.</para>
    /// </summary>
    public double Iod
    {
        get
        {
            return GetIod();
        }
        set
        {
            SetIod(value);
        }
    }

    /// <summary>
    /// <para>The width of the display in centimeters.</para>
    /// </summary>
    public double DisplayWidth
    {
        get
        {
            return GetDisplayWidth();
        }
        set
        {
            SetDisplayWidth(value);
        }
    }

    /// <summary>
    /// <para>The distance between the display and the lenses inside of the device in centimeters.</para>
    /// </summary>
    public double DisplayToLens
    {
        get
        {
            return GetDisplayToLens();
        }
        set
        {
            SetDisplayToLens(value);
        }
    }

    /// <summary>
    /// <para>Set the offset rect relative to the area being rendered. A length of 1 represents the whole rendering area on that axis.</para>
    /// </summary>
    public Rect2 OffsetRect
    {
        get
        {
            return GetOffsetRect();
        }
        set
        {
            SetOffsetRect(value);
        }
    }

    /// <summary>
    /// <para>The oversample setting. Because of the lens distortion we have to render our buffers at a higher resolution then the screen can natively handle. A value between 1.5 and 2.0 often provides good results but at the cost of performance.</para>
    /// </summary>
    public double Oversample
    {
        get
        {
            return GetOversample();
        }
        set
        {
            SetOversample(value);
        }
    }

    /// <summary>
    /// <para>The k1 lens factor is one of the two constants that define the strength of the lens used and directly influences the lens distortion effect.</para>
    /// </summary>
    public double K1
    {
        get
        {
            return GetK1();
        }
        set
        {
            SetK1(value);
        }
    }

    /// <summary>
    /// <para>The k2 lens factor, see k1.</para>
    /// </summary>
    public double K2
    {
        get
        {
            return GetK2();
        }
        set
        {
            SetK2(value);
        }
    }

    /// <summary>
    /// <para>The minimum radius around the focal point where full quality is guaranteed if VRS is used as a percentage of screen size.</para>
    /// <para><b>Note:</b> Mobile and Forward+ renderers only. Requires <see cref="Godot.Viewport.VrsMode"/> to be set to <see cref="Godot.Viewport.VrsModeEnum.XR"/>.</para>
    /// </summary>
    public float VrsMinRadius
    {
        get
        {
            return GetVrsMinRadius();
        }
        set
        {
            SetVrsMinRadius(value);
        }
    }

    /// <summary>
    /// <para>The strength used to calculate the VRS density map. The greater this value, the more noticeable VRS is. This improves performance at the cost of quality.</para>
    /// <para><b>Note:</b> Mobile and Forward+ renderers only. Requires <see cref="Godot.Viewport.VrsMode"/> to be set to <see cref="Godot.Viewport.VrsModeEnum.XR"/>.</para>
    /// </summary>
    public float VrsStrength
    {
        get
        {
            return GetVrsStrength();
        }
        set
        {
            SetVrsStrength(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MobileVRInterface);

    private static readonly StringName NativeName = "MobileVRInterface";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MobileVRInterface() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MobileVRInterface(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MobileVRInterface(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEyeHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEyeHeight(double eyeHeight)
    {
        NativeCalls.godot_icall_1_127(MethodBind0, GodotObject.GetPtr(this), eyeHeight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEyeHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetEyeHeight()
    {
        return NativeCalls.godot_icall_0_144(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIod, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIod(double iod)
    {
        NativeCalls.godot_icall_1_127(MethodBind2, GodotObject.GetPtr(this), iod);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIod, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetIod()
    {
        return NativeCalls.godot_icall_0_144(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisplayWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisplayWidth(double displayWidth)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(this), displayWidth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisplayWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetDisplayWidth()
    {
        return NativeCalls.godot_icall_0_144(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisplayToLens, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisplayToLens(double displayToLens)
    {
        NativeCalls.godot_icall_1_127(MethodBind6, GodotObject.GetPtr(this), displayToLens);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisplayToLens, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetDisplayToLens()
    {
        return NativeCalls.godot_icall_0_144(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffsetRect, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffsetRect(Rect2 offsetRect)
    {
        NativeCalls.godot_icall_1_188(MethodBind8, GodotObject.GetPtr(this), &offsetRect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffsetRect, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetOffsetRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOversample, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOversample(double oversample)
    {
        NativeCalls.godot_icall_1_127(MethodBind10, GodotObject.GetPtr(this), oversample);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOversample, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetOversample()
    {
        return NativeCalls.godot_icall_0_144(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetK1, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetK1(double k)
    {
        NativeCalls.godot_icall_1_127(MethodBind12, GodotObject.GetPtr(this), k);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetK1, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetK1()
    {
        return NativeCalls.godot_icall_0_144(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetK2, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetK2(double k)
    {
        NativeCalls.godot_icall_1_127(MethodBind14, GodotObject.GetPtr(this), k);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetK2, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetK2()
    {
        return NativeCalls.godot_icall_0_144(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsMinRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVrsMinRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsMinRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsMinRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind17, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVrsStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind19, GodotObject.GetPtr(this), strength);
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
    public new class PropertyName : XRInterface.PropertyName
    {
        /// <summary>
        /// Cached name for the 'eye_height' property.
        /// </summary>
        public static readonly StringName EyeHeight = "eye_height";
        /// <summary>
        /// Cached name for the 'iod' property.
        /// </summary>
        public static readonly StringName Iod = "iod";
        /// <summary>
        /// Cached name for the 'display_width' property.
        /// </summary>
        public static readonly StringName DisplayWidth = "display_width";
        /// <summary>
        /// Cached name for the 'display_to_lens' property.
        /// </summary>
        public static readonly StringName DisplayToLens = "display_to_lens";
        /// <summary>
        /// Cached name for the 'offset_rect' property.
        /// </summary>
        public static readonly StringName OffsetRect = "offset_rect";
        /// <summary>
        /// Cached name for the 'oversample' property.
        /// </summary>
        public static readonly StringName Oversample = "oversample";
        /// <summary>
        /// Cached name for the 'k1' property.
        /// </summary>
        public static readonly StringName K1 = "k1";
        /// <summary>
        /// Cached name for the 'k2' property.
        /// </summary>
        public static readonly StringName K2 = "k2";
        /// <summary>
        /// Cached name for the 'vrs_min_radius' property.
        /// </summary>
        public static readonly StringName VrsMinRadius = "vrs_min_radius";
        /// <summary>
        /// Cached name for the 'vrs_strength' property.
        /// </summary>
        public static readonly StringName VrsStrength = "vrs_strength";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRInterface.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_eye_height' method.
        /// </summary>
        public static readonly StringName SetEyeHeight = "set_eye_height";
        /// <summary>
        /// Cached name for the 'get_eye_height' method.
        /// </summary>
        public static readonly StringName GetEyeHeight = "get_eye_height";
        /// <summary>
        /// Cached name for the 'set_iod' method.
        /// </summary>
        public static readonly StringName SetIod = "set_iod";
        /// <summary>
        /// Cached name for the 'get_iod' method.
        /// </summary>
        public static readonly StringName GetIod = "get_iod";
        /// <summary>
        /// Cached name for the 'set_display_width' method.
        /// </summary>
        public static readonly StringName SetDisplayWidth = "set_display_width";
        /// <summary>
        /// Cached name for the 'get_display_width' method.
        /// </summary>
        public static readonly StringName GetDisplayWidth = "get_display_width";
        /// <summary>
        /// Cached name for the 'set_display_to_lens' method.
        /// </summary>
        public static readonly StringName SetDisplayToLens = "set_display_to_lens";
        /// <summary>
        /// Cached name for the 'get_display_to_lens' method.
        /// </summary>
        public static readonly StringName GetDisplayToLens = "get_display_to_lens";
        /// <summary>
        /// Cached name for the 'set_offset_rect' method.
        /// </summary>
        public static readonly StringName SetOffsetRect = "set_offset_rect";
        /// <summary>
        /// Cached name for the 'get_offset_rect' method.
        /// </summary>
        public static readonly StringName GetOffsetRect = "get_offset_rect";
        /// <summary>
        /// Cached name for the 'set_oversample' method.
        /// </summary>
        public static readonly StringName SetOversample = "set_oversample";
        /// <summary>
        /// Cached name for the 'get_oversample' method.
        /// </summary>
        public static readonly StringName GetOversample = "get_oversample";
        /// <summary>
        /// Cached name for the 'set_k1' method.
        /// </summary>
        public static readonly StringName SetK1 = "set_k1";
        /// <summary>
        /// Cached name for the 'get_k1' method.
        /// </summary>
        public static readonly StringName GetK1 = "get_k1";
        /// <summary>
        /// Cached name for the 'set_k2' method.
        /// </summary>
        public static readonly StringName SetK2 = "set_k2";
        /// <summary>
        /// Cached name for the 'get_k2' method.
        /// </summary>
        public static readonly StringName GetK2 = "get_k2";
        /// <summary>
        /// Cached name for the 'get_vrs_min_radius' method.
        /// </summary>
        public static readonly StringName GetVrsMinRadius = "get_vrs_min_radius";
        /// <summary>
        /// Cached name for the 'set_vrs_min_radius' method.
        /// </summary>
        public static readonly StringName SetVrsMinRadius = "set_vrs_min_radius";
        /// <summary>
        /// Cached name for the 'get_vrs_strength' method.
        /// </summary>
        public static readonly StringName GetVrsStrength = "get_vrs_strength";
        /// <summary>
        /// Cached name for the 'set_vrs_strength' method.
        /// </summary>
        public static readonly StringName SetVrsStrength = "set_vrs_strength";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRInterface.SignalName
    {
    }
}
