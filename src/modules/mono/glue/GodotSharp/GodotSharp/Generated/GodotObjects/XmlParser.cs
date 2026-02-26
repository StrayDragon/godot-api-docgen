namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides a low-level interface for creating parsers for <a href="https://en.wikipedia.org/wiki/XML">XML</a> files. This class can serve as base to make custom XML parsers.</para>
/// <para>To parse XML, you must open a file with the <see cref="Godot.XmlParser.Open(string)"/> method or a buffer with the <see cref="Godot.XmlParser.OpenBuffer(byte[])"/> method. Then, the <see cref="Godot.XmlParser.Read()"/> method must be called to parse the next nodes. Most of the methods take into consideration the currently parsed node.</para>
/// <para>Here is an example of using <see cref="Godot.XmlParser"/> to parse an SVG file (which is based on XML), printing each element and its attributes as a dictionary:</para>
/// <para><code>
/// var parser = new XmlParser();
/// parser.Open("path/to/file.svg");
/// while (parser.Read() != Error.FileEof)
/// {
/// 	if (parser.GetNodeType() == XmlParser.NodeType.Element)
/// 	{
/// 		var nodeName = parser.GetNodeName();
/// 		var attributesDict = new Godot.Collections.Dictionary();
/// 		for (int idx = 0; idx &lt; parser.GetAttributeCount(); idx++)
/// 		{
/// 			attributesDict[parser.GetAttributeName(idx)] = parser.GetAttributeValue(idx);
/// 		}
/// 		GD.Print($"The {nodeName} element has the following attributes: {attributesDict}");
/// 	}
/// }
/// </code></para>
/// </summary>
[GodotClassName("XMLParser")]
public partial class XmlParser : RefCounted
{
    public enum NodeType : long
    {
        /// <summary>
        /// <para>There's no node (no file or buffer opened).</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>An element node type, also known as a tag, e.g. <c>&lt;title&gt;</c>.</para>
        /// </summary>
        Element = 1,
        /// <summary>
        /// <para>An end of element node type, e.g. <c>&lt;/title&gt;</c>.</para>
        /// </summary>
        ElementEnd = 2,
        /// <summary>
        /// <para>A text node type, i.e. text that is not inside an element. This includes whitespace.</para>
        /// </summary>
        Text = 3,
        /// <summary>
        /// <para>A comment node type, e.g. <c>&lt;!--A comment--&gt;</c>.</para>
        /// </summary>
        Comment = 4,
        /// <summary>
        /// <para>A node type for CDATA (Character Data) sections, e.g. <c>&lt;![CDATA[CDATA section]]&gt;</c>.</para>
        /// </summary>
        Cdata = 5,
        /// <summary>
        /// <para>An unknown node type.</para>
        /// </summary>
        Unknown = 6
    }

    private static readonly System.Type CachedType = typeof(XmlParser);

    private static readonly StringName NativeName = "XMLParser";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XmlParser() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal XmlParser(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XmlParser(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Read, 166280745ul);

    /// <summary>
    /// <para>Parses the next node in the file. This method returns an error code.</para>
    /// </summary>
    public Error Read()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeType, 2984359541ul);

    /// <summary>
    /// <para>Returns the type of the current node. Compare with <see cref="Godot.XmlParser.NodeType"/> constants.</para>
    /// </summary>
    public XmlParser.NodeType GetNodeType()
    {
        return (XmlParser.NodeType)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of a node. This method will raise an error if the currently parsed node is a text node.</para>
    /// <para><b>Note:</b> The content of a <see cref="Godot.XmlParser.NodeType.Cdata"/> node and the comment string of a <see cref="Godot.XmlParser.NodeType.Comment"/> node are also considered names.</para>
    /// </summary>
    public string GetNodeName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeData, 201670096ul);

    /// <summary>
    /// <para>Returns the contents of a text node. This method will raise an error if the current parsed node is of any other type.</para>
    /// </summary>
    public string GetNodeData()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeOffset, 3905245786ul);

    /// <summary>
    /// <para>Returns the byte offset of the currently parsed node since the beginning of the file or buffer. This is usually equivalent to the number of characters before the read position.</para>
    /// </summary>
    public ulong GetNodeOffset()
    {
        return NativeCalls.godot_icall_0_137(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttributeCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of attributes in the currently parsed element.</para>
    /// <para><b>Note:</b> If this method is used while the currently parsed node is not <see cref="Godot.XmlParser.NodeType.Element"/> or <see cref="Godot.XmlParser.NodeType.ElementEnd"/>, this count will not be updated and will still reflect the last element.</para>
    /// </summary>
    public int GetAttributeCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttributeName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of an attribute of the currently parsed element, specified by the <paramref name="idx"/> index.</para>
    /// </summary>
    public string GetAttributeName(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind6, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttributeValue, 844755477ul);

    /// <summary>
    /// <para>Returns the value of an attribute of the currently parsed element, specified by the <paramref name="idx"/> index.</para>
    /// </summary>
    public string GetAttributeValue(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind7, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAttribute, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the currently parsed element has an attribute with the <paramref name="name"/>.</para>
    /// </summary>
    public bool HasAttribute(string name)
    {
        return NativeCalls.godot_icall_1_131(MethodBind8, GodotObject.GetPtr(this), name).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNamedAttributeValue, 3135753539ul);

    /// <summary>
    /// <para>Returns the value of an attribute of the currently parsed element, specified by its <paramref name="name"/>. This method will raise an error if the element has no such attribute.</para>
    /// </summary>
    public string GetNamedAttributeValue(string name)
    {
        return NativeCalls.godot_icall_1_304(MethodBind9, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNamedAttributeValueSafe, 3135753539ul);

    /// <summary>
    /// <para>Returns the value of an attribute of the currently parsed element, specified by its <paramref name="name"/>. This method will return an empty string if the element has no such attribute.</para>
    /// </summary>
    public string GetNamedAttributeValueSafe(string name)
    {
        return NativeCalls.godot_icall_1_304(MethodBind10, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmpty, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the currently parsed element is empty, e.g. <c>&lt;element /&gt;</c>.</para>
    /// </summary>
    public bool IsEmpty()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentLine, 3905245786ul);

    /// <summary>
    /// <para>Returns the current line in the parsed file, counting from 0.</para>
    /// </summary>
    public int GetCurrentLine()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkipSection, 3218959716ul);

    /// <summary>
    /// <para>Skips the current section. If the currently parsed node contains more inner nodes, they will be ignored and the cursor will go to the closing of the current element.</para>
    /// </summary>
    public void SkipSection()
    {
        NativeCalls.godot_icall_0_3(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Seek, 844576869ul);

    /// <summary>
    /// <para>Moves the buffer cursor to a certain offset (since the beginning) and reads the next node there. This method returns an error code.</para>
    /// </summary>
    public Error Seek(ulong position)
    {
        return (Error)NativeCalls.godot_icall_1_1509(MethodBind14, GodotObject.GetPtr(this), position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Open, 166001499ul);

    /// <summary>
    /// <para>Opens an XML <paramref name="file"/> for parsing. This method returns an error code.</para>
    /// </summary>
    public Error Open(string file)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind15, GodotObject.GetPtr(this), file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenBuffer, 680677267ul);

    /// <summary>
    /// <para>Opens an XML raw <paramref name="buffer"/> for parsing. This method returns an error code.</para>
    /// </summary>
    public Error OpenBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind16, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Opens an XML raw <paramref name="buffer"/> for parsing. This method returns an error code.</para>
    /// </summary>
    public Error OpenBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind16, GodotObject.GetPtr(this), buffer);
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'read' method.
        /// </summary>
        public static readonly StringName Read = "read";
        /// <summary>
        /// Cached name for the 'get_node_type' method.
        /// </summary>
        public static readonly StringName GetNodeType = "get_node_type";
        /// <summary>
        /// Cached name for the 'get_node_name' method.
        /// </summary>
        public static readonly StringName GetNodeName = "get_node_name";
        /// <summary>
        /// Cached name for the 'get_node_data' method.
        /// </summary>
        public static readonly StringName GetNodeData = "get_node_data";
        /// <summary>
        /// Cached name for the 'get_node_offset' method.
        /// </summary>
        public static readonly StringName GetNodeOffset = "get_node_offset";
        /// <summary>
        /// Cached name for the 'get_attribute_count' method.
        /// </summary>
        public static readonly StringName GetAttributeCount = "get_attribute_count";
        /// <summary>
        /// Cached name for the 'get_attribute_name' method.
        /// </summary>
        public static readonly StringName GetAttributeName = "get_attribute_name";
        /// <summary>
        /// Cached name for the 'get_attribute_value' method.
        /// </summary>
        public static readonly StringName GetAttributeValue = "get_attribute_value";
        /// <summary>
        /// Cached name for the 'has_attribute' method.
        /// </summary>
        public static readonly StringName HasAttribute = "has_attribute";
        /// <summary>
        /// Cached name for the 'get_named_attribute_value' method.
        /// </summary>
        public static readonly StringName GetNamedAttributeValue = "get_named_attribute_value";
        /// <summary>
        /// Cached name for the 'get_named_attribute_value_safe' method.
        /// </summary>
        public static readonly StringName GetNamedAttributeValueSafe = "get_named_attribute_value_safe";
        /// <summary>
        /// Cached name for the 'is_empty' method.
        /// </summary>
        public static readonly StringName IsEmpty = "is_empty";
        /// <summary>
        /// Cached name for the 'get_current_line' method.
        /// </summary>
        public static readonly StringName GetCurrentLine = "get_current_line";
        /// <summary>
        /// Cached name for the 'skip_section' method.
        /// </summary>
        public static readonly StringName SkipSection = "skip_section";
        /// <summary>
        /// Cached name for the 'seek' method.
        /// </summary>
        public static readonly StringName Seek = "seek";
        /// <summary>
        /// Cached name for the 'open' method.
        /// </summary>
        public static readonly StringName Open = "open";
        /// <summary>
        /// Cached name for the 'open_buffer' method.
        /// </summary>
        public static readonly StringName OpenBuffer = "open_buffer";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
