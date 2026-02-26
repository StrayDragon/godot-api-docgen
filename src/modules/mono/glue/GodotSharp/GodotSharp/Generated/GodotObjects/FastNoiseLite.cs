namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class generates noise using the FastNoiseLite library, which is a collection of several noise algorithms including Cellular, Perlin, Value, and more.</para>
/// <para>Most generated noise values are in the range of <c>[-1, 1]</c>, but not always. Some of the cellular noise algorithms return results above <c>1</c>.</para>
/// </summary>
public partial class FastNoiseLite : Noise
{
    public enum NoiseTypeEnum : long
    {
        /// <summary>
        /// <para>A lattice of points are assigned random values then interpolated based on neighboring values.</para>
        /// </summary>
        Value = 5,
        /// <summary>
        /// <para>Similar to value noise (<see cref="Godot.FastNoiseLite.NoiseTypeEnum.Value"/>), but slower. Has more variance in peaks and valleys.</para>
        /// <para>Cubic noise can be used to avoid certain artifacts when using value noise to create a bumpmap. In general, you should always use this mode if the value noise is being used for a heightmap or bumpmap.</para>
        /// </summary>
        ValueCubic = 4,
        /// <summary>
        /// <para>A lattice of random gradients. Their dot products are interpolated to obtain values in between the lattices.</para>
        /// </summary>
        Perlin = 3,
        /// <summary>
        /// <para>Cellular includes both Worley noise and Voronoi diagrams which creates various regions of the same value.</para>
        /// </summary>
        Cellular = 2,
        /// <summary>
        /// <para>As opposed to <see cref="Godot.FastNoiseLite.NoiseTypeEnum.Perlin"/>, gradients exist in a simplex lattice rather than a grid lattice, avoiding directional artifacts. Internally uses FastNoiseLite's OpenSimplex2 noise type.</para>
        /// </summary>
        Simplex = 0,
        /// <summary>
        /// <para>Modified, higher quality version of <see cref="Godot.FastNoiseLite.NoiseTypeEnum.Simplex"/>, but slower. Internally uses FastNoiseLite's OpenSimplex2S noise type.</para>
        /// </summary>
        SimplexSmooth = 1
    }

    public enum FractalTypeEnum : long
    {
        /// <summary>
        /// <para>No fractal noise.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Method using Fractional Brownian Motion to combine octaves into a fractal.</para>
        /// </summary>
        Fbm = 1,
        /// <summary>
        /// <para>Method of combining octaves into a fractal resulting in a "ridged" look.</para>
        /// </summary>
        Ridged = 2,
        /// <summary>
        /// <para>Method of combining octaves into a fractal with a ping pong effect.</para>
        /// </summary>
        PingPong = 3
    }

    public enum CellularDistanceFunctionEnum : long
    {
        /// <summary>
        /// <para>Euclidean distance to the nearest point.</para>
        /// </summary>
        Euclidean = 0,
        /// <summary>
        /// <para>Squared Euclidean distance to the nearest point.</para>
        /// </summary>
        EuclideanSquared = 1,
        /// <summary>
        /// <para>Manhattan distance (taxicab metric) to the nearest point.</para>
        /// </summary>
        Manhattan = 2,
        /// <summary>
        /// <para>Blend of <see cref="Godot.FastNoiseLite.CellularDistanceFunctionEnum.Euclidean"/> and <see cref="Godot.FastNoiseLite.CellularDistanceFunctionEnum.Manhattan"/> to give curved cell boundaries.</para>
        /// </summary>
        Hybrid = 3
    }

    public enum CellularReturnTypeEnum : long
    {
        /// <summary>
        /// <para>The cellular distance function will return the same value for all points within a cell.</para>
        /// </summary>
        CellValue = 0,
        /// <summary>
        /// <para>The cellular distance function will return a value determined by the distance to the nearest point.</para>
        /// </summary>
        Distance = 1,
        /// <summary>
        /// <para>The cellular distance function returns the distance to the second-nearest point.</para>
        /// </summary>
        Distance2 = 2,
        /// <summary>
        /// <para>The distance to the nearest point is added to the distance to the second-nearest point.</para>
        /// </summary>
        Distance2Add = 3,
        /// <summary>
        /// <para>The distance to the nearest point is subtracted from the distance to the second-nearest point.</para>
        /// </summary>
        Distance2Sub = 4,
        /// <summary>
        /// <para>The distance to the nearest point is multiplied with the distance to the second-nearest point.</para>
        /// </summary>
        Distance2Mul = 5,
        /// <summary>
        /// <para>The distance to the nearest point is divided by the distance to the second-nearest point.</para>
        /// </summary>
        Distance2Div = 6
    }

    public enum DomainWarpTypeEnum : long
    {
        /// <summary>
        /// <para>The domain is warped using the simplex noise algorithm.</para>
        /// </summary>
        Simplex = 0,
        /// <summary>
        /// <para>The domain is warped using a simplified version of the simplex noise algorithm.</para>
        /// </summary>
        SimplexReduced = 1,
        /// <summary>
        /// <para>The domain is warped using a simple noise grid (not as smooth as the other methods, but more performant).</para>
        /// </summary>
        BasicGrid = 2
    }

    public enum DomainWarpFractalTypeEnum : long
    {
        /// <summary>
        /// <para>No fractal noise for warping the space.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Warping the space progressively, octave for octave, resulting in a more "liquified" distortion.</para>
        /// </summary>
        Progressive = 1,
        /// <summary>
        /// <para>Warping the space independently for each octave, resulting in a more chaotic distortion.</para>
        /// </summary>
        Independent = 2
    }

    /// <summary>
    /// <para>The noise algorithm used.</para>
    /// </summary>
    public FastNoiseLite.NoiseTypeEnum NoiseType
    {
        get
        {
            return GetNoiseType();
        }
        set
        {
            SetNoiseType(value);
        }
    }

    /// <summary>
    /// <para>The random number seed for all noise types.</para>
    /// </summary>
    public int Seed
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
    /// <para>The frequency for all noise types. Low frequency results in smooth noise while high frequency results in rougher, more granular noise.</para>
    /// </summary>
    public float Frequency
    {
        get
        {
            return GetFrequency();
        }
        set
        {
            SetFrequency(value);
        }
    }

    /// <summary>
    /// <para>Translate the noise input coordinates by the given <see cref="Godot.Vector3"/>.</para>
    /// </summary>
    public Vector3 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>The method for combining octaves into a fractal.</para>
    /// </summary>
    public FastNoiseLite.FractalTypeEnum FractalType
    {
        get
        {
            return GetFractalType();
        }
        set
        {
            SetFractalType(value);
        }
    }

    /// <summary>
    /// <para>The number of noise layers that are sampled to get the final value for fractal noise types.</para>
    /// </summary>
    public int FractalOctaves
    {
        get
        {
            return GetFractalOctaves();
        }
        set
        {
            SetFractalOctaves(value);
        }
    }

    /// <summary>
    /// <para>Frequency multiplier between subsequent octaves. Increasing this value results in higher octaves producing noise with finer details and a rougher appearance.</para>
    /// </summary>
    public float FractalLacunarity
    {
        get
        {
            return GetFractalLacunarity();
        }
        set
        {
            SetFractalLacunarity(value);
        }
    }

    /// <summary>
    /// <para>Determines the strength of each subsequent layer of noise in fractal noise.</para>
    /// <para>A low value places more emphasis on the lower frequency base layers, while a high value puts more emphasis on the higher frequency layers.</para>
    /// </summary>
    public float FractalGain
    {
        get
        {
            return GetFractalGain();
        }
        set
        {
            SetFractalGain(value);
        }
    }

    /// <summary>
    /// <para>Higher weighting means higher octaves have less impact if lower octaves have a large impact.</para>
    /// </summary>
    public float FractalWeightedStrength
    {
        get
        {
            return GetFractalWeightedStrength();
        }
        set
        {
            SetFractalWeightedStrength(value);
        }
    }

    /// <summary>
    /// <para>Sets the strength of the fractal ping pong type.</para>
    /// </summary>
    public float FractalPingPongStrength
    {
        get
        {
            return GetFractalPingPongStrength();
        }
        set
        {
            SetFractalPingPongStrength(value);
        }
    }

    /// <summary>
    /// <para>Determines how the distance to the nearest/second-nearest point is computed.</para>
    /// </summary>
    public FastNoiseLite.CellularDistanceFunctionEnum CellularDistanceFunction
    {
        get
        {
            return GetCellularDistanceFunction();
        }
        set
        {
            SetCellularDistanceFunction(value);
        }
    }

    /// <summary>
    /// <para>Maximum distance a point can move off of its grid position. Set to <c>0</c> for an even grid.</para>
    /// </summary>
    public float CellularJitter
    {
        get
        {
            return GetCellularJitter();
        }
        set
        {
            SetCellularJitter(value);
        }
    }

    /// <summary>
    /// <para>Return type from cellular noise calculations.</para>
    /// </summary>
    public FastNoiseLite.CellularReturnTypeEnum CellularReturnType
    {
        get
        {
            return GetCellularReturnType();
        }
        set
        {
            SetCellularReturnType(value);
        }
    }

    /// <summary>
    /// <para>If enabled, another FastNoiseLite instance is used to warp the space, resulting in a distortion of the noise.</para>
    /// </summary>
    public bool DomainWarpEnabled
    {
        get
        {
            return IsDomainWarpEnabled();
        }
        set
        {
            SetDomainWarpEnabled(value);
        }
    }

    /// <summary>
    /// <para>The warp algorithm.</para>
    /// </summary>
    public FastNoiseLite.DomainWarpTypeEnum DomainWarpType
    {
        get
        {
            return GetDomainWarpType();
        }
        set
        {
            SetDomainWarpType(value);
        }
    }

    /// <summary>
    /// <para>Sets the maximum warp distance from the origin.</para>
    /// </summary>
    public float DomainWarpAmplitude
    {
        get
        {
            return GetDomainWarpAmplitude();
        }
        set
        {
            SetDomainWarpAmplitude(value);
        }
    }

    /// <summary>
    /// <para>Frequency of the noise which warps the space. Low frequency results in smooth noise while high frequency results in rougher, more granular noise.</para>
    /// </summary>
    public float DomainWarpFrequency
    {
        get
        {
            return GetDomainWarpFrequency();
        }
        set
        {
            SetDomainWarpFrequency(value);
        }
    }

    /// <summary>
    /// <para>The method for combining octaves into a fractal which is used to warp the space.</para>
    /// </summary>
    public FastNoiseLite.DomainWarpFractalTypeEnum DomainWarpFractalType
    {
        get
        {
            return GetDomainWarpFractalType();
        }
        set
        {
            SetDomainWarpFractalType(value);
        }
    }

    /// <summary>
    /// <para>The number of noise layers that are sampled to get the final value for the fractal noise which warps the space.</para>
    /// </summary>
    public int DomainWarpFractalOctaves
    {
        get
        {
            return GetDomainWarpFractalOctaves();
        }
        set
        {
            SetDomainWarpFractalOctaves(value);
        }
    }

    /// <summary>
    /// <para>The change in frequency between octaves, also known as "lacunarity", of the fractal noise which warps the space. Increasing this value results in higher octaves, producing noise with finer details and a rougher appearance.</para>
    /// </summary>
    public float DomainWarpFractalLacunarity
    {
        get
        {
            return GetDomainWarpFractalLacunarity();
        }
        set
        {
            SetDomainWarpFractalLacunarity(value);
        }
    }

    /// <summary>
    /// <para>Determines the strength of each subsequent layer of the noise which is used to warp the space.</para>
    /// <para>A low value places more emphasis on the lower frequency base layers, while a high value puts more emphasis on the higher frequency layers.</para>
    /// </summary>
    public float DomainWarpFractalGain
    {
        get
        {
            return GetDomainWarpFractalGain();
        }
        set
        {
            SetDomainWarpFractalGain(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FastNoiseLite);

    private static readonly StringName NativeName = "FastNoiseLite";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FastNoiseLite() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal FastNoiseLite(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FastNoiseLite(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNoiseType, 2624461392ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNoiseType(FastNoiseLite.NoiseTypeEnum type)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNoiseType, 1458108610ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FastNoiseLite.NoiseTypeEnum GetNoiseType()
    {
        return (FastNoiseLite.NoiseTypeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSeed, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSeed(int seed)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), seed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSeed, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSeed()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrequency, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrequency(float freq)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), freq);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrequency, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFrequency()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector3 offset)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetOffset()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractalType, 4132731174ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractalType(FastNoiseLite.FractalTypeEnum type)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractalType, 1036889279ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FastNoiseLite.FractalTypeEnum GetFractalType()
    {
        return (FastNoiseLite.FractalTypeEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractalOctaves, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractalOctaves(int octaveCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), octaveCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractalOctaves, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFractalOctaves()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractalLacunarity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractalLacunarity(float lacunarity)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), lacunarity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractalLacunarity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFractalLacunarity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractalGain, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractalGain(float gain)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), gain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractalGain, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFractalGain()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractalWeightedStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractalWeightedStrength(float weightedStrength)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), weightedStrength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractalWeightedStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFractalWeightedStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFractalPingPongStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFractalPingPongStrength(float pingPongStrength)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), pingPongStrength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFractalPingPongStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFractalPingPongStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellularDistanceFunction, 1006013267ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellularDistanceFunction(FastNoiseLite.CellularDistanceFunctionEnum func)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)func);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellularDistanceFunction, 2021274088ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FastNoiseLite.CellularDistanceFunctionEnum GetCellularDistanceFunction()
    {
        return (FastNoiseLite.CellularDistanceFunctionEnum)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellularJitter, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellularJitter(float jitter)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), jitter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellularJitter, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCellularJitter()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellularReturnType, 2654169698ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellularReturnType(FastNoiseLite.CellularReturnTypeEnum ret)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)ret);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellularReturnType, 3699796343ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FastNoiseLite.CellularReturnTypeEnum GetCellularReturnType()
    {
        return (FastNoiseLite.CellularReturnTypeEnum)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpEnabled(bool domainWarpEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind26, GodotObject.GetPtr(this), domainWarpEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDomainWarpEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDomainWarpEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind27, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpType, 3629692980ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpType(FastNoiseLite.DomainWarpTypeEnum domainWarpType)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)domainWarpType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainWarpType, 2980162020ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FastNoiseLite.DomainWarpTypeEnum GetDomainWarpType()
    {
        return (FastNoiseLite.DomainWarpTypeEnum)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpAmplitude, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpAmplitude(float domainWarpAmplitude)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), domainWarpAmplitude);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainWarpAmplitude, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDomainWarpAmplitude()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpFrequency, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpFrequency(float domainWarpFrequency)
    {
        NativeCalls.godot_icall_1_67(MethodBind32, GodotObject.GetPtr(this), domainWarpFrequency);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainWarpFrequency, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDomainWarpFrequency()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpFractalType, 3999408287ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpFractalType(FastNoiseLite.DomainWarpFractalTypeEnum domainWarpFractalType)
    {
        NativeCalls.godot_icall_1_38(MethodBind34, GodotObject.GetPtr(this), (int)domainWarpFractalType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainWarpFractalType, 407716934ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FastNoiseLite.DomainWarpFractalTypeEnum GetDomainWarpFractalType()
    {
        return (FastNoiseLite.DomainWarpFractalTypeEnum)NativeCalls.godot_icall_0_39(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpFractalOctaves, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpFractalOctaves(int domainWarpOctaveCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind36, GodotObject.GetPtr(this), domainWarpOctaveCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainWarpFractalOctaves, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDomainWarpFractalOctaves()
    {
        return NativeCalls.godot_icall_0_39(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpFractalLacunarity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpFractalLacunarity(float domainWarpLacunarity)
    {
        NativeCalls.godot_icall_1_67(MethodBind38, GodotObject.GetPtr(this), domainWarpLacunarity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainWarpFractalLacunarity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDomainWarpFractalLacunarity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDomainWarpFractalGain, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDomainWarpFractalGain(float domainWarpGain)
    {
        NativeCalls.godot_icall_1_67(MethodBind40, GodotObject.GetPtr(this), domainWarpGain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainWarpFractalGain, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDomainWarpFractalGain()
    {
        return NativeCalls.godot_icall_0_68(MethodBind41, GodotObject.GetPtr(this));
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
    public new class PropertyName : Noise.PropertyName
    {
        /// <summary>
        /// Cached name for the 'noise_type' property.
        /// </summary>
        public static readonly StringName NoiseType = "noise_type";
        /// <summary>
        /// Cached name for the 'seed' property.
        /// </summary>
        public static readonly StringName Seed = "seed";
        /// <summary>
        /// Cached name for the 'frequency' property.
        /// </summary>
        public static readonly StringName Frequency = "frequency";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'fractal_type' property.
        /// </summary>
        public static readonly StringName FractalType = "fractal_type";
        /// <summary>
        /// Cached name for the 'fractal_octaves' property.
        /// </summary>
        public static readonly StringName FractalOctaves = "fractal_octaves";
        /// <summary>
        /// Cached name for the 'fractal_lacunarity' property.
        /// </summary>
        public static readonly StringName FractalLacunarity = "fractal_lacunarity";
        /// <summary>
        /// Cached name for the 'fractal_gain' property.
        /// </summary>
        public static readonly StringName FractalGain = "fractal_gain";
        /// <summary>
        /// Cached name for the 'fractal_weighted_strength' property.
        /// </summary>
        public static readonly StringName FractalWeightedStrength = "fractal_weighted_strength";
        /// <summary>
        /// Cached name for the 'fractal_ping_pong_strength' property.
        /// </summary>
        public static readonly StringName FractalPingPongStrength = "fractal_ping_pong_strength";
        /// <summary>
        /// Cached name for the 'cellular_distance_function' property.
        /// </summary>
        public static readonly StringName CellularDistanceFunction = "cellular_distance_function";
        /// <summary>
        /// Cached name for the 'cellular_jitter' property.
        /// </summary>
        public static readonly StringName CellularJitter = "cellular_jitter";
        /// <summary>
        /// Cached name for the 'cellular_return_type' property.
        /// </summary>
        public static readonly StringName CellularReturnType = "cellular_return_type";
        /// <summary>
        /// Cached name for the 'domain_warp_enabled' property.
        /// </summary>
        public static readonly StringName DomainWarpEnabled = "domain_warp_enabled";
        /// <summary>
        /// Cached name for the 'domain_warp_type' property.
        /// </summary>
        public static readonly StringName DomainWarpType = "domain_warp_type";
        /// <summary>
        /// Cached name for the 'domain_warp_amplitude' property.
        /// </summary>
        public static readonly StringName DomainWarpAmplitude = "domain_warp_amplitude";
        /// <summary>
        /// Cached name for the 'domain_warp_frequency' property.
        /// </summary>
        public static readonly StringName DomainWarpFrequency = "domain_warp_frequency";
        /// <summary>
        /// Cached name for the 'domain_warp_fractal_type' property.
        /// </summary>
        public static readonly StringName DomainWarpFractalType = "domain_warp_fractal_type";
        /// <summary>
        /// Cached name for the 'domain_warp_fractal_octaves' property.
        /// </summary>
        public static readonly StringName DomainWarpFractalOctaves = "domain_warp_fractal_octaves";
        /// <summary>
        /// Cached name for the 'domain_warp_fractal_lacunarity' property.
        /// </summary>
        public static readonly StringName DomainWarpFractalLacunarity = "domain_warp_fractal_lacunarity";
        /// <summary>
        /// Cached name for the 'domain_warp_fractal_gain' property.
        /// </summary>
        public static readonly StringName DomainWarpFractalGain = "domain_warp_fractal_gain";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Noise.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_noise_type' method.
        /// </summary>
        public static readonly StringName SetNoiseType = "set_noise_type";
        /// <summary>
        /// Cached name for the 'get_noise_type' method.
        /// </summary>
        public static readonly StringName GetNoiseType = "get_noise_type";
        /// <summary>
        /// Cached name for the 'set_seed' method.
        /// </summary>
        public static readonly StringName SetSeed = "set_seed";
        /// <summary>
        /// Cached name for the 'get_seed' method.
        /// </summary>
        public static readonly StringName GetSeed = "get_seed";
        /// <summary>
        /// Cached name for the 'set_frequency' method.
        /// </summary>
        public static readonly StringName SetFrequency = "set_frequency";
        /// <summary>
        /// Cached name for the 'get_frequency' method.
        /// </summary>
        public static readonly StringName GetFrequency = "get_frequency";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_fractal_type' method.
        /// </summary>
        public static readonly StringName SetFractalType = "set_fractal_type";
        /// <summary>
        /// Cached name for the 'get_fractal_type' method.
        /// </summary>
        public static readonly StringName GetFractalType = "get_fractal_type";
        /// <summary>
        /// Cached name for the 'set_fractal_octaves' method.
        /// </summary>
        public static readonly StringName SetFractalOctaves = "set_fractal_octaves";
        /// <summary>
        /// Cached name for the 'get_fractal_octaves' method.
        /// </summary>
        public static readonly StringName GetFractalOctaves = "get_fractal_octaves";
        /// <summary>
        /// Cached name for the 'set_fractal_lacunarity' method.
        /// </summary>
        public static readonly StringName SetFractalLacunarity = "set_fractal_lacunarity";
        /// <summary>
        /// Cached name for the 'get_fractal_lacunarity' method.
        /// </summary>
        public static readonly StringName GetFractalLacunarity = "get_fractal_lacunarity";
        /// <summary>
        /// Cached name for the 'set_fractal_gain' method.
        /// </summary>
        public static readonly StringName SetFractalGain = "set_fractal_gain";
        /// <summary>
        /// Cached name for the 'get_fractal_gain' method.
        /// </summary>
        public static readonly StringName GetFractalGain = "get_fractal_gain";
        /// <summary>
        /// Cached name for the 'set_fractal_weighted_strength' method.
        /// </summary>
        public static readonly StringName SetFractalWeightedStrength = "set_fractal_weighted_strength";
        /// <summary>
        /// Cached name for the 'get_fractal_weighted_strength' method.
        /// </summary>
        public static readonly StringName GetFractalWeightedStrength = "get_fractal_weighted_strength";
        /// <summary>
        /// Cached name for the 'set_fractal_ping_pong_strength' method.
        /// </summary>
        public static readonly StringName SetFractalPingPongStrength = "set_fractal_ping_pong_strength";
        /// <summary>
        /// Cached name for the 'get_fractal_ping_pong_strength' method.
        /// </summary>
        public static readonly StringName GetFractalPingPongStrength = "get_fractal_ping_pong_strength";
        /// <summary>
        /// Cached name for the 'set_cellular_distance_function' method.
        /// </summary>
        public static readonly StringName SetCellularDistanceFunction = "set_cellular_distance_function";
        /// <summary>
        /// Cached name for the 'get_cellular_distance_function' method.
        /// </summary>
        public static readonly StringName GetCellularDistanceFunction = "get_cellular_distance_function";
        /// <summary>
        /// Cached name for the 'set_cellular_jitter' method.
        /// </summary>
        public static readonly StringName SetCellularJitter = "set_cellular_jitter";
        /// <summary>
        /// Cached name for the 'get_cellular_jitter' method.
        /// </summary>
        public static readonly StringName GetCellularJitter = "get_cellular_jitter";
        /// <summary>
        /// Cached name for the 'set_cellular_return_type' method.
        /// </summary>
        public static readonly StringName SetCellularReturnType = "set_cellular_return_type";
        /// <summary>
        /// Cached name for the 'get_cellular_return_type' method.
        /// </summary>
        public static readonly StringName GetCellularReturnType = "get_cellular_return_type";
        /// <summary>
        /// Cached name for the 'set_domain_warp_enabled' method.
        /// </summary>
        public static readonly StringName SetDomainWarpEnabled = "set_domain_warp_enabled";
        /// <summary>
        /// Cached name for the 'is_domain_warp_enabled' method.
        /// </summary>
        public static readonly StringName IsDomainWarpEnabled = "is_domain_warp_enabled";
        /// <summary>
        /// Cached name for the 'set_domain_warp_type' method.
        /// </summary>
        public static readonly StringName SetDomainWarpType = "set_domain_warp_type";
        /// <summary>
        /// Cached name for the 'get_domain_warp_type' method.
        /// </summary>
        public static readonly StringName GetDomainWarpType = "get_domain_warp_type";
        /// <summary>
        /// Cached name for the 'set_domain_warp_amplitude' method.
        /// </summary>
        public static readonly StringName SetDomainWarpAmplitude = "set_domain_warp_amplitude";
        /// <summary>
        /// Cached name for the 'get_domain_warp_amplitude' method.
        /// </summary>
        public static readonly StringName GetDomainWarpAmplitude = "get_domain_warp_amplitude";
        /// <summary>
        /// Cached name for the 'set_domain_warp_frequency' method.
        /// </summary>
        public static readonly StringName SetDomainWarpFrequency = "set_domain_warp_frequency";
        /// <summary>
        /// Cached name for the 'get_domain_warp_frequency' method.
        /// </summary>
        public static readonly StringName GetDomainWarpFrequency = "get_domain_warp_frequency";
        /// <summary>
        /// Cached name for the 'set_domain_warp_fractal_type' method.
        /// </summary>
        public static readonly StringName SetDomainWarpFractalType = "set_domain_warp_fractal_type";
        /// <summary>
        /// Cached name for the 'get_domain_warp_fractal_type' method.
        /// </summary>
        public static readonly StringName GetDomainWarpFractalType = "get_domain_warp_fractal_type";
        /// <summary>
        /// Cached name for the 'set_domain_warp_fractal_octaves' method.
        /// </summary>
        public static readonly StringName SetDomainWarpFractalOctaves = "set_domain_warp_fractal_octaves";
        /// <summary>
        /// Cached name for the 'get_domain_warp_fractal_octaves' method.
        /// </summary>
        public static readonly StringName GetDomainWarpFractalOctaves = "get_domain_warp_fractal_octaves";
        /// <summary>
        /// Cached name for the 'set_domain_warp_fractal_lacunarity' method.
        /// </summary>
        public static readonly StringName SetDomainWarpFractalLacunarity = "set_domain_warp_fractal_lacunarity";
        /// <summary>
        /// Cached name for the 'get_domain_warp_fractal_lacunarity' method.
        /// </summary>
        public static readonly StringName GetDomainWarpFractalLacunarity = "get_domain_warp_fractal_lacunarity";
        /// <summary>
        /// Cached name for the 'set_domain_warp_fractal_gain' method.
        /// </summary>
        public static readonly StringName SetDomainWarpFractalGain = "set_domain_warp_fractal_gain";
        /// <summary>
        /// Cached name for the 'get_domain_warp_fractal_gain' method.
        /// </summary>
        public static readonly StringName GetDomainWarpFractalGain = "get_domain_warp_fractal_gain";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Noise.SignalName
    {
    }
}
