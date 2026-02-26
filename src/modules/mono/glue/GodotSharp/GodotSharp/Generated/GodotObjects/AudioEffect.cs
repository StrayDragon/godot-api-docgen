namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The base <see cref="Godot.Resource"/> for every audio effect. In the editor, an audio effect can be added to the current bus layout through the Audio panel. At run-time, it is also possible to manipulate audio effects through <see cref="Godot.AudioServer.AddBusEffect(int, AudioEffect, int)"/>, <see cref="Godot.AudioServer.RemoveBusEffect(int, int)"/>, and <see cref="Godot.AudioServer.GetBusEffect(int, int)"/>.</para>
/// <para>When applied on a bus, an audio effect creates a corresponding <see cref="Godot.AudioEffectInstance"/>. The instance is directly responsible for manipulating the sound, based on the original audio effect's properties.</para>
/// </summary>
public partial class AudioEffect : Resource
{
    private static readonly System.Type CachedType = typeof(AudioEffect);

    private static readonly StringName NativeName = "AudioEffect";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffect() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffect(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffect(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to customize the <see cref="Godot.AudioEffectInstance"/> created when this effect is applied on a bus in the editor's Audio panel, or through <see cref="Godot.AudioServer.AddBusEffect(int, AudioEffect, int)"/>.</para>
    /// <para><code>
    /// extends AudioEffect
    /// 
    /// @export var strength = 4.0
    /// 
    /// func _instantiate():
    /// 	var effect = CustomAudioEffectInstance.new()
    /// 	effect.base = self
    /// 
    /// 	return effect
    /// </code></para>
    /// <para><b>Note:</b> It is recommended to keep a reference to the original <see cref="Godot.AudioEffect"/> in the new instance. Depending on the implementation this allows the effect instance to listen for changes at run-time and be modified accordingly.</para>
    /// </summary>
    public virtual AudioEffectInstance _Instantiate()
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__instantiate = "_Instantiate";

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
        if ((method == MethodProxyName__instantiate || method == MethodName._Instantiate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__instantiate.NativeValue))
        {
            var callRet = _Instantiate();
            ret = VariantUtils.CreateFrom<AudioEffectInstance>(callRet);
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
        if (method == MethodName._Instantiate)
        {
            if (HasGodotClassMethod(MethodProxyName__instantiate.NativeValue.DangerousSelfRef))
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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_instantiate' method.
        /// </summary>
        public static readonly StringName _Instantiate = "_instantiate";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
