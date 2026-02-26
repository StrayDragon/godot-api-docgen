namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is an audio stream that can playback music interactively, combining clips and a transition table. Clips must be added first, and then the transition rules via the <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>. Additionally, this stream exports a property parameter to control the playback via <see cref="Godot.AudioStreamPlayer"/>, <see cref="Godot.AudioStreamPlayer2D"/>, or <see cref="Godot.AudioStreamPlayer3D"/>.</para>
/// <para>The way this is used is by filling a number of clips, then configuring the transition table. From there, clips are selected for playback and the music will smoothly go from the current to the new one while using the corresponding transition rule defined in the transition table.</para>
/// </summary>
public partial class AudioStreamInteractive : AudioStream
{
    /// <summary>
    /// <para>This constant describes that any clip is valid for a specific transition as either source or destination.</para>
    /// </summary>
    public const long ClipAny = -1;

    public enum TransitionFromTime : long
    {
        /// <summary>
        /// <para>Start transition as soon as possible, don't wait for any specific time position.</para>
        /// </summary>
        Immediate = 0,
        /// <summary>
        /// <para>Transition when the clip playback position reaches the next beat.</para>
        /// </summary>
        NextBeat = 1,
        /// <summary>
        /// <para>Transition when the clip playback position reaches the next bar.</para>
        /// </summary>
        NextBar = 2,
        /// <summary>
        /// <para>Transition when the current clip finished playing.</para>
        /// </summary>
        End = 3
    }

    public enum TransitionToTime : long
    {
        /// <summary>
        /// <para>Transition to the same position in the destination clip. This is useful when both clips have exactly the same length and the music should fade between them.</para>
        /// </summary>
        SamePosition = 0,
        /// <summary>
        /// <para>Transition to the start of the destination clip.</para>
        /// </summary>
        Start = 1
    }

    public enum FadeMode : long
    {
        /// <summary>
        /// <para>Do not use fade for the transition. This is useful when transitioning from a clip-end to clip-beginning, and each clip has their begin/end.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Use a fade-in in the next clip, let the current clip finish.</para>
        /// </summary>
        In = 1,
        /// <summary>
        /// <para>Use a fade-out in the current clip, the next clip will start by itself.</para>
        /// </summary>
        Out = 2,
        /// <summary>
        /// <para>Use a cross-fade between clips.</para>
        /// </summary>
        Cross = 3,
        /// <summary>
        /// <para>Use automatic fade logic depending on the transition from/to. It is recommended to use this by default.</para>
        /// </summary>
        Automatic = 4
    }

    public enum AutoAdvanceMode : long
    {
        /// <summary>
        /// <para>Disable auto-advance (default).</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Enable auto-advance, a clip must be specified.</para>
        /// </summary>
        Enabled = 1,
        /// <summary>
        /// <para>Enable auto-advance, but instead of specifying a clip, the playback will return to hold (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
        /// </summary>
        ReturnToHold = 2
    }

    /// <summary>
    /// <para>Amount of clips contained in this interactive player.</para>
    /// </summary>
    public int ClipCount
    {
        get
        {
            return GetClipCount();
        }
        set
        {
            SetClipCount(value);
        }
    }

    /// <summary>
    /// <para>Index of the initial clip, which will be played first when this stream is played.</para>
    /// </summary>
    public int InitialClip
    {
        get
        {
            return GetInitialClip();
        }
        set
        {
            SetInitialClip(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary _Transitions
    {
        get
        {
            return _GetTransitions();
        }
        set
        {
            _SetTransitions(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(AudioStreamInteractive);

    private static readonly StringName NativeName = "AudioStreamInteractive";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamInteractive() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamInteractive(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamInteractive(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClipCount(int clipCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), clipCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetClipCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInitialClip, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInitialClip(int clipIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), clipIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInitialClip, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInitialClip()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipName, 3780747571ul);

    /// <summary>
    /// <para>Set the name of the current clip (for easier identification).</para>
    /// </summary>
    public void SetClipName(int clipIndex, StringName name)
    {
        NativeCalls.godot_icall_2_178(MethodBind4, GodotObject.GetPtr(this), clipIndex, (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipName, 659327637ul);

    /// <summary>
    /// <para>Return the name of a clip.</para>
    /// </summary>
    public StringName GetClipName(int clipIndex)
    {
        return NativeCalls.godot_icall_1_162(MethodBind5, GodotObject.GetPtr(this), clipIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipStream, 111075094ul);

    /// <summary>
    /// <para>Set the <see cref="Godot.AudioStream"/> associated with the current clip.</para>
    /// </summary>
    public void SetClipStream(int clipIndex, AudioStream stream)
    {
        NativeCalls.godot_icall_2_70(MethodBind6, GodotObject.GetPtr(this), clipIndex, GodotObject.GetPtr(stream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipStream, 2739380747ul);

    /// <summary>
    /// <para>Return the <see cref="Godot.AudioStream"/> associated with a clip.</para>
    /// </summary>
    public AudioStream GetClipStream(int clipIndex)
    {
        return (AudioStream)NativeCalls.godot_icall_1_71(MethodBind7, GodotObject.GetPtr(this), clipIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipAutoAdvance, 57217598ul);

    /// <summary>
    /// <para>Set whether a clip will auto-advance by changing the auto-advance mode.</para>
    /// </summary>
    public void SetClipAutoAdvance(int clipIndex, AudioStreamInteractive.AutoAdvanceMode mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind8, GodotObject.GetPtr(this), clipIndex, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipAutoAdvance, 1778634807ul);

    /// <summary>
    /// <para>Return whether a clip has auto-advance enabled. See <see cref="Godot.AudioStreamInteractive.SetClipAutoAdvance(int, AudioStreamInteractive.AutoAdvanceMode)"/>.</para>
    /// </summary>
    public AudioStreamInteractive.AutoAdvanceMode GetClipAutoAdvance(int clipIndex)
    {
        return (AudioStreamInteractive.AutoAdvanceMode)NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), clipIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipAutoAdvanceNextClip, 3937882851ul);

    /// <summary>
    /// <para>Set the index of the next clip towards which this clip will auto advance to when finished. If the clip being played loops, then auto-advance will be ignored.</para>
    /// </summary>
    public void SetClipAutoAdvanceNextClip(int clipIndex, int autoAdvanceNextClip)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), clipIndex, autoAdvanceNextClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipAutoAdvanceNextClip, 923996154ul);

    /// <summary>
    /// <para>Return the clip towards which the clip referenced by <paramref name="clipIndex"/> will auto-advance to.</para>
    /// </summary>
    public int GetClipAutoAdvanceNextClip(int clipIndex)
    {
        return NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), clipIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTransition, 1630280552ul);

    /// <summary>
    /// <para>Add a transition between two clips. Provide the indices of the source and destination clips, or use the <see cref="Godot.AudioStreamInteractive.ClipAny"/> constant to indicate that transition happens to/from any clip to this one.</para>
    /// <para>* <paramref name="fromTime"/> indicates the moment in the current clip the transition will begin after triggered.</para>
    /// <para>* <paramref name="toTime"/> indicates the time in the next clip that the playback will start from.</para>
    /// <para>* <paramref name="fadeMode"/> indicates how the fade will happen between clips. If unsure, just use <see cref="Godot.AudioStreamInteractive.FadeMode.Automatic"/> which uses the most common type of fade for each situation.</para>
    /// <para>* <paramref name="fadeBeats"/> indicates how many beats the fade will take. Using decimals is allowed.</para>
    /// <para>* <paramref name="useFillerClip"/> indicates that there will be a filler clip used between the source and destination clips.</para>
    /// <para>* <paramref name="fillerClip"/> the index of the filler clip.</para>
    /// <para>* If <paramref name="holdPrevious"/> is used, then this clip will be remembered. This can be used together with <see cref="Godot.AudioStreamInteractive.AutoAdvanceMode.ReturnToHold"/> to return to this clip after another is done playing.</para>
    /// </summary>
    public void AddTransition(int fromClip, int toClip, AudioStreamInteractive.TransitionFromTime fromTime, AudioStreamInteractive.TransitionToTime toTime, AudioStreamInteractive.FadeMode fadeMode, float fadeBeats, bool useFillerClip = false, int fillerClip = -1, bool holdPrevious = false)
    {
        NativeCalls.godot_icall_9_201(MethodBind12, GodotObject.GetPtr(this), fromClip, toClip, (int)fromTime, (int)toTime, (int)fadeMode, fadeBeats, useFillerClip.ToGodotBool(), fillerClip, holdPrevious.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTransition, 2522259332ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a given transition exists (was added via <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public bool HasTransition(int fromClip, int toClip)
    {
        return NativeCalls.godot_icall_2_40(MethodBind13, GodotObject.GetPtr(this), fromClip, toClip).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseTransition, 3937882851ul);

    /// <summary>
    /// <para>Erase a transition by providing <paramref name="fromClip"/> and <paramref name="toClip"/> clip indices. <see cref="Godot.AudioStreamInteractive.ClipAny"/> can be used for either argument or both.</para>
    /// </summary>
    public void EraseTransition(int fromClip, int toClip)
    {
        NativeCalls.godot_icall_2_59(MethodBind14, GodotObject.GetPtr(this), fromClip, toClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionList, 1930428628ul);

    /// <summary>
    /// <para>Return the list of transitions (from, to interleaved).</para>
    /// </summary>
    public int[] GetTransitionList()
    {
        return NativeCalls.godot_icall_0_151(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionFromTime, 3453338158ul);

    /// <summary>
    /// <para>Return the source time position for a transition (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public AudioStreamInteractive.TransitionFromTime GetTransitionFromTime(int fromClip, int toClip)
    {
        return (AudioStreamInteractive.TransitionFromTime)NativeCalls.godot_icall_2_73(MethodBind16, GodotObject.GetPtr(this), fromClip, toClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionToTime, 1369651373ul);

    /// <summary>
    /// <para>Return the destination time position for a transition (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public AudioStreamInteractive.TransitionToTime GetTransitionToTime(int fromClip, int toClip)
    {
        return (AudioStreamInteractive.TransitionToTime)NativeCalls.godot_icall_2_73(MethodBind17, GodotObject.GetPtr(this), fromClip, toClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionFadeMode, 4065396087ul);

    /// <summary>
    /// <para>Return the mode for a transition (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public AudioStreamInteractive.FadeMode GetTransitionFadeMode(int fromClip, int toClip)
    {
        return (AudioStreamInteractive.FadeMode)NativeCalls.godot_icall_2_73(MethodBind18, GodotObject.GetPtr(this), fromClip, toClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionFadeBeats, 3085491603ul);

    /// <summary>
    /// <para>Return the time (in beats) for a transition (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public float GetTransitionFadeBeats(int fromClip, int toClip)
    {
        return NativeCalls.godot_icall_2_88(MethodBind19, GodotObject.GetPtr(this), fromClip, toClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTransitionUsingFillerClip, 2522259332ul);

    /// <summary>
    /// <para>Return whether a transition uses the <i>filler clip</i> functionality (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public bool IsTransitionUsingFillerClip(int fromClip, int toClip)
    {
        return NativeCalls.godot_icall_2_40(MethodBind20, GodotObject.GetPtr(this), fromClip, toClip).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionFillerClip, 3175239445ul);

    /// <summary>
    /// <para>Return the filler clip for a transition (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public int GetTransitionFillerClip(int fromClip, int toClip)
    {
        return NativeCalls.godot_icall_2_73(MethodBind21, GodotObject.GetPtr(this), fromClip, toClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTransitionHoldingPrevious, 2522259332ul);

    /// <summary>
    /// <para>Return whether a transition uses the <i>hold previous</i> functionality (see <see cref="Godot.AudioStreamInteractive.AddTransition(int, int, AudioStreamInteractive.TransitionFromTime, AudioStreamInteractive.TransitionToTime, AudioStreamInteractive.FadeMode, float, bool, int, bool)"/>).</para>
    /// </summary>
    public bool IsTransitionHoldingPrevious(int fromClip, int toClip)
    {
        return NativeCalls.godot_icall_2_40(MethodBind22, GodotObject.GetPtr(this), fromClip, toClip).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetTransitions, 4155329257ul);

    internal void _SetTransitions(Godot.Collections.Dictionary transitions)
    {
        NativeCalls.godot_icall_1_121(MethodBind23, GodotObject.GetPtr(this), (godot_dictionary)(transitions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetTransitions, 3102165223ul);

    internal Godot.Collections.Dictionary _GetTransitions()
    {
        return NativeCalls.godot_icall_0_122(MethodBind24, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioStream.PropertyName
    {
        /// <summary>
        /// Cached name for the 'clip_count' property.
        /// </summary>
        public static readonly StringName ClipCount = "clip_count";
        /// <summary>
        /// Cached name for the 'initial_clip' property.
        /// </summary>
        public static readonly StringName InitialClip = "initial_clip";
        /// <summary>
        /// Cached name for the '_transitions' property.
        /// </summary>
        public static readonly StringName _Transitions = "_transitions";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStream.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_clip_count' method.
        /// </summary>
        public static readonly StringName SetClipCount = "set_clip_count";
        /// <summary>
        /// Cached name for the 'get_clip_count' method.
        /// </summary>
        public static readonly StringName GetClipCount = "get_clip_count";
        /// <summary>
        /// Cached name for the 'set_initial_clip' method.
        /// </summary>
        public static readonly StringName SetInitialClip = "set_initial_clip";
        /// <summary>
        /// Cached name for the 'get_initial_clip' method.
        /// </summary>
        public static readonly StringName GetInitialClip = "get_initial_clip";
        /// <summary>
        /// Cached name for the 'set_clip_name' method.
        /// </summary>
        public static readonly StringName SetClipName = "set_clip_name";
        /// <summary>
        /// Cached name for the 'get_clip_name' method.
        /// </summary>
        public static readonly StringName GetClipName = "get_clip_name";
        /// <summary>
        /// Cached name for the 'set_clip_stream' method.
        /// </summary>
        public static readonly StringName SetClipStream = "set_clip_stream";
        /// <summary>
        /// Cached name for the 'get_clip_stream' method.
        /// </summary>
        public static readonly StringName GetClipStream = "get_clip_stream";
        /// <summary>
        /// Cached name for the 'set_clip_auto_advance' method.
        /// </summary>
        public static readonly StringName SetClipAutoAdvance = "set_clip_auto_advance";
        /// <summary>
        /// Cached name for the 'get_clip_auto_advance' method.
        /// </summary>
        public static readonly StringName GetClipAutoAdvance = "get_clip_auto_advance";
        /// <summary>
        /// Cached name for the 'set_clip_auto_advance_next_clip' method.
        /// </summary>
        public static readonly StringName SetClipAutoAdvanceNextClip = "set_clip_auto_advance_next_clip";
        /// <summary>
        /// Cached name for the 'get_clip_auto_advance_next_clip' method.
        /// </summary>
        public static readonly StringName GetClipAutoAdvanceNextClip = "get_clip_auto_advance_next_clip";
        /// <summary>
        /// Cached name for the 'add_transition' method.
        /// </summary>
        public static readonly StringName AddTransition = "add_transition";
        /// <summary>
        /// Cached name for the 'has_transition' method.
        /// </summary>
        public static readonly StringName HasTransition = "has_transition";
        /// <summary>
        /// Cached name for the 'erase_transition' method.
        /// </summary>
        public static readonly StringName EraseTransition = "erase_transition";
        /// <summary>
        /// Cached name for the 'get_transition_list' method.
        /// </summary>
        public static readonly StringName GetTransitionList = "get_transition_list";
        /// <summary>
        /// Cached name for the 'get_transition_from_time' method.
        /// </summary>
        public static readonly StringName GetTransitionFromTime = "get_transition_from_time";
        /// <summary>
        /// Cached name for the 'get_transition_to_time' method.
        /// </summary>
        public static readonly StringName GetTransitionToTime = "get_transition_to_time";
        /// <summary>
        /// Cached name for the 'get_transition_fade_mode' method.
        /// </summary>
        public static readonly StringName GetTransitionFadeMode = "get_transition_fade_mode";
        /// <summary>
        /// Cached name for the 'get_transition_fade_beats' method.
        /// </summary>
        public static readonly StringName GetTransitionFadeBeats = "get_transition_fade_beats";
        /// <summary>
        /// Cached name for the 'is_transition_using_filler_clip' method.
        /// </summary>
        public static readonly StringName IsTransitionUsingFillerClip = "is_transition_using_filler_clip";
        /// <summary>
        /// Cached name for the 'get_transition_filler_clip' method.
        /// </summary>
        public static readonly StringName GetTransitionFillerClip = "get_transition_filler_clip";
        /// <summary>
        /// Cached name for the 'is_transition_holding_previous' method.
        /// </summary>
        public static readonly StringName IsTransitionHoldingPrevious = "is_transition_holding_previous";
        /// <summary>
        /// Cached name for the '_set_transitions' method.
        /// </summary>
        public static readonly StringName _SetTransitions = "_set_transitions";
        /// <summary>
        /// Cached name for the '_get_transitions' method.
        /// </summary>
        public static readonly StringName _GetTransitions = "_get_transitions";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
