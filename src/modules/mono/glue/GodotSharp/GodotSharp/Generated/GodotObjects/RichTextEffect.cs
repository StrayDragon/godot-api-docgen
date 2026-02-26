namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A custom effect for a <see cref="Godot.RichTextLabel"/>, which can be loaded in the <see cref="Godot.RichTextLabel"/> inspector or using <see cref="Godot.RichTextLabel.InstallEffect(Variant)"/>.</para>
/// <para><b>Note:</b> For a <see cref="Godot.RichTextEffect"/> to be usable, a BBCode tag must be defined as a member variable called <c>bbcode</c> in the script.</para>
/// <para><code>
/// // The RichTextEffect will be usable like this: `[example]Some text[/example]`
/// string bbcode = "example";
/// </code></para>
/// <para><b>Note:</b> As soon as a <see cref="Godot.RichTextLabel"/> contains at least one <see cref="Godot.RichTextEffect"/>, it will continuously process the effect unless the project is paused. This may impact battery life negatively.</para>
/// </summary>
public partial class RichTextEffect : Resource
{
    private static readonly System.Type CachedType = typeof(RichTextEffect);

    private static readonly StringName NativeName = "RichTextEffect";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RichTextEffect() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RichTextEffect(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RichTextEffect(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to modify properties in <paramref name="charFX"/>. The method must return <see langword="true"/> if the character could be transformed successfully. If the method returns <see langword="false"/>, it will skip transformation to avoid displaying broken text.</para>
    /// </summary>
    public virtual bool _ProcessCustomFX(CharFXTransform charFX)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__process_custom_fx = "_ProcessCustomFX";

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
        if ((method == MethodProxyName__process_custom_fx || method == MethodName._ProcessCustomFX) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__process_custom_fx.NativeValue))
        {
            var callRet = _ProcessCustomFX(VariantUtils.ConvertTo<CharFXTransform>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._ProcessCustomFX)
        {
            if (HasGodotClassMethod(MethodProxyName__process_custom_fx.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_process_custom_fx' method.
        /// </summary>
        public static readonly StringName _ProcessCustomFX = "_process_custom_fx";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
