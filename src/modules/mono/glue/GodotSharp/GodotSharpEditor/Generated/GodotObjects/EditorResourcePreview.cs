namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node is used to generate previews for resources or files.</para>
/// <para><b>Note:</b> This class shouldn't be instantiated directly. Instead, access the singleton using <see cref="Godot.EditorInterface.GetResourcePreviewer()"/>.</para>
/// </summary>
public partial class EditorResourcePreview : Node
{
    private static readonly System.Type CachedType = typeof(EditorResourcePreview);

    private static readonly StringName NativeName = "EditorResourcePreview";

    internal EditorResourcePreview() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorResourcePreview(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorResourcePreview(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueResourcePreview, 233177534ul);

    /// <summary>
    /// <para>Queue a resource file located at <paramref name="path"/> for preview. Once the preview is ready, the <paramref name="receiver"/>'s <paramref name="receiverFunc"/> will be called. The <paramref name="receiverFunc"/> must take the following four arguments: <see cref="string"/> path, <see cref="Godot.Texture2D"/> preview, <see cref="Godot.Texture2D"/> thumbnail_preview, <see cref="Godot.Variant"/> userdata. <paramref name="userdata"/> can be anything, and will be returned when <paramref name="receiverFunc"/> is called.</para>
    /// <para><b>Note:</b> If it was not possible to create the preview the <paramref name="receiverFunc"/> will still be called, but the preview will be <see langword="null"/>.</para>
    /// </summary>
    public void QueueResourcePreview(string path, GodotObject receiver, StringName receiverFunc, Variant userdata)
    {
        EditorNativeCalls.godot_icall_4_526(MethodBind0, GodotObject.GetPtr(this), path, GodotObject.GetPtr(receiver), (godot_string_name)(receiverFunc?.NativeValue ?? default), userdata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueEditedResourcePreview, 1608376650ul);

    /// <summary>
    /// <para>Queue the <paramref name="resource"/> being edited for preview. Once the preview is ready, the <paramref name="receiver"/>'s <paramref name="receiverFunc"/> will be called. The <paramref name="receiverFunc"/> must take the following four arguments: <see cref="string"/> path, <see cref="Godot.Texture2D"/> preview, <see cref="Godot.Texture2D"/> thumbnail_preview, <see cref="Godot.Variant"/> userdata. <paramref name="userdata"/> can be anything, and will be returned when <paramref name="receiverFunc"/> is called.</para>
    /// <para><b>Note:</b> If it was not possible to create the preview the <paramref name="receiverFunc"/> will still be called, but the preview will be <see langword="null"/>.</para>
    /// </summary>
    public void QueueEditedResourcePreview(Resource resource, GodotObject receiver, StringName receiverFunc, Variant userdata)
    {
        EditorNativeCalls.godot_icall_4_527(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(resource), GodotObject.GetPtr(receiver), (godot_string_name)(receiverFunc?.NativeValue ?? default), userdata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPreviewGenerator, 332288124ul);

    /// <summary>
    /// <para>Create an own, custom preview generator.</para>
    /// </summary>
    public void AddPreviewGenerator(EditorResourcePreviewGenerator generator)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(generator));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePreviewGenerator, 332288124ul);

    /// <summary>
    /// <para>Removes a custom preview generator.</para>
    /// </summary>
    public void RemovePreviewGenerator(EditorResourcePreviewGenerator generator)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(generator));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CheckForInvalidation, 83702148ul);

    /// <summary>
    /// <para>Check if the resource changed, if so, it will be invalidated and the corresponding signal emitted.</para>
    /// </summary>
    public void CheckForInvalidation(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), path);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorResourcePreview.PreviewInvalidated"/> event of a <see cref="Godot.EditorResourcePreview"/> class.
    /// </summary>
    public delegate void PreviewInvalidatedEventHandler(string path);

    private static void PreviewInvalidatedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PreviewInvalidatedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted if a preview was invalidated (changed). <c>path</c> corresponds to the path of the preview.</para>
    /// </summary>
    public unsafe event PreviewInvalidatedEventHandler PreviewInvalidated
    {
        add => Connect(SignalName.PreviewInvalidated, Callable.CreateWithUnsafeTrampoline(value, &PreviewInvalidatedTrampoline));
        remove => Disconnect(SignalName.PreviewInvalidated, Callable.CreateWithUnsafeTrampoline(value, &PreviewInvalidatedTrampoline));
    }

    protected void EmitSignalPreviewInvalidated(string path)
    {
        EmitSignal(SignalName.PreviewInvalidated, path);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_preview_invalidated = "PreviewInvalidated";

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
        if (signal == SignalName.PreviewInvalidated)
        {
            if (HasGodotClassSignal(SignalProxyName_preview_invalidated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'queue_resource_preview' method.
        /// </summary>
        public static readonly StringName QueueResourcePreview = "queue_resource_preview";
        /// <summary>
        /// Cached name for the 'queue_edited_resource_preview' method.
        /// </summary>
        public static readonly StringName QueueEditedResourcePreview = "queue_edited_resource_preview";
        /// <summary>
        /// Cached name for the 'add_preview_generator' method.
        /// </summary>
        public static readonly StringName AddPreviewGenerator = "add_preview_generator";
        /// <summary>
        /// Cached name for the 'remove_preview_generator' method.
        /// </summary>
        public static readonly StringName RemovePreviewGenerator = "remove_preview_generator";
        /// <summary>
        /// Cached name for the 'check_for_invalidation' method.
        /// </summary>
        public static readonly StringName CheckForInvalidation = "check_for_invalidation";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'preview_invalidated' signal.
        /// </summary>
        public static readonly StringName PreviewInvalidated = "preview_invalidated";
    }
}
