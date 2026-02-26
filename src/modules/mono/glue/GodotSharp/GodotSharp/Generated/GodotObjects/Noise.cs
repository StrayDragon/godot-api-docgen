namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class defines the interface for noise generation libraries to inherit from.</para>
/// <para>A default <see cref="Godot.Noise.GetSeamlessImage(int, int, bool, bool, float, bool)"/> implementation is provided for libraries that do not provide seamless noise. This function requests a larger image from the <see cref="Godot.Noise.GetImage(int, int, bool, bool, bool)"/> method, reverses the quadrants of the image, then uses the strips of extra width to blend over the seams.</para>
/// <para>Inheriting noise classes can optionally override this function to provide a more optimal algorithm.</para>
/// </summary>
public partial class Noise : Resource
{
    private static readonly System.Type CachedType = typeof(Noise);

    private static readonly StringName NativeName = "Noise";

    internal Noise() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Noise(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Noise(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNoise1D, 3919130443ul);

    /// <summary>
    /// <para>Returns the 1D noise value at the given (x) coordinate.</para>
    /// </summary>
    public float GetNoise1D(float x)
    {
        return NativeCalls.godot_icall_1_354(MethodBind0, GodotObject.GetPtr(this), x);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNoise2D, 2753205203ul);

    /// <summary>
    /// <para>Returns the 2D noise value at the given position.</para>
    /// </summary>
    public float GetNoise2D(float x, float y)
    {
        return NativeCalls.godot_icall_2_900(MethodBind1, GodotObject.GetPtr(this), x, y);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNoise2Dv, 2276447920ul);

    /// <summary>
    /// <para>Returns the 2D noise value at the given position.</para>
    /// </summary>
    public unsafe float GetNoise2Dv(Vector2 v)
    {
        return NativeCalls.godot_icall_1_287(MethodBind2, GodotObject.GetPtr(this), &v);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNoise3D, 973811851ul);

    /// <summary>
    /// <para>Returns the 3D noise value at the given position.</para>
    /// </summary>
    public float GetNoise3D(float x, float y, float z)
    {
        return NativeCalls.godot_icall_3_901(MethodBind3, GodotObject.GetPtr(this), x, y, z);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNoise3Dv, 1109078154ul);

    /// <summary>
    /// <para>Returns the 3D noise value at the given position.</para>
    /// </summary>
    public unsafe float GetNoise3Dv(Vector3 v)
    {
        return NativeCalls.godot_icall_1_288(MethodBind4, GodotObject.GetPtr(this), &v);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetImage, 3180683109ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Image"/> containing 2D noise values.</para>
    /// <para><b>Note:</b> With <paramref name="normalize"/> set to <see langword="false"/>, the default implementation expects the noise generator to return values in the range <c>-1.0</c> to <c>1.0</c>.</para>
    /// </summary>
    public Image GetImage(int width, int height, bool invert = false, bool in3DSpace = false, bool normalize = true)
    {
        return (Image)NativeCalls.godot_icall_5_902(MethodBind5, GodotObject.GetPtr(this), width, height, invert.ToGodotBool(), in3DSpace.ToGodotBool(), normalize.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSeamlessImage, 2770743602ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Image"/> containing seamless 2D noise values.</para>
    /// <para><b>Note:</b> With <paramref name="normalize"/> set to <see langword="false"/>, the default implementation expects the noise generator to return values in the range <c>-1.0</c> to <c>1.0</c>.</para>
    /// </summary>
    public Image GetSeamlessImage(int width, int height, bool invert = false, bool in3DSpace = false, float skirt = 0.1f, bool normalize = true)
    {
        return (Image)NativeCalls.godot_icall_6_903(MethodBind6, GodotObject.GetPtr(this), width, height, invert.ToGodotBool(), in3DSpace.ToGodotBool(), skirt, normalize.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetImage3D, 3977814329ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Image"/>s containing 3D noise values for use with <see cref="Godot.ImageTexture3D.Create(Image.Format, int, int, int, bool, Godot.Collections.Array{Image})"/>.</para>
    /// <para><b>Note:</b> With <paramref name="normalize"/> set to <see langword="false"/>, the default implementation expects the noise generator to return values in the range <c>-1.0</c> to <c>1.0</c>.</para>
    /// </summary>
    public Godot.Collections.Array<Image> GetImage3D(int width, int height, int depth, bool invert = false, bool normalize = true)
    {
        return new Godot.Collections.Array<Image>(NativeCalls.godot_icall_5_904(MethodBind7, GodotObject.GetPtr(this), width, height, depth, invert.ToGodotBool(), normalize.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSeamlessImage3D, 451006340ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Image"/>s containing seamless 3D noise values for use with <see cref="Godot.ImageTexture3D.Create(Image.Format, int, int, int, bool, Godot.Collections.Array{Image})"/>.</para>
    /// <para><b>Note:</b> With <paramref name="normalize"/> set to <see langword="false"/>, the default implementation expects the noise generator to return values in the range <c>-1.0</c> to <c>1.0</c>.</para>
    /// </summary>
    public Godot.Collections.Array<Image> GetSeamlessImage3D(int width, int height, int depth, bool invert = false, float skirt = 0.1f, bool normalize = true)
    {
        return new Godot.Collections.Array<Image>(NativeCalls.godot_icall_6_905(MethodBind8, GodotObject.GetPtr(this), width, height, depth, invert.ToGodotBool(), skirt, normalize.ToGodotBool()));
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
    public new class PropertyName : Resource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_noise_1d' method.
        /// </summary>
        public static readonly StringName GetNoise1D = "get_noise_1d";
        /// <summary>
        /// Cached name for the 'get_noise_2d' method.
        /// </summary>
        public static readonly StringName GetNoise2D = "get_noise_2d";
        /// <summary>
        /// Cached name for the 'get_noise_2dv' method.
        /// </summary>
        public static readonly StringName GetNoise2Dv = "get_noise_2dv";
        /// <summary>
        /// Cached name for the 'get_noise_3d' method.
        /// </summary>
        public static readonly StringName GetNoise3D = "get_noise_3d";
        /// <summary>
        /// Cached name for the 'get_noise_3dv' method.
        /// </summary>
        public static readonly StringName GetNoise3Dv = "get_noise_3dv";
        /// <summary>
        /// Cached name for the 'get_image' method.
        /// </summary>
        public static readonly StringName GetImage = "get_image";
        /// <summary>
        /// Cached name for the 'get_seamless_image' method.
        /// </summary>
        public static readonly StringName GetSeamlessImage = "get_seamless_image";
        /// <summary>
        /// Cached name for the 'get_image_3d' method.
        /// </summary>
        public static readonly StringName GetImage3D = "get_image_3d";
        /// <summary>
        /// Cached name for the 'get_seamless_image_3d' method.
        /// </summary>
        public static readonly StringName GetSeamlessImage3D = "get_seamless_image_3d";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
