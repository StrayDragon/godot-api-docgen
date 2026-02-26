namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for <see cref="Godot.Texture2DArrayRD"/>, <see cref="Godot.TextureCubemapRD"/> and <see cref="Godot.TextureCubemapArrayRD"/>. Cannot be used directly, but contains all the functions necessary for accessing the derived resource types.</para>
/// <para><b>Note:</b> <see cref="Godot.TextureLayeredRD"/> is intended for low-level usage with <see cref="Godot.RenderingDevice"/>. For most use cases, use <see cref="Godot.TextureLayered"/> instead.</para>
/// </summary>
public partial class TextureLayeredRD : TextureLayered
{
    /// <summary>
    /// <para>The RID of the texture object created on the <see cref="Godot.RenderingDevice"/>.</para>
    /// </summary>
    public Rid TextureRdRid
    {
        get
        {
            return GetTextureRdRid();
        }
        set
        {
            SetTextureRdRid(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TextureLayeredRD);

    private static readonly StringName NativeName = "TextureLayeredRD";

    internal TextureLayeredRD() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextureLayeredRD(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextureLayeredRD(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureRdRid, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureRdRid(Rid textureRdRid)
    {
        NativeCalls.godot_icall_1_286(MethodBind0, GodotObject.GetPtr(this), textureRdRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureRdRid, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetTextureRdRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : TextureLayered.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture_rd_rid' property.
        /// </summary>
        public static readonly StringName TextureRdRid = "texture_rd_rid";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : TextureLayered.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_texture_rd_rid' method.
        /// </summary>
        public static readonly StringName SetTextureRdRid = "set_texture_rd_rid";
        /// <summary>
        /// Cached name for the 'get_texture_rd_rid' method.
        /// </summary>
        public static readonly StringName GetTextureRdRid = "get_texture_rd_rid";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : TextureLayered.SignalName
    {
    }
}
