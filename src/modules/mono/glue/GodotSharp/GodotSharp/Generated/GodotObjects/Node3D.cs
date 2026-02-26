namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.Node3D"/> node is the base representation of a node in 3D space. All other 3D nodes inherit from this class.</para>
/// <para>Affine operations (translation, rotation, scale) are calculated in the coordinate system relative to the parent, unless the <see cref="Godot.Node3D"/>'s <see cref="Godot.Node3D.TopLevel"/> is <see langword="true"/>. In this coordinate system, affine operations correspond to direct affine operations on the <see cref="Godot.Node3D"/>'s <see cref="Godot.Node3D.Transform"/>. The term <i>parent space</i> refers to this coordinate system. The coordinate system that is attached to the <see cref="Godot.Node3D"/> itself is referred to as object-local coordinate system, or <i>local space</i>.</para>
/// <para><b>Note:</b> Unless otherwise specified, all methods that need angle parameters must receive angles in <i>radians</i>. To convert degrees to radians, use <c>@GlobalScope.deg_to_rad</c>.</para>
/// <para><b>Note:</b> In Godot 3 and older, <see cref="Godot.Node3D"/> was named <i>Spatial</i>.</para>
/// </summary>
public partial class Node3D : Node
{
    /// <summary>
    /// <para>Notification received when this node's <see cref="Godot.Node3D.GlobalTransform"/> changes, if <see cref="Godot.Node3D.IsTransformNotificationEnabled()"/> is <see langword="true"/>. See also <see cref="Godot.Node3D.SetNotifyTransform(bool)"/>.</para>
    /// <para><b>Note:</b> Most 3D nodes such as <see cref="Godot.VisualInstance3D"/> or <see cref="Godot.CollisionObject3D"/> automatically enable this to function correctly.</para>
    /// <para><b>Note:</b> In the editor, nodes will propagate this notification to their children if a gizmo is attached (see <see cref="Godot.Node3D.AddGizmo(Node3DGizmo)"/>).</para>
    /// </summary>
    public const long NotificationTransformChanged = 2000;
    /// <summary>
    /// <para>Notification received when this node is registered to a new <see cref="Godot.World3D"/> (see <see cref="Godot.Node3D.GetWorld3D()"/>).</para>
    /// </summary>
    public const long NotificationEnterWorld = 41;
    /// <summary>
    /// <para>Notification received when this node is unregistered from the current <see cref="Godot.World3D"/> (see <see cref="Godot.Node3D.GetWorld3D()"/>).</para>
    /// <para>This notification is sent in reversed order.</para>
    /// </summary>
    public const long NotificationExitWorld = 42;
    /// <summary>
    /// <para>Notification received when this node's visibility changes (see <see cref="Godot.Node3D.Visible"/> and <see cref="Godot.Node3D.IsVisibleInTree()"/>).</para>
    /// <para>This notification is received <i>before</i> the related <see cref="Godot.Node3D.VisibilityChanged"/> signal.</para>
    /// </summary>
    public const long NotificationVisibilityChanged = 43;
    /// <summary>
    /// <para>Notification received when this node's <see cref="Godot.Node3D.Transform"/> changes, if <see cref="Godot.Node3D.IsLocalTransformNotificationEnabled()"/> is <see langword="true"/>. This is not received when a parent <see cref="Godot.Node3D"/>'s <see cref="Godot.Node3D.Transform"/> changes. See also <see cref="Godot.Node3D.SetNotifyLocalTransform(bool)"/>.</para>
    /// <para><b>Note:</b> Some 3D nodes such as <see cref="Godot.CsgShape3D"/> or <see cref="Godot.CollisionShape3D"/> automatically enable this to function correctly.</para>
    /// </summary>
    public const long NotificationLocalTransformChanged = 44;

    public enum RotationEditModeEnum : long
    {
        /// <summary>
        /// <para>The rotation is edited using a <see cref="Godot.Vector3"/> in <a href="https://en.wikipedia.org/wiki/Euler_angles">Euler angles</a>.</para>
        /// </summary>
        Euler = 0,
        /// <summary>
        /// <para>The rotation is edited using a <see cref="Godot.Quaternion"/>.</para>
        /// </summary>
        Quaternion = 1,
        /// <summary>
        /// <para>The rotation is edited using a <see cref="Godot.Basis"/>. In this mode, the raw <see cref="Godot.Node3D.Basis"/>'s axes can be freely modified, but the <see cref="Godot.Node3D.Scale"/> property is not available.</para>
        /// </summary>
        Basis = 2
    }

    /// <summary>
    /// <para>The local transformation of this node, in parent space (relative to the parent node). Contains and represents this node's <see cref="Godot.Node3D.Position"/>, <see cref="Godot.Node3D.Rotation"/>, and <see cref="Godot.Node3D.Scale"/>.</para>
    /// </summary>
    public Transform3D Transform
    {
        get
        {
            return GetTransform();
        }
        set
        {
            SetTransform(value);
        }
    }

    /// <summary>
    /// <para>The transformation of this node, in global space (relative to the world). Contains and represents this node's <see cref="Godot.Node3D.GlobalPosition"/>, <see cref="Godot.Node3D.GlobalRotation"/>, and global scale.</para>
    /// <para><b>Note:</b> If the node is not inside the tree, getting this property fails and returns <c>Transform3D.IDENTITY</c>.</para>
    /// </summary>
    public Transform3D GlobalTransform
    {
        get
        {
            return GetGlobalTransform();
        }
        set
        {
            SetGlobalTransform(value);
        }
    }

    /// <summary>
    /// <para>Position (translation) of this node in parent space (relative to the parent node). This is equivalent to the <see cref="Godot.Node3D.Transform"/>'s <c>Transform3D.origin</c>.</para>
    /// </summary>
    public Vector3 Position
    {
        get
        {
            return GetPosition();
        }
        set
        {
            SetPosition(value);
        }
    }

    /// <summary>
    /// <para>Rotation of this node as <a href="https://en.wikipedia.org/wiki/Euler_angles">Euler angles</a>, in radians and in parent space (relative to the parent node). This value is obtained from <see cref="Godot.Node3D.Basis"/>'s rotation.</para>
    /// <para>- The <c>Vector3.x</c> is the angle around the local X axis (pitch);</para>
    /// <para>- The <c>Vector3.y</c> is the angle around the local Y axis (yaw);</para>
    /// <para>- The <c>Vector3.z</c> is the angle around the local Z axis (roll).</para>
    /// <para>The order of each consecutive rotation can be changed with <see cref="Godot.Node3D.RotationOrder"/> (see <see cref="Godot.EulerOrder"/> constants). By default, the YXZ convention is used (<see cref="Godot.EulerOrder.Yxz"/>).</para>
    /// <para><b>Note:</b> This property is edited in degrees in the inspector. If you want to use degrees in a script, use <see cref="Godot.Node3D.RotationDegrees"/>.</para>
    /// </summary>
    public Vector3 Rotation
    {
        get
        {
            return GetRotation();
        }
        set
        {
            SetRotation(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Node3D.Rotation"/> of this node, in degrees instead of radians.</para>
    /// <para><b>Note:</b> This is <b>not</b> the property available in the Inspector dock.</para>
    /// </summary>
    public Vector3 RotationDegrees
    {
        get
        {
            return GetRotationDegrees();
        }
        set
        {
            SetRotationDegrees(value);
        }
    }

    /// <summary>
    /// <para>Rotation of this node represented as a <see cref="Godot.Quaternion"/> in parent space (relative to the parent node). This value is obtained from <see cref="Godot.Node3D.Basis"/>'s rotation.</para>
    /// <para><b>Note:</b> Quaternions are much more suitable for 3D math but are less intuitive. Setting this property can be useful for interpolation (see <c>Quaternion.slerp</c>).</para>
    /// </summary>
    public Quaternion Quaternion
    {
        get
        {
            return GetQuaternion();
        }
        set
        {
            SetQuaternion(value);
        }
    }

    /// <summary>
    /// <para>Basis of the <see cref="Godot.Node3D.Transform"/> property. Represents the rotation, scale, and shear of this node in parent space (relative to the parent node).</para>
    /// </summary>
    public Basis Basis
    {
        get
        {
            return GetBasis();
        }
        set
        {
            SetBasis(value);
        }
    }

    /// <summary>
    /// <para>Scale of this node in local space (relative to this node). This value is obtained from <see cref="Godot.Node3D.Basis"/>'s scale.</para>
    /// <para><b>Note:</b> The behavior of some 3D node types is not affected by this property. These include <see cref="Godot.Light3D"/>, <see cref="Godot.Camera3D"/>, <see cref="Godot.AudioStreamPlayer3D"/>, and more.</para>
    /// <para><b>Warning:</b> The scale's components must either be all positive or all negative, and <b>not</b> exactly <c>0.0</c>. Otherwise, it won't be possible to obtain the scale from the <see cref="Godot.Node3D.Basis"/>. This may cause the intended scale to be lost when reloaded from disk, and potentially other unstable behavior.</para>
    /// </summary>
    public Vector3 Scale
    {
        get
        {
            return GetScale();
        }
        set
        {
            SetScale(value);
        }
    }

    /// <summary>
    /// <para>How this node's rotation and scale are displayed in the Inspector dock.</para>
    /// </summary>
    public Node3D.RotationEditModeEnum RotationEditMode
    {
        get
        {
            return GetRotationEditMode();
        }
        set
        {
            SetRotationEditMode(value);
        }
    }

    /// <summary>
    /// <para>The axis rotation order of the <see cref="Godot.Node3D.Rotation"/> property. The final orientation is calculated by rotating around the local X, Y, and Z axis in this order.</para>
    /// </summary>
    public EulerOrder RotationOrder
    {
        get
        {
            return GetRotationOrder();
        }
        set
        {
            SetRotationOrder(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the node does not inherit its transformations from its parent. As such, node transformations will only be in global space, which also means that <see cref="Godot.Node3D.GlobalTransform"/> and <see cref="Godot.Node3D.Transform"/> will be identical.</para>
    /// </summary>
    public bool TopLevel
    {
        get
        {
            return IsSetAsTopLevel();
        }
        set
        {
            SetAsTopLevel(value);
        }
    }

    /// <summary>
    /// <para>Global position (translation) of this node in global space (relative to the world). This is equivalent to the <see cref="Godot.Node3D.GlobalTransform"/>'s <c>Transform3D.origin</c>.</para>
    /// <para><b>Note:</b> If the node is not inside the tree, getting this property fails and returns <c>Vector3.ZERO</c>.</para>
    /// </summary>
    public Vector3 GlobalPosition
    {
        get
        {
            return GetGlobalPosition();
        }
        set
        {
            SetGlobalPosition(value);
        }
    }

    /// <summary>
    /// <para>Basis of the <see cref="Godot.Node3D.GlobalTransform"/> property. Represents the rotation, scale, and shear of this node in global space (relative to the world).</para>
    /// <para><b>Note:</b> If the node is not inside the tree, getting this property fails and returns <c>Basis.IDENTITY</c>.</para>
    /// </summary>
    public Basis GlobalBasis
    {
        get
        {
            return GetGlobalBasis();
        }
        set
        {
            SetGlobalBasis(value);
        }
    }

    /// <summary>
    /// <para>Global rotation of this node as <a href="https://en.wikipedia.org/wiki/Euler_angles">Euler angles</a>, in radians and in global space (relative to the world). This value is obtained from <see cref="Godot.Node3D.GlobalBasis"/>'s rotation.</para>
    /// <para>- The <c>Vector3.x</c> is the angle around the global X axis (pitch);</para>
    /// <para>- The <c>Vector3.y</c> is the angle around the global Y axis (yaw);</para>
    /// <para>- The <c>Vector3.z</c> is the angle around the global Z axis (roll).</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.Node3D.Rotation"/>, this property always follows the YXZ convention (<see cref="Godot.EulerOrder.Yxz"/>).</para>
    /// <para><b>Note:</b> If the node is not inside the tree, getting this property fails and returns <c>Vector3.ZERO</c>.</para>
    /// </summary>
    public Vector3 GlobalRotation
    {
        get
        {
            return GetGlobalRotation();
        }
        set
        {
            SetGlobalRotation(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Node3D.GlobalRotation"/> of this node, in degrees instead of radians.</para>
    /// <para><b>Note:</b> If the node is not inside the tree, getting this property fails and returns <c>Vector3.ZERO</c>.</para>
    /// </summary>
    public Vector3 GlobalRotationDegrees
    {
        get
        {
            return GetGlobalRotationDegrees();
        }
        set
        {
            SetGlobalRotationDegrees(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this node can be visible. The node is only rendered when all of its ancestors are visible, as well. That means <see cref="Godot.Node3D.IsVisibleInTree()"/> must return <see langword="true"/>.</para>
    /// </summary>
    public bool Visible
    {
        get
        {
            return IsVisible();
        }
        set
        {
            SetVisible(value);
        }
    }

    /// <summary>
    /// <para>Path to the visibility range parent for this node and its descendants. The visibility parent must be a <see cref="Godot.GeometryInstance3D"/>.</para>
    /// <para>Any visual instance will only be visible if the visibility parent (and all of its visibility ancestors) is hidden by being closer to the camera than its own <see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/>. Nodes hidden via the <see cref="Godot.Node3D.Visible"/> property are essentially removed from the visibility dependency tree, so dependent instances will not take the hidden node or its descendants into account.</para>
    /// </summary>
    public NodePath VisibilityParent
    {
        get
        {
            return GetVisibilityParent();
        }
        set
        {
            SetVisibilityParent(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Node3D);

    private static readonly StringName NativeName = "Node3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Node3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Node3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Node3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTransform(Transform3D local)
    {
        NativeCalls.godot_icall_1_648(MethodBind0, GodotObject.GetPtr(this), &local);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector3 position)
    {
        NativeCalls.godot_icall_1_177(MethodBind2, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotation, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRotation(Vector3 eulerRadians)
    {
        NativeCalls.godot_icall_1_177(MethodBind4, GodotObject.GetPtr(this), &eulerRadians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotation, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetRotation()
    {
        return NativeCalls.godot_icall_0_125(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationDegrees, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRotationDegrees(Vector3 eulerDegrees)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &eulerDegrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationDegrees, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetRotationDegrees()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationOrder, 1820889989ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationOrder(EulerOrder order)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)order);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationOrder, 916939469ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public EulerOrder GetRotationOrder()
    {
        return (EulerOrder)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationEditMode, 141483330ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationEditMode(Node3D.RotationEditModeEnum editMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)editMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationEditMode, 1572188370ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node3D.RotationEditModeEnum GetRotationEditMode()
    {
        return (Node3D.RotationEditModeEnum)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScale, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScale(Vector3 scale)
    {
        NativeCalls.godot_icall_1_177(MethodBind12, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScale, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetScale()
    {
        return NativeCalls.godot_icall_0_125(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetQuaternion, 1727505552ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetQuaternion(Quaternion quaternion)
    {
        NativeCalls.godot_icall_1_649(MethodBind14, GodotObject.GetPtr(this), &quaternion);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetQuaternion, 1222331677ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quaternion GetQuaternion()
    {
        return NativeCalls.godot_icall_0_126(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBasis, 1055510324ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBasis(Basis basis)
    {
        NativeCalls.godot_icall_1_653(MethodBind16, GodotObject.GetPtr(this), &basis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBasis, 2716978435ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Basis GetBasis()
    {
        return NativeCalls.godot_icall_0_652(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalTransform, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalTransform(Transform3D global)
    {
        NativeCalls.godot_icall_1_648(MethodBind18, GodotObject.GetPtr(this), &global);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalTransform, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetGlobalTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalTransformInterpolated, 4183770049ul);

    /// <summary>
    /// <para>When using physics interpolation, there will be circumstances in which you want to know the interpolated (displayed) transform of a node rather than the standard transform (which may only be accurate to the most recent physics tick).</para>
    /// <para>This is particularly important for frame-based operations that take place in <see cref="Godot.Node._Process(double)"/>, rather than <see cref="Godot.Node._PhysicsProcess(double)"/>. Examples include <see cref="Godot.Camera3D"/>s focusing on a node, or finding where to fire lasers from on a frame rather than physics tick.</para>
    /// <para><b>Note:</b> This function creates an interpolation pump on the <see cref="Godot.Node3D"/> the first time it is called, which can respond to physics interpolation resets. If you get problems with "streaking" when initially following a <see cref="Godot.Node3D"/>, be sure to call <see cref="Godot.Node3D.GetGlobalTransformInterpolated()"/> at least once <i>before</i> resetting the <see cref="Godot.Node3D"/> physics interpolation.</para>
    /// </summary>
    public Transform3D GetGlobalTransformInterpolated()
    {
        return NativeCalls.godot_icall_0_192(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalPosition(Vector3 position)
    {
        NativeCalls.godot_icall_1_177(MethodBind21, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetGlobalPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalBasis, 1055510324ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalBasis(Basis basis)
    {
        NativeCalls.godot_icall_1_653(MethodBind23, GodotObject.GetPtr(this), &basis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalBasis, 2716978435ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Basis GetGlobalBasis()
    {
        return NativeCalls.godot_icall_0_652(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalRotation, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalRotation(Vector3 eulerRadians)
    {
        NativeCalls.godot_icall_1_177(MethodBind25, GodotObject.GetPtr(this), &eulerRadians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalRotation, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetGlobalRotation()
    {
        return NativeCalls.godot_icall_0_125(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalRotationDegrees, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalRotationDegrees(Vector3 eulerDegrees)
    {
        NativeCalls.godot_icall_1_177(MethodBind27, GodotObject.GetPtr(this), &eulerDegrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalRotationDegrees, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetGlobalRotationDegrees()
    {
        return NativeCalls.godot_icall_0_125(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParentNode3D, 151077316ul);

    /// <summary>
    /// <para>Returns the parent <see cref="Godot.Node3D"/> that directly affects this node's <see cref="Godot.Node3D.GlobalTransform"/>. Returns <see langword="null"/> if no parent exists, the parent is not a <see cref="Godot.Node3D"/>, or <see cref="Godot.Node3D.TopLevel"/> is <see langword="true"/>.</para>
    /// <para><b>Note:</b> This method is not always equivalent to <see cref="Godot.Node.GetParent()"/>, which does not take <see cref="Godot.Node3D.TopLevel"/> into account.</para>
    /// </summary>
    public Node3D GetParentNode3D()
    {
        return (Node3D)NativeCalls.godot_icall_0_53(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreTransformNotification, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the node will not receive <see cref="Godot.Node3D.NotificationTransformChanged"/> or <see cref="Godot.Node3D.NotificationLocalTransformChanged"/>.</para>
    /// <para>It may useful to call this method when handling these notifications to prevent infinite recursion.</para>
    /// </summary>
    public void SetIgnoreTransformNotification(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind30, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsTopLevel, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAsTopLevel(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind31, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSetAsTopLevel, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSetAsTopLevel()
    {
        return NativeCalls.godot_icall_0_15(MethodBind32, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableScale, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, this node's <see cref="Godot.Node3D.GlobalTransform"/> is automatically orthonormalized. This results in this node not appearing distorted, as if its global scale were set to <c>Vector3.ONE</c> (or its negative counterpart). See also <see cref="Godot.Node3D.IsScaleDisabled()"/> and <see cref="Godot.Node3D.Orthonormalize()"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Node3D.Transform"/> is not affected by this setting.</para>
    /// </summary>
    public void SetDisableScale(bool disable)
    {
        NativeCalls.godot_icall_1_14(MethodBind33, GodotObject.GetPtr(this), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScaleDisabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this node's <see cref="Godot.Node3D.GlobalTransform"/> is automatically orthonormalized. This results in this node not appearing distorted, as if its global scale were set to <c>Vector3.ONE</c> (or its negative counterpart). See also <see cref="Godot.Node3D.SetDisableScale(bool)"/> and <see cref="Godot.Node3D.Orthonormalize()"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Node3D.Transform"/> is not affected by this setting.</para>
    /// </summary>
    public bool IsScaleDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorld3D, 317588385ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.World3D"/> this node is registered to.</para>
    /// <para>Usually, this is the same as the world used by this node's viewport (see <see cref="Godot.Node.GetViewport()"/> and <see cref="Godot.Viewport.FindWorld3D()"/>).</para>
    /// </summary>
    public World3D GetWorld3D()
    {
        return (World3D)NativeCalls.godot_icall_0_63(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdateTransform, 3218959716ul);

    /// <summary>
    /// <para>Forces the node's <see cref="Godot.Node3D.GlobalTransform"/> to update, by sending <see cref="Godot.Node3D.NotificationTransformChanged"/>. Fails if the node is not inside the tree.</para>
    /// <para><b>Note:</b> For performance reasons, transform changes are usually accumulated and applied <i>once</i> at the end of the frame. The update propagates through <see cref="Godot.Node3D"/> children, as well. Therefore, use this method only when you need an up-to-date transform (such as during physics operations).</para>
    /// </summary>
    public void ForceUpdateTransform()
    {
        NativeCalls.godot_icall_0_3(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityParent, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityParent(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind37, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityParent, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetVisibilityParent()
    {
        return NativeCalls.godot_icall_0_124(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateGizmos, 3218959716ul);

    /// <summary>
    /// <para>Updates all the <c>EditorNode3DGizmo</c> objects attached to this node. Only works in the editor.</para>
    /// </summary>
    public void UpdateGizmos()
    {
        NativeCalls.godot_icall_0_3(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddGizmo, 1544533845ul);

    /// <summary>
    /// <para>Attaches the given <paramref name="gizmo"/> to this node. Only works in the editor.</para>
    /// <para><b>Note:</b> <paramref name="gizmo"/> should be an <c>EditorNode3DGizmo</c>. The argument type is <see cref="Godot.Node3DGizmo"/> to avoid depending on editor classes in <see cref="Godot.Node3D"/>.</para>
    /// </summary>
    public void AddGizmo(Node3DGizmo gizmo)
    {
        NativeCalls.godot_icall_1_56(MethodBind40, GodotObject.GetPtr(this), GodotObject.GetPtr(gizmo));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGizmos, 3995934104ul);

    /// <summary>
    /// <para>Returns all the <c>EditorNode3DGizmo</c> objects attached to this node. Only works in the editor.</para>
    /// </summary>
    public Godot.Collections.Array<Node3DGizmo> GetGizmos()
    {
        return new Godot.Collections.Array<Node3DGizmo>(NativeCalls.godot_icall_0_120(MethodBind41, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearGizmos, 3218959716ul);

    /// <summary>
    /// <para>Clears all <c>EditorNode3DGizmo</c> objects attached to this node. Only works in the editor.</para>
    /// </summary>
    public void ClearGizmos()
    {
        NativeCalls.godot_icall_0_3(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubgizmoSelection, 3317607635ul);

    /// <summary>
    /// <para>Selects the <paramref name="gizmo"/>'s subgizmo with the given <paramref name="id"/> and sets its transform. Only works in the editor.</para>
    /// <para><b>Note:</b> The gizmo object would typically be an instance of <c>EditorNode3DGizmo</c>, but the argument type is kept generic to avoid creating a dependency on editor classes in <see cref="Godot.Node3D"/>.</para>
    /// </summary>
    public unsafe void SetSubgizmoSelection(Node3DGizmo gizmo, int id, Transform3D transform)
    {
        NativeCalls.godot_icall_3_896(MethodBind43, GodotObject.GetPtr(this), GodotObject.GetPtr(gizmo), id, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSubgizmoSelection, 3218959716ul);

    /// <summary>
    /// <para>Deselects all subgizmos for this node. Useful to call when the selected subgizmo may no longer exist after a property change. Only works in the editor.</para>
    /// </summary>
    public void ClearSubgizmoSelection()
    {
        NativeCalls.godot_icall_0_3(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind45, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisibleInTree, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this node is inside the scene tree and the <see cref="Godot.Node3D.Visible"/> property is <see langword="true"/> for this node and all of its <see cref="Godot.Node3D"/> ancestors <i>in sequence</i>. An ancestor of any other type (such as <see cref="Godot.Node"/> or <see cref="Godot.Node2D"/>) breaks the sequence. See also <see cref="Godot.Node.GetParent()"/>.</para>
    /// <para><b>Note:</b> This method cannot take <see cref="Godot.VisualInstance3D.Layers"/> into account, so even if this method returns <see langword="true"/>, the node may not be rendered.</para>
    /// </summary>
    public bool IsVisibleInTree()
    {
        return NativeCalls.godot_icall_0_15(MethodBind47, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Show, 3218959716ul);

    /// <summary>
    /// <para>Allows this node to be rendered. Equivalent to setting <see cref="Godot.Node3D.Visible"/> to <see langword="true"/>. This is the opposite of <see cref="Godot.Node3D.Hide()"/>.</para>
    /// </summary>
    public void Show()
    {
        NativeCalls.godot_icall_0_3(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Hide, 3218959716ul);

    /// <summary>
    /// <para>Prevents this node from being rendered. Equivalent to setting <see cref="Godot.Node3D.Visible"/> to <see langword="false"/>. This is the opposite of <see cref="Godot.Node3D.Show()"/>.</para>
    /// </summary>
    public void Hide()
    {
        NativeCalls.godot_icall_0_3(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNotifyLocalTransform, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the node will receive <see cref="Godot.Node3D.NotificationLocalTransformChanged"/> whenever <see cref="Godot.Node3D.Transform"/> changes.</para>
    /// <para><b>Note:</b> Some 3D nodes such as <see cref="Godot.CsgShape3D"/> or <see cref="Godot.CollisionShape3D"/> automatically enable this to function correctly.</para>
    /// </summary>
    public void SetNotifyLocalTransform(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind50, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLocalTransformNotificationEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node receives <see cref="Godot.Node3D.NotificationLocalTransformChanged"/> whenever <see cref="Godot.Node3D.Transform"/> changes. This is enabled with <see cref="Godot.Node3D.SetNotifyLocalTransform(bool)"/>.</para>
    /// </summary>
    public bool IsLocalTransformNotificationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind51, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNotifyTransform, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the node will receive <see cref="Godot.Node3D.NotificationTransformChanged"/> whenever <see cref="Godot.Node3D.GlobalTransform"/> changes.</para>
    /// <para><b>Note:</b> Most 3D nodes such as <see cref="Godot.VisualInstance3D"/> or <see cref="Godot.CollisionObject3D"/> automatically enable this to function correctly.</para>
    /// <para><b>Note:</b> In the editor, nodes will propagate this notification to their children if a gizmo is attached (see <see cref="Godot.Node3D.AddGizmo(Node3DGizmo)"/>).</para>
    /// </summary>
    public void SetNotifyTransform(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind52, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTransformNotificationEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node receives <see cref="Godot.Node3D.NotificationTransformChanged"/> whenever <see cref="Godot.Node3D.GlobalTransform"/> changes. This is enabled with <see cref="Godot.Node3D.SetNotifyTransform(bool)"/>.</para>
    /// </summary>
    public bool IsTransformNotificationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind53, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Rotate, 3436291937ul);

    /// <summary>
    /// <para>Rotates this node's <see cref="Godot.Node3D.Basis"/> around the <paramref name="axis"/> by the given <paramref name="angle"/>, in radians. This operation is calculated in parent space (relative to the parent) and preserves the <see cref="Godot.Node3D.Position"/>.</para>
    /// </summary>
    public unsafe void Rotate(Vector3 axis, float angle)
    {
        NativeCalls.godot_icall_2_897(MethodBind54, GodotObject.GetPtr(this), &axis, angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalRotate, 3436291937ul);

    /// <summary>
    /// <para>Rotates this node's <see cref="Godot.Node3D.GlobalBasis"/> around the global <paramref name="axis"/> by the given <paramref name="angle"/>, in radians. This operation is calculated in global space (relative to the world) and preserves the <see cref="Godot.Node3D.GlobalPosition"/>.</para>
    /// </summary>
    public unsafe void GlobalRotate(Vector3 axis, float angle)
    {
        NativeCalls.godot_icall_2_897(MethodBind55, GodotObject.GetPtr(this), &axis, angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalScale, 3460891852ul);

    /// <summary>
    /// <para>Scales this node's <see cref="Godot.Node3D.GlobalBasis"/> by the given <paramref name="scale"/> factor. This operation is calculated in global space (relative to the world) and preserves the <see cref="Godot.Node3D.GlobalPosition"/>.</para>
    /// <para><b>Note:</b> This method is not to be confused with the <see cref="Godot.Node3D.Scale"/> property.</para>
    /// </summary>
    public unsafe void GlobalScale(Vector3 scale)
    {
        NativeCalls.godot_icall_1_177(MethodBind56, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalTranslate, 3460891852ul);

    /// <summary>
    /// <para>Adds the given translation <paramref name="offset"/> to the node's <see cref="Godot.Node3D.GlobalPosition"/> in global space (relative to the world).</para>
    /// </summary>
    public unsafe void GlobalTranslate(Vector3 offset)
    {
        NativeCalls.godot_icall_1_177(MethodBind57, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RotateObjectLocal, 3436291937ul);

    /// <summary>
    /// <para>Rotates this node's <see cref="Godot.Node3D.Basis"/> around the <paramref name="axis"/> by the given <paramref name="angle"/>, in radians. This operation is calculated in local space (relative to this node) and preserves the <see cref="Godot.Node3D.Position"/>.</para>
    /// </summary>
    public unsafe void RotateObjectLocal(Vector3 axis, float angle)
    {
        NativeCalls.godot_icall_2_897(MethodBind58, GodotObject.GetPtr(this), &axis, angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScaleObjectLocal, 3460891852ul);

    /// <summary>
    /// <para>Scales this node's <see cref="Godot.Node3D.Basis"/> by the given <paramref name="scale"/> factor. This operation is calculated in local space (relative to this node) and preserves the <see cref="Godot.Node3D.Position"/>.</para>
    /// </summary>
    public unsafe void ScaleObjectLocal(Vector3 scale)
    {
        NativeCalls.godot_icall_1_177(MethodBind59, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TranslateObjectLocal, 3460891852ul);

    /// <summary>
    /// <para>Adds the given translation <paramref name="offset"/> to the node's position, in local space (relative to this node).</para>
    /// </summary>
    public unsafe void TranslateObjectLocal(Vector3 offset)
    {
        NativeCalls.godot_icall_1_177(MethodBind60, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RotateX, 373806689ul);

    /// <summary>
    /// <para>Rotates this node's <see cref="Godot.Node3D.Basis"/> around the X axis by the given <paramref name="angle"/>, in radians. This operation is calculated in parent space (relative to the parent) and preserves the <see cref="Godot.Node3D.Position"/>.</para>
    /// </summary>
    public void RotateX(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind61, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RotateY, 373806689ul);

    /// <summary>
    /// <para>Rotates this node's <see cref="Godot.Node3D.Basis"/> around the Y axis by the given <paramref name="angle"/>, in radians. This operation is calculated in parent space (relative to the parent) and preserves the <see cref="Godot.Node3D.Position"/>.</para>
    /// </summary>
    public void RotateY(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind62, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RotateZ, 373806689ul);

    /// <summary>
    /// <para>Rotates this node's <see cref="Godot.Node3D.Basis"/> around the Z axis by the given <paramref name="angle"/>, in radians. This operation is calculated in parent space (relative to the parent) and preserves the <see cref="Godot.Node3D.Position"/>.</para>
    /// </summary>
    public void RotateZ(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind63, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Translate, 3460891852ul);

    /// <summary>
    /// <para>Adds the given translation <paramref name="offset"/> to the node's position, in local space (relative to this node).</para>
    /// <para><b>Note:</b> Prefer using <see cref="Godot.Node3D.TranslateObjectLocal(Vector3)"/>, instead, as this method may be changed in a future release.</para>
    /// <para><b>Note:</b> Despite the naming convention, this operation is <b>not</b> calculated in parent space for compatibility reasons. To translate in parent space, add <paramref name="offset"/> to the <see cref="Godot.Node3D.Position"/> (<c>node_3d.position += offset</c>).</para>
    /// </summary>
    public unsafe void Translate(Vector3 offset)
    {
        NativeCalls.godot_icall_1_177(MethodBind64, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Orthonormalize, 3218959716ul);

    /// <summary>
    /// <para>Orthonormalizes this node's <see cref="Godot.Node3D.Basis"/>. This method sets this node's <see cref="Godot.Node3D.Scale"/> to <c>Vector3.ONE</c> (or its negative counterpart), but preserves the <see cref="Godot.Node3D.Position"/> and <see cref="Godot.Node3D.Rotation"/>. See also <c>Transform3D.orthonormalized</c>.</para>
    /// </summary>
    public void Orthonormalize()
    {
        NativeCalls.godot_icall_0_3(MethodBind65, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIdentity, 3218959716ul);

    /// <summary>
    /// <para>Sets this node's <see cref="Godot.Node3D.Transform"/> to <c>Transform3D.IDENTITY</c>, which resets all transformations in parent space (<see cref="Godot.Node3D.Position"/>, <see cref="Godot.Node3D.Rotation"/>, and <see cref="Godot.Node3D.Scale"/>).</para>
    /// </summary>
    public void SetIdentity()
    {
        NativeCalls.godot_icall_0_3(MethodBind66, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LookAt, 2882425029ul);

    /// <summary>
    /// <para>Rotates the node so that the local forward axis (-Z, <c>Vector3.FORWARD</c>) points toward the <paramref name="target"/> position. This operation is calculated in global space (relative to the world).</para>
    /// <para>The local up axis (+Y) points as close to the <paramref name="up"/> vector as possible while staying perpendicular to the local forward axis. The resulting transform is orthogonal, and the scale is preserved. Non-uniform scaling may not work correctly.</para>
    /// <para>The <paramref name="target"/> position cannot be the same as the node's position, the <paramref name="up"/> vector cannot be <c>Vector3.ZERO</c>. Furthermore, the direction from the node's position to the <paramref name="target"/> position cannot be parallel to the <paramref name="up"/> vector, to avoid an unintended rotation around the local Z axis.</para>
    /// <para>If <paramref name="useModelFront"/> is <see langword="true"/>, the +Z axis (asset front) is treated as forward (implies +X is left) and points toward the <paramref name="target"/> position. By default, the -Z axis (camera forward) is treated as forward (implies +X is right).</para>
    /// <para><b>Note:</b> This method fails if the node is not in the scene tree. If necessary, use <see cref="Godot.Node3D.LookAtFromPosition(Vector3, Vector3, Nullable{Vector3}, bool)"/> instead.</para>
    /// </summary>
    /// <param name="up">If the parameter is null, then the default value is <c>new Vector3(0.0f, 1.0f, 0.0f)</c>.</param>
    public unsafe void LookAt(Vector3 target, Nullable<Vector3> up = null, bool useModelFront = false)
    {
        Vector3 upOrDefVal = up.HasValue ? up.Value : new Vector3(0.0f, 1.0f, 0.0f);
        NativeCalls.godot_icall_3_898(MethodBind67, GodotObject.GetPtr(this), &target, &upOrDefVal, useModelFront.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LookAtFromPosition, 2086826090ul);

    /// <summary>
    /// <para>Moves the node to the specified <paramref name="position"/>, then rotates the node to point toward the <paramref name="target"/> position, similar to <see cref="Godot.Node3D.LookAt(Vector3, Nullable{Vector3}, bool)"/>. This operation is calculated in global space (relative to the world).</para>
    /// </summary>
    /// <param name="up">If the parameter is null, then the default value is <c>new Vector3(0.0f, 1.0f, 0.0f)</c>.</param>
    public unsafe void LookAtFromPosition(Vector3 position, Vector3 target, Nullable<Vector3> up = null, bool useModelFront = false)
    {
        Vector3 upOrDefVal = up.HasValue ? up.Value : new Vector3(0.0f, 1.0f, 0.0f);
        NativeCalls.godot_icall_4_899(MethodBind68, GodotObject.GetPtr(this), &position, &target, &upOrDefVal, useModelFront.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToLocal, 192990374ul);

    /// <summary>
    /// <para>Returns the <paramref name="globalPoint"/> converted from global space to this node's local space. This is the opposite of <see cref="Godot.Node3D.ToGlobal(Vector3)"/>.</para>
    /// </summary>
    public unsafe Vector3 ToLocal(Vector3 globalPoint)
    {
        return NativeCalls.godot_icall_1_29(MethodBind69, GodotObject.GetPtr(this), &globalPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToGlobal, 192990374ul);

    /// <summary>
    /// <para>Returns the <paramref name="localPoint"/> converted from this node's local space to global space. This is the opposite of <see cref="Godot.Node3D.ToLocal(Vector3)"/>.</para>
    /// </summary>
    public unsafe Vector3 ToGlobal(Vector3 localPoint)
    {
        return NativeCalls.godot_icall_1_29(MethodBind70, GodotObject.GetPtr(this), &localPoint);
    }

    /// <summary>
    /// <para>Emitted when this node's visibility changes (see <see cref="Godot.Node3D.Visible"/> and <see cref="Godot.Node3D.IsVisibleInTree()"/>).</para>
    /// <para>This signal is emitted <i>after</i> the related <see cref="Godot.Node3D.NotificationVisibilityChanged"/> notification.</para>
    /// </summary>
    public event Action VisibilityChanged
    {
        add => Connect(SignalName.VisibilityChanged, Callable.From(value));
        remove => Disconnect(SignalName.VisibilityChanged, Callable.From(value));
    }

    protected void EmitSignalVisibilityChanged()
    {
        EmitSignal(SignalName.VisibilityChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_visibility_changed = "VisibilityChanged";

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
        if (signal == SignalName.VisibilityChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_visibility_changed.NativeValue.DangerousSelfRef))
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
        /// <summary>
        /// Cached name for the 'transform' property.
        /// </summary>
        public static readonly StringName Transform = "transform";
        /// <summary>
        /// Cached name for the 'global_transform' property.
        /// </summary>
        public static readonly StringName GlobalTransform = "global_transform";
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'rotation' property.
        /// </summary>
        public static readonly StringName Rotation = "rotation";
        /// <summary>
        /// Cached name for the 'rotation_degrees' property.
        /// </summary>
        public static readonly StringName RotationDegrees = "rotation_degrees";
        /// <summary>
        /// Cached name for the 'quaternion' property.
        /// </summary>
        public static readonly StringName Quaternion = "quaternion";
        /// <summary>
        /// Cached name for the 'basis' property.
        /// </summary>
        public static readonly StringName Basis = "basis";
        /// <summary>
        /// Cached name for the 'scale' property.
        /// </summary>
        public static readonly StringName Scale = "scale";
        /// <summary>
        /// Cached name for the 'rotation_edit_mode' property.
        /// </summary>
        public static readonly StringName RotationEditMode = "rotation_edit_mode";
        /// <summary>
        /// Cached name for the 'rotation_order' property.
        /// </summary>
        public static readonly StringName RotationOrder = "rotation_order";
        /// <summary>
        /// Cached name for the 'top_level' property.
        /// </summary>
        public static readonly StringName TopLevel = "top_level";
        /// <summary>
        /// Cached name for the 'global_position' property.
        /// </summary>
        public static readonly StringName GlobalPosition = "global_position";
        /// <summary>
        /// Cached name for the 'global_basis' property.
        /// </summary>
        public static readonly StringName GlobalBasis = "global_basis";
        /// <summary>
        /// Cached name for the 'global_rotation' property.
        /// </summary>
        public static readonly StringName GlobalRotation = "global_rotation";
        /// <summary>
        /// Cached name for the 'global_rotation_degrees' property.
        /// </summary>
        public static readonly StringName GlobalRotationDegrees = "global_rotation_degrees";
        /// <summary>
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
        /// <summary>
        /// Cached name for the 'visibility_parent' property.
        /// </summary>
        public static readonly StringName VisibilityParent = "visibility_parent";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'set_rotation' method.
        /// </summary>
        public static readonly StringName SetRotation = "set_rotation";
        /// <summary>
        /// Cached name for the 'get_rotation' method.
        /// </summary>
        public static readonly StringName GetRotation = "get_rotation";
        /// <summary>
        /// Cached name for the 'set_rotation_degrees' method.
        /// </summary>
        public static readonly StringName SetRotationDegrees = "set_rotation_degrees";
        /// <summary>
        /// Cached name for the 'get_rotation_degrees' method.
        /// </summary>
        public static readonly StringName GetRotationDegrees = "get_rotation_degrees";
        /// <summary>
        /// Cached name for the 'set_rotation_order' method.
        /// </summary>
        public static readonly StringName SetRotationOrder = "set_rotation_order";
        /// <summary>
        /// Cached name for the 'get_rotation_order' method.
        /// </summary>
        public static readonly StringName GetRotationOrder = "get_rotation_order";
        /// <summary>
        /// Cached name for the 'set_rotation_edit_mode' method.
        /// </summary>
        public static readonly StringName SetRotationEditMode = "set_rotation_edit_mode";
        /// <summary>
        /// Cached name for the 'get_rotation_edit_mode' method.
        /// </summary>
        public static readonly StringName GetRotationEditMode = "get_rotation_edit_mode";
        /// <summary>
        /// Cached name for the 'set_scale' method.
        /// </summary>
        public static readonly StringName SetScale = "set_scale";
        /// <summary>
        /// Cached name for the 'get_scale' method.
        /// </summary>
        public static readonly StringName GetScale = "get_scale";
        /// <summary>
        /// Cached name for the 'set_quaternion' method.
        /// </summary>
        public static readonly StringName SetQuaternion = "set_quaternion";
        /// <summary>
        /// Cached name for the 'get_quaternion' method.
        /// </summary>
        public static readonly StringName GetQuaternion = "get_quaternion";
        /// <summary>
        /// Cached name for the 'set_basis' method.
        /// </summary>
        public static readonly StringName SetBasis = "set_basis";
        /// <summary>
        /// Cached name for the 'get_basis' method.
        /// </summary>
        public static readonly StringName GetBasis = "get_basis";
        /// <summary>
        /// Cached name for the 'set_global_transform' method.
        /// </summary>
        public static readonly StringName SetGlobalTransform = "set_global_transform";
        /// <summary>
        /// Cached name for the 'get_global_transform' method.
        /// </summary>
        public static readonly StringName GetGlobalTransform = "get_global_transform";
        /// <summary>
        /// Cached name for the 'get_global_transform_interpolated' method.
        /// </summary>
        public static readonly StringName GetGlobalTransformInterpolated = "get_global_transform_interpolated";
        /// <summary>
        /// Cached name for the 'set_global_position' method.
        /// </summary>
        public static readonly StringName SetGlobalPosition = "set_global_position";
        /// <summary>
        /// Cached name for the 'get_global_position' method.
        /// </summary>
        public static readonly StringName GetGlobalPosition = "get_global_position";
        /// <summary>
        /// Cached name for the 'set_global_basis' method.
        /// </summary>
        public static readonly StringName SetGlobalBasis = "set_global_basis";
        /// <summary>
        /// Cached name for the 'get_global_basis' method.
        /// </summary>
        public static readonly StringName GetGlobalBasis = "get_global_basis";
        /// <summary>
        /// Cached name for the 'set_global_rotation' method.
        /// </summary>
        public static readonly StringName SetGlobalRotation = "set_global_rotation";
        /// <summary>
        /// Cached name for the 'get_global_rotation' method.
        /// </summary>
        public static readonly StringName GetGlobalRotation = "get_global_rotation";
        /// <summary>
        /// Cached name for the 'set_global_rotation_degrees' method.
        /// </summary>
        public static readonly StringName SetGlobalRotationDegrees = "set_global_rotation_degrees";
        /// <summary>
        /// Cached name for the 'get_global_rotation_degrees' method.
        /// </summary>
        public static readonly StringName GetGlobalRotationDegrees = "get_global_rotation_degrees";
        /// <summary>
        /// Cached name for the 'get_parent_node_3d' method.
        /// </summary>
        public static readonly StringName GetParentNode3D = "get_parent_node_3d";
        /// <summary>
        /// Cached name for the 'set_ignore_transform_notification' method.
        /// </summary>
        public static readonly StringName SetIgnoreTransformNotification = "set_ignore_transform_notification";
        /// <summary>
        /// Cached name for the 'set_as_top_level' method.
        /// </summary>
        public static readonly StringName SetAsTopLevel = "set_as_top_level";
        /// <summary>
        /// Cached name for the 'is_set_as_top_level' method.
        /// </summary>
        public static readonly StringName IsSetAsTopLevel = "is_set_as_top_level";
        /// <summary>
        /// Cached name for the 'set_disable_scale' method.
        /// </summary>
        public static readonly StringName SetDisableScale = "set_disable_scale";
        /// <summary>
        /// Cached name for the 'is_scale_disabled' method.
        /// </summary>
        public static readonly StringName IsScaleDisabled = "is_scale_disabled";
        /// <summary>
        /// Cached name for the 'get_world_3d' method.
        /// </summary>
        public static readonly StringName GetWorld3D = "get_world_3d";
        /// <summary>
        /// Cached name for the 'force_update_transform' method.
        /// </summary>
        public static readonly StringName ForceUpdateTransform = "force_update_transform";
        /// <summary>
        /// Cached name for the 'set_visibility_parent' method.
        /// </summary>
        public static readonly StringName SetVisibilityParent = "set_visibility_parent";
        /// <summary>
        /// Cached name for the 'get_visibility_parent' method.
        /// </summary>
        public static readonly StringName GetVisibilityParent = "get_visibility_parent";
        /// <summary>
        /// Cached name for the 'update_gizmos' method.
        /// </summary>
        public static readonly StringName UpdateGizmos = "update_gizmos";
        /// <summary>
        /// Cached name for the 'add_gizmo' method.
        /// </summary>
        public static readonly StringName AddGizmo = "add_gizmo";
        /// <summary>
        /// Cached name for the 'get_gizmos' method.
        /// </summary>
        public static readonly StringName GetGizmos = "get_gizmos";
        /// <summary>
        /// Cached name for the 'clear_gizmos' method.
        /// </summary>
        public static readonly StringName ClearGizmos = "clear_gizmos";
        /// <summary>
        /// Cached name for the 'set_subgizmo_selection' method.
        /// </summary>
        public static readonly StringName SetSubgizmoSelection = "set_subgizmo_selection";
        /// <summary>
        /// Cached name for the 'clear_subgizmo_selection' method.
        /// </summary>
        public static readonly StringName ClearSubgizmoSelection = "clear_subgizmo_selection";
        /// <summary>
        /// Cached name for the 'set_visible' method.
        /// </summary>
        public static readonly StringName SetVisible = "set_visible";
        /// <summary>
        /// Cached name for the 'is_visible' method.
        /// </summary>
        public static readonly StringName IsVisible = "is_visible";
        /// <summary>
        /// Cached name for the 'is_visible_in_tree' method.
        /// </summary>
        public static readonly StringName IsVisibleInTree = "is_visible_in_tree";
        /// <summary>
        /// Cached name for the 'show' method.
        /// </summary>
        public static readonly StringName Show = "show";
        /// <summary>
        /// Cached name for the 'hide' method.
        /// </summary>
        public static readonly StringName Hide = "hide";
        /// <summary>
        /// Cached name for the 'set_notify_local_transform' method.
        /// </summary>
        public static readonly StringName SetNotifyLocalTransform = "set_notify_local_transform";
        /// <summary>
        /// Cached name for the 'is_local_transform_notification_enabled' method.
        /// </summary>
        public static readonly StringName IsLocalTransformNotificationEnabled = "is_local_transform_notification_enabled";
        /// <summary>
        /// Cached name for the 'set_notify_transform' method.
        /// </summary>
        public static readonly StringName SetNotifyTransform = "set_notify_transform";
        /// <summary>
        /// Cached name for the 'is_transform_notification_enabled' method.
        /// </summary>
        public static readonly StringName IsTransformNotificationEnabled = "is_transform_notification_enabled";
        /// <summary>
        /// Cached name for the 'rotate' method.
        /// </summary>
        public static readonly StringName Rotate = "rotate";
        /// <summary>
        /// Cached name for the 'global_rotate' method.
        /// </summary>
        public static readonly StringName GlobalRotate = "global_rotate";
        /// <summary>
        /// Cached name for the 'global_scale' method.
        /// </summary>
        public static readonly StringName GlobalScale = "global_scale";
        /// <summary>
        /// Cached name for the 'global_translate' method.
        /// </summary>
        public static readonly StringName GlobalTranslate = "global_translate";
        /// <summary>
        /// Cached name for the 'rotate_object_local' method.
        /// </summary>
        public static readonly StringName RotateObjectLocal = "rotate_object_local";
        /// <summary>
        /// Cached name for the 'scale_object_local' method.
        /// </summary>
        public static readonly StringName ScaleObjectLocal = "scale_object_local";
        /// <summary>
        /// Cached name for the 'translate_object_local' method.
        /// </summary>
        public static readonly StringName TranslateObjectLocal = "translate_object_local";
        /// <summary>
        /// Cached name for the 'rotate_x' method.
        /// </summary>
        public static readonly StringName RotateX = "rotate_x";
        /// <summary>
        /// Cached name for the 'rotate_y' method.
        /// </summary>
        public static readonly StringName RotateY = "rotate_y";
        /// <summary>
        /// Cached name for the 'rotate_z' method.
        /// </summary>
        public static readonly StringName RotateZ = "rotate_z";
        /// <summary>
        /// Cached name for the 'translate' method.
        /// </summary>
        public static readonly StringName Translate = "translate";
        /// <summary>
        /// Cached name for the 'orthonormalize' method.
        /// </summary>
        public static readonly StringName Orthonormalize = "orthonormalize";
        /// <summary>
        /// Cached name for the 'set_identity' method.
        /// </summary>
        public static readonly StringName SetIdentity = "set_identity";
        /// <summary>
        /// Cached name for the 'look_at' method.
        /// </summary>
        public static readonly StringName LookAt = "look_at";
        /// <summary>
        /// Cached name for the 'look_at_from_position' method.
        /// </summary>
        public static readonly StringName LookAtFromPosition = "look_at_from_position";
        /// <summary>
        /// Cached name for the 'to_local' method.
        /// </summary>
        public static readonly StringName ToLocal = "to_local";
        /// <summary>
        /// Cached name for the 'to_global' method.
        /// </summary>
        public static readonly StringName ToGlobal = "to_global";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'visibility_changed' signal.
        /// </summary>
        public static readonly StringName VisibilityChanged = "visibility_changed";
    }
}
