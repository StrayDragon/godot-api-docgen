namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Scripts extending this class and implementing its <see cref="Godot.EditorScript._Run()"/> method can be executed from the Script Editor's <b>File &gt; Run</b> menu option (or by pressing Ctrl + Shift + X) while the editor is running. This is useful for adding custom in-editor functionality to Godot. For more complex additions, consider using <see cref="Godot.EditorPlugin"/>s instead.</para>
/// <para>If a script extending this class also has a global class name, it will be included in the editor's command palette.</para>
/// <para><b>Note:</b> Extending scripts need to have <c>tool</c> mode enabled.</para>
/// <para><b>Example:</b> Running the following script prints "Hello from the Godot Editor!":</para>
/// <para><code>
/// using Godot;
/// 
/// [Tool]
/// public partial class HelloEditor : EditorScript
/// {
/// 	public override void _Run()
/// 	{
/// 		GD.Print("Hello from the Godot Editor!");
/// 	}
/// }
/// </code></para>
/// <para><b>Note:</b> EditorScript is <see cref="Godot.RefCounted"/>, meaning it is destroyed when nothing references it. This can cause errors during asynchronous operations if there are no references to the script.</para>
/// </summary>
public partial class EditorScript : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorScript);

    private static readonly StringName NativeName = "EditorScript";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorScript() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorScript(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorScript(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>This method is executed by the Editor when <b>File &gt; Run</b> is used.</para>
    /// </summary>
    public virtual void _Run()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddRootNode, 1078189570ul);

    /// <summary>
    /// <para>Makes <paramref name="node"/> root of the currently opened scene. Only works if the scene is empty. If the <paramref name="node"/> is a scene instance, an inheriting scene will be created.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorInterface.AddRootNode(Node)' instead.")]
    public void AddRootNode(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScene, 3160264692ul);

    /// <summary>
    /// <para>Returns the edited (current) scene's root <see cref="Godot.Node"/>. Equivalent of <see cref="Godot.EditorInterface.GetEditedSceneRoot()"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorInterface.GetEditedSceneRoot()' instead.")]
    public Node GetScene()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorInterface, 1976662476ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.EditorInterface"/> singleton instance.</para>
    /// </summary>
    [Obsolete("'EditorInterface' is a global singleton and can be accessed directly by its name.")]
    public EditorInterface GetEditorInterface()
    {
        return (EditorInterface)NativeCalls.godot_icall_0_53(MethodBind2, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__run = "_Run";

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
        if ((method == MethodProxyName__run || method == MethodName._Run) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__run.NativeValue))
        {
            _Run();
            ret = default;
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
        if (method == MethodName._Run)
        {
            if (HasGodotClassMethod(MethodProxyName__run.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_run' method.
        /// </summary>
        public static readonly StringName _Run = "_run";
        /// <summary>
        /// Cached name for the 'add_root_node' method.
        /// </summary>
        public static readonly StringName AddRootNode = "add_root_node";
        /// <summary>
        /// Cached name for the 'get_scene' method.
        /// </summary>
        public static readonly StringName GetScene = "get_scene";
        /// <summary>
        /// Cached name for the 'get_editor_interface' method.
        /// </summary>
        public static readonly StringName GetEditorInterface = "get_editor_interface";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
