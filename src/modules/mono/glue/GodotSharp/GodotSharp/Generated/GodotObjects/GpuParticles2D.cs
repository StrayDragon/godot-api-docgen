namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>2D particle node used to create a variety of particle systems and effects. <see cref="Godot.GpuParticles2D"/> features an emitter that generates some number of particles at a given rate.</para>
/// <para>Use the <see cref="Godot.GpuParticles2D.ProcessMaterial"/> property to add a <see cref="Godot.ParticleProcessMaterial"/> to configure particle appearance and behavior. Alternatively, you can add a <see cref="Godot.ShaderMaterial"/> which will be applied to all particles.</para>
/// <para>2D particles can optionally collide with <see cref="Godot.LightOccluder2D"/>, but they don't collide with <see cref="Godot.PhysicsBody2D"/> nodes.</para>
/// </summary>
[GodotClassName("GPUParticles2D")]
public partial class GpuParticles2D : Node2D
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
        /// <para>Particles are drawn in reverse order of remaining lifetime. In other words, the particle with the lowest lifetime is drawn at the front.</para>
        /// </summary>
        ReverseLifetime = 2
    }

    public enum EmitFlags : long
    {
        /// <summary>
        /// <para>Particle starts at the specified position.</para>
        /// </summary>
        Position = 1,
        /// <summary>
        /// <para>Particle starts with specified rotation and scale.</para>
        /// </summary>
        RotationScale = 2,
        /// <summary>
        /// <para>Particle starts with the specified velocity vector, which defines the emission direction and speed.</para>
        /// </summary>
        Velocity = 4,
        /// <summary>
        /// <para>Particle starts with specified color.</para>
        /// </summary>
        Color = 8,
        /// <summary>
        /// <para>Particle starts with specified <c>CUSTOM</c> data.</para>
        /// </summary>
        Custom = 16
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles are being emitted. <see cref="Godot.GpuParticles2D.Emitting"/> can be used to start and stop particles from emitting. However, if <see cref="Godot.GpuParticles2D.OneShot"/> is <see langword="true"/> setting <see cref="Godot.GpuParticles2D.Emitting"/> to <see langword="true"/> will not restart the emission cycle unless all active particles have finished processing. Use the <see cref="Godot.GpuParticles2D.Finished"/> signal to be notified once all active particles finish processing.</para>
    /// <para><b>Note:</b> For <see cref="Godot.GpuParticles2D.OneShot"/> emitters, due to the particles being computed on the GPU, there may be a short period after receiving the <see cref="Godot.GpuParticles2D.Finished"/> signal during which setting this to <see langword="true"/> will not restart the emission cycle.</para>
    /// <para><b>Tip:</b> If your <see cref="Godot.GpuParticles2D.OneShot"/> emitter needs to immediately restart emitting particles once <see cref="Godot.GpuParticles2D.Finished"/> signal is received, consider calling <see cref="Godot.GpuParticles2D.Restart(bool)"/> instead of setting <see cref="Godot.GpuParticles2D.Emitting"/>.</para>
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
    /// <para>The number of particles to emit in one emission cycle. The effective emission rate is <c>(amount * amount_ratio) / lifetime</c> particles per second. Higher values will increase GPU requirements, even if not all particles are visible at a given time or if <see cref="Godot.GpuParticles2D.AmountRatio"/> is decreased.</para>
    /// <para><b>Note:</b> Changing this value will cause the particle system to restart. To avoid this, change <see cref="Godot.GpuParticles2D.AmountRatio"/> instead.</para>
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
    /// <para>The ratio of particles that should actually be emitted. If set to a value lower than <c>1.0</c>, this will set the amount of emitted particles throughout the lifetime to <c>amount * amount_ratio</c>. Unlike changing <see cref="Godot.GpuParticles2D.Amount"/>, changing <see cref="Godot.GpuParticles2D.AmountRatio"/> while emitting does not affect already-emitted particles and doesn't cause the particle system to restart. <see cref="Godot.GpuParticles2D.AmountRatio"/> can be used to create effects that make the number of emitted particles vary over time.</para>
    /// <para><b>Note:</b> Reducing the <see cref="Godot.GpuParticles2D.AmountRatio"/> has no performance benefit, since resources need to be allocated and processed for the total <see cref="Godot.GpuParticles2D.Amount"/> of particles regardless of the <see cref="Godot.GpuParticles2D.AmountRatio"/>. If you don't intend to change the number of particles emitted while the particles are emitting, make sure <see cref="Godot.GpuParticles2D.AmountRatio"/> is set to <c>1</c> and change <see cref="Godot.GpuParticles2D.Amount"/> to your liking instead.</para>
    /// </summary>
    public float AmountRatio
    {
        get
        {
            return GetAmountRatio();
        }
        set
        {
            SetAmountRatio(value);
        }
    }

    /// <summary>
    /// <para>Path to another <see cref="Godot.GpuParticles2D"/> node that will be used as a subemitter (see <see cref="Godot.ParticleProcessMaterial.SubEmitterMode"/>). Subemitters can be used to achieve effects such as fireworks, sparks on collision, bubbles popping into water drops, and more.</para>
    /// <para><b>Note:</b> When <see cref="Godot.GpuParticles2D.SubEmitter"/> is set, the target <see cref="Godot.GpuParticles2D"/> node will no longer emit particles on its own.</para>
    /// </summary>
    public NodePath SubEmitter
    {
        get
        {
            return GetSubEmitter();
        }
        set
        {
            SetSubEmitter(value);
        }
    }

    /// <summary>
    /// <para>Particle texture. If <see langword="null"/>, particles will be squares with a size of 1×1 pixels.</para>
    /// <para><b>Note:</b> To use a flipbook texture, assign a new <see cref="Godot.CanvasItemMaterial"/> to the <see cref="Godot.GpuParticles2D"/>'s <see cref="Godot.CanvasItem.Material"/> property, then enable <see cref="Godot.CanvasItemMaterial.ParticlesAnimation"/> and set <see cref="Godot.CanvasItemMaterial.ParticlesAnimHFrames"/>, <see cref="Godot.CanvasItemMaterial.ParticlesAnimVFrames"/>, and <see cref="Godot.CanvasItemMaterial.ParticlesAnimLoop"/> to match the flipbook texture.</para>
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

    /// <summary>
    /// <para>The amount of time each particle will exist (in seconds). The effective emission rate is <c>(amount * amount_ratio) / lifetime</c> particles per second.</para>
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
    /// <para>Causes all the particles in this node to interpolate towards the end of their lifetime.</para>
    /// <para><b>Note:</b> This only works when used with a <see cref="Godot.ParticleProcessMaterial"/>. It needs to be manually implemented for custom process shaders.</para>
    /// </summary>
    public float InterpToEnd
    {
        get
        {
            return GetInterpToEnd();
        }
        set
        {
            SetInterpToEnd(value);
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
    /// <para><b>Note:</b> This can be very expensive if set to a high number as it requires running the particle shader a number of times equal to the <see cref="Godot.GpuParticles2D.FixedFps"/> (or 30, if <see cref="Godot.GpuParticles2D.FixedFps"/> is 0) for every second. In extreme cases it can even lead to a GPU crash due to the volume of work done in a single frame.</para>
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
    /// <para>If <see langword="true"/>, particles will use the same seed for every simulation using the seed defined in <see cref="Godot.GpuParticles2D.Seed"/>. This is useful for situations where the visual outcome should be consistent across replays, for example when using Movie Maker mode.</para>
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
    /// <para>Sets the random seed used by the particle system. Only effective if <see cref="Godot.GpuParticles2D.UseFixedSeed"/> is <see langword="true"/>.</para>
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
    /// <para>The particle system's frame rate is fixed to a value. For example, changing the value to 2 will make the particles render at 2 frames per second. Note this does not slow down the simulation of the particle system itself.</para>
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
    /// <para>Enables particle interpolation, which makes the particle movement smoother when their <see cref="Godot.GpuParticles2D.FixedFps"/> is lower than the screen refresh rate.</para>
    /// </summary>
    public bool Interpolate
    {
        get
        {
            return GetInterpolate();
        }
        set
        {
            SetInterpolate(value);
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
    /// <para>Multiplier for particle's collision radius. <c>1.0</c> corresponds to the size of the sprite. If particles appear to sink into the ground when colliding, increase this value. If particles appear to float when colliding, decrease this value. Only effective if <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> is <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/> or <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.HideOnContact"/>.</para>
    /// <para><b>Note:</b> Particles always have a spherical collision shape.</para>
    /// </summary>
    public float CollisionBaseSize
    {
        get
        {
            return GetCollisionBaseSize();
        }
        set
        {
            SetCollisionBaseSize(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Rect2"/> that determines the node's region which needs to be visible on screen for the particle system to be active.</para>
    /// <para>Grow the rect if particles suddenly appear/disappear when the node enters/exits the screen. The <see cref="Godot.Rect2"/> can be grown via code or with the <b>Particles → Generate Visibility Rect</b> editor tool.</para>
    /// </summary>
    public Rect2 VisibilityRect
    {
        get
        {
            return GetVisibilityRect();
        }
        set
        {
            SetVisibilityRect(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="Godot.GpuParticles2D"/> node (and its parents) when it is moved or rotated. If <see langword="false"/>, particles use global coordinates; they will not move or rotate along the <see cref="Godot.GpuParticles2D"/> node (and its parents) when it is moved or rotated.</para>
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
    public GpuParticles2D.DrawOrderEnum DrawOrder
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
    /// <para>If <see langword="true"/>, enables particle trails using a mesh skinning system.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.GpuParticles3D"/>, the number of trail sections and subdivisions is set with the <see cref="Godot.GpuParticles2D.TrailSections"/> and <see cref="Godot.GpuParticles2D.TrailSectionSubdivisions"/> properties.</para>
    /// </summary>
    public bool TrailEnabled
    {
        get
        {
            return IsTrailEnabled();
        }
        set
        {
            SetTrailEnabled(value);
        }
    }

    /// <summary>
    /// <para>The amount of time the particle's trail should represent (in seconds). Only effective if <see cref="Godot.GpuParticles2D.TrailEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public double TrailLifetime
    {
        get
        {
            return GetTrailLifetime();
        }
        set
        {
            SetTrailLifetime(value);
        }
    }

    /// <summary>
    /// <para>The number of sections to use for the particle trail rendering. Higher values can result in smoother trail curves, at the cost of performance due to increased mesh complexity. See also <see cref="Godot.GpuParticles2D.TrailSectionSubdivisions"/>. Only effective if <see cref="Godot.GpuParticles2D.TrailEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public int TrailSections
    {
        get
        {
            return GetTrailSections();
        }
        set
        {
            SetTrailSections(value);
        }
    }

    /// <summary>
    /// <para>The number of subdivisions to use for the particle trail rendering. Higher values can result in smoother trail curves, at the cost of performance due to increased mesh complexity. See also <see cref="Godot.GpuParticles2D.TrailSections"/>. Only effective if <see cref="Godot.GpuParticles2D.TrailEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public int TrailSectionSubdivisions
    {
        get
        {
            return GetTrailSectionSubdivisions();
        }
        set
        {
            SetTrailSectionSubdivisions(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Material"/> for processing particles. Can be a <see cref="Godot.ParticleProcessMaterial"/> or a <see cref="Godot.ShaderMaterial"/>.</para>
    /// </summary>
    public Material ProcessMaterial
    {
        get
        {
            return GetProcessMaterial();
        }
        set
        {
            SetProcessMaterial(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GpuParticles2D);

    private static readonly StringName NativeName = "GPUParticles2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GpuParticles2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticles2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticles2D(bool memoryOwn) : base(memoryOwn) { }

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
    public void SetOneShot(bool secs)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), secs.ToGodotBool());
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
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRect, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVisibilityRect(Rect2 visibilityRect)
    {
        NativeCalls.godot_icall_1_188(MethodBind7, GodotObject.GetPtr(this), &visibilityRect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseLocalCoordinates, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseLocalCoordinates(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFixedFps, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFixedFps(int fps)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), fps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractionalDelta, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractionalDelta(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterpolate, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInterpolate(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessMaterial, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpeedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpeedScale(double scale)
    {
        NativeCalls.godot_icall_1_127(MethodBind13, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionBaseSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionBaseSize(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterpToEnd, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInterpToEnd(float interp)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), interp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestParticlesProcess, 373806689ul);

    /// <summary>
    /// <para>Requests the particles to process for extra process time during a single frame.</para>
    /// <para>Useful for particle playback, if used in combination with <see cref="Godot.GpuParticles2D.UseFixedSeed"/> or by calling <see cref="Godot.GpuParticles2D.Restart(bool)"/> with parameter <c>keep_seed</c> set to <see langword="true"/>.</para>
    /// </summary>
    public void RequestParticlesProcess(float processTime)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), processTime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmitting, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEmitting()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetAmount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLifetime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetLifetime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOneShot, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetOneShot()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreProcessTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetPreProcessTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExplosivenessRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetExplosivenessRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRandomnessRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRandomnessRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRect, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetVisibilityRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseLocalCoordinates, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseLocalCoordinates()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFixedFps, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFixedFps()
    {
        return NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractionalDelta, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFractionalDelta()
    {
        return NativeCalls.godot_icall_0_15(MethodBind27, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterpolate, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetInterpolate()
    {
        return NativeCalls.godot_icall_0_15(MethodBind28, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessMaterial, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetProcessMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpeedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetSpeedScale()
    {
        return NativeCalls.godot_icall_0_144(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionBaseSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCollisionBaseSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterpToEnd, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInterpToEnd()
    {
        return NativeCalls.godot_icall_0_68(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawOrder, 1939677959ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawOrder(GpuParticles2D.DrawOrderEnum order)
    {
        NativeCalls.godot_icall_1_38(MethodBind33, GodotObject.GetPtr(this), (int)order);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawOrder, 941479095ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GpuParticles2D.DrawOrderEnum GetDrawOrder()
    {
        return (GpuParticles2D.DrawOrderEnum)NativeCalls.godot_icall_0_39(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind35, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CaptureRect, 1639390495ul);

    /// <summary>
    /// <para>Returns a rectangle containing the positions of all existing particles.</para>
    /// <para><b>Note:</b> When using threaded rendering this method synchronizes the rendering thread. Calling it often may have a negative impact on performance.</para>
    /// </summary>
    public Rect2 CaptureRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Restart, 107499316ul);

    /// <summary>
    /// <para>Restarts the particle emission cycle, clearing existing particles. To avoid particles vanishing from the viewport, wait for the <see cref="Godot.GpuParticles2D.Finished"/> signal before calling.</para>
    /// <para><b>Note:</b> The <see cref="Godot.GpuParticles2D.Finished"/> signal is only emitted by <see cref="Godot.GpuParticles2D.OneShot"/> emitters.</para>
    /// <para>If <paramref name="keepSeed"/> is <see langword="true"/>, the current random seed will be preserved. Useful for seeking and playback.</para>
    /// </summary>
    public void Restart(bool keepSeed = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind38, GodotObject.GetPtr(this), keepSeed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubEmitter, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubEmitter(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind39, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubEmitter, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetSubEmitter()
    {
        return NativeCalls.godot_icall_0_124(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EmitParticle, 2179202058ul);

    /// <summary>
    /// <para>Emits a single particle. Whether <paramref name="xform"/>, <paramref name="velocity"/>, <paramref name="color"/> and <paramref name="custom"/> are applied depends on the value of <paramref name="flags"/>. See <see cref="Godot.GpuParticles2D.EmitFlags"/>.</para>
    /// <para>The default ParticleProcessMaterial will overwrite <paramref name="color"/> and use the contents of <paramref name="custom"/> as <c>(rotation, age, animation, lifetime)</c>.</para>
    /// <para><b>Note:</b> <see cref="Godot.GpuParticles2D.EmitParticle(Transform2D, Vector2, Color, Color, uint)"/> is only supported on the Forward+ and Mobile rendering methods, not Compatibility.</para>
    /// </summary>
    public unsafe void EmitParticle(Transform2D xform, Vector2 velocity, Color color, Color custom, uint flags)
    {
        NativeCalls.godot_icall_5_657(MethodBind41, GodotObject.GetPtr(this), &xform, &velocity, &color, &custom, flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrailEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrailEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind42, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrailLifetime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrailLifetime(double secs)
    {
        NativeCalls.godot_icall_1_127(MethodBind43, GodotObject.GetPtr(this), secs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTrailEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTrailEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind44, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrailLifetime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetTrailLifetime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrailSections, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrailSections(int sections)
    {
        NativeCalls.godot_icall_1_38(MethodBind46, GodotObject.GetPtr(this), sections);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrailSections, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTrailSections()
    {
        return NativeCalls.godot_icall_0_39(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrailSectionSubdivisions, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrailSectionSubdivisions(int subdivisions)
    {
        NativeCalls.godot_icall_1_38(MethodBind48, GodotObject.GetPtr(this), subdivisions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrailSectionSubdivisions, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTrailSectionSubdivisions()
    {
        return NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvertFromParticles, 1078189570ul);

    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="Godot.CpuParticles2D"/> node.</para>
    /// </summary>
    public void ConvertFromParticles(Node particles)
    {
        NativeCalls.godot_icall_1_56(MethodBind50, GodotObject.GetPtr(this), GodotObject.GetPtr(particles));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmountRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmountRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind51, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmountRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAmountRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseFixedSeed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseFixedSeed(bool useFixedSeed)
    {
        NativeCalls.godot_icall_1_14(MethodBind53, GodotObject.GetPtr(this), useFixedSeed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseFixedSeed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseFixedSeed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind54, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSeed, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSeed(uint seed)
    {
        NativeCalls.godot_icall_1_208(MethodBind55, GodotObject.GetPtr(this), seed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSeed, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetSeed()
    {
        return NativeCalls.godot_icall_0_209(MethodBind56, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Restart, 3218959716ul);

    /// <summary>
    /// <para>Restarts the particle emission cycle, clearing existing particles. To avoid particles vanishing from the viewport, wait for the <see cref="Godot.GpuParticles2D.Finished"/> signal before calling.</para>
    /// <para><b>Note:</b> The <see cref="Godot.GpuParticles2D.Finished"/> signal is only emitted by <see cref="Godot.GpuParticles2D.OneShot"/> emitters.</para>
    /// <para>If <paramref name="keepSeed"/> is <see langword="true"/>, the current random seed will be preserved. Useful for seeking and playback.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Restart()
    {
        NativeCalls.godot_icall_0_3(MethodBind57, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when all active particles have finished processing. To immediately restart the emission cycle, call <see cref="Godot.GpuParticles2D.Restart(bool)"/>.</para>
    /// <para>This signal is never emitted when <see cref="Godot.GpuParticles2D.OneShot"/> is disabled, as particles will be emitted and processed continuously.</para>
    /// <para><b>Note:</b> For <see cref="Godot.GpuParticles2D.OneShot"/> emitters, due to the particles being computed on the GPU, there may be a short period after receiving the signal during which setting <see cref="Godot.GpuParticles2D.Emitting"/> to <see langword="true"/> will not restart the emission cycle. This delay is avoided by instead calling <see cref="Godot.GpuParticles2D.Restart(bool)"/>.</para>
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
    public new class PropertyName : Node2D.PropertyName
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
        /// Cached name for the 'amount_ratio' property.
        /// </summary>
        public static readonly StringName AmountRatio = "amount_ratio";
        /// <summary>
        /// Cached name for the 'sub_emitter' property.
        /// </summary>
        public static readonly StringName SubEmitter = "sub_emitter";
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
        /// <summary>
        /// Cached name for the 'lifetime' property.
        /// </summary>
        public static readonly StringName Lifetime = "lifetime";
        /// <summary>
        /// Cached name for the 'interp_to_end' property.
        /// </summary>
        public static readonly StringName InterpToEnd = "interp_to_end";
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
        /// Cached name for the 'fixed_fps' property.
        /// </summary>
        public static readonly StringName FixedFps = "fixed_fps";
        /// <summary>
        /// Cached name for the 'interpolate' property.
        /// </summary>
        public static readonly StringName Interpolate = "interpolate";
        /// <summary>
        /// Cached name for the 'fract_delta' property.
        /// </summary>
        public static readonly StringName FractDelta = "fract_delta";
        /// <summary>
        /// Cached name for the 'collision_base_size' property.
        /// </summary>
        public static readonly StringName CollisionBaseSize = "collision_base_size";
        /// <summary>
        /// Cached name for the 'visibility_rect' property.
        /// </summary>
        public static readonly StringName VisibilityRect = "visibility_rect";
        /// <summary>
        /// Cached name for the 'local_coords' property.
        /// </summary>
        public static readonly StringName LocalCoords = "local_coords";
        /// <summary>
        /// Cached name for the 'draw_order' property.
        /// </summary>
        public static readonly StringName DrawOrder = "draw_order";
        /// <summary>
        /// Cached name for the 'trail_enabled' property.
        /// </summary>
        public static readonly StringName TrailEnabled = "trail_enabled";
        /// <summary>
        /// Cached name for the 'trail_lifetime' property.
        /// </summary>
        public static readonly StringName TrailLifetime = "trail_lifetime";
        /// <summary>
        /// Cached name for the 'trail_sections' property.
        /// </summary>
        public static readonly StringName TrailSections = "trail_sections";
        /// <summary>
        /// Cached name for the 'trail_section_subdivisions' property.
        /// </summary>
        public static readonly StringName TrailSectionSubdivisions = "trail_section_subdivisions";
        /// <summary>
        /// Cached name for the 'process_material' property.
        /// </summary>
        public static readonly StringName ProcessMaterial = "process_material";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
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
        /// Cached name for the 'set_visibility_rect' method.
        /// </summary>
        public static readonly StringName SetVisibilityRect = "set_visibility_rect";
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
        /// Cached name for the 'set_interpolate' method.
        /// </summary>
        public static readonly StringName SetInterpolate = "set_interpolate";
        /// <summary>
        /// Cached name for the 'set_process_material' method.
        /// </summary>
        public static readonly StringName SetProcessMaterial = "set_process_material";
        /// <summary>
        /// Cached name for the 'set_speed_scale' method.
        /// </summary>
        public static readonly StringName SetSpeedScale = "set_speed_scale";
        /// <summary>
        /// Cached name for the 'set_collision_base_size' method.
        /// </summary>
        public static readonly StringName SetCollisionBaseSize = "set_collision_base_size";
        /// <summary>
        /// Cached name for the 'set_interp_to_end' method.
        /// </summary>
        public static readonly StringName SetInterpToEnd = "set_interp_to_end";
        /// <summary>
        /// Cached name for the 'request_particles_process' method.
        /// </summary>
        public static readonly StringName RequestParticlesProcess = "request_particles_process";
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
        /// Cached name for the 'get_visibility_rect' method.
        /// </summary>
        public static readonly StringName GetVisibilityRect = "get_visibility_rect";
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
        /// Cached name for the 'get_interpolate' method.
        /// </summary>
        public static readonly StringName GetInterpolate = "get_interpolate";
        /// <summary>
        /// Cached name for the 'get_process_material' method.
        /// </summary>
        public static readonly StringName GetProcessMaterial = "get_process_material";
        /// <summary>
        /// Cached name for the 'get_speed_scale' method.
        /// </summary>
        public static readonly StringName GetSpeedScale = "get_speed_scale";
        /// <summary>
        /// Cached name for the 'get_collision_base_size' method.
        /// </summary>
        public static readonly StringName GetCollisionBaseSize = "get_collision_base_size";
        /// <summary>
        /// Cached name for the 'get_interp_to_end' method.
        /// </summary>
        public static readonly StringName GetInterpToEnd = "get_interp_to_end";
        /// <summary>
        /// Cached name for the 'set_draw_order' method.
        /// </summary>
        public static readonly StringName SetDrawOrder = "set_draw_order";
        /// <summary>
        /// Cached name for the 'get_draw_order' method.
        /// </summary>
        public static readonly StringName GetDrawOrder = "get_draw_order";
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'capture_rect' method.
        /// </summary>
        public static readonly StringName CaptureRect = "capture_rect";
        /// <summary>
        /// Cached name for the 'restart' method.
        /// </summary>
        public static readonly StringName Restart = "restart";
        /// <summary>
        /// Cached name for the 'set_sub_emitter' method.
        /// </summary>
        public static readonly StringName SetSubEmitter = "set_sub_emitter";
        /// <summary>
        /// Cached name for the 'get_sub_emitter' method.
        /// </summary>
        public static readonly StringName GetSubEmitter = "get_sub_emitter";
        /// <summary>
        /// Cached name for the 'emit_particle' method.
        /// </summary>
        public static readonly StringName EmitParticle = "emit_particle";
        /// <summary>
        /// Cached name for the 'set_trail_enabled' method.
        /// </summary>
        public static readonly StringName SetTrailEnabled = "set_trail_enabled";
        /// <summary>
        /// Cached name for the 'set_trail_lifetime' method.
        /// </summary>
        public static readonly StringName SetTrailLifetime = "set_trail_lifetime";
        /// <summary>
        /// Cached name for the 'is_trail_enabled' method.
        /// </summary>
        public static readonly StringName IsTrailEnabled = "is_trail_enabled";
        /// <summary>
        /// Cached name for the 'get_trail_lifetime' method.
        /// </summary>
        public static readonly StringName GetTrailLifetime = "get_trail_lifetime";
        /// <summary>
        /// Cached name for the 'set_trail_sections' method.
        /// </summary>
        public static readonly StringName SetTrailSections = "set_trail_sections";
        /// <summary>
        /// Cached name for the 'get_trail_sections' method.
        /// </summary>
        public static readonly StringName GetTrailSections = "get_trail_sections";
        /// <summary>
        /// Cached name for the 'set_trail_section_subdivisions' method.
        /// </summary>
        public static readonly StringName SetTrailSectionSubdivisions = "set_trail_section_subdivisions";
        /// <summary>
        /// Cached name for the 'get_trail_section_subdivisions' method.
        /// </summary>
        public static readonly StringName GetTrailSectionSubdivisions = "get_trail_section_subdivisions";
        /// <summary>
        /// Cached name for the 'convert_from_particles' method.
        /// </summary>
        public static readonly StringName ConvertFromParticles = "convert_from_particles";
        /// <summary>
        /// Cached name for the 'set_amount_ratio' method.
        /// </summary>
        public static readonly StringName SetAmountRatio = "set_amount_ratio";
        /// <summary>
        /// Cached name for the 'get_amount_ratio' method.
        /// </summary>
        public static readonly StringName GetAmountRatio = "get_amount_ratio";
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'finished' signal.
        /// </summary>
        public static readonly StringName Finished = "finished";
    }
}
