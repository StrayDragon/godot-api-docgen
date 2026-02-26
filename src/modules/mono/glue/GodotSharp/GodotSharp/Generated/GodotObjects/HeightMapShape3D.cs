namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 3D heightmap shape, intended for use in physics to provide a shape for a <see cref="Godot.CollisionShape3D"/>. This type is most commonly used for terrain with vertices placed in a fixed-width grid.</para>
/// <para>The heightmap is represented as a 2D grid of height values, which represent the position of grid points on the Y axis. Grid points are spaced 1 unit apart on the X and Z axes, and the grid is centered on the origin of the <see cref="Godot.CollisionShape3D"/> node. Internally, each grid square is divided into two triangles.</para>
/// <para>Due to the nature of the heightmap, it cannot be used to model overhangs or caves, which would require multiple vertices at the same vertical location. Holes can be punched through the collision by assigning <c>@GDScript.NAN</c> to the height of the desired vertices (this is supported in both GodotPhysics3D and Jolt Physics). You could then insert meshes with their own separate collision to provide overhangs, caves, and so on.</para>
/// <para><b>Performance:</b> <see cref="Godot.HeightMapShape3D"/> is faster to check collisions against than <see cref="Godot.ConcavePolygonShape3D"/>, but it is significantly slower than primitive shapes like <see cref="Godot.BoxShape3D"/>.</para>
/// <para>A heightmap collision shape can also be built by using an <see cref="Godot.Image"/> reference:</para>
/// <para></para>
/// <para><b>Note:</b> If you need to use a spacing different than 1 unit, you can adjust the <see cref="Godot.Node3D.Scale"/> of the shape. However, keep in mind that GodotPhysics3D does not support non-uniform scaling: you'll need to scale the Y axis by the same amount as the X and Z axes, which means the values in <see cref="Godot.HeightMapShape3D.MapData"/> will need to be pre-scaled by the inverse of that scale. Also note that GodotPhysics3D does not support scaling at all for dynamic bodies (that is, non-frozen <see cref="Godot.RigidBody3D"/> nodes); to use a scaled <see cref="Godot.HeightMapShape3D"/> with those, you will need to use Jolt Physics.</para>
/// </summary>
public partial class HeightMapShape3D : Shape3D
{
    /// <summary>
    /// <para>Number of vertices in the width of the heightmap. Changing this will resize the <see cref="Godot.HeightMapShape3D.MapData"/>.</para>
    /// </summary>
    public int MapWidth
    {
        get
        {
            return GetMapWidth();
        }
        set
        {
            SetMapWidth(value);
        }
    }

    /// <summary>
    /// <para>Number of vertices in the depth of the heightmap. Changing this will resize the <see cref="Godot.HeightMapShape3D.MapData"/>.</para>
    /// </summary>
    public int MapDepth
    {
        get
        {
            return GetMapDepth();
        }
        set
        {
            SetMapDepth(value);
        }
    }

    /// <summary>
    /// <para>Heightmap data. The array's size must be equal to <see cref="Godot.HeightMapShape3D.MapWidth"/> multiplied by <see cref="Godot.HeightMapShape3D.MapDepth"/>.</para>
    /// </summary>
    public float[] MapData
    {
        get
        {
            return GetMapData();
        }
        set
        {
            SetMapData(value);
        }
    }

    private static readonly System.Type CachedType = typeof(HeightMapShape3D);

    private static readonly StringName NativeName = "HeightMapShape3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public HeightMapShape3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal HeightMapShape3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal HeightMapShape3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMapWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMapWidth(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMapWidth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMapWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMapDepth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMapDepth(int height)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMapDepth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMapDepth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMapData, 2899603908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMapData(float[] data)
    {
        NativeCalls.godot_icall_1_647(MethodBind4, GodotObject.GetPtr(this), data);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMapData(ReadOnlySpan<float> data)
    {
        NativeCalls.godot_icall_1_647(MethodBind4, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMapData, 675695659ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float[] GetMapData()
    {
        return NativeCalls.godot_icall_0_368(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinHeight, 1740695150ul);

    /// <summary>
    /// <para>Returns the smallest height value found in <see cref="Godot.HeightMapShape3D.MapData"/>. Recalculates only when <see cref="Godot.HeightMapShape3D.MapData"/> changes.</para>
    /// </summary>
    public float GetMinHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxHeight, 1740695150ul);

    /// <summary>
    /// <para>Returns the largest height value found in <see cref="Godot.HeightMapShape3D.MapData"/>. Recalculates only when <see cref="Godot.HeightMapShape3D.MapData"/> changes.</para>
    /// </summary>
    public float GetMaxHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateMapDataFromImage, 2636652979ul);

    /// <summary>
    /// <para>Updates <see cref="Godot.HeightMapShape3D.MapData"/> with data read from an <see cref="Godot.Image"/> reference. Automatically resizes heightmap <see cref="Godot.HeightMapShape3D.MapWidth"/> and <see cref="Godot.HeightMapShape3D.MapDepth"/> to fit the full image width and height.</para>
    /// <para>The image needs to be in either <see cref="Godot.Image.Format.Rf"/> (32 bit), <see cref="Godot.Image.Format.Rh"/> (16 bit), or <see cref="Godot.Image.Format.R8"/> (8 bit).</para>
    /// <para>Each image pixel is read in as a float on the range from <c>0.0</c> (black pixel) to <c>1.0</c> (white pixel). This range value gets remapped to <paramref name="heightMin"/> and <paramref name="heightMax"/> to form the final height value.</para>
    /// <para><b>Note:</b> Using a heightmap with 16-bit or 32-bit data, stored in EXR or HDR format is recommended. Using 8-bit height data, or a format like PNG that Godot imports as 8-bit, will result in a terraced terrain.</para>
    /// </summary>
    public void UpdateMapDataFromImage(Image image, float heightMin, float heightMax)
    {
        NativeCalls.godot_icall_3_720(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(image), heightMin, heightMax);
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
    public new class PropertyName : Shape3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'map_width' property.
        /// </summary>
        public static readonly StringName MapWidth = "map_width";
        /// <summary>
        /// Cached name for the 'map_depth' property.
        /// </summary>
        public static readonly StringName MapDepth = "map_depth";
        /// <summary>
        /// Cached name for the 'map_data' property.
        /// </summary>
        public static readonly StringName MapData = "map_data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_map_width' method.
        /// </summary>
        public static readonly StringName SetMapWidth = "set_map_width";
        /// <summary>
        /// Cached name for the 'get_map_width' method.
        /// </summary>
        public static readonly StringName GetMapWidth = "get_map_width";
        /// <summary>
        /// Cached name for the 'set_map_depth' method.
        /// </summary>
        public static readonly StringName SetMapDepth = "set_map_depth";
        /// <summary>
        /// Cached name for the 'get_map_depth' method.
        /// </summary>
        public static readonly StringName GetMapDepth = "get_map_depth";
        /// <summary>
        /// Cached name for the 'set_map_data' method.
        /// </summary>
        public static readonly StringName SetMapData = "set_map_data";
        /// <summary>
        /// Cached name for the 'get_map_data' method.
        /// </summary>
        public static readonly StringName GetMapData = "get_map_data";
        /// <summary>
        /// Cached name for the 'get_min_height' method.
        /// </summary>
        public static readonly StringName GetMinHeight = "get_min_height";
        /// <summary>
        /// Cached name for the 'get_max_height' method.
        /// </summary>
        public static readonly StringName GetMaxHeight = "get_max_height";
        /// <summary>
        /// Cached name for the 'update_map_data_from_image' method.
        /// </summary>
        public static readonly StringName UpdateMapDataFromImage = "update_map_data_from_image";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape3D.SignalName
    {
    }
}
