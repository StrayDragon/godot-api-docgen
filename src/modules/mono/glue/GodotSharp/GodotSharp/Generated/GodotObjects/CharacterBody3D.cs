namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.CharacterBody3D"/> is a specialized class for physics bodies that are meant to be user-controlled. They are not affected by physics at all, but they affect other physics bodies in their path. They are mainly used to provide high-level API to move objects with wall and slope detection (<see cref="Godot.CharacterBody3D.MoveAndSlide()"/> method) in addition to the general collision detection provided by <see cref="Godot.PhysicsBody3D.MoveAndCollide(Vector3, bool, float, bool, int)"/>. This makes it useful for highly configurable physics bodies that must move in specific ways and collide with the world, as is often the case with user-controlled characters.</para>
/// <para>For game objects that don't require complex movement or collision detection, such as moving platforms, <see cref="Godot.AnimatableBody3D"/> is simpler to configure.</para>
/// </summary>
public partial class CharacterBody3D : PhysicsBody3D
{
    public enum MotionModeEnum : long
    {
        /// <summary>
        /// <para>Apply when notions of walls, ceiling and floor are relevant. In this mode the body motion will react to slopes (acceleration/slowdown). This mode is suitable for grounded games like platformers.</para>
        /// </summary>
        Grounded = 0,
        /// <summary>
        /// <para>Apply when there is no notion of floor or ceiling. All collisions will be reported as <c>on_wall</c>. In this mode, when you slide, the speed will always be constant. This mode is suitable for games without ground like space games.</para>
        /// </summary>
        Floating = 1
    }

    public enum PlatformOnLeaveEnum : long
    {
        /// <summary>
        /// <para>Add the last platform velocity to the <see cref="Godot.CharacterBody3D.Velocity"/> when you leave a moving platform.</para>
        /// </summary>
        AddVelocity = 0,
        /// <summary>
        /// <para>Add the last platform velocity to the <see cref="Godot.CharacterBody3D.Velocity"/> when you leave a moving platform, but any downward motion is ignored. It's useful to keep full jump height even when the platform is moving down.</para>
        /// </summary>
        AddUpwardVelocity = 1,
        /// <summary>
        /// <para>Do nothing when leaving a platform.</para>
        /// </summary>
        DoNothing = 2
    }

    /// <summary>
    /// <para>Sets the motion mode which defines the behavior of <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>.</para>
    /// </summary>
    public CharacterBody3D.MotionModeEnum MotionMode
    {
        get
        {
            return GetMotionMode();
        }
        set
        {
            SetMotionMode(value);
        }
    }

    /// <summary>
    /// <para>Vector pointing upwards, used to determine what is a wall and what is a floor (or a ceiling) when calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Defaults to <c>Vector3.UP</c>. As the vector will be normalized it can't be equal to <c>Vector3.ZERO</c>, if you want all collisions to be reported as walls, consider using <see cref="Godot.CharacterBody3D.MotionModeEnum.Floating"/> as <see cref="Godot.CharacterBody3D.MotionMode"/>.</para>
    /// </summary>
    public Vector3 UpDirection
    {
        get
        {
            return GetUpDirection();
        }
        set
        {
            SetUpDirection(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, during a jump against the ceiling, the body will slide, if <see langword="false"/> it will be stopped and will fall vertically.</para>
    /// </summary>
    public bool SlideOnCeiling
    {
        get
        {
            return IsSlideOnCeilingEnabled();
        }
        set
        {
            SetSlideOnCeilingEnabled(value);
        }
    }

    /// <summary>
    /// <para>Current velocity vector (typically meters per second), used and modified during calls to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>.</para>
    /// <para><b>Note:</b> A common mistake is setting this property to the desired velocity multiplied by <c>delta</c>, which produces a motion vector (typically in meters).</para>
    /// </summary>
    public Vector3 Velocity
    {
        get
        {
            return GetVelocity();
        }
        set
        {
            SetVelocity(value);
        }
    }

    /// <summary>
    /// <para>Maximum number of times the body can change direction before it stops when calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Must be greater than zero.</para>
    /// </summary>
    public int MaxSlides
    {
        get
        {
            return GetMaxSlides();
        }
        set
        {
            SetMaxSlides(value);
        }
    }

    /// <summary>
    /// <para>Minimum angle (in radians) where the body is allowed to slide when it encounters a wall. The default value equals 15 degrees. When <see cref="Godot.CharacterBody3D.MotionMode"/> is <see cref="Godot.CharacterBody3D.MotionModeEnum.Grounded"/>, it only affects movement if <see cref="Godot.CharacterBody3D.FloorBlockOnWall"/> is <see langword="true"/>.</para>
    /// </summary>
    public float WallMinSlideAngle
    {
        get
        {
            return GetWallMinSlideAngle();
        }
        set
        {
            SetWallMinSlideAngle(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the body will not slide on slopes when calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/> when the body is standing still.</para>
    /// <para>If <see langword="false"/>, the body will slide on floor's slopes when <see cref="Godot.CharacterBody3D.Velocity"/> applies a downward force.</para>
    /// </summary>
    public bool FloorStopOnSlope
    {
        get
        {
            return IsFloorStopOnSlopeEnabled();
        }
        set
        {
            SetFloorStopOnSlopeEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/> (by default), the body will move faster on downward slopes and slower on upward slopes.</para>
    /// <para>If <see langword="true"/>, the body will always move at the same speed on the ground no matter the slope. Note that you need to use <see cref="Godot.CharacterBody3D.FloorSnapLength"/> to stick along a downward slope at constant speed.</para>
    /// </summary>
    public bool FloorConstantSpeed
    {
        get
        {
            return IsFloorConstantSpeedEnabled();
        }
        set
        {
            SetFloorConstantSpeedEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the body will be able to move on the floor only. This option avoids to be able to walk on walls, it will however allow to slide down along them.</para>
    /// </summary>
    public bool FloorBlockOnWall
    {
        get
        {
            return IsFloorBlockOnWallEnabled();
        }
        set
        {
            SetFloorBlockOnWallEnabled(value);
        }
    }

    /// <summary>
    /// <para>Maximum angle (in radians) where a slope is still considered a floor (or a ceiling), rather than a wall, when calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. The default value equals 45 degrees.</para>
    /// </summary>
    public float FloorMaxAngle
    {
        get
        {
            return GetFloorMaxAngle();
        }
        set
        {
            SetFloorMaxAngle(value);
        }
    }

    /// <summary>
    /// <para>Sets a snapping distance. When set to a value different from <c>0.0</c>, the body is kept attached to slopes when calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. The snapping vector is determined by the given distance along the opposite direction of the <see cref="Godot.CharacterBody3D.UpDirection"/>.</para>
    /// <para>As long as the snapping vector is in contact with the ground and the body moves against <see cref="Godot.CharacterBody3D.UpDirection"/>, the body will remain attached to the surface. Snapping is not applied if the body moves along <see cref="Godot.CharacterBody3D.UpDirection"/>, meaning it contains vertical rising velocity, so it will be able to detach from the ground when jumping or when the body is pushed up by something. If you want to apply a snap without taking into account the velocity, use <see cref="Godot.CharacterBody3D.ApplyFloorSnap()"/>.</para>
    /// </summary>
    public float FloorSnapLength
    {
        get
        {
            return GetFloorSnapLength();
        }
        set
        {
            SetFloorSnapLength(value);
        }
    }

    /// <summary>
    /// <para>Sets the behavior to apply when you leave a moving platform. By default, to be physically accurate, when you leave the last platform velocity is applied.</para>
    /// </summary>
    public CharacterBody3D.PlatformOnLeaveEnum PlatformOnLeave
    {
        get
        {
            return GetPlatformOnLeave();
        }
        set
        {
            SetPlatformOnLeave(value);
        }
    }

    /// <summary>
    /// <para>Collision layers that will be included for detecting floor bodies that will act as moving platforms to be followed by the <see cref="Godot.CharacterBody3D"/>. By default, all floor bodies are detected and propagate their velocity.</para>
    /// </summary>
    public uint PlatformFloorLayers
    {
        get
        {
            return GetPlatformFloorLayers();
        }
        set
        {
            SetPlatformFloorLayers(value);
        }
    }

    /// <summary>
    /// <para>Collision layers that will be included for detecting wall bodies that will act as moving platforms to be followed by the <see cref="Godot.CharacterBody3D"/>. By default, all wall bodies are ignored.</para>
    /// </summary>
    public uint PlatformWallLayers
    {
        get
        {
            return GetPlatformWallLayers();
        }
        set
        {
            SetPlatformWallLayers(value);
        }
    }

    /// <summary>
    /// <para>Extra margin used for collision recovery when calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>.</para>
    /// <para>If the body is at least this close to another body, it will consider them to be colliding and will be pushed away before performing the actual motion.</para>
    /// <para>A higher value means it's more flexible for detecting collision, which helps with consistently detecting walls and floors.</para>
    /// <para>A lower value forces the collision algorithm to use more exact detection, so it can be used in cases that specifically require precision, e.g at very low scale to avoid visible jittering, or for stability with a stack of character bodies.</para>
    /// </summary>
    public float SafeMargin
    {
        get
        {
            return GetSafeMargin();
        }
        set
        {
            SetSafeMargin(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CharacterBody3D);

    private static readonly StringName NativeName = "CharacterBody3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CharacterBody3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CharacterBody3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CharacterBody3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveAndSlide, 2240911060ul);

    /// <summary>
    /// <para>Moves the body based on <see cref="Godot.CharacterBody3D.Velocity"/>. If the body collides with another, it will slide along the other body rather than stop immediately. If the other body is a <see cref="Godot.CharacterBody3D"/> or <see cref="Godot.RigidBody3D"/>, it will also be affected by the motion of the other body. You can use this to make moving and rotating platforms, or to make nodes push other nodes.</para>
    /// <para>This method should be used in <see cref="Godot.Node._PhysicsProcess(double)"/> (or in a method called by <see cref="Godot.Node._PhysicsProcess(double)"/>), as it uses the physics step's <c>delta</c> value automatically in calculations. Otherwise, the simulation will run at an incorrect speed.</para>
    /// <para>Modifies <see cref="Godot.CharacterBody3D.Velocity"/> if a slide collision occurred. To get the latest collision call <see cref="Godot.CharacterBody3D.GetLastSlideCollision()"/>, for more detailed information about collisions that occurred, use <see cref="Godot.CharacterBody3D.GetSlideCollision(int)"/>.</para>
    /// <para>When the body touches a moving platform, the platform's velocity is automatically added to the body motion. If a collision occurs due to the platform's motion, it will always be first in the slide collisions.</para>
    /// <para>Returns <see langword="true"/> if the body collided, otherwise, returns <see langword="false"/>.</para>
    /// </summary>
    public bool MoveAndSlide()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyFloorSnap, 3218959716ul);

    /// <summary>
    /// <para>Allows to manually apply a snap to the floor regardless of the body's velocity. This function does nothing when <see cref="Godot.CharacterBody3D.IsOnFloor()"/> returns <see langword="true"/>.</para>
    /// </summary>
    public void ApplyFloorSnap()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVelocity(Vector3 velocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind2, GodotObject.GetPtr(this), &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSafeMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSafeMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSafeMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSafeMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFloorStopOnSlopeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFloorStopOnSlopeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFloorStopOnSlopeEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFloorStopOnSlopeEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFloorConstantSpeedEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFloorConstantSpeedEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFloorConstantSpeedEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFloorConstantSpeedEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFloorBlockOnWallEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFloorBlockOnWallEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFloorBlockOnWallEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFloorBlockOnWallEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlideOnCeilingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSlideOnCeilingEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSlideOnCeilingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSlideOnCeilingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlatformFloorLayers, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlatformFloorLayers(uint excludeLayer)
    {
        NativeCalls.godot_icall_1_208(MethodBind14, GodotObject.GetPtr(this), excludeLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlatformFloorLayers, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetPlatformFloorLayers()
    {
        return NativeCalls.godot_icall_0_209(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlatformWallLayers, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlatformWallLayers(uint excludeLayer)
    {
        NativeCalls.godot_icall_1_208(MethodBind16, GodotObject.GetPtr(this), excludeLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlatformWallLayers, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetPlatformWallLayers()
    {
        return NativeCalls.godot_icall_0_209(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxSlides, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxSlides()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxSlides, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxSlides(int maxSlides)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), maxSlides);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloorMaxAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFloorMaxAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFloorMaxAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFloorMaxAngle(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind21, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloorSnapLength, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFloorSnapLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFloorSnapLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFloorSnapLength(float floorSnapLength)
    {
        NativeCalls.godot_icall_1_67(MethodBind23, GodotObject.GetPtr(this), floorSnapLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWallMinSlideAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWallMinSlideAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWallMinSlideAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWallMinSlideAngle(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind25, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpDirection, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetUpDirection()
    {
        return NativeCalls.godot_icall_0_125(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpDirection, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetUpDirection(Vector3 upDirection)
    {
        NativeCalls.godot_icall_1_177(MethodBind27, GodotObject.GetPtr(this), &upDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotionMode, 2690739026ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMotionMode(CharacterBody3D.MotionModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotionMode, 3529553604ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CharacterBody3D.MotionModeEnum GetMotionMode()
    {
        return (CharacterBody3D.MotionModeEnum)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlatformOnLeave, 1459986142ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlatformOnLeave(CharacterBody3D.PlatformOnLeaveEnum onLeaveApplyVelocity)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)onLeaveApplyVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlatformOnLeave, 996491171ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CharacterBody3D.PlatformOnLeaveEnum GetPlatformOnLeave()
    {
        return (CharacterBody3D.PlatformOnLeaveEnum)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnFloor, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body collided with the floor on the last call of <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Otherwise, returns <see langword="false"/>. The <see cref="Godot.CharacterBody3D.UpDirection"/> and <see cref="Godot.CharacterBody3D.FloorMaxAngle"/> are used to determine whether a surface is "floor" or not.</para>
    /// </summary>
    public bool IsOnFloor()
    {
        return NativeCalls.godot_icall_0_15(MethodBind32, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnFloorOnly, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body collided only with the floor on the last call of <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Otherwise, returns <see langword="false"/>. The <see cref="Godot.CharacterBody3D.UpDirection"/> and <see cref="Godot.CharacterBody3D.FloorMaxAngle"/> are used to determine whether a surface is "floor" or not.</para>
    /// </summary>
    public bool IsOnFloorOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnCeiling, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body collided with the ceiling on the last call of <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Otherwise, returns <see langword="false"/>. The <see cref="Godot.CharacterBody3D.UpDirection"/> and <see cref="Godot.CharacterBody3D.FloorMaxAngle"/> are used to determine whether a surface is "ceiling" or not.</para>
    /// </summary>
    public bool IsOnCeiling()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnCeilingOnly, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body collided only with the ceiling on the last call of <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Otherwise, returns <see langword="false"/>. The <see cref="Godot.CharacterBody3D.UpDirection"/> and <see cref="Godot.CharacterBody3D.FloorMaxAngle"/> are used to determine whether a surface is "ceiling" or not.</para>
    /// </summary>
    public bool IsOnCeilingOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnWall, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body collided with a wall on the last call of <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Otherwise, returns <see langword="false"/>. The <see cref="Godot.CharacterBody3D.UpDirection"/> and <see cref="Godot.CharacterBody3D.FloorMaxAngle"/> are used to determine whether a surface is "wall" or not.</para>
    /// </summary>
    public bool IsOnWall()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnWallOnly, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body collided only with a wall on the last call of <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Otherwise, returns <see langword="false"/>. The <see cref="Godot.CharacterBody3D.UpDirection"/> and <see cref="Godot.CharacterBody3D.FloorMaxAngle"/> are used to determine whether a surface is "wall" or not.</para>
    /// </summary>
    public bool IsOnWallOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind37, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloorNormal, 3360562783ul);

    /// <summary>
    /// <para>Returns the collision normal of the floor at the last collision point. Only valid after calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/> and when <see cref="Godot.CharacterBody3D.IsOnFloor()"/> returns <see langword="true"/>.</para>
    /// <para><b>Warning:</b> The collision normal is not always the same as the surface normal.</para>
    /// </summary>
    public Vector3 GetFloorNormal()
    {
        return NativeCalls.godot_icall_0_125(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWallNormal, 3360562783ul);

    /// <summary>
    /// <para>Returns the collision normal of the wall at the last collision point. Only valid after calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/> and when <see cref="Godot.CharacterBody3D.IsOnWall()"/> returns <see langword="true"/>.</para>
    /// <para><b>Warning:</b> The collision normal is not always the same as the surface normal.</para>
    /// </summary>
    public Vector3 GetWallNormal()
    {
        return NativeCalls.godot_icall_0_125(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastMotion, 3360562783ul);

    /// <summary>
    /// <para>Returns the last motion applied to the <see cref="Godot.CharacterBody3D"/> during the last call to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. The movement can be split into multiple motions when sliding occurs, and this method return the last one, which is useful to retrieve the current direction of the movement.</para>
    /// </summary>
    public Vector3 GetLastMotion()
    {
        return NativeCalls.godot_icall_0_125(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionDelta, 3360562783ul);

    /// <summary>
    /// <para>Returns the travel (position delta) that occurred during the last call to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>.</para>
    /// </summary>
    public Vector3 GetPositionDelta()
    {
        return NativeCalls.godot_icall_0_125(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRealVelocity, 3360562783ul);

    /// <summary>
    /// <para>Returns the current real velocity since the last call to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. For example, when you climb a slope, you will move diagonally even though the velocity is horizontal. This method returns the diagonal movement, as opposed to <see cref="Godot.CharacterBody3D.Velocity"/> which returns the requested velocity.</para>
    /// </summary>
    public Vector3 GetRealVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloorAngle, 2906300789ul);

    /// <summary>
    /// <para>Returns the floor's collision angle at the last collision point according to <paramref name="upDirection"/>, which is <c>Vector3.UP</c> by default. This value is always positive and only valid after calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/> and when <see cref="Godot.CharacterBody3D.IsOnFloor()"/> returns <see langword="true"/>.</para>
    /// </summary>
    /// <param name="upDirection">If the parameter is null, then the default value is <c>new Vector3(0.0f, 1.0f, 0.0f)</c>.</param>
    public unsafe float GetFloorAngle(Nullable<Vector3> upDirection = null)
    {
        Vector3 upDirectionOrDefVal = upDirection.HasValue ? upDirection.Value : new Vector3(0.0f, 1.0f, 0.0f);
        return NativeCalls.godot_icall_1_288(MethodBind43, GodotObject.GetPtr(this), &upDirectionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlatformVelocity, 3360562783ul);

    /// <summary>
    /// <para>Returns the linear velocity of the platform at the last collision point. Only valid after calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>.</para>
    /// </summary>
    public Vector3 GetPlatformVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlatformAngularVelocity, 3360562783ul);

    /// <summary>
    /// <para>Returns the angular velocity of the platform at the last collision point. Only valid after calling <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>.</para>
    /// </summary>
    public Vector3 GetPlatformAngularVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlideCollisionCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of times the body collided and changed direction during the last call to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>.</para>
    /// </summary>
    public int GetSlideCollisionCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlideCollision, 107003663ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.KinematicCollision3D"/>, which contains information about a collision that occurred during the last call to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Since the body can collide several times in a single call to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>, you must specify the index of the collision in the range 0 to (<see cref="Godot.CharacterBody3D.GetSlideCollisionCount()"/> - 1). See also <see cref="Godot.CharacterBody3D.GetLastSlideCollision()"/>.</para>
    /// </summary>
    public KinematicCollision3D GetSlideCollision(int slideIdx)
    {
        return (KinematicCollision3D)NativeCalls.godot_icall_1_71(MethodBind47, GodotObject.GetPtr(this), slideIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastSlideCollision, 186875014ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.KinematicCollision3D"/> if a collision occurred. The returned value contains information about the latest collision that occurred during the last call to <see cref="Godot.CharacterBody3D.MoveAndSlide()"/>. Returns <see langword="null"/> if no collision occurred. See also <see cref="Godot.CharacterBody3D.GetSlideCollision(int)"/>.</para>
    /// </summary>
    public KinematicCollision3D GetLastSlideCollision()
    {
        return (KinematicCollision3D)NativeCalls.godot_icall_0_63(MethodBind48, GodotObject.GetPtr(this));
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
    public new class PropertyName : PhysicsBody3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'motion_mode' property.
        /// </summary>
        public static readonly StringName MotionMode = "motion_mode";
        /// <summary>
        /// Cached name for the 'up_direction' property.
        /// </summary>
        public static readonly StringName UpDirection = "up_direction";
        /// <summary>
        /// Cached name for the 'slide_on_ceiling' property.
        /// </summary>
        public static readonly StringName SlideOnCeiling = "slide_on_ceiling";
        /// <summary>
        /// Cached name for the 'velocity' property.
        /// </summary>
        public static readonly StringName Velocity = "velocity";
        /// <summary>
        /// Cached name for the 'max_slides' property.
        /// </summary>
        public static readonly StringName MaxSlides = "max_slides";
        /// <summary>
        /// Cached name for the 'wall_min_slide_angle' property.
        /// </summary>
        public static readonly StringName WallMinSlideAngle = "wall_min_slide_angle";
        /// <summary>
        /// Cached name for the 'floor_stop_on_slope' property.
        /// </summary>
        public static readonly StringName FloorStopOnSlope = "floor_stop_on_slope";
        /// <summary>
        /// Cached name for the 'floor_constant_speed' property.
        /// </summary>
        public static readonly StringName FloorConstantSpeed = "floor_constant_speed";
        /// <summary>
        /// Cached name for the 'floor_block_on_wall' property.
        /// </summary>
        public static readonly StringName FloorBlockOnWall = "floor_block_on_wall";
        /// <summary>
        /// Cached name for the 'floor_max_angle' property.
        /// </summary>
        public static readonly StringName FloorMaxAngle = "floor_max_angle";
        /// <summary>
        /// Cached name for the 'floor_snap_length' property.
        /// </summary>
        public static readonly StringName FloorSnapLength = "floor_snap_length";
        /// <summary>
        /// Cached name for the 'platform_on_leave' property.
        /// </summary>
        public static readonly StringName PlatformOnLeave = "platform_on_leave";
        /// <summary>
        /// Cached name for the 'platform_floor_layers' property.
        /// </summary>
        public static readonly StringName PlatformFloorLayers = "platform_floor_layers";
        /// <summary>
        /// Cached name for the 'platform_wall_layers' property.
        /// </summary>
        public static readonly StringName PlatformWallLayers = "platform_wall_layers";
        /// <summary>
        /// Cached name for the 'safe_margin' property.
        /// </summary>
        public static readonly StringName SafeMargin = "safe_margin";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PhysicsBody3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'move_and_slide' method.
        /// </summary>
        public static readonly StringName MoveAndSlide = "move_and_slide";
        /// <summary>
        /// Cached name for the 'apply_floor_snap' method.
        /// </summary>
        public static readonly StringName ApplyFloorSnap = "apply_floor_snap";
        /// <summary>
        /// Cached name for the 'set_velocity' method.
        /// </summary>
        public static readonly StringName SetVelocity = "set_velocity";
        /// <summary>
        /// Cached name for the 'get_velocity' method.
        /// </summary>
        public static readonly StringName GetVelocity = "get_velocity";
        /// <summary>
        /// Cached name for the 'set_safe_margin' method.
        /// </summary>
        public static readonly StringName SetSafeMargin = "set_safe_margin";
        /// <summary>
        /// Cached name for the 'get_safe_margin' method.
        /// </summary>
        public static readonly StringName GetSafeMargin = "get_safe_margin";
        /// <summary>
        /// Cached name for the 'is_floor_stop_on_slope_enabled' method.
        /// </summary>
        public static readonly StringName IsFloorStopOnSlopeEnabled = "is_floor_stop_on_slope_enabled";
        /// <summary>
        /// Cached name for the 'set_floor_stop_on_slope_enabled' method.
        /// </summary>
        public static readonly StringName SetFloorStopOnSlopeEnabled = "set_floor_stop_on_slope_enabled";
        /// <summary>
        /// Cached name for the 'set_floor_constant_speed_enabled' method.
        /// </summary>
        public static readonly StringName SetFloorConstantSpeedEnabled = "set_floor_constant_speed_enabled";
        /// <summary>
        /// Cached name for the 'is_floor_constant_speed_enabled' method.
        /// </summary>
        public static readonly StringName IsFloorConstantSpeedEnabled = "is_floor_constant_speed_enabled";
        /// <summary>
        /// Cached name for the 'set_floor_block_on_wall_enabled' method.
        /// </summary>
        public static readonly StringName SetFloorBlockOnWallEnabled = "set_floor_block_on_wall_enabled";
        /// <summary>
        /// Cached name for the 'is_floor_block_on_wall_enabled' method.
        /// </summary>
        public static readonly StringName IsFloorBlockOnWallEnabled = "is_floor_block_on_wall_enabled";
        /// <summary>
        /// Cached name for the 'set_slide_on_ceiling_enabled' method.
        /// </summary>
        public static readonly StringName SetSlideOnCeilingEnabled = "set_slide_on_ceiling_enabled";
        /// <summary>
        /// Cached name for the 'is_slide_on_ceiling_enabled' method.
        /// </summary>
        public static readonly StringName IsSlideOnCeilingEnabled = "is_slide_on_ceiling_enabled";
        /// <summary>
        /// Cached name for the 'set_platform_floor_layers' method.
        /// </summary>
        public static readonly StringName SetPlatformFloorLayers = "set_platform_floor_layers";
        /// <summary>
        /// Cached name for the 'get_platform_floor_layers' method.
        /// </summary>
        public static readonly StringName GetPlatformFloorLayers = "get_platform_floor_layers";
        /// <summary>
        /// Cached name for the 'set_platform_wall_layers' method.
        /// </summary>
        public static readonly StringName SetPlatformWallLayers = "set_platform_wall_layers";
        /// <summary>
        /// Cached name for the 'get_platform_wall_layers' method.
        /// </summary>
        public static readonly StringName GetPlatformWallLayers = "get_platform_wall_layers";
        /// <summary>
        /// Cached name for the 'get_max_slides' method.
        /// </summary>
        public static readonly StringName GetMaxSlides = "get_max_slides";
        /// <summary>
        /// Cached name for the 'set_max_slides' method.
        /// </summary>
        public static readonly StringName SetMaxSlides = "set_max_slides";
        /// <summary>
        /// Cached name for the 'get_floor_max_angle' method.
        /// </summary>
        public static readonly StringName GetFloorMaxAngle = "get_floor_max_angle";
        /// <summary>
        /// Cached name for the 'set_floor_max_angle' method.
        /// </summary>
        public static readonly StringName SetFloorMaxAngle = "set_floor_max_angle";
        /// <summary>
        /// Cached name for the 'get_floor_snap_length' method.
        /// </summary>
        public static readonly StringName GetFloorSnapLength = "get_floor_snap_length";
        /// <summary>
        /// Cached name for the 'set_floor_snap_length' method.
        /// </summary>
        public static readonly StringName SetFloorSnapLength = "set_floor_snap_length";
        /// <summary>
        /// Cached name for the 'get_wall_min_slide_angle' method.
        /// </summary>
        public static readonly StringName GetWallMinSlideAngle = "get_wall_min_slide_angle";
        /// <summary>
        /// Cached name for the 'set_wall_min_slide_angle' method.
        /// </summary>
        public static readonly StringName SetWallMinSlideAngle = "set_wall_min_slide_angle";
        /// <summary>
        /// Cached name for the 'get_up_direction' method.
        /// </summary>
        public static readonly StringName GetUpDirection = "get_up_direction";
        /// <summary>
        /// Cached name for the 'set_up_direction' method.
        /// </summary>
        public static readonly StringName SetUpDirection = "set_up_direction";
        /// <summary>
        /// Cached name for the 'set_motion_mode' method.
        /// </summary>
        public static readonly StringName SetMotionMode = "set_motion_mode";
        /// <summary>
        /// Cached name for the 'get_motion_mode' method.
        /// </summary>
        public static readonly StringName GetMotionMode = "get_motion_mode";
        /// <summary>
        /// Cached name for the 'set_platform_on_leave' method.
        /// </summary>
        public static readonly StringName SetPlatformOnLeave = "set_platform_on_leave";
        /// <summary>
        /// Cached name for the 'get_platform_on_leave' method.
        /// </summary>
        public static readonly StringName GetPlatformOnLeave = "get_platform_on_leave";
        /// <summary>
        /// Cached name for the 'is_on_floor' method.
        /// </summary>
        public static readonly StringName IsOnFloor = "is_on_floor";
        /// <summary>
        /// Cached name for the 'is_on_floor_only' method.
        /// </summary>
        public static readonly StringName IsOnFloorOnly = "is_on_floor_only";
        /// <summary>
        /// Cached name for the 'is_on_ceiling' method.
        /// </summary>
        public static readonly StringName IsOnCeiling = "is_on_ceiling";
        /// <summary>
        /// Cached name for the 'is_on_ceiling_only' method.
        /// </summary>
        public static readonly StringName IsOnCeilingOnly = "is_on_ceiling_only";
        /// <summary>
        /// Cached name for the 'is_on_wall' method.
        /// </summary>
        public static readonly StringName IsOnWall = "is_on_wall";
        /// <summary>
        /// Cached name for the 'is_on_wall_only' method.
        /// </summary>
        public static readonly StringName IsOnWallOnly = "is_on_wall_only";
        /// <summary>
        /// Cached name for the 'get_floor_normal' method.
        /// </summary>
        public static readonly StringName GetFloorNormal = "get_floor_normal";
        /// <summary>
        /// Cached name for the 'get_wall_normal' method.
        /// </summary>
        public static readonly StringName GetWallNormal = "get_wall_normal";
        /// <summary>
        /// Cached name for the 'get_last_motion' method.
        /// </summary>
        public static readonly StringName GetLastMotion = "get_last_motion";
        /// <summary>
        /// Cached name for the 'get_position_delta' method.
        /// </summary>
        public static readonly StringName GetPositionDelta = "get_position_delta";
        /// <summary>
        /// Cached name for the 'get_real_velocity' method.
        /// </summary>
        public static readonly StringName GetRealVelocity = "get_real_velocity";
        /// <summary>
        /// Cached name for the 'get_floor_angle' method.
        /// </summary>
        public static readonly StringName GetFloorAngle = "get_floor_angle";
        /// <summary>
        /// Cached name for the 'get_platform_velocity' method.
        /// </summary>
        public static readonly StringName GetPlatformVelocity = "get_platform_velocity";
        /// <summary>
        /// Cached name for the 'get_platform_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetPlatformAngularVelocity = "get_platform_angular_velocity";
        /// <summary>
        /// Cached name for the 'get_slide_collision_count' method.
        /// </summary>
        public static readonly StringName GetSlideCollisionCount = "get_slide_collision_count";
        /// <summary>
        /// Cached name for the 'get_slide_collision' method.
        /// </summary>
        public static readonly StringName GetSlideCollision = "get_slide_collision";
        /// <summary>
        /// Cached name for the 'get_last_slide_collision' method.
        /// </summary>
        public static readonly StringName GetLastSlideCollision = "get_last_slide_collision";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PhysicsBody3D.SignalName
    {
    }
}
