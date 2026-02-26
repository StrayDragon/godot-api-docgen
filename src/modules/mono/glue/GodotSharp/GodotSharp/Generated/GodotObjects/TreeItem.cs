namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A single item of a <see cref="Godot.Tree"/> control. It can contain other <see cref="Godot.TreeItem"/>s as children, which allows it to create a hierarchy. It can also contain text and buttons. <see cref="Godot.TreeItem"/> is not a <see cref="Godot.Node"/>, it is internal to the <see cref="Godot.Tree"/>.</para>
/// <para>To create a <see cref="Godot.TreeItem"/>, use <see cref="Godot.Tree.CreateItem(TreeItem, int)"/> or <see cref="Godot.TreeItem.CreateChild(int)"/>. To remove a <see cref="Godot.TreeItem"/>, use <see cref="Godot.GodotObject.Free()"/>.</para>
/// <para><b>Note:</b> The ID values used for buttons are 32-bit, unlike <see cref="int"/> which is always 64-bit. They go from <c>-2147483648</c> to <c>2147483647</c>.</para>
/// </summary>
public partial class TreeItem : GodotObject
{
    public enum TreeCellMode : long
    {
        /// <summary>
        /// <para>Cell shows a string label, optionally with an icon. When editable, the text can be edited using a <see cref="Godot.LineEdit"/>, or a <see cref="Godot.TextEdit"/> popup if <see cref="Godot.TreeItem.SetEditMultiline(int, bool)"/> is used.</para>
        /// </summary>
        String = 0,
        /// <summary>
        /// <para>Cell shows a checkbox, optionally with text and an icon. The checkbox can be pressed, released, or indeterminate (via <see cref="Godot.TreeItem.SetIndeterminate(int, bool)"/>). The checkbox can't be clicked unless the cell is editable.</para>
        /// </summary>
        Check = 1,
        /// <summary>
        /// <para>Cell shows a numeric range. When editable, it can be edited using a range slider. Use <see cref="Godot.TreeItem.SetRange(int, double)"/> to set the value and <see cref="Godot.TreeItem.SetRangeConfig(int, double, double, double, bool)"/> to configure the range.</para>
        /// <para>This cell can also be used in a text dropdown mode when you assign a text with <see cref="Godot.TreeItem.SetText(int, string)"/>. Separate options with a comma, e.g. <c>"Option1,Option2,Option3"</c>.</para>
        /// </summary>
        Range = 2,
        /// <summary>
        /// <para>Cell shows an icon. It can't be edited nor display text. The icon is always centered within the cell.</para>
        /// </summary>
        Icon = 3,
        /// <summary>
        /// <para>Cell shows as a clickable button. It will display an arrow similar to <see cref="Godot.OptionButton"/>, but doesn't feature a dropdown (for that you can use <see cref="Godot.TreeItem.TreeCellMode.Range"/>). Clicking the button emits the <see cref="Godot.Tree.ItemEdited"/> signal. The button is flat by default, you can use <see cref="Godot.TreeItem.SetCustomAsButton(int, bool)"/> to display it with a <see cref="Godot.StyleBox"/>.</para>
        /// <para>This mode also supports custom drawing using <see cref="Godot.TreeItem.SetCustomDrawCallback(int, Callable)"/>.</para>
        /// </summary>
        Custom = 4
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the TreeItem is collapsed.</para>
    /// </summary>
    public bool Collapsed
    {
        get
        {
            return IsCollapsed();
        }
        set
        {
            SetCollapsed(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.TreeItem"/> is visible (default).</para>
    /// <para>Note that if a <see cref="Godot.TreeItem"/> is set to not be visible, none of its children will be visible either.</para>
    /// </summary>
    public bool Visible
    {
        get
        {
            return IsVisible();
        }
        set
        {
            SetVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, folding is disabled for this TreeItem.</para>
    /// </summary>
    public bool DisableFolding
    {
        get
        {
            return IsFoldingDisabled();
        }
        set
        {
            SetDisableFolding(value);
        }
    }

    /// <summary>
    /// <para>The custom minimum height.</para>
    /// </summary>
    public int CustomMinimumHeight
    {
        get
        {
            return GetCustomMinimumHeight();
        }
        set
        {
            SetCustomMinimumHeight(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TreeItem);

    private static readonly StringName NativeName = "TreeItem";

    internal TreeItem() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TreeItem(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TreeItem(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellMode, 289920701ul);

    /// <summary>
    /// <para>Sets the given column's cell mode to <paramref name="mode"/>. This determines how the cell is displayed and edited.</para>
    /// </summary>
    public void SetCellMode(int column, TreeItem.TreeCellMode mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind0, GodotObject.GetPtr(this), column, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellMode, 3406114978ul);

    /// <summary>
    /// <para>Returns the column's cell mode.</para>
    /// </summary>
    public TreeItem.TreeCellMode GetCellMode(int column)
    {
        return (TreeItem.TreeCellMode)NativeCalls.godot_icall_1_60(MethodBind1, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoTranslateMode, 287402019ul);

    /// <summary>
    /// <para>Sets the given column's auto translate mode to <paramref name="mode"/>.</para>
    /// <para>All columns use <see cref="Godot.Node.AutoTranslateModeEnum.Inherit"/> by default, which uses the same auto translate mode as the <see cref="Godot.Tree"/> itself.</para>
    /// </summary>
    public void SetAutoTranslateMode(int column, Node.AutoTranslateModeEnum mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind2, GodotObject.GetPtr(this), column, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoTranslateMode, 906302372ul);

    /// <summary>
    /// <para>Returns the column's auto translate mode.</para>
    /// </summary>
    public Node.AutoTranslateModeEnum GetAutoTranslateMode(int column)
    {
        return (Node.AutoTranslateModeEnum)NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditMultiline, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="multiline"/> is <see langword="true"/>, the given <paramref name="column"/> is multiline editable.</para>
    /// <para><b>Note:</b> This option only affects the type of control (<see cref="Godot.LineEdit"/> or <see cref="Godot.TextEdit"/>) that appears when editing the column. You can set multiline values with <see cref="Godot.TreeItem.SetText(int, string)"/> even if the column is not multiline editable.</para>
    /// </summary>
    public void SetEditMultiline(int column, bool multiline)
    {
        NativeCalls.godot_icall_2_61(MethodBind4, GodotObject.GetPtr(this), column, multiline.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditMultiline, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="column"/> is multiline editable.</para>
    /// </summary>
    public bool IsEditMultiline(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind5, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetChecked, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="checked"/> is <see langword="true"/>, the given <paramref name="column"/> is checked. Clears column's indeterminate status.</para>
    /// </summary>
    public void SetChecked(int column, bool @checked)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), column, @checked.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndeterminate, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="indeterminate"/> is <see langword="true"/>, the given <paramref name="column"/> is marked indeterminate.</para>
    /// <para><b>Note:</b> If set <see langword="true"/> from <see langword="false"/>, then column is cleared of checked status.</para>
    /// </summary>
    public void SetIndeterminate(int column, bool indeterminate)
    {
        NativeCalls.godot_icall_2_61(MethodBind7, GodotObject.GetPtr(this), column, indeterminate.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsChecked, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="column"/> is checked.</para>
    /// </summary>
    public bool IsChecked(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIndeterminate, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="column"/> is indeterminate.</para>
    /// </summary>
    public bool IsIndeterminate(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind9, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropagateCheck, 972357352ul);

    /// <summary>
    /// <para>Propagates this item's checked status to its children and parents for the given <paramref name="column"/>. It is possible to process the items affected by this method call by connecting to <see cref="Godot.Tree.CheckPropagatedToItem"/>. The order that the items affected will be processed is as follows: the item invoking this method, children of that item, and finally parents of that item. If <paramref name="emitSignal"/> is <see langword="false"/>, then <see cref="Godot.Tree.CheckPropagatedToItem"/> will not be emitted.</para>
    /// </summary>
    public void PropagateCheck(int column, bool emitSignal = true)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), column, emitSignal.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 501894301ul);

    /// <summary>
    /// <para>Sets the given column's text value.</para>
    /// </summary>
    public void SetText(int column, string text)
    {
        NativeCalls.godot_icall_2_181(MethodBind11, GodotObject.GetPtr(this), column, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 844755477ul);

    /// <summary>
    /// <para>Returns the given column's text.</para>
    /// </summary>
    public string GetText(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind12, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDescription, 501894301ul);

    /// <summary>
    /// <para>Sets the given column's description for assistive apps.</para>
    /// </summary>
    public void SetDescription(int column, string description)
    {
        NativeCalls.godot_icall_2_181(MethodBind13, GodotObject.GetPtr(this), column, description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDescription, 844755477ul);

    /// <summary>
    /// <para>Returns the given column's description for assistive apps.</para>
    /// </summary>
    public string GetDescription(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind14, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 1707680378ul);

    /// <summary>
    /// <para>Sets item's text base writing direction.</para>
    /// </summary>
    public void SetTextDirection(int column, Control.TextDirection direction)
    {
        NativeCalls.godot_icall_2_59(MethodBind15, GodotObject.GetPtr(this), column, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 4235602388ul);

    /// <summary>
    /// <para>Returns item's text base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetTextDirection(int column)
    {
        return (Control.TextDirection)NativeCalls.godot_icall_1_60(MethodBind16, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapMode, 3633006561ul);

    /// <summary>
    /// <para>Sets the autowrap mode in the given <paramref name="column"/>. If set to something other than <see cref="Godot.TextServer.AutowrapMode.Off"/>, the text gets wrapped inside the cell's bounding rectangle.</para>
    /// </summary>
    public void SetAutowrapMode(int column, TextServer.AutowrapMode autowrapMode)
    {
        NativeCalls.godot_icall_2_59(MethodBind17, GodotObject.GetPtr(this), column, (int)autowrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapMode, 2902757236ul);

    /// <summary>
    /// <para>Returns the text autowrap mode in the given <paramref name="column"/>. By default it is <see cref="Godot.TextServer.AutowrapMode.Off"/>.</para>
    /// </summary>
    public TextServer.AutowrapMode GetAutowrapMode(int column)
    {
        return (TextServer.AutowrapMode)NativeCalls.godot_icall_1_60(MethodBind18, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextOverrunBehavior, 1940772195ul);

    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds the item's bounding rectangle in the given <paramref name="column"/>.</para>
    /// </summary>
    public void SetTextOverrunBehavior(int column, TextServer.OverrunBehavior overrunBehavior)
    {
        NativeCalls.godot_icall_2_59(MethodBind19, GodotObject.GetPtr(this), column, (int)overrunBehavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextOverrunBehavior, 3782727860ul);

    /// <summary>
    /// <para>Returns the clipping behavior when the text exceeds the item's bounding rectangle in the given <paramref name="column"/>. By default it is <see cref="Godot.TextServer.OverrunBehavior.TrimEllipsis"/>.</para>
    /// </summary>
    public TextServer.OverrunBehavior GetTextOverrunBehavior(int column)
    {
        return (TextServer.OverrunBehavior)NativeCalls.godot_icall_1_60(MethodBind20, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverride, 868756907ul);

    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text. Has effect for cells that display text.</para>
    /// </summary>
    public void SetStructuredTextBidiOverride(int column, TextServer.StructuredTextParser parser)
    {
        NativeCalls.godot_icall_2_59(MethodBind21, GodotObject.GetPtr(this), column, (int)parser);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverride, 3377823772ul);

    /// <summary>
    /// <para>Returns the BiDi algorithm override set for this cell.</para>
    /// </summary>
    public TextServer.StructuredTextParser GetStructuredTextBidiOverride(int column)
    {
        return (TextServer.StructuredTextParser)NativeCalls.godot_icall_1_60(MethodBind22, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverrideOptions, 537221740ul);

    /// <summary>
    /// <para>Set additional options for BiDi override. Has effect for cells that display text.</para>
    /// </summary>
    public void SetStructuredTextBidiOverrideOptions(int column, Godot.Collections.Array args)
    {
        NativeCalls.godot_icall_2_802(MethodBind23, GodotObject.GetPtr(this), column, (godot_array)(args ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverrideOptions, 663333327ul);

    /// <summary>
    /// <para>Returns the additional BiDi options set for this cell.</para>
    /// </summary>
    public Godot.Collections.Array GetStructuredTextBidiOverrideOptions(int column)
    {
        return NativeCalls.godot_icall_1_457(MethodBind24, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 501894301ul);

    /// <summary>
    /// <para>Sets the language code of the given <paramref name="column"/>'s text to <paramref name="language"/>. This is used for line-breaking and text shaping algorithms. If <paramref name="language"/> is empty, the current locale is used.</para>
    /// </summary>
    public void SetLanguage(int column, string language)
    {
        NativeCalls.godot_icall_2_181(MethodBind25, GodotObject.GetPtr(this), column, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 844755477ul);

    /// <summary>
    /// <para>Returns item's text language code.</para>
    /// </summary>
    public string GetLanguage(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind26, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSuffix, 501894301ul);

    /// <summary>
    /// <para>Sets a string to be shown after a column's value (for example, a unit abbreviation).</para>
    /// </summary>
    public void SetSuffix(int column, string text)
    {
        NativeCalls.godot_icall_2_181(MethodBind27, GodotObject.GetPtr(this), column, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSuffix, 844755477ul);

    /// <summary>
    /// <para>Gets the suffix string shown after the column value.</para>
    /// </summary>
    public string GetSuffix(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind28, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIcon, 666127730ul);

    /// <summary>
    /// <para>Sets the given cell's icon <see cref="Godot.Texture2D"/>. If the cell is in <see cref="Godot.TreeItem.TreeCellMode.Icon"/> mode, the icon is displayed in the center of the cell. Otherwise, the icon is displayed before the cell's text. <see cref="Godot.TreeItem.TreeCellMode.Range"/> does not display an icon.</para>
    /// </summary>
    public void SetIcon(int column, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind29, GodotObject.GetPtr(this), column, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the given column's icon <see cref="Godot.Texture2D"/>. Error if no icon is set.</para>
    /// </summary>
    public Texture2D GetIcon(int column)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind30, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconOverlay, 666127730ul);

    /// <summary>
    /// <para>Sets the given cell's icon overlay <see cref="Godot.Texture2D"/>. The cell has to be in <see cref="Godot.TreeItem.TreeCellMode.Icon"/> mode, and icon has to be set. Overlay is drawn on top of icon, in the bottom left corner.</para>
    /// </summary>
    public void SetIconOverlay(int column, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind31, GodotObject.GetPtr(this), column, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconOverlay, 3536238170ul);

    /// <summary>
    /// <para>Returns the given column's icon overlay <see cref="Godot.Texture2D"/>.</para>
    /// </summary>
    public Texture2D GetIconOverlay(int column)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind32, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconRegion, 1356297692ul);

    /// <summary>
    /// <para>Sets the given column's icon's texture region.</para>
    /// </summary>
    public unsafe void SetIconRegion(int column, Rect2 region)
    {
        NativeCalls.godot_icall_2_763(MethodBind33, GodotObject.GetPtr(this), column, &region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconRegion, 3327874267ul);

    /// <summary>
    /// <para>Returns the icon <see cref="Godot.Texture2D"/> region as <see cref="Godot.Rect2"/>.</para>
    /// </summary>
    public Rect2 GetIconRegion(int column)
    {
        return NativeCalls.godot_icall_1_450(MethodBind34, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconMaxWidth, 3937882851ul);

    /// <summary>
    /// <para>Sets the maximum allowed width of the icon in the given <paramref name="column"/>. This limit is applied on top of the default size of the icon and on top of <c>Tree.icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    public void SetIconMaxWidth(int column, int width)
    {
        NativeCalls.godot_icall_2_59(MethodBind35, GodotObject.GetPtr(this), column, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconMaxWidth, 923996154ul);

    /// <summary>
    /// <para>Returns the maximum allowed width of the icon in the given <paramref name="column"/>.</para>
    /// </summary>
    public int GetIconMaxWidth(int column)
    {
        return NativeCalls.godot_icall_1_60(MethodBind36, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconModulate, 2878471219ul);

    /// <summary>
    /// <para>Modulates the given column's icon with <paramref name="modulate"/>.</para>
    /// </summary>
    public unsafe void SetIconModulate(int column, Color modulate)
    {
        NativeCalls.godot_icall_2_687(MethodBind37, GodotObject.GetPtr(this), column, &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconModulate, 3457211756ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Color"/> modulating the column's icon.</para>
    /// </summary>
    public Color GetIconModulate(int column)
    {
        return NativeCalls.godot_icall_1_688(MethodBind38, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRange, 1602489585ul);

    /// <summary>
    /// <para>Sets the value of a <see cref="Godot.TreeItem.TreeCellMode.Range"/> column.</para>
    /// </summary>
    public void SetRange(int column, double value)
    {
        NativeCalls.godot_icall_2_84(MethodBind39, GodotObject.GetPtr(this), column, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRange, 2339986948ul);

    /// <summary>
    /// <para>Returns the value of a <see cref="Godot.TreeItem.TreeCellMode.Range"/> column.</para>
    /// </summary>
    public double GetRange(int column)
    {
        return NativeCalls.godot_icall_1_460(MethodBind40, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRangeConfig, 1547181014ul);

    /// <summary>
    /// <para>Sets the range of accepted values for a column. The column must be in the <see cref="Godot.TreeItem.TreeCellMode.Range"/> mode.</para>
    /// <para>If <paramref name="expr"/> is <see langword="true"/>, the edit mode slider will use an exponential scale as with <see cref="Godot.Range.ExpEdit"/>.</para>
    /// </summary>
    public void SetRangeConfig(int column, double min, double max, double step, bool expr = false)
    {
        NativeCalls.godot_icall_5_1475(MethodBind41, GodotObject.GetPtr(this), column, min, max, step, expr.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRangeConfig, 3554694381ul);

    /// <summary>
    /// <para>Returns a dictionary containing the range parameters for a given column. The keys are "min", "max", "step", and "expr".</para>
    /// </summary>
    public Godot.Collections.Dictionary GetRangeConfig(int column)
    {
        return NativeCalls.godot_icall_1_307(MethodBind42, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMetadata, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata value for the given column, which can be retrieved later using <see cref="Godot.TreeItem.GetMetadata(int)"/>. This can be used, for example, to store a reference to the original data.</para>
    /// </summary>
    public void SetMetadata(int column, Variant meta)
    {
        NativeCalls.godot_icall_2_701(MethodBind43, GodotObject.GetPtr(this), column, meta);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMetadata, 4227898402ul);

    /// <summary>
    /// <para>Returns the metadata value that was set for the given column using <see cref="Godot.TreeItem.SetMetadata(int, Variant)"/>.</para>
    /// </summary>
    public Variant GetMetadata(int column)
    {
        return NativeCalls.godot_icall_1_702(MethodBind44, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomDraw, 272420368ul);

    /// <summary>
    /// <para>Sets the given column's custom draw callback to the <paramref name="callback"/> method on <paramref name="object"/>.</para>
    /// <para>The method named <paramref name="callback"/> should accept two arguments: the <see cref="Godot.TreeItem"/> that is drawn and its position and size as a <see cref="Godot.Rect2"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TreeItem.SetCustomDrawCallback(int, Callable)' instead.")]
    public void SetCustomDraw(int column, GodotObject @object, StringName callback)
    {
        NativeCalls.godot_icall_3_1476(MethodBind45, GodotObject.GetPtr(this), column, GodotObject.GetPtr(@object), (godot_string_name)(callback?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomDrawCallback, 957362965ul);

    /// <summary>
    /// <para>Sets the given column's custom draw callback. Use an empty <see cref="Godot.Callable"/> (<c>Callable()</c>) to clear the custom callback. The cell has to be in <see cref="Godot.TreeItem.TreeCellMode.Custom"/> to use this feature.</para>
    /// <para>The <paramref name="callback"/> should accept two arguments: the <see cref="Godot.TreeItem"/> that is drawn and its position and size as a <see cref="Godot.Rect2"/>.</para>
    /// </summary>
    public void SetCustomDrawCallback(int column, Callable callback)
    {
        NativeCalls.godot_icall_2_402(MethodBind46, GodotObject.GetPtr(this), column, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomDrawCallback, 1317077508ul);

    /// <summary>
    /// <para>Returns the custom callback of column <paramref name="column"/>.</para>
    /// </summary>
    public Callable GetCustomDrawCallback(int column)
    {
        return NativeCalls.godot_icall_1_1477(MethodBind47, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomStylebox, 1433009359ul);

    /// <summary>
    /// <para>Sets the given column's custom <see cref="Godot.StyleBox"/> used to draw the background.</para>
    /// <para><b>Note:</b> If a custom background color is set, the <see cref="Godot.StyleBox"/> will be drawn in front of it.</para>
    /// </summary>
    public void SetCustomStylebox(int column, StyleBox stylebox)
    {
        NativeCalls.godot_icall_2_70(MethodBind48, GodotObject.GetPtr(this), column, GodotObject.GetPtr(stylebox));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomStylebox, 3362509644ul);

    /// <summary>
    /// <para>Returns the given column's custom <see cref="Godot.StyleBox"/> used to draw the background.</para>
    /// </summary>
    public StyleBox GetCustomStylebox(int column)
    {
        return (StyleBox)NativeCalls.godot_icall_1_71(MethodBind49, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollapsed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollapsed(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind50, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollapsed, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollapsed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind51, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollapsedRecursive, 2586408642ul);

    /// <summary>
    /// <para>Collapses or uncollapses this <see cref="Godot.TreeItem"/> and all the descendants of this item.</para>
    /// </summary>
    public void SetCollapsedRecursive(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind52, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAnyCollapsed, 2595650253ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this <see cref="Godot.TreeItem"/>, or any of its descendants, is collapsed.</para>
    /// <para>If <paramref name="onlyVisible"/> is <see langword="true"/> it ignores non-visible <see cref="Godot.TreeItem"/>s.</para>
    /// </summary>
    public bool IsAnyCollapsed(bool onlyVisible = false)
    {
        return NativeCalls.godot_icall_1_334(MethodBind53, GodotObject.GetPtr(this), onlyVisible.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisible(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind54, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisible, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisibleInTree, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <see cref="Godot.TreeItem.Visible"/> is <see langword="true"/> and all its ancestors are also visible.</para>
    /// </summary>
    public bool IsVisibleInTree()
    {
        return NativeCalls.godot_icall_0_15(MethodBind56, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UncollapseTree, 3218959716ul);

    /// <summary>
    /// <para>Uncollapses all <see cref="Godot.TreeItem"/>s necessary to reveal this <see cref="Godot.TreeItem"/>, i.e. all ancestor <see cref="Godot.TreeItem"/>s.</para>
    /// </summary>
    public void UncollapseTree()
    {
        NativeCalls.godot_icall_0_3(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomMinimumHeight, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomMinimumHeight(int height)
    {
        NativeCalls.godot_icall_1_38(MethodBind58, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMinimumHeight, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCustomMinimumHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectable, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="selectable"/> is <see langword="true"/>, the given <paramref name="column"/> is selectable.</para>
    /// </summary>
    public void SetSelectable(int column, bool selectable)
    {
        NativeCalls.godot_icall_2_61(MethodBind60, GodotObject.GetPtr(this), column, selectable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelectable, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="column"/> is selectable.</para>
    /// </summary>
    public bool IsSelectable(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind61, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelected, 3067735520ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="column"/> is selected.</para>
    /// </summary>
    public bool IsSelected(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind62, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Select, 1286410249ul);

    /// <summary>
    /// <para>Selects the given <paramref name="column"/>.</para>
    /// </summary>
    public void Select(int column)
    {
        NativeCalls.godot_icall_1_38(MethodBind63, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Deselect, 1286410249ul);

    /// <summary>
    /// <para>Deselects the given column.</para>
    /// </summary>
    public void Deselect(int column)
    {
        NativeCalls.godot_icall_1_38(MethodBind64, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditable, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the given <paramref name="column"/> is editable.</para>
    /// </summary>
    public void SetEditable(int column, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind65, GodotObject.GetPtr(this), column, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditable, 3067735520ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="column"/> is editable.</para>
    /// </summary>
    public bool IsEditable(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind66, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the given column's custom color.</para>
    /// </summary>
    public unsafe void SetCustomColor(int column, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind67, GodotObject.GetPtr(this), column, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the custom color of column <paramref name="column"/>.</para>
    /// </summary>
    public Color GetCustomColor(int column)
    {
        return NativeCalls.godot_icall_1_688(MethodBind68, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCustomColor, 1286410249ul);

    /// <summary>
    /// <para>Resets the color for the given column to default.</para>
    /// </summary>
    public void ClearCustomColor(int column)
    {
        NativeCalls.godot_icall_1_38(MethodBind69, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomFont, 2637609184ul);

    /// <summary>
    /// <para>Sets custom font used to draw text in the given <paramref name="column"/>.</para>
    /// </summary>
    public void SetCustomFont(int column, Font font)
    {
        NativeCalls.godot_icall_2_70(MethodBind70, GodotObject.GetPtr(this), column, GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomFont, 4244553094ul);

    /// <summary>
    /// <para>Returns custom font used to draw text in the column <paramref name="column"/>.</para>
    /// </summary>
    public Font GetCustomFont(int column)
    {
        return (Font)NativeCalls.godot_icall_1_71(MethodBind71, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomFontSize, 3937882851ul);

    /// <summary>
    /// <para>Sets custom font size used to draw text in the given <paramref name="column"/>.</para>
    /// </summary>
    public void SetCustomFontSize(int column, int fontSize)
    {
        NativeCalls.godot_icall_2_59(MethodBind72, GodotObject.GetPtr(this), column, fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomFontSize, 923996154ul);

    /// <summary>
    /// <para>Returns custom font size used to draw text in the column <paramref name="column"/>.</para>
    /// </summary>
    public int GetCustomFontSize(int column)
    {
        return NativeCalls.godot_icall_1_60(MethodBind73, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomBgColor, 894174518ul);

    /// <summary>
    /// <para>Sets the given column's custom background color and whether to just use it as an outline.</para>
    /// <para><b>Note:</b> If a custom <see cref="Godot.StyleBox"/> is set, the background color will be drawn behind it.</para>
    /// </summary>
    public unsafe void SetCustomBgColor(int column, Color color, bool justOutline = false)
    {
        NativeCalls.godot_icall_3_1478(MethodBind74, GodotObject.GetPtr(this), column, &color, justOutline.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCustomBgColor, 1286410249ul);

    /// <summary>
    /// <para>Resets the background color for the given column to default.</para>
    /// </summary>
    public void ClearCustomBgColor(int column)
    {
        NativeCalls.godot_icall_1_38(MethodBind75, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomBgColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the custom background color of column <paramref name="column"/>.</para>
    /// </summary>
    public Color GetCustomBgColor(int column)
    {
        return NativeCalls.godot_icall_1_688(MethodBind76, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomAsButton, 300928843ul);

    /// <summary>
    /// <para>Makes a cell with <see cref="Godot.TreeItem.TreeCellMode.Custom"/> display as a non-flat button with a <see cref="Godot.StyleBox"/>.</para>
    /// </summary>
    public void SetCustomAsButton(int column, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind77, GodotObject.GetPtr(this), column, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCustomSetAsButton, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the cell was made into a button with <see cref="Godot.TreeItem.SetCustomAsButton(int, bool)"/>.</para>
    /// </summary>
    public bool IsCustomSetAsButton(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind78, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearButtons, 3218959716ul);

    /// <summary>
    /// <para>Removes all buttons from all columns of this item.</para>
    /// </summary>
    public void ClearButtons()
    {
        NativeCalls.godot_icall_0_3(MethodBind79, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddButton, 973481897ul);

    /// <summary>
    /// <para>Adds a button with <see cref="Godot.Texture2D"/> <paramref name="button"/> to the end of the cell at column <paramref name="column"/>. The <paramref name="id"/> is used to identify the button in the according <see cref="Godot.Tree.ButtonClicked"/> signal and can be different from the buttons index. If not specified, the next available index is used, which may be retrieved by calling <see cref="Godot.TreeItem.GetButtonCount(int)"/> immediately before this method. Optionally, the button can be <paramref name="disabled"/> and have a <paramref name="tooltipText"/>. <paramref name="description"/> is used as the button description for assistive apps.</para>
    /// </summary>
    public void AddButton(int column, Texture2D button, int id = -1, bool disabled = false, string tooltipText = "", string description = "")
    {
        NativeCalls.godot_icall_6_1479(MethodBind80, GodotObject.GetPtr(this), column, GodotObject.GetPtr(button), id, disabled.ToGodotBool(), tooltipText, description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of buttons in column <paramref name="column"/>.</para>
    /// </summary>
    public int GetButtonCount(int column)
    {
        return NativeCalls.godot_icall_1_60(MethodBind81, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonTooltipText, 1391810591ul);

    /// <summary>
    /// <para>Returns the tooltip text for the button at index <paramref name="buttonIndex"/> in column <paramref name="column"/>.</para>
    /// </summary>
    public string GetButtonTooltipText(int column, int buttonIndex)
    {
        return NativeCalls.godot_icall_2_222(MethodBind82, GodotObject.GetPtr(this), column, buttonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonId, 3175239445ul);

    /// <summary>
    /// <para>Returns the ID for the button at index <paramref name="buttonIndex"/> in column <paramref name="column"/>.</para>
    /// </summary>
    public int GetButtonId(int column, int buttonIndex)
    {
        return NativeCalls.godot_icall_2_73(MethodBind83, GodotObject.GetPtr(this), column, buttonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonById, 3175239445ul);

    /// <summary>
    /// <para>Returns the button index if there is a button with ID <paramref name="id"/> in column <paramref name="column"/>, otherwise returns -1.</para>
    /// </summary>
    public int GetButtonById(int column, int id)
    {
        return NativeCalls.godot_icall_2_73(MethodBind84, GodotObject.GetPtr(this), column, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonColor, 2165839948ul);

    /// <summary>
    /// <para>Returns the color of the button with ID <paramref name="id"/> in column <paramref name="column"/>. If the specified button does not exist, returns <c>Color.BLACK</c>.</para>
    /// </summary>
    public Color GetButtonColor(int column, int id)
    {
        return NativeCalls.godot_icall_2_734(MethodBind85, GodotObject.GetPtr(this), column, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButton, 2584904275ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Texture2D"/> of the button at index <paramref name="buttonIndex"/> in column <paramref name="column"/>.</para>
    /// </summary>
    public Texture2D GetButton(int column, int buttonIndex)
    {
        return (Texture2D)NativeCalls.godot_icall_2_101(MethodBind86, GodotObject.GetPtr(this), column, buttonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonTooltipText, 2285447957ul);

    /// <summary>
    /// <para>Sets the tooltip text for the button at index <paramref name="buttonIndex"/> in the given <paramref name="column"/>.</para>
    /// </summary>
    public void SetButtonTooltipText(int column, int buttonIndex, string tooltip)
    {
        NativeCalls.godot_icall_3_1313(MethodBind87, GodotObject.GetPtr(this), column, buttonIndex, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButton, 176101966ul);

    /// <summary>
    /// <para>Sets the given column's button <see cref="Godot.Texture2D"/> at index <paramref name="buttonIndex"/> to <paramref name="button"/>.</para>
    /// </summary>
    public void SetButton(int column, int buttonIndex, Texture2D button)
    {
        NativeCalls.godot_icall_3_100(MethodBind88, GodotObject.GetPtr(this), column, buttonIndex, GodotObject.GetPtr(button));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseButton, 3937882851ul);

    /// <summary>
    /// <para>Removes the button at index <paramref name="buttonIndex"/> in column <paramref name="column"/>.</para>
    /// </summary>
    public void EraseButton(int column, int buttonIndex)
    {
        NativeCalls.godot_icall_2_59(MethodBind89, GodotObject.GetPtr(this), column, buttonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonDescription, 2285447957ul);

    /// <summary>
    /// <para>Sets the given column's button description at index <paramref name="buttonIndex"/> for assistive apps.</para>
    /// </summary>
    public void SetButtonDescription(int column, int buttonIndex, string description)
    {
        NativeCalls.godot_icall_3_1313(MethodBind90, GodotObject.GetPtr(this), column, buttonIndex, description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonDisabled, 1383440665ul);

    /// <summary>
    /// <para>If <see langword="true"/>, disables the button at index <paramref name="buttonIndex"/> in the given <paramref name="column"/>.</para>
    /// </summary>
    public void SetButtonDisabled(int column, int buttonIndex, bool disabled)
    {
        NativeCalls.godot_icall_3_197(MethodBind91, GodotObject.GetPtr(this), column, buttonIndex, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonColor, 3733378741ul);

    /// <summary>
    /// <para>Sets the given column's button color at index <paramref name="buttonIndex"/> to <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void SetButtonColor(int column, int buttonIndex, Color color)
    {
        NativeCalls.godot_icall_3_736(MethodBind92, GodotObject.GetPtr(this), column, buttonIndex, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsButtonDisabled, 2522259332ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the button at index <paramref name="buttonIndex"/> for the given <paramref name="column"/> is disabled.</para>
    /// </summary>
    public bool IsButtonDisabled(int column, int buttonIndex)
    {
        return NativeCalls.godot_icall_2_40(MethodBind93, GodotObject.GetPtr(this), column, buttonIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTooltipText, 501894301ul);

    /// <summary>
    /// <para>Sets the given column's tooltip text.</para>
    /// </summary>
    public void SetTooltipText(int column, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind94, GodotObject.GetPtr(this), column, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTooltipText, 844755477ul);

    /// <summary>
    /// <para>Returns the given column's tooltip text.</para>
    /// </summary>
    public string GetTooltipText(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind95, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextAlignment, 3276431499ul);

    /// <summary>
    /// <para>Sets the given column's text alignment to <paramref name="textAlignment"/>.</para>
    /// </summary>
    public void SetTextAlignment(int column, HorizontalAlignment textAlignment)
    {
        NativeCalls.godot_icall_2_59(MethodBind96, GodotObject.GetPtr(this), column, (int)textAlignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextAlignment, 4171562184ul);

    /// <summary>
    /// <para>Returns the given column's text alignment.</para>
    /// </summary>
    public HorizontalAlignment GetTextAlignment(int column)
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_1_60(MethodBind97, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandRight, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enable"/> is <see langword="true"/>, the given <paramref name="column"/> is expanded to the right.</para>
    /// </summary>
    public void SetExpandRight(int column, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind98, GodotObject.GetPtr(this), column, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExpandRight, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <c>expand_right</c> is set.</para>
    /// </summary>
    public bool GetExpandRight(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind99, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableFolding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisableFolding(bool disable)
    {
        NativeCalls.godot_icall_1_14(MethodBind100, GodotObject.GetPtr(this), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFoldingDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFoldingDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind101, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateChild, 954243986ul);

    /// <summary>
    /// <para>Creates an item and adds it as a child.</para>
    /// <para>The new item will be inserted as position <paramref name="index"/> (the default value <c>-1</c> means the last position), or it will be the last child if <paramref name="index"/> is higher than the child count.</para>
    /// </summary>
    public TreeItem CreateChild(int index = -1)
    {
        return (TreeItem)NativeCalls.godot_icall_1_335(MethodBind102, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddChild, 1819951137ul);

    /// <summary>
    /// <para>Adds a previously unparented <see cref="Godot.TreeItem"/> as a direct child of this one. The <paramref name="child"/> item must not be a part of any <see cref="Godot.Tree"/> or parented to any <see cref="Godot.TreeItem"/>. See also <see cref="Godot.TreeItem.RemoveChild(TreeItem)"/>.</para>
    /// </summary>
    public void AddChild(TreeItem child)
    {
        NativeCalls.godot_icall_1_56(MethodBind103, GodotObject.GetPtr(this), GodotObject.GetPtr(child));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveChild, 1819951137ul);

    /// <summary>
    /// <para>Removes the given child <see cref="Godot.TreeItem"/> and all its children from the <see cref="Godot.Tree"/>. Note that it doesn't free the item from memory, so it can be reused later (see <see cref="Godot.TreeItem.AddChild(TreeItem)"/>). To completely remove a <see cref="Godot.TreeItem"/> use <see cref="Godot.GodotObject.Free()"/>.</para>
    /// <para><b>Note:</b> If you want to move a child from one <see cref="Godot.Tree"/> to another, then instead of removing and adding it manually you can use <see cref="Godot.TreeItem.MoveBefore(TreeItem)"/> or <see cref="Godot.TreeItem.MoveAfter(TreeItem)"/>.</para>
    /// </summary>
    public void RemoveChild(TreeItem child)
    {
        NativeCalls.godot_icall_1_56(MethodBind104, GodotObject.GetPtr(this), GodotObject.GetPtr(child));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTree, 2243340556ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Tree"/> that owns this TreeItem.</para>
    /// </summary>
    public Tree GetTree()
    {
        return (Tree)NativeCalls.godot_icall_0_53(MethodBind105, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNext, 1514277247ul);

    /// <summary>
    /// <para>Returns the next sibling TreeItem in the tree or a <see langword="null"/> object if there is none.</para>
    /// </summary>
    public TreeItem GetNext()
    {
        return (TreeItem)NativeCalls.godot_icall_0_53(MethodBind106, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrev, 2768121250ul);

    /// <summary>
    /// <para>Returns the previous sibling TreeItem in the tree or a <see langword="null"/> object if there is none.</para>
    /// </summary>
    public TreeItem GetPrev()
    {
        return (TreeItem)NativeCalls.godot_icall_0_53(MethodBind107, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParent, 1514277247ul);

    /// <summary>
    /// <para>Returns the parent TreeItem or a <see langword="null"/> object if there is none.</para>
    /// </summary>
    public TreeItem GetParent()
    {
        return (TreeItem)NativeCalls.godot_icall_0_53(MethodBind108, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFirstChild, 1514277247ul);

    /// <summary>
    /// <para>Returns the TreeItem's first child.</para>
    /// </summary>
    public TreeItem GetFirstChild()
    {
        return (TreeItem)NativeCalls.godot_icall_0_53(MethodBind109, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextInTree, 1666920593ul);

    /// <summary>
    /// <para>Returns the next TreeItem in the tree (in the context of a depth-first search) or a <see langword="null"/> object if there is none.</para>
    /// <para>If <paramref name="wrap"/> is enabled, the method will wrap around to the first element in the tree when called on the last element, otherwise it returns <see langword="null"/>.</para>
    /// </summary>
    public TreeItem GetNextInTree(bool wrap = false)
    {
        return (TreeItem)NativeCalls.godot_icall_1_223(MethodBind110, GodotObject.GetPtr(this), wrap.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrevInTree, 1666920593ul);

    /// <summary>
    /// <para>Returns the previous TreeItem in the tree (in the context of a depth-first search) or a <see langword="null"/> object if there is none.</para>
    /// <para>If <paramref name="wrap"/> is enabled, the method will wrap around to the last element in the tree when called on the first visible element, otherwise it returns <see langword="null"/>.</para>
    /// </summary>
    public TreeItem GetPrevInTree(bool wrap = false)
    {
        return (TreeItem)NativeCalls.godot_icall_1_223(MethodBind111, GodotObject.GetPtr(this), wrap.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextVisible, 1666920593ul);

    /// <summary>
    /// <para>Returns the next visible TreeItem in the tree (in the context of a depth-first search) or a <see langword="null"/> object if there is none.</para>
    /// <para>If <paramref name="wrap"/> is enabled, the method will wrap around to the first visible element in the tree when called on the last visible element, otherwise it returns <see langword="null"/>.</para>
    /// </summary>
    public TreeItem GetNextVisible(bool wrap = false)
    {
        return (TreeItem)NativeCalls.godot_icall_1_223(MethodBind112, GodotObject.GetPtr(this), wrap.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrevVisible, 1666920593ul);

    /// <summary>
    /// <para>Returns the previous visible sibling TreeItem in the tree (in the context of a depth-first search) or a <see langword="null"/> object if there is none.</para>
    /// <para>If <paramref name="wrap"/> is enabled, the method will wrap around to the last visible element in the tree when called on the first visible element, otherwise it returns <see langword="null"/>.</para>
    /// </summary>
    public TreeItem GetPrevVisible(bool wrap = false)
    {
        return (TreeItem)NativeCalls.godot_icall_1_223(MethodBind113, GodotObject.GetPtr(this), wrap.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChild, 306700752ul);

    /// <summary>
    /// <para>Returns a child item by its <paramref name="index"/> (see <see cref="Godot.TreeItem.GetChildCount()"/>). This method is often used for iterating all children of an item.</para>
    /// <para>Negative indices access the children from the last one.</para>
    /// </summary>
    public TreeItem GetChild(int index)
    {
        return (TreeItem)NativeCalls.godot_icall_1_335(MethodBind114, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChildCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of child items.</para>
    /// </summary>
    public int GetChildCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind115, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChildren, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of references to the item's children.</para>
    /// </summary>
    public Godot.Collections.Array<TreeItem> GetChildren()
    {
        return new Godot.Collections.Array<TreeItem>(NativeCalls.godot_icall_0_120(MethodBind116, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndex, 2455072627ul);

    /// <summary>
    /// <para>Returns the node's order in the tree. For example, if called on the first child item the position is <c>0</c>.</para>
    /// </summary>
    public int GetIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind117, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveBefore, 1819951137ul);

    /// <summary>
    /// <para>Moves this TreeItem right before the given <paramref name="item"/>.</para>
    /// <para><b>Note:</b> You can't move to the root or move the root.</para>
    /// </summary>
    public void MoveBefore(TreeItem item)
    {
        NativeCalls.godot_icall_1_56(MethodBind118, GodotObject.GetPtr(this), GodotObject.GetPtr(item));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveAfter, 1819951137ul);

    /// <summary>
    /// <para>Moves this TreeItem right after the given <paramref name="item"/>.</para>
    /// <para><b>Note:</b> You can't move to the root or move the root.</para>
    /// </summary>
    public void MoveAfter(TreeItem item)
    {
        NativeCalls.godot_icall_1_56(MethodBind119, GodotObject.GetPtr(this), GodotObject.GetPtr(item));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CallRecursive, 2866548813ul);

    /// <summary>
    /// <para>Calls the <paramref name="method"/> on the actual TreeItem and its children recursively. Pass parameters as a comma separated list.</para>
    /// </summary>
    public void CallRecursive(StringName method, params Variant[] @args)
    {
        NativeCalls.godot_icall_2_1480(MethodBind120, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallRecursive.NativeValue);
    }

    /// <summary>
    /// <para>Calls the <paramref name="method"/> on the actual TreeItem and its children recursively. Pass parameters as a comma separated list.</para>
    /// </summary>
    public void CallRecursive(StringName method, ReadOnlySpan<Variant> @args)
    {
        NativeCalls.godot_icall_2_1480(MethodBind120, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallRecursive.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddButton, 1688223362ul);

    /// <summary>
    /// <para>Adds a button with <see cref="Godot.Texture2D"/> <paramref name="button"/> to the end of the cell at column <paramref name="column"/>. The <paramref name="id"/> is used to identify the button in the according <see cref="Godot.Tree.ButtonClicked"/> signal and can be different from the buttons index. If not specified, the next available index is used, which may be retrieved by calling <see cref="Godot.TreeItem.GetButtonCount(int)"/> immediately before this method. Optionally, the button can be <paramref name="disabled"/> and have a <paramref name="tooltipText"/>. <paramref name="description"/> is used as the button description for assistive apps.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddButton(int column, Texture2D button, int id, bool disabled, string tooltipText)
    {
        NativeCalls.godot_icall_5_1481(MethodBind121, GodotObject.GetPtr(this), column, GodotObject.GetPtr(button), id, disabled.ToGodotBool(), tooltipText);
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
    public new class PropertyName : GodotObject.PropertyName
    {
        /// <summary>
        /// Cached name for the 'collapsed' property.
        /// </summary>
        public static readonly StringName Collapsed = "collapsed";
        /// <summary>
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
        /// <summary>
        /// Cached name for the 'disable_folding' property.
        /// </summary>
        public static readonly StringName DisableFolding = "disable_folding";
        /// <summary>
        /// Cached name for the 'custom_minimum_height' property.
        /// </summary>
        public static readonly StringName CustomMinimumHeight = "custom_minimum_height";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_cell_mode' method.
        /// </summary>
        public static readonly StringName SetCellMode = "set_cell_mode";
        /// <summary>
        /// Cached name for the 'get_cell_mode' method.
        /// </summary>
        public static readonly StringName GetCellMode = "get_cell_mode";
        /// <summary>
        /// Cached name for the 'set_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName SetAutoTranslateMode = "set_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'get_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName GetAutoTranslateMode = "get_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'set_edit_multiline' method.
        /// </summary>
        public static readonly StringName SetEditMultiline = "set_edit_multiline";
        /// <summary>
        /// Cached name for the 'is_edit_multiline' method.
        /// </summary>
        public static readonly StringName IsEditMultiline = "is_edit_multiline";
        /// <summary>
        /// Cached name for the 'set_checked' method.
        /// </summary>
        public static readonly StringName SetChecked = "set_checked";
        /// <summary>
        /// Cached name for the 'set_indeterminate' method.
        /// </summary>
        public static readonly StringName SetIndeterminate = "set_indeterminate";
        /// <summary>
        /// Cached name for the 'is_checked' method.
        /// </summary>
        public static readonly StringName IsChecked = "is_checked";
        /// <summary>
        /// Cached name for the 'is_indeterminate' method.
        /// </summary>
        public static readonly StringName IsIndeterminate = "is_indeterminate";
        /// <summary>
        /// Cached name for the 'propagate_check' method.
        /// </summary>
        public static readonly StringName PropagateCheck = "propagate_check";
        /// <summary>
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'set_description' method.
        /// </summary>
        public static readonly StringName SetDescription = "set_description";
        /// <summary>
        /// Cached name for the 'get_description' method.
        /// </summary>
        public static readonly StringName GetDescription = "get_description";
        /// <summary>
        /// Cached name for the 'set_text_direction' method.
        /// </summary>
        public static readonly StringName SetTextDirection = "set_text_direction";
        /// <summary>
        /// Cached name for the 'get_text_direction' method.
        /// </summary>
        public static readonly StringName GetTextDirection = "get_text_direction";
        /// <summary>
        /// Cached name for the 'set_autowrap_mode' method.
        /// </summary>
        public static readonly StringName SetAutowrapMode = "set_autowrap_mode";
        /// <summary>
        /// Cached name for the 'get_autowrap_mode' method.
        /// </summary>
        public static readonly StringName GetAutowrapMode = "get_autowrap_mode";
        /// <summary>
        /// Cached name for the 'set_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName SetTextOverrunBehavior = "set_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'get_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName GetTextOverrunBehavior = "get_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'set_structured_text_bidi_override' method.
        /// </summary>
        public static readonly StringName SetStructuredTextBidiOverride = "set_structured_text_bidi_override";
        /// <summary>
        /// Cached name for the 'get_structured_text_bidi_override' method.
        /// </summary>
        public static readonly StringName GetStructuredTextBidiOverride = "get_structured_text_bidi_override";
        /// <summary>
        /// Cached name for the 'set_structured_text_bidi_override_options' method.
        /// </summary>
        public static readonly StringName SetStructuredTextBidiOverrideOptions = "set_structured_text_bidi_override_options";
        /// <summary>
        /// Cached name for the 'get_structured_text_bidi_override_options' method.
        /// </summary>
        public static readonly StringName GetStructuredTextBidiOverrideOptions = "get_structured_text_bidi_override_options";
        /// <summary>
        /// Cached name for the 'set_language' method.
        /// </summary>
        public static readonly StringName SetLanguage = "set_language";
        /// <summary>
        /// Cached name for the 'get_language' method.
        /// </summary>
        public static readonly StringName GetLanguage = "get_language";
        /// <summary>
        /// Cached name for the 'set_suffix' method.
        /// </summary>
        public static readonly StringName SetSuffix = "set_suffix";
        /// <summary>
        /// Cached name for the 'get_suffix' method.
        /// </summary>
        public static readonly StringName GetSuffix = "get_suffix";
        /// <summary>
        /// Cached name for the 'set_icon' method.
        /// </summary>
        public static readonly StringName SetIcon = "set_icon";
        /// <summary>
        /// Cached name for the 'get_icon' method.
        /// </summary>
        public static readonly StringName GetIcon = "get_icon";
        /// <summary>
        /// Cached name for the 'set_icon_overlay' method.
        /// </summary>
        public static readonly StringName SetIconOverlay = "set_icon_overlay";
        /// <summary>
        /// Cached name for the 'get_icon_overlay' method.
        /// </summary>
        public static readonly StringName GetIconOverlay = "get_icon_overlay";
        /// <summary>
        /// Cached name for the 'set_icon_region' method.
        /// </summary>
        public static readonly StringName SetIconRegion = "set_icon_region";
        /// <summary>
        /// Cached name for the 'get_icon_region' method.
        /// </summary>
        public static readonly StringName GetIconRegion = "get_icon_region";
        /// <summary>
        /// Cached name for the 'set_icon_max_width' method.
        /// </summary>
        public static readonly StringName SetIconMaxWidth = "set_icon_max_width";
        /// <summary>
        /// Cached name for the 'get_icon_max_width' method.
        /// </summary>
        public static readonly StringName GetIconMaxWidth = "get_icon_max_width";
        /// <summary>
        /// Cached name for the 'set_icon_modulate' method.
        /// </summary>
        public static readonly StringName SetIconModulate = "set_icon_modulate";
        /// <summary>
        /// Cached name for the 'get_icon_modulate' method.
        /// </summary>
        public static readonly StringName GetIconModulate = "get_icon_modulate";
        /// <summary>
        /// Cached name for the 'set_range' method.
        /// </summary>
        public static readonly StringName SetRange = "set_range";
        /// <summary>
        /// Cached name for the 'get_range' method.
        /// </summary>
        public static readonly StringName GetRange = "get_range";
        /// <summary>
        /// Cached name for the 'set_range_config' method.
        /// </summary>
        public static readonly StringName SetRangeConfig = "set_range_config";
        /// <summary>
        /// Cached name for the 'get_range_config' method.
        /// </summary>
        public static readonly StringName GetRangeConfig = "get_range_config";
        /// <summary>
        /// Cached name for the 'set_metadata' method.
        /// </summary>
        public static readonly StringName SetMetadata = "set_metadata";
        /// <summary>
        /// Cached name for the 'get_metadata' method.
        /// </summary>
        public static readonly StringName GetMetadata = "get_metadata";
        /// <summary>
        /// Cached name for the 'set_custom_draw' method.
        /// </summary>
        public static readonly StringName SetCustomDraw = "set_custom_draw";
        /// <summary>
        /// Cached name for the 'set_custom_draw_callback' method.
        /// </summary>
        public static readonly StringName SetCustomDrawCallback = "set_custom_draw_callback";
        /// <summary>
        /// Cached name for the 'get_custom_draw_callback' method.
        /// </summary>
        public static readonly StringName GetCustomDrawCallback = "get_custom_draw_callback";
        /// <summary>
        /// Cached name for the 'set_custom_stylebox' method.
        /// </summary>
        public static readonly StringName SetCustomStylebox = "set_custom_stylebox";
        /// <summary>
        /// Cached name for the 'get_custom_stylebox' method.
        /// </summary>
        public static readonly StringName GetCustomStylebox = "get_custom_stylebox";
        /// <summary>
        /// Cached name for the 'set_collapsed' method.
        /// </summary>
        public static readonly StringName SetCollapsed = "set_collapsed";
        /// <summary>
        /// Cached name for the 'is_collapsed' method.
        /// </summary>
        public static readonly StringName IsCollapsed = "is_collapsed";
        /// <summary>
        /// Cached name for the 'set_collapsed_recursive' method.
        /// </summary>
        public static readonly StringName SetCollapsedRecursive = "set_collapsed_recursive";
        /// <summary>
        /// Cached name for the 'is_any_collapsed' method.
        /// </summary>
        public static readonly StringName IsAnyCollapsed = "is_any_collapsed";
        /// <summary>
        /// Cached name for the 'set_visible' method.
        /// </summary>
        public static readonly StringName SetVisible = "set_visible";
        /// <summary>
        /// Cached name for the 'is_visible' method.
        /// </summary>
        public static readonly StringName IsVisible = "is_visible";
        /// <summary>
        /// Cached name for the 'is_visible_in_tree' method.
        /// </summary>
        public static readonly StringName IsVisibleInTree = "is_visible_in_tree";
        /// <summary>
        /// Cached name for the 'uncollapse_tree' method.
        /// </summary>
        public static readonly StringName UncollapseTree = "uncollapse_tree";
        /// <summary>
        /// Cached name for the 'set_custom_minimum_height' method.
        /// </summary>
        public static readonly StringName SetCustomMinimumHeight = "set_custom_minimum_height";
        /// <summary>
        /// Cached name for the 'get_custom_minimum_height' method.
        /// </summary>
        public static readonly StringName GetCustomMinimumHeight = "get_custom_minimum_height";
        /// <summary>
        /// Cached name for the 'set_selectable' method.
        /// </summary>
        public static readonly StringName SetSelectable = "set_selectable";
        /// <summary>
        /// Cached name for the 'is_selectable' method.
        /// </summary>
        public static readonly StringName IsSelectable = "is_selectable";
        /// <summary>
        /// Cached name for the 'is_selected' method.
        /// </summary>
        public static readonly StringName IsSelected = "is_selected";
        /// <summary>
        /// Cached name for the 'select' method.
        /// </summary>
        public static readonly StringName Select = "select";
        /// <summary>
        /// Cached name for the 'deselect' method.
        /// </summary>
        public static readonly StringName Deselect = "deselect";
        /// <summary>
        /// Cached name for the 'set_editable' method.
        /// </summary>
        public static readonly StringName SetEditable = "set_editable";
        /// <summary>
        /// Cached name for the 'is_editable' method.
        /// </summary>
        public static readonly StringName IsEditable = "is_editable";
        /// <summary>
        /// Cached name for the 'set_custom_color' method.
        /// </summary>
        public static readonly StringName SetCustomColor = "set_custom_color";
        /// <summary>
        /// Cached name for the 'get_custom_color' method.
        /// </summary>
        public static readonly StringName GetCustomColor = "get_custom_color";
        /// <summary>
        /// Cached name for the 'clear_custom_color' method.
        /// </summary>
        public static readonly StringName ClearCustomColor = "clear_custom_color";
        /// <summary>
        /// Cached name for the 'set_custom_font' method.
        /// </summary>
        public static readonly StringName SetCustomFont = "set_custom_font";
        /// <summary>
        /// Cached name for the 'get_custom_font' method.
        /// </summary>
        public static readonly StringName GetCustomFont = "get_custom_font";
        /// <summary>
        /// Cached name for the 'set_custom_font_size' method.
        /// </summary>
        public static readonly StringName SetCustomFontSize = "set_custom_font_size";
        /// <summary>
        /// Cached name for the 'get_custom_font_size' method.
        /// </summary>
        public static readonly StringName GetCustomFontSize = "get_custom_font_size";
        /// <summary>
        /// Cached name for the 'set_custom_bg_color' method.
        /// </summary>
        public static readonly StringName SetCustomBgColor = "set_custom_bg_color";
        /// <summary>
        /// Cached name for the 'clear_custom_bg_color' method.
        /// </summary>
        public static readonly StringName ClearCustomBgColor = "clear_custom_bg_color";
        /// <summary>
        /// Cached name for the 'get_custom_bg_color' method.
        /// </summary>
        public static readonly StringName GetCustomBgColor = "get_custom_bg_color";
        /// <summary>
        /// Cached name for the 'set_custom_as_button' method.
        /// </summary>
        public static readonly StringName SetCustomAsButton = "set_custom_as_button";
        /// <summary>
        /// Cached name for the 'is_custom_set_as_button' method.
        /// </summary>
        public static readonly StringName IsCustomSetAsButton = "is_custom_set_as_button";
        /// <summary>
        /// Cached name for the 'clear_buttons' method.
        /// </summary>
        public static readonly StringName ClearButtons = "clear_buttons";
        /// <summary>
        /// Cached name for the 'add_button' method.
        /// </summary>
        public static readonly StringName AddButton = "add_button";
        /// <summary>
        /// Cached name for the 'get_button_count' method.
        /// </summary>
        public static readonly StringName GetButtonCount = "get_button_count";
        /// <summary>
        /// Cached name for the 'get_button_tooltip_text' method.
        /// </summary>
        public static readonly StringName GetButtonTooltipText = "get_button_tooltip_text";
        /// <summary>
        /// Cached name for the 'get_button_id' method.
        /// </summary>
        public static readonly StringName GetButtonId = "get_button_id";
        /// <summary>
        /// Cached name for the 'get_button_by_id' method.
        /// </summary>
        public static readonly StringName GetButtonById = "get_button_by_id";
        /// <summary>
        /// Cached name for the 'get_button_color' method.
        /// </summary>
        public static readonly StringName GetButtonColor = "get_button_color";
        /// <summary>
        /// Cached name for the 'get_button' method.
        /// </summary>
        public static readonly StringName GetButton = "get_button";
        /// <summary>
        /// Cached name for the 'set_button_tooltip_text' method.
        /// </summary>
        public static readonly StringName SetButtonTooltipText = "set_button_tooltip_text";
        /// <summary>
        /// Cached name for the 'set_button' method.
        /// </summary>
        public static readonly StringName SetButton = "set_button";
        /// <summary>
        /// Cached name for the 'erase_button' method.
        /// </summary>
        public static readonly StringName EraseButton = "erase_button";
        /// <summary>
        /// Cached name for the 'set_button_description' method.
        /// </summary>
        public static readonly StringName SetButtonDescription = "set_button_description";
        /// <summary>
        /// Cached name for the 'set_button_disabled' method.
        /// </summary>
        public static readonly StringName SetButtonDisabled = "set_button_disabled";
        /// <summary>
        /// Cached name for the 'set_button_color' method.
        /// </summary>
        public static readonly StringName SetButtonColor = "set_button_color";
        /// <summary>
        /// Cached name for the 'is_button_disabled' method.
        /// </summary>
        public static readonly StringName IsButtonDisabled = "is_button_disabled";
        /// <summary>
        /// Cached name for the 'set_tooltip_text' method.
        /// </summary>
        public static readonly StringName SetTooltipText = "set_tooltip_text";
        /// <summary>
        /// Cached name for the 'get_tooltip_text' method.
        /// </summary>
        public static readonly StringName GetTooltipText = "get_tooltip_text";
        /// <summary>
        /// Cached name for the 'set_text_alignment' method.
        /// </summary>
        public static readonly StringName SetTextAlignment = "set_text_alignment";
        /// <summary>
        /// Cached name for the 'get_text_alignment' method.
        /// </summary>
        public static readonly StringName GetTextAlignment = "get_text_alignment";
        /// <summary>
        /// Cached name for the 'set_expand_right' method.
        /// </summary>
        public static readonly StringName SetExpandRight = "set_expand_right";
        /// <summary>
        /// Cached name for the 'get_expand_right' method.
        /// </summary>
        public static readonly StringName GetExpandRight = "get_expand_right";
        /// <summary>
        /// Cached name for the 'set_disable_folding' method.
        /// </summary>
        public static readonly StringName SetDisableFolding = "set_disable_folding";
        /// <summary>
        /// Cached name for the 'is_folding_disabled' method.
        /// </summary>
        public static readonly StringName IsFoldingDisabled = "is_folding_disabled";
        /// <summary>
        /// Cached name for the 'create_child' method.
        /// </summary>
        public static readonly StringName CreateChild = "create_child";
        /// <summary>
        /// Cached name for the 'add_child' method.
        /// </summary>
        public static readonly StringName AddChild = "add_child";
        /// <summary>
        /// Cached name for the 'remove_child' method.
        /// </summary>
        public static readonly StringName RemoveChild = "remove_child";
        /// <summary>
        /// Cached name for the 'get_tree' method.
        /// </summary>
        public static readonly StringName GetTree = "get_tree";
        /// <summary>
        /// Cached name for the 'get_next' method.
        /// </summary>
        public static readonly StringName GetNext = "get_next";
        /// <summary>
        /// Cached name for the 'get_prev' method.
        /// </summary>
        public static readonly StringName GetPrev = "get_prev";
        /// <summary>
        /// Cached name for the 'get_parent' method.
        /// </summary>
        public static readonly StringName GetParent = "get_parent";
        /// <summary>
        /// Cached name for the 'get_first_child' method.
        /// </summary>
        public static readonly StringName GetFirstChild = "get_first_child";
        /// <summary>
        /// Cached name for the 'get_next_in_tree' method.
        /// </summary>
        public static readonly StringName GetNextInTree = "get_next_in_tree";
        /// <summary>
        /// Cached name for the 'get_prev_in_tree' method.
        /// </summary>
        public static readonly StringName GetPrevInTree = "get_prev_in_tree";
        /// <summary>
        /// Cached name for the 'get_next_visible' method.
        /// </summary>
        public static readonly StringName GetNextVisible = "get_next_visible";
        /// <summary>
        /// Cached name for the 'get_prev_visible' method.
        /// </summary>
        public static readonly StringName GetPrevVisible = "get_prev_visible";
        /// <summary>
        /// Cached name for the 'get_child' method.
        /// </summary>
        public static readonly StringName GetChild = "get_child";
        /// <summary>
        /// Cached name for the 'get_child_count' method.
        /// </summary>
        public static readonly StringName GetChildCount = "get_child_count";
        /// <summary>
        /// Cached name for the 'get_children' method.
        /// </summary>
        public static readonly StringName GetChildren = "get_children";
        /// <summary>
        /// Cached name for the 'get_index' method.
        /// </summary>
        public static readonly StringName GetIndex = "get_index";
        /// <summary>
        /// Cached name for the 'move_before' method.
        /// </summary>
        public static readonly StringName MoveBefore = "move_before";
        /// <summary>
        /// Cached name for the 'move_after' method.
        /// </summary>
        public static readonly StringName MoveAfter = "move_after";
        /// <summary>
        /// Cached name for the 'call_recursive' method.
        /// </summary>
        public static readonly StringName CallRecursive = "call_recursive";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
