namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Imported scenes can be automatically modified right after import by setting their <b>Custom Script</b> Import property to a <c>tool</c> script that inherits from this class.</para>
/// <para>The <see cref="Godot.EditorScenePostImport._PostImport(Node)"/> callback receives the imported scene's root node and returns the modified version of the scene:</para>
/// <para><code>
/// using Godot;
/// 
/// // This sample changes all node names.
/// // Called right after the scene is imported and gets the root node.
/// [Tool]
/// public partial class NodeRenamer : EditorScenePostImport
/// {
/// 	public override GodotObject _PostImport(Node scene)
/// 	{
/// 		// Change all node names to "modified_[oldnodename]"
/// 		Iterate(scene);
/// 		return scene; // Remember to return the imported scene
/// 	}
/// 
/// 	public void Iterate(Node node)
/// 	{
/// 		if (node != null)
/// 		{
/// 			node.Name = $"modified_{node.Name}";
/// 			foreach (Node child in node.GetChildren())
/// 			{
/// 				Iterate(child);
/// 			}
/// 		}
/// 	}
/// }
/// </code></para>
/// </summary>
public partial class EditorScenePostImport : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorScenePostImport);

    private static readonly StringName NativeName = "EditorScenePostImport";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorScenePostImport() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorScenePostImport(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorScenePostImport(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called after the scene was imported. This method must return the modified version of the scene.</para>
    /// </summary>
    public virtual GodotObject _PostImport(Node scene)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceFile, 201670096ul);

    /// <summary>
    /// <para>Returns the source file path which got imported (e.g. <c>res://scene.dae</c>).</para>
    /// </summary>
    public string GetSourceFile()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__post_import = "_PostImport";

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
        if ((method == MethodProxyName__post_import || method == MethodName._PostImport) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__post_import.NativeValue))
        {
            var callRet = _PostImport(VariantUtils.ConvertTo<Node>(args[0]));
            ret = VariantUtils.CreateFrom<GodotObject>(callRet);
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
        if (method == MethodName._PostImport)
        {
            if (HasGodotClassMethod(MethodProxyName__post_import.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_post_import' method.
        /// </summary>
        public static readonly StringName _PostImport = "_post_import";
        /// <summary>
        /// Cached name for the 'get_source_file' method.
        /// </summary>
        public static readonly StringName GetSourceFile = "get_source_file";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
