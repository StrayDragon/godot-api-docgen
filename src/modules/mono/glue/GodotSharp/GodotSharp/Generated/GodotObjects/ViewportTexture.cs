namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.ViewportTexture"/> provides the content of a <see cref="Godot.Viewport"/> as a dynamic <see cref="Godot.Texture2D"/>. This can be used to combine the rendering of <see cref="Godot.Control"/>, <see cref="Godot.Node2D"/> and <see cref="Godot.Node3D"/> nodes. For example, you can use this texture to display a 3D scene inside a <see cref="Godot.TextureRect"/>, or a 2D overlay in a <see cref="Godot.Sprite3D"/>.</para>
/// <para>To get a <see cref="Godot.ViewportTexture"/> in code, use the <see cref="Godot.Viewport.GetTexture()"/> method on the target viewport.</para>
/// <para><b>Note:</b> A <see cref="Godot.ViewportTexture"/> is always local to its scene (see <see cref="Godot.Resource.ResourceLocalToScene"/>). If the scene root is not ready, it may return incorrect data (see <see cref="Godot.Node.Ready"/>).</para>
/// <para><b>Note:</b> Instantiating scenes containing a high-resolution <see cref="Godot.ViewportTexture"/> may cause noticeable stutter.</para>
/// <para><b>Note:</b> When using a <see cref="Godot.Viewport"/> with <see cref="Godot.Viewport.UseHdr2D"/> set to <see langword="true"/>, the returned texture will be an HDR image that uses linear encoding. This may look darker than normal when displayed directly on screen. To convert to nonlinear sRGB encoding, you can do the following:</para>
/// <para><code>
/// img.convert(Image.FORMAT_RGBA8)
/// img.linear_to_srgb()
/// </code></para>
/// <para><b>Note:</b> Some nodes such as <see cref="Godot.Decal"/>, <see cref="Godot.Light3D"/>, and <see cref="Godot.PointLight2D"/> do not support using <see cref="Godot.ViewportTexture"/> directly. To use texture data from a <see cref="Godot.ViewportTexture"/> in these nodes, you need to create an <see cref="Godot.ImageTexture"/> by calling <see cref="Godot.Texture2D.GetImage()"/> on the <see cref="Godot.ViewportTexture"/> and passing the result to <see cref="Godot.ImageTexture.CreateFromImage(Image)"/>. This conversion is a slow operation, so it should not be performed every frame.</para>
/// </summary>
public partial class ViewportTexture : Texture2D
{
    /// <summary>
    /// <para>The path to the <see cref="Godot.Viewport"/> node to display. This is relative to the local scene root (see <see cref="Godot.Resource.GetLocalScene()"/>), <b>not</b> to the nodes that use this texture.</para>
    /// <para><b>Note:</b> In the editor, this path is automatically updated when the target viewport or one of its ancestors is renamed or moved. At runtime, this path may not automatically update if the scene root cannot be found.</para>
    /// </summary>
    public NodePath ViewportPath
    {
        get
        {
            return GetViewportPathInScene();
        }
        set
        {
            SetViewportPathInScene(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ViewportTexture);

    private static readonly StringName NativeName = "ViewportTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ViewportTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ViewportTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ViewportTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetViewportPathInScene, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetViewportPathInScene(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewportPathInScene, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetViewportPathInScene()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'viewport_path' property.
        /// </summary>
        public static readonly StringName ViewportPath = "viewport_path";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_viewport_path_in_scene' method.
        /// </summary>
        public static readonly StringName SetViewportPathInScene = "set_viewport_path_in_scene";
        /// <summary>
        /// Cached name for the 'get_viewport_path_in_scene' method.
        /// </summary>
        public static readonly StringName GetViewportPathInScene = "get_viewport_path_in_scene";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
