namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
[GodotClassName("GLTFSkeleton")]
public partial class GltfSkeleton : Resource
{
    public int[] Joints
    {
        get
        {
            return GetJoints();
        }
        set
        {
            SetJoints(value);
        }
    }

    public int[] Roots
    {
        get
        {
            return GetRoots();
        }
        set
        {
            SetRoots(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<string> UniqueNames
    {
        get
        {
            return GetUniqueNames();
        }
        set
        {
            SetUniqueNames(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary GodotBoneNode
    {
        get
        {
            return GetGodotBoneNode();
        }
        set
        {
            SetGodotBoneNode(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(GltfSkeleton);

    private static readonly StringName NativeName = "GLTFSkeleton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfSkeleton() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfSkeleton(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfSkeleton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoints, 969006518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetJoints()
    {
        return NativeCalls.godot_icall_0_151(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJoints, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJoints(int[] joints)
    {
        NativeCalls.godot_icall_1_150(MethodBind1, GodotObject.GetPtr(this), joints);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJoints(ReadOnlySpan<int> joints)
    {
        NativeCalls.godot_icall_1_150(MethodBind1, GodotObject.GetPtr(this), joints);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRoots, 969006518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetRoots()
    {
        return NativeCalls.godot_icall_0_151(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRoots, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRoots(int[] roots)
    {
        NativeCalls.godot_icall_1_150(MethodBind3, GodotObject.GetPtr(this), roots);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRoots(ReadOnlySpan<int> roots)
    {
        NativeCalls.godot_icall_1_150(MethodBind3, GodotObject.GetPtr(this), roots);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGodotSkeleton, 1814733083ul);

    public Skeleton3D GetGodotSkeleton()
    {
        return (Skeleton3D)NativeCalls.godot_icall_0_53(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUniqueNames, 2915620761ul);

    public Godot.Collections.Array<string> GetUniqueNames()
    {
        return new Godot.Collections.Array<string>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUniqueNames, 381264803ul);

    public void SetUniqueNames(Godot.Collections.Array<string> uniqueNames)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(uniqueNames ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGodotBoneNode, 2382534195ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> that maps skeleton bone indices to the indices of glTF nodes. This property is unused during import, and only set during export. In a glTF file, a bone is a node, so Godot converts skeleton bones to glTF nodes.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetGodotBoneNode()
    {
        return NativeCalls.godot_icall_0_122(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGodotBoneNode, 4155329257ul);

    /// <summary>
    /// <para>Sets a <see cref="Godot.Collections.Dictionary"/> that maps skeleton bone indices to the indices of glTF nodes. This property is unused during import, and only set during export. In a glTF file, a bone is a node, so Godot converts skeleton bones to glTF nodes.</para>
    /// </summary>
    public void SetGodotBoneNode(Godot.Collections.Dictionary godotBoneNode)
    {
        NativeCalls.godot_icall_1_121(MethodBind8, GodotObject.GetPtr(this), (godot_dictionary)(godotBoneNode ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneAttachmentCount, 2455072627ul);

    public int GetBoneAttachmentCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneAttachment, 945440495ul);

    public BoneAttachment3D GetBoneAttachment(int idx)
    {
        return (BoneAttachment3D)NativeCalls.godot_icall_1_335(MethodBind10, GodotObject.GetPtr(this), idx);
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'joints' property.
        /// </summary>
        public static readonly StringName Joints = "joints";
        /// <summary>
        /// Cached name for the 'roots' property.
        /// </summary>
        public static readonly StringName Roots = "roots";
        /// <summary>
        /// Cached name for the 'unique_names' property.
        /// </summary>
        public static readonly StringName UniqueNames = "unique_names";
        /// <summary>
        /// Cached name for the 'godot_bone_node' property.
        /// </summary>
        public static readonly StringName GodotBoneNode = "godot_bone_node";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_joints' method.
        /// </summary>
        public static readonly StringName GetJoints = "get_joints";
        /// <summary>
        /// Cached name for the 'set_joints' method.
        /// </summary>
        public static readonly StringName SetJoints = "set_joints";
        /// <summary>
        /// Cached name for the 'get_roots' method.
        /// </summary>
        public static readonly StringName GetRoots = "get_roots";
        /// <summary>
        /// Cached name for the 'set_roots' method.
        /// </summary>
        public static readonly StringName SetRoots = "set_roots";
        /// <summary>
        /// Cached name for the 'get_godot_skeleton' method.
        /// </summary>
        public static readonly StringName GetGodotSkeleton = "get_godot_skeleton";
        /// <summary>
        /// Cached name for the 'get_unique_names' method.
        /// </summary>
        public static readonly StringName GetUniqueNames = "get_unique_names";
        /// <summary>
        /// Cached name for the 'set_unique_names' method.
        /// </summary>
        public static readonly StringName SetUniqueNames = "set_unique_names";
        /// <summary>
        /// Cached name for the 'get_godot_bone_node' method.
        /// </summary>
        public static readonly StringName GetGodotBoneNode = "get_godot_bone_node";
        /// <summary>
        /// Cached name for the 'set_godot_bone_node' method.
        /// </summary>
        public static readonly StringName SetGodotBoneNode = "set_godot_bone_node";
        /// <summary>
        /// Cached name for the 'get_bone_attachment_count' method.
        /// </summary>
        public static readonly StringName GetBoneAttachmentCount = "get_bone_attachment_count";
        /// <summary>
        /// Cached name for the 'get_bone_attachment' method.
        /// </summary>
        public static readonly StringName GetBoneAttachment = "get_bone_attachment";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
