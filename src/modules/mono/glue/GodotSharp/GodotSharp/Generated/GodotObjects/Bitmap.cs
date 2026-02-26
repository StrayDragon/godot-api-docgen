namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A two-dimensional array of boolean values, can be used to efficiently store a binary matrix (every matrix element takes only one bit) and query the values using natural cartesian coordinates.</para>
/// </summary>
[GodotClassName("BitMap")]
public partial class Bitmap : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(Bitmap);

    private static readonly StringName NativeName = "BitMap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Bitmap() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Bitmap(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Bitmap(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Create, 1130785943ul);

    /// <summary>
    /// <para>Creates a bitmap with the specified size, filled with <see langword="false"/>.</para>
    /// </summary>
    public unsafe void Create(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromImageAlpha, 106271684ul);

    /// <summary>
    /// <para>Creates a bitmap that matches the given image dimensions, every element of the bitmap is set to <see langword="false"/> if the alpha value of the image at that position is equal to <paramref name="threshold"/> or less, and <see langword="true"/> in other case.</para>
    /// </summary>
    public void CreateFromImageAlpha(Image image, float threshold = 0.1f)
    {
        NativeCalls.godot_icall_2_215(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(image), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBitv, 4153096796ul);

    /// <summary>
    /// <para>Sets the bitmap's element at the specified position, to the specified value.</para>
    /// </summary>
    public unsafe void SetBitv(Vector2I position, bool bit)
    {
        NativeCalls.godot_icall_2_42(MethodBind2, GodotObject.GetPtr(this), &position, bit.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBit, 1383440665ul);

    /// <summary>
    /// <para>Sets the bitmap's element at the specified position, to the specified value.</para>
    /// </summary>
    public void SetBit(int x, int y, bool bit)
    {
        NativeCalls.godot_icall_3_197(MethodBind3, GodotObject.GetPtr(this), x, y, bit.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBitv, 3900751641ul);

    /// <summary>
    /// <para>Returns bitmap's value at the specified position.</para>
    /// </summary>
    public unsafe bool GetBitv(Vector2I position)
    {
        return NativeCalls.godot_icall_1_41(MethodBind4, GodotObject.GetPtr(this), &position).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBit, 2522259332ul);

    /// <summary>
    /// <para>Returns bitmap's value at the specified position.</para>
    /// </summary>
    public bool GetBit(int x, int y)
    {
        return NativeCalls.godot_icall_2_40(MethodBind5, GodotObject.GetPtr(this), x, y).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBitRect, 472162941ul);

    /// <summary>
    /// <para>Sets a rectangular portion of the bitmap to the specified value.</para>
    /// </summary>
    public unsafe void SetBitRect(Rect2I rect, bool bit)
    {
        NativeCalls.godot_icall_2_45(MethodBind6, GodotObject.GetPtr(this), &rect, bit.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrueBitCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of bitmap elements that are set to <see langword="true"/>.</para>
    /// </summary>
    public int GetTrueBitCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3690982128ul);

    /// <summary>
    /// <para>Returns bitmap's dimensions.</para>
    /// </summary>
    public Vector2I GetSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Resize, 1130785943ul);

    /// <summary>
    /// <para>Resizes the image to <paramref name="newSize"/>.</para>
    /// </summary>
    public unsafe void Resize(Vector2I newSize)
    {
        NativeCalls.godot_icall_1_34(MethodBind9, GodotObject.GetPtr(this), &newSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 4155329257ul);

    internal void _SetData(Godot.Collections.Dictionary data)
    {
        NativeCalls.godot_icall_1_121(MethodBind10, GodotObject.GetPtr(this), (godot_dictionary)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3102165223ul);

    internal Godot.Collections.Dictionary _GetData()
    {
        return NativeCalls.godot_icall_0_122(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GrowMask, 3317281434ul);

    /// <summary>
    /// <para>Applies morphological dilation or erosion to the bitmap. If <paramref name="pixels"/> is positive, dilation is applied to the bitmap. If <paramref name="pixels"/> is negative, erosion is applied to the bitmap. <paramref name="rect"/> defines the area where the morphological operation is applied. Pixels located outside the <paramref name="rect"/> are unaffected by <see cref="Godot.Bitmap.GrowMask(int, Rect2I)"/>.</para>
    /// </summary>
    public unsafe void GrowMask(int pixels, Rect2I rect)
    {
        NativeCalls.godot_icall_2_216(MethodBind12, GodotObject.GetPtr(this), pixels, &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvertToImage, 4190603485ul);

    /// <summary>
    /// <para>Returns an image of the same size as the bitmap and with an <see cref="Godot.Image.Format"/> of type <see cref="Godot.Image.Format.L8"/>. <see langword="true"/> bits of the bitmap are being converted into white pixels, and <see langword="false"/> bits into black.</para>
    /// </summary>
    public Image ConvertToImage()
    {
        return (Image)NativeCalls.godot_icall_0_63(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpaqueToPolygons, 48478126ul);

    /// <summary>
    /// <para>Creates an <see cref="Godot.Collections.Array"/> of polygons covering a rectangular portion of the bitmap. It uses a marching squares algorithm, followed by Ramer-Douglas-Peucker (RDP) reduction of the number of vertices. Each polygon is described as a <see cref="Godot.Vector2"/>[] of its vertices.</para>
    /// <para>To get polygons covering the whole bitmap, pass:</para>
    /// <para><code>
    /// Rect2(Vector2(), get_size())
    /// </code></para>
    /// <para><paramref name="epsilon"/> is passed to RDP to control how accurately the polygons cover the bitmap: a lower <paramref name="epsilon"/> corresponds to more points in the polygons.</para>
    /// </summary>
    public unsafe Godot.Collections.Array<Vector2[]> OpaqueToPolygons(Rect2I rect, float epsilon = 2.0f)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_217(MethodBind14, GodotObject.GetPtr(this), &rect, epsilon));
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
        /// <summary>
        /// Cached name for the 'data' property.
        /// </summary>
        public static readonly StringName Data = "data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'create' method.
        /// </summary>
        public static readonly StringName Create = "create";
        /// <summary>
        /// Cached name for the 'create_from_image_alpha' method.
        /// </summary>
        public static readonly StringName CreateFromImageAlpha = "create_from_image_alpha";
        /// <summary>
        /// Cached name for the 'set_bitv' method.
        /// </summary>
        public static readonly StringName SetBitv = "set_bitv";
        /// <summary>
        /// Cached name for the 'set_bit' method.
        /// </summary>
        public static readonly StringName SetBit = "set_bit";
        /// <summary>
        /// Cached name for the 'get_bitv' method.
        /// </summary>
        public static readonly StringName GetBitv = "get_bitv";
        /// <summary>
        /// Cached name for the 'get_bit' method.
        /// </summary>
        public static readonly StringName GetBit = "get_bit";
        /// <summary>
        /// Cached name for the 'set_bit_rect' method.
        /// </summary>
        public static readonly StringName SetBitRect = "set_bit_rect";
        /// <summary>
        /// Cached name for the 'get_true_bit_count' method.
        /// </summary>
        public static readonly StringName GetTrueBitCount = "get_true_bit_count";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'resize' method.
        /// </summary>
        public static readonly StringName Resize = "resize";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
        /// <summary>
        /// Cached name for the 'grow_mask' method.
        /// </summary>
        public static readonly StringName GrowMask = "grow_mask";
        /// <summary>
        /// Cached name for the 'convert_to_image' method.
        /// </summary>
        public static readonly StringName ConvertToImage = "convert_to_image";
        /// <summary>
        /// Cached name for the 'opaque_to_polygons' method.
        /// </summary>
        public static readonly StringName OpaqueToPolygons = "opaque_to_polygons";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
