namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GLTFBufferView is a data structure representing a glTF <c>bufferView</c> that would be found in the <c>"bufferViews"</c> array. A buffer is a blob of binary data. A buffer view is a slice of a buffer that can be used to identify and extract data from the buffer.</para>
/// <para>Most custom uses of buffers only need to use the <see cref="Godot.GltfBufferView.Buffer"/>, <see cref="Godot.GltfBufferView.ByteLength"/>, and <see cref="Godot.GltfBufferView.ByteOffset"/>. The <see cref="Godot.GltfBufferView.ByteStride"/> and <see cref="Godot.GltfBufferView.Indices"/> properties are for more advanced use cases such as interleaved mesh data encoded for the GPU.</para>
/// </summary>
[GodotClassName("GLTFBufferView")]
public partial class GltfBufferView : Resource
{
    /// <summary>
    /// <para>The index of the buffer this buffer view is referencing. If <c>-1</c>, this buffer view is not referencing any buffer.</para>
    /// </summary>
    public int Buffer
    {
        get
        {
            return GetBuffer();
        }
        set
        {
            SetBuffer(value);
        }
    }

    /// <summary>
    /// <para>The offset, in bytes, from the start of the buffer to the start of this buffer view.</para>
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
    /// <para>The length, in bytes, of this buffer view. If <c>0</c>, this buffer view is empty.</para>
    /// </summary>
    public long ByteLength
    {
        get
        {
            return GetByteLength();
        }
        set
        {
            SetByteLength(value);
        }
    }

    /// <summary>
    /// <para>The stride, in bytes, between interleaved data. If <c>-1</c>, this buffer view is not interleaved.</para>
    /// </summary>
    public long ByteStride
    {
        get
        {
            return GetByteStride();
        }
        set
        {
            SetByteStride(value);
        }
    }

    /// <summary>
    /// <para><see langword="true"/> if the GLTFBufferView's OpenGL GPU buffer type is an <c>ELEMENT_ARRAY_BUFFER</c> used for vertex indices (integer constant <c>34963</c>). <see langword="false"/> if the buffer type is any other value. See <a href="https://github.com/KhronosGroup/glTF-Tutorials/blob/master/gltfTutorial/gltfTutorial_005_BuffersBufferViewsAccessors.md">Buffers, BufferViews, and Accessors</a> for possible values. This property is set on import and used on export.</para>
    /// </summary>
    public bool Indices
    {
        get
        {
            return GetIndices();
        }
        set
        {
            SetIndices(value);
        }
    }

    /// <summary>
    /// <para><see langword="true"/> if the GLTFBufferView's OpenGL GPU buffer type is an <c>ARRAY_BUFFER</c> used for vertex attributes (integer constant <c>34962</c>). <see langword="false"/> if the buffer type is any other value. See <a href="https://github.com/KhronosGroup/glTF-Tutorials/blob/master/gltfTutorial/gltfTutorial_005_BuffersBufferViewsAccessors.md">Buffers, BufferViews, and Accessors</a> for possible values. This property is set on import and used on export.</para>
    /// </summary>
    public bool VertexAttributes
    {
        get
        {
            return GetVertexAttributes();
        }
        set
        {
            SetVertexAttributes(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfBufferView);

    private static readonly StringName NativeName = "GLTFBufferView";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfBufferView() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfBufferView(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfBufferView(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadBufferViewData, 3945446907ul);

    /// <summary>
    /// <para>Loads the buffer view data from the buffer referenced by this buffer view in the given <see cref="Godot.GltfState"/>. Interleaved data with a byte stride is not yet supported by this method. The data is returned as a <see cref="byte"/>[].</para>
    /// </summary>
    public byte[] LoadBufferViewData(GltfState state)
    {
        return NativeCalls.godot_icall_1_636(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(state));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromDictionary, 2594413512ul);

    /// <summary>
    /// <para>Creates a new GLTFBufferView instance by parsing the given <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public static GltfBufferView FromDictionary(Godot.Collections.Dictionary dictionary)
    {
        return (GltfBufferView)NativeCalls.godot_icall_1_633(MethodBind1, (godot_dictionary)(dictionary ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToDictionary, 3102165223ul);

    /// <summary>
    /// <para>Serializes this GLTFBufferView instance into a <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary ToDictionary()
    {
        return NativeCalls.godot_icall_0_122(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBuffer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBuffer()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBuffer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBuffer(int buffer)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetByteOffset, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetByteOffset()
    {
        return NativeCalls.godot_icall_0_4(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetByteOffset, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetByteOffset(long byteOffset)
    {
        NativeCalls.godot_icall_1_10(MethodBind6, GodotObject.GetPtr(this), byteOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetByteLength, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetByteLength()
    {
        return NativeCalls.godot_icall_0_4(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetByteLength, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetByteLength(long byteLength)
    {
        NativeCalls.godot_icall_1_10(MethodBind8, GodotObject.GetPtr(this), byteLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetByteStride, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetByteStride()
    {
        return NativeCalls.godot_icall_0_4(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetByteStride, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetByteStride(long byteStride)
    {
        NativeCalls.godot_icall_1_10(MethodBind10, GodotObject.GetPtr(this), byteStride);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndices, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetIndices()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndices, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndices(bool indices)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), indices.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexAttributes, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetVertexAttributes()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexAttributes, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertexAttributes(bool isAttributes)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), isAttributes.ToGodotBool());
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
        /// Cached name for the 'buffer' property.
        /// </summary>
        public static readonly StringName Buffer = "buffer";
        /// <summary>
        /// Cached name for the 'byte_offset' property.
        /// </summary>
        public static readonly StringName ByteOffset = "byte_offset";
        /// <summary>
        /// Cached name for the 'byte_length' property.
        /// </summary>
        public static readonly StringName ByteLength = "byte_length";
        /// <summary>
        /// Cached name for the 'byte_stride' property.
        /// </summary>
        public static readonly StringName ByteStride = "byte_stride";
        /// <summary>
        /// Cached name for the 'indices' property.
        /// </summary>
        public static readonly StringName Indices = "indices";
        /// <summary>
        /// Cached name for the 'vertex_attributes' property.
        /// </summary>
        public static readonly StringName VertexAttributes = "vertex_attributes";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'load_buffer_view_data' method.
        /// </summary>
        public static readonly StringName LoadBufferViewData = "load_buffer_view_data";
        /// <summary>
        /// Cached name for the 'from_dictionary' method.
        /// </summary>
        public static readonly StringName FromDictionary = "from_dictionary";
        /// <summary>
        /// Cached name for the 'to_dictionary' method.
        /// </summary>
        public static readonly StringName ToDictionary = "to_dictionary";
        /// <summary>
        /// Cached name for the 'get_buffer' method.
        /// </summary>
        public static readonly StringName GetBuffer = "get_buffer";
        /// <summary>
        /// Cached name for the 'set_buffer' method.
        /// </summary>
        public static readonly StringName SetBuffer = "set_buffer";
        /// <summary>
        /// Cached name for the 'get_byte_offset' method.
        /// </summary>
        public static readonly StringName GetByteOffset = "get_byte_offset";
        /// <summary>
        /// Cached name for the 'set_byte_offset' method.
        /// </summary>
        public static readonly StringName SetByteOffset = "set_byte_offset";
        /// <summary>
        /// Cached name for the 'get_byte_length' method.
        /// </summary>
        public static readonly StringName GetByteLength = "get_byte_length";
        /// <summary>
        /// Cached name for the 'set_byte_length' method.
        /// </summary>
        public static readonly StringName SetByteLength = "set_byte_length";
        /// <summary>
        /// Cached name for the 'get_byte_stride' method.
        /// </summary>
        public static readonly StringName GetByteStride = "get_byte_stride";
        /// <summary>
        /// Cached name for the 'set_byte_stride' method.
        /// </summary>
        public static readonly StringName SetByteStride = "set_byte_stride";
        /// <summary>
        /// Cached name for the 'get_indices' method.
        /// </summary>
        public static readonly StringName GetIndices = "get_indices";
        /// <summary>
        /// Cached name for the 'set_indices' method.
        /// </summary>
        public static readonly StringName SetIndices = "set_indices";
        /// <summary>
        /// Cached name for the 'get_vertex_attributes' method.
        /// </summary>
        public static readonly StringName GetVertexAttributes = "get_vertex_attributes";
        /// <summary>
        /// Cached name for the 'set_vertex_attributes' method.
        /// </summary>
        public static readonly StringName SetVertexAttributes = "set_vertex_attributes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
