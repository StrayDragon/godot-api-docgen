namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GLTFDocument supports reading data from a glTF file, buffer, or Godot scene. This data can then be written to the filesystem, buffer, or used to create a Godot scene.</para>
/// <para>All of the data in a glTF scene is stored in the <see cref="Godot.GltfState"/> class. GLTFDocument processes state objects, but does not contain any scene data itself. GLTFDocument has member variables to store export configuration settings such as the image format, but is otherwise stateless. Multiple scenes can be processed with the same settings using the same GLTFDocument object and different <see cref="Godot.GltfState"/> objects.</para>
/// <para>GLTFDocument can be extended with arbitrary functionality by extending the <see cref="Godot.GltfDocumentExtension"/> class and registering it with GLTFDocument via <see cref="Godot.GltfDocument.RegisterGltfDocumentExtension(GltfDocumentExtension, bool)"/>. This allows for custom data to be imported and exported.</para>
/// </summary>
[GodotClassName("GLTFDocument")]
public partial class GltfDocument : Resource
{
    public enum RootNodeModeEnum : long
    {
        /// <summary>
        /// <para>Treat the Godot scene's root node as the root node of the glTF file, and mark it as the single root node via the <c>GODOT_single_root</c> glTF extension. This will be parsed the same as <see cref="Godot.GltfDocument.RootNodeModeEnum.KeepRoot"/> if the implementation does not support <c>GODOT_single_root</c>.</para>
        /// </summary>
        SingleRoot = 0,
        /// <summary>
        /// <para>Treat the Godot scene's root node as the root node of the glTF file, but do not mark it as anything special. An extra root node will be generated when importing into Godot. This uses only vanilla glTF features. This is equivalent to the behavior in Godot 4.1 and earlier.</para>
        /// </summary>
        KeepRoot = 1,
        /// <summary>
        /// <para>Treat the Godot scene's root node as the name of the glTF scene, and add all of its children as root nodes of the glTF file. This uses only vanilla glTF features. This avoids an extra root node, but only the name of the Godot scene's root node will be preserved, as it will not be saved as a node.</para>
        /// </summary>
        MultiRoot = 2
    }

    public enum VisibilityModeEnum : long
    {
        /// <summary>
        /// <para>If the scene contains any non-visible nodes, include them, mark them as non-visible with <c>KHR_node_visibility</c>, and require that importers respect their non-visibility. Downside: If the importer does not support <c>KHR_node_visibility</c>, the file cannot be imported.</para>
        /// </summary>
        IncludeRequired = 0,
        /// <summary>
        /// <para>If the scene contains any non-visible nodes, include them, mark them as non-visible with <c>KHR_node_visibility</c>, and do not impose any requirements on importers. Downside: If the importer does not support <c>KHR_node_visibility</c>, invisible objects will be visible.</para>
        /// </summary>
        IncludeOptional = 1,
        /// <summary>
        /// <para>If the scene contains any non-visible nodes, do not include them in the export. This is the same as the behavior in Godot 4.4 and earlier. Downside: Invisible nodes will not exist in the exported file.</para>
        /// </summary>
        Exclude = 2
    }

    /// <summary>
    /// <para>The user-friendly name of the export image format. This is used when exporting the glTF file, including writing to a file and writing to a byte array.</para>
    /// <para>By default, Godot allows the following options: "None", "PNG", "JPEG", "Lossless WebP", and "Lossy WebP". Support for more image formats can be added in <see cref="Godot.GltfDocumentExtension"/> classes. A single extension class can provide multiple options for the specific format to use, or even an option that uses multiple formats at once.</para>
    /// </summary>
    public string ImageFormat
    {
        get
        {
            return GetImageFormat();
        }
        set
        {
            SetImageFormat(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.GltfDocument.ImageFormat"/> is a lossy image format, this determines the lossy quality of the image. On a range of <c>0.0</c> to <c>1.0</c>, where <c>0.0</c> is the lowest quality and <c>1.0</c> is the highest quality. A lossy quality of <c>1.0</c> is not the same as lossless.</para>
    /// </summary>
    public float LossyQuality
    {
        get
        {
            return GetLossyQuality();
        }
        set
        {
            SetLossyQuality(value);
        }
    }

    /// <summary>
    /// <para>The user-friendly name of the fallback image format. This is used when exporting the glTF file, including writing to a file and writing to a byte array.</para>
    /// <para>This property may only be one of "None", "PNG", or "JPEG", and is only used when the <see cref="Godot.GltfDocument.ImageFormat"/> is not one of "None", "PNG", or "JPEG". If having multiple extension image formats is desired, that can be done using a <see cref="Godot.GltfDocumentExtension"/> class - this property only covers the use case of providing a base glTF fallback image when using a custom image format.</para>
    /// </summary>
    public string FallbackImageFormat
    {
        get
        {
            return GetFallbackImageFormat();
        }
        set
        {
            SetFallbackImageFormat(value);
        }
    }

    /// <summary>
    /// <para>The quality of the fallback image, if any. For PNG files, this downscales the image on both dimensions by this factor. For JPEG files, this is the lossy quality of the image. A low value is recommended, since including multiple high quality images in a glTF file defeats the file size gains of using a more efficient image format.</para>
    /// </summary>
    public float FallbackImageQuality
    {
        get
        {
            return GetFallbackImageQuality();
        }
        set
        {
            SetFallbackImageQuality(value);
        }
    }

    /// <summary>
    /// <para>How to process the root node during export. The default and recommended value is <see cref="Godot.GltfDocument.RootNodeModeEnum.SingleRoot"/>.</para>
    /// <para><b>Note:</b> Regardless of how the glTF file is exported, when importing, the root node type and name can be overridden in the scene import settings tab.</para>
    /// </summary>
    public GltfDocument.RootNodeModeEnum RootNodeMode
    {
        get
        {
            return GetRootNodeMode();
        }
        set
        {
            SetRootNodeMode(value);
        }
    }

    /// <summary>
    /// <para>How to deal with node visibility during export. This setting does nothing if all nodes are visible. The default and recommended value is <see cref="Godot.GltfDocument.VisibilityModeEnum.IncludeRequired"/>, which uses the <c>KHR_node_visibility</c> extension.</para>
    /// </summary>
    public GltfDocument.VisibilityModeEnum VisibilityMode
    {
        get
        {
            return GetVisibilityMode();
        }
        set
        {
            SetVisibilityMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfDocument);

    private static readonly StringName NativeName = "GLTFDocument";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfDocument() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfDocument(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfDocument(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetImageFormat, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetImageFormat(string imageFormat)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), imageFormat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetImageFormat, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetImageFormat()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLossyQuality, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLossyQuality(float lossyQuality)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), lossyQuality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLossyQuality, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLossyQuality()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackImageFormat, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackImageFormat(string fallbackImageFormat)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), fallbackImageFormat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackImageFormat, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetFallbackImageFormat()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackImageQuality, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackImageQuality(float fallbackImageQuality)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), fallbackImageQuality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackImageQuality, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFallbackImageQuality()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootNodeMode, 463633402ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootNodeMode(GltfDocument.RootNodeModeEnum rootNodeMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)rootNodeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootNodeMode, 948057992ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GltfDocument.RootNodeModeEnum GetRootNodeMode()
    {
        return (GltfDocument.RootNodeModeEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityMode, 2803579218ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityMode(GltfDocument.VisibilityModeEnum visibilityMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)visibilityMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityMode, 3885445962ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GltfDocument.VisibilityModeEnum GetVisibilityMode()
    {
        return (GltfDocument.VisibilityModeEnum)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendFromFile, 866380864ul);

    /// <summary>
    /// <para>Takes a path to a glTF file and imports the data at that file path to the given <see cref="Godot.GltfState"/> object through the <paramref name="state"/> parameter.</para>
    /// <para><b>Note:</b> The <paramref name="basePath"/> tells <see cref="Godot.GltfDocument.AppendFromFile(string, GltfState, uint, string)"/> where to find dependencies and can be empty.</para>
    /// </summary>
    public Error AppendFromFile(string path, GltfState state, uint flags = (uint)(0), string basePath = "")
    {
        return (Error)NativeCalls.godot_icall_4_638(MethodBind12, GodotObject.GetPtr(this), path, GodotObject.GetPtr(state), flags, basePath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendFromBuffer, 1616081266ul);

    /// <summary>
    /// <para>Takes a <see cref="byte"/>[] defining a glTF and imports the data to the given <see cref="Godot.GltfState"/> object through the <paramref name="state"/> parameter.</para>
    /// <para><b>Note:</b> The <paramref name="basePath"/> tells <see cref="Godot.GltfDocument.AppendFromBuffer(byte[], string, GltfState, uint)"/> where to find dependencies and can be empty.</para>
    /// </summary>
    public Error AppendFromBuffer(byte[] bytes, string basePath, GltfState state, uint flags = (uint)(0))
    {
        return (Error)NativeCalls.godot_icall_4_639(MethodBind13, GodotObject.GetPtr(this), bytes, basePath, GodotObject.GetPtr(state), flags);
    }

    /// <summary>
    /// <para>Takes a <see cref="byte"/>[] defining a glTF and imports the data to the given <see cref="Godot.GltfState"/> object through the <paramref name="state"/> parameter.</para>
    /// <para><b>Note:</b> The <paramref name="basePath"/> tells <see cref="Godot.GltfDocument.AppendFromBuffer(byte[], string, GltfState, uint)"/> where to find dependencies and can be empty.</para>
    /// </summary>
    public Error AppendFromBuffer(ReadOnlySpan<byte> bytes, string basePath, GltfState state, uint flags)
    {
        return (Error)NativeCalls.godot_icall_4_639(MethodBind13, GodotObject.GetPtr(this), bytes, basePath, GodotObject.GetPtr(state), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendFromScene, 1622574258ul);

    /// <summary>
    /// <para>Takes a Godot Engine scene node and exports it and its descendants to the given <see cref="Godot.GltfState"/> object through the <paramref name="state"/> parameter.</para>
    /// </summary>
    public Error AppendFromScene(Node node, GltfState state, uint flags = (uint)(0))
    {
        return (Error)NativeCalls.godot_icall_3_640(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(node), GodotObject.GetPtr(state), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateScene, 596118388ul);

    /// <summary>
    /// <para>Takes a <see cref="Godot.GltfState"/> object through the <paramref name="state"/> parameter and returns a Godot Engine scene node.</para>
    /// <para>The <paramref name="bakeFps"/> parameter overrides the bake_fps in <paramref name="state"/>.</para>
    /// </summary>
    public Node GenerateScene(GltfState state, float bakeFps = (float)(30), bool trimming = false, bool removeImmutableTracks = true)
    {
        return (Node)NativeCalls.godot_icall_4_641(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(state), bakeFps, trimming.ToGodotBool(), removeImmutableTracks.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateBuffer, 741783455ul);

    /// <summary>
    /// <para>Takes a <see cref="Godot.GltfState"/> object through the <paramref name="state"/> parameter and returns a glTF <see cref="byte"/>[].</para>
    /// </summary>
    public byte[] GenerateBuffer(GltfState state)
    {
        return NativeCalls.godot_icall_1_636(MethodBind16, GodotObject.GetPtr(this), GodotObject.GetPtr(state));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WriteToFilesystem, 1784551478ul);

    /// <summary>
    /// <para>Takes a <see cref="Godot.GltfState"/> object through the <paramref name="state"/> parameter and writes a glTF file to the filesystem.</para>
    /// <para><b>Note:</b> The extension of the glTF file determines if it is a .glb binary file or a .gltf text file.</para>
    /// </summary>
    public Error WriteToFilesystem(GltfState state, string path)
    {
        return (Error)NativeCalls.godot_icall_2_642(MethodBind17, GodotObject.GetPtr(this), GodotObject.GetPtr(state), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ImportObjectModelProperty, 1206708632ul);

    /// <summary>
    /// <para>Determines a mapping between the given glTF Object Model <paramref name="jsonPointer"/> and the corresponding Godot node path(s) in the generated Godot scene. The details of this mapping are returned in a <see cref="Godot.GltfObjectModelProperty"/> object. Additional mappings can be supplied via the <see cref="Godot.GltfDocumentExtension._ExportObjectModelProperty(GltfState, NodePath, Node, int, GodotObject, int)"/> callback method.</para>
    /// </summary>
    public static GltfObjectModelProperty ImportObjectModelProperty(GltfState state, string jsonPointer)
    {
        return (GltfObjectModelProperty)NativeCalls.godot_icall_2_643(MethodBind18, GodotObject.GetPtr(state), jsonPointer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExportObjectModelProperty, 314209806ul);

    /// <summary>
    /// <para>Determines a mapping between the given Godot <paramref name="nodePath"/> and the corresponding glTF Object Model JSON pointer(s) in the generated glTF file. The details of this mapping are returned in a <see cref="Godot.GltfObjectModelProperty"/> object. Additional mappings can be supplied via the <see cref="Godot.GltfDocumentExtension._ImportObjectModelProperty(GltfState, string[], Godot.Collections.Array{NodePath})"/> callback method.</para>
    /// </summary>
    public static GltfObjectModelProperty ExportObjectModelProperty(GltfState state, NodePath nodePath, Node godotNode, int gltfNodeIndex)
    {
        return (GltfObjectModelProperty)NativeCalls.godot_icall_4_644(MethodBind19, GodotObject.GetPtr(state), (godot_node_path)(nodePath?.NativeValue ?? default), GodotObject.GetPtr(godotNode), gltfNodeIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterGltfDocumentExtension, 3752678331ul);

    /// <summary>
    /// <para>Registers the given <see cref="Godot.GltfDocumentExtension"/> instance with GLTFDocument. If <paramref name="firstPriority"/> is <see langword="true"/>, this extension will be run first. Otherwise, it will be run last.</para>
    /// <para><b>Note:</b> Like GLTFDocument itself, all GLTFDocumentExtension classes must be stateless in order to function properly. If you need to store data, use the <c>set_additional_data</c> and <c>get_additional_data</c> methods in <see cref="Godot.GltfState"/> or <see cref="Godot.GltfNode"/>.</para>
    /// </summary>
    public static void RegisterGltfDocumentExtension(GltfDocumentExtension extension, bool firstPriority = false)
    {
        NativeCalls.godot_icall_2_645(MethodBind20, GodotObject.GetPtr(extension), firstPriority.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterGltfDocumentExtension, 2684415758ul);

    /// <summary>
    /// <para>Unregisters the given <see cref="Godot.GltfDocumentExtension"/> instance.</para>
    /// </summary>
    public static void UnregisterGltfDocumentExtension(GltfDocumentExtension extension)
    {
        NativeCalls.godot_icall_1_646(MethodBind21, GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedGltfExtensions, 2981934095ul);

    /// <summary>
    /// <para>Returns a list of all support glTF extensions, including extensions supported directly by the engine, and extensions supported by user plugins registering <see cref="Godot.GltfDocumentExtension"/> classes.</para>
    /// <para><b>Note:</b> If this method is run before a GLTFDocumentExtension is registered, its extensions won't be included in the list. Be sure to only run this method after all extensions are registered. If you run this when the engine starts, consider waiting a frame before calling this method to ensure all extensions are registered.</para>
    /// </summary>
    public static string[] GetSupportedGltfExtensions()
    {
        return NativeCalls.godot_icall_0_484(MethodBind22);
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
        /// Cached name for the 'image_format' property.
        /// </summary>
        public static readonly StringName ImageFormat = "image_format";
        /// <summary>
        /// Cached name for the 'lossy_quality' property.
        /// </summary>
        public static readonly StringName LossyQuality = "lossy_quality";
        /// <summary>
        /// Cached name for the 'fallback_image_format' property.
        /// </summary>
        public static readonly StringName FallbackImageFormat = "fallback_image_format";
        /// <summary>
        /// Cached name for the 'fallback_image_quality' property.
        /// </summary>
        public static readonly StringName FallbackImageQuality = "fallback_image_quality";
        /// <summary>
        /// Cached name for the 'root_node_mode' property.
        /// </summary>
        public static readonly StringName RootNodeMode = "root_node_mode";
        /// <summary>
        /// Cached name for the 'visibility_mode' property.
        /// </summary>
        public static readonly StringName VisibilityMode = "visibility_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_image_format' method.
        /// </summary>
        public static readonly StringName SetImageFormat = "set_image_format";
        /// <summary>
        /// Cached name for the 'get_image_format' method.
        /// </summary>
        public static readonly StringName GetImageFormat = "get_image_format";
        /// <summary>
        /// Cached name for the 'set_lossy_quality' method.
        /// </summary>
        public static readonly StringName SetLossyQuality = "set_lossy_quality";
        /// <summary>
        /// Cached name for the 'get_lossy_quality' method.
        /// </summary>
        public static readonly StringName GetLossyQuality = "get_lossy_quality";
        /// <summary>
        /// Cached name for the 'set_fallback_image_format' method.
        /// </summary>
        public static readonly StringName SetFallbackImageFormat = "set_fallback_image_format";
        /// <summary>
        /// Cached name for the 'get_fallback_image_format' method.
        /// </summary>
        public static readonly StringName GetFallbackImageFormat = "get_fallback_image_format";
        /// <summary>
        /// Cached name for the 'set_fallback_image_quality' method.
        /// </summary>
        public static readonly StringName SetFallbackImageQuality = "set_fallback_image_quality";
        /// <summary>
        /// Cached name for the 'get_fallback_image_quality' method.
        /// </summary>
        public static readonly StringName GetFallbackImageQuality = "get_fallback_image_quality";
        /// <summary>
        /// Cached name for the 'set_root_node_mode' method.
        /// </summary>
        public static readonly StringName SetRootNodeMode = "set_root_node_mode";
        /// <summary>
        /// Cached name for the 'get_root_node_mode' method.
        /// </summary>
        public static readonly StringName GetRootNodeMode = "get_root_node_mode";
        /// <summary>
        /// Cached name for the 'set_visibility_mode' method.
        /// </summary>
        public static readonly StringName SetVisibilityMode = "set_visibility_mode";
        /// <summary>
        /// Cached name for the 'get_visibility_mode' method.
        /// </summary>
        public static readonly StringName GetVisibilityMode = "get_visibility_mode";
        /// <summary>
        /// Cached name for the 'append_from_file' method.
        /// </summary>
        public static readonly StringName AppendFromFile = "append_from_file";
        /// <summary>
        /// Cached name for the 'append_from_buffer' method.
        /// </summary>
        public static readonly StringName AppendFromBuffer = "append_from_buffer";
        /// <summary>
        /// Cached name for the 'append_from_scene' method.
        /// </summary>
        public static readonly StringName AppendFromScene = "append_from_scene";
        /// <summary>
        /// Cached name for the 'generate_scene' method.
        /// </summary>
        public static readonly StringName GenerateScene = "generate_scene";
        /// <summary>
        /// Cached name for the 'generate_buffer' method.
        /// </summary>
        public static readonly StringName GenerateBuffer = "generate_buffer";
        /// <summary>
        /// Cached name for the 'write_to_filesystem' method.
        /// </summary>
        public static readonly StringName WriteToFilesystem = "write_to_filesystem";
        /// <summary>
        /// Cached name for the 'import_object_model_property' method.
        /// </summary>
        public static readonly StringName ImportObjectModelProperty = "import_object_model_property";
        /// <summary>
        /// Cached name for the 'export_object_model_property' method.
        /// </summary>
        public static readonly StringName ExportObjectModelProperty = "export_object_model_property";
        /// <summary>
        /// Cached name for the 'register_gltf_document_extension' method.
        /// </summary>
        public static readonly StringName RegisterGltfDocumentExtension = "register_gltf_document_extension";
        /// <summary>
        /// Cached name for the 'unregister_gltf_document_extension' method.
        /// </summary>
        public static readonly StringName UnregisterGltfDocumentExtension = "unregister_gltf_document_extension";
        /// <summary>
        /// Cached name for the 'get_supported_gltf_extensions' method.
        /// </summary>
        public static readonly StringName GetSupportedGltfExtensions = "get_supported_gltf_extensions";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
