namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Turning on the option <b>Load As Placeholder</b> for an instantiated scene in the editor causes it to be replaced by an <see cref="Godot.InstancePlaceholder"/> when running the game, this will not replace the node in the editor. This makes it possible to delay actually loading the scene until calling <see cref="Godot.InstancePlaceholder.CreateInstance(bool, PackedScene)"/>. This is useful to avoid loading large scenes all at once by loading parts of it selectively.</para>
/// <para><b>Note:</b> Like <see cref="Godot.Node"/>, <see cref="Godot.InstancePlaceholder"/> does not have a transform. This causes any child nodes to be positioned relatively to the <see cref="Godot.Viewport"/> origin, rather than their parent as displayed in the editor. Replacing the placeholder with a scene with a transform will transform children relatively to their parent again.</para>
/// </summary>
public partial class InstancePlaceholder : Node
{
    private static readonly System.Type CachedType = typeof(InstancePlaceholder);

    private static readonly StringName NativeName = "InstancePlaceholder";

    internal InstancePlaceholder() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal InstancePlaceholder(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal InstancePlaceholder(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStoredValues, 2230153369ul);

    /// <summary>
    /// <para>Returns the list of properties that will be applied to the node when <see cref="Godot.InstancePlaceholder.CreateInstance(bool, PackedScene)"/> is called.</para>
    /// <para>If <paramref name="withOrder"/> is <see langword="true"/>, a key named <c>.order</c> (note the leading period) is added to the dictionary. This <c>.order</c> key is an <see cref="Godot.Collections.Array"/> of <see cref="string"/> property names specifying the order in which properties will be applied (with index 0 being the first).</para>
    /// </summary>
    public Godot.Collections.Dictionary GetStoredValues(bool withOrder = false)
    {
        return NativeCalls.godot_icall_1_759(MethodBind0, GodotObject.GetPtr(this), withOrder.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateInstance, 3794612210ul);

    /// <summary>
    /// <para>Call this method to actually load in the node. The created node will be placed as a sibling <i>above</i> the <see cref="Godot.InstancePlaceholder"/> in the scene tree. The <see cref="Godot.Node"/>'s reference is also returned for convenience.</para>
    /// <para><b>Note:</b> <see cref="Godot.InstancePlaceholder.CreateInstance(bool, PackedScene)"/> is not thread-safe. Use <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/> if calling from a thread.</para>
    /// </summary>
    public Node CreateInstance(bool replace = false, PackedScene customScene = default)
    {
        return (Node)NativeCalls.godot_icall_2_760(MethodBind1, GodotObject.GetPtr(this), replace.ToGodotBool(), GodotObject.GetPtr(customScene));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstancePath, 201670096ul);

    /// <summary>
    /// <para>Gets the path to the <see cref="Godot.PackedScene"/> resource file that is loaded by default when calling <see cref="Godot.InstancePlaceholder.CreateInstance(bool, PackedScene)"/>. Not thread-safe. Use <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/> if calling from a thread.</para>
    /// </summary>
    public string GetInstancePath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_stored_values' method.
        /// </summary>
        public static readonly StringName GetStoredValues = "get_stored_values";
        /// <summary>
        /// Cached name for the 'create_instance' method.
        /// </summary>
        public static readonly StringName CreateInstance = "create_instance";
        /// <summary>
        /// Cached name for the 'get_instance_path' method.
        /// </summary>
        public static readonly StringName GetInstancePath = "get_instance_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
    }
}
