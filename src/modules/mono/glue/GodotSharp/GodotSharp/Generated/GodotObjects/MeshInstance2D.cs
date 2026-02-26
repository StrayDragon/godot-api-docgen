namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Node used for displaying a <see cref="Godot.Mesh"/> in 2D. This can be faster to render compared to displaying a <see cref="Godot.Sprite2D"/> node with large transparent areas, especially if the node takes up a lot of space on screen at high viewport resolutions. This is because using a mesh designed to fit the sprite's opaque areas will reduce GPU fill rate utilization (at the cost of increased vertex processing utilization).</para>
/// <para>When a <see cref="Godot.Mesh"/> has to be instantiated more than thousands of times close to each other, consider using a <see cref="Godot.MultiMesh"/> in a <see cref="Godot.MultiMeshInstance2D"/> instead.</para>
/// <para>A <see cref="Godot.MeshInstance2D"/> can be created from an existing <see cref="Godot.Sprite2D"/> via a tool in the editor toolbar. Select the <see cref="Godot.Sprite2D"/> node, then choose <b>Sprite2D &gt; Convert to MeshInstance2D</b> at the top of the 2D editor viewport.</para>
/// </summary>
public partial class MeshInstance2D : Node2D
{
    /// <summary>
    /// <para>The <see cref="Godot.Mesh"/> that will be drawn by the <see cref="Godot.MeshInstance2D"/>.</para>
    /// </summary>
    public Mesh Mesh
    {
        get
        {
            return GetMesh();
        }
        set
        {
            SetMesh(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Texture2D"/> that will be used if using the default <see cref="Godot.CanvasItemMaterial"/>. Can be accessed as <c>TEXTURE</c> in CanvasItem shader.</para>
    /// </summary>
    public Texture2D Texture
    {
        get
        {
            return GetTexture();
        }
        set
        {
            SetTexture(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MeshInstance2D);

    private static readonly StringName NativeName = "MeshInstance2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MeshInstance2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MeshInstance2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MeshInstance2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 194775623ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(Mesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 1808005922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Mesh GetMesh()
    {
        return (Mesh)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.MeshInstance2D.Texture"/> is changed.</para>
    /// </summary>
    public event Action TextureChanged
    {
        add => Connect(SignalName.TextureChanged, Callable.From(value));
        remove => Disconnect(SignalName.TextureChanged, Callable.From(value));
    }

    protected void EmitSignalTextureChanged()
    {
        EmitSignal(SignalName.TextureChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_texture_changed = "TextureChanged";

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
        if (signal == SignalName.TextureChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_texture_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'texture_changed' signal.
        /// </summary>
        public static readonly StringName TextureChanged = "texture_changed";
    }
}
