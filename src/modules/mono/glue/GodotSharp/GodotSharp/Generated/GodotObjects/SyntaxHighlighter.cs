namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for syntax highlighters. Provides syntax highlighting data to a <see cref="Godot.TextEdit"/>. The associated <see cref="Godot.TextEdit"/> will call into the <see cref="Godot.SyntaxHighlighter"/> on an as-needed basis.</para>
/// <para><b>Note:</b> A <see cref="Godot.SyntaxHighlighter"/> instance should not be used across multiple <see cref="Godot.TextEdit"/> nodes.</para>
/// </summary>
public partial class SyntaxHighlighter : Resource
{
    private static readonly System.Type CachedType = typeof(SyntaxHighlighter);

    private static readonly StringName NativeName = "SyntaxHighlighter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SyntaxHighlighter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SyntaxHighlighter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SyntaxHighlighter(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Virtual method which can be overridden to clear any local caches.</para>
    /// </summary>
    public virtual void _ClearHighlightingCache()
    {
    }

    /// <summary>
    /// <para>Virtual method which can be overridden to return syntax highlighting data.</para>
    /// <para>See <see cref="Godot.SyntaxHighlighter.GetLineSyntaxHighlighting(int)"/> for more details.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _GetLineSyntaxHighlighting(int line)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method which can be overridden to update any local caches.</para>
    /// </summary>
    public virtual void _UpdateCache()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineSyntaxHighlighting, 3554694381ul);

    /// <summary>
    /// <para>Returns the syntax highlighting data for the line at index <paramref name="line"/>. If the line is not cached, calls <see cref="Godot.SyntaxHighlighter._GetLineSyntaxHighlighting(int)"/> first to calculate the data.</para>
    /// <para>Each entry is a column number containing a nested <see cref="Godot.Collections.Dictionary"/>. The column number denotes the start of a region, the region will end if another region is found, or at the end of the line. The nested <see cref="Godot.Collections.Dictionary"/> contains the data for that region. Currently only the key <c>"color"</c> is supported.</para>
    /// <para><b>Example:</b> Possible return value. This means columns <c>0</c> to <c>4</c> should be red, and columns <c>5</c> to the end of the line should be green:</para>
    /// <para><code>
    /// {
    /// 	0: {
    /// 		"color": Color(1, 0, 0)
    /// 	},
    /// 	5: {
    /// 		"color": Color(0, 1, 0)
    /// 	}
    /// }
    /// </code></para>
    /// </summary>
    public Godot.Collections.Dictionary GetLineSyntaxHighlighting(int line)
    {
        return NativeCalls.godot_icall_1_307(MethodBind0, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateCache, 3218959716ul);

    /// <summary>
    /// <para>Clears then updates the <see cref="Godot.SyntaxHighlighter"/> caches. Override <see cref="Godot.SyntaxHighlighter._UpdateCache()"/> for a callback.</para>
    /// <para><b>Note:</b> This is called automatically when the associated <see cref="Godot.TextEdit"/> node, updates its own cache.</para>
    /// </summary>
    public void UpdateCache()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearHighlightingCache, 3218959716ul);

    /// <summary>
    /// <para>Clears all cached syntax highlighting data.</para>
    /// <para>Then calls overridable method <see cref="Godot.SyntaxHighlighter._ClearHighlightingCache()"/>.</para>
    /// </summary>
    public void ClearHighlightingCache()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextEdit, 1893027089ul);

    /// <summary>
    /// <para>Returns the associated <see cref="Godot.TextEdit"/> node.</para>
    /// </summary>
    public TextEdit GetTextEdit()
    {
        return (TextEdit)NativeCalls.godot_icall_0_53(MethodBind3, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__clear_highlighting_cache = "_ClearHighlightingCache";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_line_syntax_highlighting = "_GetLineSyntaxHighlighting";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__update_cache = "_UpdateCache";

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
        if ((method == MethodProxyName__clear_highlighting_cache || method == MethodName._ClearHighlightingCache) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__clear_highlighting_cache.NativeValue))
        {
            _ClearHighlightingCache();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_line_syntax_highlighting || method == MethodName._GetLineSyntaxHighlighting) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_line_syntax_highlighting.NativeValue))
        {
            var callRet = _GetLineSyntaxHighlighting(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__update_cache || method == MethodName._UpdateCache) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__update_cache.NativeValue))
        {
            _UpdateCache();
            ret = default;
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
        if (method == MethodName._ClearHighlightingCache)
        {
            if (HasGodotClassMethod(MethodProxyName__clear_highlighting_cache.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLineSyntaxHighlighting)
        {
            if (HasGodotClassMethod(MethodProxyName__get_line_syntax_highlighting.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UpdateCache)
        {
            if (HasGodotClassMethod(MethodProxyName__update_cache.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_clear_highlighting_cache' method.
        /// </summary>
        public static readonly StringName _ClearHighlightingCache = "_clear_highlighting_cache";
        /// <summary>
        /// Cached name for the '_get_line_syntax_highlighting' method.
        /// </summary>
        public static readonly StringName _GetLineSyntaxHighlighting = "_get_line_syntax_highlighting";
        /// <summary>
        /// Cached name for the '_update_cache' method.
        /// </summary>
        public static readonly StringName _UpdateCache = "_update_cache";
        /// <summary>
        /// Cached name for the 'get_line_syntax_highlighting' method.
        /// </summary>
        public static readonly StringName GetLineSyntaxHighlighting = "get_line_syntax_highlighting";
        /// <summary>
        /// Cached name for the 'update_cache' method.
        /// </summary>
        public static readonly StringName UpdateCache = "update_cache";
        /// <summary>
        /// Cached name for the 'clear_highlighting_cache' method.
        /// </summary>
        public static readonly StringName ClearHighlightingCache = "clear_highlighting_cache";
        /// <summary>
        /// Cached name for the 'get_text_edit' method.
        /// </summary>
        public static readonly StringName GetTextEdit = "get_text_edit";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
