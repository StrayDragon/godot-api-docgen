namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for <see cref="Godot.AnimationPlayer"/> and <see cref="Godot.AnimationTree"/> to manage animation lists. It also has general properties and methods for playback and blending.</para>
/// <para>After instantiating the playback information data within the extended class, the blending is processed by the <see cref="Godot.AnimationMixer"/>.</para>
/// </summary>
public partial class AnimationMixer : Node
{
    public enum AnimationCallbackModeProcess : long
    {
        /// <summary>
        /// <para>Process animation during physics frames (see <see cref="Godot.Node.NotificationInternalPhysicsProcess"/>). This is especially useful when animating physics bodies.</para>
        /// </summary>
        Physics = 0,
        /// <summary>
        /// <para>Process animation during process frames (see <see cref="Godot.Node.NotificationInternalProcess"/>).</para>
        /// </summary>
        Idle = 1,
        /// <summary>
        /// <para>Do not process animation. Use <see cref="Godot.AnimationMixer.Advance(double)"/> to process the animation manually.</para>
        /// </summary>
        Manual = 2
    }

    public enum AnimationCallbackModeMethod : long
    {
        /// <summary>
        /// <para>Batch method calls during the animation process, then do the calls after events are processed. This avoids bugs involving deleting nodes or modifying the AnimationPlayer while playing.</para>
        /// </summary>
        Deferred = 0,
        /// <summary>
        /// <para>Make method calls immediately when reached in the animation.</para>
        /// </summary>
        Immediate = 1
    }

    public enum AnimationCallbackModeDiscrete : long
    {
        /// <summary>
        /// <para>An <see cref="Godot.Animation.UpdateMode.Discrete"/> track value takes precedence when blending <see cref="Godot.Animation.UpdateMode.Continuous"/> or <see cref="Godot.Animation.UpdateMode.Capture"/> track values and <see cref="Godot.Animation.UpdateMode.Discrete"/> track values.</para>
        /// </summary>
        Dominant = 0,
        /// <summary>
        /// <para>An <see cref="Godot.Animation.UpdateMode.Continuous"/> or <see cref="Godot.Animation.UpdateMode.Capture"/> track value takes precedence when blending the <see cref="Godot.Animation.UpdateMode.Continuous"/> or <see cref="Godot.Animation.UpdateMode.Capture"/> track values and the <see cref="Godot.Animation.UpdateMode.Discrete"/> track values. This is the default behavior for <see cref="Godot.AnimationPlayer"/>.</para>
        /// </summary>
        Recessive = 1,
        /// <summary>
        /// <para>Always treat the <see cref="Godot.Animation.UpdateMode.Discrete"/> track value as <see cref="Godot.Animation.UpdateMode.Continuous"/> with <see cref="Godot.Animation.InterpolationType.Nearest"/>. This is the default behavior for <see cref="Godot.AnimationTree"/>.</para>
        /// <para>If a value track has un-interpolatable type key values, it is internally converted to use <see cref="Godot.AnimationMixer.AnimationCallbackModeDiscrete.Recessive"/> with <see cref="Godot.Animation.UpdateMode.Discrete"/>.</para>
        /// <para>Un-interpolatable type list:</para>
        /// <para>- <see cref="Godot.Variant.Type.Nil"/></para>
        /// <para>- <see cref="Godot.Variant.Type.NodePath"/></para>
        /// <para>- <see cref="Godot.Variant.Type.Rid"/></para>
        /// <para>- <see cref="Godot.Variant.Type.Object"/></para>
        /// <para>- <see cref="Godot.Variant.Type.Callable"/></para>
        /// <para>- <see cref="Godot.Variant.Type.Signal"/></para>
        /// <para>- <see cref="Godot.Variant.Type.Dictionary"/></para>
        /// <para>- <see cref="Godot.Variant.Type.PackedByteArray"/></para>
        /// <para><see cref="Godot.Variant.Type.Bool"/> and <see cref="Godot.Variant.Type.Int"/> are treated as <see cref="Godot.Variant.Type.Float"/> during blending and rounded when the result is retrieved.</para>
        /// <para>It is same for arrays and vectors with them such as <see cref="Godot.Variant.Type.PackedInt32Array"/> or <see cref="Godot.Variant.Type.Vector2I"/>, they are treated as <see cref="Godot.Variant.Type.PackedFloat32Array"/> or <see cref="Godot.Variant.Type.Vector2"/>. Also note that for arrays, the size is also interpolated.</para>
        /// <para><see cref="Godot.Variant.Type.String"/> and <see cref="Godot.Variant.Type.StringName"/> are interpolated between character codes and lengths, but note that there is a difference in algorithm between interpolation between keys and interpolation by blending.</para>
        /// </summary>
        ForceContinuous = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.AnimationMixer"/> will be processing.</para>
    /// </summary>
    public bool Active
    {
        get
        {
            return IsActive();
        }
        set
        {
            SetActive(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the blending uses the deterministic algorithm. The total weight is not normalized and the result is accumulated with an initial value (<c>0</c> or a <c>"RESET"</c> animation if present).</para>
    /// <para>This means that if the total amount of blending is <c>0.0</c>, the result is equal to the <c>"RESET"</c> animation.</para>
    /// <para>If the number of tracks between the blended animations is different, the animation with the missing track is treated as if it had the initial value.</para>
    /// <para>If <see langword="false"/>, The blend does not use the deterministic algorithm. The total weight is normalized and always <c>1.0</c>. If the number of tracks between the blended animations is different, nothing is done about the animation that is missing a track.</para>
    /// <para><b>Note:</b> In <see cref="Godot.AnimationTree"/>, the blending with <see cref="Godot.AnimationNodeAdd2"/>, <see cref="Godot.AnimationNodeAdd3"/>, <see cref="Godot.AnimationNodeSub2"/> or the weight greater than <c>1.0</c> may produce unexpected results.</para>
    /// <para>For example, if <see cref="Godot.AnimationNodeAdd2"/> blends two nodes with the amount <c>1.0</c>, then total weight is <c>2.0</c> but it will be normalized to make the total amount <c>1.0</c> and the result will be equal to <see cref="Godot.AnimationNodeBlend2"/> with the amount <c>0.5</c>.</para>
    /// </summary>
    public bool Deterministic
    {
        get
        {
            return IsDeterministic();
        }
        set
        {
            SetDeterministic(value);
        }
    }

    /// <summary>
    /// <para>This is used by the editor. If set to <see langword="true"/>, the scene will be saved with the effects of the reset animation (the animation with the key <c>"RESET"</c>) applied as if it had been seeked to time 0, with the editor keeping the values that the scene had before saving.</para>
    /// <para>This makes it more convenient to preview and edit animations in the editor, as changes to the scene will not be saved as long as they are set in the reset animation.</para>
    /// </summary>
    public bool ResetOnSave
    {
        get
        {
            return IsResetOnSaveEnabled();
        }
        set
        {
            SetResetOnSaveEnabled(value);
        }
    }

    /// <summary>
    /// <para>The node which node path references will travel from.</para>
    /// </summary>
    public NodePath RootNode
    {
        get
        {
            return GetRootNode();
        }
        set
        {
            SetRootNode(value);
        }
    }

    /// <summary>
    /// <para>The path to the Animation track used for root motion. Paths must be valid scene-tree paths to a node, and must be specified starting from the parent node of the node that will reproduce the animation. The <see cref="Godot.AnimationMixer.RootMotionTrack"/> uses the same format as <see cref="Godot.Animation.TrackSetPath(int, NodePath)"/>, but note that a bone must be specified.</para>
    /// <para>If the track has type <see cref="Godot.Animation.TrackType.Position3D"/>, <see cref="Godot.Animation.TrackType.Rotation3D"/>, or <see cref="Godot.Animation.TrackType.Scale3D"/> the transformation will be canceled visually, and the animation will appear to stay in place. See also <see cref="Godot.AnimationMixer.GetRootMotionPosition()"/>, <see cref="Godot.AnimationMixer.GetRootMotionRotation()"/>, <see cref="Godot.AnimationMixer.GetRootMotionScale()"/>, and <see cref="Godot.RootMotionView"/>.</para>
    /// </summary>
    public NodePath RootMotionTrack
    {
        get
        {
            return GetRootMotionTrack();
        }
        set
        {
            SetRootMotionTrack(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.AnimationMixer.GetRootMotionPosition()"/> value is extracted as a local translation value before blending. In other words, it is treated like the translation is done after the rotation.</para>
    /// </summary>
    public bool RootMotionLocal
    {
        get
        {
            return IsRootMotionLocal();
        }
        set
        {
            SetRootMotionLocal(value);
        }
    }

    /// <summary>
    /// <para>The number of possible simultaneous sounds for each of the assigned AudioStreamPlayers.</para>
    /// <para>For example, if this value is <c>32</c> and the animation has two audio tracks, the two <see cref="Godot.AudioStreamPlayer"/>s assigned can play simultaneously up to <c>32</c> voices each.</para>
    /// </summary>
    public int AudioMaxPolyphony
    {
        get
        {
            return GetAudioMaxPolyphony();
        }
        set
        {
            SetAudioMaxPolyphony(value);
        }
    }

    /// <summary>
    /// <para>The process notification in which to update animations.</para>
    /// </summary>
    public AnimationMixer.AnimationCallbackModeProcess CallbackModeProcess
    {
        get
        {
            return GetCallbackModeProcess();
        }
        set
        {
            SetCallbackModeProcess(value);
        }
    }

    /// <summary>
    /// <para>The call mode used for "Call Method" tracks.</para>
    /// </summary>
    public AnimationMixer.AnimationCallbackModeMethod CallbackModeMethod
    {
        get
        {
            return GetCallbackModeMethod();
        }
        set
        {
            SetCallbackModeMethod(value);
        }
    }

    /// <summary>
    /// <para>Ordinarily, tracks can be set to <see cref="Godot.Animation.UpdateMode.Discrete"/> to update infrequently, usually when using nearest interpolation.</para>
    /// <para>However, when blending with <see cref="Godot.Animation.UpdateMode.Continuous"/> several results are considered. The <see cref="Godot.AnimationMixer.CallbackModeDiscrete"/> specify it explicitly. See also <see cref="Godot.AnimationMixer.AnimationCallbackModeDiscrete"/>.</para>
    /// <para>To make the blended results look good, it is recommended to set this to <see cref="Godot.AnimationMixer.AnimationCallbackModeDiscrete.ForceContinuous"/> to update every frame during blending. Other values exist for compatibility and they are fine if there is no blending, but not so, may produce artifacts.</para>
    /// </summary>
    public AnimationMixer.AnimationCallbackModeDiscrete CallbackModeDiscrete
    {
        get
        {
            return GetCallbackModeDiscrete();
        }
        set
        {
            SetCallbackModeDiscrete(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationMixer);

    private static readonly StringName NativeName = "AnimationMixer";

    internal AnimationMixer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimationMixer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimationMixer(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>A virtual function for processing after getting a key during playback.</para>
    /// </summary>
    public virtual Variant _PostProcessKeyValue(Animation animation, int track, Variant value, ulong objectId, int objectSubIdx)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAnimationLibrary, 618909818ul);

    /// <summary>
    /// <para>Adds <paramref name="library"/> to the animation player, under the key <paramref name="name"/>.</para>
    /// <para>AnimationMixer has a global library by default with an empty string as key. For adding an animation to the global library:</para>
    /// <para></para>
    /// </summary>
    public Error AddAnimationLibrary(StringName name, AnimationLibrary library)
    {
        return (Error)NativeCalls.godot_icall_2_117(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(library));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAnimationLibrary, 3304788590ul);

    /// <summary>
    /// <para>Removes the <see cref="Godot.AnimationLibrary"/> associated with the key <paramref name="name"/>.</para>
    /// </summary>
    public void RemoveAnimationLibrary(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenameAnimationLibrary, 3740211285ul);

    /// <summary>
    /// <para>Moves the <see cref="Godot.AnimationLibrary"/> associated with the key <paramref name="name"/> to the key <paramref name="newname"/>.</para>
    /// </summary>
    public void RenameAnimationLibrary(StringName name, StringName newname)
    {
        NativeCalls.godot_icall_2_118(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(newname?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAnimationLibrary, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.AnimationMixer"/> stores an <see cref="Godot.AnimationLibrary"/> with key <paramref name="name"/>.</para>
    /// </summary>
    public bool HasAnimationLibrary(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationLibrary, 147342321ul);

    /// <summary>
    /// <para>Returns the first <see cref="Godot.AnimationLibrary"/> with key <paramref name="name"/> or <see langword="null"/> if not found.</para>
    /// <para>To get the <see cref="Godot.AnimationMixer"/>'s global animation library, use <c>get_animation_library("")</c>.</para>
    /// </summary>
    public AnimationLibrary GetAnimationLibrary(StringName name)
    {
        return (AnimationLibrary)NativeCalls.godot_icall_1_119(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationLibraryList, 3995934104ul);

    /// <summary>
    /// <para>Returns the list of stored library keys.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetAnimationLibraryList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAnimation, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.AnimationMixer"/> stores an <see cref="Godot.Animation"/> with key <paramref name="name"/>.</para>
    /// </summary>
    public bool HasAnimation(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimation, 2933122410ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Animation"/> with the key <paramref name="name"/>. If the animation does not exist, <see langword="null"/> is returned and an error is logged.</para>
    /// </summary>
    public Animation GetAnimation(StringName name)
    {
        return (Animation)NativeCalls.godot_icall_1_119(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationList, 1139954409ul);

    /// <summary>
    /// <para>Returns the list of stored animation keys.</para>
    /// </summary>
    public string[] GetAnimationList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActive, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActive, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeterministic, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeterministic(bool deterministic)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), deterministic.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDeterministic, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDeterministic()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootNode(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind13, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetRootNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCallbackModeProcess, 2153733086ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCallbackModeProcess(AnimationMixer.AnimationCallbackModeProcess mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCallbackModeProcess, 1394468472ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationMixer.AnimationCallbackModeProcess GetCallbackModeProcess()
    {
        return (AnimationMixer.AnimationCallbackModeProcess)NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCallbackModeMethod, 742218271ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCallbackModeMethod(AnimationMixer.AnimationCallbackModeMethod mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCallbackModeMethod, 489449656ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationMixer.AnimationCallbackModeMethod GetCallbackModeMethod()
    {
        return (AnimationMixer.AnimationCallbackModeMethod)NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCallbackModeDiscrete, 1998944670ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCallbackModeDiscrete(AnimationMixer.AnimationCallbackModeDiscrete mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCallbackModeDiscrete, 3493168860ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationMixer.AnimationCallbackModeDiscrete GetCallbackModeDiscrete()
    {
        return (AnimationMixer.AnimationCallbackModeDiscrete)NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAudioMaxPolyphony, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAudioMaxPolyphony(int maxPolyphony)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), maxPolyphony);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAudioMaxPolyphony, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetAudioMaxPolyphony()
    {
        return NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootMotionTrack, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootMotionTrack(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind23, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootMotionTrack, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetRootMotionTrack()
    {
        return NativeCalls.godot_icall_0_124(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootMotionLocal, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootMotionLocal(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind25, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRootMotionLocal, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRootMotionLocal()
    {
        return NativeCalls.godot_icall_0_15(MethodBind26, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootMotionPosition, 3360562783ul);

    /// <summary>
    /// <para>Retrieve the motion delta of position with the <see cref="Godot.AnimationMixer.RootMotionTrack"/> as a <see cref="Godot.Vector3"/> that can be used elsewhere.</para>
    /// <para>If <see cref="Godot.AnimationMixer.RootMotionTrack"/> is not a path to a track of type <see cref="Godot.Animation.TrackType.Position3D"/>, returns <c>Vector3(0, 0, 0)</c>.</para>
    /// <para>See also <see cref="Godot.AnimationMixer.RootMotionTrack"/> and <see cref="Godot.RootMotionView"/>.</para>
    /// <para>The most basic example is applying position to <see cref="Godot.CharacterBody3D"/>:</para>
    /// <para></para>
    /// <para>By using this in combination with <see cref="Godot.AnimationMixer.GetRootMotionRotationAccumulator()"/>, you can apply the root motion position more correctly to account for the rotation of the node.</para>
    /// <para></para>
    /// <para>If <see cref="Godot.AnimationMixer.RootMotionLocal"/> is <see langword="true"/>, returns the pre-multiplied translation value with the inverted rotation.</para>
    /// <para>In this case, the code can be written as follows:</para>
    /// <para></para>
    /// </summary>
    public Vector3 GetRootMotionPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootMotionRotation, 1222331677ul);

    /// <summary>
    /// <para>Retrieve the motion delta of rotation with the <see cref="Godot.AnimationMixer.RootMotionTrack"/> as a <see cref="Godot.Quaternion"/> that can be used elsewhere.</para>
    /// <para>If <see cref="Godot.AnimationMixer.RootMotionTrack"/> is not a path to a track of type <see cref="Godot.Animation.TrackType.Rotation3D"/>, returns <c>Quaternion(0, 0, 0, 1)</c>.</para>
    /// <para>See also <see cref="Godot.AnimationMixer.RootMotionTrack"/> and <see cref="Godot.RootMotionView"/>.</para>
    /// <para>The most basic example is applying rotation to <see cref="Godot.CharacterBody3D"/>:</para>
    /// <para></para>
    /// </summary>
    public Quaternion GetRootMotionRotation()
    {
        return NativeCalls.godot_icall_0_126(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootMotionScale, 3360562783ul);

    /// <summary>
    /// <para>Retrieve the motion delta of scale with the <see cref="Godot.AnimationMixer.RootMotionTrack"/> as a <see cref="Godot.Vector3"/> that can be used elsewhere.</para>
    /// <para>If <see cref="Godot.AnimationMixer.RootMotionTrack"/> is not a path to a track of type <see cref="Godot.Animation.TrackType.Scale3D"/>, returns <c>Vector3(0, 0, 0)</c>.</para>
    /// <para>See also <see cref="Godot.AnimationMixer.RootMotionTrack"/> and <see cref="Godot.RootMotionView"/>.</para>
    /// <para>The most basic example is applying scale to <see cref="Godot.CharacterBody3D"/>:</para>
    /// <para></para>
    /// </summary>
    public Vector3 GetRootMotionScale()
    {
        return NativeCalls.godot_icall_0_125(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootMotionPositionAccumulator, 3360562783ul);

    /// <summary>
    /// <para>Retrieve the blended value of the position tracks with the <see cref="Godot.AnimationMixer.RootMotionTrack"/> as a <see cref="Godot.Vector3"/> that can be used elsewhere.</para>
    /// <para>This is useful in cases where you want to respect the initial key values of the animation.</para>
    /// <para>For example, if an animation with only one key <c>Vector3(0, 0, 0)</c> is played in the previous frame and then an animation with only one key <c>Vector3(1, 0, 1)</c> is played in the next frame, the difference can be calculated as follows:</para>
    /// <para></para>
    /// <para>However, if the animation loops, an unintended discrete change may occur, so this is only useful for some simple use cases.</para>
    /// </summary>
    public Vector3 GetRootMotionPositionAccumulator()
    {
        return NativeCalls.godot_icall_0_125(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootMotionRotationAccumulator, 1222331677ul);

    /// <summary>
    /// <para>Retrieve the blended value of the rotation tracks with the <see cref="Godot.AnimationMixer.RootMotionTrack"/> as a <see cref="Godot.Quaternion"/> that can be used elsewhere.</para>
    /// <para>This is necessary to apply the root motion position correctly, taking rotation into account. See also <see cref="Godot.AnimationMixer.GetRootMotionPosition()"/>.</para>
    /// <para>Also, this is useful in cases where you want to respect the initial key values of the animation.</para>
    /// <para>For example, if an animation with only one key <c>Quaternion(0, 0, 0, 1)</c> is played in the previous frame and then an animation with only one key <c>Quaternion(0, 0.707, 0, 0.707)</c> is played in the next frame, the difference can be calculated as follows:</para>
    /// <para></para>
    /// <para>However, if the animation loops, an unintended discrete change may occur, so this is only useful for some simple use cases.</para>
    /// </summary>
    public Quaternion GetRootMotionRotationAccumulator()
    {
        return NativeCalls.godot_icall_0_126(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootMotionScaleAccumulator, 3360562783ul);

    /// <summary>
    /// <para>Retrieve the blended value of the scale tracks with the <see cref="Godot.AnimationMixer.RootMotionTrack"/> as a <see cref="Godot.Vector3"/> that can be used elsewhere.</para>
    /// <para>For example, if an animation with only one key <c>Vector3(1, 1, 1)</c> is played in the previous frame and then an animation with only one key <c>Vector3(2, 2, 2)</c> is played in the next frame, the difference can be calculated as follows:</para>
    /// <para></para>
    /// <para>However, if the animation loops, an unintended discrete change may occur, so this is only useful for some simple use cases.</para>
    /// </summary>
    public Vector3 GetRootMotionScaleAccumulator()
    {
        return NativeCalls.godot_icall_0_125(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCaches, 3218959716ul);

    /// <summary>
    /// <para><see cref="Godot.AnimationMixer"/> caches animated nodes. It may not notice if a node disappears; <see cref="Godot.AnimationMixer.ClearCaches()"/> forces it to update the cache again.</para>
    /// </summary>
    public void ClearCaches()
    {
        NativeCalls.godot_icall_0_3(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Advance, 373806689ul);

    /// <summary>
    /// <para>Manually advance the animations by the specified time (in seconds).</para>
    /// </summary>
    public void Advance(double delta)
    {
        NativeCalls.godot_icall_1_127(MethodBind34, GodotObject.GetPtr(this), delta);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Capture, 1333632127ul);

    /// <summary>
    /// <para>If the animation track specified by <paramref name="name"/> has an option <see cref="Godot.Animation.UpdateMode.Capture"/>, stores current values of the objects indicated by the track path as a cache. If there is already a captured cache, the old cache is discarded.</para>
    /// <para>After this it will interpolate with current animation blending result during the playback process for the time specified by <paramref name="duration"/>, working like a crossfade.</para>
    /// <para>You can specify <paramref name="transType"/> as the curve for the interpolation. For better results, it may be appropriate to specify <see cref="Godot.Tween.TransitionType.Linear"/> for cases where the first key of the track begins with a non-zero value or where the key value does not change, and <see cref="Godot.Tween.TransitionType.Quad"/> for cases where the key value changes linearly.</para>
    /// </summary>
    public void Capture(StringName name, double duration, Tween.TransitionType transType = (Tween.TransitionType)(0), Tween.EaseType easeType = (Tween.EaseType)(0))
    {
        NativeCalls.godot_icall_4_128(MethodBind35, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), duration, (int)transType, (int)easeType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResetOnSaveEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResetOnSaveEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind36, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsResetOnSaveEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsResetOnSaveEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind37, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindAnimation, 1559484580ul);

    /// <summary>
    /// <para>Returns the key of <paramref name="animation"/> or an empty <see cref="Godot.StringName"/> if not found.</para>
    /// </summary>
    public StringName FindAnimation(Animation animation)
    {
        return NativeCalls.godot_icall_1_129(MethodBind38, GodotObject.GetPtr(this), GodotObject.GetPtr(animation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindAnimationLibrary, 1559484580ul);

    /// <summary>
    /// <para>Returns the key for the <see cref="Godot.AnimationLibrary"/> that contains <paramref name="animation"/> or an empty <see cref="Godot.StringName"/> if not found.</para>
    /// </summary>
    public StringName FindAnimationLibrary(Animation animation)
    {
        return NativeCalls.godot_icall_1_129(MethodBind39, GodotObject.GetPtr(this), GodotObject.GetPtr(animation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName._PostProcessKeyValue, 3067767940ul);

    /// <summary>
    /// <para>A virtual function for processing after getting a key during playback.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Variant _PostProcessKeyValue(Animation animation, int track, Variant value, GodotObject @object, int objectIdx)
    {
        return NativeCalls.godot_icall_5_130(MethodBind40, GodotObject.GetPtr(this), GodotObject.GetPtr(animation), track, value, GodotObject.GetPtr(@object), objectIdx);
    }

    /// <summary>
    /// <para>Notifies when an animation list is changed.</para>
    /// </summary>
    public event Action AnimationListChanged
    {
        add => Connect(SignalName.AnimationListChanged, Callable.From(value));
        remove => Disconnect(SignalName.AnimationListChanged, Callable.From(value));
    }

    protected void EmitSignalAnimationListChanged()
    {
        EmitSignal(SignalName.AnimationListChanged);
    }

    /// <summary>
    /// <para>Notifies when the animation libraries have changed.</para>
    /// </summary>
    public event Action AnimationLibrariesUpdated
    {
        add => Connect(SignalName.AnimationLibrariesUpdated, Callable.From(value));
        remove => Disconnect(SignalName.AnimationLibrariesUpdated, Callable.From(value));
    }

    protected void EmitSignalAnimationLibrariesUpdated()
    {
        EmitSignal(SignalName.AnimationLibrariesUpdated);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationMixer.AnimationFinished"/> event of a <see cref="Godot.AnimationMixer"/> class.
    /// </summary>
    public delegate void AnimationFinishedEventHandler(StringName animName);

    private static void AnimationFinishedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((AnimationFinishedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Notifies when an animation finished playing.</para>
    /// <para><b>Note:</b> This signal is not emitted if an animation is looping.</para>
    /// </summary>
    public unsafe event AnimationFinishedEventHandler AnimationFinished
    {
        add => Connect(SignalName.AnimationFinished, Callable.CreateWithUnsafeTrampoline(value, &AnimationFinishedTrampoline));
        remove => Disconnect(SignalName.AnimationFinished, Callable.CreateWithUnsafeTrampoline(value, &AnimationFinishedTrampoline));
    }

    protected void EmitSignalAnimationFinished(StringName animName)
    {
        EmitSignal(SignalName.AnimationFinished, animName);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationMixer.AnimationStarted"/> event of a <see cref="Godot.AnimationMixer"/> class.
    /// </summary>
    public delegate void AnimationStartedEventHandler(StringName animName);

    private static void AnimationStartedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((AnimationStartedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Notifies when an animation starts playing.</para>
    /// <para><b>Note:</b> This signal is not emitted if an animation is looping.</para>
    /// </summary>
    public unsafe event AnimationStartedEventHandler AnimationStarted
    {
        add => Connect(SignalName.AnimationStarted, Callable.CreateWithUnsafeTrampoline(value, &AnimationStartedTrampoline));
        remove => Disconnect(SignalName.AnimationStarted, Callable.CreateWithUnsafeTrampoline(value, &AnimationStartedTrampoline));
    }

    protected void EmitSignalAnimationStarted(StringName animName)
    {
        EmitSignal(SignalName.AnimationStarted, animName);
    }

    /// <summary>
    /// <para>Notifies when the caches have been cleared, either automatically, or manually via <see cref="Godot.AnimationMixer.ClearCaches()"/>.</para>
    /// </summary>
    public event Action CachesCleared
    {
        add => Connect(SignalName.CachesCleared, Callable.From(value));
        remove => Disconnect(SignalName.CachesCleared, Callable.From(value));
    }

    protected void EmitSignalCachesCleared()
    {
        EmitSignal(SignalName.CachesCleared);
    }

    /// <summary>
    /// <para>Notifies when the blending result related have been applied to the target objects.</para>
    /// </summary>
    public event Action MixerApplied
    {
        add => Connect(SignalName.MixerApplied, Callable.From(value));
        remove => Disconnect(SignalName.MixerApplied, Callable.From(value));
    }

    protected void EmitSignalMixerApplied()
    {
        EmitSignal(SignalName.MixerApplied);
    }

    /// <summary>
    /// <para>Notifies when the property related process have been updated.</para>
    /// </summary>
    public event Action MixerUpdated
    {
        add => Connect(SignalName.MixerUpdated, Callable.From(value));
        remove => Disconnect(SignalName.MixerUpdated, Callable.From(value));
    }

    protected void EmitSignalMixerUpdated()
    {
        EmitSignal(SignalName.MixerUpdated);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__post_process_key_value = "_PostProcessKeyValue";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_list_changed = "AnimationListChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_libraries_updated = "AnimationLibrariesUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_finished = "AnimationFinished";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_started = "AnimationStarted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_caches_cleared = "CachesCleared";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mixer_applied = "MixerApplied";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mixer_updated = "MixerUpdated";

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
        if ((method == MethodProxyName__post_process_key_value || method == MethodName._PostProcessKeyValue) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__post_process_key_value.NativeValue))
        {
            var callRet = _PostProcessKeyValue(VariantUtils.ConvertTo<Animation>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]), VariantUtils.ConvertTo<ulong>(args[3]), VariantUtils.ConvertTo<int>(args[4]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
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
        if (method == MethodName._PostProcessKeyValue)
        {
            if (HasGodotClassMethod(MethodProxyName__post_process_key_value.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        if (signal == SignalName.AnimationListChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_list_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationLibrariesUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_libraries_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationFinished)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationStarted)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CachesCleared)
        {
            if (HasGodotClassSignal(SignalProxyName_caches_cleared.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MixerApplied)
        {
            if (HasGodotClassSignal(SignalProxyName_mixer_applied.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MixerUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_mixer_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'active' property.
        /// </summary>
        public static readonly StringName Active = "active";
        /// <summary>
        /// Cached name for the 'deterministic' property.
        /// </summary>
        public static readonly StringName Deterministic = "deterministic";
        /// <summary>
        /// Cached name for the 'reset_on_save' property.
        /// </summary>
        public static readonly StringName ResetOnSave = "reset_on_save";
        /// <summary>
        /// Cached name for the 'root_node' property.
        /// </summary>
        public static readonly StringName RootNode = "root_node";
        /// <summary>
        /// Cached name for the 'root_motion_track' property.
        /// </summary>
        public static readonly StringName RootMotionTrack = "root_motion_track";
        /// <summary>
        /// Cached name for the 'root_motion_local' property.
        /// </summary>
        public static readonly StringName RootMotionLocal = "root_motion_local";
        /// <summary>
        /// Cached name for the 'audio_max_polyphony' property.
        /// </summary>
        public static readonly StringName AudioMaxPolyphony = "audio_max_polyphony";
        /// <summary>
        /// Cached name for the 'callback_mode_process' property.
        /// </summary>
        public static readonly StringName CallbackModeProcess = "callback_mode_process";
        /// <summary>
        /// Cached name for the 'callback_mode_method' property.
        /// </summary>
        public static readonly StringName CallbackModeMethod = "callback_mode_method";
        /// <summary>
        /// Cached name for the 'callback_mode_discrete' property.
        /// </summary>
        public static readonly StringName CallbackModeDiscrete = "callback_mode_discrete";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the '_post_process_key_value' method.
        /// </summary>
        public static readonly StringName _PostProcessKeyValue = "_post_process_key_value";
        /// <summary>
        /// Cached name for the 'add_animation_library' method.
        /// </summary>
        public static readonly StringName AddAnimationLibrary = "add_animation_library";
        /// <summary>
        /// Cached name for the 'remove_animation_library' method.
        /// </summary>
        public static readonly StringName RemoveAnimationLibrary = "remove_animation_library";
        /// <summary>
        /// Cached name for the 'rename_animation_library' method.
        /// </summary>
        public static readonly StringName RenameAnimationLibrary = "rename_animation_library";
        /// <summary>
        /// Cached name for the 'has_animation_library' method.
        /// </summary>
        public static readonly StringName HasAnimationLibrary = "has_animation_library";
        /// <summary>
        /// Cached name for the 'get_animation_library' method.
        /// </summary>
        public static readonly StringName GetAnimationLibrary = "get_animation_library";
        /// <summary>
        /// Cached name for the 'get_animation_library_list' method.
        /// </summary>
        public static readonly StringName GetAnimationLibraryList = "get_animation_library_list";
        /// <summary>
        /// Cached name for the 'has_animation' method.
        /// </summary>
        public static readonly StringName HasAnimation = "has_animation";
        /// <summary>
        /// Cached name for the 'get_animation' method.
        /// </summary>
        public static readonly StringName GetAnimation = "get_animation";
        /// <summary>
        /// Cached name for the 'get_animation_list' method.
        /// </summary>
        public static readonly StringName GetAnimationList = "get_animation_list";
        /// <summary>
        /// Cached name for the 'set_active' method.
        /// </summary>
        public static readonly StringName SetActive = "set_active";
        /// <summary>
        /// Cached name for the 'is_active' method.
        /// </summary>
        public static readonly StringName IsActive = "is_active";
        /// <summary>
        /// Cached name for the 'set_deterministic' method.
        /// </summary>
        public static readonly StringName SetDeterministic = "set_deterministic";
        /// <summary>
        /// Cached name for the 'is_deterministic' method.
        /// </summary>
        public static readonly StringName IsDeterministic = "is_deterministic";
        /// <summary>
        /// Cached name for the 'set_root_node' method.
        /// </summary>
        public static readonly StringName SetRootNode = "set_root_node";
        /// <summary>
        /// Cached name for the 'get_root_node' method.
        /// </summary>
        public static readonly StringName GetRootNode = "get_root_node";
        /// <summary>
        /// Cached name for the 'set_callback_mode_process' method.
        /// </summary>
        public static readonly StringName SetCallbackModeProcess = "set_callback_mode_process";
        /// <summary>
        /// Cached name for the 'get_callback_mode_process' method.
        /// </summary>
        public static readonly StringName GetCallbackModeProcess = "get_callback_mode_process";
        /// <summary>
        /// Cached name for the 'set_callback_mode_method' method.
        /// </summary>
        public static readonly StringName SetCallbackModeMethod = "set_callback_mode_method";
        /// <summary>
        /// Cached name for the 'get_callback_mode_method' method.
        /// </summary>
        public static readonly StringName GetCallbackModeMethod = "get_callback_mode_method";
        /// <summary>
        /// Cached name for the 'set_callback_mode_discrete' method.
        /// </summary>
        public static readonly StringName SetCallbackModeDiscrete = "set_callback_mode_discrete";
        /// <summary>
        /// Cached name for the 'get_callback_mode_discrete' method.
        /// </summary>
        public static readonly StringName GetCallbackModeDiscrete = "get_callback_mode_discrete";
        /// <summary>
        /// Cached name for the 'set_audio_max_polyphony' method.
        /// </summary>
        public static readonly StringName SetAudioMaxPolyphony = "set_audio_max_polyphony";
        /// <summary>
        /// Cached name for the 'get_audio_max_polyphony' method.
        /// </summary>
        public static readonly StringName GetAudioMaxPolyphony = "get_audio_max_polyphony";
        /// <summary>
        /// Cached name for the 'set_root_motion_track' method.
        /// </summary>
        public static readonly StringName SetRootMotionTrack = "set_root_motion_track";
        /// <summary>
        /// Cached name for the 'get_root_motion_track' method.
        /// </summary>
        public static readonly StringName GetRootMotionTrack = "get_root_motion_track";
        /// <summary>
        /// Cached name for the 'set_root_motion_local' method.
        /// </summary>
        public static readonly StringName SetRootMotionLocal = "set_root_motion_local";
        /// <summary>
        /// Cached name for the 'is_root_motion_local' method.
        /// </summary>
        public static readonly StringName IsRootMotionLocal = "is_root_motion_local";
        /// <summary>
        /// Cached name for the 'get_root_motion_position' method.
        /// </summary>
        public static readonly StringName GetRootMotionPosition = "get_root_motion_position";
        /// <summary>
        /// Cached name for the 'get_root_motion_rotation' method.
        /// </summary>
        public static readonly StringName GetRootMotionRotation = "get_root_motion_rotation";
        /// <summary>
        /// Cached name for the 'get_root_motion_scale' method.
        /// </summary>
        public static readonly StringName GetRootMotionScale = "get_root_motion_scale";
        /// <summary>
        /// Cached name for the 'get_root_motion_position_accumulator' method.
        /// </summary>
        public static readonly StringName GetRootMotionPositionAccumulator = "get_root_motion_position_accumulator";
        /// <summary>
        /// Cached name for the 'get_root_motion_rotation_accumulator' method.
        /// </summary>
        public static readonly StringName GetRootMotionRotationAccumulator = "get_root_motion_rotation_accumulator";
        /// <summary>
        /// Cached name for the 'get_root_motion_scale_accumulator' method.
        /// </summary>
        public static readonly StringName GetRootMotionScaleAccumulator = "get_root_motion_scale_accumulator";
        /// <summary>
        /// Cached name for the 'clear_caches' method.
        /// </summary>
        public static readonly StringName ClearCaches = "clear_caches";
        /// <summary>
        /// Cached name for the 'advance' method.
        /// </summary>
        public static readonly StringName Advance = "advance";
        /// <summary>
        /// Cached name for the 'capture' method.
        /// </summary>
        public static readonly StringName Capture = "capture";
        /// <summary>
        /// Cached name for the 'set_reset_on_save_enabled' method.
        /// </summary>
        public static readonly StringName SetResetOnSaveEnabled = "set_reset_on_save_enabled";
        /// <summary>
        /// Cached name for the 'is_reset_on_save_enabled' method.
        /// </summary>
        public static readonly StringName IsResetOnSaveEnabled = "is_reset_on_save_enabled";
        /// <summary>
        /// Cached name for the 'find_animation' method.
        /// </summary>
        public static readonly StringName FindAnimation = "find_animation";
        /// <summary>
        /// Cached name for the 'find_animation_library' method.
        /// </summary>
        public static readonly StringName FindAnimationLibrary = "find_animation_library";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'animation_list_changed' signal.
        /// </summary>
        public static readonly StringName AnimationListChanged = "animation_list_changed";
        /// <summary>
        /// Cached name for the 'animation_libraries_updated' signal.
        /// </summary>
        public static readonly StringName AnimationLibrariesUpdated = "animation_libraries_updated";
        /// <summary>
        /// Cached name for the 'animation_finished' signal.
        /// </summary>
        public static readonly StringName AnimationFinished = "animation_finished";
        /// <summary>
        /// Cached name for the 'animation_started' signal.
        /// </summary>
        public static readonly StringName AnimationStarted = "animation_started";
        /// <summary>
        /// Cached name for the 'caches_cleared' signal.
        /// </summary>
        public static readonly StringName CachesCleared = "caches_cleared";
        /// <summary>
        /// Cached name for the 'mixer_applied' signal.
        /// </summary>
        public static readonly StringName MixerApplied = "mixer_applied";
        /// <summary>
        /// Cached name for the 'mixer_updated' signal.
        /// </summary>
        public static readonly StringName MixerUpdated = "mixer_updated";
    }
}
