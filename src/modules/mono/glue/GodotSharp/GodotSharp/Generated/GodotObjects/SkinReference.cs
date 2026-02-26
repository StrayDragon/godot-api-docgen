namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An internal object containing a mapping from a <see cref="Godot.Skin"/> used within the context of a particular <see cref="Godot.MeshInstance3D"/> to refer to the skeleton's <see cref="Godot.Rid"/> in the RenderingServer.</para>
/// <para>See also <see cref="Godot.MeshInstance3D.GetSkinReference()"/> and <see cref="Godot.RenderingServer.InstanceAttachSkeleton(Rid, Rid)"/>.</para>
/// <para>Note that despite the similar naming, the skeleton RID used in the <see cref="Godot.RenderingServer"/> does not have a direct one-to-one correspondence to a <see cref="Godot.Skeleton3D"/> node.</para>
/// <para>In particular, a <see cref="Godot.Skeleton3D"/> node with no <see cref="Godot.MeshInstance3D"/> children may be unknown to the <see cref="Godot.RenderingServer"/>.</para>
/// <para>On the other hand, a <see cref="Godot.Skeleton3D"/> with multiple <see cref="Godot.MeshInstance3D"/> nodes which each have different <see cref="Godot.MeshInstance3D.Skin"/> objects may have multiple SkinReference instances (and hence, multiple skeleton <see cref="Godot.Rid"/>s).</para>
/// </summary>
public partial class SkinReference : RefCounted
{
    private static readonly System.Type CachedType = typeof(SkinReference);

    private static readonly StringName NativeName = "SkinReference";

    internal SkinReference() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkinReference(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkinReference(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeleton, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> owned by this SkinReference, as returned by <see cref="Godot.RenderingServer.SkeletonCreate()"/>.</para>
    /// </summary>
    public Rid GetSkeleton()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkin, 2074563878ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Skin"/> connected to this SkinReference. In the case of <see cref="Godot.MeshInstance3D"/> with no <see cref="Godot.MeshInstance3D.Skin"/> assigned, this will reference an internal default <see cref="Godot.Skin"/> owned by that <see cref="Godot.MeshInstance3D"/>.</para>
    /// <para>Note that a single <see cref="Godot.Skin"/> may have more than one <see cref="Godot.SkinReference"/> in the case that it is shared by meshes across multiple <see cref="Godot.Skeleton3D"/> nodes.</para>
    /// </summary>
    public Skin GetSkin()
    {
        return (Skin)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_skeleton' method.
        /// </summary>
        public static readonly StringName GetSkeleton = "get_skeleton";
        /// <summary>
        /// Cached name for the 'get_skin' method.
        /// </summary>
        public static readonly StringName GetSkin = "get_skin";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
