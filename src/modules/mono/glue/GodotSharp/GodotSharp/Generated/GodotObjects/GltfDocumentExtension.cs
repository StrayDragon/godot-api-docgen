namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Extends the functionality of the <see cref="Godot.GltfDocument"/> class by allowing you to run arbitrary code at various stages of glTF import or export.</para>
/// <para>To use, make a new class extending GLTFDocumentExtension, override any methods you need, make an instance of your class, and register it using <see cref="Godot.GltfDocument.RegisterGltfDocumentExtension(GltfDocumentExtension, bool)"/>.</para>
/// <para><b>Note:</b> Like GLTFDocument itself, all GLTFDocumentExtension classes must be stateless in order to function properly. If you need to store data, use the <c>set_additional_data</c> and <c>get_additional_data</c> methods in <see cref="Godot.GltfState"/> or <see cref="Godot.GltfNode"/>.</para>
/// </summary>
[GodotClassName("GLTFDocumentExtension")]
public partial class GltfDocumentExtension : Resource
{
    private static readonly System.Type CachedType = typeof(GltfDocumentExtension);

    private static readonly StringName NativeName = "GLTFDocumentExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfDocumentExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfDocumentExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfDocumentExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._ExportPreflight(GltfState, Node)"/> and before <see cref="Godot.GltfDocumentExtension._ExportPostConvert(GltfState, Node)"/>.</para>
    /// <para>Runs when converting the data from a Godot scene node. This method can be used to process the Godot scene node data into a format that can be used by <see cref="Godot.GltfDocumentExtension._ExportNode(GltfState, GltfNode, Godot.Collections.Dictionary, Node)"/>.</para>
    /// </summary>
    public virtual void _ConvertSceneNode(GltfState state, GltfNode gltfNode, Node sceneNode)
    {
    }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._GetSaveableImageFormats()"/> and before <see cref="Godot.GltfDocumentExtension._ExportPost(GltfState)"/>. If this <see cref="Godot.GltfDocumentExtension"/> is used for exporting images, this runs after <see cref="Godot.GltfDocumentExtension._SerializeTextureJson(GltfState, Godot.Collections.Dictionary, GltfTexture, string)"/>.</para>
    /// <para>This method can be used to modify the final JSON of each node. Data should be primarily stored in <paramref name="gltfNode"/> prior to serializing the JSON, but the original Godot <see cref="Godot.Node"/> is also provided if available. <paramref name="node"/> may be <see langword="null"/> if not available, such as when exporting glTF data not generated from a Godot scene.</para>
    /// </summary>
    public virtual Error _ExportNode(GltfState state, GltfNode gltfNode, Godot.Collections.Dictionary json, Node node)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. Allows GLTFDocumentExtension classes to provide mappings for properties of nodes in the Godot scene tree, to JSON pointers to glTF properties, as defined by the glTF object model.</para>
    /// <para>Returns a <see cref="Godot.GltfObjectModelProperty"/> instance that defines how the property should be mapped. If your extension can't handle the property, return <see langword="null"/> or an instance without any JSON pointers (see <see cref="Godot.GltfObjectModelProperty.HasJsonPointers()"/>). You should use <see cref="Godot.GltfObjectModelProperty.SetTypes(Variant.Type, GltfObjectModelProperty.GltfObjectModelType)"/> to set the types, and set the JSON pointer(s) using the <see cref="Godot.GltfObjectModelProperty.JsonPointers"/> property.</para>
    /// <para>The parameters provide context for the property, including the NodePath, the Godot node, the GLTF node index, and the target object. The <paramref name="targetObject"/> will be equal to <paramref name="godotNode"/> if no sub-object can be found, otherwise it will point to a sub-object. For example, if the path is <c>^"A/B/C/MeshInstance3D:mesh:surface_0/material:emission_intensity"</c>, it will get the node, then the mesh, and then the material, so <paramref name="targetObject"/> will be the <see cref="Godot.Material"/> resource, and <paramref name="targetDepth"/> will be 2 because 2 levels were traversed to get to the target.</para>
    /// </summary>
    public virtual GltfObjectModelProperty _ExportObjectModelProperty(GltfState state, NodePath nodePath, Node godotNode, int gltfNodeIndex, GodotObject targetObject, int targetDepth)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run last, after all other parts of the export process.</para>
    /// <para>This method can be used to modify the final JSON of the generated glTF file.</para>
    /// </summary>
    public virtual Error _ExportPost(GltfState state)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._ConvertSceneNode(GltfState, GltfNode, Node)"/> and before <see cref="Godot.GltfDocumentExtension._ExportPreserialize(GltfState)"/>.</para>
    /// <para>This method can be used to modify the converted node data structures before serialization with any additional data from the scene tree.</para>
    /// </summary>
    public virtual Error _ExportPostConvert(GltfState state, Node root)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run first, before all other parts of the export process.</para>
    /// <para>The return value is used to determine if this <see cref="Godot.GltfDocumentExtension"/> instance should be used for exporting a given glTF file. If <see cref="Godot.Error.Ok"/>, the export will use this <see cref="Godot.GltfDocumentExtension"/> instance. If not overridden, <see cref="Godot.Error.Ok"/> is returned.</para>
    /// </summary>
    public virtual Error _ExportPreflight(GltfState state, Node root)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._ExportPostConvert(GltfState, Node)"/> and before <see cref="Godot.GltfDocumentExtension._GetSaveableImageFormats()"/>.</para>
    /// <para>This method can be used to alter the state before performing serialization. It runs every time when generating a buffer with <see cref="Godot.GltfDocument.GenerateBuffer(GltfState)"/> or writing to the file system with <see cref="Godot.GltfDocument.WriteToFilesystem(GltfState, string)"/>.</para>
    /// </summary>
    public virtual Error _ExportPreserialize(GltfState state)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._ImportPreGenerate(GltfState)"/> and before <see cref="Godot.GltfDocumentExtension._ImportNode(GltfState, GltfNode, Godot.Collections.Dictionary, Node)"/>.</para>
    /// <para>Runs when generating a Godot scene node from a GLTFNode. The returned node will be added to the scene tree. Multiple nodes can be generated in this step if they are added as a child of the returned node.</para>
    /// <para><b>Note:</b> The <paramref name="sceneParent"/> parameter may be <see langword="null"/> if this is the single root node.</para>
    /// </summary>
    public virtual Node3D _GenerateSceneNode(GltfState state, GltfNode gltfNode, Node sceneParent)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the file extension to use for saving image data into, for example, <c>".png"</c>. If defined, when this extension is used to handle images, and the images are saved to a separate file, the image bytes will be copied to a file with this extension. If this is set, there should be a <see cref="Godot.ResourceImporter"/> class able to import the file. If not defined or empty, Godot will save the image into a PNG file.</para>
    /// </summary>
    public virtual string _GetImageFileExtension()
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._ConvertSceneNode(GltfState, GltfNode, Node)"/> and before <see cref="Godot.GltfDocumentExtension._ExportNode(GltfState, GltfNode, Godot.Collections.Dictionary, Node)"/>.</para>
    /// <para>Returns an array of the image formats that can be saved/exported by this extension. This extension will only be selected as the image exporter if the <see cref="Godot.GltfDocument"/>'s <see cref="Godot.GltfDocument.ImageFormat"/> is in this array. If this <see cref="Godot.GltfDocumentExtension"/> is selected as the image exporter, one of the <see cref="Godot.GltfDocumentExtension._SaveImageAtPath(GltfState, Image, string, string, float)"/> or <see cref="Godot.GltfDocumentExtension._SerializeImageToBytes(GltfState, Image, Godot.Collections.Dictionary, string, float)"/> methods will run next, otherwise <see cref="Godot.GltfDocumentExtension._ExportNode(GltfState, GltfNode, Godot.Collections.Dictionary, Node)"/> will run next. If the format name contains <c>"Lossy"</c>, the lossy quality slider will be displayed.</para>
    /// </summary>
    public virtual string[] _GetSaveableImageFormats()
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._ImportPreflight(GltfState, string[])"/> and before <see cref="Godot.GltfDocumentExtension._ParseNodeExtensions(GltfState, GltfNode, Godot.Collections.Dictionary)"/>.</para>
    /// <para>Returns an array of the glTF extensions supported by this GLTFDocumentExtension class. This is used to validate if a glTF file with required extensions can be loaded.</para>
    /// </summary>
    public virtual string[] _GetSupportedExtensions()
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._GenerateSceneNode(GltfState, GltfNode, Node)"/> and before <see cref="Godot.GltfDocumentExtension._ImportPost(GltfState, Node)"/>.</para>
    /// <para>This method can be used to make modifications to each of the generated Godot scene nodes.</para>
    /// </summary>
    public virtual Error _ImportNode(GltfState state, GltfNode gltfNode, Godot.Collections.Dictionary json, Node node)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. Allows GLTFDocumentExtension classes to provide mappings for JSON pointers to glTF properties, as defined by the glTF object model, to properties of nodes in the Godot scene tree.</para>
    /// <para>Returns a <see cref="Godot.GltfObjectModelProperty"/> instance that defines how the property should be mapped. If your extension can't handle the property, return <see langword="null"/> or an instance without any NodePaths (see <see cref="Godot.GltfObjectModelProperty.HasNodePaths()"/>). You should use <see cref="Godot.GltfObjectModelProperty.SetTypes(Variant.Type, GltfObjectModelProperty.GltfObjectModelType)"/> to set the types, and <see cref="Godot.GltfObjectModelProperty.AppendPathToProperty(NodePath, StringName)"/> function is useful for most simple cases.</para>
    /// <para>In many cases, <paramref name="partialPaths"/> will contain the start of a path, allowing the extension to complete the path. For example, for <c>/nodes/3/extensions/MY_ext/prop</c>, Godot will pass you a NodePath that leads to node 3, so the GLTFDocumentExtension class only needs to resolve the last <c>MY_ext/prop</c> part of the path. In this example, the extension should check <c>split.size() &gt; 4 and split[0] == "nodes" and split[2] == "extensions" and split[3] == "MY_ext"</c> at the start of the function to check if this JSON pointer applies to it, then it can use <paramref name="partialPaths"/> and handle <c>split[4]</c>.</para>
    /// </summary>
    public virtual GltfObjectModelProperty _ImportObjectModelProperty(GltfState state, string[] splitJsonPointer, Godot.Collections.Array<NodePath> partialPaths)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run last, after all other parts of the import process.</para>
    /// <para>This method can be used to modify the final Godot scene generated by the import process.</para>
    /// </summary>
    public virtual Error _ImportPost(GltfState state, Node root)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._ParseNodeExtensions(GltfState, GltfNode, Godot.Collections.Dictionary)"/> and before <see cref="Godot.GltfDocumentExtension._ImportPreGenerate(GltfState)"/>.</para>
    /// <para>This method can be used to modify any of the data imported so far after parsing each node, but before generating the scene or any of its nodes.</para>
    /// </summary>
    public virtual Error _ImportPostParse(GltfState state)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._ImportPostParse(GltfState)"/> and before <see cref="Godot.GltfDocumentExtension._GenerateSceneNode(GltfState, GltfNode, Node)"/>.</para>
    /// <para>This method can be used to modify or read from any of the processed data structures, before generating the nodes and then running the final per-node import step.</para>
    /// </summary>
    public virtual Error _ImportPreGenerate(GltfState state)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run first, before all other parts of the import process.</para>
    /// <para>The return value is used to determine if this <see cref="Godot.GltfDocumentExtension"/> instance should be used for importing a given glTF file. If <see cref="Godot.Error.Ok"/>, the import will use this <see cref="Godot.GltfDocumentExtension"/> instance. If not overridden, <see cref="Godot.Error.Ok"/> is returned.</para>
    /// </summary>
    public virtual Error _ImportPreflight(GltfState state, string[] extensions)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._ParseNodeExtensions(GltfState, GltfNode, Godot.Collections.Dictionary)"/> and before <see cref="Godot.GltfDocumentExtension._ParseTextureJson(GltfState, Godot.Collections.Dictionary, GltfTexture)"/>.</para>
    /// <para>Runs when parsing image data from a glTF file. The data could be sourced from a separate file, a URI, or a buffer, and then is passed as a byte array.</para>
    /// </summary>
    public virtual Error _ParseImageData(GltfState state, byte[] imageData, string mimeType, Image retImage)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._GetSupportedExtensions()"/> and before <see cref="Godot.GltfDocumentExtension._ImportPostParse(GltfState)"/>.</para>
    /// <para>Runs when parsing the node extensions of a GLTFNode. This method can be used to process the extension JSON data into a format that can be used by <see cref="Godot.GltfDocumentExtension._GenerateSceneNode(GltfState, GltfNode, Node)"/>. The return value should be a member of the <see cref="Godot.Error"/> enum.</para>
    /// </summary>
    public virtual Error _ParseNodeExtensions(GltfState state, GltfNode gltfNode, Godot.Collections.Dictionary extensions)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the import process. This method is run after <see cref="Godot.GltfDocumentExtension._ParseImageData(GltfState, byte[], string, Image)"/> and before <see cref="Godot.GltfDocumentExtension._GenerateSceneNode(GltfState, GltfNode, Node)"/>.</para>
    /// <para>Runs when parsing the texture JSON from the glTF textures array. This can be used to set the source image index to use as the texture.</para>
    /// </summary>
    public virtual Error _ParseTextureJson(GltfState state, Godot.Collections.Dictionary textureJson, GltfTexture retGltfTexture)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._GetSaveableImageFormats()"/> and before <see cref="Godot.GltfDocumentExtension._SerializeTextureJson(GltfState, Godot.Collections.Dictionary, GltfTexture, string)"/>.</para>
    /// <para>This method is run when saving images separately from the glTF file. When images are embedded, <see cref="Godot.GltfDocumentExtension._SerializeImageToBytes(GltfState, Image, Godot.Collections.Dictionary, string, float)"/> runs instead. Note that these methods only run when this <see cref="Godot.GltfDocumentExtension"/> is selected as the image exporter.</para>
    /// </summary>
    public virtual Error _SaveImageAtPath(GltfState state, Image image, string filePath, string imageFormat, float lossyQuality)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._GetSaveableImageFormats()"/> and before <see cref="Godot.GltfDocumentExtension._SerializeTextureJson(GltfState, Godot.Collections.Dictionary, GltfTexture, string)"/>.</para>
    /// <para>This method is run when embedding images in the glTF file. When images are saved separately, <see cref="Godot.GltfDocumentExtension._SaveImageAtPath(GltfState, Image, string, string, float)"/> runs instead. Note that these methods only run when this <see cref="Godot.GltfDocumentExtension"/> is selected as the image exporter.</para>
    /// <para>This method must set the image MIME type in the <paramref name="imageDict"/> with the <c>"mimeType"</c> key. For example, for a PNG image, it would be set to <c>"image/png"</c>. The return value must be a <see cref="byte"/>[] containing the image data.</para>
    /// </summary>
    public virtual byte[] _SerializeImageToBytes(GltfState state, Image image, Godot.Collections.Dictionary imageDict, string imageFormat, float lossyQuality)
    {
        return default;
    }

    /// <summary>
    /// <para>Part of the export process. This method is run after <see cref="Godot.GltfDocumentExtension._SaveImageAtPath(GltfState, Image, string, string, float)"/> or <see cref="Godot.GltfDocumentExtension._SerializeImageToBytes(GltfState, Image, Godot.Collections.Dictionary, string, float)"/>, and before <see cref="Godot.GltfDocumentExtension._ExportNode(GltfState, GltfNode, Godot.Collections.Dictionary, Node)"/>. Note that this method only runs when this <see cref="Godot.GltfDocumentExtension"/> is selected as the image exporter.</para>
    /// <para>This method can be used to set up the extensions for the texture JSON by editing <paramref name="textureJson"/>. The extension must also be added as used extension with <see cref="Godot.GltfState.AddUsedExtension(string, bool)"/>, be sure to set <c>required</c> to <see langword="true"/> if you are not providing a fallback.</para>
    /// </summary>
    public virtual Error _SerializeTextureJson(GltfState state, Godot.Collections.Dictionary textureJson, GltfTexture gltfTexture, string imageFormat)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__convert_scene_node = "_ConvertSceneNode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_node = "_ExportNode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_object_model_property = "_ExportObjectModelProperty";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_post = "_ExportPost";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_post_convert = "_ExportPostConvert";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_preflight = "_ExportPreflight";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_preserialize = "_ExportPreserialize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__generate_scene_node = "_GenerateSceneNode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_image_file_extension = "_GetImageFileExtension";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_saveable_image_formats = "_GetSaveableImageFormats";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_supported_extensions = "_GetSupportedExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__import_node = "_ImportNode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__import_object_model_property = "_ImportObjectModelProperty";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__import_post = "_ImportPost";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__import_post_parse = "_ImportPostParse";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__import_pre_generate = "_ImportPreGenerate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__import_preflight = "_ImportPreflight";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_image_data = "_ParseImageData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_node_extensions = "_ParseNodeExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_texture_json = "_ParseTextureJson";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__save_image_at_path = "_SaveImageAtPath";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__serialize_image_to_bytes = "_SerializeImageToBytes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__serialize_texture_json = "_SerializeTextureJson";

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
        if ((method == MethodProxyName__convert_scene_node || method == MethodName._ConvertSceneNode) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__convert_scene_node.NativeValue))
        {
            _ConvertSceneNode(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<GltfNode>(args[1]), VariantUtils.ConvertTo<Node>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__export_node || method == MethodName._ExportNode) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_node.NativeValue))
        {
            var callRet = _ExportNode(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<GltfNode>(args[1]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[2]), VariantUtils.ConvertTo<Node>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_object_model_property || method == MethodName._ExportObjectModelProperty) && args.Count == 6 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_object_model_property.NativeValue))
        {
            var callRet = _ExportObjectModelProperty(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<NodePath>(args[1]), VariantUtils.ConvertTo<Node>(args[2]), VariantUtils.ConvertTo<int>(args[3]), VariantUtils.ConvertTo<GodotObject>(args[4]), VariantUtils.ConvertTo<int>(args[5]));
            ret = VariantUtils.CreateFrom<GltfObjectModelProperty>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_post || method == MethodName._ExportPost) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_post.NativeValue))
        {
            var callRet = _ExportPost(VariantUtils.ConvertTo<GltfState>(args[0]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_post_convert || method == MethodName._ExportPostConvert) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_post_convert.NativeValue))
        {
            var callRet = _ExportPostConvert(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<Node>(args[1]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_preflight || method == MethodName._ExportPreflight) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_preflight.NativeValue))
        {
            var callRet = _ExportPreflight(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<Node>(args[1]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_preserialize || method == MethodName._ExportPreserialize) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_preserialize.NativeValue))
        {
            var callRet = _ExportPreserialize(VariantUtils.ConvertTo<GltfState>(args[0]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__generate_scene_node || method == MethodName._GenerateSceneNode) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__generate_scene_node.NativeValue))
        {
            var callRet = _GenerateSceneNode(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<GltfNode>(args[1]), VariantUtils.ConvertTo<Node>(args[2]));
            ret = VariantUtils.CreateFrom<Node3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_image_file_extension || method == MethodName._GetImageFileExtension) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_image_file_extension.NativeValue))
        {
            var callRet = _GetImageFileExtension();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_saveable_image_formats || method == MethodName._GetSaveableImageFormats) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_saveable_image_formats.NativeValue))
        {
            var callRet = _GetSaveableImageFormats();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_supported_extensions || method == MethodName._GetSupportedExtensions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_supported_extensions.NativeValue))
        {
            var callRet = _GetSupportedExtensions();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__import_node || method == MethodName._ImportNode) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__import_node.NativeValue))
        {
            var callRet = _ImportNode(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<GltfNode>(args[1]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[2]), VariantUtils.ConvertTo<Node>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__import_object_model_property || method == MethodName._ImportObjectModelProperty) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__import_object_model_property.NativeValue))
        {
            var callRet = _ImportObjectModelProperty(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<string[]>(args[1]), new Godot.Collections.Array<NodePath>(VariantUtils.ConvertToArray(args[2])));
            ret = VariantUtils.CreateFrom<GltfObjectModelProperty>(callRet);
            return true;
        }
        if ((method == MethodProxyName__import_post || method == MethodName._ImportPost) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__import_post.NativeValue))
        {
            var callRet = _ImportPost(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<Node>(args[1]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__import_post_parse || method == MethodName._ImportPostParse) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__import_post_parse.NativeValue))
        {
            var callRet = _ImportPostParse(VariantUtils.ConvertTo<GltfState>(args[0]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__import_pre_generate || method == MethodName._ImportPreGenerate) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__import_pre_generate.NativeValue))
        {
            var callRet = _ImportPreGenerate(VariantUtils.ConvertTo<GltfState>(args[0]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__import_preflight || method == MethodName._ImportPreflight) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__import_preflight.NativeValue))
        {
            var callRet = _ImportPreflight(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<string[]>(args[1]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__parse_image_data || method == MethodName._ParseImageData) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_image_data.NativeValue))
        {
            var callRet = _ParseImageData(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<byte[]>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<Image>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__parse_node_extensions || method == MethodName._ParseNodeExtensions) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_node_extensions.NativeValue))
        {
            var callRet = _ParseNodeExtensions(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<GltfNode>(args[1]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[2]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__parse_texture_json || method == MethodName._ParseTextureJson) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_texture_json.NativeValue))
        {
            var callRet = _ParseTextureJson(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[1]), VariantUtils.ConvertTo<GltfTexture>(args[2]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__save_image_at_path || method == MethodName._SaveImageAtPath) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__save_image_at_path.NativeValue))
        {
            var callRet = _SaveImageAtPath(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<Image>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<string>(args[3]), VariantUtils.ConvertTo<float>(args[4]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__serialize_image_to_bytes || method == MethodName._SerializeImageToBytes) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__serialize_image_to_bytes.NativeValue))
        {
            var callRet = _SerializeImageToBytes(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<Image>(args[1]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[2]), VariantUtils.ConvertTo<string>(args[3]), VariantUtils.ConvertTo<float>(args[4]));
            ret = VariantUtils.CreateFrom<byte[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__serialize_texture_json || method == MethodName._SerializeTextureJson) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__serialize_texture_json.NativeValue))
        {
            var callRet = _SerializeTextureJson(VariantUtils.ConvertTo<GltfState>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[1]), VariantUtils.ConvertTo<GltfTexture>(args[2]), VariantUtils.ConvertTo<string>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
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
        if (method == MethodName._ConvertSceneNode)
        {
            if (HasGodotClassMethod(MethodProxyName__convert_scene_node.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportNode)
        {
            if (HasGodotClassMethod(MethodProxyName__export_node.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportObjectModelProperty)
        {
            if (HasGodotClassMethod(MethodProxyName__export_object_model_property.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportPost)
        {
            if (HasGodotClassMethod(MethodProxyName__export_post.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportPostConvert)
        {
            if (HasGodotClassMethod(MethodProxyName__export_post_convert.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportPreflight)
        {
            if (HasGodotClassMethod(MethodProxyName__export_preflight.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportPreserialize)
        {
            if (HasGodotClassMethod(MethodProxyName__export_preserialize.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GenerateSceneNode)
        {
            if (HasGodotClassMethod(MethodProxyName__generate_scene_node.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetImageFileExtension)
        {
            if (HasGodotClassMethod(MethodProxyName__get_image_file_extension.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSaveableImageFormats)
        {
            if (HasGodotClassMethod(MethodProxyName__get_saveable_image_formats.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSupportedExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_supported_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ImportNode)
        {
            if (HasGodotClassMethod(MethodProxyName__import_node.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ImportObjectModelProperty)
        {
            if (HasGodotClassMethod(MethodProxyName__import_object_model_property.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ImportPost)
        {
            if (HasGodotClassMethod(MethodProxyName__import_post.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ImportPostParse)
        {
            if (HasGodotClassMethod(MethodProxyName__import_post_parse.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ImportPreGenerate)
        {
            if (HasGodotClassMethod(MethodProxyName__import_pre_generate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ImportPreflight)
        {
            if (HasGodotClassMethod(MethodProxyName__import_preflight.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseImageData)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_image_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseNodeExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_node_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseTextureJson)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_texture_json.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SaveImageAtPath)
        {
            if (HasGodotClassMethod(MethodProxyName__save_image_at_path.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SerializeImageToBytes)
        {
            if (HasGodotClassMethod(MethodProxyName__serialize_image_to_bytes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SerializeTextureJson)
        {
            if (HasGodotClassMethod(MethodProxyName__serialize_texture_json.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the '_convert_scene_node' method.
        /// </summary>
        public static readonly StringName _ConvertSceneNode = "_convert_scene_node";
        /// <summary>
        /// Cached name for the '_export_node' method.
        /// </summary>
        public static readonly StringName _ExportNode = "_export_node";
        /// <summary>
        /// Cached name for the '_export_object_model_property' method.
        /// </summary>
        public static readonly StringName _ExportObjectModelProperty = "_export_object_model_property";
        /// <summary>
        /// Cached name for the '_export_post' method.
        /// </summary>
        public static readonly StringName _ExportPost = "_export_post";
        /// <summary>
        /// Cached name for the '_export_post_convert' method.
        /// </summary>
        public static readonly StringName _ExportPostConvert = "_export_post_convert";
        /// <summary>
        /// Cached name for the '_export_preflight' method.
        /// </summary>
        public static readonly StringName _ExportPreflight = "_export_preflight";
        /// <summary>
        /// Cached name for the '_export_preserialize' method.
        /// </summary>
        public static readonly StringName _ExportPreserialize = "_export_preserialize";
        /// <summary>
        /// Cached name for the '_generate_scene_node' method.
        /// </summary>
        public static readonly StringName _GenerateSceneNode = "_generate_scene_node";
        /// <summary>
        /// Cached name for the '_get_image_file_extension' method.
        /// </summary>
        public static readonly StringName _GetImageFileExtension = "_get_image_file_extension";
        /// <summary>
        /// Cached name for the '_get_saveable_image_formats' method.
        /// </summary>
        public static readonly StringName _GetSaveableImageFormats = "_get_saveable_image_formats";
        /// <summary>
        /// Cached name for the '_get_supported_extensions' method.
        /// </summary>
        public static readonly StringName _GetSupportedExtensions = "_get_supported_extensions";
        /// <summary>
        /// Cached name for the '_import_node' method.
        /// </summary>
        public static readonly StringName _ImportNode = "_import_node";
        /// <summary>
        /// Cached name for the '_import_object_model_property' method.
        /// </summary>
        public static readonly StringName _ImportObjectModelProperty = "_import_object_model_property";
        /// <summary>
        /// Cached name for the '_import_post' method.
        /// </summary>
        public static readonly StringName _ImportPost = "_import_post";
        /// <summary>
        /// Cached name for the '_import_post_parse' method.
        /// </summary>
        public static readonly StringName _ImportPostParse = "_import_post_parse";
        /// <summary>
        /// Cached name for the '_import_pre_generate' method.
        /// </summary>
        public static readonly StringName _ImportPreGenerate = "_import_pre_generate";
        /// <summary>
        /// Cached name for the '_import_preflight' method.
        /// </summary>
        public static readonly StringName _ImportPreflight = "_import_preflight";
        /// <summary>
        /// Cached name for the '_parse_image_data' method.
        /// </summary>
        public static readonly StringName _ParseImageData = "_parse_image_data";
        /// <summary>
        /// Cached name for the '_parse_node_extensions' method.
        /// </summary>
        public static readonly StringName _ParseNodeExtensions = "_parse_node_extensions";
        /// <summary>
        /// Cached name for the '_parse_texture_json' method.
        /// </summary>
        public static readonly StringName _ParseTextureJson = "_parse_texture_json";
        /// <summary>
        /// Cached name for the '_save_image_at_path' method.
        /// </summary>
        public static readonly StringName _SaveImageAtPath = "_save_image_at_path";
        /// <summary>
        /// Cached name for the '_serialize_image_to_bytes' method.
        /// </summary>
        public static readonly StringName _SerializeImageToBytes = "_serialize_image_to_bytes";
        /// <summary>
        /// Cached name for the '_serialize_texture_json' method.
        /// </summary>
        public static readonly StringName _SerializeTextureJson = "_serialize_texture_json";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
