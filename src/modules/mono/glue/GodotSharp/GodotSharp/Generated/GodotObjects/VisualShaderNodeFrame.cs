namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A rectangular frame that can be used to group visual shader nodes together to improve organization.</para>
/// <para>Nodes attached to the frame will move with it when it is dragged and it can automatically resize to enclose all attached nodes.</para>
/// <para>Its title, description and color can be customized.</para>
/// </summary>
public partial class VisualShaderNodeFrame : VisualShaderNodeResizableBase
{
    /// <summary>
    /// <para>The title of the node.</para>
    /// </summary>
    public string Title
    {
        get
        {
            return GetTitle();
        }
        set
        {
            SetTitle(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the frame will be tinted with the color specified in <see cref="Godot.VisualShaderNodeFrame.TintColor"/>.</para>
    /// </summary>
    public bool TintColorEnabled
    {
        get
        {
            return IsTintColorEnabled();
        }
        set
        {
            SetTintColorEnabled(value);
        }
    }

    /// <summary>
    /// <para>The color of the frame when <see cref="Godot.VisualShaderNodeFrame.TintColorEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public Color TintColor
    {
        get
        {
            return GetTintColor();
        }
        set
        {
            SetTintColor(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the frame will automatically resize to enclose all attached nodes.</para>
    /// </summary>
    public bool Autoshrink
    {
        get
        {
            return IsAutoshrinkEnabled();
        }
        set
        {
            SetAutoshrinkEnabled(value);
        }
    }

    /// <summary>
    /// <para>The list of nodes attached to the frame.</para>
    /// </summary>
    public int[] AttachedNodes
    {
        get
        {
            return GetAttachedNodes();
        }
        set
        {
            SetAttachedNodes(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeFrame);

    private static readonly StringName NativeName = "VisualShaderNodeFrame";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeFrame() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFrame(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFrame(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitle, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitle(string title)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitle, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTitle()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTintColorEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTintColorEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTintColorEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTintColorEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTintColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTintColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind4, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTintColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetTintColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoshrinkEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoshrinkEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoshrinkEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoshrinkEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAttachedNode, 1286410249ul);

    /// <summary>
    /// <para>Adds a node to the list of nodes attached to the frame. Should not be called directly, use the <see cref="Godot.VisualShader.AttachNodeToFrame(VisualShader.Type, int, int)"/> method instead.</para>
    /// </summary>
    public void AddAttachedNode(int node)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), node);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAttachedNode, 1286410249ul);

    /// <summary>
    /// <para>Removes a node from the list of nodes attached to the frame. Should not be called directly, use the <see cref="Godot.VisualShader.DetachNodeFromFrame(VisualShader.Type, int)"/> method instead.</para>
    /// </summary>
    public void RemoveAttachedNode(int node)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), node);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttachedNodes, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttachedNodes(int[] attachedNodes)
    {
        NativeCalls.godot_icall_1_150(MethodBind10, GodotObject.GetPtr(this), attachedNodes);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttachedNodes(ReadOnlySpan<int> attachedNodes)
    {
        NativeCalls.godot_icall_1_150(MethodBind10, GodotObject.GetPtr(this), attachedNodes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttachedNodes, 1930428628ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetAttachedNodes()
    {
        return NativeCalls.godot_icall_0_151(MethodBind11, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeResizableBase.PropertyName
    {
        /// <summary>
        /// Cached name for the 'title' property.
        /// </summary>
        public static readonly StringName Title = "title";
        /// <summary>
        /// Cached name for the 'tint_color_enabled' property.
        /// </summary>
        public static readonly StringName TintColorEnabled = "tint_color_enabled";
        /// <summary>
        /// Cached name for the 'tint_color' property.
        /// </summary>
        public static readonly StringName TintColor = "tint_color";
        /// <summary>
        /// Cached name for the 'autoshrink' property.
        /// </summary>
        public static readonly StringName Autoshrink = "autoshrink";
        /// <summary>
        /// Cached name for the 'attached_nodes' property.
        /// </summary>
        public static readonly StringName AttachedNodes = "attached_nodes";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeResizableBase.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_title' method.
        /// </summary>
        public static readonly StringName SetTitle = "set_title";
        /// <summary>
        /// Cached name for the 'get_title' method.
        /// </summary>
        public static readonly StringName GetTitle = "get_title";
        /// <summary>
        /// Cached name for the 'set_tint_color_enabled' method.
        /// </summary>
        public static readonly StringName SetTintColorEnabled = "set_tint_color_enabled";
        /// <summary>
        /// Cached name for the 'is_tint_color_enabled' method.
        /// </summary>
        public static readonly StringName IsTintColorEnabled = "is_tint_color_enabled";
        /// <summary>
        /// Cached name for the 'set_tint_color' method.
        /// </summary>
        public static readonly StringName SetTintColor = "set_tint_color";
        /// <summary>
        /// Cached name for the 'get_tint_color' method.
        /// </summary>
        public static readonly StringName GetTintColor = "get_tint_color";
        /// <summary>
        /// Cached name for the 'set_autoshrink_enabled' method.
        /// </summary>
        public static readonly StringName SetAutoshrinkEnabled = "set_autoshrink_enabled";
        /// <summary>
        /// Cached name for the 'is_autoshrink_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoshrinkEnabled = "is_autoshrink_enabled";
        /// <summary>
        /// Cached name for the 'add_attached_node' method.
        /// </summary>
        public static readonly StringName AddAttachedNode = "add_attached_node";
        /// <summary>
        /// Cached name for the 'remove_attached_node' method.
        /// </summary>
        public static readonly StringName RemoveAttachedNode = "remove_attached_node";
        /// <summary>
        /// Cached name for the 'set_attached_nodes' method.
        /// </summary>
        public static readonly StringName SetAttachedNodes = "set_attached_nodes";
        /// <summary>
        /// Cached name for the 'get_attached_nodes' method.
        /// </summary>
        public static readonly StringName GetAttachedNodes = "get_attached_nodes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeResizableBase.SignalName
    {
    }
}
