namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.ParticleProcessMaterial"/> defines particle properties and behavior. It is used in the <c>process_material</c> of the <see cref="Godot.GpuParticles2D"/> and <see cref="Godot.GpuParticles3D"/> nodes. Some of this material's properties are applied to each particle when emitted, while others can have a <see cref="Godot.CurveTexture"/> or a <see cref="Godot.GradientTexture1D"/> applied to vary numerical or color values over the lifetime of the particle.</para>
/// </summary>
public partial class ParticleProcessMaterial : Material
{
    public enum Parameter : long
    {
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set initial velocity properties.</para>
        /// </summary>
        InitialLinearVelocity = 0,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set angular velocity properties.</para>
        /// </summary>
        AngularVelocity = 1,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set orbital velocity properties.</para>
        /// </summary>
        OrbitVelocity = 2,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set linear acceleration properties.</para>
        /// </summary>
        LinearAccel = 3,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set radial acceleration properties.</para>
        /// </summary>
        RadialAccel = 4,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set tangential acceleration properties.</para>
        /// </summary>
        TangentialAccel = 5,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set damping properties.</para>
        /// </summary>
        Damping = 6,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set angle properties.</para>
        /// </summary>
        Angle = 7,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set scale properties.</para>
        /// </summary>
        Scale = 8,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set hue variation properties.</para>
        /// </summary>
        HueVariation = 9,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set animation speed properties.</para>
        /// </summary>
        AnimSpeed = 10,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set animation offset properties.</para>
        /// </summary>
        AnimOffset = 11,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set radial velocity properties.</para>
        /// </summary>
        RadialVelocity = 15,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set directional velocity properties.</para>
        /// </summary>
        DirectionalVelocity = 16,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/>, <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/>, and <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set scale over velocity properties.</para>
        /// </summary>
        ScaleOverVelocity = 17,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.ParticleProcessMaterial.Parameter"/> enum.</para>
        /// </summary>
        Max = 18,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/> and <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/> to set the turbulence minimum und maximum influence on each particles velocity.</para>
        /// </summary>
        TurbVelInfluence = 13,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamMin(ParticleProcessMaterial.Parameter, float)"/> and <see cref="Godot.ParticleProcessMaterial.SetParamMax(ParticleProcessMaterial.Parameter, float)"/> to set the turbulence minimum and maximum displacement of the particles spawn position.</para>
        /// </summary>
        TurbInitDisplacement = 14,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParamTexture(ParticleProcessMaterial.Parameter, Texture2D)"/> to set the turbulence influence over the particles life time.</para>
        /// </summary>
        TurbInfluenceOverLife = 12
    }

    public enum ParticleFlags : long
    {
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParticleFlag(ParticleProcessMaterial.ParticleFlags, bool)"/> to set <see cref="Godot.ParticleProcessMaterial.ParticleFlagAlignY"/>.</para>
        /// </summary>
        AlignYToVelocity = 0,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParticleFlag(ParticleProcessMaterial.ParticleFlags, bool)"/> to set <see cref="Godot.ParticleProcessMaterial.ParticleFlagRotateY"/>.</para>
        /// </summary>
        RotateY = 1,
        /// <summary>
        /// <para>Use with <see cref="Godot.ParticleProcessMaterial.SetParticleFlag(ParticleProcessMaterial.ParticleFlags, bool)"/> to set <see cref="Godot.ParticleProcessMaterial.ParticleFlagDisableZ"/>.</para>
        /// </summary>
        DisableZ = 2,
        DampingAsFriction = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.ParticleProcessMaterial.ParticleFlags"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum EmissionShapeEnum : long
    {
        /// <summary>
        /// <para>All particles will be emitted from a single point.</para>
        /// </summary>
        Point = 0,
        /// <summary>
        /// <para>Particles will be emitted in the volume of a sphere.</para>
        /// </summary>
        Sphere = 1,
        /// <summary>
        /// <para>Particles will be emitted on the surface of a sphere.</para>
        /// </summary>
        SphereSurface = 2,
        /// <summary>
        /// <para>Particles will be emitted in the volume of a box.</para>
        /// </summary>
        Box = 3,
        /// <summary>
        /// <para>Particles will be emitted at a position determined by sampling a random point on the <see cref="Godot.ParticleProcessMaterial.EmissionPointTexture"/>. Particle color will be modulated by <see cref="Godot.ParticleProcessMaterial.EmissionColorTexture"/>.</para>
        /// </summary>
        Points = 4,
        /// <summary>
        /// <para>Particles will be emitted at a position determined by sampling a random point on the <see cref="Godot.ParticleProcessMaterial.EmissionPointTexture"/>. Particle velocity and rotation will be set based on <see cref="Godot.ParticleProcessMaterial.EmissionNormalTexture"/>. Particle color will be modulated by <see cref="Godot.ParticleProcessMaterial.EmissionColorTexture"/>.</para>
        /// </summary>
        DirectedPoints = 5,
        /// <summary>
        /// <para>Particles will be emitted in a ring or cylinder.</para>
        /// </summary>
        Ring = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public enum SubEmitterModeEnum : long
    {
        Disabled = 0,
        Constant = 1,
        AtEnd = 2,
        AtCollision = 3,
        AtStart = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.ParticleProcessMaterial.SubEmitterModeEnum"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum CollisionModeEnum : long
    {
        /// <summary>
        /// <para>No collision for particles. Particles will go through <see cref="Godot.GpuParticlesCollision3D"/> nodes.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para><see cref="Godot.RigidBody3D"/>-style collision for particles using <see cref="Godot.GpuParticlesCollision3D"/> nodes.</para>
        /// </summary>
        Rigid = 1,
        /// <summary>
        /// <para>Hide particles instantly when colliding with a <see cref="Godot.GpuParticlesCollision3D"/> node. This can be combined with a subemitter that uses the <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/> collision mode to "replace" the parent particle with the subemitter on impact.</para>
        /// </summary>
        HideOnContact = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>Particle lifetime randomness ratio. The equation for the lifetime of a particle is <c>lifetime * (1.0 - randf() * lifetime_randomness)</c>. For example, a <see cref="Godot.ParticleProcessMaterial.LifetimeRandomness"/> of <c>0.4</c> scales the lifetime between <c>0.6</c> to <c>1.0</c> of its original value.</para>
    /// </summary>
    public double LifetimeRandomness
    {
        get
        {
            return GetLifetimeRandomness();
        }
        set
        {
            SetLifetimeRandomness(value);
        }
    }

    /// <summary>
    /// <para>Align Y axis of particle with the direction of its velocity.</para>
    /// </summary>
    public bool ParticleFlagAlignY
    {
        get
        {
            return GetParticleFlag((ParticleProcessMaterial.ParticleFlags)(0));
        }
        set
        {
            SetParticleFlag((ParticleProcessMaterial.ParticleFlags)(0), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles rotate around Y axis by <see cref="Godot.ParticleProcessMaterial.AngleMin"/>.</para>
    /// </summary>
    public bool ParticleFlagRotateY
    {
        get
        {
            return GetParticleFlag((ParticleProcessMaterial.ParticleFlags)(1));
        }
        set
        {
            SetParticleFlag((ParticleProcessMaterial.ParticleFlags)(1), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles will not move on the z axis.</para>
    /// </summary>
    public bool ParticleFlagDisableZ
    {
        get
        {
            return GetParticleFlag((ParticleProcessMaterial.ParticleFlags)(2));
        }
        set
        {
            SetParticleFlag((ParticleProcessMaterial.ParticleFlags)(2), value);
        }
    }

    /// <summary>
    /// <para>Changes the behavior of the damping properties from a linear deceleration to a deceleration based on speed percentage.</para>
    /// </summary>
    public bool ParticleFlagDampingAsFriction
    {
        get
        {
            return GetParticleFlag((ParticleProcessMaterial.ParticleFlags)(3));
        }
        set
        {
            SetParticleFlag((ParticleProcessMaterial.ParticleFlags)(3), value);
        }
    }

    /// <summary>
    /// <para>The offset for the <see cref="Godot.ParticleProcessMaterial.EmissionShape"/>, in local space.</para>
    /// </summary>
    public Vector3 EmissionShapeOffset
    {
        get
        {
            return GetEmissionShapeOffset();
        }
        set
        {
            SetEmissionShapeOffset(value);
        }
    }

    /// <summary>
    /// <para>The scale of the <see cref="Godot.ParticleProcessMaterial.EmissionShape"/>, in local space.</para>
    /// </summary>
    public Vector3 EmissionShapeScale
    {
        get
        {
            return GetEmissionShapeScale();
        }
        set
        {
            SetEmissionShapeScale(value);
        }
    }

    /// <summary>
    /// <para>Particles will be emitted inside this region.</para>
    /// </summary>
    public ParticleProcessMaterial.EmissionShapeEnum EmissionShape
    {
        get
        {
            return GetEmissionShape();
        }
        set
        {
            SetEmissionShape(value);
        }
    }

    /// <summary>
    /// <para>The sphere's radius if <see cref="Godot.ParticleProcessMaterial.EmissionShape"/> is set to <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Sphere"/>.</para>
    /// </summary>
    public float EmissionSphereRadius
    {
        get
        {
            return GetEmissionSphereRadius();
        }
        set
        {
            SetEmissionSphereRadius(value);
        }
    }

    /// <summary>
    /// <para>The box's extents if <see cref="Godot.ParticleProcessMaterial.EmissionShape"/> is set to <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Box"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.EmissionBoxExtents"/> starts from the center point and applies the X, Y, and Z values in both directions. The size is twice the area of the extents.</para>
    /// </summary>
    public Vector3 EmissionBoxExtents
    {
        get
        {
            return GetEmissionBoxExtents();
        }
        set
        {
            SetEmissionBoxExtents(value);
        }
    }

    /// <summary>
    /// <para>Particles will be emitted at positions determined by sampling this texture at a random position. Used with <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Points"/> and <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.DirectedPoints"/>. Can be created automatically from mesh or node by selecting "Create Emission Points from Mesh/Node" under the "Particles" tool in the toolbar.</para>
    /// </summary>
    public Texture2D EmissionPointTexture
    {
        get
        {
            return GetEmissionPointTexture();
        }
        set
        {
            SetEmissionPointTexture(value);
        }
    }

    /// <summary>
    /// <para>Particle velocity and rotation will be set by sampling this texture at the same point as the <see cref="Godot.ParticleProcessMaterial.EmissionPointTexture"/>. Used only in <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.DirectedPoints"/>. Can be created automatically from mesh or node by selecting "Create Emission Points from Mesh/Node" under the "Particles" tool in the toolbar.</para>
    /// </summary>
    public Texture2D EmissionNormalTexture
    {
        get
        {
            return GetEmissionNormalTexture();
        }
        set
        {
            SetEmissionNormalTexture(value);
        }
    }

    /// <summary>
    /// <para>Particle color will be modulated by color determined by sampling this texture at the same point as the <see cref="Godot.ParticleProcessMaterial.EmissionPointTexture"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.EmissionColorTexture"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.ParticleProcessMaterial.EmissionColorTexture"/> will have no visible effect.</para>
    /// </summary>
    public Texture2D EmissionColorTexture
    {
        get
        {
            return GetEmissionColorTexture();
        }
        set
        {
            SetEmissionColorTexture(value);
        }
    }

    /// <summary>
    /// <para>The number of emission points if <see cref="Godot.ParticleProcessMaterial.EmissionShape"/> is set to <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Points"/> or <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.DirectedPoints"/>.</para>
    /// </summary>
    public int EmissionPointCount
    {
        get
        {
            return GetEmissionPointCount();
        }
        set
        {
            SetEmissionPointCount(value);
        }
    }

    /// <summary>
    /// <para>The axis of the ring when using the emitter <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Ring"/>.</para>
    /// </summary>
    public Vector3 EmissionRingAxis
    {
        get
        {
            return GetEmissionRingAxis();
        }
        set
        {
            SetEmissionRingAxis(value);
        }
    }

    /// <summary>
    /// <para>The height of the ring when using the emitter <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Ring"/>.</para>
    /// </summary>
    public float EmissionRingHeight
    {
        get
        {
            return GetEmissionRingHeight();
        }
        set
        {
            SetEmissionRingHeight(value);
        }
    }

    /// <summary>
    /// <para>The radius of the ring when using the emitter <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Ring"/>.</para>
    /// </summary>
    public float EmissionRingRadius
    {
        get
        {
            return GetEmissionRingRadius();
        }
        set
        {
            SetEmissionRingRadius(value);
        }
    }

    /// <summary>
    /// <para>The inner radius of the ring when using the emitter <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Ring"/>.</para>
    /// </summary>
    public float EmissionRingInnerRadius
    {
        get
        {
            return GetEmissionRingInnerRadius();
        }
        set
        {
            SetEmissionRingInnerRadius(value);
        }
    }

    /// <summary>
    /// <para>The angle of the cone when using the emitter <see cref="Godot.ParticleProcessMaterial.EmissionShapeEnum.Ring"/>. The default angle of 90 degrees results in a ring, while an angle of 0 degrees results in a cone. Intermediate values will result in a ring where one end is larger than the other.</para>
    /// <para><b>Note:</b> Depending on <see cref="Godot.ParticleProcessMaterial.EmissionRingHeight"/>, the angle may be clamped if the ring's end is reached to form a perfect cone.</para>
    /// </summary>
    public float EmissionRingConeAngle
    {
        get
        {
            return GetEmissionRingConeAngle();
        }
        set
        {
            SetEmissionRingConeAngle(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 Angle
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(7));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(7), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.AngleMax"/>.</para>
    /// </summary>
    public float AngleMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(7));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(7), value);
        }
    }

    /// <summary>
    /// <para>Maximum initial rotation applied to each particle, in degrees.</para>
    /// <para>Only applied when <see cref="Godot.ParticleProcessMaterial.ParticleFlagDisableZ"/> or <see cref="Godot.ParticleProcessMaterial.ParticleFlagRotateY"/> are <see langword="true"/> or the <see cref="Godot.BaseMaterial3D"/> being used to draw the particle is using <see cref="Godot.BaseMaterial3D.BillboardModeEnum.Particles"/>.</para>
    /// </summary>
    public float AngleMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(7));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(7), value);
        }
    }

    /// <summary>
    /// <para>Each particle's rotation will be animated along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D AngleCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(7));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(7), value);
        }
    }

    /// <summary>
    /// <para>Percentage of the velocity of the respective <see cref="Godot.GpuParticles2D"/> or <see cref="Godot.GpuParticles3D"/> inherited by each particle when spawning.</para>
    /// </summary>
    public double InheritVelocityRatio
    {
        get
        {
            return GetInheritVelocityRatio();
        }
        set
        {
            SetInheritVelocityRatio(value);
        }
    }

    /// <summary>
    /// <para>A pivot point used to calculate radial and orbital velocity of particles.</para>
    /// </summary>
    public Vector3 VelocityPivot
    {
        get
        {
            return GetVelocityPivot();
        }
        set
        {
            SetVelocityPivot(value);
        }
    }

    /// <summary>
    /// <para>Unit vector specifying the particles' emission direction.</para>
    /// </summary>
    public Vector3 Direction
    {
        get
        {
            return GetDirection();
        }
        set
        {
            SetDirection(value);
        }
    }

    /// <summary>
    /// <para>Each particle's initial direction range from <c>+spread</c> to <c>-spread</c> degrees.</para>
    /// </summary>
    public float Spread
    {
        get
        {
            return GetSpread();
        }
        set
        {
            SetSpread(value);
        }
    }

    /// <summary>
    /// <para>Amount of <see cref="Godot.ParticleProcessMaterial.Spread"/> along the Y axis.</para>
    /// </summary>
    public float Flatness
    {
        get
        {
            return GetFlatness();
        }
        set
        {
            SetFlatness(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 InitialVelocity
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(0));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(0), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.InitialVelocityMax"/>.</para>
    /// </summary>
    public float InitialVelocityMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(0));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(0), value);
        }
    }

    /// <summary>
    /// <para>Maximum initial velocity magnitude for each particle. Direction comes from <see cref="Godot.ParticleProcessMaterial.Direction"/> and <see cref="Godot.ParticleProcessMaterial.Spread"/>.</para>
    /// </summary>
    public float InitialVelocityMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(0));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(0), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 AngularVelocity
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(1));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(1), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.AngularVelocityMax"/>.</para>
    /// </summary>
    public float AngularVelocityMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(1));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(1), value);
        }
    }

    /// <summary>
    /// <para>Maximum initial angular velocity (rotation speed) applied to each particle in <i>degrees</i> per second.</para>
    /// <para>Only applied when <see cref="Godot.ParticleProcessMaterial.ParticleFlagDisableZ"/> or <see cref="Godot.ParticleProcessMaterial.ParticleFlagRotateY"/> are <see langword="true"/> or the <see cref="Godot.BaseMaterial3D"/> being used to draw the particle is using <see cref="Godot.BaseMaterial3D.BillboardModeEnum.Particles"/>.</para>
    /// </summary>
    public float AngularVelocityMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(1));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(1), value);
        }
    }

    /// <summary>
    /// <para>Each particle's angular velocity (rotation speed) will vary along this <see cref="Godot.CurveTexture"/> over its lifetime.</para>
    /// </summary>
    public Texture2D AngularVelocityCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(1));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(1), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 DirectionalVelocity
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(16));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(16), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum directional velocity value, which is multiplied by <see cref="Godot.ParticleProcessMaterial.DirectionalVelocityCurve"/>.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public float DirectionalVelocityMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(16));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(16), value);
        }
    }

    /// <summary>
    /// <para>Maximum directional velocity value, which is multiplied by <see cref="Godot.ParticleProcessMaterial.DirectionalVelocityCurve"/>.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public float DirectionalVelocityMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(16));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(16), value);
        }
    }

    /// <summary>
    /// <para>A curve that specifies the velocity along each of the axes of the particle system along its lifetime.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public Texture2D DirectionalVelocityCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(16));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(16), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 OrbitVelocity
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(2));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(2), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.OrbitVelocityMax"/>.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public float OrbitVelocityMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(2));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(2), value);
        }
    }

    /// <summary>
    /// <para>Maximum orbital velocity applied to each particle. Makes the particles circle around origin. Specified in number of full rotations around origin per second.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public float OrbitVelocityMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(2));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(2), value);
        }
    }

    /// <summary>
    /// <para>Each particle's orbital velocity will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// <para><b>Note:</b> For 3D orbital velocity, use a <see cref="Godot.CurveXyzTexture"/>.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public Texture2D OrbitVelocityCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(2));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(2), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 RadialVelocity
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(15));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(15), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum radial velocity applied to each particle. Makes particles move away from the <see cref="Godot.ParticleProcessMaterial.VelocityPivot"/>, or toward it if negative.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public float RadialVelocityMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(15));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(15), value);
        }
    }

    /// <summary>
    /// <para>Maximum radial velocity applied to each particle. Makes particles move away from the <see cref="Godot.ParticleProcessMaterial.VelocityPivot"/>, or toward it if negative.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public float RadialVelocityMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(15));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(15), value);
        }
    }

    /// <summary>
    /// <para>A <see cref="Godot.CurveTexture"/> that defines the velocity over the particle's lifetime away (or toward) the <see cref="Godot.ParticleProcessMaterial.VelocityPivot"/>.</para>
    /// <para><b>Note:</b> Animated velocities will not be affected by damping, use <see cref="Godot.ParticleProcessMaterial.VelocityLimitCurve"/> instead.</para>
    /// </summary>
    public Texture2D RadialVelocityCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(15));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(15), value);
        }
    }

    /// <summary>
    /// <para>A <see cref="Godot.CurveTexture"/> that defines the maximum velocity of a particle during its lifetime.</para>
    /// </summary>
    public Texture2D VelocityLimitCurve
    {
        get
        {
            return GetVelocityLimitCurve();
        }
        set
        {
            SetVelocityLimitCurve(value);
        }
    }

    /// <summary>
    /// <para>Gravity applied to every particle.</para>
    /// </summary>
    public Vector3 Gravity
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

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 LinearAccel
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(3));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(3), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.LinearAccelMax"/>.</para>
    /// </summary>
    public float LinearAccelMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(3));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(3), value);
        }
    }

    /// <summary>
    /// <para>Maximum linear acceleration applied to each particle in the direction of motion.</para>
    /// </summary>
    public float LinearAccelMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(3));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(3), value);
        }
    }

    /// <summary>
    /// <para>Each particle's linear acceleration will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D LinearAccelCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(3));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(3), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 RadialAccel
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(4));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(4), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.RadialAccelMax"/>.</para>
    /// </summary>
    public float RadialAccelMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(4));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(4), value);
        }
    }

    /// <summary>
    /// <para>Maximum radial acceleration applied to each particle. Makes particle accelerate away from the origin or towards it if negative.</para>
    /// </summary>
    public float RadialAccelMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(4));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(4), value);
        }
    }

    /// <summary>
    /// <para>Each particle's radial acceleration will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D RadialAccelCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(4));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(4), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 TangentialAccel
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(5));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(5), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.TangentialAccelMax"/>.</para>
    /// </summary>
    public float TangentialAccelMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(5));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(5), value);
        }
    }

    /// <summary>
    /// <para>Maximum tangential acceleration applied to each particle. Tangential acceleration is perpendicular to the particle's velocity giving the particles a swirling motion.</para>
    /// </summary>
    public float TangentialAccelMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(5));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(5), value);
        }
    }

    /// <summary>
    /// <para>Each particle's tangential acceleration will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D TangentialAccelCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(5));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(5), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 Damping
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(6));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(6), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.DampingMax"/>.</para>
    /// </summary>
    public float DampingMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(6));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(6), value);
        }
    }

    /// <summary>
    /// <para>The maximum rate at which particles lose velocity. For example value of <c>100</c> means that the particle will go from <c>100</c> velocity to <c>0</c> in <c>1</c> second.</para>
    /// </summary>
    public float DampingMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(6));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(6), value);
        }
    }

    /// <summary>
    /// <para>Damping will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D DampingCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(6));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(6), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, interaction with particle attractors is enabled. In 3D, attraction only occurs within the area defined by the <see cref="Godot.GpuParticles3D"/> node's <see cref="Godot.GpuParticles3D.VisibilityAabb"/>.</para>
    /// </summary>
    public bool AttractorInteractionEnabled
    {
        get
        {
            return IsAttractorInteractionEnabled();
        }
        set
        {
            SetAttractorInteractionEnabled(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 Scale
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(8));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(8), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.ScaleMax"/>.</para>
    /// </summary>
    public float ScaleMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(8));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(8), value);
        }
    }

    /// <summary>
    /// <para>Maximum initial scale applied to each particle.</para>
    /// </summary>
    public float ScaleMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(8));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(8), value);
        }
    }

    /// <summary>
    /// <para>Each particle's scale will vary along this <see cref="Godot.CurveTexture"/> over its lifetime. If a <see cref="Godot.CurveXyzTexture"/> is supplied instead, the scale will be separated per-axis.</para>
    /// </summary>
    public Texture2D ScaleCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(8));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(8), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 ScaleOverVelocity
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(17));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(17), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum velocity value reference for <see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityCurve"/>.</para>
    /// <para><see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityCurve"/> will be interpolated between <see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityMin"/> and <see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityMax"/>.</para>
    /// </summary>
    public float ScaleOverVelocityMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(17));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(17), value);
        }
    }

    /// <summary>
    /// <para>Maximum velocity value reference for <see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityCurve"/>.</para>
    /// <para><see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityCurve"/> will be interpolated between <see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityMin"/> and <see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityMax"/>.</para>
    /// </summary>
    public float ScaleOverVelocityMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(17));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(17), value);
        }
    }

    /// <summary>
    /// <para>Either a <see cref="Godot.CurveTexture"/> or a <see cref="Godot.CurveXyzTexture"/> that scales each particle based on its velocity.</para>
    /// </summary>
    public Texture2D ScaleOverVelocityCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(17));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(17), value);
        }
    }

    /// <summary>
    /// <para>Each particle's initial color. If the <see cref="Godot.GpuParticles2D"/>'s <c>texture</c> is defined, it will be multiplied by this color.</para>
    /// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.Color"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.ParticleProcessMaterial.Color"/> will have no visible effect.</para>
    /// </summary>
    public Color Color
    {
        get
        {
            return GetColor();
        }
        set
        {
            SetColor(value);
        }
    }

    /// <summary>
    /// <para>Each particle's color will vary along this <see cref="Godot.GradientTexture1D"/> over its lifetime (multiplied with <see cref="Godot.ParticleProcessMaterial.Color"/>).</para>
    /// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.ColorRamp"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.ParticleProcessMaterial.ColorRamp"/> will have no visible effect.</para>
    /// </summary>
    public Texture2D ColorRamp
    {
        get
        {
            return GetColorRamp();
        }
        set
        {
            SetColorRamp(value);
        }
    }

    /// <summary>
    /// <para>Each particle's initial color will vary along this <see cref="Godot.GradientTexture1D"/> (multiplied with <see cref="Godot.ParticleProcessMaterial.Color"/>).</para>
    /// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.ColorInitialRamp"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.ParticleProcessMaterial.ColorInitialRamp"/> will have no visible effect.</para>
    /// </summary>
    public Texture2D ColorInitialRamp
    {
        get
        {
            return GetColorInitialRamp();
        }
        set
        {
            SetColorInitialRamp(value);
        }
    }

    /// <summary>
    /// <para>The alpha value of each particle's color will be multiplied by this <see cref="Godot.CurveTexture"/> over its lifetime.</para>
    /// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.AlphaCurve"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALPHA *= COLOR.a;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.ParticleProcessMaterial.AlphaCurve"/> will have no visible effect.</para>
    /// </summary>
    public Texture2D AlphaCurve
    {
        get
        {
            return GetAlphaCurve();
        }
        set
        {
            SetAlphaCurve(value);
        }
    }

    /// <summary>
    /// <para>Each particle's color will be multiplied by this <see cref="Godot.CurveTexture"/> over its lifetime.</para>
    /// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.EmissionCurve"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.ParticleProcessMaterial.EmissionCurve"/> will have no visible effect.</para>
    /// </summary>
    public Texture2D EmissionCurve
    {
        get
        {
            return GetEmissionCurve();
        }
        set
        {
            SetEmissionCurve(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 HueVariation
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(9));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(9), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.HueVariationMax"/>.</para>
    /// </summary>
    public float HueVariationMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(9));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(9), value);
        }
    }

    /// <summary>
    /// <para>Maximum initial hue variation applied to each particle. It will shift the particle color's hue.</para>
    /// </summary>
    public float HueVariationMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(9));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(9), value);
        }
    }

    /// <summary>
    /// <para>Each particle's hue will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D HueVariationCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(9));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(9), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 AnimSpeed
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(10));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(10), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.AnimSpeedMax"/>.</para>
    /// </summary>
    public float AnimSpeedMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(10));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(10), value);
        }
    }

    /// <summary>
    /// <para>Maximum particle animation speed. Animation speed of <c>1</c> means that the particles will make full <c>0</c> to <c>1</c> offset cycle during lifetime, <c>2</c> means <c>2</c> cycles etc.</para>
    /// <para>With animation speed greater than <c>1</c>, remember to enable <see cref="Godot.CanvasItemMaterial.ParticlesAnimLoop"/> property if you want the animation to repeat.</para>
    /// </summary>
    public float AnimSpeedMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(10));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(10), value);
        }
    }

    /// <summary>
    /// <para>Each particle's animation speed will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D AnimSpeedCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(10));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(10), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 AnimOffset
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(11));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(11), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum equivalent of <see cref="Godot.ParticleProcessMaterial.AnimOffsetMax"/>.</para>
    /// </summary>
    public float AnimOffsetMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(11));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(11), value);
        }
    }

    /// <summary>
    /// <para>Maximum animation offset that corresponds to frame index in the texture. <c>0</c> is the first frame, <c>1</c> is the last one. See <see cref="Godot.CanvasItemMaterial.ParticlesAnimation"/>.</para>
    /// </summary>
    public float AnimOffsetMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(11));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(11), value);
        }
    }

    /// <summary>
    /// <para>Each particle's animation offset will vary along this <see cref="Godot.CurveTexture"/>.</para>
    /// </summary>
    public Texture2D AnimOffsetCurve
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(11));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(11), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables turbulence for the particle system. Turbulence can be used to vary particle movement according to its position (based on a 3D noise pattern). In 3D, <see cref="Godot.GpuParticlesAttractorVectorField3D"/> with <see cref="Godot.NoiseTexture3D"/> can be used as an alternative to turbulence that works in world space and with multiple particle systems reacting in the same way.</para>
    /// <para><b>Note:</b> Enabling turbulence has a high performance cost on the GPU. Only enable turbulence on a few particle systems at once at most, and consider disabling it when targeting mobile/web platforms.</para>
    /// </summary>
    public bool TurbulenceEnabled
    {
        get
        {
            return GetTurbulenceEnabled();
        }
        set
        {
            SetTurbulenceEnabled(value);
        }
    }

    /// <summary>
    /// <para>The turbulence noise strength. Increasing this will result in a stronger, more contrasting, flow pattern.</para>
    /// </summary>
    public float TurbulenceNoiseStrength
    {
        get
        {
            return GetTurbulenceNoiseStrength();
        }
        set
        {
            SetTurbulenceNoiseStrength(value);
        }
    }

    /// <summary>
    /// <para>This value controls the overall scale/frequency of the turbulence noise pattern.</para>
    /// <para>A small scale will result in smaller features with more detail while a high scale will result in smoother noise with larger features.</para>
    /// </summary>
    public float TurbulenceNoiseScale
    {
        get
        {
            return GetTurbulenceNoiseScale();
        }
        set
        {
            SetTurbulenceNoiseScale(value);
        }
    }

    /// <summary>
    /// <para>A scrolling velocity for the turbulence field. This sets a directional trend for the pattern to move in over time.</para>
    /// <para>The default value of <c>Vector3(0, 0, 0)</c> turns off the scrolling.</para>
    /// </summary>
    public Vector3 TurbulenceNoiseSpeed
    {
        get
        {
            return GetTurbulenceNoiseSpeed();
        }
        set
        {
            SetTurbulenceNoiseSpeed(value);
        }
    }

    /// <summary>
    /// <para>The in-place rate of change of the turbulence field. This defines how quickly the noise pattern varies over time.</para>
    /// <para>A value of 0.0 will result in a fixed pattern.</para>
    /// </summary>
    public float TurbulenceNoiseSpeedRandom
    {
        get
        {
            return GetTurbulenceNoiseSpeedRandom();
        }
        set
        {
            SetTurbulenceNoiseSpeedRandom(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 TurbulenceInfluence
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(13));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(13), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum turbulence influence on each particle.</para>
    /// <para>The actual amount of turbulence influence on each particle is calculated as a random value between <see cref="Godot.ParticleProcessMaterial.TurbulenceInfluenceMin"/> and <see cref="Godot.ParticleProcessMaterial.TurbulenceInfluenceMax"/> and multiplied by the amount of turbulence influence from <see cref="Godot.ParticleProcessMaterial.TurbulenceInfluenceOverLife"/>.</para>
    /// </summary>
    public float TurbulenceInfluenceMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(13));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(13), value);
        }
    }

    /// <summary>
    /// <para>Maximum turbulence influence on each particle.</para>
    /// <para>The actual amount of turbulence influence on each particle is calculated as a random value between <see cref="Godot.ParticleProcessMaterial.TurbulenceInfluenceMin"/> and <see cref="Godot.ParticleProcessMaterial.TurbulenceInfluenceMax"/> and multiplied by the amount of turbulence influence from <see cref="Godot.ParticleProcessMaterial.TurbulenceInfluenceOverLife"/>.</para>
    /// </summary>
    public float TurbulenceInfluenceMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(13));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(13), value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2 TurbulenceInitialDisplacement
    {
        get
        {
            return GetParam((ParticleProcessMaterial.Parameter)(14));
        }
        set
        {
            SetParam((ParticleProcessMaterial.Parameter)(14), value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Minimum displacement of each particle's spawn position by the turbulence.</para>
    /// <para>The actual amount of displacement will be a factor of the underlying turbulence multiplied by a random value between <see cref="Godot.ParticleProcessMaterial.TurbulenceInitialDisplacementMin"/> and <see cref="Godot.ParticleProcessMaterial.TurbulenceInitialDisplacementMax"/>.</para>
    /// </summary>
    public float TurbulenceInitialDisplacementMin
    {
        get
        {
            return GetParamMin((ParticleProcessMaterial.Parameter)(14));
        }
        set
        {
            SetParamMin((ParticleProcessMaterial.Parameter)(14), value);
        }
    }

    /// <summary>
    /// <para>Maximum displacement of each particle's spawn position by the turbulence.</para>
    /// <para>The actual amount of displacement will be a factor of the underlying turbulence multiplied by a random value between <see cref="Godot.ParticleProcessMaterial.TurbulenceInitialDisplacementMin"/> and <see cref="Godot.ParticleProcessMaterial.TurbulenceInitialDisplacementMax"/>.</para>
    /// </summary>
    public float TurbulenceInitialDisplacementMax
    {
        get
        {
            return GetParamMax((ParticleProcessMaterial.Parameter)(14));
        }
        set
        {
            SetParamMax((ParticleProcessMaterial.Parameter)(14), value);
        }
    }

    /// <summary>
    /// <para>Each particle's amount of turbulence will be influenced along this <see cref="Godot.CurveTexture"/> over its life time.</para>
    /// </summary>
    public Texture2D TurbulenceInfluenceOverLife
    {
        get
        {
            return GetParamTexture((ParticleProcessMaterial.Parameter)(12));
        }
        set
        {
            SetParamTexture((ParticleProcessMaterial.Parameter)(12), value);
        }
    }

    /// <summary>
    /// <para>The particles' collision mode.</para>
    /// <para><b>Note:</b> 3D Particles can only collide with <see cref="Godot.GpuParticlesCollision3D"/> nodes, not <see cref="Godot.PhysicsBody3D"/> nodes. To make particles collide with various objects, you can add <see cref="Godot.GpuParticlesCollision3D"/> nodes as children of <see cref="Godot.PhysicsBody3D"/> nodes. In 3D, collisions only occur within the area defined by the <see cref="Godot.GpuParticles3D"/> node's <see cref="Godot.GpuParticles3D.VisibilityAabb"/>.</para>
    /// <para><b>Note:</b> 2D Particles can only collide with <see cref="Godot.LightOccluder2D"/> nodes, not <see cref="Godot.PhysicsBody2D"/> nodes.</para>
    /// </summary>
    public ParticleProcessMaterial.CollisionModeEnum CollisionMode
    {
        get
        {
            return GetCollisionMode();
        }
        set
        {
            SetCollisionMode(value);
        }
    }

    /// <summary>
    /// <para>The particles' friction. Values range from <c>0</c> (frictionless) to <c>1</c> (maximum friction). Only effective if <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> is <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/>.</para>
    /// </summary>
    public float CollisionFriction
    {
        get
        {
            return GetCollisionFriction();
        }
        set
        {
            SetCollisionFriction(value);
        }
    }

    /// <summary>
    /// <para>The particles' bounciness. Values range from <c>0</c> (no bounce) to <c>1</c> (full bounciness). Only effective if <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> is <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/>.</para>
    /// </summary>
    public float CollisionBounce
    {
        get
        {
            return GetCollisionBounce();
        }
        set
        {
            SetCollisionBounce(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.GpuParticles3D.CollisionBaseSize"/> is multiplied by the particle's effective scale (see <see cref="Godot.ParticleProcessMaterial.ScaleMin"/>, <see cref="Godot.ParticleProcessMaterial.ScaleMax"/>, <see cref="Godot.ParticleProcessMaterial.ScaleCurve"/>, and <see cref="Godot.ParticleProcessMaterial.ScaleOverVelocityCurve"/>).</para>
    /// </summary>
    public bool CollisionUseScale
    {
        get
        {
            return IsCollisionUsingScale();
        }
        set
        {
            SetCollisionUseScale(value);
        }
    }

    /// <summary>
    /// <para>The particle subemitter mode (see <see cref="Godot.GpuParticles2D.SubEmitter"/> and <see cref="Godot.GpuParticles3D.SubEmitter"/>).</para>
    /// </summary>
    public ParticleProcessMaterial.SubEmitterModeEnum SubEmitterMode
    {
        get
        {
            return GetSubEmitterMode();
        }
        set
        {
            SetSubEmitterMode(value);
        }
    }

    /// <summary>
    /// <para>The frequency at which particles should be emitted from the subemitter node. One particle will be spawned every <see cref="Godot.ParticleProcessMaterial.SubEmitterFrequency"/> seconds.</para>
    /// <para><b>Note:</b> This value shouldn't exceed <see cref="Godot.GpuParticles2D.Amount"/> or <see cref="Godot.GpuParticles3D.Amount"/> defined on the <i>subemitter node</i> (not the main node), relative to the subemitter's particle lifetime. If the number of particles is exceeded, no new particles will spawn from the subemitter until enough particles have expired.</para>
    /// </summary>
    public double SubEmitterFrequency
    {
        get
        {
            return GetSubEmitterFrequency();
        }
        set
        {
            SetSubEmitterFrequency(value);
        }
    }

    /// <summary>
    /// <para>The amount of particles to spawn from the subemitter node when the particle expires.</para>
    /// <para><b>Note:</b> This value shouldn't exceed <see cref="Godot.GpuParticles2D.Amount"/> or <see cref="Godot.GpuParticles3D.Amount"/> defined on the <i>subemitter node</i> (not the main node), relative to the subemitter's particle lifetime. If the number of particles is exceeded, no new particles will spawn from the subemitter until enough particles have expired.</para>
    /// </summary>
    public int SubEmitterAmountAtEnd
    {
        get
        {
            return GetSubEmitterAmountAtEnd();
        }
        set
        {
            SetSubEmitterAmountAtEnd(value);
        }
    }

    /// <summary>
    /// <para>The amount of particles to spawn from the subemitter node when a collision occurs. When combined with <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.HideOnContact"/> on the main particles material, this can be used to achieve effects such as raindrops hitting the ground.</para>
    /// <para><b>Note:</b> This value shouldn't exceed <see cref="Godot.GpuParticles2D.Amount"/> or <see cref="Godot.GpuParticles3D.Amount"/> defined on the <i>subemitter node</i> (not the main node), relative to the subemitter's particle lifetime. If the number of particles is exceeded, no new particles will spawn from the subemitter until enough particles have expired.</para>
    /// </summary>
    public int SubEmitterAmountAtCollision
    {
        get
        {
            return GetSubEmitterAmountAtCollision();
        }
        set
        {
            SetSubEmitterAmountAtCollision(value);
        }
    }

    /// <summary>
    /// <para>The amount of particles to spawn from the subemitter node when the particle spawns.</para>
    /// <para><b>Note:</b> This value shouldn't exceed <see cref="Godot.GpuParticles2D.Amount"/> or <see cref="Godot.GpuParticles3D.Amount"/> defined on the <i>subemitter node</i> (not the main node), relative to the subemitter's particle lifetime. If the number of particles is exceeded, no new particles will spawn from the subemitter until enough particles have expired.</para>
    /// </summary>
    public int SubEmitterAmountAtStart
    {
        get
        {
            return GetSubEmitterAmountAtStart();
        }
        set
        {
            SetSubEmitterAmountAtStart(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the subemitter inherits the parent particle's velocity when it spawns.</para>
    /// </summary>
    public bool SubEmitterKeepVelocity
    {
        get
        {
            return GetSubEmitterKeepVelocity();
        }
        set
        {
            SetSubEmitterKeepVelocity(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ParticleProcessMaterial);

    private static readonly StringName NativeName = "ParticleProcessMaterial";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ParticleProcessMaterial() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ParticleProcessMaterial(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ParticleProcessMaterial(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDirection, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDirection(Vector3 degrees)
    {
        NativeCalls.godot_icall_1_177(MethodBind0, GodotObject.GetPtr(this), &degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirection, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetDirection()
    {
        return NativeCalls.godot_icall_0_125(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInheritVelocityRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInheritVelocityRatio(double ratio)
    {
        NativeCalls.godot_icall_1_127(MethodBind2, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInheritVelocityRatio, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetInheritVelocityRatio()
    {
        return NativeCalls.godot_icall_0_144(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpread, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpread(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpread, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpread()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlatness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlatness(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlatness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFlatness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParam, 676779352ul);

    /// <summary>
    /// <para>Sets the minimum and maximum values of the given <paramref name="param"/>.</para>
    /// <para>The <c>x</c> component of the argument vector corresponds to minimum and the <c>y</c> component corresponds to maximum.</para>
    /// </summary>
    public unsafe void SetParam(ParticleProcessMaterial.Parameter param, Vector2 value)
    {
        NativeCalls.godot_icall_2_147(MethodBind8, GodotObject.GetPtr(this), (int)param, &value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParam, 2623708480ul);

    /// <summary>
    /// <para>Returns the minimum and maximum values of the given <paramref name="param"/> as a vector.</para>
    /// <para>The <c>x</c> component of the returned vector corresponds to minimum and the <c>y</c> component corresponds to maximum.</para>
    /// </summary>
    public Vector2 GetParam(ParticleProcessMaterial.Parameter param)
    {
        return NativeCalls.godot_icall_1_148(MethodBind9, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamMin, 2295964248ul);

    /// <summary>
    /// <para>Sets the minimum value range for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParamMin(ParticleProcessMaterial.Parameter param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind10, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamMin, 3903786503ul);

    /// <summary>
    /// <para>Returns the minimum value range for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetParamMin(ParticleProcessMaterial.Parameter param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind11, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamMax, 2295964248ul);

    /// <summary>
    /// <para>Sets the maximum value range for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParamMax(ParticleProcessMaterial.Parameter param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind12, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamMax, 3903786503ul);

    /// <summary>
    /// <para>Returns the maximum value range for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetParamMax(ParticleProcessMaterial.Parameter param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind13, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamTexture, 526976089ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Texture2D"/> for the specified <see cref="Godot.ParticleProcessMaterial.Parameter"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParamTexture(ParticleProcessMaterial.Parameter param, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind14, GodotObject.GetPtr(this), (int)param, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamTexture, 3489372978ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Texture2D"/> used by the specified parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetParamTexture(ParticleProcessMaterial.Parameter param)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind15, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind16, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorRamp, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorRamp(Texture2D ramp)
    {
        NativeCalls.godot_icall_1_56(MethodBind18, GodotObject.GetPtr(this), GodotObject.GetPtr(ramp));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorRamp, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetColorRamp()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaCurve, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaCurve(Texture2D curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind20, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaCurve, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetAlphaCurve()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionCurve, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionCurve(Texture2D curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind22, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionCurve, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetEmissionCurve()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorInitialRamp, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorInitialRamp(Texture2D ramp)
    {
        NativeCalls.godot_icall_1_56(MethodBind24, GodotObject.GetPtr(this), GodotObject.GetPtr(ramp));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorInitialRamp, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetColorInitialRamp()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocityLimitCurve, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVelocityLimitCurve(Texture2D curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind26, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityLimitCurve, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetVelocityLimitCurve()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParticleFlag, 1711815571ul);

    /// <summary>
    /// <para>Sets the <paramref name="particleFlag"/> to <paramref name="enable"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParticleFlag(ParticleProcessMaterial.ParticleFlags particleFlag, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind28, GodotObject.GetPtr(this), (int)particleFlag, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParticleFlag, 3895316907ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified particle flag is enabled.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetParticleFlag(ParticleProcessMaterial.ParticleFlags particleFlag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind29, GodotObject.GetPtr(this), (int)particleFlag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocityPivot, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVelocityPivot(Vector3 pivot)
    {
        NativeCalls.godot_icall_1_177(MethodBind30, GodotObject.GetPtr(this), &pivot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityPivot, 3783033775ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetVelocityPivot()
    {
        return NativeCalls.godot_icall_0_125(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionShape, 461501442ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionShape(ParticleProcessMaterial.EmissionShapeEnum shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind32, GodotObject.GetPtr(this), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionShape, 3719733018ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ParticleProcessMaterial.EmissionShapeEnum GetEmissionShape()
    {
        return (ParticleProcessMaterial.EmissionShapeEnum)NativeCalls.godot_icall_0_39(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionSphereRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionSphereRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind34, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionSphereRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionSphereRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionBoxExtents, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEmissionBoxExtents(Vector3 extents)
    {
        NativeCalls.godot_icall_1_177(MethodBind36, GodotObject.GetPtr(this), &extents);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionBoxExtents, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetEmissionBoxExtents()
    {
        return NativeCalls.godot_icall_0_125(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionPointTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionPointTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind38, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionPointTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetEmissionPointTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionNormalTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionNormalTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind40, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionNormalTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetEmissionNormalTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionColorTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionColorTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind42, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionColorTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetEmissionColorTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionPointCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionPointCount(int pointCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind44, GodotObject.GetPtr(this), pointCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionPointCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetEmissionPointCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingAxis, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEmissionRingAxis(Vector3 axis)
    {
        NativeCalls.godot_icall_1_177(MethodBind46, GodotObject.GetPtr(this), &axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingAxis, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetEmissionRingAxis()
    {
        return NativeCalls.godot_icall_0_125(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind48, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind50, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingInnerRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingInnerRadius(float innerRadius)
    {
        NativeCalls.godot_icall_1_67(MethodBind52, GodotObject.GetPtr(this), innerRadius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingInnerRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingInnerRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingConeAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingConeAngle(float coneAngle)
    {
        NativeCalls.godot_icall_1_67(MethodBind54, GodotObject.GetPtr(this), coneAngle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingConeAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingConeAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionShapeOffset, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEmissionShapeOffset(Vector3 emissionShapeOffset)
    {
        NativeCalls.godot_icall_1_177(MethodBind56, GodotObject.GetPtr(this), &emissionShapeOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionShapeOffset, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetEmissionShapeOffset()
    {
        return NativeCalls.godot_icall_0_125(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionShapeScale, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEmissionShapeScale(Vector3 emissionShapeScale)
    {
        NativeCalls.godot_icall_1_177(MethodBind58, GodotObject.GetPtr(this), &emissionShapeScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionShapeScale, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetEmissionShapeScale()
    {
        return NativeCalls.godot_icall_0_125(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTurbulenceEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetTurbulenceEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind60, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTurbulenceEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTurbulenceEnabled(bool turbulenceEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind61, GodotObject.GetPtr(this), turbulenceEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTurbulenceNoiseStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTurbulenceNoiseStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind62, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTurbulenceNoiseStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTurbulenceNoiseStrength(float turbulenceNoiseStrength)
    {
        NativeCalls.godot_icall_1_67(MethodBind63, GodotObject.GetPtr(this), turbulenceNoiseStrength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTurbulenceNoiseScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTurbulenceNoiseScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind64, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTurbulenceNoiseScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTurbulenceNoiseScale(float turbulenceNoiseScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind65, GodotObject.GetPtr(this), turbulenceNoiseScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTurbulenceNoiseSpeedRandom, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTurbulenceNoiseSpeedRandom()
    {
        return NativeCalls.godot_icall_0_68(MethodBind66, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTurbulenceNoiseSpeedRandom, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTurbulenceNoiseSpeedRandom(float turbulenceNoiseSpeedRandom)
    {
        NativeCalls.godot_icall_1_67(MethodBind67, GodotObject.GetPtr(this), turbulenceNoiseSpeedRandom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTurbulenceNoiseSpeed, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetTurbulenceNoiseSpeed()
    {
        return NativeCalls.godot_icall_0_125(MethodBind68, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTurbulenceNoiseSpeed, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTurbulenceNoiseSpeed(Vector3 turbulenceNoiseSpeed)
    {
        NativeCalls.godot_icall_1_177(MethodBind69, GodotObject.GetPtr(this), &turbulenceNoiseSpeed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetGravity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind70, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGravity(Vector3 accelVec)
    {
        NativeCalls.godot_icall_1_177(MethodBind71, GodotObject.GetPtr(this), &accelVec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLifetimeRandomness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLifetimeRandomness(double randomness)
    {
        NativeCalls.godot_icall_1_127(MethodBind72, GodotObject.GetPtr(this), randomness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLifetimeRandomness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetLifetimeRandomness()
    {
        return NativeCalls.godot_icall_0_144(MethodBind73, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubEmitterMode, 2399052877ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ParticleProcessMaterial.SubEmitterModeEnum GetSubEmitterMode()
    {
        return (ParticleProcessMaterial.SubEmitterModeEnum)NativeCalls.godot_icall_0_39(MethodBind74, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubEmitterMode, 2161806672ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubEmitterMode(ParticleProcessMaterial.SubEmitterModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind75, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubEmitterFrequency, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetSubEmitterFrequency()
    {
        return NativeCalls.godot_icall_0_144(MethodBind76, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubEmitterFrequency, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubEmitterFrequency(double hz)
    {
        NativeCalls.godot_icall_1_127(MethodBind77, GodotObject.GetPtr(this), hz);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubEmitterAmountAtEnd, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubEmitterAmountAtEnd()
    {
        return NativeCalls.godot_icall_0_39(MethodBind78, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubEmitterAmountAtEnd, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubEmitterAmountAtEnd(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind79, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubEmitterAmountAtCollision, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubEmitterAmountAtCollision()
    {
        return NativeCalls.godot_icall_0_39(MethodBind80, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubEmitterAmountAtCollision, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubEmitterAmountAtCollision(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind81, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubEmitterAmountAtStart, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubEmitterAmountAtStart()
    {
        return NativeCalls.godot_icall_0_39(MethodBind82, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubEmitterAmountAtStart, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubEmitterAmountAtStart(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind83, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubEmitterKeepVelocity, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSubEmitterKeepVelocity()
    {
        return NativeCalls.godot_icall_0_15(MethodBind84, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubEmitterKeepVelocity, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubEmitterKeepVelocity(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind85, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttractorInteractionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttractorInteractionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind86, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAttractorInteractionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAttractorInteractionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind87, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMode, 653804659ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMode(ParticleProcessMaterial.CollisionModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind88, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMode, 139371864ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ParticleProcessMaterial.CollisionModeEnum GetCollisionMode()
    {
        return (ParticleProcessMaterial.CollisionModeEnum)NativeCalls.godot_icall_0_39(MethodBind89, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionUseScale, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionUseScale(bool radius)
    {
        NativeCalls.godot_icall_1_14(MethodBind90, GodotObject.GetPtr(this), radius.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollisionUsingScale, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollisionUsingScale()
    {
        return NativeCalls.godot_icall_0_15(MethodBind91, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionFriction, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionFriction(float friction)
    {
        NativeCalls.godot_icall_1_67(MethodBind92, GodotObject.GetPtr(this), friction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionFriction, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCollisionFriction()
    {
        return NativeCalls.godot_icall_0_68(MethodBind93, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionBounce, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionBounce(float bounce)
    {
        NativeCalls.godot_icall_1_67(MethodBind94, GodotObject.GetPtr(this), bounce);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionBounce, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCollisionBounce()
    {
        return NativeCalls.godot_icall_0_68(MethodBind95, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when this material's emission shape is changed in any way. This includes changes to <see cref="Godot.ParticleProcessMaterial.EmissionShape"/>, <see cref="Godot.ParticleProcessMaterial.EmissionShapeScale"/>, or <see cref="Godot.ParticleProcessMaterial.EmissionSphereRadius"/>, and any other property that affects the emission shape's offset, size, scale, or orientation.</para>
    /// <para><b>Note:</b> This signal is only emitted inside the editor for performance reasons.</para>
    /// </summary>
    public event Action EmissionShapeChanged
    {
        add => Connect(SignalName.EmissionShapeChanged, Callable.From(value));
        remove => Disconnect(SignalName.EmissionShapeChanged, Callable.From(value));
    }

    protected void EmitSignalEmissionShapeChanged()
    {
        EmitSignal(SignalName.EmissionShapeChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_emission_shape_changed = "EmissionShapeChanged";

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
        if (signal == SignalName.EmissionShapeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_emission_shape_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Material.PropertyName
    {
        /// <summary>
        /// Cached name for the 'lifetime_randomness' property.
        /// </summary>
        public static readonly StringName LifetimeRandomness = "lifetime_randomness";
        /// <summary>
        /// Cached name for the 'particle_flag_align_y' property.
        /// </summary>
        public static readonly StringName ParticleFlagAlignY = "particle_flag_align_y";
        /// <summary>
        /// Cached name for the 'particle_flag_rotate_y' property.
        /// </summary>
        public static readonly StringName ParticleFlagRotateY = "particle_flag_rotate_y";
        /// <summary>
        /// Cached name for the 'particle_flag_disable_z' property.
        /// </summary>
        public static readonly StringName ParticleFlagDisableZ = "particle_flag_disable_z";
        /// <summary>
        /// Cached name for the 'particle_flag_damping_as_friction' property.
        /// </summary>
        public static readonly StringName ParticleFlagDampingAsFriction = "particle_flag_damping_as_friction";
        /// <summary>
        /// Cached name for the 'emission_shape_offset' property.
        /// </summary>
        public static readonly StringName EmissionShapeOffset = "emission_shape_offset";
        /// <summary>
        /// Cached name for the 'emission_shape_scale' property.
        /// </summary>
        public static readonly StringName EmissionShapeScale = "emission_shape_scale";
        /// <summary>
        /// Cached name for the 'emission_shape' property.
        /// </summary>
        public static readonly StringName EmissionShape = "emission_shape";
        /// <summary>
        /// Cached name for the 'emission_sphere_radius' property.
        /// </summary>
        public static readonly StringName EmissionSphereRadius = "emission_sphere_radius";
        /// <summary>
        /// Cached name for the 'emission_box_extents' property.
        /// </summary>
        public static readonly StringName EmissionBoxExtents = "emission_box_extents";
        /// <summary>
        /// Cached name for the 'emission_point_texture' property.
        /// </summary>
        public static readonly StringName EmissionPointTexture = "emission_point_texture";
        /// <summary>
        /// Cached name for the 'emission_normal_texture' property.
        /// </summary>
        public static readonly StringName EmissionNormalTexture = "emission_normal_texture";
        /// <summary>
        /// Cached name for the 'emission_color_texture' property.
        /// </summary>
        public static readonly StringName EmissionColorTexture = "emission_color_texture";
        /// <summary>
        /// Cached name for the 'emission_point_count' property.
        /// </summary>
        public static readonly StringName EmissionPointCount = "emission_point_count";
        /// <summary>
        /// Cached name for the 'emission_ring_axis' property.
        /// </summary>
        public static readonly StringName EmissionRingAxis = "emission_ring_axis";
        /// <summary>
        /// Cached name for the 'emission_ring_height' property.
        /// </summary>
        public static readonly StringName EmissionRingHeight = "emission_ring_height";
        /// <summary>
        /// Cached name for the 'emission_ring_radius' property.
        /// </summary>
        public static readonly StringName EmissionRingRadius = "emission_ring_radius";
        /// <summary>
        /// Cached name for the 'emission_ring_inner_radius' property.
        /// </summary>
        public static readonly StringName EmissionRingInnerRadius = "emission_ring_inner_radius";
        /// <summary>
        /// Cached name for the 'emission_ring_cone_angle' property.
        /// </summary>
        public static readonly StringName EmissionRingConeAngle = "emission_ring_cone_angle";
        /// <summary>
        /// Cached name for the 'angle' property.
        /// </summary>
        public static readonly StringName Angle = "angle";
        /// <summary>
        /// Cached name for the 'angle_min' property.
        /// </summary>
        public static readonly StringName AngleMin = "angle_min";
        /// <summary>
        /// Cached name for the 'angle_max' property.
        /// </summary>
        public static readonly StringName AngleMax = "angle_max";
        /// <summary>
        /// Cached name for the 'angle_curve' property.
        /// </summary>
        public static readonly StringName AngleCurve = "angle_curve";
        /// <summary>
        /// Cached name for the 'inherit_velocity_ratio' property.
        /// </summary>
        public static readonly StringName InheritVelocityRatio = "inherit_velocity_ratio";
        /// <summary>
        /// Cached name for the 'velocity_pivot' property.
        /// </summary>
        public static readonly StringName VelocityPivot = "velocity_pivot";
        /// <summary>
        /// Cached name for the 'direction' property.
        /// </summary>
        public static readonly StringName Direction = "direction";
        /// <summary>
        /// Cached name for the 'spread' property.
        /// </summary>
        public static readonly StringName Spread = "spread";
        /// <summary>
        /// Cached name for the 'flatness' property.
        /// </summary>
        public static readonly StringName Flatness = "flatness";
        /// <summary>
        /// Cached name for the 'initial_velocity' property.
        /// </summary>
        public static readonly StringName InitialVelocity = "initial_velocity";
        /// <summary>
        /// Cached name for the 'initial_velocity_min' property.
        /// </summary>
        public static readonly StringName InitialVelocityMin = "initial_velocity_min";
        /// <summary>
        /// Cached name for the 'initial_velocity_max' property.
        /// </summary>
        public static readonly StringName InitialVelocityMax = "initial_velocity_max";
        /// <summary>
        /// Cached name for the 'angular_velocity' property.
        /// </summary>
        public static readonly StringName AngularVelocity = "angular_velocity";
        /// <summary>
        /// Cached name for the 'angular_velocity_min' property.
        /// </summary>
        public static readonly StringName AngularVelocityMin = "angular_velocity_min";
        /// <summary>
        /// Cached name for the 'angular_velocity_max' property.
        /// </summary>
        public static readonly StringName AngularVelocityMax = "angular_velocity_max";
        /// <summary>
        /// Cached name for the 'angular_velocity_curve' property.
        /// </summary>
        public static readonly StringName AngularVelocityCurve = "angular_velocity_curve";
        /// <summary>
        /// Cached name for the 'directional_velocity' property.
        /// </summary>
        public static readonly StringName DirectionalVelocity = "directional_velocity";
        /// <summary>
        /// Cached name for the 'directional_velocity_min' property.
        /// </summary>
        public static readonly StringName DirectionalVelocityMin = "directional_velocity_min";
        /// <summary>
        /// Cached name for the 'directional_velocity_max' property.
        /// </summary>
        public static readonly StringName DirectionalVelocityMax = "directional_velocity_max";
        /// <summary>
        /// Cached name for the 'directional_velocity_curve' property.
        /// </summary>
        public static readonly StringName DirectionalVelocityCurve = "directional_velocity_curve";
        /// <summary>
        /// Cached name for the 'orbit_velocity' property.
        /// </summary>
        public static readonly StringName OrbitVelocity = "orbit_velocity";
        /// <summary>
        /// Cached name for the 'orbit_velocity_min' property.
        /// </summary>
        public static readonly StringName OrbitVelocityMin = "orbit_velocity_min";
        /// <summary>
        /// Cached name for the 'orbit_velocity_max' property.
        /// </summary>
        public static readonly StringName OrbitVelocityMax = "orbit_velocity_max";
        /// <summary>
        /// Cached name for the 'orbit_velocity_curve' property.
        /// </summary>
        public static readonly StringName OrbitVelocityCurve = "orbit_velocity_curve";
        /// <summary>
        /// Cached name for the 'radial_velocity' property.
        /// </summary>
        public static readonly StringName RadialVelocity = "radial_velocity";
        /// <summary>
        /// Cached name for the 'radial_velocity_min' property.
        /// </summary>
        public static readonly StringName RadialVelocityMin = "radial_velocity_min";
        /// <summary>
        /// Cached name for the 'radial_velocity_max' property.
        /// </summary>
        public static readonly StringName RadialVelocityMax = "radial_velocity_max";
        /// <summary>
        /// Cached name for the 'radial_velocity_curve' property.
        /// </summary>
        public static readonly StringName RadialVelocityCurve = "radial_velocity_curve";
        /// <summary>
        /// Cached name for the 'velocity_limit_curve' property.
        /// </summary>
        public static readonly StringName VelocityLimitCurve = "velocity_limit_curve";
        /// <summary>
        /// Cached name for the 'gravity' property.
        /// </summary>
        public static readonly StringName Gravity = "gravity";
        /// <summary>
        /// Cached name for the 'linear_accel' property.
        /// </summary>
        public static readonly StringName LinearAccel = "linear_accel";
        /// <summary>
        /// Cached name for the 'linear_accel_min' property.
        /// </summary>
        public static readonly StringName LinearAccelMin = "linear_accel_min";
        /// <summary>
        /// Cached name for the 'linear_accel_max' property.
        /// </summary>
        public static readonly StringName LinearAccelMax = "linear_accel_max";
        /// <summary>
        /// Cached name for the 'linear_accel_curve' property.
        /// </summary>
        public static readonly StringName LinearAccelCurve = "linear_accel_curve";
        /// <summary>
        /// Cached name for the 'radial_accel' property.
        /// </summary>
        public static readonly StringName RadialAccel = "radial_accel";
        /// <summary>
        /// Cached name for the 'radial_accel_min' property.
        /// </summary>
        public static readonly StringName RadialAccelMin = "radial_accel_min";
        /// <summary>
        /// Cached name for the 'radial_accel_max' property.
        /// </summary>
        public static readonly StringName RadialAccelMax = "radial_accel_max";
        /// <summary>
        /// Cached name for the 'radial_accel_curve' property.
        /// </summary>
        public static readonly StringName RadialAccelCurve = "radial_accel_curve";
        /// <summary>
        /// Cached name for the 'tangential_accel' property.
        /// </summary>
        public static readonly StringName TangentialAccel = "tangential_accel";
        /// <summary>
        /// Cached name for the 'tangential_accel_min' property.
        /// </summary>
        public static readonly StringName TangentialAccelMin = "tangential_accel_min";
        /// <summary>
        /// Cached name for the 'tangential_accel_max' property.
        /// </summary>
        public static readonly StringName TangentialAccelMax = "tangential_accel_max";
        /// <summary>
        /// Cached name for the 'tangential_accel_curve' property.
        /// </summary>
        public static readonly StringName TangentialAccelCurve = "tangential_accel_curve";
        /// <summary>
        /// Cached name for the 'damping' property.
        /// </summary>
        public static readonly StringName Damping = "damping";
        /// <summary>
        /// Cached name for the 'damping_min' property.
        /// </summary>
        public static readonly StringName DampingMin = "damping_min";
        /// <summary>
        /// Cached name for the 'damping_max' property.
        /// </summary>
        public static readonly StringName DampingMax = "damping_max";
        /// <summary>
        /// Cached name for the 'damping_curve' property.
        /// </summary>
        public static readonly StringName DampingCurve = "damping_curve";
        /// <summary>
        /// Cached name for the 'attractor_interaction_enabled' property.
        /// </summary>
        public static readonly StringName AttractorInteractionEnabled = "attractor_interaction_enabled";
        /// <summary>
        /// Cached name for the 'scale' property.
        /// </summary>
        public static readonly StringName Scale = "scale";
        /// <summary>
        /// Cached name for the 'scale_min' property.
        /// </summary>
        public static readonly StringName ScaleMin = "scale_min";
        /// <summary>
        /// Cached name for the 'scale_max' property.
        /// </summary>
        public static readonly StringName ScaleMax = "scale_max";
        /// <summary>
        /// Cached name for the 'scale_curve' property.
        /// </summary>
        public static readonly StringName ScaleCurve = "scale_curve";
        /// <summary>
        /// Cached name for the 'scale_over_velocity' property.
        /// </summary>
        public static readonly StringName ScaleOverVelocity = "scale_over_velocity";
        /// <summary>
        /// Cached name for the 'scale_over_velocity_min' property.
        /// </summary>
        public static readonly StringName ScaleOverVelocityMin = "scale_over_velocity_min";
        /// <summary>
        /// Cached name for the 'scale_over_velocity_max' property.
        /// </summary>
        public static readonly StringName ScaleOverVelocityMax = "scale_over_velocity_max";
        /// <summary>
        /// Cached name for the 'scale_over_velocity_curve' property.
        /// </summary>
        public static readonly StringName ScaleOverVelocityCurve = "scale_over_velocity_curve";
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'color_ramp' property.
        /// </summary>
        public static readonly StringName ColorRamp = "color_ramp";
        /// <summary>
        /// Cached name for the 'color_initial_ramp' property.
        /// </summary>
        public static readonly StringName ColorInitialRamp = "color_initial_ramp";
        /// <summary>
        /// Cached name for the 'alpha_curve' property.
        /// </summary>
        public static readonly StringName AlphaCurve = "alpha_curve";
        /// <summary>
        /// Cached name for the 'emission_curve' property.
        /// </summary>
        public static readonly StringName EmissionCurve = "emission_curve";
        /// <summary>
        /// Cached name for the 'hue_variation' property.
        /// </summary>
        public static readonly StringName HueVariation = "hue_variation";
        /// <summary>
        /// Cached name for the 'hue_variation_min' property.
        /// </summary>
        public static readonly StringName HueVariationMin = "hue_variation_min";
        /// <summary>
        /// Cached name for the 'hue_variation_max' property.
        /// </summary>
        public static readonly StringName HueVariationMax = "hue_variation_max";
        /// <summary>
        /// Cached name for the 'hue_variation_curve' property.
        /// </summary>
        public static readonly StringName HueVariationCurve = "hue_variation_curve";
        /// <summary>
        /// Cached name for the 'anim_speed' property.
        /// </summary>
        public static readonly StringName AnimSpeed = "anim_speed";
        /// <summary>
        /// Cached name for the 'anim_speed_min' property.
        /// </summary>
        public static readonly StringName AnimSpeedMin = "anim_speed_min";
        /// <summary>
        /// Cached name for the 'anim_speed_max' property.
        /// </summary>
        public static readonly StringName AnimSpeedMax = "anim_speed_max";
        /// <summary>
        /// Cached name for the 'anim_speed_curve' property.
        /// </summary>
        public static readonly StringName AnimSpeedCurve = "anim_speed_curve";
        /// <summary>
        /// Cached name for the 'anim_offset' property.
        /// </summary>
        public static readonly StringName AnimOffset = "anim_offset";
        /// <summary>
        /// Cached name for the 'anim_offset_min' property.
        /// </summary>
        public static readonly StringName AnimOffsetMin = "anim_offset_min";
        /// <summary>
        /// Cached name for the 'anim_offset_max' property.
        /// </summary>
        public static readonly StringName AnimOffsetMax = "anim_offset_max";
        /// <summary>
        /// Cached name for the 'anim_offset_curve' property.
        /// </summary>
        public static readonly StringName AnimOffsetCurve = "anim_offset_curve";
        /// <summary>
        /// Cached name for the 'turbulence_enabled' property.
        /// </summary>
        public static readonly StringName TurbulenceEnabled = "turbulence_enabled";
        /// <summary>
        /// Cached name for the 'turbulence_noise_strength' property.
        /// </summary>
        public static readonly StringName TurbulenceNoiseStrength = "turbulence_noise_strength";
        /// <summary>
        /// Cached name for the 'turbulence_noise_scale' property.
        /// </summary>
        public static readonly StringName TurbulenceNoiseScale = "turbulence_noise_scale";
        /// <summary>
        /// Cached name for the 'turbulence_noise_speed' property.
        /// </summary>
        public static readonly StringName TurbulenceNoiseSpeed = "turbulence_noise_speed";
        /// <summary>
        /// Cached name for the 'turbulence_noise_speed_random' property.
        /// </summary>
        public static readonly StringName TurbulenceNoiseSpeedRandom = "turbulence_noise_speed_random";
        /// <summary>
        /// Cached name for the 'turbulence_influence' property.
        /// </summary>
        public static readonly StringName TurbulenceInfluence = "turbulence_influence";
        /// <summary>
        /// Cached name for the 'turbulence_influence_min' property.
        /// </summary>
        public static readonly StringName TurbulenceInfluenceMin = "turbulence_influence_min";
        /// <summary>
        /// Cached name for the 'turbulence_influence_max' property.
        /// </summary>
        public static readonly StringName TurbulenceInfluenceMax = "turbulence_influence_max";
        /// <summary>
        /// Cached name for the 'turbulence_initial_displacement' property.
        /// </summary>
        public static readonly StringName TurbulenceInitialDisplacement = "turbulence_initial_displacement";
        /// <summary>
        /// Cached name for the 'turbulence_initial_displacement_min' property.
        /// </summary>
        public static readonly StringName TurbulenceInitialDisplacementMin = "turbulence_initial_displacement_min";
        /// <summary>
        /// Cached name for the 'turbulence_initial_displacement_max' property.
        /// </summary>
        public static readonly StringName TurbulenceInitialDisplacementMax = "turbulence_initial_displacement_max";
        /// <summary>
        /// Cached name for the 'turbulence_influence_over_life' property.
        /// </summary>
        public static readonly StringName TurbulenceInfluenceOverLife = "turbulence_influence_over_life";
        /// <summary>
        /// Cached name for the 'collision_mode' property.
        /// </summary>
        public static readonly StringName CollisionMode = "collision_mode";
        /// <summary>
        /// Cached name for the 'collision_friction' property.
        /// </summary>
        public static readonly StringName CollisionFriction = "collision_friction";
        /// <summary>
        /// Cached name for the 'collision_bounce' property.
        /// </summary>
        public static readonly StringName CollisionBounce = "collision_bounce";
        /// <summary>
        /// Cached name for the 'collision_use_scale' property.
        /// </summary>
        public static readonly StringName CollisionUseScale = "collision_use_scale";
        /// <summary>
        /// Cached name for the 'sub_emitter_mode' property.
        /// </summary>
        public static readonly StringName SubEmitterMode = "sub_emitter_mode";
        /// <summary>
        /// Cached name for the 'sub_emitter_frequency' property.
        /// </summary>
        public static readonly StringName SubEmitterFrequency = "sub_emitter_frequency";
        /// <summary>
        /// Cached name for the 'sub_emitter_amount_at_end' property.
        /// </summary>
        public static readonly StringName SubEmitterAmountAtEnd = "sub_emitter_amount_at_end";
        /// <summary>
        /// Cached name for the 'sub_emitter_amount_at_collision' property.
        /// </summary>
        public static readonly StringName SubEmitterAmountAtCollision = "sub_emitter_amount_at_collision";
        /// <summary>
        /// Cached name for the 'sub_emitter_amount_at_start' property.
        /// </summary>
        public static readonly StringName SubEmitterAmountAtStart = "sub_emitter_amount_at_start";
        /// <summary>
        /// Cached name for the 'sub_emitter_keep_velocity' property.
        /// </summary>
        public static readonly StringName SubEmitterKeepVelocity = "sub_emitter_keep_velocity";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Material.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_direction' method.
        /// </summary>
        public static readonly StringName SetDirection = "set_direction";
        /// <summary>
        /// Cached name for the 'get_direction' method.
        /// </summary>
        public static readonly StringName GetDirection = "get_direction";
        /// <summary>
        /// Cached name for the 'set_inherit_velocity_ratio' method.
        /// </summary>
        public static readonly StringName SetInheritVelocityRatio = "set_inherit_velocity_ratio";
        /// <summary>
        /// Cached name for the 'get_inherit_velocity_ratio' method.
        /// </summary>
        public static readonly StringName GetInheritVelocityRatio = "get_inherit_velocity_ratio";
        /// <summary>
        /// Cached name for the 'set_spread' method.
        /// </summary>
        public static readonly StringName SetSpread = "set_spread";
        /// <summary>
        /// Cached name for the 'get_spread' method.
        /// </summary>
        public static readonly StringName GetSpread = "get_spread";
        /// <summary>
        /// Cached name for the 'set_flatness' method.
        /// </summary>
        public static readonly StringName SetFlatness = "set_flatness";
        /// <summary>
        /// Cached name for the 'get_flatness' method.
        /// </summary>
        public static readonly StringName GetFlatness = "get_flatness";
        /// <summary>
        /// Cached name for the 'set_param' method.
        /// </summary>
        public static readonly StringName SetParam = "set_param";
        /// <summary>
        /// Cached name for the 'get_param' method.
        /// </summary>
        public static readonly StringName GetParam = "get_param";
        /// <summary>
        /// Cached name for the 'set_param_min' method.
        /// </summary>
        public static readonly StringName SetParamMin = "set_param_min";
        /// <summary>
        /// Cached name for the 'get_param_min' method.
        /// </summary>
        public static readonly StringName GetParamMin = "get_param_min";
        /// <summary>
        /// Cached name for the 'set_param_max' method.
        /// </summary>
        public static readonly StringName SetParamMax = "set_param_max";
        /// <summary>
        /// Cached name for the 'get_param_max' method.
        /// </summary>
        public static readonly StringName GetParamMax = "get_param_max";
        /// <summary>
        /// Cached name for the 'set_param_texture' method.
        /// </summary>
        public static readonly StringName SetParamTexture = "set_param_texture";
        /// <summary>
        /// Cached name for the 'get_param_texture' method.
        /// </summary>
        public static readonly StringName GetParamTexture = "get_param_texture";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_color_ramp' method.
        /// </summary>
        public static readonly StringName SetColorRamp = "set_color_ramp";
        /// <summary>
        /// Cached name for the 'get_color_ramp' method.
        /// </summary>
        public static readonly StringName GetColorRamp = "get_color_ramp";
        /// <summary>
        /// Cached name for the 'set_alpha_curve' method.
        /// </summary>
        public static readonly StringName SetAlphaCurve = "set_alpha_curve";
        /// <summary>
        /// Cached name for the 'get_alpha_curve' method.
        /// </summary>
        public static readonly StringName GetAlphaCurve = "get_alpha_curve";
        /// <summary>
        /// Cached name for the 'set_emission_curve' method.
        /// </summary>
        public static readonly StringName SetEmissionCurve = "set_emission_curve";
        /// <summary>
        /// Cached name for the 'get_emission_curve' method.
        /// </summary>
        public static readonly StringName GetEmissionCurve = "get_emission_curve";
        /// <summary>
        /// Cached name for the 'set_color_initial_ramp' method.
        /// </summary>
        public static readonly StringName SetColorInitialRamp = "set_color_initial_ramp";
        /// <summary>
        /// Cached name for the 'get_color_initial_ramp' method.
        /// </summary>
        public static readonly StringName GetColorInitialRamp = "get_color_initial_ramp";
        /// <summary>
        /// Cached name for the 'set_velocity_limit_curve' method.
        /// </summary>
        public static readonly StringName SetVelocityLimitCurve = "set_velocity_limit_curve";
        /// <summary>
        /// Cached name for the 'get_velocity_limit_curve' method.
        /// </summary>
        public static readonly StringName GetVelocityLimitCurve = "get_velocity_limit_curve";
        /// <summary>
        /// Cached name for the 'set_particle_flag' method.
        /// </summary>
        public static readonly StringName SetParticleFlag = "set_particle_flag";
        /// <summary>
        /// Cached name for the 'get_particle_flag' method.
        /// </summary>
        public static readonly StringName GetParticleFlag = "get_particle_flag";
        /// <summary>
        /// Cached name for the 'set_velocity_pivot' method.
        /// </summary>
        public static readonly StringName SetVelocityPivot = "set_velocity_pivot";
        /// <summary>
        /// Cached name for the 'get_velocity_pivot' method.
        /// </summary>
        public static readonly StringName GetVelocityPivot = "get_velocity_pivot";
        /// <summary>
        /// Cached name for the 'set_emission_shape' method.
        /// </summary>
        public static readonly StringName SetEmissionShape = "set_emission_shape";
        /// <summary>
        /// Cached name for the 'get_emission_shape' method.
        /// </summary>
        public static readonly StringName GetEmissionShape = "get_emission_shape";
        /// <summary>
        /// Cached name for the 'set_emission_sphere_radius' method.
        /// </summary>
        public static readonly StringName SetEmissionSphereRadius = "set_emission_sphere_radius";
        /// <summary>
        /// Cached name for the 'get_emission_sphere_radius' method.
        /// </summary>
        public static readonly StringName GetEmissionSphereRadius = "get_emission_sphere_radius";
        /// <summary>
        /// Cached name for the 'set_emission_box_extents' method.
        /// </summary>
        public static readonly StringName SetEmissionBoxExtents = "set_emission_box_extents";
        /// <summary>
        /// Cached name for the 'get_emission_box_extents' method.
        /// </summary>
        public static readonly StringName GetEmissionBoxExtents = "get_emission_box_extents";
        /// <summary>
        /// Cached name for the 'set_emission_point_texture' method.
        /// </summary>
        public static readonly StringName SetEmissionPointTexture = "set_emission_point_texture";
        /// <summary>
        /// Cached name for the 'get_emission_point_texture' method.
        /// </summary>
        public static readonly StringName GetEmissionPointTexture = "get_emission_point_texture";
        /// <summary>
        /// Cached name for the 'set_emission_normal_texture' method.
        /// </summary>
        public static readonly StringName SetEmissionNormalTexture = "set_emission_normal_texture";
        /// <summary>
        /// Cached name for the 'get_emission_normal_texture' method.
        /// </summary>
        public static readonly StringName GetEmissionNormalTexture = "get_emission_normal_texture";
        /// <summary>
        /// Cached name for the 'set_emission_color_texture' method.
        /// </summary>
        public static readonly StringName SetEmissionColorTexture = "set_emission_color_texture";
        /// <summary>
        /// Cached name for the 'get_emission_color_texture' method.
        /// </summary>
        public static readonly StringName GetEmissionColorTexture = "get_emission_color_texture";
        /// <summary>
        /// Cached name for the 'set_emission_point_count' method.
        /// </summary>
        public static readonly StringName SetEmissionPointCount = "set_emission_point_count";
        /// <summary>
        /// Cached name for the 'get_emission_point_count' method.
        /// </summary>
        public static readonly StringName GetEmissionPointCount = "get_emission_point_count";
        /// <summary>
        /// Cached name for the 'set_emission_ring_axis' method.
        /// </summary>
        public static readonly StringName SetEmissionRingAxis = "set_emission_ring_axis";
        /// <summary>
        /// Cached name for the 'get_emission_ring_axis' method.
        /// </summary>
        public static readonly StringName GetEmissionRingAxis = "get_emission_ring_axis";
        /// <summary>
        /// Cached name for the 'set_emission_ring_height' method.
        /// </summary>
        public static readonly StringName SetEmissionRingHeight = "set_emission_ring_height";
        /// <summary>
        /// Cached name for the 'get_emission_ring_height' method.
        /// </summary>
        public static readonly StringName GetEmissionRingHeight = "get_emission_ring_height";
        /// <summary>
        /// Cached name for the 'set_emission_ring_radius' method.
        /// </summary>
        public static readonly StringName SetEmissionRingRadius = "set_emission_ring_radius";
        /// <summary>
        /// Cached name for the 'get_emission_ring_radius' method.
        /// </summary>
        public static readonly StringName GetEmissionRingRadius = "get_emission_ring_radius";
        /// <summary>
        /// Cached name for the 'set_emission_ring_inner_radius' method.
        /// </summary>
        public static readonly StringName SetEmissionRingInnerRadius = "set_emission_ring_inner_radius";
        /// <summary>
        /// Cached name for the 'get_emission_ring_inner_radius' method.
        /// </summary>
        public static readonly StringName GetEmissionRingInnerRadius = "get_emission_ring_inner_radius";
        /// <summary>
        /// Cached name for the 'set_emission_ring_cone_angle' method.
        /// </summary>
        public static readonly StringName SetEmissionRingConeAngle = "set_emission_ring_cone_angle";
        /// <summary>
        /// Cached name for the 'get_emission_ring_cone_angle' method.
        /// </summary>
        public static readonly StringName GetEmissionRingConeAngle = "get_emission_ring_cone_angle";
        /// <summary>
        /// Cached name for the 'set_emission_shape_offset' method.
        /// </summary>
        public static readonly StringName SetEmissionShapeOffset = "set_emission_shape_offset";
        /// <summary>
        /// Cached name for the 'get_emission_shape_offset' method.
        /// </summary>
        public static readonly StringName GetEmissionShapeOffset = "get_emission_shape_offset";
        /// <summary>
        /// Cached name for the 'set_emission_shape_scale' method.
        /// </summary>
        public static readonly StringName SetEmissionShapeScale = "set_emission_shape_scale";
        /// <summary>
        /// Cached name for the 'get_emission_shape_scale' method.
        /// </summary>
        public static readonly StringName GetEmissionShapeScale = "get_emission_shape_scale";
        /// <summary>
        /// Cached name for the 'get_turbulence_enabled' method.
        /// </summary>
        public static readonly StringName GetTurbulenceEnabled = "get_turbulence_enabled";
        /// <summary>
        /// Cached name for the 'set_turbulence_enabled' method.
        /// </summary>
        public static readonly StringName SetTurbulenceEnabled = "set_turbulence_enabled";
        /// <summary>
        /// Cached name for the 'get_turbulence_noise_strength' method.
        /// </summary>
        public static readonly StringName GetTurbulenceNoiseStrength = "get_turbulence_noise_strength";
        /// <summary>
        /// Cached name for the 'set_turbulence_noise_strength' method.
        /// </summary>
        public static readonly StringName SetTurbulenceNoiseStrength = "set_turbulence_noise_strength";
        /// <summary>
        /// Cached name for the 'get_turbulence_noise_scale' method.
        /// </summary>
        public static readonly StringName GetTurbulenceNoiseScale = "get_turbulence_noise_scale";
        /// <summary>
        /// Cached name for the 'set_turbulence_noise_scale' method.
        /// </summary>
        public static readonly StringName SetTurbulenceNoiseScale = "set_turbulence_noise_scale";
        /// <summary>
        /// Cached name for the 'get_turbulence_noise_speed_random' method.
        /// </summary>
        public static readonly StringName GetTurbulenceNoiseSpeedRandom = "get_turbulence_noise_speed_random";
        /// <summary>
        /// Cached name for the 'set_turbulence_noise_speed_random' method.
        /// </summary>
        public static readonly StringName SetTurbulenceNoiseSpeedRandom = "set_turbulence_noise_speed_random";
        /// <summary>
        /// Cached name for the 'get_turbulence_noise_speed' method.
        /// </summary>
        public static readonly StringName GetTurbulenceNoiseSpeed = "get_turbulence_noise_speed";
        /// <summary>
        /// Cached name for the 'set_turbulence_noise_speed' method.
        /// </summary>
        public static readonly StringName SetTurbulenceNoiseSpeed = "set_turbulence_noise_speed";
        /// <summary>
        /// Cached name for the 'get_gravity' method.
        /// </summary>
        public static readonly StringName GetGravity = "get_gravity";
        /// <summary>
        /// Cached name for the 'set_gravity' method.
        /// </summary>
        public static readonly StringName SetGravity = "set_gravity";
        /// <summary>
        /// Cached name for the 'set_lifetime_randomness' method.
        /// </summary>
        public static readonly StringName SetLifetimeRandomness = "set_lifetime_randomness";
        /// <summary>
        /// Cached name for the 'get_lifetime_randomness' method.
        /// </summary>
        public static readonly StringName GetLifetimeRandomness = "get_lifetime_randomness";
        /// <summary>
        /// Cached name for the 'get_sub_emitter_mode' method.
        /// </summary>
        public static readonly StringName GetSubEmitterMode = "get_sub_emitter_mode";
        /// <summary>
        /// Cached name for the 'set_sub_emitter_mode' method.
        /// </summary>
        public static readonly StringName SetSubEmitterMode = "set_sub_emitter_mode";
        /// <summary>
        /// Cached name for the 'get_sub_emitter_frequency' method.
        /// </summary>
        public static readonly StringName GetSubEmitterFrequency = "get_sub_emitter_frequency";
        /// <summary>
        /// Cached name for the 'set_sub_emitter_frequency' method.
        /// </summary>
        public static readonly StringName SetSubEmitterFrequency = "set_sub_emitter_frequency";
        /// <summary>
        /// Cached name for the 'get_sub_emitter_amount_at_end' method.
        /// </summary>
        public static readonly StringName GetSubEmitterAmountAtEnd = "get_sub_emitter_amount_at_end";
        /// <summary>
        /// Cached name for the 'set_sub_emitter_amount_at_end' method.
        /// </summary>
        public static readonly StringName SetSubEmitterAmountAtEnd = "set_sub_emitter_amount_at_end";
        /// <summary>
        /// Cached name for the 'get_sub_emitter_amount_at_collision' method.
        /// </summary>
        public static readonly StringName GetSubEmitterAmountAtCollision = "get_sub_emitter_amount_at_collision";
        /// <summary>
        /// Cached name for the 'set_sub_emitter_amount_at_collision' method.
        /// </summary>
        public static readonly StringName SetSubEmitterAmountAtCollision = "set_sub_emitter_amount_at_collision";
        /// <summary>
        /// Cached name for the 'get_sub_emitter_amount_at_start' method.
        /// </summary>
        public static readonly StringName GetSubEmitterAmountAtStart = "get_sub_emitter_amount_at_start";
        /// <summary>
        /// Cached name for the 'set_sub_emitter_amount_at_start' method.
        /// </summary>
        public static readonly StringName SetSubEmitterAmountAtStart = "set_sub_emitter_amount_at_start";
        /// <summary>
        /// Cached name for the 'get_sub_emitter_keep_velocity' method.
        /// </summary>
        public static readonly StringName GetSubEmitterKeepVelocity = "get_sub_emitter_keep_velocity";
        /// <summary>
        /// Cached name for the 'set_sub_emitter_keep_velocity' method.
        /// </summary>
        public static readonly StringName SetSubEmitterKeepVelocity = "set_sub_emitter_keep_velocity";
        /// <summary>
        /// Cached name for the 'set_attractor_interaction_enabled' method.
        /// </summary>
        public static readonly StringName SetAttractorInteractionEnabled = "set_attractor_interaction_enabled";
        /// <summary>
        /// Cached name for the 'is_attractor_interaction_enabled' method.
        /// </summary>
        public static readonly StringName IsAttractorInteractionEnabled = "is_attractor_interaction_enabled";
        /// <summary>
        /// Cached name for the 'set_collision_mode' method.
        /// </summary>
        public static readonly StringName SetCollisionMode = "set_collision_mode";
        /// <summary>
        /// Cached name for the 'get_collision_mode' method.
        /// </summary>
        public static readonly StringName GetCollisionMode = "get_collision_mode";
        /// <summary>
        /// Cached name for the 'set_collision_use_scale' method.
        /// </summary>
        public static readonly StringName SetCollisionUseScale = "set_collision_use_scale";
        /// <summary>
        /// Cached name for the 'is_collision_using_scale' method.
        /// </summary>
        public static readonly StringName IsCollisionUsingScale = "is_collision_using_scale";
        /// <summary>
        /// Cached name for the 'set_collision_friction' method.
        /// </summary>
        public static readonly StringName SetCollisionFriction = "set_collision_friction";
        /// <summary>
        /// Cached name for the 'get_collision_friction' method.
        /// </summary>
        public static readonly StringName GetCollisionFriction = "get_collision_friction";
        /// <summary>
        /// Cached name for the 'set_collision_bounce' method.
        /// </summary>
        public static readonly StringName SetCollisionBounce = "set_collision_bounce";
        /// <summary>
        /// Cached name for the 'get_collision_bounce' method.
        /// </summary>
        public static readonly StringName GetCollisionBounce = "get_collision_bounce";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Material.SignalName
    {
        /// <summary>
        /// Cached name for the 'emission_shape_changed' signal.
        /// </summary>
        public static readonly StringName EmissionShapeChanged = "emission_shape_changed";
    }
}
