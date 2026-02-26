namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.SkeletonProfile"/> as a preset that is optimized for the human form. This exists for standardization, so all parameters are read-only.</para>
/// <para>A humanoid skeleton profile contains 56 bones divided into 4 groups: <c>"Body"</c>, <c>"Face"</c>, <c>"LeftHand"</c>, and <c>"RightHand"</c>. It is structured as follows:</para>
/// <para><code>
/// Root
/// └─ Hips
///     ├─ LeftUpperLeg
///     │  └─ LeftLowerLeg
///     │     └─ LeftFoot
///     │        └─ LeftToes
///     ├─ RightUpperLeg
///     │  └─ RightLowerLeg
///     │     └─ RightFoot
///     │        └─ RightToes
///     └─ Spine
///         └─ Chest
///             └─ UpperChest
///                 ├─ Neck
///                 │   └─ Head
///                 │       ├─ Jaw
///                 │       ├─ LeftEye
///                 │       └─ RightEye
///                 ├─ LeftShoulder
///                 │  └─ LeftUpperArm
///                 │     └─ LeftLowerArm
///                 │        └─ LeftHand
///                 │           ├─ LeftThumbMetacarpal
///                 │           │  └─ LeftThumbProximal
///                 │           │    └─ LeftThumbDistal
///                 │           ├─ LeftIndexProximal
///                 │           │  └─ LeftIndexIntermediate
///                 │           │    └─ LeftIndexDistal
///                 │           ├─ LeftMiddleProximal
///                 │           │  └─ LeftMiddleIntermediate
///                 │           │    └─ LeftMiddleDistal
///                 │           ├─ LeftRingProximal
///                 │           │  └─ LeftRingIntermediate
///                 │           │    └─ LeftRingDistal
///                 │           └─ LeftLittleProximal
///                 │              └─ LeftLittleIntermediate
///                 │                └─ LeftLittleDistal
///                 └─ RightShoulder
///                    └─ RightUpperArm
///                       └─ RightLowerArm
///                          └─ RightHand
///                             ├─ RightThumbMetacarpal
///                             │  └─ RightThumbProximal
///                             │     └─ RightThumbDistal
///                             ├─ RightIndexProximal
///                             │  └─ RightIndexIntermediate
///                             │     └─ RightIndexDistal
///                             ├─ RightMiddleProximal
///                             │  └─ RightMiddleIntermediate
///                             │     └─ RightMiddleDistal
///                             ├─ RightRingProximal
///                             │  └─ RightRingIntermediate
///                             │     └─ RightRingDistal
///                             └─ RightLittleProximal
///                                └─ RightLittleIntermediate
///                                  └─ RightLittleDistal
/// </code></para>
/// </summary>
public partial class SkeletonProfileHumanoid : SkeletonProfile
{
    private static readonly System.Type CachedType = typeof(SkeletonProfileHumanoid);

    private static readonly StringName NativeName = "SkeletonProfileHumanoid";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonProfileHumanoid() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonProfileHumanoid(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonProfileHumanoid(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : SkeletonProfile.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonProfile.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonProfile.SignalName
    {
    }
}
