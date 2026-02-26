namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class contains the list of attachment descriptions for a framebuffer pass. Each points with an index to a previously supplied list of texture attachments.</para>
/// <para>Multipass framebuffers can optimize some configurations in mobile. On desktop, they provide little to no advantage.</para>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDFramebufferPass : RefCounted
{
    /// <summary>
    /// <para>Attachment is unused.</para>
    /// </summary>
    public const long AttachmentUnused = -1;

    /// <summary>
    /// <para>Color attachments in order starting from 0. If this attachment is not used by the shader, pass ATTACHMENT_UNUSED to skip.</para>
    /// </summary>
    public int[] ColorAttachments
    {
        get
        {
            return GetColorAttachments();
        }
        set
        {
            SetColorAttachments(value);
        }
    }

    /// <summary>
    /// <para>Used for multipass framebuffers (more than one render pass). Converts an attachment to an input. Make sure to also supply it properly in the <see cref="Godot.RDUniform"/> for the uniform set.</para>
    /// </summary>
    public int[] InputAttachments
    {
        get
        {
            return GetInputAttachments();
        }
        set
        {
            SetInputAttachments(value);
        }
    }

    /// <summary>
    /// <para>If the color attachments are multisampled, non-multisampled resolve attachments can be provided.</para>
    /// </summary>
    public int[] ResolveAttachments
    {
        get
        {
            return GetResolveAttachments();
        }
        set
        {
            SetResolveAttachments(value);
        }
    }

    /// <summary>
    /// <para>Attachments to preserve in this pass (otherwise they are erased).</para>
    /// </summary>
    public int[] PreserveAttachments
    {
        get
        {
            return GetPreserveAttachments();
        }
        set
        {
            SetPreserveAttachments(value);
        }
    }

    /// <summary>
    /// <para>Depth attachment. ATTACHMENT_UNUSED should be used if no depth buffer is required for this pass.</para>
    /// </summary>
    public int DepthAttachment
    {
        get
        {
            return GetDepthAttachment();
        }
        set
        {
            SetDepthAttachment(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDFramebufferPass);

    private static readonly StringName NativeName = "RDFramebufferPass";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDFramebufferPass() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDFramebufferPass(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDFramebufferPass(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorAttachments, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorAttachments(int[] pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind0, GodotObject.GetPtr(this), pMember);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorAttachments(ReadOnlySpan<int> pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind0, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorAttachments, 1930428628ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetColorAttachments()
    {
        return NativeCalls.godot_icall_0_151(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputAttachments, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInputAttachments(int[] pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), pMember);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInputAttachments(ReadOnlySpan<int> pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputAttachments, 1930428628ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetInputAttachments()
    {
        return NativeCalls.godot_icall_0_151(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResolveAttachments, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResolveAttachments(int[] pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind4, GodotObject.GetPtr(this), pMember);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResolveAttachments(ReadOnlySpan<int> pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind4, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolveAttachments, 1930428628ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetResolveAttachments()
    {
        return NativeCalls.godot_icall_0_151(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreserveAttachments, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreserveAttachments(int[] pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind6, GodotObject.GetPtr(this), pMember);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreserveAttachments(ReadOnlySpan<int> pMember)
    {
        NativeCalls.godot_icall_1_150(MethodBind6, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreserveAttachments, 1930428628ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetPreserveAttachments()
    {
        return NativeCalls.godot_icall_0_151(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthAttachment, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthAttachment(int pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthAttachment, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDepthAttachment()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
        /// <summary>
        /// Cached name for the 'color_attachments' property.
        /// </summary>
        public static readonly StringName ColorAttachments = "color_attachments";
        /// <summary>
        /// Cached name for the 'input_attachments' property.
        /// </summary>
        public static readonly StringName InputAttachments = "input_attachments";
        /// <summary>
        /// Cached name for the 'resolve_attachments' property.
        /// </summary>
        public static readonly StringName ResolveAttachments = "resolve_attachments";
        /// <summary>
        /// Cached name for the 'preserve_attachments' property.
        /// </summary>
        public static readonly StringName PreserveAttachments = "preserve_attachments";
        /// <summary>
        /// Cached name for the 'depth_attachment' property.
        /// </summary>
        public static readonly StringName DepthAttachment = "depth_attachment";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_color_attachments' method.
        /// </summary>
        public static readonly StringName SetColorAttachments = "set_color_attachments";
        /// <summary>
        /// Cached name for the 'get_color_attachments' method.
        /// </summary>
        public static readonly StringName GetColorAttachments = "get_color_attachments";
        /// <summary>
        /// Cached name for the 'set_input_attachments' method.
        /// </summary>
        public static readonly StringName SetInputAttachments = "set_input_attachments";
        /// <summary>
        /// Cached name for the 'get_input_attachments' method.
        /// </summary>
        public static readonly StringName GetInputAttachments = "get_input_attachments";
        /// <summary>
        /// Cached name for the 'set_resolve_attachments' method.
        /// </summary>
        public static readonly StringName SetResolveAttachments = "set_resolve_attachments";
        /// <summary>
        /// Cached name for the 'get_resolve_attachments' method.
        /// </summary>
        public static readonly StringName GetResolveAttachments = "get_resolve_attachments";
        /// <summary>
        /// Cached name for the 'set_preserve_attachments' method.
        /// </summary>
        public static readonly StringName SetPreserveAttachments = "set_preserve_attachments";
        /// <summary>
        /// Cached name for the 'get_preserve_attachments' method.
        /// </summary>
        public static readonly StringName GetPreserveAttachments = "get_preserve_attachments";
        /// <summary>
        /// Cached name for the 'set_depth_attachment' method.
        /// </summary>
        public static readonly StringName SetDepthAttachment = "set_depth_attachment";
        /// <summary>
        /// Cached name for the 'get_depth_attachment' method.
        /// </summary>
        public static readonly StringName GetDepthAttachment = "get_depth_attachment";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
