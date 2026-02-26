namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A container that can be expanded/collapsed, with a title that can be filled with controls, such as buttons. This is also called an accordion.</para>
/// <para>The title can be positioned at the top or bottom of the container. The container can be expanded or collapsed by clicking the title or by pressing <c>ui_accept</c> when focused. Child control nodes are hidden when the container is collapsed. Ignores non-control children.</para>
/// <para>A FoldableContainer can be grouped with other FoldableContainers so that only one of them can be opened at a time; see <see cref="Godot.FoldableContainer.FoldableGroup"/> and <see cref="Godot.FoldableGroup"/>.</para>
/// </summary>
public partial class FoldableContainer : Container
{
    public enum TitlePositionEnum : long
    {
        /// <summary>
        /// <para>Makes the title appear at the top of the container.</para>
        /// </summary>
        Top = 0,
        /// <summary>
        /// <para>Makes the title appear at the bottom of the container. Also makes all StyleBoxes flipped vertically.</para>
        /// </summary>
        Bottom = 1
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the container will becomes folded and will hide all its children.</para>
    /// </summary>
    public bool Folded
    {
        get
        {
            return IsFolded();
        }
        set
        {
            SetFolded(value);
        }
    }

    /// <summary>
    /// <para>The container's title text.</para>
    /// </summary>
    public string Title
    {
        get
        {
            return GetTitle();
        }
        set
        {
            SetTitle(value);
        }
    }

    /// <summary>
    /// <para>Title's horizontal text alignment.</para>
    /// </summary>
    public HorizontalAlignment TitleAlignment
    {
        get
        {
            return GetTitleAlignment();
        }
        set
        {
            SetTitleAlignment(value);
        }
    }

    /// <summary>
    /// <para>Title's position.</para>
    /// </summary>
    public FoldableContainer.TitlePositionEnum TitlePosition
    {
        get
        {
            return GetTitlePosition();
        }
        set
        {
            SetTitlePosition(value);
        }
    }

    /// <summary>
    /// <para>Defines the behavior of the title when the text is longer than the available space.</para>
    /// </summary>
    public TextServer.OverrunBehavior TitleTextOverrunBehavior
    {
        get
        {
            return GetTitleTextOverrunBehavior();
        }
        set
        {
            SetTitleTextOverrunBehavior(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.FoldableGroup"/> associated with the container. When multiple <see cref="Godot.FoldableContainer"/> nodes share the same group, only one of them is allowed to be unfolded.</para>
    /// </summary>
    public FoldableGroup FoldableGroup
    {
        get
        {
            return GetFoldableGroup();
        }
        set
        {
            SetFoldableGroup(value);
        }
    }

    /// <summary>
    /// <para>Title text writing direction.</para>
    /// </summary>
    public Control.TextDirection TitleTextDirection
    {
        get
        {
            return GetTitleTextDirection();
        }
        set
        {
            SetTitleTextDirection(value);
        }
    }

    /// <summary>
    /// <para>Language code used for text shaping algorithms. If left empty, the current locale is used instead.</para>
    /// </summary>
    public string Language
    {
        get
        {
            return GetLanguage();
        }
        set
        {
            SetLanguage(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FoldableContainer);

    private static readonly StringName NativeName = "FoldableContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FoldableContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal FoldableContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal FoldableContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Fold, 3218959716ul);

    /// <summary>
    /// <para>Folds the container and emits <see cref="Godot.FoldableContainer.FoldingChanged"/>.</para>
    /// </summary>
    public void Fold()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Expand, 3218959716ul);

    /// <summary>
    /// <para>Expands the container and emits <see cref="Godot.FoldableContainer.FoldingChanged"/>.</para>
    /// </summary>
    public void Expand()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFolded, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFolded(bool folded)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), folded.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFolded, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFolded()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFoldableGroup, 3001390597ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFoldableGroup(FoldableGroup buttonGroup)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(buttonGroup));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFoldableGroup, 66499518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FoldableGroup GetFoldableGroup()
    {
        return (FoldableGroup)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitle, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitle(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind6, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitle, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTitle()
    {
        return NativeCalls.godot_icall_0_58(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitleAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitleAlignment(HorizontalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitleAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetTitleAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind10, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitleTextDirection, 119160795ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitleTextDirection(Control.TextDirection textDirection)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)textDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitleTextDirection, 797257663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.TextDirection GetTitleTextDirection()
    {
        return (Control.TextDirection)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitleTextOverrunBehavior, 1008890932ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitleTextOverrunBehavior(TextServer.OverrunBehavior overrunBehavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)overrunBehavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitleTextOverrunBehavior, 3779142101ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.OverrunBehavior GetTitleTextOverrunBehavior()
    {
        return (TextServer.OverrunBehavior)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitlePosition, 2276829442ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitlePosition(FoldableContainer.TitlePositionEnum titlePosition)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)titlePosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitlePosition, 3028840207ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FoldableContainer.TitlePositionEnum GetTitlePosition()
    {
        return (FoldableContainer.TitlePositionEnum)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTitleBarControl, 1496901182ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Control"/> that will be placed next to the container's title, obscuring the clickable area. Prime usage is adding <see cref="Godot.Button"/> nodes, but it can be any <see cref="Godot.Control"/>.</para>
    /// <para>The control will be added as a child of this container and removed from previous parent if necessary. The controls will be placed aligned to the right, with the first added control being the leftmost one.</para>
    /// </summary>
    public void AddTitleBarControl(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind18, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTitleBarControl, 1496901182ul);

    /// <summary>
    /// <para>Removes a <see cref="Godot.Control"/> added with <see cref="Godot.FoldableContainer.AddTitleBarControl(Control)"/>. The node is not freed automatically, you need to use <see cref="Godot.Node.QueueFree()"/>.</para>
    /// </summary>
    public void RemoveTitleBarControl(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind19, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FoldableContainer.FoldingChanged"/> event of a <see cref="Godot.FoldableContainer"/> class.
    /// </summary>
    public delegate void FoldingChangedEventHandler(bool isFolded);

    private static void FoldingChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((FoldingChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<bool>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the container is folded/expanded.</para>
    /// </summary>
    public unsafe event FoldingChangedEventHandler FoldingChanged
    {
        add => Connect(SignalName.FoldingChanged, Callable.CreateWithUnsafeTrampoline(value, &FoldingChangedTrampoline));
        remove => Disconnect(SignalName.FoldingChanged, Callable.CreateWithUnsafeTrampoline(value, &FoldingChangedTrampoline));
    }

    protected void EmitSignalFoldingChanged(bool isFolded)
    {
        EmitSignal(SignalName.FoldingChanged, isFolded);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_folding_changed = "FoldingChanged";

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
        if (signal == SignalName.FoldingChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_folding_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'folded' property.
        /// </summary>
        public static readonly StringName Folded = "folded";
        /// <summary>
        /// Cached name for the 'title' property.
        /// </summary>
        public static readonly StringName Title = "title";
        /// <summary>
        /// Cached name for the 'title_alignment' property.
        /// </summary>
        public static readonly StringName TitleAlignment = "title_alignment";
        /// <summary>
        /// Cached name for the 'title_position' property.
        /// </summary>
        public static readonly StringName TitlePosition = "title_position";
        /// <summary>
        /// Cached name for the 'title_text_overrun_behavior' property.
        /// </summary>
        public static readonly StringName TitleTextOverrunBehavior = "title_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'foldable_group' property.
        /// </summary>
        public static readonly StringName FoldableGroup = "foldable_group";
        /// <summary>
        /// Cached name for the 'title_text_direction' property.
        /// </summary>
        public static readonly StringName TitleTextDirection = "title_text_direction";
        /// <summary>
        /// Cached name for the 'language' property.
        /// </summary>
        public static readonly StringName Language = "language";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'fold' method.
        /// </summary>
        public static readonly StringName Fold = "fold";
        /// <summary>
        /// Cached name for the 'expand' method.
        /// </summary>
        public static readonly StringName Expand = "expand";
        /// <summary>
        /// Cached name for the 'set_folded' method.
        /// </summary>
        public static readonly StringName SetFolded = "set_folded";
        /// <summary>
        /// Cached name for the 'is_folded' method.
        /// </summary>
        public static readonly StringName IsFolded = "is_folded";
        /// <summary>
        /// Cached name for the 'set_foldable_group' method.
        /// </summary>
        public static readonly StringName SetFoldableGroup = "set_foldable_group";
        /// <summary>
        /// Cached name for the 'get_foldable_group' method.
        /// </summary>
        public static readonly StringName GetFoldableGroup = "get_foldable_group";
        /// <summary>
        /// Cached name for the 'set_title' method.
        /// </summary>
        public static readonly StringName SetTitle = "set_title";
        /// <summary>
        /// Cached name for the 'get_title' method.
        /// </summary>
        public static readonly StringName GetTitle = "get_title";
        /// <summary>
        /// Cached name for the 'set_title_alignment' method.
        /// </summary>
        public static readonly StringName SetTitleAlignment = "set_title_alignment";
        /// <summary>
        /// Cached name for the 'get_title_alignment' method.
        /// </summary>
        public static readonly StringName GetTitleAlignment = "get_title_alignment";
        /// <summary>
        /// Cached name for the 'set_language' method.
        /// </summary>
        public static readonly StringName SetLanguage = "set_language";
        /// <summary>
        /// Cached name for the 'get_language' method.
        /// </summary>
        public static readonly StringName GetLanguage = "get_language";
        /// <summary>
        /// Cached name for the 'set_title_text_direction' method.
        /// </summary>
        public static readonly StringName SetTitleTextDirection = "set_title_text_direction";
        /// <summary>
        /// Cached name for the 'get_title_text_direction' method.
        /// </summary>
        public static readonly StringName GetTitleTextDirection = "get_title_text_direction";
        /// <summary>
        /// Cached name for the 'set_title_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName SetTitleTextOverrunBehavior = "set_title_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'get_title_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName GetTitleTextOverrunBehavior = "get_title_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'set_title_position' method.
        /// </summary>
        public static readonly StringName SetTitlePosition = "set_title_position";
        /// <summary>
        /// Cached name for the 'get_title_position' method.
        /// </summary>
        public static readonly StringName GetTitlePosition = "get_title_position";
        /// <summary>
        /// Cached name for the 'add_title_bar_control' method.
        /// </summary>
        public static readonly StringName AddTitleBarControl = "add_title_bar_control";
        /// <summary>
        /// Cached name for the 'remove_title_bar_control' method.
        /// </summary>
        public static readonly StringName RemoveTitleBarControl = "remove_title_bar_control";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
        /// <summary>
        /// Cached name for the 'folding_changed' signal.
        /// </summary>
        public static readonly StringName FoldingChanged = "folding_changed";
    }
}
