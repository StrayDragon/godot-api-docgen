namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Generate an axis-aligned box <see cref="Godot.PrimitiveMesh"/>.</para>
/// <para>The box's UV layout is arranged in a 3×2 layout that allows texturing each face individually. To apply the same texture on all faces, change the material's UV property to <c>Vector3(3, 2, 1)</c>. This is equivalent to adding <c>UV *= vec2(3.0, 2.0)</c> in a vertex shader.</para>
/// <para><b>Note:</b> When using a large textured <see cref="Godot.BoxMesh"/> (e.g. as a floor), you may stumble upon UV jittering issues depending on the camera angle. To solve this, increase <see cref="Godot.BoxMesh.SubdivideDepth"/>, <see cref="Godot.BoxMesh.SubdivideHeight"/> and <see cref="Godot.BoxMesh.SubdivideWidth"/> until you no longer notice UV jittering.</para>
/// </summary>
public partial class BoxMesh : PrimitiveMesh
{
    /// <summary>
    /// <para>The box's width, height and depth.</para>
    /// </summary>
    public Vector3 Size
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

    /// <summary>
    /// <para>Number of extra edge loops inserted along the X axis.</para>
    /// </summary>
    public int SubdivideWidth
    {
        get
        {
            return GetSubdivideWidth();
        }
        set
        {
            SetSubdivideWidth(value);
        }
    }

    /// <summary>
    /// <para>Number of extra edge loops inserted along the Y axis.</para>
    /// </summary>
    public int SubdivideHeight
    {
        get
        {
            return GetSubdivideHeight();
        }
        set
        {
            SetSubdivideHeight(value);
        }
    }

    /// <summary>
    /// <para>Number of extra edge loops inserted along the Z axis.</para>
    /// </summary>
    public int SubdivideDepth
    {
        get
        {
            return GetSubdivideDepth();
        }
        set
        {
            SetSubdivideDepth(value);
        }
    }

    private static readonly System.Type CachedType = typeof(BoxMesh);

    private static readonly StringName NativeName = "BoxMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public BoxMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal BoxMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal BoxMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector3 size)
    {
        NativeCalls.godot_icall_1_177(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubdivideWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubdivideWidth(int subdivide)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), subdivide);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdivideWidth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubdivideWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubdivideHeight, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubdivideHeight(int divisions)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), divisions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdivideHeight, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubdivideHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubdivideDepth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubdivideDepth(int divisions)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), divisions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdivideDepth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubdivideDepth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : PrimitiveMesh.PropertyName
    {
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'subdivide_width' property.
        /// </summary>
        public static readonly StringName SubdivideWidth = "subdivide_width";
        /// <summary>
        /// Cached name for the 'subdivide_height' property.
        /// </summary>
        public static readonly StringName SubdivideHeight = "subdivide_height";
        /// <summary>
        /// Cached name for the 'subdivide_depth' property.
        /// </summary>
        public static readonly StringName SubdivideDepth = "subdivide_depth";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PrimitiveMesh.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_subdivide_width' method.
        /// </summary>
        public static readonly StringName SetSubdivideWidth = "set_subdivide_width";
        /// <summary>
        /// Cached name for the 'get_subdivide_width' method.
        /// </summary>
        public static readonly StringName GetSubdivideWidth = "get_subdivide_width";
        /// <summary>
        /// Cached name for the 'set_subdivide_height' method.
        /// </summary>
        public static readonly StringName SetSubdivideHeight = "set_subdivide_height";
        /// <summary>
        /// Cached name for the 'get_subdivide_height' method.
        /// </summary>
        public static readonly StringName GetSubdivideHeight = "get_subdivide_height";
        /// <summary>
        /// Cached name for the 'set_subdivide_depth' method.
        /// </summary>
        public static readonly StringName SetSubdivideDepth = "set_subdivide_depth";
        /// <summary>
        /// Cached name for the 'get_subdivide_depth' method.
        /// </summary>
        public static readonly StringName GetSubdivideDepth = "get_subdivide_depth";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PrimitiveMesh.SignalName
    {
    }
}
