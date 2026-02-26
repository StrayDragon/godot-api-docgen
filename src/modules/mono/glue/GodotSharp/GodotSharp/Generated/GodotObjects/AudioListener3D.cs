namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Once added to the scene tree and enabled using <see cref="Godot.AudioListener3D.MakeCurrent()"/>, this node will override the location sounds are heard from. This can be used to listen from a location different from the <see cref="Godot.Camera3D"/>.</para>
/// </summary>
public partial class AudioListener3D : Node3D
{
    public enum DopplerTrackingEnum : long
    {
        /// <summary>
        /// <para>Disables <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> simulation (default).</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Simulate <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> by tracking positions of objects that are changed in <c>_process</c>. Changes in the relative velocity of this listener compared to those objects affect how audio is perceived (changing the audio's <see cref="Godot.AudioStreamPlayer3D.PitchScale"/>).</para>
        /// </summary>
        IdleStep = 1,
        /// <summary>
        /// <para>Simulate <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> by tracking positions of objects that are changed in <c>_physics_process</c>. Changes in the relative velocity of this listener compared to those objects affect how audio is perceived (changing the audio's <see cref="Godot.AudioStreamPlayer3D.PitchScale"/>).</para>
        /// </summary>
        PhysicsStep = 2
    }

    /// <summary>
    /// <para>If not <see cref="Godot.AudioListener3D.DopplerTrackingEnum.Disabled"/>, this listener will simulate the <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> for objects changed in particular <c>_process</c> methods.</para>
    /// <para><b>Note:</b> The Doppler effect will only be heard on <see cref="Godot.AudioStreamPlayer3D"/>s if <see cref="Godot.AudioStreamPlayer3D.DopplerTracking"/> is not set to <see cref="Godot.AudioStreamPlayer3D.DopplerTrackingEnum.Disabled"/>.</para>
    /// </summary>
    public AudioListener3D.DopplerTrackingEnum DopplerTracking
    {
        get
        {
            return GetDopplerTracking();
        }
        set
        {
            SetDopplerTracking(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioListener3D);

    private static readonly StringName NativeName = "AudioListener3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioListener3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AudioListener3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AudioListener3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeCurrent, 3218959716ul);

    /// <summary>
    /// <para>Enables the listener. This will override the current camera's listener.</para>
    /// </summary>
    public void MakeCurrent()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCurrent, 3218959716ul);

    /// <summary>
    /// <para>Disables the listener to use the current camera's listener instead.</para>
    /// </summary>
    public void ClearCurrent()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCurrent, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the listener was made current using <see cref="Godot.AudioListener3D.MakeCurrent()"/>, <see langword="false"/> otherwise.</para>
    /// <para><b>Note:</b> There may be more than one AudioListener3D marked as "current" in the scene tree, but only the one that was made current last will be used.</para>
    /// </summary>
    public bool IsCurrent()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetListenerTransform, 3229777777ul);

    /// <summary>
    /// <para>Returns the listener's global orthonormalized <see cref="Godot.Transform3D"/>.</para>
    /// </summary>
    public Transform3D GetListenerTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDopplerTracking, 2365921740ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDopplerTracking(AudioListener3D.DopplerTrackingEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDopplerTracking, 550229039ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioListener3D.DopplerTrackingEnum GetDopplerTracking()
    {
        return (AudioListener3D.DopplerTrackingEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'doppler_tracking' property.
        /// </summary>
        public static readonly StringName DopplerTracking = "doppler_tracking";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'make_current' method.
        /// </summary>
        public static readonly StringName MakeCurrent = "make_current";
        /// <summary>
        /// Cached name for the 'clear_current' method.
        /// </summary>
        public static readonly StringName ClearCurrent = "clear_current";
        /// <summary>
        /// Cached name for the 'is_current' method.
        /// </summary>
        public static readonly StringName IsCurrent = "is_current";
        /// <summary>
        /// Cached name for the 'get_listener_transform' method.
        /// </summary>
        public static readonly StringName GetListenerTransform = "get_listener_transform";
        /// <summary>
        /// Cached name for the 'set_doppler_tracking' method.
        /// </summary>
        public static readonly StringName SetDopplerTracking = "set_doppler_tracking";
        /// <summary>
        /// Cached name for the 'get_doppler_tracking' method.
        /// </summary>
        public static readonly StringName GetDopplerTracking = "get_doppler_tracking";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
