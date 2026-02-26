namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents a glTF node. glTF nodes may have names, transforms, children (other glTF nodes), and more specialized properties (represented by their own classes).</para>
/// <para>glTF nodes generally exist inside of <see cref="Godot.GltfState"/> which represents all data of a glTF file. Most of GLTFNode's properties are indices of other data in the glTF file. You can extend a glTF node with additional properties by using <see cref="Godot.GltfNode.GetAdditionalData(StringName)"/> and <see cref="Godot.GltfNode.SetAdditionalData(StringName, Variant)"/>.</para>
/// </summary>
[GodotClassName("GLTFNode")]
public partial class GltfNode : Resource
{
    /// <summary>
    /// <para>The original name of the node.</para>
    /// </summary>
    public string OriginalName
    {
        get
        {
            return GetOriginalName();
        }
        set
        {
            SetOriginalName(value);
        }
    }

    /// <summary>
    /// <para>The index of the parent node in the <see cref="Godot.GltfState"/>. If -1, this node is a root node.</para>
    /// </summary>
    public int Parent
    {
        get
        {
            return GetParent();
        }
        set
        {
            SetParent(value);
        }
    }

    /// <summary>
    /// <para>How deep into the node hierarchy this node is. A root node will have a height of 0, its children will have a height of 1, and so on. If -1, the height has not been calculated.</para>
    /// </summary>
    public int Height
    {
        get
        {
            return GetHeight();
        }
        set
        {
            SetHeight(value);
        }
    }

    /// <summary>
    /// <para>The transform of the glTF node relative to its parent. This property is usually unused since the position, rotation, and scale properties are preferred.</para>
    /// </summary>
    public Transform3D Xform
    {
        get
        {
            return GetXform();
        }
        set
        {
            SetXform(value);
        }
    }

    /// <summary>
    /// <para>If this glTF node is a mesh, the index of the <see cref="Godot.GltfMesh"/> in the <see cref="Godot.GltfState"/> that describes the mesh's properties. If -1, this node is not a mesh.</para>
    /// </summary>
    public int Mesh
    {
        get
        {
            return GetMesh();
        }
        set
        {
            SetMesh(value);
        }
    }

    /// <summary>
    /// <para>If this glTF node is a camera, the index of the <see cref="Godot.GltfCamera"/> in the <see cref="Godot.GltfState"/> that describes the camera's properties. If <c>-1</c>, this node is not a camera.</para>
    /// </summary>
    public int Camera
    {
        get
        {
            return GetCamera();
        }
        set
        {
            SetCamera(value);
        }
    }

    /// <summary>
    /// <para>If this glTF node has a skin, the index of the <see cref="Godot.GltfSkin"/> in the <see cref="Godot.GltfState"/> that describes the skin's properties. If -1, this node does not have a skin.</para>
    /// </summary>
    public int Skin
    {
        get
        {
            return GetSkin();
        }
        set
        {
            SetSkin(value);
        }
    }

    /// <summary>
    /// <para>If this glTF node has a skeleton, the index of the <see cref="Godot.GltfSkeleton"/> in the <see cref="Godot.GltfState"/> that describes the skeleton's properties. If -1, this node does not have a skeleton.</para>
    /// </summary>
    public int Skeleton
    {
        get
        {
            return GetSkeleton();
        }
        set
        {
            SetSkeleton(value);
        }
    }

    /// <summary>
    /// <para>The position of the glTF node relative to its parent.</para>
    /// </summary>
    public Vector3 Position
    {
        get
        {
            return GetPosition();
        }
        set
        {
            SetPosition(value);
        }
    }

    /// <summary>
    /// <para>The rotation of the glTF node relative to its parent.</para>
    /// </summary>
    public Quaternion Rotation
    {
        get
        {
            return GetRotation();
        }
        set
        {
            SetRotation(value);
        }
    }

    /// <summary>
    /// <para>The scale of the glTF node relative to its parent.</para>
    /// </summary>
    public Vector3 Scale
    {
        get
        {
            return GetScale();
        }
        set
        {
            SetScale(value);
        }
    }

    /// <summary>
    /// <para>The indices of the child nodes in the <see cref="Godot.GltfState"/>. If this glTF node has no children, this will be an empty array.</para>
    /// </summary>
    public int[] Children
    {
        get
        {
            return GetChildren();
        }
        set
        {
            SetChildren(value);
        }
    }

    /// <summary>
    /// <para>If this glTF node is a light, the index of the <see cref="Godot.GltfLight"/> in the <see cref="Godot.GltfState"/> that describes the light's properties. If -1, this node is not a light.</para>
    /// </summary>
    public int Light
    {
        get
        {
            return GetLight();
        }
        set
        {
            SetLight(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the GLTF node is visible. If <see langword="false"/>, the GLTF node is not visible. This is converted to the <see cref="Godot.Node3D.Visible"/> property in the Godot scene, and is exported to <c>KHR_node_visibility</c> when <see langword="false"/>.</para>
    /// </summary>
    public bool Visible
    {
        get
        {
            return GetVisible();
        }
        set
        {
            SetVisible(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfNode);

    private static readonly StringName NativeName = "GLTFNode";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfNode() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfNode(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfNode(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginalName, 2841200299ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetOriginalName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginalName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginalName(string originalName)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), originalName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParent, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetParent()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParent, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParent(int parent)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), parent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeight, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeight(int height)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetXform, 4183770049ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetXform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetXform, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetXform(Transform3D xform)
    {
        NativeCalls.godot_icall_1_648(MethodBind7, GodotObject.GetPtr(this), &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMesh()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(int mesh)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCamera, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCamera()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCamera, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCamera(int camera)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), camera);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkin, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSkin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkin(int skin)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), skin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeleton, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSkeleton()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkeleton, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkeleton(int skeleton)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3783033775ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector3 position)
    {
        NativeCalls.godot_icall_1_177(MethodBind17, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotation, 2916281908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quaternion GetRotation()
    {
        return NativeCalls.godot_icall_0_126(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotation, 1727505552ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRotation(Quaternion rotation)
    {
        NativeCalls.godot_icall_1_649(MethodBind19, GodotObject.GetPtr(this), &rotation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScale, 3783033775ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetScale()
    {
        return NativeCalls.godot_icall_0_125(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScale, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScale(Vector3 scale)
    {
        NativeCalls.godot_icall_1_177(MethodBind21, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChildren, 969006518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetChildren()
    {
        return NativeCalls.godot_icall_0_151(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetChildren, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetChildren(int[] children)
    {
        NativeCalls.godot_icall_1_150(MethodBind23, GodotObject.GetPtr(this), children);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetChildren(ReadOnlySpan<int> children)
    {
        NativeCalls.godot_icall_1_150(MethodBind23, GodotObject.GetPtr(this), children);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendChildIndex, 1286410249ul);

    /// <summary>
    /// <para>Appends the given child node index to the <see cref="Godot.GltfNode.Children"/> array.</para>
    /// </summary>
    public void AppendChildIndex(int childIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), childIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLight, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLight, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLight(int light)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), light);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisible, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind27, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdditionalData, 2138907829ul);

    /// <summary>
    /// <para>Gets additional arbitrary data in this <see cref="Godot.GltfNode"/> instance. This can be used to keep per-node state data in <see cref="Godot.GltfDocumentExtension"/> classes, which is important because they are stateless.</para>
    /// <para>The argument should be the <see cref="Godot.GltfDocumentExtension"/> name (does not have to match the extension name in the glTF file), and the return value can be anything you set. If nothing was set, the return value is <see langword="null"/>.</para>
    /// </summary>
    public Variant GetAdditionalData(StringName extensionName)
    {
        return NativeCalls.godot_icall_1_143(MethodBind29, GodotObject.GetPtr(this), (godot_string_name)(extensionName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdditionalData, 3776071444ul);

    /// <summary>
    /// <para>Sets additional arbitrary data in this <see cref="Godot.GltfNode"/> instance. This can be used to keep per-node state data in <see cref="Godot.GltfDocumentExtension"/> classes, which is important because they are stateless.</para>
    /// <para>The first argument should be the <see cref="Godot.GltfDocumentExtension"/> name (does not have to match the extension name in the glTF file), and the second argument can be anything you want.</para>
    /// </summary>
    public void SetAdditionalData(StringName extensionName, Variant additionalData)
    {
        NativeCalls.godot_icall_2_142(MethodBind30, GodotObject.GetPtr(this), (godot_string_name)(extensionName?.NativeValue ?? default), additionalData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneNodePath, 573359477ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.NodePath"/> that this GLTF node will have in the Godot scene tree after being imported. This is useful when importing glTF object model pointers with <see cref="Godot.GltfObjectModelProperty"/>, for handling extensions such as <c>KHR_animation_pointer</c> or <c>KHR_interactivity</c>.</para>
    /// <para>If <paramref name="handleSkeletons"/> is <see langword="true"/>, paths to skeleton bone glTF nodes will be resolved properly. For example, a path that would be <c>^"A/B/C/Bone1/Bone2/Bone3"</c> if <see langword="false"/> will become <c>^"A/B/C/Skeleton3D:Bone3"</c>.</para>
    /// </summary>
    public NodePath GetSceneNodePath(GltfState gltfState, bool handleSkeletons = true)
    {
        return NativeCalls.godot_icall_2_650(MethodBind31, GodotObject.GetPtr(this), GodotObject.GetPtr(gltfState), handleSkeletons.ToGodotBool());
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
        /// Cached name for the 'original_name' property.
        /// </summary>
        public static readonly StringName OriginalName = "original_name";
        /// <summary>
        /// Cached name for the 'parent' property.
        /// </summary>
        public static readonly StringName Parent = "parent";
        /// <summary>
        /// Cached name for the 'height' property.
        /// </summary>
        public static readonly StringName Height = "height";
        /// <summary>
        /// Cached name for the 'xform' property.
        /// </summary>
        public static readonly StringName Xform = "xform";
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
        /// <summary>
        /// Cached name for the 'camera' property.
        /// </summary>
        public static readonly StringName Camera = "camera";
        /// <summary>
        /// Cached name for the 'skin' property.
        /// </summary>
        public static readonly StringName Skin = "skin";
        /// <summary>
        /// Cached name for the 'skeleton' property.
        /// </summary>
        public static readonly StringName Skeleton = "skeleton";
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'rotation' property.
        /// </summary>
        public static readonly StringName Rotation = "rotation";
        /// <summary>
        /// Cached name for the 'scale' property.
        /// </summary>
        public static readonly StringName Scale = "scale";
        /// <summary>
        /// Cached name for the 'children' property.
        /// </summary>
        public static readonly StringName Children = "children";
        /// <summary>
        /// Cached name for the 'light' property.
        /// </summary>
        public static readonly StringName Light = "light";
        /// <summary>
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_original_name' method.
        /// </summary>
        public static readonly StringName GetOriginalName = "get_original_name";
        /// <summary>
        /// Cached name for the 'set_original_name' method.
        /// </summary>
        public static readonly StringName SetOriginalName = "set_original_name";
        /// <summary>
        /// Cached name for the 'get_parent' method.
        /// </summary>
        public static readonly StringName GetParent = "get_parent";
        /// <summary>
        /// Cached name for the 'set_parent' method.
        /// </summary>
        public static readonly StringName SetParent = "set_parent";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
        /// <summary>
        /// Cached name for the 'set_height' method.
        /// </summary>
        public static readonly StringName SetHeight = "set_height";
        /// <summary>
        /// Cached name for the 'get_xform' method.
        /// </summary>
        public static readonly StringName GetXform = "get_xform";
        /// <summary>
        /// Cached name for the 'set_xform' method.
        /// </summary>
        public static readonly StringName SetXform = "set_xform";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_camera' method.
        /// </summary>
        public static readonly StringName GetCamera = "get_camera";
        /// <summary>
        /// Cached name for the 'set_camera' method.
        /// </summary>
        public static readonly StringName SetCamera = "set_camera";
        /// <summary>
        /// Cached name for the 'get_skin' method.
        /// </summary>
        public static readonly StringName GetSkin = "get_skin";
        /// <summary>
        /// Cached name for the 'set_skin' method.
        /// </summary>
        public static readonly StringName SetSkin = "set_skin";
        /// <summary>
        /// Cached name for the 'get_skeleton' method.
        /// </summary>
        public static readonly StringName GetSkeleton = "get_skeleton";
        /// <summary>
        /// Cached name for the 'set_skeleton' method.
        /// </summary>
        public static readonly StringName SetSkeleton = "set_skeleton";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_rotation' method.
        /// </summary>
        public static readonly StringName GetRotation = "get_rotation";
        /// <summary>
        /// Cached name for the 'set_rotation' method.
        /// </summary>
        public static readonly StringName SetRotation = "set_rotation";
        /// <summary>
        /// Cached name for the 'get_scale' method.
        /// </summary>
        public static readonly StringName GetScale = "get_scale";
        /// <summary>
        /// Cached name for the 'set_scale' method.
        /// </summary>
        public static readonly StringName SetScale = "set_scale";
        /// <summary>
        /// Cached name for the 'get_children' method.
        /// </summary>
        public static readonly StringName GetChildren = "get_children";
        /// <summary>
        /// Cached name for the 'set_children' method.
        /// </summary>
        public static readonly StringName SetChildren = "set_children";
        /// <summary>
        /// Cached name for the 'append_child_index' method.
        /// </summary>
        public static readonly StringName AppendChildIndex = "append_child_index";
        /// <summary>
        /// Cached name for the 'get_light' method.
        /// </summary>
        public static readonly StringName GetLight = "get_light";
        /// <summary>
        /// Cached name for the 'set_light' method.
        /// </summary>
        public static readonly StringName SetLight = "set_light";
        /// <summary>
        /// Cached name for the 'get_visible' method.
        /// </summary>
        public static readonly StringName GetVisible = "get_visible";
        /// <summary>
        /// Cached name for the 'set_visible' method.
        /// </summary>
        public static readonly StringName SetVisible = "set_visible";
        /// <summary>
        /// Cached name for the 'get_additional_data' method.
        /// </summary>
        public static readonly StringName GetAdditionalData = "get_additional_data";
        /// <summary>
        /// Cached name for the 'set_additional_data' method.
        /// </summary>
        public static readonly StringName SetAdditionalData = "set_additional_data";
        /// <summary>
        /// Cached name for the 'get_scene_node_path' method.
        /// </summary>
        public static readonly StringName GetSceneNodePath = "get_scene_node_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
