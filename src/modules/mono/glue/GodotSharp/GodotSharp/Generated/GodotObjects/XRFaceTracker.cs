namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An instance of this object represents a tracked face and its corresponding blend shapes. The blend shapes come from the <a href="https://docs.vrcft.io/docs/tutorial-avatars/tutorial-avatars-extras/unified-blendshapes">Unified Expressions</a> standard, and contain extended details and visuals for each blend shape. Additionally the <a href="https://docs.vrcft.io/docs/tutorial-avatars/tutorial-avatars-extras/compatibility/overview">Tracking Standard Comparison</a> page documents the relationship between Unified Expressions and other standards.</para>
/// <para>As face trackers are turned on they are registered with the <see cref="Godot.XRServer"/>.</para>
/// </summary>
public partial class XRFaceTracker : XRTracker
{
    public enum BlendShapeEntry : long
    {
        /// <summary>
        /// <para>Right eye looks outwards.</para>
        /// </summary>
        EyeLookOutRight = 0,
        /// <summary>
        /// <para>Right eye looks inwards.</para>
        /// </summary>
        EyeLookInRight = 1,
        /// <summary>
        /// <para>Right eye looks upwards.</para>
        /// </summary>
        EyeLookUpRight = 2,
        /// <summary>
        /// <para>Right eye looks downwards.</para>
        /// </summary>
        EyeLookDownRight = 3,
        /// <summary>
        /// <para>Left eye looks outwards.</para>
        /// </summary>
        EyeLookOutLeft = 4,
        /// <summary>
        /// <para>Left eye looks inwards.</para>
        /// </summary>
        EyeLookInLeft = 5,
        /// <summary>
        /// <para>Left eye looks upwards.</para>
        /// </summary>
        EyeLookUpLeft = 6,
        /// <summary>
        /// <para>Left eye looks downwards.</para>
        /// </summary>
        EyeLookDownLeft = 7,
        /// <summary>
        /// <para>Closes the right eyelid.</para>
        /// </summary>
        EyeClosedRight = 8,
        /// <summary>
        /// <para>Closes the left eyelid.</para>
        /// </summary>
        EyeClosedLeft = 9,
        /// <summary>
        /// <para>Squeezes the right eye socket muscles.</para>
        /// </summary>
        EyeSquintRight = 10,
        /// <summary>
        /// <para>Squeezes the left eye socket muscles.</para>
        /// </summary>
        EyeSquintLeft = 11,
        /// <summary>
        /// <para>Right eyelid widens beyond relaxed.</para>
        /// </summary>
        EyeWideRight = 12,
        /// <summary>
        /// <para>Left eyelid widens beyond relaxed.</para>
        /// </summary>
        EyeWideLeft = 13,
        /// <summary>
        /// <para>Dilates the right eye pupil.</para>
        /// </summary>
        EyeDilationRight = 14,
        /// <summary>
        /// <para>Dilates the left eye pupil.</para>
        /// </summary>
        EyeDilationLeft = 15,
        /// <summary>
        /// <para>Constricts the right eye pupil.</para>
        /// </summary>
        EyeConstrictRight = 16,
        /// <summary>
        /// <para>Constricts the left eye pupil.</para>
        /// </summary>
        EyeConstrictLeft = 17,
        /// <summary>
        /// <para>Right eyebrow pinches in.</para>
        /// </summary>
        BrowPinchRight = 18,
        /// <summary>
        /// <para>Left eyebrow pinches in.</para>
        /// </summary>
        BrowPinchLeft = 19,
        /// <summary>
        /// <para>Outer right eyebrow pulls down.</para>
        /// </summary>
        BrowLowererRight = 20,
        /// <summary>
        /// <para>Outer left eyebrow pulls down.</para>
        /// </summary>
        BrowLowererLeft = 21,
        /// <summary>
        /// <para>Inner right eyebrow pulls up.</para>
        /// </summary>
        BrowInnerUpRight = 22,
        /// <summary>
        /// <para>Inner left eyebrow pulls up.</para>
        /// </summary>
        BrowInnerUpLeft = 23,
        /// <summary>
        /// <para>Outer right eyebrow pulls up.</para>
        /// </summary>
        BrowOuterUpRight = 24,
        /// <summary>
        /// <para>Outer left eyebrow pulls up.</para>
        /// </summary>
        BrowOuterUpLeft = 25,
        /// <summary>
        /// <para>Right side face sneers.</para>
        /// </summary>
        NoseSneerRight = 26,
        /// <summary>
        /// <para>Left side face sneers.</para>
        /// </summary>
        NoseSneerLeft = 27,
        /// <summary>
        /// <para>Right side nose canal dilates.</para>
        /// </summary>
        NasalDilationRight = 28,
        /// <summary>
        /// <para>Left side nose canal dilates.</para>
        /// </summary>
        NasalDilationLeft = 29,
        /// <summary>
        /// <para>Right side nose canal constricts.</para>
        /// </summary>
        NasalConstrictRight = 30,
        /// <summary>
        /// <para>Left side nose canal constricts.</para>
        /// </summary>
        NasalConstrictLeft = 31,
        /// <summary>
        /// <para>Raises the right side cheek.</para>
        /// </summary>
        CheekSquintRight = 32,
        /// <summary>
        /// <para>Raises the left side cheek.</para>
        /// </summary>
        CheekSquintLeft = 33,
        /// <summary>
        /// <para>Puffs the right side cheek.</para>
        /// </summary>
        CheekPuffRight = 34,
        /// <summary>
        /// <para>Puffs the left side cheek.</para>
        /// </summary>
        CheekPuffLeft = 35,
        /// <summary>
        /// <para>Sucks in the right side cheek.</para>
        /// </summary>
        CheekSuckRight = 36,
        /// <summary>
        /// <para>Sucks in the left side cheek.</para>
        /// </summary>
        CheekSuckLeft = 37,
        /// <summary>
        /// <para>Opens jawbone.</para>
        /// </summary>
        JawOpen = 38,
        /// <summary>
        /// <para>Closes the mouth.</para>
        /// </summary>
        MouthClosed = 39,
        /// <summary>
        /// <para>Pushes jawbone right.</para>
        /// </summary>
        JawRight = 40,
        /// <summary>
        /// <para>Pushes jawbone left.</para>
        /// </summary>
        JawLeft = 41,
        /// <summary>
        /// <para>Pushes jawbone forward.</para>
        /// </summary>
        JawForward = 42,
        /// <summary>
        /// <para>Pushes jawbone backward.</para>
        /// </summary>
        JawBackward = 43,
        /// <summary>
        /// <para>Flexes jaw muscles.</para>
        /// </summary>
        JawClench = 44,
        /// <summary>
        /// <para>Raises the jawbone.</para>
        /// </summary>
        JawMandibleRaise = 45,
        /// <summary>
        /// <para>Upper right lip part tucks in the mouth.</para>
        /// </summary>
        LipSuckUpperRight = 46,
        /// <summary>
        /// <para>Upper left lip part tucks in the mouth.</para>
        /// </summary>
        LipSuckUpperLeft = 47,
        /// <summary>
        /// <para>Lower right lip part tucks in the mouth.</para>
        /// </summary>
        LipSuckLowerRight = 48,
        /// <summary>
        /// <para>Lower left lip part tucks in the mouth.</para>
        /// </summary>
        LipSuckLowerLeft = 49,
        /// <summary>
        /// <para>Right lip corner folds into the mouth.</para>
        /// </summary>
        LipSuckCornerRight = 50,
        /// <summary>
        /// <para>Left lip corner folds into the mouth.</para>
        /// </summary>
        LipSuckCornerLeft = 51,
        /// <summary>
        /// <para>Upper right lip part pushes into a funnel.</para>
        /// </summary>
        LipFunnelUpperRight = 52,
        /// <summary>
        /// <para>Upper left lip part pushes into a funnel.</para>
        /// </summary>
        LipFunnelUpperLeft = 53,
        /// <summary>
        /// <para>Lower right lip part pushes into a funnel.</para>
        /// </summary>
        LipFunnelLowerRight = 54,
        /// <summary>
        /// <para>Lower left lip part pushes into a funnel.</para>
        /// </summary>
        LipFunnelLowerLeft = 55,
        /// <summary>
        /// <para>Upper right lip part pushes outwards.</para>
        /// </summary>
        LipPuckerUpperRight = 56,
        /// <summary>
        /// <para>Upper left lip part pushes outwards.</para>
        /// </summary>
        LipPuckerUpperLeft = 57,
        /// <summary>
        /// <para>Lower right lip part pushes outwards.</para>
        /// </summary>
        LipPuckerLowerRight = 58,
        /// <summary>
        /// <para>Lower left lip part pushes outwards.</para>
        /// </summary>
        LipPuckerLowerLeft = 59,
        /// <summary>
        /// <para>Upper right part of the lip pulls up.</para>
        /// </summary>
        MouthUpperUpRight = 60,
        /// <summary>
        /// <para>Upper left part of the lip pulls up.</para>
        /// </summary>
        MouthUpperUpLeft = 61,
        /// <summary>
        /// <para>Lower right part of the lip pulls up.</para>
        /// </summary>
        MouthLowerDownRight = 62,
        /// <summary>
        /// <para>Lower left part of the lip pulls up.</para>
        /// </summary>
        MouthLowerDownLeft = 63,
        /// <summary>
        /// <para>Upper right lip part pushes in the cheek.</para>
        /// </summary>
        MouthUpperDeepenRight = 64,
        /// <summary>
        /// <para>Upper left lip part pushes in the cheek.</para>
        /// </summary>
        MouthUpperDeepenLeft = 65,
        /// <summary>
        /// <para>Moves upper lip right.</para>
        /// </summary>
        MouthUpperRight = 66,
        /// <summary>
        /// <para>Moves upper lip left.</para>
        /// </summary>
        MouthUpperLeft = 67,
        /// <summary>
        /// <para>Moves lower lip right.</para>
        /// </summary>
        MouthLowerRight = 68,
        /// <summary>
        /// <para>Moves lower lip left.</para>
        /// </summary>
        MouthLowerLeft = 69,
        /// <summary>
        /// <para>Right lip corner pulls diagonally up and out.</para>
        /// </summary>
        MouthCornerPullRight = 70,
        /// <summary>
        /// <para>Left lip corner pulls diagonally up and out.</para>
        /// </summary>
        MouthCornerPullLeft = 71,
        /// <summary>
        /// <para>Right corner lip slants up.</para>
        /// </summary>
        MouthCornerSlantRight = 72,
        /// <summary>
        /// <para>Left corner lip slants up.</para>
        /// </summary>
        MouthCornerSlantLeft = 73,
        /// <summary>
        /// <para>Right corner lip pulls down.</para>
        /// </summary>
        MouthFrownRight = 74,
        /// <summary>
        /// <para>Left corner lip pulls down.</para>
        /// </summary>
        MouthFrownLeft = 75,
        /// <summary>
        /// <para>Mouth corner lip pulls out and down.</para>
        /// </summary>
        MouthStretchRight = 76,
        /// <summary>
        /// <para>Mouth corner lip pulls out and down.</para>
        /// </summary>
        MouthStretchLeft = 77,
        /// <summary>
        /// <para>Right lip corner is pushed backwards.</para>
        /// </summary>
        MouthDimpleRight = 78,
        /// <summary>
        /// <para>Left lip corner is pushed backwards.</para>
        /// </summary>
        MouthDimpleLeft = 79,
        /// <summary>
        /// <para>Raises and slightly pushes out the upper mouth.</para>
        /// </summary>
        MouthRaiserUpper = 80,
        /// <summary>
        /// <para>Raises and slightly pushes out the lower mouth.</para>
        /// </summary>
        MouthRaiserLower = 81,
        /// <summary>
        /// <para>Right side lips press and flatten together vertically.</para>
        /// </summary>
        MouthPressRight = 82,
        /// <summary>
        /// <para>Left side lips press and flatten together vertically.</para>
        /// </summary>
        MouthPressLeft = 83,
        /// <summary>
        /// <para>Right side lips squeeze together horizontally.</para>
        /// </summary>
        MouthTightenerRight = 84,
        /// <summary>
        /// <para>Left side lips squeeze together horizontally.</para>
        /// </summary>
        MouthTightenerLeft = 85,
        /// <summary>
        /// <para>Tongue visibly sticks out of the mouth.</para>
        /// </summary>
        TongueOut = 86,
        /// <summary>
        /// <para>Tongue points upwards.</para>
        /// </summary>
        TongueUp = 87,
        /// <summary>
        /// <para>Tongue points downwards.</para>
        /// </summary>
        TongueDown = 88,
        /// <summary>
        /// <para>Tongue points right.</para>
        /// </summary>
        TongueRight = 89,
        /// <summary>
        /// <para>Tongue points left.</para>
        /// </summary>
        TongueLeft = 90,
        /// <summary>
        /// <para>Sides of the tongue funnel, creating a roll.</para>
        /// </summary>
        TongueRoll = 91,
        /// <summary>
        /// <para>Tongue arches up then down inside the mouth.</para>
        /// </summary>
        TongueBlendDown = 92,
        /// <summary>
        /// <para>Tongue arches down then up inside the mouth.</para>
        /// </summary>
        TongueCurlUp = 93,
        /// <summary>
        /// <para>Tongue squishes together and thickens.</para>
        /// </summary>
        TongueSquish = 94,
        /// <summary>
        /// <para>Tongue flattens and thins out.</para>
        /// </summary>
        TongueFlat = 95,
        /// <summary>
        /// <para>Tongue tip rotates clockwise, with the rest following gradually.</para>
        /// </summary>
        TongueTwistRight = 96,
        /// <summary>
        /// <para>Tongue tip rotates counter-clockwise, with the rest following gradually.</para>
        /// </summary>
        TongueTwistLeft = 97,
        /// <summary>
        /// <para>Inner mouth throat closes.</para>
        /// </summary>
        SoftPalateClose = 98,
        /// <summary>
        /// <para>The Adam's apple visibly swallows.</para>
        /// </summary>
        ThroatSwallow = 99,
        /// <summary>
        /// <para>Right side neck visibly flexes.</para>
        /// </summary>
        NeckFlexRight = 100,
        /// <summary>
        /// <para>Left side neck visibly flexes.</para>
        /// </summary>
        NeckFlexLeft = 101,
        /// <summary>
        /// <para>Closes both eye lids.</para>
        /// </summary>
        EyeClosed = 102,
        /// <summary>
        /// <para>Widens both eye lids.</para>
        /// </summary>
        EyeWide = 103,
        /// <summary>
        /// <para>Squints both eye lids.</para>
        /// </summary>
        EyeSquint = 104,
        /// <summary>
        /// <para>Dilates both pupils.</para>
        /// </summary>
        EyeDilation = 105,
        /// <summary>
        /// <para>Constricts both pupils.</para>
        /// </summary>
        EyeConstrict = 106,
        /// <summary>
        /// <para>Pulls the right eyebrow down and in.</para>
        /// </summary>
        BrowDownRight = 107,
        /// <summary>
        /// <para>Pulls the left eyebrow down and in.</para>
        /// </summary>
        BrowDownLeft = 108,
        /// <summary>
        /// <para>Pulls both eyebrows down and in.</para>
        /// </summary>
        BrowDown = 109,
        /// <summary>
        /// <para>Right brow appears worried.</para>
        /// </summary>
        BrowUpRight = 110,
        /// <summary>
        /// <para>Left brow appears worried.</para>
        /// </summary>
        BrowUpLeft = 111,
        /// <summary>
        /// <para>Both brows appear worried.</para>
        /// </summary>
        BrowUp = 112,
        /// <summary>
        /// <para>Entire face sneers.</para>
        /// </summary>
        NoseSneer = 113,
        /// <summary>
        /// <para>Both nose canals dilate.</para>
        /// </summary>
        NasalDilation = 114,
        /// <summary>
        /// <para>Both nose canals constrict.</para>
        /// </summary>
        NasalConstrict = 115,
        /// <summary>
        /// <para>Puffs both cheeks.</para>
        /// </summary>
        CheekPuff = 116,
        /// <summary>
        /// <para>Sucks in both cheeks.</para>
        /// </summary>
        CheekSuck = 117,
        /// <summary>
        /// <para>Raises both cheeks.</para>
        /// </summary>
        CheekSquint = 118,
        /// <summary>
        /// <para>Tucks in the upper lips.</para>
        /// </summary>
        LipSuckUpper = 119,
        /// <summary>
        /// <para>Tucks in the lower lips.</para>
        /// </summary>
        LipSuckLower = 120,
        /// <summary>
        /// <para>Tucks in both lips.</para>
        /// </summary>
        LipSuck = 121,
        /// <summary>
        /// <para>Funnels in the upper lips.</para>
        /// </summary>
        LipFunnelUpper = 122,
        /// <summary>
        /// <para>Funnels in the lower lips.</para>
        /// </summary>
        LipFunnelLower = 123,
        /// <summary>
        /// <para>Funnels in both lips.</para>
        /// </summary>
        LipFunnel = 124,
        /// <summary>
        /// <para>Upper lip part pushes outwards.</para>
        /// </summary>
        LipPuckerUpper = 125,
        /// <summary>
        /// <para>Lower lip part pushes outwards.</para>
        /// </summary>
        LipPuckerLower = 126,
        /// <summary>
        /// <para>Lips push outwards.</para>
        /// </summary>
        LipPucker = 127,
        /// <summary>
        /// <para>Raises the upper lips.</para>
        /// </summary>
        MouthUpperUp = 128,
        /// <summary>
        /// <para>Lowers the lower lips.</para>
        /// </summary>
        MouthLowerDown = 129,
        /// <summary>
        /// <para>Mouth opens, revealing teeth.</para>
        /// </summary>
        MouthOpen = 130,
        /// <summary>
        /// <para>Moves mouth right.</para>
        /// </summary>
        MouthRight = 131,
        /// <summary>
        /// <para>Moves mouth left.</para>
        /// </summary>
        MouthLeft = 132,
        /// <summary>
        /// <para>Right side of the mouth smiles.</para>
        /// </summary>
        MouthSmileRight = 133,
        /// <summary>
        /// <para>Left side of the mouth smiles.</para>
        /// </summary>
        MouthSmileLeft = 134,
        /// <summary>
        /// <para>Mouth expresses a smile.</para>
        /// </summary>
        MouthSmile = 135,
        /// <summary>
        /// <para>Right side of the mouth expresses sadness.</para>
        /// </summary>
        MouthSadRight = 136,
        /// <summary>
        /// <para>Left side of the mouth expresses sadness.</para>
        /// </summary>
        MouthSadLeft = 137,
        /// <summary>
        /// <para>Mouth expresses sadness.</para>
        /// </summary>
        MouthSad = 138,
        /// <summary>
        /// <para>Mouth stretches.</para>
        /// </summary>
        MouthStretch = 139,
        /// <summary>
        /// <para>Lip corners dimple.</para>
        /// </summary>
        MouthDimple = 140,
        /// <summary>
        /// <para>Mouth tightens.</para>
        /// </summary>
        MouthTightener = 141,
        /// <summary>
        /// <para>Mouth presses together.</para>
        /// </summary>
        MouthPress = 142,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.XRFaceTracker.BlendShapeEntry"/> enum.</para>
        /// </summary>
        Max = 143
    }

    /// <summary>
    /// <para>The array of face blend shape weights with indices corresponding to the <see cref="Godot.XRFaceTracker.BlendShapeEntry"/> enum.</para>
    /// </summary>
    public float[] BlendShapes
    {
        get
        {
            return GetBlendShapes();
        }
        set
        {
            SetBlendShapes(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRFaceTracker);

    private static readonly StringName NativeName = "XRFaceTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRFaceTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRFaceTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRFaceTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShape, 330010046ul);

    /// <summary>
    /// <para>Returns the requested face blend shape weight.</para>
    /// </summary>
    public float GetBlendShape(XRFaceTracker.BlendShapeEntry blendShape)
    {
        return NativeCalls.godot_icall_1_72(MethodBind0, GodotObject.GetPtr(this), (int)blendShape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendShape, 2352588791ul);

    /// <summary>
    /// <para>Sets a face blend shape weight.</para>
    /// </summary>
    public void SetBlendShape(XRFaceTracker.BlendShapeEntry blendShape, float weight)
    {
        NativeCalls.godot_icall_2_69(MethodBind1, GodotObject.GetPtr(this), (int)blendShape, weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapes, 675695659ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float[] GetBlendShapes()
    {
        return NativeCalls.godot_icall_0_368(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendShapes, 2899603908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendShapes(float[] weights)
    {
        NativeCalls.godot_icall_1_647(MethodBind3, GodotObject.GetPtr(this), weights);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendShapes(ReadOnlySpan<float> weights)
    {
        NativeCalls.godot_icall_1_647(MethodBind3, GodotObject.GetPtr(this), weights);
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
    public new class PropertyName : XRTracker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'blend_shapes' property.
        /// </summary>
        public static readonly StringName BlendShapes = "blend_shapes";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRTracker.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_blend_shape' method.
        /// </summary>
        public static readonly StringName GetBlendShape = "get_blend_shape";
        /// <summary>
        /// Cached name for the 'set_blend_shape' method.
        /// </summary>
        public static readonly StringName SetBlendShape = "set_blend_shape";
        /// <summary>
        /// Cached name for the 'get_blend_shapes' method.
        /// </summary>
        public static readonly StringName GetBlendShapes = "get_blend_shapes";
        /// <summary>
        /// Cached name for the 'set_blend_shapes' method.
        /// </summary>
        public static readonly StringName SetBlendShapes = "set_blend_shapes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRTracker.SignalName
    {
    }
}
