namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GLTFAccessor is a data structure representing a glTF <c>accessor</c> that would be found in the <c>"accessors"</c> array. A buffer is a blob of binary data. A buffer view is a slice of a buffer. An accessor is a typed interpretation of the data in a buffer view.</para>
/// <para>Most custom data stored in glTF does not need accessors, only buffer views (see <see cref="Godot.GltfBufferView"/>). Accessors are for more advanced use cases such as interleaved mesh data encoded for the GPU.</para>
/// </summary>
[GodotClassName("GLTFAccessor")]
public partial class GltfAccessor : Resource
{
    public enum GltfAccessorType : long
    {
        /// <summary>
        /// <para>Accessor type "SCALAR". For the glTF object model, this can be used to map to a single float, int, or bool value, or a float array.</para>
        /// </summary>
        Scalar = 0,
        /// <summary>
        /// <para>Accessor type "VEC2". For the glTF object model, this maps to "float2", represented in the glTF JSON as an array of two floats.</para>
        /// </summary>
        Vec2 = 1,
        /// <summary>
        /// <para>Accessor type "VEC3". For the glTF object model, this maps to "float3", represented in the glTF JSON as an array of three floats.</para>
        /// </summary>
        Vec3 = 2,
        /// <summary>
        /// <para>Accessor type "VEC4". For the glTF object model, this maps to "float4", represented in the glTF JSON as an array of four floats.</para>
        /// </summary>
        Vec4 = 3,
        /// <summary>
        /// <para>Accessor type "MAT2". For the glTF object model, this maps to "float2x2", represented in the glTF JSON as an array of four floats.</para>
        /// </summary>
        Mat2 = 4,
        /// <summary>
        /// <para>Accessor type "MAT3". For the glTF object model, this maps to "float3x3", represented in the glTF JSON as an array of nine floats.</para>
        /// </summary>
        Mat3 = 5,
        /// <summary>
        /// <para>Accessor type "MAT4". For the glTF object model, this maps to "float4x4", represented in the glTF JSON as an array of sixteen floats.</para>
        /// </summary>
        Mat4 = 6
    }

    public enum GltfComponentType : long
    {
        /// <summary>
        /// <para>Component type "NONE". This is not a valid component type, and is used to indicate that the component type is not set.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Component type "BYTE". The value is <c>0x1400</c> which comes from OpenGL. This indicates data is stored in 1-byte or 8-bit signed integers. This is a core part of the glTF specification.</para>
        /// </summary>
        SignedByte = 5120,
        /// <summary>
        /// <para>Component type "UNSIGNED_BYTE". The value is <c>0x1401</c> which comes from OpenGL. This indicates data is stored in 1-byte or 8-bit unsigned integers. This is a core part of the glTF specification.</para>
        /// </summary>
        UnsignedByte = 5121,
        /// <summary>
        /// <para>Component type "SHORT". The value is <c>0x1402</c> which comes from OpenGL. This indicates data is stored in 2-byte or 16-bit signed integers. This is a core part of the glTF specification.</para>
        /// </summary>
        SignedShort = 5122,
        /// <summary>
        /// <para>Component type "UNSIGNED_SHORT". The value is <c>0x1403</c> which comes from OpenGL. This indicates data is stored in 2-byte or 16-bit unsigned integers. This is a core part of the glTF specification.</para>
        /// </summary>
        UnsignedShort = 5123,
        /// <summary>
        /// <para>Component type "INT". The value is <c>0x1404</c> which comes from OpenGL. This indicates data is stored in 4-byte or 32-bit signed integers. This is NOT a core part of the glTF specification, and may not be supported by all glTF importers. May be used by some extensions including <c>KHR_interactivity</c>.</para>
        /// </summary>
        SignedInt = 5124,
        /// <summary>
        /// <para>Component type "UNSIGNED_INT". The value is <c>0x1405</c> which comes from OpenGL. This indicates data is stored in 4-byte or 32-bit unsigned integers. This is a core part of the glTF specification.</para>
        /// </summary>
        UnsignedInt = 5125,
        /// <summary>
        /// <para>Component type "FLOAT". The value is <c>0x1406</c> which comes from OpenGL. This indicates data is stored in 4-byte or 32-bit floating-point numbers. This is a core part of the glTF specification.</para>
        /// </summary>
        SingleFloat = 5126,
        /// <summary>
        /// <para>Component type "DOUBLE". The value is <c>0x140A</c> which comes from OpenGL. This indicates data is stored in 8-byte or 64-bit floating-point numbers. This is NOT a core part of the glTF specification, and may not be supported by all glTF importers. May be used by some extensions including <c>KHR_interactivity</c>.</para>
        /// </summary>
        DoubleFloat = 5130,
        /// <summary>
        /// <para>Component type "HALF_FLOAT". The value is <c>0x140B</c> which comes from OpenGL. This indicates data is stored in 2-byte or 16-bit floating-point numbers. This is NOT a core part of the glTF specification, and may not be supported by all glTF importers. May be used by some extensions including <c>KHR_interactivity</c>.</para>
        /// </summary>
        HalfFloat = 5131,
        /// <summary>
        /// <para>Component type "LONG". The value is <c>0x140E</c> which comes from OpenGL. This indicates data is stored in 8-byte or 64-bit signed integers. This is NOT a core part of the glTF specification, and may not be supported by all glTF importers. May be used by some extensions including <c>KHR_interactivity</c>.</para>
        /// </summary>
        SignedLong = 5134,
        /// <summary>
        /// <para>Component type "UNSIGNED_LONG". The value is <c>0x140F</c> which comes from OpenGL. This indicates data is stored in 8-byte or 64-bit unsigned integers. This is NOT a core part of the glTF specification, and may not be supported by all glTF importers. May be used by some extensions including <c>KHR_interactivity</c>.</para>
        /// </summary>
        UnsignedLong = 5135
    }

    /// <summary>
    /// <para>The index of the buffer view this accessor is referencing. If <c>-1</c>, this accessor is not referencing any buffer view.</para>
    /// </summary>
    public int BufferView
    {
        get
        {
            return GetBufferView();
        }
        set
        {
            SetBufferView(value);
        }
    }

    /// <summary>
    /// <para>The offset relative to the start of the buffer view in bytes.</para>
    /// </summary>
    public long ByteOffset
    {
        get
        {
            return GetByteOffset();
        }
        set
        {
            SetByteOffset(value);
        }
    }

    /// <summary>
    /// <para>The glTF component type as an enum. See <see cref="Godot.GltfAccessor.GltfComponentType"/> for possible values. Within the core glTF specification, a value of 5125 or "UNSIGNED_INT" must not be used for any accessor that is not referenced by mesh.primitive.indices.</para>
    /// </summary>
    public GltfAccessor.GltfComponentType ComponentType
    {
        get
        {
            return GetComponentType();
        }
        set
        {
            SetComponentType(value);
        }
    }

    /// <summary>
    /// <para>Specifies whether integer data values are normalized before usage.</para>
    /// </summary>
    public bool Normalized
    {
        get
        {
            return GetNormalized();
        }
        set
        {
            SetNormalized(value);
        }
    }

    /// <summary>
    /// <para>The number of elements referenced by this accessor.</para>
    /// </summary>
    public long Count
    {
        get
        {
            return GetCount();
        }
        set
        {
            SetCount(value);
        }
    }

    /// <summary>
    /// <para>The glTF accessor type, as an enum.</para>
    /// </summary>
    public GltfAccessor.GltfAccessorType AccessorType
    {
        get
        {
            return GetAccessorType();
        }
        set
        {
            SetAccessorType(value);
        }
    }

    /// <summary>
    /// <para>The glTF accessor type, as an <see cref="int"/>. Possible values are <c>0</c> for "SCALAR", <c>1</c> for "VEC2", <c>2</c> for "VEC3", <c>3</c> for "VEC4", <c>4</c> for "MAT2", <c>5</c> for "MAT3", and <c>6</c> for "MAT4".</para>
    /// </summary>
    [Obsolete("Use 'Godot.GltfAccessor.AccessorType' instead.")]
    public int Type
    {
        get
        {
            return GetType();
        }
        set
        {
            SetType(value);
        }
    }

    /// <summary>
    /// <para>Minimum value of each component in this accessor.</para>
    /// </summary>
    public double[] Min
    {
        get
        {
            return GetMin();
        }
        set
        {
            SetMin(value);
        }
    }

    /// <summary>
    /// <para>Maximum value of each component in this accessor.</para>
    /// </summary>
    public double[] Max
    {
        get
        {
            return GetMax();
        }
        set
        {
            SetMax(value);
        }
    }

    /// <summary>
    /// <para>Number of deviating accessor values stored in the sparse array.</para>
    /// </summary>
    public long SparseCount
    {
        get
        {
            return GetSparseCount();
        }
        set
        {
            SetSparseCount(value);
        }
    }

    /// <summary>
    /// <para>The index of the buffer view with sparse indices. The referenced buffer view MUST NOT have its target or byteStride properties defined. The buffer view and the optional byteOffset MUST be aligned to the componentType byte length.</para>
    /// </summary>
    public int SparseIndicesBufferView
    {
        get
        {
            return GetSparseIndicesBufferView();
        }
        set
        {
            SetSparseIndicesBufferView(value);
        }
    }

    /// <summary>
    /// <para>The offset relative to the start of the buffer view in bytes.</para>
    /// </summary>
    public long SparseIndicesByteOffset
    {
        get
        {
            return GetSparseIndicesByteOffset();
        }
        set
        {
            SetSparseIndicesByteOffset(value);
        }
    }

    /// <summary>
    /// <para>The indices component data type as an enum. Possible values are 5121 for "UNSIGNED_BYTE", 5123 for "UNSIGNED_SHORT", and 5125 for "UNSIGNED_INT".</para>
    /// </summary>
    public GltfAccessor.GltfComponentType SparseIndicesComponentType
    {
        get
        {
            return GetSparseIndicesComponentType();
        }
        set
        {
            SetSparseIndicesComponentType(value);
        }
    }

    /// <summary>
    /// <para>The index of the bufferView with sparse values. The referenced buffer view MUST NOT have its target or byteStride properties defined.</para>
    /// </summary>
    public int SparseValuesBufferView
    {
        get
        {
            return GetSparseValuesBufferView();
        }
        set
        {
            SetSparseValuesBufferView(value);
        }
    }

    /// <summary>
    /// <para>The offset relative to the start of the bufferView in bytes.</para>
    /// </summary>
    public long SparseValuesByteOffset
    {
        get
        {
            return GetSparseValuesByteOffset();
        }
        set
        {
            SetSparseValuesByteOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfAccessor);

    private static readonly StringName NativeName = "GLTFAccessor";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfAccessor() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfAccessor(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfAccessor(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromDictionary, 3495091019ul);

    /// <summary>
    /// <para>Creates a new GLTFAccessor instance by parsing the given <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public static GltfAccessor FromDictionary(Godot.Collections.Dictionary dictionary)
    {
        return (GltfAccessor)NativeCalls.godot_icall_1_633(MethodBind0, (godot_dictionary)(dictionary ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToDictionary, 3102165223ul);

    /// <summary>
    /// <para>Serializes this GLTFAccessor instance into a <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary ToDictionary()
    {
        return NativeCalls.godot_icall_0_122(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBufferView, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBufferView()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBufferView, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBufferView(int bufferView)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), bufferView);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetByteOffset, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetByteOffset()
    {
        return NativeCalls.godot_icall_0_4(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetByteOffset, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetByteOffset(long byteOffset)
    {
        NativeCalls.godot_icall_1_10(MethodBind5, GodotObject.GetPtr(this), byteOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetComponentType, 852227802ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GltfAccessor.GltfComponentType GetComponentType()
    {
        return (GltfAccessor.GltfComponentType)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetComponentType, 1780020221ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetComponentType(GltfAccessor.GltfComponentType componentType)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), (int)componentType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormalized, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetNormalized()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNormalized, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNormalized(bool normalized)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), normalized.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetCount()
    {
        return NativeCalls.godot_icall_0_4(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCount(long count)
    {
        NativeCalls.godot_icall_1_10(MethodBind11, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessorType, 1998183368ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GltfAccessor.GltfAccessorType GetAccessorType()
    {
        return (GltfAccessor.GltfAccessorType)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessorType, 2347728198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessorType(GltfAccessor.GltfAccessorType accessorType)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), (int)accessorType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetType, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int GetType()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetType, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetType(int type)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMin, 547233126ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double[] GetMin()
    {
        return NativeCalls.godot_icall_0_634(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMin, 2576592201ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMin(double[] min)
    {
        NativeCalls.godot_icall_1_635(MethodBind17, GodotObject.GetPtr(this), min);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMin(ReadOnlySpan<double> min)
    {
        NativeCalls.godot_icall_1_635(MethodBind17, GodotObject.GetPtr(this), min);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMax, 547233126ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double[] GetMax()
    {
        return NativeCalls.godot_icall_0_634(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMax, 2576592201ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMax(double[] max)
    {
        NativeCalls.godot_icall_1_635(MethodBind19, GodotObject.GetPtr(this), max);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMax(ReadOnlySpan<double> max)
    {
        NativeCalls.godot_icall_1_635(MethodBind19, GodotObject.GetPtr(this), max);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSparseCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetSparseCount()
    {
        return NativeCalls.godot_icall_0_4(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSparseCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSparseCount(long sparseCount)
    {
        NativeCalls.godot_icall_1_10(MethodBind21, GodotObject.GetPtr(this), sparseCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSparseIndicesBufferView, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSparseIndicesBufferView()
    {
        return NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSparseIndicesBufferView, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSparseIndicesBufferView(int sparseIndicesBufferView)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), sparseIndicesBufferView);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSparseIndicesByteOffset, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetSparseIndicesByteOffset()
    {
        return NativeCalls.godot_icall_0_4(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSparseIndicesByteOffset, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSparseIndicesByteOffset(long sparseIndicesByteOffset)
    {
        NativeCalls.godot_icall_1_10(MethodBind25, GodotObject.GetPtr(this), sparseIndicesByteOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSparseIndicesComponentType, 852227802ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GltfAccessor.GltfComponentType GetSparseIndicesComponentType()
    {
        return (GltfAccessor.GltfComponentType)NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSparseIndicesComponentType, 1780020221ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSparseIndicesComponentType(GltfAccessor.GltfComponentType sparseIndicesComponentType)
    {
        NativeCalls.godot_icall_1_38(MethodBind27, GodotObject.GetPtr(this), (int)sparseIndicesComponentType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSparseValuesBufferView, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSparseValuesBufferView()
    {
        return NativeCalls.godot_icall_0_39(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSparseValuesBufferView, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSparseValuesBufferView(int sparseValuesBufferView)
    {
        NativeCalls.godot_icall_1_38(MethodBind29, GodotObject.GetPtr(this), sparseValuesBufferView);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSparseValuesByteOffset, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetSparseValuesByteOffset()
    {
        return NativeCalls.godot_icall_0_4(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSparseValuesByteOffset, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSparseValuesByteOffset(long sparseValuesByteOffset)
    {
        NativeCalls.godot_icall_1_10(MethodBind31, GodotObject.GetPtr(this), sparseValuesByteOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSparseIndicesComponentType, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSparseIndicesComponentType(int sparseIndicesComponentType)
    {
        NativeCalls.godot_icall_1_38(MethodBind32, GodotObject.GetPtr(this), sparseIndicesComponentType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetComponentType, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetComponentType(int componentType)
    {
        NativeCalls.godot_icall_1_38(MethodBind33, GodotObject.GetPtr(this), componentType);
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
        /// Cached name for the 'buffer_view' property.
        /// </summary>
        public static readonly StringName BufferView = "buffer_view";
        /// <summary>
        /// Cached name for the 'byte_offset' property.
        /// </summary>
        public static readonly StringName ByteOffset = "byte_offset";
        /// <summary>
        /// Cached name for the 'component_type' property.
        /// </summary>
        public static readonly StringName ComponentType = "component_type";
        /// <summary>
        /// Cached name for the 'normalized' property.
        /// </summary>
        public static readonly StringName Normalized = "normalized";
        /// <summary>
        /// Cached name for the 'count' property.
        /// </summary>
        public static readonly StringName Count = "count";
        /// <summary>
        /// Cached name for the 'accessor_type' property.
        /// </summary>
        public static readonly StringName AccessorType = "accessor_type";
        /// <summary>
        /// Cached name for the 'type' property.
        /// </summary>
        public static readonly StringName Type = "type";
        /// <summary>
        /// Cached name for the 'min' property.
        /// </summary>
        public static readonly StringName Min = "min";
        /// <summary>
        /// Cached name for the 'max' property.
        /// </summary>
        public static readonly StringName Max = "max";
        /// <summary>
        /// Cached name for the 'sparse_count' property.
        /// </summary>
        public static readonly StringName SparseCount = "sparse_count";
        /// <summary>
        /// Cached name for the 'sparse_indices_buffer_view' property.
        /// </summary>
        public static readonly StringName SparseIndicesBufferView = "sparse_indices_buffer_view";
        /// <summary>
        /// Cached name for the 'sparse_indices_byte_offset' property.
        /// </summary>
        public static readonly StringName SparseIndicesByteOffset = "sparse_indices_byte_offset";
        /// <summary>
        /// Cached name for the 'sparse_indices_component_type' property.
        /// </summary>
        public static readonly StringName SparseIndicesComponentType = "sparse_indices_component_type";
        /// <summary>
        /// Cached name for the 'sparse_values_buffer_view' property.
        /// </summary>
        public static readonly StringName SparseValuesBufferView = "sparse_values_buffer_view";
        /// <summary>
        /// Cached name for the 'sparse_values_byte_offset' property.
        /// </summary>
        public static readonly StringName SparseValuesByteOffset = "sparse_values_byte_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'from_dictionary' method.
        /// </summary>
        public static readonly StringName FromDictionary = "from_dictionary";
        /// <summary>
        /// Cached name for the 'to_dictionary' method.
        /// </summary>
        public static readonly StringName ToDictionary = "to_dictionary";
        /// <summary>
        /// Cached name for the 'get_buffer_view' method.
        /// </summary>
        public static readonly StringName GetBufferView = "get_buffer_view";
        /// <summary>
        /// Cached name for the 'set_buffer_view' method.
        /// </summary>
        public static readonly StringName SetBufferView = "set_buffer_view";
        /// <summary>
        /// Cached name for the 'get_byte_offset' method.
        /// </summary>
        public static readonly StringName GetByteOffset = "get_byte_offset";
        /// <summary>
        /// Cached name for the 'set_byte_offset' method.
        /// </summary>
        public static readonly StringName SetByteOffset = "set_byte_offset";
        /// <summary>
        /// Cached name for the 'get_component_type' method.
        /// </summary>
        public static readonly StringName GetComponentType = "get_component_type";
        /// <summary>
        /// Cached name for the 'set_component_type' method.
        /// </summary>
        public static readonly StringName SetComponentType = "set_component_type";
        /// <summary>
        /// Cached name for the 'get_normalized' method.
        /// </summary>
        public static readonly StringName GetNormalized = "get_normalized";
        /// <summary>
        /// Cached name for the 'set_normalized' method.
        /// </summary>
        public static readonly StringName SetNormalized = "set_normalized";
        /// <summary>
        /// Cached name for the 'get_count' method.
        /// </summary>
        public static readonly StringName GetCount = "get_count";
        /// <summary>
        /// Cached name for the 'set_count' method.
        /// </summary>
        public static readonly StringName SetCount = "set_count";
        /// <summary>
        /// Cached name for the 'get_accessor_type' method.
        /// </summary>
        public static readonly StringName GetAccessorType = "get_accessor_type";
        /// <summary>
        /// Cached name for the 'set_accessor_type' method.
        /// </summary>
        public static readonly StringName SetAccessorType = "set_accessor_type";
        /// <summary>
        /// Cached name for the 'get_type' method.
        /// </summary>
        public static new readonly StringName GetType = "get_type";
        /// <summary>
        /// Cached name for the 'set_type' method.
        /// </summary>
        public static readonly StringName SetType = "set_type";
        /// <summary>
        /// Cached name for the 'get_min' method.
        /// </summary>
        public static readonly StringName GetMin = "get_min";
        /// <summary>
        /// Cached name for the 'set_min' method.
        /// </summary>
        public static readonly StringName SetMin = "set_min";
        /// <summary>
        /// Cached name for the 'get_max' method.
        /// </summary>
        public static readonly StringName GetMax = "get_max";
        /// <summary>
        /// Cached name for the 'set_max' method.
        /// </summary>
        public static readonly StringName SetMax = "set_max";
        /// <summary>
        /// Cached name for the 'get_sparse_count' method.
        /// </summary>
        public static readonly StringName GetSparseCount = "get_sparse_count";
        /// <summary>
        /// Cached name for the 'set_sparse_count' method.
        /// </summary>
        public static readonly StringName SetSparseCount = "set_sparse_count";
        /// <summary>
        /// Cached name for the 'get_sparse_indices_buffer_view' method.
        /// </summary>
        public static readonly StringName GetSparseIndicesBufferView = "get_sparse_indices_buffer_view";
        /// <summary>
        /// Cached name for the 'set_sparse_indices_buffer_view' method.
        /// </summary>
        public static readonly StringName SetSparseIndicesBufferView = "set_sparse_indices_buffer_view";
        /// <summary>
        /// Cached name for the 'get_sparse_indices_byte_offset' method.
        /// </summary>
        public static readonly StringName GetSparseIndicesByteOffset = "get_sparse_indices_byte_offset";
        /// <summary>
        /// Cached name for the 'set_sparse_indices_byte_offset' method.
        /// </summary>
        public static readonly StringName SetSparseIndicesByteOffset = "set_sparse_indices_byte_offset";
        /// <summary>
        /// Cached name for the 'get_sparse_indices_component_type' method.
        /// </summary>
        public static readonly StringName GetSparseIndicesComponentType = "get_sparse_indices_component_type";
        /// <summary>
        /// Cached name for the 'set_sparse_indices_component_type' method.
        /// </summary>
        public static readonly StringName SetSparseIndicesComponentType = "set_sparse_indices_component_type";
        /// <summary>
        /// Cached name for the 'get_sparse_values_buffer_view' method.
        /// </summary>
        public static readonly StringName GetSparseValuesBufferView = "get_sparse_values_buffer_view";
        /// <summary>
        /// Cached name for the 'set_sparse_values_buffer_view' method.
        /// </summary>
        public static readonly StringName SetSparseValuesBufferView = "set_sparse_values_buffer_view";
        /// <summary>
        /// Cached name for the 'get_sparse_values_byte_offset' method.
        /// </summary>
        public static readonly StringName GetSparseValuesByteOffset = "get_sparse_values_byte_offset";
        /// <summary>
        /// Cached name for the 'set_sparse_values_byte_offset' method.
        /// </summary>
        public static readonly StringName SetSparseValuesByteOffset = "set_sparse_values_byte_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
