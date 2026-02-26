namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>CPU-based 3D particle node used to create a variety of particle systems and effects.</para>
/// <para>See also <see cref="Godot.GpuParticles3D"/>, which provides the same functionality with hardware acceleration, but may not run on older devices.</para>
/// </summary>
[GodotClassName("CPUParticles3D")]
public partial class CpuParticles3D : GeometryInstance3D
{
    public enum DrawOrderEnum : long
    {
        /// <summary>
        /// <para>Particles are drawn in the order emitted.</para>
        /// </summary>
        Index = 0,
        /// <summary>
        /// <para>Particles are drawn in order of remaining lifetime. In other words, the particle with the highest lifetime is drawn at the front.</para>
        /// </summary>
        Lifetime = 1,
        /// <summary>
        /// <para>Particles are drawn in order of depth.</para>
        /// </summary>
        ViewDepth = 2
    }

    public enum Parameter : long
    {
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set initial velocity properties.</para>
        /// </summary>
        InitialLinearVelocity = 0,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set angular velocity properties.</para>
        /// </summary>
        AngularVelocity = 1,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set orbital velocity properties.</para>
        /// </summary>
        OrbitVelocity = 2,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set linear acceleration properties.</para>
        /// </summary>
        LinearAccel = 3,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set radial acceleration properties.</para>
        /// </summary>
        RadialAccel = 4,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set tangential acceleration properties.</para>
        /// </summary>
        TangentialAccel = 5,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set damping properties.</para>
        /// </summary>
        Damping = 6,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set angle properties.</para>
        /// </summary>
        Angle = 7,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set scale properties.</para>
        /// </summary>
        Scale = 8,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set hue variation properties.</para>
        /// </summary>
        HueVariation = 9,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set animation speed properties.</para>
        /// </summary>
        AnimSpeed = 10,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParamMin(CpuParticles3D.Parameter, float)"/>, <see cref="Godot.CpuParticles3D.SetParamMax(CpuParticles3D.Parameter, float)"/>, and <see cref="Godot.CpuParticles3D.SetParamCurve(CpuParticles3D.Parameter, Curve)"/> to set animation offset properties.</para>
        /// </summary>
        AnimOffset = 11,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.CpuParticles3D.Parameter"/> enum.</para>
        /// </summary>
        Max = 12
    }

    public enum ParticleFlags : long
    {
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParticleFlag(CpuParticles3D.ParticleFlags, bool)"/> to set <see cref="Godot.CpuParticles3D.ParticleFlagAlignY"/>.</para>
        /// </summary>
        AlignYToVelocity = 0,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParticleFlag(CpuParticles3D.ParticleFlags, bool)"/> to set <see cref="Godot.CpuParticles3D.ParticleFlagRotateY"/>.</para>
        /// </summary>
        RotateY = 1,
        /// <summary>
        /// <para>Use with <see cref="Godot.CpuParticles3D.SetParticleFlag(CpuParticles3D.ParticleFlags, bool)"/> to set <see cref="Godot.CpuParticles3D.ParticleFlagDisableZ"/>.</para>
        /// </summary>
        DisableZ = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.CpuParticles3D.ParticleFlags"/> enum.</para>
        /// </summary>
        Max = 3
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
        /// <para>Particles will be emitted at a position chosen randomly among <see cref="Godot.CpuParticles3D.EmissionPoints"/>. Particle color will be modulated by <see cref="Godot.CpuParticles3D.EmissionColors"/>.</para>
        /// </summary>
        Points = 4,
        /// <summary>
        /// <para>Particles will be emitted at a position chosen randomly among <see cref="Godot.CpuParticles3D.EmissionPoints"/>. Particle velocity and rotation will be set based on <see cref="Godot.CpuParticles3D.EmissionNormals"/>. Particle color will be modulated by <see cref="Godot.CpuParticles3D.EmissionColors"/>.</para>
        /// </summary>
        DirectedPoints = 5,
        /// <summary>
        /// <para>Particles will be emitted in a ring or cylinder.</para>
        /// </summary>
        Ring = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.CpuParticles3D.EmissionShapeEnum"/> enum.</para>
        /// </summary>
        Max = 7
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles are being emitted. <see cref="Godot.CpuParticles3D.Emitting"/> can be used to start and stop particles from emitting. However, if <see cref="Godot.CpuParticles3D.OneShot"/> is <see langword="true"/> setting <see cref="Godot.CpuParticles3D.Emitting"/> to <see langword="true"/> will not restart the emission cycle until after all active particles finish processing. You can use the <see cref="Godot.CpuParticles3D.Finished"/> signal to be notified once all active particles finish processing.</para>
    /// </summary>
    public bool Emitting
    {
        get
        {
            return IsEmitting();
        }
        set
        {
            SetEmitting(value);
        }
    }

    /// <summary>
    /// <para>Number of particles emitted in one emission cycle.</para>
    /// </summary>
    public int Amount
    {
        get
        {
            return GetAmount();
        }
        set
        {
            SetAmount(value);
        }
    }

    /// <summary>
    /// <para>Amount of time each particle will exist.</para>
    /// </summary>
    public double Lifetime
    {
        get
        {
            return GetLifetime();
        }
        set
        {
            SetLifetime(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, only one emission cycle occurs. If set <see langword="true"/> during a cycle, emission will stop at the cycle's end.</para>
    /// </summary>
    public bool OneShot
    {
        get
        {
            return GetOneShot();
        }
        set
        {
            SetOneShot(value);
        }
    }

    /// <summary>
    /// <para>Particle system starts as if it had already run for this many seconds.</para>
    /// </summary>
    public double Preprocess
    {
        get
        {
            return GetPreProcessTime();
        }
        set
        {
            SetPreProcessTime(value);
        }
    }

    /// <summary>
    /// <para>Particle system's running speed scaling ratio. A value of <c>0</c> can be used to pause the particles.</para>
    /// </summary>
    public double SpeedScale
    {
        get
        {
            return GetSpeedScale();
        }
        set
        {
            SetSpeedScale(value);
        }
    }

    /// <summary>
    /// <para>How rapidly particles in an emission cycle are emitted. If greater than <c>0</c>, there will be a gap in emissions before the next cycle begins.</para>
    /// </summary>
    public float Explosiveness
    {
        get
        {
            return GetExplosivenessRatio();
        }
        set
        {
            SetExplosivenessRatio(value);
        }
    }

    /// <summary>
    /// <para>Emission lifetime randomness ratio.</para>
    /// </summary>
    public float Randomness
    {
        get
        {
            return GetRandomnessRatio();
        }
        set
        {
            SetRandomnessRatio(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles will use the same seed for every simulation using the seed defined in <see cref="Godot.CpuParticles3D.Seed"/>. This is useful for situations where the visual outcome should be consistent across replays, for example when using Movie Maker mode.</para>
    /// </summary>
    public bool UseFixedSeed
    {
        get
        {
            return GetUseFixedSeed();
        }
        set
        {
            SetUseFixedSeed(value);
        }
    }

    /// <summary>
    /// <para>Sets the random seed used by the particle system. Only effective if <see cref="Godot.CpuParticles3D.UseFixedSeed"/> is <see langword="true"/>.</para>
    /// </summary>
    public uint Seed
    {
        get
        {
            return GetSeed();
        }
        set
        {
            SetSeed(value);
        }
    }

    /// <summary>
    /// <para>Particle lifetime randomness ratio.</para>
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
    /// <para>The particle system's frame rate is fixed to a value. For example, changing the value to 2 will make the particles render at 2 frames per second. Note this does not slow down the particle system itself.</para>
    /// </summary>
    public int FixedFps
    {
        get
        {
            return GetFixedFps();
        }
        set
        {
            SetFixedFps(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, results in fractional delta calculation which has a smoother particles display effect.</para>
    /// </summary>
    public bool FractDelta
    {
        get
        {
            return GetFractionalDelta();
        }
        set
        {
            SetFractionalDelta(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Aabb"/> that determines the node's region which needs to be visible on screen for the particle system to be active.</para>
    /// <para>Grow the box if particles suddenly appear/disappear when the node enters/exits the screen. The <see cref="Godot.Aabb"/> can be grown via code or with the <b>Particles → Generate AABB</b> editor tool.</para>
    /// </summary>
    public Aabb VisibilityAabb
    {
        get
        {
            return GetVisibilityAabb();
        }
        set
        {
            SetVisibilityAabb(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="Godot.CpuParticles3D"/> node (and its parents) when it is moved or rotated. If <see langword="false"/>, particles use global coordinates; they will not move or rotate along the <see cref="Godot.CpuParticles3D"/> node (and its parents) when it is moved or rotated.</para>
    /// </summary>
    public bool LocalCoords
    {
        get
        {
            return GetUseLocalCoordinates();
        }
        set
        {
            SetUseLocalCoordinates(value);
        }
    }

    /// <summary>
    /// <para>Particle draw order.</para>
    /// </summary>
    public CpuParticles3D.DrawOrderEnum DrawOrder
    {
        get
        {
            return GetDrawOrder();
        }
        set
        {
            SetDrawOrder(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Mesh"/> used for each particle. If <see langword="null"/>, particles will be spheres.</para>
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
    /// <para>Particles will be emitted inside this region.</para>
    /// </summary>
    public CpuParticles3D.EmissionShapeEnum EmissionShape
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
    /// <para>The sphere's radius if <see cref="Godot.CpuParticles3D.EmissionShapeEnum"/> is set to <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Sphere"/>.</para>
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
    /// <para>The rectangle's extents if <see cref="Godot.CpuParticles3D.EmissionShape"/> is set to <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Box"/>.</para>
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
    /// <para>Sets the initial positions to spawn particles when using <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Points"/> or <see cref="Godot.CpuParticles3D.EmissionShapeEnum.DirectedPoints"/>.</para>
    /// </summary>
    public Vector3[] EmissionPoints
    {
        get
        {
            return GetEmissionPoints();
        }
        set
        {
            SetEmissionPoints(value);
        }
    }

    /// <summary>
    /// <para>Sets the direction the particles will be emitted in when using <see cref="Godot.CpuParticles3D.EmissionShapeEnum.DirectedPoints"/>.</para>
    /// </summary>
    public Vector3[] EmissionNormals
    {
        get
        {
            return GetEmissionNormals();
        }
        set
        {
            SetEmissionNormals(value);
        }
    }

    /// <summary>
    /// <para>Sets the <see cref="Godot.Color"/>s to modulate particles by when using <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Points"/> or <see cref="Godot.CpuParticles3D.EmissionShapeEnum.DirectedPoints"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.CpuParticles3D.EmissionColors"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.CpuParticles3D.EmissionColors"/> will have no visible effect.</para>
    /// </summary>
    public Color[] EmissionColors
    {
        get
        {
            return GetEmissionColors();
        }
        set
        {
            SetEmissionColors(value);
        }
    }

    /// <summary>
    /// <para>The axis of the ring when using the emitter <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Ring"/>.</para>
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
    /// <para>The height of the ring when using the emitter <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Ring"/>.</para>
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
    /// <para>The radius of the ring when using the emitter <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Ring"/>.</para>
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
    /// <para>The inner radius of the ring when using the emitter <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Ring"/>.</para>
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
    /// <para>The angle of the cone when using the emitter <see cref="Godot.CpuParticles3D.EmissionShapeEnum.Ring"/>. The default angle of 90 degrees results in a ring, while an angle of 0 degrees results in a cone. Intermediate values will result in a ring where one end is larger than the other.</para>
    /// <para><b>Note:</b> Depending on <see cref="Godot.CpuParticles3D.EmissionRingHeight"/>, the angle may be clamped if the ring's end is reached to form a perfect cone.</para>
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

    /// <summary>
    /// <para>Align Y axis of particle with the direction of its velocity.</para>
    /// </summary>
    public bool ParticleFlagAlignY
    {
        get
        {
            return GetParticleFlag((CpuParticles3D.ParticleFlags)(0));
        }
        set
        {
            SetParticleFlag((CpuParticles3D.ParticleFlags)(0), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles rotate around Y axis by <see cref="Godot.CpuParticles3D.AngleMin"/>.</para>
    /// </summary>
    public bool ParticleFlagRotateY
    {
        get
        {
            return GetParticleFlag((CpuParticles3D.ParticleFlags)(1));
        }
        set
        {
            SetParticleFlag((CpuParticles3D.ParticleFlags)(1), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles will not move on the Z axis.</para>
    /// </summary>
    public bool ParticleFlagDisableZ
    {
        get
        {
            return GetParticleFlag((CpuParticles3D.ParticleFlags)(2));
        }
        set
        {
            SetParticleFlag((CpuParticles3D.ParticleFlags)(2), value);
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
    /// <para>Each particle's initial direction range from <c>+spread</c> to <c>-spread</c> degrees. Applied to X/Z plane and Y/Z planes.</para>
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
    /// <para>Amount of <see cref="Godot.CpuParticles3D.Spread"/> in Y/Z plane. A value of <c>1</c> restricts particles to X/Z plane.</para>
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

    /// <summary>
    /// <para>Minimum value of the initial velocity.</para>
    /// </summary>
    public float InitialVelocityMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(0));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(0), value);
        }
    }

    /// <summary>
    /// <para>Maximum value of the initial velocity.</para>
    /// </summary>
    public float InitialVelocityMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(0));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(0), value);
        }
    }

    /// <summary>
    /// <para>Minimum initial angular velocity (rotation speed) applied to each particle in <i>degrees</i> per second.</para>
    /// </summary>
    public float AngularVelocityMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(1));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(1), value);
        }
    }

    /// <summary>
    /// <para>Maximum initial angular velocity (rotation speed) applied to each particle in <i>degrees</i> per second.</para>
    /// </summary>
    public float AngularVelocityMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(1));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(1), value);
        }
    }

    /// <summary>
    /// <para>Each particle's angular velocity (rotation speed) will vary along this <see cref="Godot.Curve"/> over its lifetime. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve AngularVelocityCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(1));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(1), value);
        }
    }

    /// <summary>
    /// <para>Minimum orbit velocity.</para>
    /// </summary>
    public float OrbitVelocityMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(2));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(2), value);
        }
    }

    /// <summary>
    /// <para>Maximum orbit velocity.</para>
    /// </summary>
    public float OrbitVelocityMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(2));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(2), value);
        }
    }

    /// <summary>
    /// <para>Each particle's orbital velocity will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve OrbitVelocityCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(2));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(2), value);
        }
    }

    /// <summary>
    /// <para>Minimum linear acceleration.</para>
    /// </summary>
    public float LinearAccelMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(3));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(3), value);
        }
    }

    /// <summary>
    /// <para>Maximum linear acceleration.</para>
    /// </summary>
    public float LinearAccelMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(3));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(3), value);
        }
    }

    /// <summary>
    /// <para>Each particle's linear acceleration will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve LinearAccelCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(3));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(3), value);
        }
    }

    /// <summary>
    /// <para>Minimum radial acceleration.</para>
    /// </summary>
    public float RadialAccelMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(4));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(4), value);
        }
    }

    /// <summary>
    /// <para>Maximum radial acceleration.</para>
    /// </summary>
    public float RadialAccelMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(4));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(4), value);
        }
    }

    /// <summary>
    /// <para>Each particle's radial acceleration will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve RadialAccelCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(4));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(4), value);
        }
    }

    /// <summary>
    /// <para>Minimum tangent acceleration.</para>
    /// </summary>
    public float TangentialAccelMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(5));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(5), value);
        }
    }

    /// <summary>
    /// <para>Maximum tangent acceleration.</para>
    /// </summary>
    public float TangentialAccelMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(5));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(5), value);
        }
    }

    /// <summary>
    /// <para>Each particle's tangential acceleration will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve TangentialAccelCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(5));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(5), value);
        }
    }

    /// <summary>
    /// <para>Minimum damping.</para>
    /// </summary>
    public float DampingMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(6));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(6), value);
        }
    }

    /// <summary>
    /// <para>Maximum damping.</para>
    /// </summary>
    public float DampingMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(6));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(6), value);
        }
    }

    /// <summary>
    /// <para>Damping will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve DampingCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(6));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(6), value);
        }
    }

    /// <summary>
    /// <para>Minimum angle.</para>
    /// </summary>
    public float AngleMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(7));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(7), value);
        }
    }

    /// <summary>
    /// <para>Maximum angle.</para>
    /// </summary>
    public float AngleMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(7));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(7), value);
        }
    }

    /// <summary>
    /// <para>Each particle's rotation will be animated along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve AngleCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(7));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(7), value);
        }
    }

    /// <summary>
    /// <para>Minimum scale.</para>
    /// </summary>
    public float ScaleAmountMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(8));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(8), value);
        }
    }

    /// <summary>
    /// <para>Maximum scale.</para>
    /// </summary>
    public float ScaleAmountMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(8));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(8), value);
        }
    }

    /// <summary>
    /// <para>Each particle's scale will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve ScaleAmountCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(8));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(8), value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, three different scale curves can be specified, one per scale axis.</para>
    /// </summary>
    public bool SplitScale
    {
        get
        {
            return GetSplitScale();
        }
        set
        {
            SetSplitScale(value);
        }
    }

    /// <summary>
    /// <para>Curve for the scale over life, along the x axis.</para>
    /// </summary>
    public Curve ScaleCurveX
    {
        get
        {
            return GetScaleCurveX();
        }
        set
        {
            SetScaleCurveX(value);
        }
    }

    /// <summary>
    /// <para>Curve for the scale over life, along the y axis.</para>
    /// </summary>
    public Curve ScaleCurveY
    {
        get
        {
            return GetScaleCurveY();
        }
        set
        {
            SetScaleCurveY(value);
        }
    }

    /// <summary>
    /// <para>Curve for the scale over life, along the z axis.</para>
    /// </summary>
    public Curve ScaleCurveZ
    {
        get
        {
            return GetScaleCurveZ();
        }
        set
        {
            SetScaleCurveZ(value);
        }
    }

    /// <summary>
    /// <para>Each particle's initial color.</para>
    /// <para><b>Note:</b> <see cref="Godot.CpuParticles3D.Color"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.CpuParticles3D.Color"/> will have no visible effect.</para>
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
    /// <para>Each particle's color will vary along this <see cref="Godot.Gradient"/> over its lifetime (multiplied with <see cref="Godot.CpuParticles3D.Color"/>).</para>
    /// <para><b>Note:</b> <see cref="Godot.CpuParticles3D.ColorRamp"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.CpuParticles3D.ColorRamp"/> will have no visible effect.</para>
    /// </summary>
    public Gradient ColorRamp
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
    /// <para>Each particle's initial color will vary along this <see cref="Godot.Gradient"/> (multiplied with <see cref="Godot.CpuParticles3D.Color"/>).</para>
    /// <para><b>Note:</b> <see cref="Godot.CpuParticles3D.ColorInitialRamp"/> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> <i>must</i> be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="Godot.CpuParticles3D.ColorInitialRamp"/> will have no visible effect.</para>
    /// </summary>
    public Gradient ColorInitialRamp
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
    /// <para>Minimum hue variation.</para>
    /// </summary>
    public float HueVariationMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(9));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(9), value);
        }
    }

    /// <summary>
    /// <para>Maximum hue variation.</para>
    /// </summary>
    public float HueVariationMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(9));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(9), value);
        }
    }

    /// <summary>
    /// <para>Each particle's hue will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve HueVariationCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(9));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(9), value);
        }
    }

    /// <summary>
    /// <para>Minimum particle animation speed.</para>
    /// </summary>
    public float AnimSpeedMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(10));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(10), value);
        }
    }

    /// <summary>
    /// <para>Maximum particle animation speed.</para>
    /// </summary>
    public float AnimSpeedMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(10));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(10), value);
        }
    }

    /// <summary>
    /// <para>Each particle's animation speed will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve AnimSpeedCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(10));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(10), value);
        }
    }

    /// <summary>
    /// <para>Minimum animation offset.</para>
    /// </summary>
    public float AnimOffsetMin
    {
        get
        {
            return GetParamMin((CpuParticles3D.Parameter)(11));
        }
        set
        {
            SetParamMin((CpuParticles3D.Parameter)(11), value);
        }
    }

    /// <summary>
    /// <para>Maximum animation offset.</para>
    /// </summary>
    public float AnimOffsetMax
    {
        get
        {
            return GetParamMax((CpuParticles3D.Parameter)(11));
        }
        set
        {
            SetParamMax((CpuParticles3D.Parameter)(11), value);
        }
    }

    /// <summary>
    /// <para>Each particle's animation offset will vary along this <see cref="Godot.Curve"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve AnimOffsetCurve
    {
        get
        {
            return GetParamCurve((CpuParticles3D.Parameter)(11));
        }
        set
        {
            SetParamCurve((CpuParticles3D.Parameter)(11), value);
        }
    }

    private static readonly System.Type CachedType = typeof(CpuParticles3D);

    private static readonly StringName NativeName = "CPUParticles3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CpuParticles3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CpuParticles3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CpuParticles3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmitting, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmitting(bool emitting)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), emitting.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmount(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLifetime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLifetime(double secs)
    {
        NativeCalls.godot_icall_1_127(MethodBind2, GodotObject.GetPtr(this), secs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOneShot, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOneShot(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreProcessTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreProcessTime(double secs)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(this), secs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExplosivenessRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExplosivenessRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind5, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRandomnessRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRandomnessRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVisibilityAabb(Aabb aabb)
    {
        NativeCalls.godot_icall_1_183(MethodBind7, GodotObject.GetPtr(this), &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLifetimeRandomness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLifetimeRandomness(double random)
    {
        NativeCalls.godot_icall_1_127(MethodBind8, GodotObject.GetPtr(this), random);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseLocalCoordinates, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseLocalCoordinates(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFixedFps, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFixedFps(int fps)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), fps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractionalDelta, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractionalDelta(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpeedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpeedScale(double scale)
    {
        NativeCalls.godot_icall_1_127(MethodBind12, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmitting, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEmitting()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetAmount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLifetime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetLifetime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOneShot, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetOneShot()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreProcessTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetPreProcessTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExplosivenessRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetExplosivenessRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRandomnessRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRandomnessRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityAabb, 1068685055ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Aabb GetVisibilityAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLifetimeRandomness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetLifetimeRandomness()
    {
        return NativeCalls.godot_icall_0_144(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseLocalCoordinates, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseLocalCoordinates()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFixedFps, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFixedFps()
    {
        return NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractionalDelta, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFractionalDelta()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpeedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetSpeedScale()
    {
        return NativeCalls.godot_icall_0_144(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawOrder, 1427401774ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawOrder(CpuParticles3D.DrawOrderEnum order)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)order);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawOrder, 1321900776ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CpuParticles3D.DrawOrderEnum GetDrawOrder()
    {
        return (CpuParticles3D.DrawOrderEnum)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 194775623ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(Mesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind28, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 1808005922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Mesh GetMesh()
    {
        return (Mesh)NativeCalls.godot_icall_0_63(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseFixedSeed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseFixedSeed(bool useFixedSeed)
    {
        NativeCalls.godot_icall_1_14(MethodBind30, GodotObject.GetPtr(this), useFixedSeed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseFixedSeed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseFixedSeed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind31, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSeed, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSeed(uint seed)
    {
        NativeCalls.godot_icall_1_208(MethodBind32, GodotObject.GetPtr(this), seed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSeed, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetSeed()
    {
        return NativeCalls.godot_icall_0_209(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Restart, 107499316ul);

    /// <summary>
    /// <para>Restarts the particle emitter.</para>
    /// <para>If <paramref name="keepSeed"/> is <see langword="true"/>, the current random seed will be preserved. Useful for seeking and playback.</para>
    /// </summary>
    public void Restart(bool keepSeed = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind34, GodotObject.GetPtr(this), keepSeed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestParticlesProcess, 373806689ul);

    /// <summary>
    /// <para>Requests the particles to process for extra process time during a single frame.</para>
    /// <para>Useful for particle playback, if used in combination with <see cref="Godot.CpuParticles3D.UseFixedSeed"/> or by calling <see cref="Godot.CpuParticles3D.Restart(bool)"/> with parameter <c>keep_seed</c> set to <see langword="true"/>.</para>
    /// </summary>
    public void RequestParticlesProcess(float processTime)
    {
        NativeCalls.godot_icall_1_67(MethodBind35, GodotObject.GetPtr(this), processTime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CaptureAabb, 1068685055ul);

    /// <summary>
    /// <para>Returns the axis-aligned bounding box that contains all the particles that are active in the current frame.</para>
    /// </summary>
    public Aabb CaptureAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDirection, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDirection(Vector3 direction)
    {
        NativeCalls.godot_icall_1_177(MethodBind37, GodotObject.GetPtr(this), &direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirection, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetDirection()
    {
        return NativeCalls.godot_icall_0_125(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpread, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpread(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind39, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpread, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpread()
    {
        return NativeCalls.godot_icall_0_68(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlatness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlatness(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind41, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlatness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFlatness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamMin, 557936109ul);

    /// <summary>
    /// <para>Sets the minimum value for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParamMin(CpuParticles3D.Parameter param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind43, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamMin, 597646162ul);

    /// <summary>
    /// <para>Returns the minimum value range for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetParamMin(CpuParticles3D.Parameter param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind44, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamMax, 557936109ul);

    /// <summary>
    /// <para>Sets the maximum value for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParamMax(CpuParticles3D.Parameter param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind45, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamMax, 597646162ul);

    /// <summary>
    /// <para>Returns the maximum value range for the given parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetParamMax(CpuParticles3D.Parameter param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind46, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamCurve, 4044142537ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Curve"/> of the parameter specified by <see cref="Godot.CpuParticles3D.Parameter"/>. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParamCurve(CpuParticles3D.Parameter param, Curve curve)
    {
        NativeCalls.godot_icall_2_70(MethodBind47, GodotObject.GetPtr(this), (int)param, GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamCurve, 4132790277ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Curve"/> of the parameter specified by <see cref="Godot.CpuParticles3D.Parameter"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetParamCurve(CpuParticles3D.Parameter param)
    {
        return (Curve)NativeCalls.godot_icall_1_71(MethodBind48, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind49, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind50, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorRamp, 2756054477ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorRamp(Gradient ramp)
    {
        NativeCalls.godot_icall_1_56(MethodBind51, GodotObject.GetPtr(this), GodotObject.GetPtr(ramp));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorRamp, 132272999ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Gradient GetColorRamp()
    {
        return (Gradient)NativeCalls.godot_icall_0_63(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorInitialRamp, 2756054477ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorInitialRamp(Gradient ramp)
    {
        NativeCalls.godot_icall_1_56(MethodBind53, GodotObject.GetPtr(this), GodotObject.GetPtr(ramp));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorInitialRamp, 132272999ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Gradient GetColorInitialRamp()
    {
        return (Gradient)NativeCalls.godot_icall_0_63(MethodBind54, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParticleFlag, 3515406498ul);

    /// <summary>
    /// <para>Enables or disables the given particle flag.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParticleFlag(CpuParticles3D.ParticleFlags particleFlag, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind55, GodotObject.GetPtr(this), (int)particleFlag, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParticleFlag, 2845201987ul);

    /// <summary>
    /// <para>Returns the enabled state of the given particle flag.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetParticleFlag(CpuParticles3D.ParticleFlags particleFlag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind56, GodotObject.GetPtr(this), (int)particleFlag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionShape, 491823814ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionShape(CpuParticles3D.EmissionShapeEnum shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind57, GodotObject.GetPtr(this), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionShape, 2961454842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CpuParticles3D.EmissionShapeEnum GetEmissionShape()
    {
        return (CpuParticles3D.EmissionShapeEnum)NativeCalls.godot_icall_0_39(MethodBind58, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionSphereRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionSphereRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind59, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionSphereRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionSphereRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind60, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionBoxExtents, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEmissionBoxExtents(Vector3 extents)
    {
        NativeCalls.godot_icall_1_177(MethodBind61, GodotObject.GetPtr(this), &extents);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionBoxExtents, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetEmissionBoxExtents()
    {
        return NativeCalls.godot_icall_0_125(MethodBind62, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionPoints, 334873810ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionPoints(Vector3[] array)
    {
        NativeCalls.godot_icall_1_187(MethodBind63, GodotObject.GetPtr(this), array);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionPoints(ReadOnlySpan<Vector3> array)
    {
        NativeCalls.godot_icall_1_187(MethodBind63, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionPoints, 497664490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3[] GetEmissionPoints()
    {
        return NativeCalls.godot_icall_0_228(MethodBind64, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionNormals, 334873810ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionNormals(Vector3[] array)
    {
        NativeCalls.godot_icall_1_187(MethodBind65, GodotObject.GetPtr(this), array);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionNormals(ReadOnlySpan<Vector3> array)
    {
        NativeCalls.godot_icall_1_187(MethodBind65, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionNormals, 497664490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3[] GetEmissionNormals()
    {
        return NativeCalls.godot_icall_0_228(MethodBind66, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionColors, 3546319833ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionColors(Color[] array)
    {
        NativeCalls.godot_icall_1_226(MethodBind67, GodotObject.GetPtr(this), array);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionColors(ReadOnlySpan<Color> array)
    {
        NativeCalls.godot_icall_1_226(MethodBind67, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionColors, 1392750486ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color[] GetEmissionColors()
    {
        return NativeCalls.godot_icall_0_227(MethodBind68, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingAxis, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEmissionRingAxis(Vector3 axis)
    {
        NativeCalls.godot_icall_1_177(MethodBind69, GodotObject.GetPtr(this), &axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingAxis, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetEmissionRingAxis()
    {
        return NativeCalls.godot_icall_0_125(MethodBind70, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind71, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind72, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind73, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind74, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingInnerRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingInnerRadius(float innerRadius)
    {
        NativeCalls.godot_icall_1_67(MethodBind75, GodotObject.GetPtr(this), innerRadius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingInnerRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingInnerRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind76, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionRingConeAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionRingConeAngle(float coneAngle)
    {
        NativeCalls.godot_icall_1_67(MethodBind77, GodotObject.GetPtr(this), coneAngle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionRingConeAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionRingConeAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind78, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetGravity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind79, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGravity(Vector3 accelVec)
    {
        NativeCalls.godot_icall_1_177(MethodBind80, GodotObject.GetPtr(this), &accelVec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSplitScale, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSplitScale()
    {
        return NativeCalls.godot_icall_0_15(MethodBind81, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSplitScale, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSplitScale(bool splitScale)
    {
        NativeCalls.godot_icall_1_14(MethodBind82, GodotObject.GetPtr(this), splitScale.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaleCurveX, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetScaleCurveX()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind83, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaleCurveX, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScaleCurveX(Curve scaleCurve)
    {
        NativeCalls.godot_icall_1_56(MethodBind84, GodotObject.GetPtr(this), GodotObject.GetPtr(scaleCurve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaleCurveY, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetScaleCurveY()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind85, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaleCurveY, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScaleCurveY(Curve scaleCurve)
    {
        NativeCalls.godot_icall_1_56(MethodBind86, GodotObject.GetPtr(this), GodotObject.GetPtr(scaleCurve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaleCurveZ, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetScaleCurveZ()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind87, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaleCurveZ, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScaleCurveZ(Curve scaleCurve)
    {
        NativeCalls.godot_icall_1_56(MethodBind88, GodotObject.GetPtr(this), GodotObject.GetPtr(scaleCurve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvertFromParticles, 1078189570ul);

    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="Godot.GpuParticles3D"/> node with an assigned <see cref="Godot.ParticleProcessMaterial"/>.</para>
    /// </summary>
    public void ConvertFromParticles(Node particles)
    {
        NativeCalls.godot_icall_1_56(MethodBind89, GodotObject.GetPtr(this), GodotObject.GetPtr(particles));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Restart, 3218959716ul);

    /// <summary>
    /// <para>Restarts the particle emitter.</para>
    /// <para>If <paramref name="keepSeed"/> is <see langword="true"/>, the current random seed will be preserved. Useful for seeking and playback.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Restart()
    {
        NativeCalls.godot_icall_0_3(MethodBind90, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when all active particles have finished processing. When <see cref="Godot.CpuParticles3D.OneShot"/> is disabled, particles will process continuously, so this is never emitted.</para>
    /// </summary>
    public event Action Finished
    {
        add => Connect(SignalName.Finished, Callable.From(value));
        remove => Disconnect(SignalName.Finished, Callable.From(value));
    }

    protected void EmitSignalFinished()
    {
        EmitSignal(SignalName.Finished);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_finished = "Finished";

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
        if (signal == SignalName.Finished)
        {
            if (HasGodotClassSignal(SignalProxyName_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GeometryInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'emitting' property.
        /// </summary>
        public static readonly StringName Emitting = "emitting";
        /// <summary>
        /// Cached name for the 'amount' property.
        /// </summary>
        public static readonly StringName Amount = "amount";
        /// <summary>
        /// Cached name for the 'lifetime' property.
        /// </summary>
        public static readonly StringName Lifetime = "lifetime";
        /// <summary>
        /// Cached name for the 'one_shot' property.
        /// </summary>
        public static readonly StringName OneShot = "one_shot";
        /// <summary>
        /// Cached name for the 'preprocess' property.
        /// </summary>
        public static readonly StringName Preprocess = "preprocess";
        /// <summary>
        /// Cached name for the 'speed_scale' property.
        /// </summary>
        public static readonly StringName SpeedScale = "speed_scale";
        /// <summary>
        /// Cached name for the 'explosiveness' property.
        /// </summary>
        public static readonly StringName Explosiveness = "explosiveness";
        /// <summary>
        /// Cached name for the 'randomness' property.
        /// </summary>
        public static readonly StringName Randomness = "randomness";
        /// <summary>
        /// Cached name for the 'use_fixed_seed' property.
        /// </summary>
        public static readonly StringName UseFixedSeed = "use_fixed_seed";
        /// <summary>
        /// Cached name for the 'seed' property.
        /// </summary>
        public static readonly StringName Seed = "seed";
        /// <summary>
        /// Cached name for the 'lifetime_randomness' property.
        /// </summary>
        public static readonly StringName LifetimeRandomness = "lifetime_randomness";
        /// <summary>
        /// Cached name for the 'fixed_fps' property.
        /// </summary>
        public static readonly StringName FixedFps = "fixed_fps";
        /// <summary>
        /// Cached name for the 'fract_delta' property.
        /// </summary>
        public static readonly StringName FractDelta = "fract_delta";
        /// <summary>
        /// Cached name for the 'visibility_aabb' property.
        /// </summary>
        public static readonly StringName VisibilityAabb = "visibility_aabb";
        /// <summary>
        /// Cached name for the 'local_coords' property.
        /// </summary>
        public static readonly StringName LocalCoords = "local_coords";
        /// <summary>
        /// Cached name for the 'draw_order' property.
        /// </summary>
        public static readonly StringName DrawOrder = "draw_order";
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
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
        /// Cached name for the 'emission_points' property.
        /// </summary>
        public static readonly StringName EmissionPoints = "emission_points";
        /// <summary>
        /// Cached name for the 'emission_normals' property.
        /// </summary>
        public static readonly StringName EmissionNormals = "emission_normals";
        /// <summary>
        /// Cached name for the 'emission_colors' property.
        /// </summary>
        public static readonly StringName EmissionColors = "emission_colors";
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
        /// Cached name for the 'gravity' property.
        /// </summary>
        public static readonly StringName Gravity = "gravity";
        /// <summary>
        /// Cached name for the 'initial_velocity_min' property.
        /// </summary>
        public static readonly StringName InitialVelocityMin = "initial_velocity_min";
        /// <summary>
        /// Cached name for the 'initial_velocity_max' property.
        /// </summary>
        public static readonly StringName InitialVelocityMax = "initial_velocity_max";
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
        /// Cached name for the 'scale_amount_min' property.
        /// </summary>
        public static readonly StringName ScaleAmountMin = "scale_amount_min";
        /// <summary>
        /// Cached name for the 'scale_amount_max' property.
        /// </summary>
        public static readonly StringName ScaleAmountMax = "scale_amount_max";
        /// <summary>
        /// Cached name for the 'scale_amount_curve' property.
        /// </summary>
        public static readonly StringName ScaleAmountCurve = "scale_amount_curve";
        /// <summary>
        /// Cached name for the 'split_scale' property.
        /// </summary>
        public static readonly StringName SplitScale = "split_scale";
        /// <summary>
        /// Cached name for the 'scale_curve_x' property.
        /// </summary>
        public static readonly StringName ScaleCurveX = "scale_curve_x";
        /// <summary>
        /// Cached name for the 'scale_curve_y' property.
        /// </summary>
        public static readonly StringName ScaleCurveY = "scale_curve_y";
        /// <summary>
        /// Cached name for the 'scale_curve_z' property.
        /// </summary>
        public static readonly StringName ScaleCurveZ = "scale_curve_z";
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GeometryInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_emitting' method.
        /// </summary>
        public static readonly StringName SetEmitting = "set_emitting";
        /// <summary>
        /// Cached name for the 'set_amount' method.
        /// </summary>
        public static readonly StringName SetAmount = "set_amount";
        /// <summary>
        /// Cached name for the 'set_lifetime' method.
        /// </summary>
        public static readonly StringName SetLifetime = "set_lifetime";
        /// <summary>
        /// Cached name for the 'set_one_shot' method.
        /// </summary>
        public static readonly StringName SetOneShot = "set_one_shot";
        /// <summary>
        /// Cached name for the 'set_pre_process_time' method.
        /// </summary>
        public static readonly StringName SetPreProcessTime = "set_pre_process_time";
        /// <summary>
        /// Cached name for the 'set_explosiveness_ratio' method.
        /// </summary>
        public static readonly StringName SetExplosivenessRatio = "set_explosiveness_ratio";
        /// <summary>
        /// Cached name for the 'set_randomness_ratio' method.
        /// </summary>
        public static readonly StringName SetRandomnessRatio = "set_randomness_ratio";
        /// <summary>
        /// Cached name for the 'set_visibility_aabb' method.
        /// </summary>
        public static readonly StringName SetVisibilityAabb = "set_visibility_aabb";
        /// <summary>
        /// Cached name for the 'set_lifetime_randomness' method.
        /// </summary>
        public static readonly StringName SetLifetimeRandomness = "set_lifetime_randomness";
        /// <summary>
        /// Cached name for the 'set_use_local_coordinates' method.
        /// </summary>
        public static readonly StringName SetUseLocalCoordinates = "set_use_local_coordinates";
        /// <summary>
        /// Cached name for the 'set_fixed_fps' method.
        /// </summary>
        public static readonly StringName SetFixedFps = "set_fixed_fps";
        /// <summary>
        /// Cached name for the 'set_fractional_delta' method.
        /// </summary>
        public static readonly StringName SetFractionalDelta = "set_fractional_delta";
        /// <summary>
        /// Cached name for the 'set_speed_scale' method.
        /// </summary>
        public static readonly StringName SetSpeedScale = "set_speed_scale";
        /// <summary>
        /// Cached name for the 'is_emitting' method.
        /// </summary>
        public static readonly StringName IsEmitting = "is_emitting";
        /// <summary>
        /// Cached name for the 'get_amount' method.
        /// </summary>
        public static readonly StringName GetAmount = "get_amount";
        /// <summary>
        /// Cached name for the 'get_lifetime' method.
        /// </summary>
        public static readonly StringName GetLifetime = "get_lifetime";
        /// <summary>
        /// Cached name for the 'get_one_shot' method.
        /// </summary>
        public static readonly StringName GetOneShot = "get_one_shot";
        /// <summary>
        /// Cached name for the 'get_pre_process_time' method.
        /// </summary>
        public static readonly StringName GetPreProcessTime = "get_pre_process_time";
        /// <summary>
        /// Cached name for the 'get_explosiveness_ratio' method.
        /// </summary>
        public static readonly StringName GetExplosivenessRatio = "get_explosiveness_ratio";
        /// <summary>
        /// Cached name for the 'get_randomness_ratio' method.
        /// </summary>
        public static readonly StringName GetRandomnessRatio = "get_randomness_ratio";
        /// <summary>
        /// Cached name for the 'get_visibility_aabb' method.
        /// </summary>
        public static readonly StringName GetVisibilityAabb = "get_visibility_aabb";
        /// <summary>
        /// Cached name for the 'get_lifetime_randomness' method.
        /// </summary>
        public static readonly StringName GetLifetimeRandomness = "get_lifetime_randomness";
        /// <summary>
        /// Cached name for the 'get_use_local_coordinates' method.
        /// </summary>
        public static readonly StringName GetUseLocalCoordinates = "get_use_local_coordinates";
        /// <summary>
        /// Cached name for the 'get_fixed_fps' method.
        /// </summary>
        public static readonly StringName GetFixedFps = "get_fixed_fps";
        /// <summary>
        /// Cached name for the 'get_fractional_delta' method.
        /// </summary>
        public static readonly StringName GetFractionalDelta = "get_fractional_delta";
        /// <summary>
        /// Cached name for the 'get_speed_scale' method.
        /// </summary>
        public static readonly StringName GetSpeedScale = "get_speed_scale";
        /// <summary>
        /// Cached name for the 'set_draw_order' method.
        /// </summary>
        public static readonly StringName SetDrawOrder = "set_draw_order";
        /// <summary>
        /// Cached name for the 'get_draw_order' method.
        /// </summary>
        public static readonly StringName GetDrawOrder = "get_draw_order";
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_use_fixed_seed' method.
        /// </summary>
        public static readonly StringName SetUseFixedSeed = "set_use_fixed_seed";
        /// <summary>
        /// Cached name for the 'get_use_fixed_seed' method.
        /// </summary>
        public static readonly StringName GetUseFixedSeed = "get_use_fixed_seed";
        /// <summary>
        /// Cached name for the 'set_seed' method.
        /// </summary>
        public static readonly StringName SetSeed = "set_seed";
        /// <summary>
        /// Cached name for the 'get_seed' method.
        /// </summary>
        public static readonly StringName GetSeed = "get_seed";
        /// <summary>
        /// Cached name for the 'restart' method.
        /// </summary>
        public static readonly StringName Restart = "restart";
        /// <summary>
        /// Cached name for the 'request_particles_process' method.
        /// </summary>
        public static readonly StringName RequestParticlesProcess = "request_particles_process";
        /// <summary>
        /// Cached name for the 'capture_aabb' method.
        /// </summary>
        public static readonly StringName CaptureAabb = "capture_aabb";
        /// <summary>
        /// Cached name for the 'set_direction' method.
        /// </summary>
        public static readonly StringName SetDirection = "set_direction";
        /// <summary>
        /// Cached name for the 'get_direction' method.
        /// </summary>
        public static readonly StringName GetDirection = "get_direction";
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
        /// Cached name for the 'set_param_curve' method.
        /// </summary>
        public static readonly StringName SetParamCurve = "set_param_curve";
        /// <summary>
        /// Cached name for the 'get_param_curve' method.
        /// </summary>
        public static readonly StringName GetParamCurve = "get_param_curve";
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
        /// Cached name for the 'set_color_initial_ramp' method.
        /// </summary>
        public static readonly StringName SetColorInitialRamp = "set_color_initial_ramp";
        /// <summary>
        /// Cached name for the 'get_color_initial_ramp' method.
        /// </summary>
        public static readonly StringName GetColorInitialRamp = "get_color_initial_ramp";
        /// <summary>
        /// Cached name for the 'set_particle_flag' method.
        /// </summary>
        public static readonly StringName SetParticleFlag = "set_particle_flag";
        /// <summary>
        /// Cached name for the 'get_particle_flag' method.
        /// </summary>
        public static readonly StringName GetParticleFlag = "get_particle_flag";
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
        /// Cached name for the 'set_emission_points' method.
        /// </summary>
        public static readonly StringName SetEmissionPoints = "set_emission_points";
        /// <summary>
        /// Cached name for the 'get_emission_points' method.
        /// </summary>
        public static readonly StringName GetEmissionPoints = "get_emission_points";
        /// <summary>
        /// Cached name for the 'set_emission_normals' method.
        /// </summary>
        public static readonly StringName SetEmissionNormals = "set_emission_normals";
        /// <summary>
        /// Cached name for the 'get_emission_normals' method.
        /// </summary>
        public static readonly StringName GetEmissionNormals = "get_emission_normals";
        /// <summary>
        /// Cached name for the 'set_emission_colors' method.
        /// </summary>
        public static readonly StringName SetEmissionColors = "set_emission_colors";
        /// <summary>
        /// Cached name for the 'get_emission_colors' method.
        /// </summary>
        public static readonly StringName GetEmissionColors = "get_emission_colors";
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
        /// Cached name for the 'get_gravity' method.
        /// </summary>
        public static readonly StringName GetGravity = "get_gravity";
        /// <summary>
        /// Cached name for the 'set_gravity' method.
        /// </summary>
        public static readonly StringName SetGravity = "set_gravity";
        /// <summary>
        /// Cached name for the 'get_split_scale' method.
        /// </summary>
        public static readonly StringName GetSplitScale = "get_split_scale";
        /// <summary>
        /// Cached name for the 'set_split_scale' method.
        /// </summary>
        public static readonly StringName SetSplitScale = "set_split_scale";
        /// <summary>
        /// Cached name for the 'get_scale_curve_x' method.
        /// </summary>
        public static readonly StringName GetScaleCurveX = "get_scale_curve_x";
        /// <summary>
        /// Cached name for the 'set_scale_curve_x' method.
        /// </summary>
        public static readonly StringName SetScaleCurveX = "set_scale_curve_x";
        /// <summary>
        /// Cached name for the 'get_scale_curve_y' method.
        /// </summary>
        public static readonly StringName GetScaleCurveY = "get_scale_curve_y";
        /// <summary>
        /// Cached name for the 'set_scale_curve_y' method.
        /// </summary>
        public static readonly StringName SetScaleCurveY = "set_scale_curve_y";
        /// <summary>
        /// Cached name for the 'get_scale_curve_z' method.
        /// </summary>
        public static readonly StringName GetScaleCurveZ = "get_scale_curve_z";
        /// <summary>
        /// Cached name for the 'set_scale_curve_z' method.
        /// </summary>
        public static readonly StringName SetScaleCurveZ = "set_scale_curve_z";
        /// <summary>
        /// Cached name for the 'convert_from_particles' method.
        /// </summary>
        public static readonly StringName ConvertFromParticles = "convert_from_particles";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GeometryInstance3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'finished' signal.
        /// </summary>
        public static readonly StringName Finished = "finished";
    }
}
