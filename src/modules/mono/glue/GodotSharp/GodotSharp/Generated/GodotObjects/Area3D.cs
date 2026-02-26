namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Area3D"/> is a region of 3D space defined by one or multiple <see cref="Godot.CollisionShape3D"/> or <see cref="Godot.CollisionPolygon3D"/> child nodes. It detects when other <see cref="Godot.CollisionObject3D"/>s enter or exit it, and it also keeps track of which collision objects haven't exited it yet (i.e. which one are overlapping it).</para>
/// <para>This node can also locally alter or override physics parameters (gravity, damping) and route audio to custom audio buses.</para>
/// <para><b>Note:</b> Areas and bodies created with <see cref="Godot.PhysicsServer3D"/> might not interact as expected with <see cref="Godot.Area3D"/>s, and might not emit signals or track objects correctly.</para>
/// <para><b>Warning:</b> Using a <see cref="Godot.ConcavePolygonShape3D"/> inside a <see cref="Godot.CollisionShape3D"/> child of this node (created e.g. by using the <b>Create Trimesh Collision Sibling</b> option in the <b>Mesh</b> menu that appears when selecting a <see cref="Godot.MeshInstance3D"/> node) may give unexpected results, since this collision shape is hollow. If this is not desired, it has to be split into multiple <see cref="Godot.ConvexPolygonShape3D"/>s or primitive shapes like <see cref="Godot.BoxShape3D"/>, or in some cases it may be replaceable by a <see cref="Godot.CollisionPolygon3D"/>.</para>
/// </summary>
public partial class Area3D : CollisionObject3D
{
    public enum SpaceOverride : long
    {
        /// <summary>
        /// <para>This area does not affect gravity/damping.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>This area adds its gravity/damping values to whatever has been calculated so far (in <see cref="Godot.Area3D.Priority"/> order).</para>
        /// </summary>
        Combine = 1,
        /// <summary>
        /// <para>This area adds its gravity/damping values to whatever has been calculated so far (in <see cref="Godot.Area3D.Priority"/> order), ignoring any lower priority areas.</para>
        /// </summary>
        CombineReplace = 2,
        /// <summary>
        /// <para>This area replaces any gravity/damping, even the defaults, ignoring any lower priority areas.</para>
        /// </summary>
        Replace = 3,
        /// <summary>
        /// <para>This area replaces any gravity/damping calculated so far (in <see cref="Godot.Area3D.Priority"/> order), but keeps calculating the rest of the areas.</para>
        /// </summary>
        ReplaceCombine = 4
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the area detects bodies or areas entering and exiting it.</para>
    /// </summary>
    public bool Monitoring
    {
        get
        {
            return IsMonitoring();
        }
        set
        {
            SetMonitoring(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, other monitoring areas can detect this area.</para>
    /// </summary>
    public bool Monitorable
    {
        get
        {
            return IsMonitorable();
        }
        set
        {
            SetMonitorable(value);
        }
    }

    /// <summary>
    /// <para>The area's priority. Higher priority areas are processed first. The <see cref="Godot.World3D"/>'s physics is always processed last, after all areas.</para>
    /// </summary>
    public int Priority
    {
        get
        {
            return GetPriority();
        }
        set
        {
            SetPriority(value);
        }
    }

    /// <summary>
    /// <para>Override mode for gravity calculations within this area.</para>
    /// </summary>
    public Area3D.SpaceOverride GravitySpaceOverride
    {
        get
        {
            return GetGravitySpaceOverrideMode();
        }
        set
        {
            SetGravitySpaceOverrideMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, gravity is calculated from a point (set via <see cref="Godot.Area3D.GravityPointCenter"/>). See also <see cref="Godot.Area3D.GravitySpaceOverride"/>.</para>
    /// </summary>
    public bool GravityPoint
    {
        get
        {
            return IsGravityAPoint();
        }
        set
        {
            SetGravityIsPoint(value);
        }
    }

    /// <summary>
    /// <para>The distance at which the gravity strength is equal to <see cref="Godot.Area3D.Gravity"/>. For example, on a planet 100 meters in radius with a surface gravity of 4.0 m/s², set the <see cref="Godot.Area3D.Gravity"/> to 4.0 and the unit distance to 100.0. The gravity will have falloff according to the inverse square law, so in the example, at 200 meters from the center the gravity will be 1.0 m/s² (twice the distance, 1/4th the gravity), at 50 meters it will be 16.0 m/s² (half the distance, 4x the gravity), and so on.</para>
    /// <para>The above is true only when the unit distance is a positive number. When this is set to 0.0, the gravity will be constant regardless of distance.</para>
    /// </summary>
    public float GravityPointUnitDistance
    {
        get
        {
            return GetGravityPointUnitDistance();
        }
        set
        {
            SetGravityPointUnitDistance(value);
        }
    }

    /// <summary>
    /// <para>If gravity is a point (see <see cref="Godot.Area3D.GravityPoint"/>), this will be the point of attraction.</para>
    /// </summary>
    public Vector3 GravityPointCenter
    {
        get
        {
            return GetGravityPointCenter();
        }
        set
        {
            SetGravityPointCenter(value);
        }
    }

    /// <summary>
    /// <para>The area's gravity vector (not normalized).</para>
    /// </summary>
    public Vector3 GravityDirection
    {
        get
        {
            return GetGravityDirection();
        }
        set
        {
            SetGravityDirection(value);
        }
    }

    /// <summary>
    /// <para>The area's gravity intensity (in meters per second squared). This value multiplies the gravity direction. This is useful to alter the force of gravity without altering its direction.</para>
    /// </summary>
    public float Gravity
    {
        get
        {
            return GetGravity();
        }
        set
        {
            SetGravity(value);
        }
    }

    /// <summary>
    /// <para>Override mode for linear damping calculations within this area.</para>
    /// </summary>
    public Area3D.SpaceOverride LinearDampSpaceOverride
    {
        get
        {
            return GetLinearDampSpaceOverrideMode();
        }
        set
        {
            SetLinearDampSpaceOverrideMode(value);
        }
    }

    /// <summary>
    /// <para>The rate at which objects stop moving in this area. Represents the linear velocity lost per second.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_linear_damp</c> for more details about damping.</para>
    /// </summary>
    public float LinearDamp
    {
        get
        {
            return GetLinearDamp();
        }
        set
        {
            SetLinearDamp(value);
        }
    }

    /// <summary>
    /// <para>Override mode for angular damping calculations within this area.</para>
    /// </summary>
    public Area3D.SpaceOverride AngularDampSpaceOverride
    {
        get
        {
            return GetAngularDampSpaceOverrideMode();
        }
        set
        {
            SetAngularDampSpaceOverrideMode(value);
        }
    }

    /// <summary>
    /// <para>The rate at which objects stop spinning in this area. Represents the angular velocity lost per second.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_angular_damp</c> for more details about damping.</para>
    /// </summary>
    public float AngularDamp
    {
        get
        {
            return GetAngularDamp();
        }
        set
        {
            SetAngularDamp(value);
        }
    }

    /// <summary>
    /// <para>The magnitude of area-specific wind force.</para>
    /// <para><b>Note:</b> This wind force only applies to <see cref="Godot.SoftBody3D"/> nodes. Other physics bodies are currently not affected by wind.</para>
    /// </summary>
    public float WindForceMagnitude
    {
        get
        {
            return GetWindForceMagnitude();
        }
        set
        {
            SetWindForceMagnitude(value);
        }
    }

    /// <summary>
    /// <para>The exponential rate at which wind force decreases with distance from its origin.</para>
    /// <para><b>Note:</b> This wind force only applies to <see cref="Godot.SoftBody3D"/> nodes. Other physics bodies are currently not affected by wind.</para>
    /// </summary>
    public float WindAttenuationFactor
    {
        get
        {
            return GetWindAttenuationFactor();
        }
        set
        {
            SetWindAttenuationFactor(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Node3D"/> which is used to specify the direction and origin of an area-specific wind force. The direction is opposite to the z-axis of the <see cref="Godot.Node3D"/>'s local transform, and its origin is the origin of the <see cref="Godot.Node3D"/>'s local transform.</para>
    /// <para><b>Note:</b> This wind force only applies to <see cref="Godot.SoftBody3D"/> nodes. Other physics bodies are currently not affected by wind.</para>
    /// </summary>
    public NodePath WindSourcePath
    {
        get
        {
            return GetWindSourcePath();
        }
        set
        {
            SetWindSourcePath(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the area's audio bus overrides the default audio bus.</para>
    /// </summary>
    public bool AudioBusOverride
    {
        get
        {
            return IsOverridingAudioBus();
        }
        set
        {
            SetAudioBusOverride(value);
        }
    }

    /// <summary>
    /// <para>The name of the area's audio bus.</para>
    /// </summary>
    public StringName AudioBusName
    {
        get
        {
            return GetAudioBusName();
        }
        set
        {
            SetAudioBusName(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the area applies reverb to its associated audio.</para>
    /// </summary>
    public bool ReverbBusEnabled
    {
        get
        {
            return IsUsingReverbBus();
        }
        set
        {
            SetUseReverbBus(value);
        }
    }

    /// <summary>
    /// <para>The name of the reverb bus to use for this area's associated audio.</para>
    /// </summary>
    public StringName ReverbBusName
    {
        get
        {
            return GetReverbBusName();
        }
        set
        {
            SetReverbBusName(value);
        }
    }

    /// <summary>
    /// <para>The degree to which this area applies reverb to its associated audio. Ranges from <c>0</c> to <c>1</c> with <c>0.1</c> precision.</para>
    /// </summary>
    public float ReverbBusAmount
    {
        get
        {
            return GetReverbAmount();
        }
        set
        {
            SetReverbAmount(value);
        }
    }

    /// <summary>
    /// <para>The degree to which this area's reverb is a uniform effect. Ranges from <c>0</c> to <c>1</c> with <c>0.1</c> precision.</para>
    /// </summary>
    public float ReverbBusUniformity
    {
        get
        {
            return GetReverbUniformity();
        }
        set
        {
            SetReverbUniformity(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Area3D);

    private static readonly StringName NativeName = "Area3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Area3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Area3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Area3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravitySpaceOverrideMode, 2311433571ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGravitySpaceOverrideMode(Area3D.SpaceOverride spaceOverrideMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)spaceOverrideMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravitySpaceOverrideMode, 958191869ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Area3D.SpaceOverride GetGravitySpaceOverrideMode()
    {
        return (Area3D.SpaceOverride)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityIsPoint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGravityIsPoint(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGravityAPoint, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsGravityAPoint()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityPointUnitDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGravityPointUnitDistance(float distanceScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), distanceScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravityPointUnitDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGravityPointUnitDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityPointCenter, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGravityPointCenter(Vector3 center)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &center);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravityPointCenter, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetGravityPointCenter()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityDirection, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGravityDirection(Vector3 direction)
    {
        NativeCalls.godot_icall_1_177(MethodBind8, GodotObject.GetPtr(this), &direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravityDirection, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetGravityDirection()
    {
        return NativeCalls.godot_icall_0_125(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGravity(float gravity)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), gravity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGravity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearDampSpaceOverrideMode, 2311433571ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinearDampSpaceOverrideMode(Area3D.SpaceOverride spaceOverrideMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)spaceOverrideMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearDampSpaceOverrideMode, 958191869ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Area3D.SpaceOverride GetLinearDampSpaceOverrideMode()
    {
        return (Area3D.SpaceOverride)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularDampSpaceOverrideMode, 2311433571ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularDampSpaceOverrideMode(Area3D.SpaceOverride spaceOverrideMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)spaceOverrideMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularDampSpaceOverrideMode, 958191869ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Area3D.SpaceOverride GetAngularDampSpaceOverrideMode()
    {
        return (Area3D.SpaceOverride)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularDamp, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularDamp(float angularDamp)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), angularDamp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAngularDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearDamp, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinearDamp(float linearDamp)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), linearDamp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLinearDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWindForceMagnitude, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWindForceMagnitude(float windForceMagnitude)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), windForceMagnitude);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindForceMagnitude, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWindForceMagnitude()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWindAttenuationFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWindAttenuationFactor(float windAttenuationFactor)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), windAttenuationFactor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindAttenuationFactor, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWindAttenuationFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWindSourcePath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWindSourcePath(NodePath windSourcePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind26, GodotObject.GetPtr(this), (godot_node_path)(windSourcePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindSourcePath, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetWindSourcePath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMonitorable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMonitorable(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMonitorable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMonitorable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind29, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMonitoring, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMonitoring(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind30, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMonitoring, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMonitoring()
    {
        return NativeCalls.godot_icall_0_15(MethodBind31, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOverlappingBodies, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of intersecting <see cref="Godot.PhysicsBody3D"/>s and <see cref="Godot.GridMap"/>s. The overlapping body's <see cref="Godot.CollisionObject3D.CollisionLayer"/> must be part of this area's <see cref="Godot.CollisionObject3D.CollisionMask"/> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) this list is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    public Godot.Collections.Array<Node3D> GetOverlappingBodies()
    {
        return new Godot.Collections.Array<Node3D>(NativeCalls.godot_icall_0_120(MethodBind32, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOverlappingAreas, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of intersecting <see cref="Godot.Area3D"/>s. The overlapping area's <see cref="Godot.CollisionObject3D.CollisionLayer"/> must be part of this area's <see cref="Godot.CollisionObject3D.CollisionMask"/> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) this list is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    public Godot.Collections.Array<Area3D> GetOverlappingAreas()
    {
        return new Godot.Collections.Array<Area3D>(NativeCalls.godot_icall_0_120(MethodBind33, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasOverlappingBodies, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if intersecting any <see cref="Godot.PhysicsBody3D"/>s or <see cref="Godot.GridMap"/>s, otherwise returns <see langword="false"/>. The overlapping body's <see cref="Godot.CollisionObject3D.CollisionLayer"/> must be part of this area's <see cref="Godot.CollisionObject3D.CollisionMask"/> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) the list of overlapping bodies is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    public bool HasOverlappingBodies()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasOverlappingAreas, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if intersecting any <see cref="Godot.Area3D"/>s, otherwise returns <see langword="false"/>. The overlapping area's <see cref="Godot.CollisionObject3D.CollisionLayer"/> must be part of this area's <see cref="Godot.CollisionObject3D.CollisionMask"/> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) the list of overlapping areas is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    public bool HasOverlappingAreas()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OverlapsBody, 3093956946ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given physics body intersects or overlaps this <see cref="Godot.Area3D"/>, <see langword="false"/> otherwise.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of overlaps is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// <para>The <paramref name="body"/> argument can either be a <see cref="Godot.PhysicsBody3D"/> or a <see cref="Godot.GridMap"/> instance. While GridMaps are not physics body themselves, they register their tiles with collision shapes as a virtual physics body.</para>
    /// </summary>
    public bool OverlapsBody(Node body)
    {
        return NativeCalls.godot_icall_1_176(MethodBind36, GodotObject.GetPtr(this), GodotObject.GetPtr(body)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OverlapsArea, 3093956946ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <see cref="Godot.Area3D"/> intersects or overlaps this <see cref="Godot.Area3D"/>, <see langword="false"/> otherwise.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of overlaps is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// </summary>
    public bool OverlapsArea(Node area)
    {
        return NativeCalls.godot_icall_1_176(MethodBind37, GodotObject.GetPtr(this), GodotObject.GetPtr(area)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAudioBusOverride, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAudioBusOverride(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind38, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOverridingAudioBus, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOverridingAudioBus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind39, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAudioBusName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAudioBusName(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind40, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAudioBusName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetAudioBusName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseReverbBus, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseReverbBus(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind42, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingReverbBus, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingReverbBus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind43, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReverbBusName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReverbBusName(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind44, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReverbBusName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetReverbBusName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReverbAmount, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReverbAmount(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind46, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReverbAmount, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetReverbAmount()
    {
        return NativeCalls.godot_icall_0_68(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReverbUniformity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReverbUniformity(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind48, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReverbUniformity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetReverbUniformity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind49, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.BodyShapeEntered"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void BodyShapeEnteredEventHandler(Rid bodyRid, Node3D body, long bodyShapeIndex, long localShapeIndex);

    private static void BodyShapeEnteredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((BodyShapeEnteredEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Node3D>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a <see cref="Godot.Shape3D"/> of the received <c>body</c> enters a shape of this area. <c>body</c> can be a <see cref="Godot.PhysicsBody3D"/> or a <see cref="Godot.GridMap"/>. <see cref="Godot.GridMap"/>s are detected if their <see cref="Godot.MeshLibrary"/> has collision shapes configured. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// <para><c>localShapeIndex</c> and <c>bodyShapeIndex</c> contain indices of the interacting shapes from this area and the interacting body, respectively. <c>bodyRid</c> contains the <see cref="Godot.Rid"/> of the body. These values can be used with the <see cref="Godot.PhysicsServer3D"/>.</para>
    /// <para><b>Example:</b> Get the <see cref="Godot.CollisionShape3D"/> node from the shape index:</para>
    /// <para></para>
    /// </summary>
    public unsafe event BodyShapeEnteredEventHandler BodyShapeEntered
    {
        add => Connect(SignalName.BodyShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeEnteredTrampoline));
        remove => Disconnect(SignalName.BodyShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeEnteredTrampoline));
    }

    protected void EmitSignalBodyShapeEntered(Rid bodyRid, Node3D body, long bodyShapeIndex, long localShapeIndex)
    {
        EmitSignal(SignalName.BodyShapeEntered, bodyRid, body, bodyShapeIndex, localShapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.BodyShapeExited"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void BodyShapeExitedEventHandler(Rid bodyRid, Node3D body, long bodyShapeIndex, long localShapeIndex);

    private static void BodyShapeExitedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((BodyShapeExitedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Node3D>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a <see cref="Godot.Shape3D"/> of the received <c>body</c> exits a shape of this area. <c>body</c> can be a <see cref="Godot.PhysicsBody3D"/> or a <see cref="Godot.GridMap"/>. <see cref="Godot.GridMap"/>s are detected if their <see cref="Godot.MeshLibrary"/> has collision shapes configured. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// <para>See also <see cref="Godot.Area3D.BodyShapeEntered"/>.</para>
    /// </summary>
    public unsafe event BodyShapeExitedEventHandler BodyShapeExited
    {
        add => Connect(SignalName.BodyShapeExited, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeExitedTrampoline));
        remove => Disconnect(SignalName.BodyShapeExited, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeExitedTrampoline));
    }

    protected void EmitSignalBodyShapeExited(Rid bodyRid, Node3D body, long bodyShapeIndex, long localShapeIndex)
    {
        EmitSignal(SignalName.BodyShapeExited, bodyRid, body, bodyShapeIndex, localShapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.BodyEntered"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void BodyEnteredEventHandler(Node3D body);

    private static void BodyEnteredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((BodyEnteredEventHandler)delegateObj)(VariantUtils.ConvertTo<Node3D>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the received <c>body</c> enters this area. <c>body</c> can be a <see cref="Godot.PhysicsBody3D"/> or a <see cref="Godot.GridMap"/>. <see cref="Godot.GridMap"/>s are detected if their <see cref="Godot.MeshLibrary"/> has collision shapes configured. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// </summary>
    public unsafe event BodyEnteredEventHandler BodyEntered
    {
        add => Connect(SignalName.BodyEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyEnteredTrampoline));
        remove => Disconnect(SignalName.BodyEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyEnteredTrampoline));
    }

    protected void EmitSignalBodyEntered(Node3D body)
    {
        EmitSignal(SignalName.BodyEntered, body);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.BodyExited"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void BodyExitedEventHandler(Node3D body);

    private static void BodyExitedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((BodyExitedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node3D>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the received <c>body</c> exits this area. <c>body</c> can be a <see cref="Godot.PhysicsBody3D"/> or a <see cref="Godot.GridMap"/>. <see cref="Godot.GridMap"/>s are detected if their <see cref="Godot.MeshLibrary"/> has collision shapes configured. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// </summary>
    public unsafe event BodyExitedEventHandler BodyExited
    {
        add => Connect(SignalName.BodyExited, Callable.CreateWithUnsafeTrampoline(value, &BodyExitedTrampoline));
        remove => Disconnect(SignalName.BodyExited, Callable.CreateWithUnsafeTrampoline(value, &BodyExitedTrampoline));
    }

    protected void EmitSignalBodyExited(Node3D body)
    {
        EmitSignal(SignalName.BodyExited, body);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.AreaShapeEntered"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void AreaShapeEnteredEventHandler(Rid areaRid, Area3D area, long areaShapeIndex, long localShapeIndex);

    private static void AreaShapeEnteredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((AreaShapeEnteredEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Area3D>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a <see cref="Godot.Shape3D"/> of the received <c>area</c> enters a shape of this area. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// <para><c>localShapeIndex</c> and <c>areaShapeIndex</c> contain indices of the interacting shapes from this area and the other area, respectively. <c>areaRid</c> contains the <see cref="Godot.Rid"/> of the other area. These values can be used with the <see cref="Godot.PhysicsServer3D"/>.</para>
    /// <para><b>Example:</b> Get the <see cref="Godot.CollisionShape3D"/> node from the shape index:</para>
    /// <para></para>
    /// </summary>
    public unsafe event AreaShapeEnteredEventHandler AreaShapeEntered
    {
        add => Connect(SignalName.AreaShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &AreaShapeEnteredTrampoline));
        remove => Disconnect(SignalName.AreaShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &AreaShapeEnteredTrampoline));
    }

    protected void EmitSignalAreaShapeEntered(Rid areaRid, Area3D area, long areaShapeIndex, long localShapeIndex)
    {
        EmitSignal(SignalName.AreaShapeEntered, areaRid, area, areaShapeIndex, localShapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.AreaShapeExited"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void AreaShapeExitedEventHandler(Rid areaRid, Area3D area, long areaShapeIndex, long localShapeIndex);

    private static void AreaShapeExitedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((AreaShapeExitedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Area3D>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a <see cref="Godot.Shape3D"/> of the received <c>area</c> exits a shape of this area. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// <para>See also <see cref="Godot.Area3D.AreaShapeEntered"/>.</para>
    /// </summary>
    public unsafe event AreaShapeExitedEventHandler AreaShapeExited
    {
        add => Connect(SignalName.AreaShapeExited, Callable.CreateWithUnsafeTrampoline(value, &AreaShapeExitedTrampoline));
        remove => Disconnect(SignalName.AreaShapeExited, Callable.CreateWithUnsafeTrampoline(value, &AreaShapeExitedTrampoline));
    }

    protected void EmitSignalAreaShapeExited(Rid areaRid, Area3D area, long areaShapeIndex, long localShapeIndex)
    {
        EmitSignal(SignalName.AreaShapeExited, areaRid, area, areaShapeIndex, localShapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.AreaEntered"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void AreaEnteredEventHandler(Area3D area);

    private static void AreaEnteredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((AreaEnteredEventHandler)delegateObj)(VariantUtils.ConvertTo<Area3D>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the received <c>area</c> enters this area. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// </summary>
    public unsafe event AreaEnteredEventHandler AreaEntered
    {
        add => Connect(SignalName.AreaEntered, Callable.CreateWithUnsafeTrampoline(value, &AreaEnteredTrampoline));
        remove => Disconnect(SignalName.AreaEntered, Callable.CreateWithUnsafeTrampoline(value, &AreaEnteredTrampoline));
    }

    protected void EmitSignalAreaEntered(Area3D area)
    {
        EmitSignal(SignalName.AreaEntered, area);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Area3D.AreaExited"/> event of a <see cref="Godot.Area3D"/> class.
    /// </summary>
    public delegate void AreaExitedEventHandler(Area3D area);

    private static void AreaExitedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((AreaExitedEventHandler)delegateObj)(VariantUtils.ConvertTo<Area3D>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the received <c>area</c> exits this area. Requires <see cref="Godot.Area3D.Monitoring"/> to be set to <see langword="true"/>.</para>
    /// </summary>
    public unsafe event AreaExitedEventHandler AreaExited
    {
        add => Connect(SignalName.AreaExited, Callable.CreateWithUnsafeTrampoline(value, &AreaExitedTrampoline));
        remove => Disconnect(SignalName.AreaExited, Callable.CreateWithUnsafeTrampoline(value, &AreaExitedTrampoline));
    }

    protected void EmitSignalAreaExited(Area3D area)
    {
        EmitSignal(SignalName.AreaExited, area);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_shape_entered = "BodyShapeEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_shape_exited = "BodyShapeExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_entered = "BodyEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_exited = "BodyExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_area_shape_entered = "AreaShapeEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_area_shape_exited = "AreaShapeExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_area_entered = "AreaEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_area_exited = "AreaExited";

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
        if (signal == SignalName.BodyShapeEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_body_shape_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BodyShapeExited)
        {
            if (HasGodotClassSignal(SignalProxyName_body_shape_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BodyEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_body_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BodyExited)
        {
            if (HasGodotClassSignal(SignalProxyName_body_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AreaShapeEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_area_shape_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AreaShapeExited)
        {
            if (HasGodotClassSignal(SignalProxyName_area_shape_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AreaEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_area_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AreaExited)
        {
            if (HasGodotClassSignal(SignalProxyName_area_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : CollisionObject3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'monitoring' property.
        /// </summary>
        public static readonly StringName Monitoring = "monitoring";
        /// <summary>
        /// Cached name for the 'monitorable' property.
        /// </summary>
        public static readonly StringName Monitorable = "monitorable";
        /// <summary>
        /// Cached name for the 'priority' property.
        /// </summary>
        public static readonly StringName Priority = "priority";
        /// <summary>
        /// Cached name for the 'gravity_space_override' property.
        /// </summary>
        public static readonly StringName GravitySpaceOverride = "gravity_space_override";
        /// <summary>
        /// Cached name for the 'gravity_point' property.
        /// </summary>
        public static readonly StringName GravityPoint = "gravity_point";
        /// <summary>
        /// Cached name for the 'gravity_point_unit_distance' property.
        /// </summary>
        public static readonly StringName GravityPointUnitDistance = "gravity_point_unit_distance";
        /// <summary>
        /// Cached name for the 'gravity_point_center' property.
        /// </summary>
        public static readonly StringName GravityPointCenter = "gravity_point_center";
        /// <summary>
        /// Cached name for the 'gravity_direction' property.
        /// </summary>
        public static readonly StringName GravityDirection = "gravity_direction";
        /// <summary>
        /// Cached name for the 'gravity' property.
        /// </summary>
        public static readonly StringName Gravity = "gravity";
        /// <summary>
        /// Cached name for the 'linear_damp_space_override' property.
        /// </summary>
        public static readonly StringName LinearDampSpaceOverride = "linear_damp_space_override";
        /// <summary>
        /// Cached name for the 'linear_damp' property.
        /// </summary>
        public static readonly StringName LinearDamp = "linear_damp";
        /// <summary>
        /// Cached name for the 'angular_damp_space_override' property.
        /// </summary>
        public static readonly StringName AngularDampSpaceOverride = "angular_damp_space_override";
        /// <summary>
        /// Cached name for the 'angular_damp' property.
        /// </summary>
        public static readonly StringName AngularDamp = "angular_damp";
        /// <summary>
        /// Cached name for the 'wind_force_magnitude' property.
        /// </summary>
        public static readonly StringName WindForceMagnitude = "wind_force_magnitude";
        /// <summary>
        /// Cached name for the 'wind_attenuation_factor' property.
        /// </summary>
        public static readonly StringName WindAttenuationFactor = "wind_attenuation_factor";
        /// <summary>
        /// Cached name for the 'wind_source_path' property.
        /// </summary>
        public static readonly StringName WindSourcePath = "wind_source_path";
        /// <summary>
        /// Cached name for the 'audio_bus_override' property.
        /// </summary>
        public static readonly StringName AudioBusOverride = "audio_bus_override";
        /// <summary>
        /// Cached name for the 'audio_bus_name' property.
        /// </summary>
        public static readonly StringName AudioBusName = "audio_bus_name";
        /// <summary>
        /// Cached name for the 'reverb_bus_enabled' property.
        /// </summary>
        public static readonly StringName ReverbBusEnabled = "reverb_bus_enabled";
        /// <summary>
        /// Cached name for the 'reverb_bus_name' property.
        /// </summary>
        public static readonly StringName ReverbBusName = "reverb_bus_name";
        /// <summary>
        /// Cached name for the 'reverb_bus_amount' property.
        /// </summary>
        public static readonly StringName ReverbBusAmount = "reverb_bus_amount";
        /// <summary>
        /// Cached name for the 'reverb_bus_uniformity' property.
        /// </summary>
        public static readonly StringName ReverbBusUniformity = "reverb_bus_uniformity";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CollisionObject3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_gravity_space_override_mode' method.
        /// </summary>
        public static readonly StringName SetGravitySpaceOverrideMode = "set_gravity_space_override_mode";
        /// <summary>
        /// Cached name for the 'get_gravity_space_override_mode' method.
        /// </summary>
        public static readonly StringName GetGravitySpaceOverrideMode = "get_gravity_space_override_mode";
        /// <summary>
        /// Cached name for the 'set_gravity_is_point' method.
        /// </summary>
        public static readonly StringName SetGravityIsPoint = "set_gravity_is_point";
        /// <summary>
        /// Cached name for the 'is_gravity_a_point' method.
        /// </summary>
        public static readonly StringName IsGravityAPoint = "is_gravity_a_point";
        /// <summary>
        /// Cached name for the 'set_gravity_point_unit_distance' method.
        /// </summary>
        public static readonly StringName SetGravityPointUnitDistance = "set_gravity_point_unit_distance";
        /// <summary>
        /// Cached name for the 'get_gravity_point_unit_distance' method.
        /// </summary>
        public static readonly StringName GetGravityPointUnitDistance = "get_gravity_point_unit_distance";
        /// <summary>
        /// Cached name for the 'set_gravity_point_center' method.
        /// </summary>
        public static readonly StringName SetGravityPointCenter = "set_gravity_point_center";
        /// <summary>
        /// Cached name for the 'get_gravity_point_center' method.
        /// </summary>
        public static readonly StringName GetGravityPointCenter = "get_gravity_point_center";
        /// <summary>
        /// Cached name for the 'set_gravity_direction' method.
        /// </summary>
        public static readonly StringName SetGravityDirection = "set_gravity_direction";
        /// <summary>
        /// Cached name for the 'get_gravity_direction' method.
        /// </summary>
        public static readonly StringName GetGravityDirection = "get_gravity_direction";
        /// <summary>
        /// Cached name for the 'set_gravity' method.
        /// </summary>
        public static readonly StringName SetGravity = "set_gravity";
        /// <summary>
        /// Cached name for the 'get_gravity' method.
        /// </summary>
        public static readonly StringName GetGravity = "get_gravity";
        /// <summary>
        /// Cached name for the 'set_linear_damp_space_override_mode' method.
        /// </summary>
        public static readonly StringName SetLinearDampSpaceOverrideMode = "set_linear_damp_space_override_mode";
        /// <summary>
        /// Cached name for the 'get_linear_damp_space_override_mode' method.
        /// </summary>
        public static readonly StringName GetLinearDampSpaceOverrideMode = "get_linear_damp_space_override_mode";
        /// <summary>
        /// Cached name for the 'set_angular_damp_space_override_mode' method.
        /// </summary>
        public static readonly StringName SetAngularDampSpaceOverrideMode = "set_angular_damp_space_override_mode";
        /// <summary>
        /// Cached name for the 'get_angular_damp_space_override_mode' method.
        /// </summary>
        public static readonly StringName GetAngularDampSpaceOverrideMode = "get_angular_damp_space_override_mode";
        /// <summary>
        /// Cached name for the 'set_angular_damp' method.
        /// </summary>
        public static readonly StringName SetAngularDamp = "set_angular_damp";
        /// <summary>
        /// Cached name for the 'get_angular_damp' method.
        /// </summary>
        public static readonly StringName GetAngularDamp = "get_angular_damp";
        /// <summary>
        /// Cached name for the 'set_linear_damp' method.
        /// </summary>
        public static readonly StringName SetLinearDamp = "set_linear_damp";
        /// <summary>
        /// Cached name for the 'get_linear_damp' method.
        /// </summary>
        public static readonly StringName GetLinearDamp = "get_linear_damp";
        /// <summary>
        /// Cached name for the 'set_priority' method.
        /// </summary>
        public static readonly StringName SetPriority = "set_priority";
        /// <summary>
        /// Cached name for the 'get_priority' method.
        /// </summary>
        public static readonly StringName GetPriority = "get_priority";
        /// <summary>
        /// Cached name for the 'set_wind_force_magnitude' method.
        /// </summary>
        public static readonly StringName SetWindForceMagnitude = "set_wind_force_magnitude";
        /// <summary>
        /// Cached name for the 'get_wind_force_magnitude' method.
        /// </summary>
        public static readonly StringName GetWindForceMagnitude = "get_wind_force_magnitude";
        /// <summary>
        /// Cached name for the 'set_wind_attenuation_factor' method.
        /// </summary>
        public static readonly StringName SetWindAttenuationFactor = "set_wind_attenuation_factor";
        /// <summary>
        /// Cached name for the 'get_wind_attenuation_factor' method.
        /// </summary>
        public static readonly StringName GetWindAttenuationFactor = "get_wind_attenuation_factor";
        /// <summary>
        /// Cached name for the 'set_wind_source_path' method.
        /// </summary>
        public static readonly StringName SetWindSourcePath = "set_wind_source_path";
        /// <summary>
        /// Cached name for the 'get_wind_source_path' method.
        /// </summary>
        public static readonly StringName GetWindSourcePath = "get_wind_source_path";
        /// <summary>
        /// Cached name for the 'set_monitorable' method.
        /// </summary>
        public static readonly StringName SetMonitorable = "set_monitorable";
        /// <summary>
        /// Cached name for the 'is_monitorable' method.
        /// </summary>
        public static readonly StringName IsMonitorable = "is_monitorable";
        /// <summary>
        /// Cached name for the 'set_monitoring' method.
        /// </summary>
        public static readonly StringName SetMonitoring = "set_monitoring";
        /// <summary>
        /// Cached name for the 'is_monitoring' method.
        /// </summary>
        public static readonly StringName IsMonitoring = "is_monitoring";
        /// <summary>
        /// Cached name for the 'get_overlapping_bodies' method.
        /// </summary>
        public static readonly StringName GetOverlappingBodies = "get_overlapping_bodies";
        /// <summary>
        /// Cached name for the 'get_overlapping_areas' method.
        /// </summary>
        public static readonly StringName GetOverlappingAreas = "get_overlapping_areas";
        /// <summary>
        /// Cached name for the 'has_overlapping_bodies' method.
        /// </summary>
        public static readonly StringName HasOverlappingBodies = "has_overlapping_bodies";
        /// <summary>
        /// Cached name for the 'has_overlapping_areas' method.
        /// </summary>
        public static readonly StringName HasOverlappingAreas = "has_overlapping_areas";
        /// <summary>
        /// Cached name for the 'overlaps_body' method.
        /// </summary>
        public static readonly StringName OverlapsBody = "overlaps_body";
        /// <summary>
        /// Cached name for the 'overlaps_area' method.
        /// </summary>
        public static readonly StringName OverlapsArea = "overlaps_area";
        /// <summary>
        /// Cached name for the 'set_audio_bus_override' method.
        /// </summary>
        public static readonly StringName SetAudioBusOverride = "set_audio_bus_override";
        /// <summary>
        /// Cached name for the 'is_overriding_audio_bus' method.
        /// </summary>
        public static readonly StringName IsOverridingAudioBus = "is_overriding_audio_bus";
        /// <summary>
        /// Cached name for the 'set_audio_bus_name' method.
        /// </summary>
        public static readonly StringName SetAudioBusName = "set_audio_bus_name";
        /// <summary>
        /// Cached name for the 'get_audio_bus_name' method.
        /// </summary>
        public static readonly StringName GetAudioBusName = "get_audio_bus_name";
        /// <summary>
        /// Cached name for the 'set_use_reverb_bus' method.
        /// </summary>
        public static readonly StringName SetUseReverbBus = "set_use_reverb_bus";
        /// <summary>
        /// Cached name for the 'is_using_reverb_bus' method.
        /// </summary>
        public static readonly StringName IsUsingReverbBus = "is_using_reverb_bus";
        /// <summary>
        /// Cached name for the 'set_reverb_bus_name' method.
        /// </summary>
        public static readonly StringName SetReverbBusName = "set_reverb_bus_name";
        /// <summary>
        /// Cached name for the 'get_reverb_bus_name' method.
        /// </summary>
        public static readonly StringName GetReverbBusName = "get_reverb_bus_name";
        /// <summary>
        /// Cached name for the 'set_reverb_amount' method.
        /// </summary>
        public static readonly StringName SetReverbAmount = "set_reverb_amount";
        /// <summary>
        /// Cached name for the 'get_reverb_amount' method.
        /// </summary>
        public static readonly StringName GetReverbAmount = "get_reverb_amount";
        /// <summary>
        /// Cached name for the 'set_reverb_uniformity' method.
        /// </summary>
        public static readonly StringName SetReverbUniformity = "set_reverb_uniformity";
        /// <summary>
        /// Cached name for the 'get_reverb_uniformity' method.
        /// </summary>
        public static readonly StringName GetReverbUniformity = "get_reverb_uniformity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CollisionObject3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'body_shape_entered' signal.
        /// </summary>
        public static readonly StringName BodyShapeEntered = "body_shape_entered";
        /// <summary>
        /// Cached name for the 'body_shape_exited' signal.
        /// </summary>
        public static readonly StringName BodyShapeExited = "body_shape_exited";
        /// <summary>
        /// Cached name for the 'body_entered' signal.
        /// </summary>
        public static readonly StringName BodyEntered = "body_entered";
        /// <summary>
        /// Cached name for the 'body_exited' signal.
        /// </summary>
        public static readonly StringName BodyExited = "body_exited";
        /// <summary>
        /// Cached name for the 'area_shape_entered' signal.
        /// </summary>
        public static readonly StringName AreaShapeEntered = "area_shape_entered";
        /// <summary>
        /// Cached name for the 'area_shape_exited' signal.
        /// </summary>
        public static readonly StringName AreaShapeExited = "area_shape_exited";
        /// <summary>
        /// Cached name for the 'area_entered' signal.
        /// </summary>
        public static readonly StringName AreaEntered = "area_entered";
        /// <summary>
        /// Cached name for the 'area_exited' signal.
        /// </summary>
        public static readonly StringName AreaExited = "area_exited";
    }
}
