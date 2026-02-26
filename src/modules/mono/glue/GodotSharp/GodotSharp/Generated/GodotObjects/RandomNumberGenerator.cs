namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>RandomNumberGenerator is a class for generating pseudo-random numbers. It currently uses <a href="https://www.pcg-random.org/">PCG32</a>.</para>
/// <para><b>Note:</b> The underlying algorithm is an implementation detail and should not be depended upon.</para>
/// <para>To generate a random float number (within a given range) based on a time-dependent seed:</para>
/// <para><code>
/// var rng = RandomNumberGenerator.new()
/// func _ready():
/// 	var my_random_number = rng.randf_range(-10.0, 10.0)
/// </code></para>
/// </summary>
public partial class RandomNumberGenerator : RefCounted
{
    /// <summary>
    /// <para>Initializes the random number generator state based on the given seed value. A given seed will give a reproducible sequence of pseudo-random numbers.</para>
    /// <para><b>Note:</b> The RNG does not have an avalanche effect, and can output similar random streams given similar seeds. Consider using a hash function to improve your seed quality if they're sourced externally.</para>
    /// <para><b>Note:</b> Setting this property produces a side effect of changing the internal <see cref="Godot.RandomNumberGenerator.State"/>, so make sure to initialize the seed <i>before</i> modifying the <see cref="Godot.RandomNumberGenerator.State"/>:</para>
    /// <para><b>Note:</b> The default value of this property is pseudo-random, and changes when calling <see cref="Godot.RandomNumberGenerator.Randomize()"/>. The <c>0</c> value documented here is a placeholder, and not the actual default seed.</para>
    /// <para><code>
    /// var rng = RandomNumberGenerator.new()
    /// rng.seed = hash("Godot")
    /// rng.state = 100 # Restore to some previously saved state.
    /// </code></para>
    /// </summary>
    public ulong Seed
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
    /// <para>The current state of the random number generator. Save and restore this property to restore the generator to a previous state:</para>
    /// <para><code>
    /// var rng = RandomNumberGenerator.new()
    /// print(rng.randf())
    /// var saved_state = rng.state # Store current state.
    /// print(rng.randf()) # Advance internal state.
    /// rng.state = saved_state # Restore the state.
    /// print(rng.randf()) # Prints the same value as previously.
    /// </code></para>
    /// <para><b>Note:</b> Do not set state to arbitrary values, since the random number generator requires the state to have certain qualities to behave properly. It should only be set to values that came from the state property itself. To initialize the random number generator with arbitrary input, use <see cref="Godot.RandomNumberGenerator.Seed"/> instead.</para>
    /// <para><b>Note:</b> The default value of this property is pseudo-random, and changes when calling <see cref="Godot.RandomNumberGenerator.Randomize()"/>. The <c>0</c> value documented here is a placeholder, and not the actual default state.</para>
    /// </summary>
    public ulong State
    {
        get
        {
            return GetState();
        }
        set
        {
            SetState(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RandomNumberGenerator);

    private static readonly StringName NativeName = "RandomNumberGenerator";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RandomNumberGenerator() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RandomNumberGenerator(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RandomNumberGenerator(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSeed, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSeed(ulong seed)
    {
        NativeCalls.godot_icall_1_544(MethodBind0, GodotObject.GetPtr(this), seed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSeed, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ulong GetSeed()
    {
        return NativeCalls.godot_icall_0_137(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetState, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetState(ulong state)
    {
        NativeCalls.godot_icall_1_544(MethodBind2, GodotObject.GetPtr(this), state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetState, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ulong GetState()
    {
        return NativeCalls.godot_icall_0_137(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Randi, 2455072627ul);

    /// <summary>
    /// <para>Returns a pseudo-random 32-bit unsigned integer between <c>0</c> and <c>4294967295</c> (inclusive).</para>
    /// </summary>
    public uint Randi()
    {
        return NativeCalls.godot_icall_0_209(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Randf, 191475506ul);

    /// <summary>
    /// <para>Returns a pseudo-random float between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
    /// </summary>
    public float Randf()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Randfn, 837325100ul);

    /// <summary>
    /// <para>Returns a <a href="https://en.wikipedia.org/wiki/Normal_distribution">normally-distributed</a>, pseudo-random floating-point number from the specified <paramref name="mean"/> and a standard <paramref name="deviation"/>. This is also known as a Gaussian distribution.</para>
    /// <para><b>Note:</b> This method uses the <a href="https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform">Box-Muller transform</a> algorithm.</para>
    /// </summary>
    public float Randfn(float mean = 0.0f, float deviation = 1.0f)
    {
        return NativeCalls.godot_icall_2_900(MethodBind6, GodotObject.GetPtr(this), mean, deviation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RandfRange, 4269894367ul);

    /// <summary>
    /// <para>Returns a pseudo-random float between <paramref name="from"/> and <paramref name="to"/> (inclusive).</para>
    /// </summary>
    public float RandfRange(float from, float to)
    {
        return NativeCalls.godot_icall_2_900(MethodBind7, GodotObject.GetPtr(this), from, to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RandiRange, 50157827ul);

    /// <summary>
    /// <para>Returns a pseudo-random 32-bit signed integer between <paramref name="from"/> and <paramref name="to"/> (inclusive).</para>
    /// </summary>
    public int RandiRange(int from, int to)
    {
        return NativeCalls.godot_icall_2_73(MethodBind8, GodotObject.GetPtr(this), from, to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RandWeighted, 4189642986ul);

    /// <summary>
    /// <para>Returns a random index with non-uniform weights. Prints an error and returns <c>-1</c> if the array is empty.</para>
    /// <para></para>
    /// </summary>
    public long RandWeighted(float[] weights)
    {
        return NativeCalls.godot_icall_1_1032(MethodBind9, GodotObject.GetPtr(this), weights);
    }

    /// <summary>
    /// <para>Returns a random index with non-uniform weights. Prints an error and returns <c>-1</c> if the array is empty.</para>
    /// <para></para>
    /// </summary>
    public long RandWeighted(ReadOnlySpan<float> weights)
    {
        return NativeCalls.godot_icall_1_1032(MethodBind9, GodotObject.GetPtr(this), weights);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Randomize, 3218959716ul);

    /// <summary>
    /// <para>Sets up a time-based seed for this <see cref="Godot.RandomNumberGenerator"/> instance. Unlike the <c>@GlobalScope</c> random number generation functions, different <see cref="Godot.RandomNumberGenerator"/> instances can use different seeds.</para>
    /// </summary>
    public void Randomize()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
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
        /// <summary>
        /// Cached name for the 'seed' property.
        /// </summary>
        public static readonly StringName Seed = "seed";
        /// <summary>
        /// Cached name for the 'state' property.
        /// </summary>
        public static readonly StringName State = "state";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_seed' method.
        /// </summary>
        public static readonly StringName SetSeed = "set_seed";
        /// <summary>
        /// Cached name for the 'get_seed' method.
        /// </summary>
        public static readonly StringName GetSeed = "get_seed";
        /// <summary>
        /// Cached name for the 'set_state' method.
        /// </summary>
        public static readonly StringName SetState = "set_state";
        /// <summary>
        /// Cached name for the 'get_state' method.
        /// </summary>
        public static readonly StringName GetState = "get_state";
        /// <summary>
        /// Cached name for the 'randi' method.
        /// </summary>
        public static readonly StringName Randi = "randi";
        /// <summary>
        /// Cached name for the 'randf' method.
        /// </summary>
        public static readonly StringName Randf = "randf";
        /// <summary>
        /// Cached name for the 'randfn' method.
        /// </summary>
        public static readonly StringName Randfn = "randfn";
        /// <summary>
        /// Cached name for the 'randf_range' method.
        /// </summary>
        public static readonly StringName RandfRange = "randf_range";
        /// <summary>
        /// Cached name for the 'randi_range' method.
        /// </summary>
        public static readonly StringName RandiRange = "randi_range";
        /// <summary>
        /// Cached name for the 'rand_weighted' method.
        /// </summary>
        public static readonly StringName RandWeighted = "rand_weighted";
        /// <summary>
        /// Cached name for the 'randomize' method.
        /// </summary>
        public static readonly StringName Randomize = "randomize";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
