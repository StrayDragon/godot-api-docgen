namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Resource tooltip plugins are used by <see cref="Godot.FileSystemDock"/> to generate customized tooltips for specific resources. E.g. tooltip for a <see cref="Godot.Texture2D"/> displays a bigger preview and the texture's dimensions.</para>
/// <para>A plugin must be first registered with <see cref="Godot.FileSystemDock.AddResourceTooltipPlugin(EditorResourceTooltipPlugin)"/>. When the user hovers a resource in filesystem dock which is handled by the plugin, <see cref="Godot.EditorResourceTooltipPlugin._MakeTooltipForPath(string, Godot.Collections.Dictionary, Control)"/> is called to create the tooltip. It works similarly to <see cref="Godot.Control._MakeCustomTooltip(string)"/>.</para>
/// </summary>
public partial class EditorResourceTooltipPlugin : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorResourceTooltipPlugin);

    private static readonly StringName NativeName = "EditorResourceTooltipPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorResourceTooltipPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorResourceTooltipPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorResourceTooltipPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Return <see langword="true"/> if the plugin is going to handle the given <see cref="Godot.Resource"/> <paramref name="type"/>.</para>
    /// </summary>
    public virtual bool _Handles(string type)
    {
        return default;
    }

    /// <summary>
    /// <para>Create and return a tooltip that will be displayed when the user hovers a resource under the given <paramref name="path"/> in filesystem dock.</para>
    /// <para>The <paramref name="metadata"/> dictionary is provided by preview generator (see <see cref="Godot.EditorResourcePreviewGenerator._Generate(Resource, Vector2I, Godot.Collections.Dictionary)"/>).</para>
    /// <para><paramref name="base"/> is the base default tooltip, which is a <see cref="Godot.VBoxContainer"/> with a file name, type and size labels. If another plugin handled the same file type, <paramref name="base"/> will be output from the previous plugin. For best result, make sure the base tooltip is part of the returned <see cref="Godot.Control"/>.</para>
    /// <para><b>Note:</b> It's unadvised to use <see cref="Godot.ResourceLoader.Load(string, string, ResourceLoader.CacheMode)"/>, especially with heavy resources like models or textures, because it will make the editor unresponsive when creating the tooltip. You can use <see cref="Godot.EditorResourceTooltipPlugin.RequestThumbnail(string, TextureRect)"/> if you want to display a preview in your tooltip.</para>
    /// <para><b>Note:</b> If you decide to discard the <paramref name="base"/>, make sure to call <see cref="Godot.Node.QueueFree()"/>, because it's not freed automatically.</para>
    /// <para><code>
    /// func _make_tooltip_for_path(path, metadata, base):
    /// 	var t_rect = TextureRect.new()
    /// 	request_thumbnail(path, t_rect)
    /// 	base.add_child(t_rect) # The TextureRect will appear at the bottom of the tooltip.
    /// 	return base
    /// </code></para>
    /// </summary>
    public virtual Control _MakeTooltipForPath(string path, Godot.Collections.Dictionary metadata, Control @base)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestThumbnail, 3245519720ul);

    /// <summary>
    /// <para>Requests a thumbnail for the given <see cref="Godot.TextureRect"/>. The thumbnail is created asynchronously by <see cref="Godot.EditorResourcePreview"/> and automatically set when available.</para>
    /// </summary>
    public void RequestThumbnail(string path, TextureRect control)
    {
        NativeCalls.godot_icall_2_517(MethodBind0, GodotObject.GetPtr(this), path, GodotObject.GetPtr(control));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handles = "_Handles";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__make_tooltip_for_path = "_MakeTooltipForPath";

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
        if ((method == MethodProxyName__handles || method == MethodName._Handles) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__handles.NativeValue))
        {
            var callRet = _Handles(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__make_tooltip_for_path || method == MethodName._MakeTooltipForPath) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__make_tooltip_for_path.NativeValue))
        {
            var callRet = _MakeTooltipForPath(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[1]), VariantUtils.ConvertTo<Control>(args[2]));
            ret = VariantUtils.CreateFrom<Control>(callRet);
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
        if (method == MethodName._Handles)
        {
            if (HasGodotClassMethod(MethodProxyName__handles.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MakeTooltipForPath)
        {
            if (HasGodotClassMethod(MethodProxyName__make_tooltip_for_path.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_handles' method.
        /// </summary>
        public static readonly StringName _Handles = "_handles";
        /// <summary>
        /// Cached name for the '_make_tooltip_for_path' method.
        /// </summary>
        public static readonly StringName _MakeTooltipForPath = "_make_tooltip_for_path";
        /// <summary>
        /// Cached name for the 'request_thumbnail' method.
        /// </summary>
        public static readonly StringName RequestThumbnail = "request_thumbnail";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
