namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>PhysicsServer3D is the server responsible for all 3D physics. It can directly create and manipulate all physics objects:</para>
/// <para>- A <i>space</i> is a self-contained world for a physics simulation. It contains bodies, areas, and joints. Its state can be queried for collision and intersection information, and several parameters of the simulation can be modified.</para>
/// <para>- A <i>shape</i> is a geometric shape such as a sphere, a box, a cylinder, or a polygon. It can be used for collision detection by adding it to a body/area, possibly with an extra transformation relative to the body/area's origin. Bodies/areas can have multiple (transformed) shapes added to them, and a single shape can be added to bodies/areas multiple times with different local transformations.</para>
/// <para>- A <i>body</i> is a physical object which can be in static, kinematic, or rigid mode. Its state (such as position and velocity) can be queried and updated. A force integration callback can be set to customize the body's physics.</para>
/// <para>- An <i>area</i> is a region in space which can be used to detect bodies and areas entering and exiting it. A body monitoring callback can be set to report entering/exiting body shapes, and similarly an area monitoring callback can be set. Gravity and damping can be overridden within the area by setting area parameters.</para>
/// <para>- A <i>joint</i> is a constraint, either between two bodies or on one body relative to a point. Parameters such as the joint bias and the rest length of a spring joint can be adjusted.</para>
/// <para>Physics objects in <see cref="Godot.PhysicsServer3D"/> may be created and manipulated independently; they do not have to be tied to nodes in the scene tree.</para>
/// <para><b>Note:</b> All the 3D physics nodes use the physics server internally. Adding a physics node to the scene tree will cause a corresponding physics object to be created in the physics server. A rigid body node registers a callback that updates the node's transform with the transform of the respective body object in the physics server (every physics update). An area node registers a callback to inform the area node about overlaps with the respective area object in the physics server. The raycast node queries the direct state of the relevant space in the physics server.</para>
/// </summary>
public static partial class PhysicsServer3D
{
    public enum JointType : long
    {
        /// <summary>
        /// <para>The <see cref="Godot.Joint3D"/> is a <see cref="Godot.PinJoint3D"/>.</para>
        /// </summary>
        Pin = 0,
        /// <summary>
        /// <para>The <see cref="Godot.Joint3D"/> is a <see cref="Godot.HingeJoint3D"/>.</para>
        /// </summary>
        Hinge = 1,
        /// <summary>
        /// <para>The <see cref="Godot.Joint3D"/> is a <see cref="Godot.SliderJoint3D"/>.</para>
        /// </summary>
        Slider = 2,
        /// <summary>
        /// <para>The <see cref="Godot.Joint3D"/> is a <see cref="Godot.ConeTwistJoint3D"/>.</para>
        /// </summary>
        ConeTwist = 3,
        /// <summary>
        /// <para>The <see cref="Godot.Joint3D"/> is a <see cref="Godot.Generic6DofJoint3D"/>.</para>
        /// </summary>
        Type6Dof = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.PhysicsServer3D.JointType"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum PinJointParam : long
    {
        /// <summary>
        /// <para>The strength with which the pinned objects try to stay in positional relation to each other.</para>
        /// <para>The higher, the stronger.</para>
        /// </summary>
        Bias = 0,
        /// <summary>
        /// <para>The strength with which the pinned objects try to stay in velocity relation to each other.</para>
        /// <para>The higher, the stronger.</para>
        /// </summary>
        Damping = 1,
        /// <summary>
        /// <para>If above 0, this value is the maximum value for an impulse that this Joint3D puts on its ends.</para>
        /// </summary>
        ImpulseClamp = 2
    }

    public enum HingeJointParam : long
    {
        /// <summary>
        /// <para>The speed with which the two bodies get pulled together when they move in different directions.</para>
        /// </summary>
        Bias = 0,
        /// <summary>
        /// <para>The maximum rotation across the Hinge.</para>
        /// </summary>
        LimitUpper = 1,
        /// <summary>
        /// <para>The minimum rotation across the Hinge.</para>
        /// </summary>
        LimitLower = 2,
        /// <summary>
        /// <para>The speed with which the rotation across the axis perpendicular to the hinge gets corrected.</para>
        /// </summary>
        LimitBias = 3,
        LimitSoftness = 4,
        /// <summary>
        /// <para>The lower this value, the more the rotation gets slowed down.</para>
        /// </summary>
        LimitRelaxation = 5,
        /// <summary>
        /// <para>Target speed for the motor.</para>
        /// </summary>
        MotorTargetVelocity = 6,
        /// <summary>
        /// <para>Maximum acceleration for the motor.</para>
        /// </summary>
        MotorMaxImpulse = 7
    }

    public enum HingeJointFlag : long
    {
        /// <summary>
        /// <para>If <see langword="true"/>, the Hinge has a maximum and a minimum rotation.</para>
        /// </summary>
        UseLimit = 0,
        /// <summary>
        /// <para>If <see langword="true"/>, a motor turns the Hinge.</para>
        /// </summary>
        EnableMotor = 1
    }

    public enum SliderJointParam : long
    {
        /// <summary>
        /// <para>The maximum difference between the pivot points on their X axis before damping happens.</para>
        /// </summary>
        LinearLimitUpper = 0,
        /// <summary>
        /// <para>The minimum difference between the pivot points on their X axis before damping happens.</para>
        /// </summary>
        LinearLimitLower = 1,
        /// <summary>
        /// <para>A factor applied to the movement across the slider axis once the limits get surpassed. The lower, the slower the movement.</para>
        /// </summary>
        LinearLimitSoftness = 2,
        /// <summary>
        /// <para>The amount of restitution once the limits are surpassed. The lower, the more velocity-energy gets lost.</para>
        /// </summary>
        LinearLimitRestitution = 3,
        /// <summary>
        /// <para>The amount of damping once the slider limits are surpassed.</para>
        /// </summary>
        LinearLimitDamping = 4,
        /// <summary>
        /// <para>A factor applied to the movement across the slider axis as long as the slider is in the limits. The lower, the slower the movement.</para>
        /// </summary>
        LinearMotionSoftness = 5,
        /// <summary>
        /// <para>The amount of restitution inside the slider limits.</para>
        /// </summary>
        LinearMotionRestitution = 6,
        /// <summary>
        /// <para>The amount of damping inside the slider limits.</para>
        /// </summary>
        LinearMotionDamping = 7,
        /// <summary>
        /// <para>A factor applied to the movement across axes orthogonal to the slider.</para>
        /// </summary>
        LinearOrthogonalSoftness = 8,
        /// <summary>
        /// <para>The amount of restitution when movement is across axes orthogonal to the slider.</para>
        /// </summary>
        LinearOrthogonalRestitution = 9,
        /// <summary>
        /// <para>The amount of damping when movement is across axes orthogonal to the slider.</para>
        /// </summary>
        LinearOrthogonalDamping = 10,
        /// <summary>
        /// <para>The upper limit of rotation in the slider.</para>
        /// </summary>
        AngularLimitUpper = 11,
        /// <summary>
        /// <para>The lower limit of rotation in the slider.</para>
        /// </summary>
        AngularLimitLower = 12,
        /// <summary>
        /// <para>A factor applied to the all rotation once the limit is surpassed.</para>
        /// </summary>
        AngularLimitSoftness = 13,
        /// <summary>
        /// <para>The amount of restitution of the rotation when the limit is surpassed.</para>
        /// </summary>
        AngularLimitRestitution = 14,
        /// <summary>
        /// <para>The amount of damping of the rotation when the limit is surpassed.</para>
        /// </summary>
        AngularLimitDamping = 15,
        /// <summary>
        /// <para>A factor that gets applied to the all rotation in the limits.</para>
        /// </summary>
        AngularMotionSoftness = 16,
        /// <summary>
        /// <para>The amount of restitution of the rotation in the limits.</para>
        /// </summary>
        AngularMotionRestitution = 17,
        /// <summary>
        /// <para>The amount of damping of the rotation in the limits.</para>
        /// </summary>
        AngularMotionDamping = 18,
        /// <summary>
        /// <para>A factor that gets applied to the all rotation across axes orthogonal to the slider.</para>
        /// </summary>
        AngularOrthogonalSoftness = 19,
        /// <summary>
        /// <para>The amount of restitution of the rotation across axes orthogonal to the slider.</para>
        /// </summary>
        AngularOrthogonalRestitution = 20,
        /// <summary>
        /// <para>The amount of damping of the rotation across axes orthogonal to the slider.</para>
        /// </summary>
        AngularOrthogonalDamping = 21,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.PhysicsServer3D.SliderJointParam"/> enum.</para>
        /// </summary>
        Max = 22
    }

    public enum ConeTwistJointParam : long
    {
        /// <summary>
        /// <para>Swing is rotation from side to side, around the axis perpendicular to the twist axis.</para>
        /// <para>The swing span defines, how much rotation will not get corrected along the swing axis.</para>
        /// <para>Could be defined as looseness in the <see cref="Godot.ConeTwistJoint3D"/>.</para>
        /// <para>If below 0.05, this behavior is locked.</para>
        /// </summary>
        SwingSpan = 0,
        /// <summary>
        /// <para>Twist is the rotation around the twist axis, this value defined how far the joint can twist.</para>
        /// <para>Twist is locked if below 0.05.</para>
        /// </summary>
        TwistSpan = 1,
        /// <summary>
        /// <para>The speed with which the swing or twist will take place.</para>
        /// <para>The higher, the faster.</para>
        /// </summary>
        Bias = 2,
        /// <summary>
        /// <para>The ease with which the Joint3D twists, if it's too low, it takes more force to twist the joint.</para>
        /// </summary>
        Softness = 3,
        /// <summary>
        /// <para>Defines, how fast the swing- and twist-speed-difference on both sides gets synced.</para>
        /// </summary>
        Relaxation = 4
    }

    public enum G6DofJointAxisParam : long
    {
        /// <summary>
        /// <para>The minimum difference between the pivot points' axes.</para>
        /// </summary>
        LinearLowerLimit = 0,
        /// <summary>
        /// <para>The maximum difference between the pivot points' axes.</para>
        /// </summary>
        LinearUpperLimit = 1,
        /// <summary>
        /// <para>A factor that gets applied to the movement across the axes. The lower, the slower the movement.</para>
        /// </summary>
        LinearLimitSoftness = 2,
        /// <summary>
        /// <para>The amount of restitution on the axes movement. The lower, the more velocity-energy gets lost.</para>
        /// </summary>
        LinearRestitution = 3,
        /// <summary>
        /// <para>The amount of damping that happens at the linear motion across the axes.</para>
        /// </summary>
        LinearDamping = 4,
        /// <summary>
        /// <para>The velocity that the joint's linear motor will attempt to reach.</para>
        /// </summary>
        LinearMotorTargetVelocity = 5,
        /// <summary>
        /// <para>The maximum force that the linear motor can apply while trying to reach the target velocity.</para>
        /// </summary>
        LinearMotorForceLimit = 6,
        LinearSpringStiffness = 7,
        LinearSpringDamping = 8,
        LinearSpringEquilibriumPoint = 9,
        /// <summary>
        /// <para>The minimum rotation in negative direction to break loose and rotate around the axes.</para>
        /// </summary>
        AngularLowerLimit = 10,
        /// <summary>
        /// <para>The minimum rotation in positive direction to break loose and rotate around the axes.</para>
        /// </summary>
        AngularUpperLimit = 11,
        /// <summary>
        /// <para>A factor that gets multiplied onto all rotations across the axes.</para>
        /// </summary>
        AngularLimitSoftness = 12,
        /// <summary>
        /// <para>The amount of rotational damping across the axes. The lower, the more damping occurs.</para>
        /// </summary>
        AngularDamping = 13,
        /// <summary>
        /// <para>The amount of rotational restitution across the axes. The lower, the more restitution occurs.</para>
        /// </summary>
        AngularRestitution = 14,
        /// <summary>
        /// <para>The maximum amount of force that can occur, when rotating around the axes.</para>
        /// </summary>
        AngularForceLimit = 15,
        /// <summary>
        /// <para>When correcting the crossing of limits in rotation across the axes, this error tolerance factor defines how much the correction gets slowed down. The lower, the slower.</para>
        /// </summary>
        AngularErp = 16,
        /// <summary>
        /// <para>Target speed for the motor at the axes.</para>
        /// </summary>
        AngularMotorTargetVelocity = 17,
        /// <summary>
        /// <para>Maximum acceleration for the motor at the axes.</para>
        /// </summary>
        AngularMotorForceLimit = 18,
        AngularSpringStiffness = 19,
        AngularSpringDamping = 20,
        AngularSpringEquilibriumPoint = 21,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.PhysicsServer3D.G6DofJointAxisParam"/> enum.</para>
        /// </summary>
        Max = 22
    }

    public enum G6DofJointAxisFlag : long
    {
        /// <summary>
        /// <para>If set, linear motion is possible within the given limits.</para>
        /// </summary>
        EnableLinearLimit = 0,
        /// <summary>
        /// <para>If set, rotational motion is possible.</para>
        /// </summary>
        EnableAngularLimit = 1,
        EnableAngularSpring = 2,
        EnableLinearSpring = 3,
        /// <summary>
        /// <para>If set, there is a rotational motor across these axes.</para>
        /// </summary>
        EnableMotor = 4,
        /// <summary>
        /// <para>If set, there is a linear motor on this axis that targets a specific velocity.</para>
        /// </summary>
        EnableLinearMotor = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.PhysicsServer3D.G6DofJointAxisFlag"/> enum.</para>
        /// </summary>
        Max = 6
    }

    public enum ShapeType : long
    {
        /// <summary>
        /// <para>Constant for creating a world boundary shape (used by the <see cref="Godot.WorldBoundaryShape3D"/> resource).</para>
        /// </summary>
        WorldBoundary = 0,
        /// <summary>
        /// <para>Constant for creating a separation ray shape (used by the <see cref="Godot.SeparationRayShape3D"/> resource).</para>
        /// </summary>
        SeparationRay = 1,
        /// <summary>
        /// <para>Constant for creating a sphere shape (used by the <see cref="Godot.SphereShape3D"/> resource).</para>
        /// </summary>
        Sphere = 2,
        /// <summary>
        /// <para>Constant for creating a box shape (used by the <see cref="Godot.BoxShape3D"/> resource).</para>
        /// </summary>
        Box = 3,
        /// <summary>
        /// <para>Constant for creating a capsule shape (used by the <see cref="Godot.CapsuleShape3D"/> resource).</para>
        /// </summary>
        Capsule = 4,
        /// <summary>
        /// <para>Constant for creating a cylinder shape (used by the <see cref="Godot.CylinderShape3D"/> resource).</para>
        /// </summary>
        Cylinder = 5,
        /// <summary>
        /// <para>Constant for creating a convex polygon shape (used by the <see cref="Godot.ConvexPolygonShape3D"/> resource).</para>
        /// </summary>
        ConvexPolygon = 6,
        /// <summary>
        /// <para>Constant for creating a concave polygon (trimesh) shape (used by the <see cref="Godot.ConcavePolygonShape3D"/> resource).</para>
        /// </summary>
        ConcavePolygon = 7,
        /// <summary>
        /// <para>Constant for creating a heightmap shape (used by the <see cref="Godot.HeightMapShape3D"/> resource).</para>
        /// </summary>
        Heightmap = 8,
        /// <summary>
        /// <para>Constant used internally for a soft body shape. Any attempt to create this kind of shape results in an error.</para>
        /// </summary>
        SoftBody = 9,
        /// <summary>
        /// <para>Constant used internally for a custom shape. Any attempt to create this kind of shape results in an error when using Godot Physics or Jolt Physics.</para>
        /// </summary>
        Custom = 10
    }

    public enum AreaParameter : long
    {
        /// <summary>
        /// <para>Constant to set/get gravity override mode in an area. See <see cref="Godot.PhysicsServer3D.AreaSpaceOverrideMode"/> for possible values.</para>
        /// </summary>
        GravityOverrideMode = 0,
        /// <summary>
        /// <para>Constant to set/get gravity strength in an area.</para>
        /// </summary>
        Gravity = 1,
        /// <summary>
        /// <para>Constant to set/get gravity vector/center in an area.</para>
        /// </summary>
        GravityVector = 2,
        /// <summary>
        /// <para>Constant to set/get whether the gravity vector of an area is a direction, or a center point.</para>
        /// </summary>
        GravityIsPoint = 3,
        /// <summary>
        /// <para>Constant to set/get the distance at which the gravity strength is equal to the gravity controlled by <see cref="Godot.PhysicsServer3D.AreaParameter.Gravity"/>. For example, on a planet 100 meters in radius with a surface gravity of 4.0 m/s², set the gravity to 4.0 and the unit distance to 100.0. The gravity will have falloff according to the inverse square law, so in the example, at 200 meters from the center the gravity will be 1.0 m/s² (twice the distance, 1/4th the gravity), at 50 meters it will be 16.0 m/s² (half the distance, 4x the gravity), and so on.</para>
        /// <para>The above is true only when the unit distance is a positive number. When this is set to 0.0, the gravity will be constant regardless of distance.</para>
        /// </summary>
        GravityPointUnitDistance = 4,
        /// <summary>
        /// <para>Constant to set/get linear damping override mode in an area. See <see cref="Godot.PhysicsServer3D.AreaSpaceOverrideMode"/> for possible values.</para>
        /// </summary>
        LinearDampOverrideMode = 5,
        /// <summary>
        /// <para>Constant to set/get the linear damping factor of an area.</para>
        /// </summary>
        LinearDamp = 6,
        /// <summary>
        /// <para>Constant to set/get angular damping override mode in an area. See <see cref="Godot.PhysicsServer3D.AreaSpaceOverrideMode"/> for possible values.</para>
        /// </summary>
        AngularDampOverrideMode = 7,
        /// <summary>
        /// <para>Constant to set/get the angular damping factor of an area.</para>
        /// </summary>
        AngularDamp = 8,
        /// <summary>
        /// <para>Constant to set/get the priority (order of processing) of an area.</para>
        /// </summary>
        Priority = 9,
        /// <summary>
        /// <para>Constant to set/get the magnitude of area-specific wind force. This wind force only applies to <see cref="Godot.SoftBody3D"/> nodes. Other physics bodies are currently not affected by wind.</para>
        /// </summary>
        WindForceMagnitude = 10,
        /// <summary>
        /// <para>Constant to set/get the 3D vector that specifies the origin from which an area-specific wind blows.</para>
        /// </summary>
        WindSource = 11,
        /// <summary>
        /// <para>Constant to set/get the 3D vector that specifies the direction in which an area-specific wind blows.</para>
        /// </summary>
        WindDirection = 12,
        /// <summary>
        /// <para>Constant to set/get the exponential rate at which wind force decreases with distance from its origin.</para>
        /// </summary>
        WindAttenuationFactor = 13
    }

    public enum AreaSpaceOverrideMode : long
    {
        /// <summary>
        /// <para>This area does not affect gravity/damp. These are generally areas that exist only to detect collisions, and objects entering or exiting them.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>This area adds its gravity/damp values to whatever has been calculated so far. This way, many overlapping areas can combine their physics to make interesting effects.</para>
        /// </summary>
        Combine = 1,
        /// <summary>
        /// <para>This area adds its gravity/damp values to whatever has been calculated so far. Then stops taking into account the rest of the areas, even the default one.</para>
        /// </summary>
        CombineReplace = 2,
        /// <summary>
        /// <para>This area replaces any gravity/damp, even the default one, and stops taking into account the rest of the areas.</para>
        /// </summary>
        Replace = 3,
        /// <summary>
        /// <para>This area replaces any gravity/damp calculated so far, but keeps calculating the rest of the areas, down to the default one.</para>
        /// </summary>
        ReplaceCombine = 4
    }

    public enum BodyMode : long
    {
        /// <summary>
        /// <para>Constant for static bodies. In this mode, a body can be only moved by user code and doesn't collide with other bodies along its path when moved.</para>
        /// </summary>
        Static = 0,
        /// <summary>
        /// <para>Constant for kinematic bodies. In this mode, a body can be only moved by user code and collides with other bodies along its path.</para>
        /// </summary>
        Kinematic = 1,
        /// <summary>
        /// <para>Constant for rigid bodies. In this mode, a body can be pushed by other bodies and has forces applied.</para>
        /// </summary>
        Rigid = 2,
        /// <summary>
        /// <para>Constant for linear rigid bodies. In this mode, a body can not rotate, and only its linear velocity is affected by external forces.</para>
        /// </summary>
        RigidLinear = 3
    }

    public enum BodyParameter : long
    {
        /// <summary>
        /// <para>Constant to set/get a body's bounce factor.</para>
        /// </summary>
        Bounce = 0,
        /// <summary>
        /// <para>Constant to set/get a body's friction.</para>
        /// </summary>
        Friction = 1,
        /// <summary>
        /// <para>Constant to set/get a body's mass.</para>
        /// </summary>
        Mass = 2,
        /// <summary>
        /// <para>Constant to set/get a body's inertia.</para>
        /// </summary>
        Inertia = 3,
        /// <summary>
        /// <para>Constant to set/get a body's center of mass position in the body's local coordinate system.</para>
        /// </summary>
        CenterOfMass = 4,
        /// <summary>
        /// <para>Constant to set/get a body's gravity multiplier.</para>
        /// </summary>
        GravityScale = 5,
        /// <summary>
        /// <para>Constant to set/get a body's linear damping mode. See <see cref="Godot.PhysicsServer3D.BodyDampMode"/> for possible values.</para>
        /// </summary>
        LinearDampMode = 6,
        /// <summary>
        /// <para>Constant to set/get a body's angular damping mode. See <see cref="Godot.PhysicsServer3D.BodyDampMode"/> for possible values.</para>
        /// </summary>
        AngularDampMode = 7,
        /// <summary>
        /// <para>Constant to set/get a body's linear damping factor.</para>
        /// </summary>
        LinearDamp = 8,
        /// <summary>
        /// <para>Constant to set/get a body's angular damping factor.</para>
        /// </summary>
        AngularDamp = 9,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.PhysicsServer3D.BodyParameter"/> enum.</para>
        /// </summary>
        Max = 10
    }

    public enum BodyDampMode : long
    {
        /// <summary>
        /// <para>The body's damping value is added to any value set in areas or the default value.</para>
        /// </summary>
        Combine = 0,
        /// <summary>
        /// <para>The body's damping value replaces any value set in areas or the default value.</para>
        /// </summary>
        Replace = 1
    }

    public enum BodyState : long
    {
        /// <summary>
        /// <para>Constant to set/get the current transform matrix of the body.</para>
        /// </summary>
        Transform = 0,
        /// <summary>
        /// <para>Constant to set/get the current linear velocity of the body.</para>
        /// </summary>
        LinearVelocity = 1,
        /// <summary>
        /// <para>Constant to set/get the current angular velocity of the body.</para>
        /// </summary>
        AngularVelocity = 2,
        /// <summary>
        /// <para>Constant to sleep/wake up a body, or to get whether it is sleeping.</para>
        /// </summary>
        Sleeping = 3,
        /// <summary>
        /// <para>Constant to set/get whether the body can sleep.</para>
        /// </summary>
        CanSleep = 4
    }

    public enum AreaBodyStatus : long
    {
        /// <summary>
        /// <para>The value of the first parameter and area callback function receives, when an object enters one of its shapes.</para>
        /// </summary>
        Added = 0,
        /// <summary>
        /// <para>The value of the first parameter and area callback function receives, when an object exits one of its shapes.</para>
        /// </summary>
        Removed = 1
    }

    public enum ProcessInfo : long
    {
        /// <summary>
        /// <para>Constant to get the number of objects that are not sleeping.</para>
        /// </summary>
        ActiveObjects = 0,
        /// <summary>
        /// <para>Constant to get the number of possible collisions.</para>
        /// </summary>
        CollisionPairs = 1,
        /// <summary>
        /// <para>Constant to get the number of space regions where a collision could occur.</para>
        /// </summary>
        IslandCount = 2
    }

    public enum SpaceParameter : long
    {
        /// <summary>
        /// <para>Constant to set/get the maximum distance a pair of bodies has to move before their collision status has to be recalculated.</para>
        /// </summary>
        ContactRecycleRadius = 0,
        /// <summary>
        /// <para>Constant to set/get the maximum distance a shape can be from another before they are considered separated and the contact is discarded.</para>
        /// </summary>
        ContactMaxSeparation = 1,
        /// <summary>
        /// <para>Constant to set/get the maximum distance a shape can penetrate another shape before it is considered a collision.</para>
        /// </summary>
        ContactMaxAllowedPenetration = 2,
        /// <summary>
        /// <para>Constant to set/get the default solver bias for all physics contacts. A solver bias is a factor controlling how much two objects "rebound", after overlapping, to avoid leaving them in that state because of numerical imprecision.</para>
        /// </summary>
        ContactDefaultBias = 3,
        /// <summary>
        /// <para>Constant to set/get the threshold linear velocity of activity. A body marked as potentially inactive for both linear and angular velocity will be put to sleep after the time given.</para>
        /// </summary>
        BodyLinearVelocitySleepThreshold = 4,
        /// <summary>
        /// <para>Constant to set/get the threshold angular velocity of activity. A body marked as potentially inactive for both linear and angular velocity will be put to sleep after the time given.</para>
        /// </summary>
        BodyAngularVelocitySleepThreshold = 5,
        /// <summary>
        /// <para>Constant to set/get the maximum time of activity. A body marked as potentially inactive for both linear and angular velocity will be put to sleep after this time.</para>
        /// </summary>
        BodyTimeToSleep = 6,
        /// <summary>
        /// <para>Constant to set/get the number of solver iterations for contacts and constraints. The greater the number of iterations, the more accurate the collisions and constraints will be. However, a greater number of iterations requires more CPU power, which can decrease performance.</para>
        /// </summary>
        SolverIterations = 7
    }

    public enum BodyAxis : long
    {
        LinearX = 1,
        LinearY = 2,
        LinearZ = 4,
        AngularX = 8,
        AngularY = 16,
        AngularZ = 32
    }

    private static readonly StringName NativeName = "PhysicsServer3D";

    private static PhysicsServer3DInstance singleton;

    public static PhysicsServer3DInstance Singleton =>
        singleton ??= (PhysicsServer3DInstance)InteropUtils.EngineGetSingleton("PhysicsServer3D");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WorldBoundaryShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D world boundary shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the shape's normal direction and distance properties.</para>
    /// </summary>
    public static Rid WorldBoundaryShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SeparationRayShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D separation ray shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the shape's <c>length</c> and <c>slide_on_slope</c> properties.</para>
    /// </summary>
    public static Rid SeparationRayShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SphereShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D sphere shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the sphere's radius.</para>
    /// </summary>
    public static Rid SphereShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BoxShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D box shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the box's half-extents.</para>
    /// </summary>
    public static Rid BoxShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind3, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CapsuleShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D capsule shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the capsule's height and radius.</para>
    /// </summary>
    public static Rid CapsuleShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind4, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CylinderShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D cylinder shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the cylinder's height and radius.</para>
    /// </summary>
    public static Rid CylinderShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind5, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvexPolygonShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D convex polygon shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the convex polygon's points.</para>
    /// </summary>
    public static Rid ConvexPolygonShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind6, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ConcavePolygonShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D concave polygon shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the concave polygon's triangles.</para>
    /// </summary>
    public static Rid ConcavePolygonShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind7, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HeightmapShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D heightmap shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the heightmap's data.</para>
    /// </summary>
    public static Rid HeightmapShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind8, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CustomShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a custom shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> to set the shape's data.</para>
    /// <para><b>Note:</b> Custom shapes are not supported by the built-in physics servers, so calling this method always produces an error when using Godot Physics or Jolt Physics. Custom physics servers implemented as GDExtensions may support a custom shape.</para>
    /// </summary>
    public static Rid CustomShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind9, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeSetData, 3175752987ul);

    /// <summary>
    /// <para>Sets the shape data that configures the shape. The <paramref name="data"/> to be passed depends on the shape's type (see <see cref="Godot.PhysicsServer3D.ShapeGetType(Rid)"/>):</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.WorldBoundary"/>: a <see cref="Godot.Plane"/>,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.SeparationRay"/>: a dictionary containing the key <c>"length"</c> with a <see cref="float"/> value and the key <c>"slide_on_slope"</c> with a <see cref="bool"/> value,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Sphere"/>: a <see cref="float"/> that is the radius of the sphere,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Box"/>: a <see cref="Godot.Vector3"/> containing the half-extents of the box,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Capsule"/>: a dictionary containing the keys <c>"height"</c> and <c>"radius"</c> with <see cref="float"/> values,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Cylinder"/>: a dictionary containing the keys <c>"height"</c> and <c>"radius"</c> with <see cref="float"/> values,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.ConvexPolygon"/>: a <see cref="Godot.Vector3"/>[] of points defining a convex polygon (the shape will be the convex hull of the points),</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.ConcavePolygon"/>: a dictionary containing the key <c>"faces"</c> with a <see cref="Godot.Vector3"/>[] value (with a length divisible by 3, so that each 3-tuple of points forms a face) and the key <c>"backface_collision"</c> with a <see cref="bool"/> value,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Heightmap"/>: a dictionary containing the keys <c>"width"</c> and <c>"depth"</c> with <see cref="int"/> values, and the key <c>"heights"</c> with a value that is a packed array of <see cref="float"/>s of length <c>width * depth</c> (that is a <see cref="float"/>[], or a <see cref="double"/>[] if Godot was compiled with the <c>precision=double</c> option), and optionally the keys <c>"min_height"</c> and <c>"max_height"</c> with <see cref="float"/> values,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.SoftBody"/>: the input <paramref name="data"/> is ignored and this method has no effect,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Custom"/>: the input <paramref name="data"/> is interpreted by a custom physics server, if it supports custom shapes.</para>
    /// </summary>
    public static void ShapeSetData(Rid shape, Variant data)
    {
        NativeCalls.godot_icall_2_422(MethodBind10, GodotObject.GetPtr(Singleton), shape, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeSetMargin, 1794382983ul);

    /// <summary>
    /// <para>Sets the collision margin for the shape.</para>
    /// <para><b>Note:</b> This is not used in Godot Physics.</para>
    /// </summary>
    public static void ShapeSetMargin(Rid shape, float margin)
    {
        NativeCalls.godot_icall_2_816(MethodBind11, GodotObject.GetPtr(Singleton), shape, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetType, 3418923367ul);

    /// <summary>
    /// <para>Returns the shape's type.</para>
    /// </summary>
    public static PhysicsServer3D.ShapeType ShapeGetType(Rid shape)
    {
        return (PhysicsServer3D.ShapeType)NativeCalls.godot_icall_1_835(MethodBind12, GodotObject.GetPtr(Singleton), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetData, 4171304767ul);

    /// <summary>
    /// <para>Returns the shape data that configures the shape, such as the half-extents of a box or the triangles of a concave (trimesh) shape. See <see cref="Godot.PhysicsServer3D.ShapeSetData(Rid, Variant)"/> for the precise format of this data in each case.</para>
    /// </summary>
    public static Variant ShapeGetData(Rid shape)
    {
        return NativeCalls.godot_icall_1_423(MethodBind13, GodotObject.GetPtr(Singleton), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetMargin, 866169185ul);

    /// <summary>
    /// <para>Returns the collision margin for the shape.</para>
    /// <para><b>Note:</b> This is not used in Godot Physics, so will always return <c>0</c>.</para>
    /// </summary>
    public static float ShapeGetMargin(Rid shape)
    {
        return NativeCalls.godot_icall_1_817(MethodBind14, GodotObject.GetPtr(Singleton), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a space. A space is a collection of parameters for the physics engine that can be assigned to an area or a body. It can be assigned to an area with <see cref="Godot.PhysicsServer3D.AreaSetSpace(Rid, Rid)"/>, or to a body with <see cref="Godot.PhysicsServer3D.BodySetSpace(Rid, Rid)"/>.</para>
    /// </summary>
    public static Rid SpaceCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind15, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceSetActive, 1265174801ul);

    /// <summary>
    /// <para>Marks a space as active. It will not have an effect, unless it is assigned to an area or body.</para>
    /// </summary>
    public static void SpaceSetActive(Rid space, bool active)
    {
        NativeCalls.godot_icall_2_434(MethodBind16, GodotObject.GetPtr(Singleton), space, active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceIsActive, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the space is active.</para>
    /// </summary>
    public static bool SpaceIsActive(Rid space)
    {
        return NativeCalls.godot_icall_1_421(MethodBind17, GodotObject.GetPtr(Singleton), space).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceSetParam, 2406017470ul);

    /// <summary>
    /// <para>Sets the value for a space parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.SpaceParameter"/> constants.</para>
    /// </summary>
    public static void SpaceSetParam(Rid space, PhysicsServer3D.SpaceParameter param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind18, GodotObject.GetPtr(Singleton), space, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceGetParam, 1523206731ul);

    /// <summary>
    /// <para>Returns the value of a space parameter.</para>
    /// </summary>
    public static float SpaceGetParam(Rid space, PhysicsServer3D.SpaceParameter param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind19, GodotObject.GetPtr(Singleton), space, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceGetDirectState, 2048616813ul);

    /// <summary>
    /// <para>Returns the state of a space, a <see cref="Godot.PhysicsDirectSpaceState3D"/>. This object can be used to make collision/intersection queries.</para>
    /// </summary>
    public static PhysicsDirectSpaceState3D SpaceGetDirectState(Rid space)
    {
        return (PhysicsDirectSpaceState3D)NativeCalls.godot_icall_1_938(MethodBind20, GodotObject.GetPtr(Singleton), space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D area object in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. The default settings for the created area include a collision layer and mask set to <c>1</c>, and <c>monitorable</c> set to <see langword="false"/>.</para>
    /// <para>Use <see cref="Godot.PhysicsServer3D.AreaAddShape(Rid, Rid, Nullable{Transform3D}, bool)"/> to add shapes to it, use <see cref="Godot.PhysicsServer3D.AreaSetTransform(Rid, Transform3D)"/> to set its transform, and use <see cref="Godot.PhysicsServer3D.AreaSetSpace(Rid, Rid)"/> to add the area to a space. If you want the area to be detectable use <see cref="Godot.PhysicsServer3D.AreaSetMonitorable(Rid, bool)"/>.</para>
    /// </summary>
    public static Rid AreaCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind21, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetSpace, 395945892ul);

    /// <summary>
    /// <para>Assigns a space to the area.</para>
    /// </summary>
    public static void AreaSetSpace(Rid area, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind22, GodotObject.GetPtr(Singleton), area, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the space assigned to the area.</para>
    /// </summary>
    public static Rid AreaGetSpace(Rid area)
    {
        return NativeCalls.godot_icall_1_855(MethodBind23, GodotObject.GetPtr(Singleton), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaAddShape, 3711419014ul);

    /// <summary>
    /// <para>Adds a shape to the area, along with a transform matrix. Shapes are usually referenced by their index, so you should track which shape has a given index.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform3D.Identity</c>.</param>
    public static unsafe void AreaAddShape(Rid area, Rid shape, Nullable<Transform3D> transform = null, bool disabled = false)
    {
        Transform3D transformOrDefVal = transform.HasValue ? transform.Value : Transform3D.Identity;
        NativeCalls.godot_icall_4_1000(MethodBind24, GodotObject.GetPtr(Singleton), area, shape, &transformOrDefVal, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShape, 2310537182ul);

    /// <summary>
    /// <para>Substitutes a given area shape by another. The old shape is selected by its index, the new one by its <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void AreaSetShape(Rid area, int shapeIdx, Rid shape)
    {
        NativeCalls.godot_icall_3_833(MethodBind25, GodotObject.GetPtr(Singleton), area, shapeIdx, shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShapeTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the transform matrix for an area shape.</para>
    /// </summary>
    public static unsafe void AreaSetShapeTransform(Rid area, int shapeIdx, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind26, GodotObject.GetPtr(Singleton), area, shapeIdx, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShapeDisabled, 2658558584ul);

    public static void AreaSetShapeDisabled(Rid area, int shapeIdx, bool disabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind27, GodotObject.GetPtr(Singleton), area, shapeIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of shapes assigned to an area.</para>
    /// </summary>
    public static int AreaGetShapeCount(Rid area)
    {
        return NativeCalls.godot_icall_1_835(MethodBind28, GodotObject.GetPtr(Singleton), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShape, 1066463050ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the nth shape of an area.</para>
    /// </summary>
    public static Rid AreaGetShape(Rid area, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_830(MethodBind29, GodotObject.GetPtr(Singleton), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShapeTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the transform matrix of a shape within an area.</para>
    /// </summary>
    public static Transform3D AreaGetShapeTransform(Rid area, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind30, GodotObject.GetPtr(Singleton), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaRemoveShape, 3411492887ul);

    /// <summary>
    /// <para>Removes a shape from an area. It does not delete the shape, so it can be reassigned later.</para>
    /// </summary>
    public static void AreaRemoveShape(Rid area, int shapeIdx)
    {
        NativeCalls.godot_icall_2_426(MethodBind31, GodotObject.GetPtr(Singleton), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaClearShapes, 2722037293ul);

    /// <summary>
    /// <para>Removes all shapes from an area. It does not delete the shapes, so they can be reassigned later.</para>
    /// </summary>
    public static void AreaClearShapes(Rid area)
    {
        NativeCalls.godot_icall_1_286(MethodBind32, GodotObject.GetPtr(Singleton), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Assigns the area to one or many physics layers.</para>
    /// </summary>
    public static void AreaSetCollisionLayer(Rid area, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind33, GodotObject.GetPtr(Singleton), area, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers an area belongs to.</para>
    /// </summary>
    public static uint AreaGetCollisionLayer(Rid area)
    {
        return NativeCalls.godot_icall_1_850(MethodBind34, GodotObject.GetPtr(Singleton), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets which physics layers the area will monitor.</para>
    /// </summary>
    public static void AreaSetCollisionMask(Rid area, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind35, GodotObject.GetPtr(Singleton), area, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers an area can contact with.</para>
    /// </summary>
    public static uint AreaGetCollisionMask(Rid area)
    {
        return NativeCalls.godot_icall_1_850(MethodBind36, GodotObject.GetPtr(Singleton), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetParam, 2980114638ul);

    /// <summary>
    /// <para>Sets the value for an area parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.AreaParameter"/> constants.</para>
    /// </summary>
    public static void AreaSetParam(Rid area, PhysicsServer3D.AreaParameter param, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind37, GodotObject.GetPtr(Singleton), area, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the transform matrix for an area.</para>
    /// </summary>
    public static unsafe void AreaSetTransform(Rid area, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind38, GodotObject.GetPtr(Singleton), area, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetParam, 890056067ul);

    /// <summary>
    /// <para>Returns an area parameter value. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.AreaParameter"/> constants.</para>
    /// </summary>
    public static Variant AreaGetParam(Rid area, PhysicsServer3D.AreaParameter param)
    {
        return NativeCalls.godot_icall_2_828(MethodBind39, GodotObject.GetPtr(Singleton), area, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetTransform, 1128465797ul);

    /// <summary>
    /// <para>Returns the transform matrix for an area.</para>
    /// </summary>
    public static Transform3D AreaGetTransform(Rid area)
    {
        return NativeCalls.godot_icall_1_874(MethodBind40, GodotObject.GetPtr(Singleton), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Assigns the area to a descendant of <see cref="Godot.GodotObject"/>, so it can exist in the node tree.</para>
    /// </summary>
    public static void AreaAttachObjectInstanceId(Rid area, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind41, GodotObject.GetPtr(Singleton), area, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetObjectInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Gets the instance ID of the object the area is assigned to.</para>
    /// </summary>
    public static ulong AreaGetObjectInstanceId(Rid area)
    {
        return NativeCalls.godot_icall_1_853(MethodBind42, GodotObject.GetPtr(Singleton), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetMonitorCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the area's body monitor callback. This callback will be called when any other (shape of a) body enters or exits (a shape of) the given area, and must take the following five parameters:</para>
    /// <para>1. an integer <c>status</c>: either <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Added"/> or <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Removed"/> depending on whether the other body shape entered or exited the area,</para>
    /// <para>2. an <see cref="Godot.Rid"/> <c>body_rid</c>: the <see cref="Godot.Rid"/> of the body that entered or exited the area,</para>
    /// <para>3. an integer <c>instance_id</c>: the <c>ObjectID</c> attached to the body,</para>
    /// <para>4. an integer <c>body_shape_idx</c>: the index of the shape of the body that entered or exited the area,</para>
    /// <para>5. an integer <c>self_shape_idx</c>: the index of the shape of the area where the body entered or exited.</para>
    /// <para>By counting (or keeping track of) the shapes that enter and exit, it can be determined if a body (with all its shapes) is entering for the first time or exiting for the last time.</para>
    /// </summary>
    public static void AreaSetMonitorCallback(Rid area, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind43, GodotObject.GetPtr(Singleton), area, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetAreaMonitorCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the area's area monitor callback. This callback will be called when any other (shape of an) area enters or exits (a shape of) the given area, and must take the following five parameters:</para>
    /// <para>1. an integer <c>status</c>: either <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Added"/> or <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Removed"/> depending on whether the other area's shape entered or exited the area,</para>
    /// <para>2. an <see cref="Godot.Rid"/> <c>area_rid</c>: the <see cref="Godot.Rid"/> of the other area that entered or exited the area,</para>
    /// <para>3. an integer <c>instance_id</c>: the <c>ObjectID</c> attached to the other area,</para>
    /// <para>4. an integer <c>area_shape_idx</c>: the index of the shape of the other area that entered or exited the area,</para>
    /// <para>5. an integer <c>self_shape_idx</c>: the index of the shape of the area where the other area entered or exited.</para>
    /// <para>By counting (or keeping track of) the shapes that enter and exit, it can be determined if an area (with all its shapes) is entering for the first time or exiting for the last time.</para>
    /// </summary>
    public static void AreaSetAreaMonitorCallback(Rid area, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind44, GodotObject.GetPtr(Singleton), area, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetMonitorable, 1265174801ul);

    public static void AreaSetMonitorable(Rid area, bool monitorable)
    {
        NativeCalls.godot_icall_2_434(MethodBind45, GodotObject.GetPtr(Singleton), area, monitorable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetRayPickable, 1265174801ul);

    /// <summary>
    /// <para>Sets object pickable with rays.</para>
    /// </summary>
    public static void AreaSetRayPickable(Rid area, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind46, GodotObject.GetPtr(Singleton), area, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D body object in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. The default settings for the created area include a collision layer and mask set to <c>1</c>, and body mode set to <see cref="Godot.PhysicsServer3D.BodyMode.Rigid"/>.</para>
    /// <para>Use <see cref="Godot.PhysicsServer3D.BodyAddShape(Rid, Rid, Nullable{Transform3D}, bool)"/> to add shapes to it, use <see cref="Godot.PhysicsServer3D.BodySetState(Rid, PhysicsServer3D.BodyState, Variant)"/> to set its transform, and use <see cref="Godot.PhysicsServer3D.BodySetSpace(Rid, Rid)"/> to add the body to a space.</para>
    /// </summary>
    public static Rid BodyCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind47, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetSpace, 395945892ul);

    /// <summary>
    /// <para>Assigns a space to the body (see <see cref="Godot.PhysicsServer3D.SpaceCreate()"/>).</para>
    /// </summary>
    public static void BodySetSpace(Rid body, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind48, GodotObject.GetPtr(Singleton), body, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the space assigned to a body.</para>
    /// </summary>
    public static Rid BodyGetSpace(Rid body)
    {
        return NativeCalls.godot_icall_1_855(MethodBind49, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetMode, 606803466ul);

    /// <summary>
    /// <para>Sets the body mode.</para>
    /// </summary>
    public static void BodySetMode(Rid body, PhysicsServer3D.BodyMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind50, GodotObject.GetPtr(Singleton), body, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetMode, 2488819728ul);

    /// <summary>
    /// <para>Returns the body mode.</para>
    /// </summary>
    public static PhysicsServer3D.BodyMode BodyGetMode(Rid body)
    {
        return (PhysicsServer3D.BodyMode)NativeCalls.godot_icall_1_835(MethodBind51, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers a body belongs to.</para>
    /// </summary>
    public static void BodySetCollisionLayer(Rid body, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind52, GodotObject.GetPtr(Singleton), body, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers a body belongs to.</para>
    /// </summary>
    public static uint BodyGetCollisionLayer(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind53, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers a body can collide with.</para>
    /// </summary>
    public static void BodySetCollisionMask(Rid body, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind54, GodotObject.GetPtr(Singleton), body, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers a body can collide with.</para>
    /// </summary>
    public static uint BodyGetCollisionMask(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind55, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionPriority, 1794382983ul);

    /// <summary>
    /// <para>Sets the body's collision priority.</para>
    /// </summary>
    public static void BodySetCollisionPriority(Rid body, float priority)
    {
        NativeCalls.godot_icall_2_816(MethodBind56, GodotObject.GetPtr(Singleton), body, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionPriority, 866169185ul);

    /// <summary>
    /// <para>Returns the body's collision priority.</para>
    /// </summary>
    public static float BodyGetCollisionPriority(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind57, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddShape, 3711419014ul);

    /// <summary>
    /// <para>Adds a shape to the body, along with a transform matrix. Shapes are usually referenced by their index, so you should track which shape has a given index.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform3D.Identity</c>.</param>
    public static unsafe void BodyAddShape(Rid body, Rid shape, Nullable<Transform3D> transform = null, bool disabled = false)
    {
        Transform3D transformOrDefVal = transform.HasValue ? transform.Value : Transform3D.Identity;
        NativeCalls.godot_icall_4_1000(MethodBind58, GodotObject.GetPtr(Singleton), body, shape, &transformOrDefVal, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShape, 2310537182ul);

    /// <summary>
    /// <para>Substitutes a given body shape by another. The old shape is selected by its index, the new one by its <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void BodySetShape(Rid body, int shapeIdx, Rid shape)
    {
        NativeCalls.godot_icall_3_833(MethodBind59, GodotObject.GetPtr(Singleton), body, shapeIdx, shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShapeTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the transform matrix for a body shape.</para>
    /// </summary>
    public static unsafe void BodySetShapeTransform(Rid body, int shapeIdx, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind60, GodotObject.GetPtr(Singleton), body, shapeIdx, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShapeDisabled, 2658558584ul);

    public static void BodySetShapeDisabled(Rid body, int shapeIdx, bool disabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind61, GodotObject.GetPtr(Singleton), body, shapeIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of shapes assigned to a body.</para>
    /// </summary>
    public static int BodyGetShapeCount(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind62, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShape, 1066463050ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the nth shape of a body.</para>
    /// </summary>
    public static Rid BodyGetShape(Rid body, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_830(MethodBind63, GodotObject.GetPtr(Singleton), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShapeTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the transform matrix of a body shape.</para>
    /// </summary>
    public static Transform3D BodyGetShapeTransform(Rid body, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind64, GodotObject.GetPtr(Singleton), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyRemoveShape, 3411492887ul);

    /// <summary>
    /// <para>Removes a shape from a body. The shape is not deleted, so it can be reused afterwards.</para>
    /// </summary>
    public static void BodyRemoveShape(Rid body, int shapeIdx)
    {
        NativeCalls.godot_icall_2_426(MethodBind65, GodotObject.GetPtr(Singleton), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyClearShapes, 2722037293ul);

    /// <summary>
    /// <para>Removes all shapes from a body.</para>
    /// </summary>
    public static void BodyClearShapes(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind66, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Assigns the area to a descendant of <see cref="Godot.GodotObject"/>, so it can exist in the node tree.</para>
    /// </summary>
    public static void BodyAttachObjectInstanceId(Rid body, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind67, GodotObject.GetPtr(Singleton), body, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetObjectInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Gets the instance ID of the object the area is assigned to.</para>
    /// </summary>
    public static ulong BodyGetObjectInstanceId(Rid body)
    {
        return NativeCalls.godot_icall_1_853(MethodBind68, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetEnableContinuousCollisionDetection, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the continuous collision detection mode is enabled.</para>
    /// <para>Continuous collision detection tries to predict where a moving body will collide, instead of moving it and correcting its movement if it collided.</para>
    /// </summary>
    public static void BodySetEnableContinuousCollisionDetection(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind69, GodotObject.GetPtr(Singleton), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyIsContinuousCollisionDetectionEnabled, 4155700596ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the continuous collision detection mode is enabled.</para>
    /// </summary>
    public static bool BodyIsContinuousCollisionDetectionEnabled(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind70, GodotObject.GetPtr(Singleton), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetParam, 910941953ul);

    /// <summary>
    /// <para>Sets a body parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.BodyParameter"/> constants.</para>
    /// </summary>
    public static void BodySetParam(Rid body, PhysicsServer3D.BodyParameter param, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind71, GodotObject.GetPtr(Singleton), body, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetParam, 3385027841ul);

    /// <summary>
    /// <para>Returns the value of a body parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.BodyParameter"/> constants.</para>
    /// </summary>
    public static Variant BodyGetParam(Rid body, PhysicsServer3D.BodyParameter param)
    {
        return NativeCalls.godot_icall_2_828(MethodBind72, GodotObject.GetPtr(Singleton), body, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyResetMassProperties, 2722037293ul);

    /// <summary>
    /// <para>Restores the default inertia and center of mass based on shapes to cancel any custom values previously set using <see cref="Godot.PhysicsServer3D.BodySetParam(Rid, PhysicsServer3D.BodyParameter, Variant)"/>.</para>
    /// </summary>
    public static void BodyResetMassProperties(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind73, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetState, 599977762ul);

    /// <summary>
    /// <para>Sets a body state.</para>
    /// </summary>
    public static void BodySetState(Rid body, PhysicsServer3D.BodyState state, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind74, GodotObject.GetPtr(Singleton), body, (int)state, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetState, 1850449534ul);

    /// <summary>
    /// <para>Returns a body state.</para>
    /// </summary>
    public static Variant BodyGetState(Rid body, PhysicsServer3D.BodyState state)
    {
        return NativeCalls.godot_icall_2_828(MethodBind75, GodotObject.GetPtr(Singleton), body, (int)state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyCentralImpulse, 3227306858ul);

    /// <summary>
    /// <para>Applies a directional impulse without affecting rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer3D.BodyApplyImpulse(Rid, Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public static unsafe void BodyApplyCentralImpulse(Rid body, Vector3 impulse)
    {
        NativeCalls.godot_icall_2_865(MethodBind76, GodotObject.GetPtr(Singleton), body, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyImpulse, 390416203ul);

    /// <summary>
    /// <para>Applies a positioned impulse to the body.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public static unsafe void BodyApplyImpulse(Rid body, Vector3 impulse, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_3_1003(MethodBind77, GodotObject.GetPtr(Singleton), body, &impulse, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyTorqueImpulse, 3227306858ul);

    /// <summary>
    /// <para>Applies a rotational impulse to the body without affecting the position.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public static unsafe void BodyApplyTorqueImpulse(Rid body, Vector3 impulse)
    {
        NativeCalls.godot_icall_2_865(MethodBind78, GodotObject.GetPtr(Singleton), body, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyCentralForce, 3227306858ul);

    /// <summary>
    /// <para>Applies a directional force without affecting rotation. A force is time dependent and meant to be applied every physics update.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer3D.BodyApplyForce(Rid, Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public static unsafe void BodyApplyCentralForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind79, GodotObject.GetPtr(Singleton), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyForce, 390416203ul);

    /// <summary>
    /// <para>Applies a positioned force to the body. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public static unsafe void BodyApplyForce(Rid body, Vector3 force, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_3_1003(MethodBind80, GodotObject.GetPtr(Singleton), body, &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyTorque, 3227306858ul);

    /// <summary>
    /// <para>Applies a rotational force without affecting position. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public static unsafe void BodyApplyTorque(Rid body, Vector3 torque)
    {
        NativeCalls.godot_icall_2_865(MethodBind81, GodotObject.GetPtr(Singleton), body, &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantCentralForce, 3227306858ul);

    /// <summary>
    /// <para>Adds a constant directional force without affecting rotation that keeps being applied over time until cleared with <c>body_set_constant_force(body, Vector3(0, 0, 0))</c>.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer3D.BodyAddConstantForce(Rid, Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public static unsafe void BodyAddConstantCentralForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind82, GodotObject.GetPtr(Singleton), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantForce, 390416203ul);

    /// <summary>
    /// <para>Adds a constant positioned force to the body that keeps being applied over time until cleared with <c>body_set_constant_force(body, Vector3(0, 0, 0))</c>.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public static unsafe void BodyAddConstantForce(Rid body, Vector3 force, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_3_1003(MethodBind83, GodotObject.GetPtr(Singleton), body, &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantTorque, 3227306858ul);

    /// <summary>
    /// <para>Adds a constant rotational force without affecting position that keeps being applied over time until cleared with <c>body_set_constant_torque(body, Vector3(0, 0, 0))</c>.</para>
    /// </summary>
    public static unsafe void BodyAddConstantTorque(Rid body, Vector3 torque)
    {
        NativeCalls.godot_icall_2_865(MethodBind84, GodotObject.GetPtr(Singleton), body, &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetConstantForce, 3227306858ul);

    /// <summary>
    /// <para>Sets the body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3D.BodyAddConstantForce(Rid, Vector3, Nullable{Vector3})"/> and <see cref="Godot.PhysicsServer3D.BodyAddConstantCentralForce(Rid, Vector3)"/>.</para>
    /// </summary>
    public static unsafe void BodySetConstantForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind85, GodotObject.GetPtr(Singleton), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetConstantForce, 531438156ul);

    /// <summary>
    /// <para>Returns the body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3D.BodyAddConstantForce(Rid, Vector3, Nullable{Vector3})"/> and <see cref="Godot.PhysicsServer3D.BodyAddConstantCentralForce(Rid, Vector3)"/>.</para>
    /// </summary>
    public static Vector3 BodyGetConstantForce(Rid body)
    {
        return NativeCalls.godot_icall_1_866(MethodBind86, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetConstantTorque, 3227306858ul);

    /// <summary>
    /// <para>Sets the body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3D.BodyAddConstantTorque(Rid, Vector3)"/>.</para>
    /// </summary>
    public static unsafe void BodySetConstantTorque(Rid body, Vector3 torque)
    {
        NativeCalls.godot_icall_2_865(MethodBind87, GodotObject.GetPtr(Singleton), body, &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetConstantTorque, 531438156ul);

    /// <summary>
    /// <para>Returns the body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3D.BodyAddConstantTorque(Rid, Vector3)"/>.</para>
    /// </summary>
    public static Vector3 BodyGetConstantTorque(Rid body)
    {
        return NativeCalls.godot_icall_1_866(MethodBind88, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetAxisVelocity, 3227306858ul);

    /// <summary>
    /// <para>Sets an axis velocity. The velocity in the given vector axis will be set as the given vector length. This is useful for jumping behavior.</para>
    /// </summary>
    public static unsafe void BodySetAxisVelocity(Rid body, Vector3 axisVelocity)
    {
        NativeCalls.godot_icall_2_865(MethodBind89, GodotObject.GetPtr(Singleton), body, &axisVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetAxisLock, 2020836892ul);

    public static void BodySetAxisLock(Rid body, PhysicsServer3D.BodyAxis axis, bool @lock)
    {
        NativeCalls.godot_icall_3_439(MethodBind90, GodotObject.GetPtr(Singleton), body, (int)axis, @lock.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyIsAxisLocked, 587853580ul);

    public static bool BodyIsAxisLocked(Rid body, PhysicsServer3D.BodyAxis axis)
    {
        return NativeCalls.godot_icall_2_826(MethodBind91, GodotObject.GetPtr(Singleton), body, (int)axis).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddCollisionException, 395945892ul);

    /// <summary>
    /// <para>Adds a body to the list of bodies exempt from collisions.</para>
    /// </summary>
    public static void BodyAddCollisionException(Rid body, Rid exceptedBody)
    {
        NativeCalls.godot_icall_2_430(MethodBind92, GodotObject.GetPtr(Singleton), body, exceptedBody);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyRemoveCollisionException, 395945892ul);

    /// <summary>
    /// <para>Removes a body from the list of bodies exempt from collisions.</para>
    /// <para>Continuous collision detection tries to predict where a moving body will collide, instead of moving it and correcting its movement if it collided.</para>
    /// </summary>
    public static void BodyRemoveCollisionException(Rid body, Rid exceptedBody)
    {
        NativeCalls.godot_icall_2_430(MethodBind93, GodotObject.GetPtr(Singleton), body, exceptedBody);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetMaxContactsReported, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum contacts to report. Bodies can keep a log of the contacts with other bodies. This is enabled by setting the maximum number of contacts reported to a number greater than 0.</para>
    /// </summary>
    public static void BodySetMaxContactsReported(Rid body, int amount)
    {
        NativeCalls.godot_icall_2_426(MethodBind94, GodotObject.GetPtr(Singleton), body, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetMaxContactsReported, 2198884583ul);

    /// <summary>
    /// <para>Returns the maximum contacts that can be reported. See <see cref="Godot.PhysicsServer3D.BodySetMaxContactsReported(Rid, int)"/>.</para>
    /// </summary>
    public static int BodyGetMaxContactsReported(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind95, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetOmitForceIntegration, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the body omits the standard force integration. If <paramref name="enable"/> is <see langword="true"/>, the body will not automatically use applied forces, torques, and damping to update the body's linear and angular velocity. In this case, <see cref="Godot.PhysicsServer3D.BodySetForceIntegrationCallback(Rid, Callable, Variant)"/> can be used to manually update the linear and angular velocity instead.</para>
    /// <para>This method is called when the property <see cref="Godot.RigidBody3D.CustomIntegrator"/> is set.</para>
    /// </summary>
    public static void BodySetOmitForceIntegration(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind96, GodotObject.GetPtr(Singleton), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyIsOmittingForceIntegration, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body is omitting the standard force integration. See <see cref="Godot.PhysicsServer3D.BodySetOmitForceIntegration(Rid, bool)"/>.</para>
    /// </summary>
    public static bool BodyIsOmittingForceIntegration(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind97, GodotObject.GetPtr(Singleton), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetStateSyncCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the body's state synchronization callback function to <paramref name="callable"/>. Use an empty <see cref="Godot.Callable"/> (<c>Callable()</c>) to clear the callback.</para>
    /// <para>The function <paramref name="callable"/> will be called every physics frame, assuming that the body was active during the previous physics tick, and can be used to fetch the latest state from the physics server.</para>
    /// <para>The function <paramref name="callable"/> must take the following parameters:</para>
    /// <para>1. <c>state</c>: a <see cref="Godot.PhysicsDirectBodyState3D"/>, used to retrieve the body's state.</para>
    /// </summary>
    public static void BodySetStateSyncCallback(Rid body, Callable callable)
    {
        NativeCalls.godot_icall_2_814(MethodBind98, GodotObject.GetPtr(Singleton), body, callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetForceIntegrationCallback, 3059434249ul);

    /// <summary>
    /// <para>Sets the body's custom force integration callback function to <paramref name="callable"/>. Use an empty <see cref="Godot.Callable"/> (<c>Callable()</c>) to clear the custom callback.</para>
    /// <para>The function <paramref name="callable"/> will be called every physics tick, before the standard force integration (see <see cref="Godot.PhysicsServer3D.BodySetOmitForceIntegration(Rid, bool)"/>). It can be used for example to update the body's linear and angular velocity based on contact with other bodies.</para>
    /// <para>If <paramref name="userdata"/> is not <see langword="null"/>, the function <paramref name="callable"/> must take the following two parameters:</para>
    /// <para>1. <c>state</c>: a <see cref="Godot.PhysicsDirectBodyState3D"/>, used to retrieve and modify the body's state,</para>
    /// <para>2. <c>userdata</c>: a <see cref="Godot.Variant"/>; its value will be the <paramref name="userdata"/> passed into this method.</para>
    /// <para>If <paramref name="userdata"/> is <see langword="null"/>, then <paramref name="callable"/> must take only the <c>state</c> parameter.</para>
    /// </summary>
    public static void BodySetForceIntegrationCallback(Rid body, Callable callable, Variant userdata = default)
    {
        NativeCalls.godot_icall_3_995(MethodBind99, GodotObject.GetPtr(Singleton), body, callable, userdata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetRayPickable, 1265174801ul);

    /// <summary>
    /// <para>Sets the body pickable with rays if <paramref name="enable"/> is set.</para>
    /// </summary>
    public static void BodySetRayPickable(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind100, GodotObject.GetPtr(Singleton), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyTestMotion, 1944921792ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a collision would result from moving along a motion vector from a given point in space. <see cref="Godot.PhysicsTestMotionParameters3D"/> is passed to set motion parameters. <see cref="Godot.PhysicsTestMotionResult3D"/> can be passed to return additional information.</para>
    /// </summary>
    public static bool BodyTestMotion(Rid body, PhysicsTestMotionParameters3D parameters, PhysicsTestMotionResult3D result = default)
    {
        return NativeCalls.godot_icall_3_996(MethodBind101, GodotObject.GetPtr(Singleton), body, GodotObject.GetPtr(parameters), GodotObject.GetPtr(result)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetDirectState, 3029727957ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PhysicsDirectBodyState3D"/> of the body. Returns <see langword="null"/> if the body is destroyed or removed from the physics space.</para>
    /// </summary>
    public static PhysicsDirectBodyState3D BodyGetDirectState(Rid body)
    {
        return (PhysicsDirectBodyState3D)NativeCalls.godot_icall_1_938(MethodBind102, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new soft body and returns its internal <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static Rid SoftBodyCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind103, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyUpdateRenderingServer, 2218179753ul);

    /// <summary>
    /// <para>Requests that the physics server updates the rendering server with the latest positions of the given soft body's points through the <paramref name="renderingServerHandler"/> interface.</para>
    /// </summary>
    public static void SoftBodyUpdateRenderingServer(Rid body, PhysicsServer3DRenderingServerHandler renderingServerHandler)
    {
        NativeCalls.godot_icall_2_858(MethodBind104, GodotObject.GetPtr(Singleton), body, GodotObject.GetPtr(renderingServerHandler));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetSpace, 395945892ul);

    /// <summary>
    /// <para>Assigns a space to the given soft body (see <see cref="Godot.PhysicsServer3D.SpaceCreate()"/>).</para>
    /// </summary>
    public static void SoftBodySetSpace(Rid body, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind105, GodotObject.GetPtr(Singleton), body, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the space assigned to the given soft body.</para>
    /// </summary>
    public static Rid SoftBodyGetSpace(Rid body)
    {
        return NativeCalls.godot_icall_1_855(MethodBind106, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetMesh, 395945892ul);

    /// <summary>
    /// <para>Sets the mesh of the given soft body.</para>
    /// </summary>
    public static void SoftBodySetMesh(Rid body, Rid mesh)
    {
        NativeCalls.godot_icall_2_430(MethodBind107, GodotObject.GetPtr(Singleton), body, mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetBounds, 974181306ul);

    /// <summary>
    /// <para>Returns the bounds of the given soft body in global coordinates.</para>
    /// </summary>
    public static Aabb SoftBodyGetBounds(Rid body)
    {
        return NativeCalls.godot_icall_1_876(MethodBind108, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers the given soft body belongs to.</para>
    /// </summary>
    public static void SoftBodySetCollisionLayer(Rid body, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind109, GodotObject.GetPtr(Singleton), body, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers that the given soft body belongs to.</para>
    /// </summary>
    public static uint SoftBodyGetCollisionLayer(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind110, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers the given soft body can collide with.</para>
    /// </summary>
    public static void SoftBodySetCollisionMask(Rid body, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind111, GodotObject.GetPtr(Singleton), body, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers that the given soft body can collide with.</para>
    /// </summary>
    public static uint SoftBodyGetCollisionMask(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind112, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyAddCollisionException, 395945892ul);

    /// <summary>
    /// <para>Adds the given body to the list of bodies exempt from collisions.</para>
    /// </summary>
    public static void SoftBodyAddCollisionException(Rid body, Rid bodyB)
    {
        NativeCalls.godot_icall_2_430(MethodBind113, GodotObject.GetPtr(Singleton), body, bodyB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyRemoveCollisionException, 395945892ul);

    /// <summary>
    /// <para>Removes the given body from the list of bodies exempt from collisions.</para>
    /// </summary>
    public static void SoftBodyRemoveCollisionException(Rid body, Rid bodyB)
    {
        NativeCalls.godot_icall_2_430(MethodBind114, GodotObject.GetPtr(Singleton), body, bodyB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetState, 599977762ul);

    /// <summary>
    /// <para>Sets the given body state for the given body.</para>
    /// <para><b>Note:</b> Godot's default physics implementation does not support <see cref="Godot.PhysicsServer3D.BodyState.LinearVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.AngularVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.Sleeping"/>, or <see cref="Godot.PhysicsServer3D.BodyState.CanSleep"/>.</para>
    /// </summary>
    public static void SoftBodySetState(Rid body, PhysicsServer3D.BodyState state, Variant variant)
    {
        NativeCalls.godot_icall_3_832(MethodBind115, GodotObject.GetPtr(Singleton), body, (int)state, variant);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetState, 1850449534ul);

    /// <summary>
    /// <para>Returns the given soft body state.</para>
    /// <para><b>Note:</b> Godot's default physics implementation does not support <see cref="Godot.PhysicsServer3D.BodyState.LinearVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.AngularVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.Sleeping"/>, or <see cref="Godot.PhysicsServer3D.BodyState.CanSleep"/>.</para>
    /// </summary>
    public static Variant SoftBodyGetState(Rid body, PhysicsServer3D.BodyState state)
    {
        return NativeCalls.godot_icall_2_828(MethodBind116, GodotObject.GetPtr(Singleton), body, (int)state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the global transform of the given soft body.</para>
    /// </summary>
    public static unsafe void SoftBodySetTransform(Rid body, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind117, GodotObject.GetPtr(Singleton), body, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetRayPickable, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the given soft body will be pickable when using object picking.</para>
    /// </summary>
    public static void SoftBodySetRayPickable(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind118, GodotObject.GetPtr(Singleton), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetSimulationPrecision, 3411492887ul);

    /// <summary>
    /// <para>Sets the simulation precision of the given soft body. Increasing this value will improve the resulting simulation, but can affect performance. Use with care.</para>
    /// </summary>
    public static void SoftBodySetSimulationPrecision(Rid body, int simulationPrecision)
    {
        NativeCalls.godot_icall_2_426(MethodBind119, GodotObject.GetPtr(Singleton), body, simulationPrecision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetSimulationPrecision, 2198884583ul);

    /// <summary>
    /// <para>Returns the simulation precision of the given soft body.</para>
    /// </summary>
    public static int SoftBodyGetSimulationPrecision(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind120, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetTotalMass, 1794382983ul);

    /// <summary>
    /// <para>Sets the total mass for the given soft body.</para>
    /// </summary>
    public static void SoftBodySetTotalMass(Rid body, float totalMass)
    {
        NativeCalls.godot_icall_2_816(MethodBind121, GodotObject.GetPtr(Singleton), body, totalMass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetTotalMass, 866169185ul);

    /// <summary>
    /// <para>Returns the total mass assigned to the given soft body.</para>
    /// </summary>
    public static float SoftBodyGetTotalMass(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind122, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetLinearStiffness, 1794382983ul);

    /// <summary>
    /// <para>Sets the linear stiffness of the given soft body. Higher values will result in a stiffer body, while lower values will increase the body's ability to bend. The value can be between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
    /// </summary>
    public static void SoftBodySetLinearStiffness(Rid body, float stiffness)
    {
        NativeCalls.godot_icall_2_816(MethodBind123, GodotObject.GetPtr(Singleton), body, stiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetLinearStiffness, 866169185ul);

    /// <summary>
    /// <para>Returns the linear stiffness of the given soft body.</para>
    /// </summary>
    public static float SoftBodyGetLinearStiffness(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind124, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetShrinkingFactor, 1794382983ul);

    /// <summary>
    /// <para>Sets the shrinking factor of the given soft body.</para>
    /// </summary>
    public static void SoftBodySetShrinkingFactor(Rid body, float shrinkingFactor)
    {
        NativeCalls.godot_icall_2_816(MethodBind125, GodotObject.GetPtr(Singleton), body, shrinkingFactor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetShrinkingFactor, 866169185ul);

    /// <summary>
    /// <para>Returns the shrinking factor of the given soft body.</para>
    /// </summary>
    public static float SoftBodyGetShrinkingFactor(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind126, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetPressureCoefficient, 1794382983ul);

    /// <summary>
    /// <para>Sets the pressure coefficient of the given soft body. Simulates pressure build-up from inside this body. Higher values increase the strength of this effect.</para>
    /// </summary>
    public static void SoftBodySetPressureCoefficient(Rid body, float pressureCoefficient)
    {
        NativeCalls.godot_icall_2_816(MethodBind127, GodotObject.GetPtr(Singleton), body, pressureCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetPressureCoefficient, 866169185ul);

    /// <summary>
    /// <para>Returns the pressure coefficient of the given soft body.</para>
    /// </summary>
    public static float SoftBodyGetPressureCoefficient(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind128, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetDampingCoefficient, 1794382983ul);

    /// <summary>
    /// <para>Sets the damping coefficient of the given soft body. Higher values will slow down the body more noticeably when forces are applied.</para>
    /// </summary>
    public static void SoftBodySetDampingCoefficient(Rid body, float dampingCoefficient)
    {
        NativeCalls.godot_icall_2_816(MethodBind129, GodotObject.GetPtr(Singleton), body, dampingCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetDampingCoefficient, 866169185ul);

    /// <summary>
    /// <para>Returns the damping coefficient of the given soft body.</para>
    /// </summary>
    public static float SoftBodyGetDampingCoefficient(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind130, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetDragCoefficient, 1794382983ul);

    /// <summary>
    /// <para>Sets the drag coefficient of the given soft body. Higher values increase this body's air resistance.</para>
    /// <para><b>Note:</b> This value is currently unused by Godot's default physics implementation.</para>
    /// </summary>
    public static void SoftBodySetDragCoefficient(Rid body, float dragCoefficient)
    {
        NativeCalls.godot_icall_2_816(MethodBind131, GodotObject.GetPtr(Singleton), body, dragCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetDragCoefficient, 866169185ul);

    /// <summary>
    /// <para>Returns the drag coefficient of the given soft body.</para>
    /// </summary>
    public static float SoftBodyGetDragCoefficient(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind132, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyMovePoint, 831953689ul);

    /// <summary>
    /// <para>Moves the given soft body point to a position in global coordinates.</para>
    /// </summary>
    public static unsafe void SoftBodyMovePoint(Rid body, int pointIndex, Vector3 globalPosition)
    {
        NativeCalls.godot_icall_3_1004(MethodBind133, GodotObject.GetPtr(Singleton), body, pointIndex, &globalPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetPointGlobalPosition, 3440143363ul);

    /// <summary>
    /// <para>Returns the current position of the given soft body point in global coordinates.</para>
    /// </summary>
    public static Vector3 SoftBodyGetPointGlobalPosition(Rid body, int pointIndex)
    {
        return NativeCalls.godot_icall_2_875(MethodBind134, GodotObject.GetPtr(Singleton), body, pointIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyRemoveAllPinnedPoints, 2722037293ul);

    /// <summary>
    /// <para>Unpins all points of the given soft body.</para>
    /// </summary>
    public static void SoftBodyRemoveAllPinnedPoints(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind135, GodotObject.GetPtr(Singleton), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyPinPoint, 2658558584ul);

    /// <summary>
    /// <para>Pins or unpins the given soft body point based on the value of <paramref name="pin"/>.</para>
    /// <para><b>Note:</b> Pinning a point effectively makes it kinematic, preventing it from being affected by forces, but you can still move it using <see cref="Godot.PhysicsServer3D.SoftBodyMovePoint(Rid, int, Vector3)"/>.</para>
    /// </summary>
    public static void SoftBodyPinPoint(Rid body, int pointIndex, bool pin)
    {
        NativeCalls.godot_icall_3_439(MethodBind136, GodotObject.GetPtr(Singleton), body, pointIndex, pin.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyIsPointPinned, 3120086654ul);

    /// <summary>
    /// <para>Returns whether the given soft body point is pinned.</para>
    /// </summary>
    public static bool SoftBodyIsPointPinned(Rid body, int pointIndex)
    {
        return NativeCalls.godot_icall_2_826(MethodBind137, GodotObject.GetPtr(Singleton), body, pointIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyPointImpulse, 831953689ul);

    /// <summary>
    /// <para>Applies an impulse to a point.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public static unsafe void SoftBodyApplyPointImpulse(Rid body, int pointIndex, Vector3 impulse)
    {
        NativeCalls.godot_icall_3_1004(MethodBind138, GodotObject.GetPtr(Singleton), body, pointIndex, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyPointForce, 831953689ul);

    /// <summary>
    /// <para>Applies a force to a point. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public static unsafe void SoftBodyApplyPointForce(Rid body, int pointIndex, Vector3 force)
    {
        NativeCalls.godot_icall_3_1004(MethodBind139, GodotObject.GetPtr(Singleton), body, pointIndex, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyCentralImpulse, 3227306858ul);

    /// <summary>
    /// <para>Distributes and applies an impulse to all points.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public static unsafe void SoftBodyApplyCentralImpulse(Rid body, Vector3 impulse)
    {
        NativeCalls.godot_icall_2_865(MethodBind140, GodotObject.GetPtr(Singleton), body, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyCentralForce, 3227306858ul);

    /// <summary>
    /// <para>Distributes and applies a force to all points. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public static unsafe void SoftBodyApplyCentralForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind141, GodotObject.GetPtr(Singleton), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointCreate, 529393457ul);

    public static Rid JointCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind142, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointClear, 2722037293ul);

    public static void JointClear(Rid joint)
    {
        NativeCalls.godot_icall_1_286(MethodBind143, GodotObject.GetPtr(Singleton), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakePin, 4280171926ul);

    public static unsafe void JointMakePin(Rid joint, Rid bodyA, Vector3 localA, Rid bodyB, Vector3 localB)
    {
        NativeCalls.godot_icall_5_1005(MethodBind144, GodotObject.GetPtr(Singleton), joint, bodyA, &localA, bodyB, &localB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetParam, 810685294ul);

    /// <summary>
    /// <para>Sets a pin joint parameter.</para>
    /// </summary>
    public static void PinJointSetParam(Rid joint, PhysicsServer3D.PinJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind145, GodotObject.GetPtr(Singleton), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetParam, 2817972347ul);

    /// <summary>
    /// <para>Gets a pin joint parameter.</para>
    /// </summary>
    public static float PinJointGetParam(Rid joint, PhysicsServer3D.PinJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind146, GodotObject.GetPtr(Singleton), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetLocalA, 3227306858ul);

    /// <summary>
    /// <para>Sets position of the joint in the local space of body a of the joint.</para>
    /// </summary>
    public static unsafe void PinJointSetLocalA(Rid joint, Vector3 localA)
    {
        NativeCalls.godot_icall_2_865(MethodBind147, GodotObject.GetPtr(Singleton), joint, &localA);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetLocalA, 531438156ul);

    /// <summary>
    /// <para>Returns position of the joint in the local space of body a of the joint.</para>
    /// </summary>
    public static Vector3 PinJointGetLocalA(Rid joint)
    {
        return NativeCalls.godot_icall_1_866(MethodBind148, GodotObject.GetPtr(Singleton), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetLocalB, 3227306858ul);

    /// <summary>
    /// <para>Sets position of the joint in the local space of body b of the joint.</para>
    /// </summary>
    public static unsafe void PinJointSetLocalB(Rid joint, Vector3 localB)
    {
        NativeCalls.godot_icall_2_865(MethodBind149, GodotObject.GetPtr(Singleton), joint, &localB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetLocalB, 531438156ul);

    /// <summary>
    /// <para>Returns position of the joint in the local space of body b of the joint.</para>
    /// </summary>
    public static Vector3 PinJointGetLocalB(Rid joint)
    {
        return NativeCalls.godot_icall_1_866(MethodBind150, GodotObject.GetPtr(Singleton), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeHinge, 1684107643ul);

    public static unsafe void JointMakeHinge(Rid joint, Rid bodyA, Transform3D hingeA, Rid bodyB, Transform3D hingeB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind151, GodotObject.GetPtr(Singleton), joint, bodyA, &hingeA, bodyB, &hingeB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointSetParam, 3165502333ul);

    /// <summary>
    /// <para>Sets a hinge joint parameter.</para>
    /// </summary>
    public static void HingeJointSetParam(Rid joint, PhysicsServer3D.HingeJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind152, GodotObject.GetPtr(Singleton), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointGetParam, 2129207581ul);

    /// <summary>
    /// <para>Gets a hinge joint parameter.</para>
    /// </summary>
    public static float HingeJointGetParam(Rid joint, PhysicsServer3D.HingeJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind153, GodotObject.GetPtr(Singleton), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointSetFlag, 1601626188ul);

    /// <summary>
    /// <para>Sets a hinge joint flag.</para>
    /// </summary>
    public static void HingeJointSetFlag(Rid joint, PhysicsServer3D.HingeJointFlag flag, bool enabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind154, GodotObject.GetPtr(Singleton), joint, (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointGetFlag, 4165147865ul);

    /// <summary>
    /// <para>Gets a hinge joint flag.</para>
    /// </summary>
    public static bool HingeJointGetFlag(Rid joint, PhysicsServer3D.HingeJointFlag flag)
    {
        return NativeCalls.godot_icall_2_826(MethodBind155, GodotObject.GetPtr(Singleton), joint, (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeSlider, 1684107643ul);

    public static unsafe void JointMakeSlider(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind156, GodotObject.GetPtr(Singleton), joint, bodyA, &localRefA, bodyB, &localRefB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SliderJointSetParam, 2264833593ul);

    /// <summary>
    /// <para>Gets a slider joint parameter.</para>
    /// </summary>
    public static void SliderJointSetParam(Rid joint, PhysicsServer3D.SliderJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind157, GodotObject.GetPtr(Singleton), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SliderJointGetParam, 3498644957ul);

    /// <summary>
    /// <para>Gets a slider joint parameter.</para>
    /// </summary>
    public static float SliderJointGetParam(Rid joint, PhysicsServer3D.SliderJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind158, GodotObject.GetPtr(Singleton), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeConeTwist, 1684107643ul);

    public static unsafe void JointMakeConeTwist(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind159, GodotObject.GetPtr(Singleton), joint, bodyA, &localRefA, bodyB, &localRefB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ConeTwistJointSetParam, 808587618ul);

    /// <summary>
    /// <para>Sets a cone twist joint parameter.</para>
    /// </summary>
    public static void ConeTwistJointSetParam(Rid joint, PhysicsServer3D.ConeTwistJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind160, GodotObject.GetPtr(Singleton), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ConeTwistJointGetParam, 1134789658ul);

    /// <summary>
    /// <para>Gets a cone twist joint parameter.</para>
    /// </summary>
    public static float ConeTwistJointGetParam(Rid joint, PhysicsServer3D.ConeTwistJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind161, GodotObject.GetPtr(Singleton), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointGetType, 4290791900ul);

    /// <summary>
    /// <para>Returns the type of the Joint3D.</para>
    /// </summary>
    public static PhysicsServer3D.JointType JointGetType(Rid joint)
    {
        return (PhysicsServer3D.JointType)NativeCalls.godot_icall_1_835(MethodBind162, GodotObject.GetPtr(Singleton), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointSetSolverPriority, 3411492887ul);

    /// <summary>
    /// <para>Sets the priority value of the Joint3D.</para>
    /// </summary>
    public static void JointSetSolverPriority(Rid joint, int priority)
    {
        NativeCalls.godot_icall_2_426(MethodBind163, GodotObject.GetPtr(Singleton), joint, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointGetSolverPriority, 2198884583ul);

    /// <summary>
    /// <para>Gets the priority value of the Joint3D.</para>
    /// </summary>
    public static int JointGetSolverPriority(Rid joint)
    {
        return NativeCalls.godot_icall_1_835(MethodBind164, GodotObject.GetPtr(Singleton), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointDisableCollisionsBetweenBodies, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the bodies attached to the <see cref="Godot.Joint3D"/> will collide with each other.</para>
    /// </summary>
    public static void JointDisableCollisionsBetweenBodies(Rid joint, bool disable)
    {
        NativeCalls.godot_icall_2_434(MethodBind165, GodotObject.GetPtr(Singleton), joint, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointIsDisabledCollisionsBetweenBodies, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the bodies attached to the <see cref="Godot.Joint3D"/> will collide with each other.</para>
    /// </summary>
    public static bool JointIsDisabledCollisionsBetweenBodies(Rid joint)
    {
        return NativeCalls.godot_icall_1_421(MethodBind166, GodotObject.GetPtr(Singleton), joint).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeGeneric6Dof, 1684107643ul);

    /// <summary>
    /// <para>Make the joint a generic six degrees of freedom (6DOF) joint. Use <see cref="Godot.PhysicsServer3D.Generic6DofJointSetFlag(Rid, Vector3.Axis, PhysicsServer3D.G6DofJointAxisFlag, bool)"/> and <see cref="Godot.PhysicsServer3D.Generic6DofJointSetParam(Rid, Vector3.Axis, PhysicsServer3D.G6DofJointAxisParam, float)"/> to set the joint's flags and parameters respectively.</para>
    /// </summary>
    public static unsafe void JointMakeGeneric6Dof(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind167, GodotObject.GetPtr(Singleton), joint, bodyA, &localRefA, bodyB, &localRefB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointSetParam, 2600081391ul);

    /// <summary>
    /// <para>Sets the value of a given generic 6DOF joint parameter.</para>
    /// </summary>
    public static void Generic6DofJointSetParam(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisParam param, float value)
    {
        NativeCalls.godot_icall_4_1007(MethodBind168, GodotObject.GetPtr(Singleton), joint, (int)axis, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointGetParam, 467122058ul);

    /// <summary>
    /// <para>Returns the value of a generic 6DOF joint parameter.</para>
    /// </summary>
    public static float Generic6DofJointGetParam(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisParam param)
    {
        return NativeCalls.godot_icall_3_1008(MethodBind169, GodotObject.GetPtr(Singleton), joint, (int)axis, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointSetFlag, 3570926903ul);

    /// <summary>
    /// <para>Sets the value of a given generic 6DOF joint flag.</para>
    /// </summary>
    public static void Generic6DofJointSetFlag(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisFlag flag, bool enable)
    {
        NativeCalls.godot_icall_4_1009(MethodBind170, GodotObject.GetPtr(Singleton), joint, (int)axis, (int)flag, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointGetFlag, 4158090196ul);

    /// <summary>
    /// <para>Returns the value of a generic 6DOF joint flag.</para>
    /// </summary>
    public static bool Generic6DofJointGetFlag(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisFlag flag)
    {
        return NativeCalls.godot_icall_3_1010(MethodBind171, GodotObject.GetPtr(Singleton), joint, (int)axis, (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeRid, 2722037293ul);

    /// <summary>
    /// <para>Destroys any of the objects created by PhysicsServer3D. If the <see cref="Godot.Rid"/> passed is not one of the objects that can be created by PhysicsServer3D, an error will be sent to the console.</para>
    /// </summary>
    public static void FreeRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind172, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActive, 2586408642ul);

    /// <summary>
    /// <para>Activates or deactivates the 3D physics engine.</para>
    /// </summary>
    public static void SetActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind173, GodotObject.GetPtr(Singleton), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessInfo, 1332958745ul);

    /// <summary>
    /// <para>Returns the value of a physics engine state specified by <paramref name="processInfo"/>.</para>
    /// </summary>
    public static int GetProcessInfo(PhysicsServer3D.ProcessInfo processInfo)
    {
        return NativeCalls.godot_icall_1_60(MethodBind174, GodotObject.GetPtr(Singleton), (int)processInfo);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'world_boundary_shape_create' method.
        /// </summary>
        public static readonly StringName WorldBoundaryShapeCreate = "world_boundary_shape_create";
        /// <summary>
        /// Cached name for the 'separation_ray_shape_create' method.
        /// </summary>
        public static readonly StringName SeparationRayShapeCreate = "separation_ray_shape_create";
        /// <summary>
        /// Cached name for the 'sphere_shape_create' method.
        /// </summary>
        public static readonly StringName SphereShapeCreate = "sphere_shape_create";
        /// <summary>
        /// Cached name for the 'box_shape_create' method.
        /// </summary>
        public static readonly StringName BoxShapeCreate = "box_shape_create";
        /// <summary>
        /// Cached name for the 'capsule_shape_create' method.
        /// </summary>
        public static readonly StringName CapsuleShapeCreate = "capsule_shape_create";
        /// <summary>
        /// Cached name for the 'cylinder_shape_create' method.
        /// </summary>
        public static readonly StringName CylinderShapeCreate = "cylinder_shape_create";
        /// <summary>
        /// Cached name for the 'convex_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName ConvexPolygonShapeCreate = "convex_polygon_shape_create";
        /// <summary>
        /// Cached name for the 'concave_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName ConcavePolygonShapeCreate = "concave_polygon_shape_create";
        /// <summary>
        /// Cached name for the 'heightmap_shape_create' method.
        /// </summary>
        public static readonly StringName HeightmapShapeCreate = "heightmap_shape_create";
        /// <summary>
        /// Cached name for the 'custom_shape_create' method.
        /// </summary>
        public static readonly StringName CustomShapeCreate = "custom_shape_create";
        /// <summary>
        /// Cached name for the 'shape_set_data' method.
        /// </summary>
        public static readonly StringName ShapeSetData = "shape_set_data";
        /// <summary>
        /// Cached name for the 'shape_set_margin' method.
        /// </summary>
        public static readonly StringName ShapeSetMargin = "shape_set_margin";
        /// <summary>
        /// Cached name for the 'shape_get_type' method.
        /// </summary>
        public static readonly StringName ShapeGetType = "shape_get_type";
        /// <summary>
        /// Cached name for the 'shape_get_data' method.
        /// </summary>
        public static readonly StringName ShapeGetData = "shape_get_data";
        /// <summary>
        /// Cached name for the 'shape_get_margin' method.
        /// </summary>
        public static readonly StringName ShapeGetMargin = "shape_get_margin";
        /// <summary>
        /// Cached name for the 'space_create' method.
        /// </summary>
        public static readonly StringName SpaceCreate = "space_create";
        /// <summary>
        /// Cached name for the 'space_set_active' method.
        /// </summary>
        public static readonly StringName SpaceSetActive = "space_set_active";
        /// <summary>
        /// Cached name for the 'space_is_active' method.
        /// </summary>
        public static readonly StringName SpaceIsActive = "space_is_active";
        /// <summary>
        /// Cached name for the 'space_set_param' method.
        /// </summary>
        public static readonly StringName SpaceSetParam = "space_set_param";
        /// <summary>
        /// Cached name for the 'space_get_param' method.
        /// </summary>
        public static readonly StringName SpaceGetParam = "space_get_param";
        /// <summary>
        /// Cached name for the 'space_get_direct_state' method.
        /// </summary>
        public static readonly StringName SpaceGetDirectState = "space_get_direct_state";
        /// <summary>
        /// Cached name for the 'area_create' method.
        /// </summary>
        public static readonly StringName AreaCreate = "area_create";
        /// <summary>
        /// Cached name for the 'area_set_space' method.
        /// </summary>
        public static readonly StringName AreaSetSpace = "area_set_space";
        /// <summary>
        /// Cached name for the 'area_get_space' method.
        /// </summary>
        public static readonly StringName AreaGetSpace = "area_get_space";
        /// <summary>
        /// Cached name for the 'area_add_shape' method.
        /// </summary>
        public static readonly StringName AreaAddShape = "area_add_shape";
        /// <summary>
        /// Cached name for the 'area_set_shape' method.
        /// </summary>
        public static readonly StringName AreaSetShape = "area_set_shape";
        /// <summary>
        /// Cached name for the 'area_set_shape_transform' method.
        /// </summary>
        public static readonly StringName AreaSetShapeTransform = "area_set_shape_transform";
        /// <summary>
        /// Cached name for the 'area_set_shape_disabled' method.
        /// </summary>
        public static readonly StringName AreaSetShapeDisabled = "area_set_shape_disabled";
        /// <summary>
        /// Cached name for the 'area_get_shape_count' method.
        /// </summary>
        public static readonly StringName AreaGetShapeCount = "area_get_shape_count";
        /// <summary>
        /// Cached name for the 'area_get_shape' method.
        /// </summary>
        public static readonly StringName AreaGetShape = "area_get_shape";
        /// <summary>
        /// Cached name for the 'area_get_shape_transform' method.
        /// </summary>
        public static readonly StringName AreaGetShapeTransform = "area_get_shape_transform";
        /// <summary>
        /// Cached name for the 'area_remove_shape' method.
        /// </summary>
        public static readonly StringName AreaRemoveShape = "area_remove_shape";
        /// <summary>
        /// Cached name for the 'area_clear_shapes' method.
        /// </summary>
        public static readonly StringName AreaClearShapes = "area_clear_shapes";
        /// <summary>
        /// Cached name for the 'area_set_collision_layer' method.
        /// </summary>
        public static readonly StringName AreaSetCollisionLayer = "area_set_collision_layer";
        /// <summary>
        /// Cached name for the 'area_get_collision_layer' method.
        /// </summary>
        public static readonly StringName AreaGetCollisionLayer = "area_get_collision_layer";
        /// <summary>
        /// Cached name for the 'area_set_collision_mask' method.
        /// </summary>
        public static readonly StringName AreaSetCollisionMask = "area_set_collision_mask";
        /// <summary>
        /// Cached name for the 'area_get_collision_mask' method.
        /// </summary>
        public static readonly StringName AreaGetCollisionMask = "area_get_collision_mask";
        /// <summary>
        /// Cached name for the 'area_set_param' method.
        /// </summary>
        public static readonly StringName AreaSetParam = "area_set_param";
        /// <summary>
        /// Cached name for the 'area_set_transform' method.
        /// </summary>
        public static readonly StringName AreaSetTransform = "area_set_transform";
        /// <summary>
        /// Cached name for the 'area_get_param' method.
        /// </summary>
        public static readonly StringName AreaGetParam = "area_get_param";
        /// <summary>
        /// Cached name for the 'area_get_transform' method.
        /// </summary>
        public static readonly StringName AreaGetTransform = "area_get_transform";
        /// <summary>
        /// Cached name for the 'area_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName AreaAttachObjectInstanceId = "area_attach_object_instance_id";
        /// <summary>
        /// Cached name for the 'area_get_object_instance_id' method.
        /// </summary>
        public static readonly StringName AreaGetObjectInstanceId = "area_get_object_instance_id";
        /// <summary>
        /// Cached name for the 'area_set_monitor_callback' method.
        /// </summary>
        public static readonly StringName AreaSetMonitorCallback = "area_set_monitor_callback";
        /// <summary>
        /// Cached name for the 'area_set_area_monitor_callback' method.
        /// </summary>
        public static readonly StringName AreaSetAreaMonitorCallback = "area_set_area_monitor_callback";
        /// <summary>
        /// Cached name for the 'area_set_monitorable' method.
        /// </summary>
        public static readonly StringName AreaSetMonitorable = "area_set_monitorable";
        /// <summary>
        /// Cached name for the 'area_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName AreaSetRayPickable = "area_set_ray_pickable";
        /// <summary>
        /// Cached name for the 'body_create' method.
        /// </summary>
        public static readonly StringName BodyCreate = "body_create";
        /// <summary>
        /// Cached name for the 'body_set_space' method.
        /// </summary>
        public static readonly StringName BodySetSpace = "body_set_space";
        /// <summary>
        /// Cached name for the 'body_get_space' method.
        /// </summary>
        public static readonly StringName BodyGetSpace = "body_get_space";
        /// <summary>
        /// Cached name for the 'body_set_mode' method.
        /// </summary>
        public static readonly StringName BodySetMode = "body_set_mode";
        /// <summary>
        /// Cached name for the 'body_get_mode' method.
        /// </summary>
        public static readonly StringName BodyGetMode = "body_get_mode";
        /// <summary>
        /// Cached name for the 'body_set_collision_layer' method.
        /// </summary>
        public static readonly StringName BodySetCollisionLayer = "body_set_collision_layer";
        /// <summary>
        /// Cached name for the 'body_get_collision_layer' method.
        /// </summary>
        public static readonly StringName BodyGetCollisionLayer = "body_get_collision_layer";
        /// <summary>
        /// Cached name for the 'body_set_collision_mask' method.
        /// </summary>
        public static readonly StringName BodySetCollisionMask = "body_set_collision_mask";
        /// <summary>
        /// Cached name for the 'body_get_collision_mask' method.
        /// </summary>
        public static readonly StringName BodyGetCollisionMask = "body_get_collision_mask";
        /// <summary>
        /// Cached name for the 'body_set_collision_priority' method.
        /// </summary>
        public static readonly StringName BodySetCollisionPriority = "body_set_collision_priority";
        /// <summary>
        /// Cached name for the 'body_get_collision_priority' method.
        /// </summary>
        public static readonly StringName BodyGetCollisionPriority = "body_get_collision_priority";
        /// <summary>
        /// Cached name for the 'body_add_shape' method.
        /// </summary>
        public static readonly StringName BodyAddShape = "body_add_shape";
        /// <summary>
        /// Cached name for the 'body_set_shape' method.
        /// </summary>
        public static readonly StringName BodySetShape = "body_set_shape";
        /// <summary>
        /// Cached name for the 'body_set_shape_transform' method.
        /// </summary>
        public static readonly StringName BodySetShapeTransform = "body_set_shape_transform";
        /// <summary>
        /// Cached name for the 'body_set_shape_disabled' method.
        /// </summary>
        public static readonly StringName BodySetShapeDisabled = "body_set_shape_disabled";
        /// <summary>
        /// Cached name for the 'body_get_shape_count' method.
        /// </summary>
        public static readonly StringName BodyGetShapeCount = "body_get_shape_count";
        /// <summary>
        /// Cached name for the 'body_get_shape' method.
        /// </summary>
        public static readonly StringName BodyGetShape = "body_get_shape";
        /// <summary>
        /// Cached name for the 'body_get_shape_transform' method.
        /// </summary>
        public static readonly StringName BodyGetShapeTransform = "body_get_shape_transform";
        /// <summary>
        /// Cached name for the 'body_remove_shape' method.
        /// </summary>
        public static readonly StringName BodyRemoveShape = "body_remove_shape";
        /// <summary>
        /// Cached name for the 'body_clear_shapes' method.
        /// </summary>
        public static readonly StringName BodyClearShapes = "body_clear_shapes";
        /// <summary>
        /// Cached name for the 'body_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName BodyAttachObjectInstanceId = "body_attach_object_instance_id";
        /// <summary>
        /// Cached name for the 'body_get_object_instance_id' method.
        /// </summary>
        public static readonly StringName BodyGetObjectInstanceId = "body_get_object_instance_id";
        /// <summary>
        /// Cached name for the 'body_set_enable_continuous_collision_detection' method.
        /// </summary>
        public static readonly StringName BodySetEnableContinuousCollisionDetection = "body_set_enable_continuous_collision_detection";
        /// <summary>
        /// Cached name for the 'body_is_continuous_collision_detection_enabled' method.
        /// </summary>
        public static readonly StringName BodyIsContinuousCollisionDetectionEnabled = "body_is_continuous_collision_detection_enabled";
        /// <summary>
        /// Cached name for the 'body_set_param' method.
        /// </summary>
        public static readonly StringName BodySetParam = "body_set_param";
        /// <summary>
        /// Cached name for the 'body_get_param' method.
        /// </summary>
        public static readonly StringName BodyGetParam = "body_get_param";
        /// <summary>
        /// Cached name for the 'body_reset_mass_properties' method.
        /// </summary>
        public static readonly StringName BodyResetMassProperties = "body_reset_mass_properties";
        /// <summary>
        /// Cached name for the 'body_set_state' method.
        /// </summary>
        public static readonly StringName BodySetState = "body_set_state";
        /// <summary>
        /// Cached name for the 'body_get_state' method.
        /// </summary>
        public static readonly StringName BodyGetState = "body_get_state";
        /// <summary>
        /// Cached name for the 'body_apply_central_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyCentralImpulse = "body_apply_central_impulse";
        /// <summary>
        /// Cached name for the 'body_apply_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyImpulse = "body_apply_impulse";
        /// <summary>
        /// Cached name for the 'body_apply_torque_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyTorqueImpulse = "body_apply_torque_impulse";
        /// <summary>
        /// Cached name for the 'body_apply_central_force' method.
        /// </summary>
        public static readonly StringName BodyApplyCentralForce = "body_apply_central_force";
        /// <summary>
        /// Cached name for the 'body_apply_force' method.
        /// </summary>
        public static readonly StringName BodyApplyForce = "body_apply_force";
        /// <summary>
        /// Cached name for the 'body_apply_torque' method.
        /// </summary>
        public static readonly StringName BodyApplyTorque = "body_apply_torque";
        /// <summary>
        /// Cached name for the 'body_add_constant_central_force' method.
        /// </summary>
        public static readonly StringName BodyAddConstantCentralForce = "body_add_constant_central_force";
        /// <summary>
        /// Cached name for the 'body_add_constant_force' method.
        /// </summary>
        public static readonly StringName BodyAddConstantForce = "body_add_constant_force";
        /// <summary>
        /// Cached name for the 'body_add_constant_torque' method.
        /// </summary>
        public static readonly StringName BodyAddConstantTorque = "body_add_constant_torque";
        /// <summary>
        /// Cached name for the 'body_set_constant_force' method.
        /// </summary>
        public static readonly StringName BodySetConstantForce = "body_set_constant_force";
        /// <summary>
        /// Cached name for the 'body_get_constant_force' method.
        /// </summary>
        public static readonly StringName BodyGetConstantForce = "body_get_constant_force";
        /// <summary>
        /// Cached name for the 'body_set_constant_torque' method.
        /// </summary>
        public static readonly StringName BodySetConstantTorque = "body_set_constant_torque";
        /// <summary>
        /// Cached name for the 'body_get_constant_torque' method.
        /// </summary>
        public static readonly StringName BodyGetConstantTorque = "body_get_constant_torque";
        /// <summary>
        /// Cached name for the 'body_set_axis_velocity' method.
        /// </summary>
        public static readonly StringName BodySetAxisVelocity = "body_set_axis_velocity";
        /// <summary>
        /// Cached name for the 'body_set_axis_lock' method.
        /// </summary>
        public static readonly StringName BodySetAxisLock = "body_set_axis_lock";
        /// <summary>
        /// Cached name for the 'body_is_axis_locked' method.
        /// </summary>
        public static readonly StringName BodyIsAxisLocked = "body_is_axis_locked";
        /// <summary>
        /// Cached name for the 'body_add_collision_exception' method.
        /// </summary>
        public static readonly StringName BodyAddCollisionException = "body_add_collision_exception";
        /// <summary>
        /// Cached name for the 'body_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName BodyRemoveCollisionException = "body_remove_collision_exception";
        /// <summary>
        /// Cached name for the 'body_set_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName BodySetMaxContactsReported = "body_set_max_contacts_reported";
        /// <summary>
        /// Cached name for the 'body_get_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName BodyGetMaxContactsReported = "body_get_max_contacts_reported";
        /// <summary>
        /// Cached name for the 'body_set_omit_force_integration' method.
        /// </summary>
        public static readonly StringName BodySetOmitForceIntegration = "body_set_omit_force_integration";
        /// <summary>
        /// Cached name for the 'body_is_omitting_force_integration' method.
        /// </summary>
        public static readonly StringName BodyIsOmittingForceIntegration = "body_is_omitting_force_integration";
        /// <summary>
        /// Cached name for the 'body_set_state_sync_callback' method.
        /// </summary>
        public static readonly StringName BodySetStateSyncCallback = "body_set_state_sync_callback";
        /// <summary>
        /// Cached name for the 'body_set_force_integration_callback' method.
        /// </summary>
        public static readonly StringName BodySetForceIntegrationCallback = "body_set_force_integration_callback";
        /// <summary>
        /// Cached name for the 'body_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName BodySetRayPickable = "body_set_ray_pickable";
        /// <summary>
        /// Cached name for the 'body_test_motion' method.
        /// </summary>
        public static readonly StringName BodyTestMotion = "body_test_motion";
        /// <summary>
        /// Cached name for the 'body_get_direct_state' method.
        /// </summary>
        public static readonly StringName BodyGetDirectState = "body_get_direct_state";
        /// <summary>
        /// Cached name for the 'soft_body_create' method.
        /// </summary>
        public static readonly StringName SoftBodyCreate = "soft_body_create";
        /// <summary>
        /// Cached name for the 'soft_body_update_rendering_server' method.
        /// </summary>
        public static readonly StringName SoftBodyUpdateRenderingServer = "soft_body_update_rendering_server";
        /// <summary>
        /// Cached name for the 'soft_body_set_space' method.
        /// </summary>
        public static readonly StringName SoftBodySetSpace = "soft_body_set_space";
        /// <summary>
        /// Cached name for the 'soft_body_get_space' method.
        /// </summary>
        public static readonly StringName SoftBodyGetSpace = "soft_body_get_space";
        /// <summary>
        /// Cached name for the 'soft_body_set_mesh' method.
        /// </summary>
        public static readonly StringName SoftBodySetMesh = "soft_body_set_mesh";
        /// <summary>
        /// Cached name for the 'soft_body_get_bounds' method.
        /// </summary>
        public static readonly StringName SoftBodyGetBounds = "soft_body_get_bounds";
        /// <summary>
        /// Cached name for the 'soft_body_set_collision_layer' method.
        /// </summary>
        public static readonly StringName SoftBodySetCollisionLayer = "soft_body_set_collision_layer";
        /// <summary>
        /// Cached name for the 'soft_body_get_collision_layer' method.
        /// </summary>
        public static readonly StringName SoftBodyGetCollisionLayer = "soft_body_get_collision_layer";
        /// <summary>
        /// Cached name for the 'soft_body_set_collision_mask' method.
        /// </summary>
        public static readonly StringName SoftBodySetCollisionMask = "soft_body_set_collision_mask";
        /// <summary>
        /// Cached name for the 'soft_body_get_collision_mask' method.
        /// </summary>
        public static readonly StringName SoftBodyGetCollisionMask = "soft_body_get_collision_mask";
        /// <summary>
        /// Cached name for the 'soft_body_add_collision_exception' method.
        /// </summary>
        public static readonly StringName SoftBodyAddCollisionException = "soft_body_add_collision_exception";
        /// <summary>
        /// Cached name for the 'soft_body_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName SoftBodyRemoveCollisionException = "soft_body_remove_collision_exception";
        /// <summary>
        /// Cached name for the 'soft_body_set_state' method.
        /// </summary>
        public static readonly StringName SoftBodySetState = "soft_body_set_state";
        /// <summary>
        /// Cached name for the 'soft_body_get_state' method.
        /// </summary>
        public static readonly StringName SoftBodyGetState = "soft_body_get_state";
        /// <summary>
        /// Cached name for the 'soft_body_set_transform' method.
        /// </summary>
        public static readonly StringName SoftBodySetTransform = "soft_body_set_transform";
        /// <summary>
        /// Cached name for the 'soft_body_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName SoftBodySetRayPickable = "soft_body_set_ray_pickable";
        /// <summary>
        /// Cached name for the 'soft_body_set_simulation_precision' method.
        /// </summary>
        public static readonly StringName SoftBodySetSimulationPrecision = "soft_body_set_simulation_precision";
        /// <summary>
        /// Cached name for the 'soft_body_get_simulation_precision' method.
        /// </summary>
        public static readonly StringName SoftBodyGetSimulationPrecision = "soft_body_get_simulation_precision";
        /// <summary>
        /// Cached name for the 'soft_body_set_total_mass' method.
        /// </summary>
        public static readonly StringName SoftBodySetTotalMass = "soft_body_set_total_mass";
        /// <summary>
        /// Cached name for the 'soft_body_get_total_mass' method.
        /// </summary>
        public static readonly StringName SoftBodyGetTotalMass = "soft_body_get_total_mass";
        /// <summary>
        /// Cached name for the 'soft_body_set_linear_stiffness' method.
        /// </summary>
        public static readonly StringName SoftBodySetLinearStiffness = "soft_body_set_linear_stiffness";
        /// <summary>
        /// Cached name for the 'soft_body_get_linear_stiffness' method.
        /// </summary>
        public static readonly StringName SoftBodyGetLinearStiffness = "soft_body_get_linear_stiffness";
        /// <summary>
        /// Cached name for the 'soft_body_set_shrinking_factor' method.
        /// </summary>
        public static readonly StringName SoftBodySetShrinkingFactor = "soft_body_set_shrinking_factor";
        /// <summary>
        /// Cached name for the 'soft_body_get_shrinking_factor' method.
        /// </summary>
        public static readonly StringName SoftBodyGetShrinkingFactor = "soft_body_get_shrinking_factor";
        /// <summary>
        /// Cached name for the 'soft_body_set_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodySetPressureCoefficient = "soft_body_set_pressure_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_get_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodyGetPressureCoefficient = "soft_body_get_pressure_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_set_damping_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodySetDampingCoefficient = "soft_body_set_damping_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_get_damping_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodyGetDampingCoefficient = "soft_body_get_damping_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_set_drag_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodySetDragCoefficient = "soft_body_set_drag_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_get_drag_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodyGetDragCoefficient = "soft_body_get_drag_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_move_point' method.
        /// </summary>
        public static readonly StringName SoftBodyMovePoint = "soft_body_move_point";
        /// <summary>
        /// Cached name for the 'soft_body_get_point_global_position' method.
        /// </summary>
        public static readonly StringName SoftBodyGetPointGlobalPosition = "soft_body_get_point_global_position";
        /// <summary>
        /// Cached name for the 'soft_body_remove_all_pinned_points' method.
        /// </summary>
        public static readonly StringName SoftBodyRemoveAllPinnedPoints = "soft_body_remove_all_pinned_points";
        /// <summary>
        /// Cached name for the 'soft_body_pin_point' method.
        /// </summary>
        public static readonly StringName SoftBodyPinPoint = "soft_body_pin_point";
        /// <summary>
        /// Cached name for the 'soft_body_is_point_pinned' method.
        /// </summary>
        public static readonly StringName SoftBodyIsPointPinned = "soft_body_is_point_pinned";
        /// <summary>
        /// Cached name for the 'soft_body_apply_point_impulse' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyPointImpulse = "soft_body_apply_point_impulse";
        /// <summary>
        /// Cached name for the 'soft_body_apply_point_force' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyPointForce = "soft_body_apply_point_force";
        /// <summary>
        /// Cached name for the 'soft_body_apply_central_impulse' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyCentralImpulse = "soft_body_apply_central_impulse";
        /// <summary>
        /// Cached name for the 'soft_body_apply_central_force' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyCentralForce = "soft_body_apply_central_force";
        /// <summary>
        /// Cached name for the 'joint_create' method.
        /// </summary>
        public static readonly StringName JointCreate = "joint_create";
        /// <summary>
        /// Cached name for the 'joint_clear' method.
        /// </summary>
        public static readonly StringName JointClear = "joint_clear";
        /// <summary>
        /// Cached name for the 'joint_make_pin' method.
        /// </summary>
        public static readonly StringName JointMakePin = "joint_make_pin";
        /// <summary>
        /// Cached name for the 'pin_joint_set_param' method.
        /// </summary>
        public static readonly StringName PinJointSetParam = "pin_joint_set_param";
        /// <summary>
        /// Cached name for the 'pin_joint_get_param' method.
        /// </summary>
        public static readonly StringName PinJointGetParam = "pin_joint_get_param";
        /// <summary>
        /// Cached name for the 'pin_joint_set_local_a' method.
        /// </summary>
        public static readonly StringName PinJointSetLocalA = "pin_joint_set_local_a";
        /// <summary>
        /// Cached name for the 'pin_joint_get_local_a' method.
        /// </summary>
        public static readonly StringName PinJointGetLocalA = "pin_joint_get_local_a";
        /// <summary>
        /// Cached name for the 'pin_joint_set_local_b' method.
        /// </summary>
        public static readonly StringName PinJointSetLocalB = "pin_joint_set_local_b";
        /// <summary>
        /// Cached name for the 'pin_joint_get_local_b' method.
        /// </summary>
        public static readonly StringName PinJointGetLocalB = "pin_joint_get_local_b";
        /// <summary>
        /// Cached name for the 'joint_make_hinge' method.
        /// </summary>
        public static readonly StringName JointMakeHinge = "joint_make_hinge";
        /// <summary>
        /// Cached name for the 'hinge_joint_set_param' method.
        /// </summary>
        public static readonly StringName HingeJointSetParam = "hinge_joint_set_param";
        /// <summary>
        /// Cached name for the 'hinge_joint_get_param' method.
        /// </summary>
        public static readonly StringName HingeJointGetParam = "hinge_joint_get_param";
        /// <summary>
        /// Cached name for the 'hinge_joint_set_flag' method.
        /// </summary>
        public static readonly StringName HingeJointSetFlag = "hinge_joint_set_flag";
        /// <summary>
        /// Cached name for the 'hinge_joint_get_flag' method.
        /// </summary>
        public static readonly StringName HingeJointGetFlag = "hinge_joint_get_flag";
        /// <summary>
        /// Cached name for the 'joint_make_slider' method.
        /// </summary>
        public static readonly StringName JointMakeSlider = "joint_make_slider";
        /// <summary>
        /// Cached name for the 'slider_joint_set_param' method.
        /// </summary>
        public static readonly StringName SliderJointSetParam = "slider_joint_set_param";
        /// <summary>
        /// Cached name for the 'slider_joint_get_param' method.
        /// </summary>
        public static readonly StringName SliderJointGetParam = "slider_joint_get_param";
        /// <summary>
        /// Cached name for the 'joint_make_cone_twist' method.
        /// </summary>
        public static readonly StringName JointMakeConeTwist = "joint_make_cone_twist";
        /// <summary>
        /// Cached name for the 'cone_twist_joint_set_param' method.
        /// </summary>
        public static readonly StringName ConeTwistJointSetParam = "cone_twist_joint_set_param";
        /// <summary>
        /// Cached name for the 'cone_twist_joint_get_param' method.
        /// </summary>
        public static readonly StringName ConeTwistJointGetParam = "cone_twist_joint_get_param";
        /// <summary>
        /// Cached name for the 'joint_get_type' method.
        /// </summary>
        public static readonly StringName JointGetType = "joint_get_type";
        /// <summary>
        /// Cached name for the 'joint_set_solver_priority' method.
        /// </summary>
        public static readonly StringName JointSetSolverPriority = "joint_set_solver_priority";
        /// <summary>
        /// Cached name for the 'joint_get_solver_priority' method.
        /// </summary>
        public static readonly StringName JointGetSolverPriority = "joint_get_solver_priority";
        /// <summary>
        /// Cached name for the 'joint_disable_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName JointDisableCollisionsBetweenBodies = "joint_disable_collisions_between_bodies";
        /// <summary>
        /// Cached name for the 'joint_is_disabled_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName JointIsDisabledCollisionsBetweenBodies = "joint_is_disabled_collisions_between_bodies";
        /// <summary>
        /// Cached name for the 'joint_make_generic_6dof' method.
        /// </summary>
        public static readonly StringName JointMakeGeneric6Dof = "joint_make_generic_6dof";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_set_param' method.
        /// </summary>
        public static readonly StringName Generic6DofJointSetParam = "generic_6dof_joint_set_param";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_get_param' method.
        /// </summary>
        public static readonly StringName Generic6DofJointGetParam = "generic_6dof_joint_get_param";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_set_flag' method.
        /// </summary>
        public static readonly StringName Generic6DofJointSetFlag = "generic_6dof_joint_set_flag";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_get_flag' method.
        /// </summary>
        public static readonly StringName Generic6DofJointGetFlag = "generic_6dof_joint_get_flag";
        /// <summary>
        /// Cached name for the 'free_rid' method.
        /// </summary>
        public static readonly StringName FreeRid = "free_rid";
        /// <summary>
        /// Cached name for the 'set_active' method.
        /// </summary>
        public static readonly StringName SetActive = "set_active";
        /// <summary>
        /// Cached name for the 'get_process_info' method.
        /// </summary>
        public static readonly StringName GetProcessInfo = "get_process_info";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
