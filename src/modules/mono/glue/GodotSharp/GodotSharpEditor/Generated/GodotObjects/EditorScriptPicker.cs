namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Similar to <see cref="Godot.EditorResourcePicker"/> this <see cref="Godot.Control"/> node is used in the editor's Inspector dock, but only to edit the <c>script</c> property of a <see cref="Godot.Node"/>. Default options for creating new resources of all possible subtypes are replaced with dedicated buttons that open the "Attach Node Script" dialog. Can be used with <see cref="Godot.EditorInspectorPlugin"/> to recreate the same behavior.</para>
/// <para><b>Note:</b> You must set the <see cref="Godot.EditorScriptPicker.ScriptOwner"/> for the custom context menu items to work.</para>
/// </summary>
public partial class EditorScriptPicker : EditorResourcePicker
{
    /// <summary>
    /// <para>The owner <see cref="Godot.Node"/> of the script property that holds the edited resource.</para>
    /// </summary>
    public Node ScriptOwner
    {
        get
        {
            return GetScriptOwner();
        }
        set
        {
            SetScriptOwner(value);
        }
    }

    private static readonly System.Type CachedType = typeof(EditorScriptPicker);

    private static readonly StringName NativeName = "EditorScriptPicker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorScriptPicker() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorScriptPicker(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorScriptPicker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScriptOwner, 1078189570ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScriptOwner(Node ownerNode)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(ownerNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptOwner, 3160264692ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node GetScriptOwner()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : EditorResourcePicker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'script_owner' property.
        /// </summary>
        public static readonly StringName ScriptOwner = "script_owner";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : EditorResourcePicker.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_script_owner' method.
        /// </summary>
        public static readonly StringName SetScriptOwner = "set_script_owner";
        /// <summary>
        /// Cached name for the 'get_script_owner' method.
        /// </summary>
        public static readonly StringName GetScriptOwner = "get_script_owner";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : EditorResourcePicker.SignalName
    {
    }
}
