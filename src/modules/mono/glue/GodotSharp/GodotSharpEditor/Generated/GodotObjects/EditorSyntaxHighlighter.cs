namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class that all <see cref="Godot.SyntaxHighlighter"/>s used by the <see cref="Godot.ScriptEditor"/> extend from.</para>
/// <para>Add a syntax highlighter to an individual script by calling <see cref="Godot.ScriptEditorBase.AddSyntaxHighlighter(EditorSyntaxHighlighter)"/>. To apply to all scripts on open, call <see cref="Godot.ScriptEditor.RegisterSyntaxHighlighter(EditorSyntaxHighlighter)"/>.</para>
/// </summary>
public partial class EditorSyntaxHighlighter : SyntaxHighlighter
{
    private static readonly System.Type CachedType = typeof(EditorSyntaxHighlighter);

    private static readonly StringName NativeName = "EditorSyntaxHighlighter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorSyntaxHighlighter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorSyntaxHighlighter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorSyntaxHighlighter(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Virtual method which creates a new instance of the syntax highlighter.</para>
    /// </summary>
    public virtual EditorSyntaxHighlighter _Create()
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method which can be overridden to return the syntax highlighter name.</para>
    /// </summary>
    public virtual string _GetName()
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method which can be overridden to return the supported language names.</para>
    /// </summary>
    public virtual string[] _GetSupportedLanguages()
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create = "_Create";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_name = "_GetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_supported_languages = "_GetSupportedLanguages";

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
        if ((method == MethodProxyName__create || method == MethodName._Create) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__create.NativeValue))
        {
            var callRet = _Create();
            ret = VariantUtils.CreateFrom<EditorSyntaxHighlighter>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_name || method == MethodName._GetName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_name.NativeValue))
        {
            var callRet = _GetName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_supported_languages || method == MethodName._GetSupportedLanguages) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_supported_languages.NativeValue))
        {
            var callRet = _GetSupportedLanguages();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
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
        if (method == MethodName._Create)
        {
            if (HasGodotClassMethod(MethodProxyName__create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSupportedLanguages)
        {
            if (HasGodotClassMethod(MethodProxyName__get_supported_languages.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : SyntaxHighlighter.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SyntaxHighlighter.MethodName
    {
        /// <summary>
        /// Cached name for the '_create' method.
        /// </summary>
        public static readonly StringName _Create = "_create";
        /// <summary>
        /// Cached name for the '_get_name' method.
        /// </summary>
        public static readonly StringName _GetName = "_get_name";
        /// <summary>
        /// Cached name for the '_get_supported_languages' method.
        /// </summary>
        public static readonly StringName _GetSupportedLanguages = "_get_supported_languages";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SyntaxHighlighter.SignalName
    {
    }
}
