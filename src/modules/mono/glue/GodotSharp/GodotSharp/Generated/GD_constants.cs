namespace Godot;

public static partial class GD
{
}

public enum Side : long
{
    /// <summary>
    /// <para>Left side, usually used for <see cref="Godot.Control"/> or <see cref="Godot.StyleBox"/>-derived classes.</para>
    /// </summary>
    Left = 0,
    /// <summary>
    /// <para>Top side, usually used for <see cref="Godot.Control"/> or <see cref="Godot.StyleBox"/>-derived classes.</para>
    /// </summary>
    Top = 1,
    /// <summary>
    /// <para>Right side, usually used for <see cref="Godot.Control"/> or <see cref="Godot.StyleBox"/>-derived classes.</para>
    /// </summary>
    Right = 2,
    /// <summary>
    /// <para>Bottom side, usually used for <see cref="Godot.Control"/> or <see cref="Godot.StyleBox"/>-derived classes.</para>
    /// </summary>
    Bottom = 3,
}

public enum Corner : long
{
    /// <summary>
    /// <para>Top-left corner.</para>
    /// </summary>
    TopLeft = 0,
    /// <summary>
    /// <para>Top-right corner.</para>
    /// </summary>
    TopRight = 1,
    /// <summary>
    /// <para>Bottom-right corner.</para>
    /// </summary>
    BottomRight = 2,
    /// <summary>
    /// <para>Bottom-left corner.</para>
    /// </summary>
    BottomLeft = 3,
}

public enum Orientation : long
{
    /// <summary>
    /// <para>General vertical alignment, usually used for <see cref="Godot.Separator"/>, <see cref="Godot.ScrollBar"/>, <see cref="Godot.Slider"/>, etc.</para>
    /// </summary>
    Vertical = 1,
    /// <summary>
    /// <para>General horizontal alignment, usually used for <see cref="Godot.Separator"/>, <see cref="Godot.ScrollBar"/>, <see cref="Godot.Slider"/>, etc.</para>
    /// </summary>
    Horizontal = 0,
}

public enum ClockDirection : long
{
    /// <summary>
    /// <para>Clockwise rotation. Used by some methods (e.g. <see cref="Godot.Image.Rotate90(ClockDirection)"/>).</para>
    /// </summary>
    Clockwise = 0,
    /// <summary>
    /// <para>Counter-clockwise rotation. Used by some methods (e.g. <see cref="Godot.Image.Rotate90(ClockDirection)"/>).</para>
    /// </summary>
    Counterclockwise = 1,
}

public enum HorizontalAlignment : long
{
    /// <summary>
    /// <para>Horizontal left alignment, usually for text-derived classes.</para>
    /// </summary>
    Left = 0,
    /// <summary>
    /// <para>Horizontal center alignment, usually for text-derived classes.</para>
    /// </summary>
    Center = 1,
    /// <summary>
    /// <para>Horizontal right alignment, usually for text-derived classes.</para>
    /// </summary>
    Right = 2,
    /// <summary>
    /// <para>Expand row to fit width, usually for text-derived classes.</para>
    /// </summary>
    Fill = 3,
}

public enum VerticalAlignment : long
{
    /// <summary>
    /// <para>Vertical top alignment, usually for text-derived classes.</para>
    /// </summary>
    Top = 0,
    /// <summary>
    /// <para>Vertical center alignment, usually for text-derived classes.</para>
    /// </summary>
    Center = 1,
    /// <summary>
    /// <para>Vertical bottom alignment, usually for text-derived classes.</para>
    /// </summary>
    Bottom = 2,
    /// <summary>
    /// <para>Expand rows to fit height, usually for text-derived classes.</para>
    /// </summary>
    Fill = 3,
}

public enum InlineAlignment : long
{
    /// <summary>
    /// <para>Aligns the top of the inline object (e.g. image, table) to the position of the text specified by <c>INLINE_ALIGNMENT_TO_*</c> constant.</para>
    /// </summary>
    TopTo = 0,
    /// <summary>
    /// <para>Aligns the center of the inline object (e.g. image, table) to the position of the text specified by <c>INLINE_ALIGNMENT_TO_*</c> constant.</para>
    /// </summary>
    CenterTo = 1,
    /// <summary>
    /// <para>Aligns the baseline (user defined) of the inline object (e.g. image, table) to the position of the text specified by <c>INLINE_ALIGNMENT_TO_*</c> constant.</para>
    /// </summary>
    BaselineTo = 3,
    /// <summary>
    /// <para>Aligns the bottom of the inline object (e.g. image, table) to the position of the text specified by <c>INLINE_ALIGNMENT_TO_*</c> constant.</para>
    /// </summary>
    BottomTo = 2,
    /// <summary>
    /// <para>Aligns the position of the inline object (e.g. image, table) specified by <c>INLINE_ALIGNMENT_*_TO</c> constant to the top of the text.</para>
    /// </summary>
    ToTop = 0,
    /// <summary>
    /// <para>Aligns the position of the inline object (e.g. image, table) specified by <c>INLINE_ALIGNMENT_*_TO</c> constant to the center of the text.</para>
    /// </summary>
    ToCenter = 4,
    /// <summary>
    /// <para>Aligns the position of the inline object (e.g. image, table) specified by <c>INLINE_ALIGNMENT_*_TO</c> constant to the baseline of the text.</para>
    /// </summary>
    ToBaseline = 8,
    /// <summary>
    /// <para>Aligns inline object (e.g. image, table) to the bottom of the text.</para>
    /// </summary>
    ToBottom = 12,
    /// <summary>
    /// <para>Aligns top of the inline object (e.g. image, table) to the top of the text. Equivalent to <c>INLINE_ALIGNMENT_TOP_TO | INLINE_ALIGNMENT_TO_TOP</c>.</para>
    /// </summary>
    Top = 0,
    /// <summary>
    /// <para>Aligns center of the inline object (e.g. image, table) to the center of the text. Equivalent to <c>INLINE_ALIGNMENT_CENTER_TO | INLINE_ALIGNMENT_TO_CENTER</c>.</para>
    /// </summary>
    Center = 5,
    /// <summary>
    /// <para>Aligns bottom of the inline object (e.g. image, table) to the bottom of the text. Equivalent to <c>INLINE_ALIGNMENT_BOTTOM_TO | INLINE_ALIGNMENT_TO_BOTTOM</c>.</para>
    /// </summary>
    Bottom = 14,
    /// <summary>
    /// <para>A bit mask for <c>INLINE_ALIGNMENT_*_TO</c> alignment constants.</para>
    /// </summary>
    ImageMask = 3,
    /// <summary>
    /// <para>A bit mask for <c>INLINE_ALIGNMENT_TO_*</c> alignment constants.</para>
    /// </summary>
    TextMask = 12,
}

public enum EulerOrder : long
{
    /// <summary>
    /// <para>Specifies that Euler angles should be in XYZ order. When composing, the order is X, Y, Z. When decomposing, the order is reversed, first Z, then Y, and X last.</para>
    /// </summary>
    Xyz = 0,
    /// <summary>
    /// <para>Specifies that Euler angles should be in XZY order. When composing, the order is X, Z, Y. When decomposing, the order is reversed, first Y, then Z, and X last.</para>
    /// </summary>
    Xzy = 1,
    /// <summary>
    /// <para>Specifies that Euler angles should be in YXZ order. When composing, the order is Y, X, Z. When decomposing, the order is reversed, first Z, then X, and Y last.</para>
    /// </summary>
    Yxz = 2,
    /// <summary>
    /// <para>Specifies that Euler angles should be in YZX order. When composing, the order is Y, Z, X. When decomposing, the order is reversed, first X, then Z, and Y last.</para>
    /// </summary>
    Yzx = 3,
    /// <summary>
    /// <para>Specifies that Euler angles should be in ZXY order. When composing, the order is Z, X, Y. When decomposing, the order is reversed, first Y, then X, and Z last.</para>
    /// </summary>
    Zxy = 4,
    /// <summary>
    /// <para>Specifies that Euler angles should be in ZYX order. When composing, the order is Z, Y, X. When decomposing, the order is reversed, first X, then Y, and Z last.</para>
    /// </summary>
    Zyx = 5,
}

public enum Key : long
{
    /// <summary>
    /// <para>Enum value which doesn't correspond to any key. This is used to initialize <see cref="Godot.Key"/> properties with a generic state.</para>
    /// </summary>
    None = 0,
    /// <summary>
    /// <para>Keycodes with this bit applied are non-printable.</para>
    /// </summary>
    Special = 4194304,
    /// <summary>
    /// <para>Escape key.</para>
    /// </summary>
    Escape = 4194305,
    /// <summary>
    /// <para>Tab key.</para>
    /// </summary>
    Tab = 4194306,
    /// <summary>
    /// <para>Shift + Tab key.</para>
    /// </summary>
    Backtab = 4194307,
    /// <summary>
    /// <para>Backspace key.</para>
    /// </summary>
    Backspace = 4194308,
    /// <summary>
    /// <para>Return key (on the main keyboard).</para>
    /// </summary>
    Enter = 4194309,
    /// <summary>
    /// <para>Enter key on the numeric keypad.</para>
    /// </summary>
    KpEnter = 4194310,
    /// <summary>
    /// <para>Insert key.</para>
    /// </summary>
    Insert = 4194311,
    /// <summary>
    /// <para>Delete key.</para>
    /// </summary>
    Delete = 4194312,
    /// <summary>
    /// <para>Pause key.</para>
    /// </summary>
    Pause = 4194313,
    /// <summary>
    /// <para>Print Screen key.</para>
    /// </summary>
    Print = 4194314,
    /// <summary>
    /// <para>System Request key.</para>
    /// </summary>
    Sysreq = 4194315,
    /// <summary>
    /// <para>Clear key.</para>
    /// </summary>
    Clear = 4194316,
    /// <summary>
    /// <para>Home key.</para>
    /// </summary>
    Home = 4194317,
    /// <summary>
    /// <para>End key.</para>
    /// </summary>
    End = 4194318,
    /// <summary>
    /// <para>Left arrow key.</para>
    /// </summary>
    Left = 4194319,
    /// <summary>
    /// <para>Up arrow key.</para>
    /// </summary>
    Up = 4194320,
    /// <summary>
    /// <para>Right arrow key.</para>
    /// </summary>
    Right = 4194321,
    /// <summary>
    /// <para>Down arrow key.</para>
    /// </summary>
    Down = 4194322,
    /// <summary>
    /// <para>Page Up key.</para>
    /// </summary>
    Pageup = 4194323,
    /// <summary>
    /// <para>Page Down key.</para>
    /// </summary>
    Pagedown = 4194324,
    /// <summary>
    /// <para>Shift key.</para>
    /// </summary>
    Shift = 4194325,
    /// <summary>
    /// <para>Control key.</para>
    /// </summary>
    Ctrl = 4194326,
    /// <summary>
    /// <para>Meta key.</para>
    /// </summary>
    Meta = 4194327,
    /// <summary>
    /// <para>Alt key.</para>
    /// </summary>
    Alt = 4194328,
    /// <summary>
    /// <para>Caps Lock key.</para>
    /// </summary>
    Capslock = 4194329,
    /// <summary>
    /// <para>Num Lock key.</para>
    /// </summary>
    Numlock = 4194330,
    /// <summary>
    /// <para>Scroll Lock key.</para>
    /// </summary>
    Scrolllock = 4194331,
    /// <summary>
    /// <para>F1 key.</para>
    /// </summary>
    F1 = 4194332,
    /// <summary>
    /// <para>F2 key.</para>
    /// </summary>
    F2 = 4194333,
    /// <summary>
    /// <para>F3 key.</para>
    /// </summary>
    F3 = 4194334,
    /// <summary>
    /// <para>F4 key.</para>
    /// </summary>
    F4 = 4194335,
    /// <summary>
    /// <para>F5 key.</para>
    /// </summary>
    F5 = 4194336,
    /// <summary>
    /// <para>F6 key.</para>
    /// </summary>
    F6 = 4194337,
    /// <summary>
    /// <para>F7 key.</para>
    /// </summary>
    F7 = 4194338,
    /// <summary>
    /// <para>F8 key.</para>
    /// </summary>
    F8 = 4194339,
    /// <summary>
    /// <para>F9 key.</para>
    /// </summary>
    F9 = 4194340,
    /// <summary>
    /// <para>F10 key.</para>
    /// </summary>
    F10 = 4194341,
    /// <summary>
    /// <para>F11 key.</para>
    /// </summary>
    F11 = 4194342,
    /// <summary>
    /// <para>F12 key.</para>
    /// </summary>
    F12 = 4194343,
    /// <summary>
    /// <para>F13 key.</para>
    /// </summary>
    F13 = 4194344,
    /// <summary>
    /// <para>F14 key.</para>
    /// </summary>
    F14 = 4194345,
    /// <summary>
    /// <para>F15 key.</para>
    /// </summary>
    F15 = 4194346,
    /// <summary>
    /// <para>F16 key.</para>
    /// </summary>
    F16 = 4194347,
    /// <summary>
    /// <para>F17 key.</para>
    /// </summary>
    F17 = 4194348,
    /// <summary>
    /// <para>F18 key.</para>
    /// </summary>
    F18 = 4194349,
    /// <summary>
    /// <para>F19 key.</para>
    /// </summary>
    F19 = 4194350,
    /// <summary>
    /// <para>F20 key.</para>
    /// </summary>
    F20 = 4194351,
    /// <summary>
    /// <para>F21 key.</para>
    /// </summary>
    F21 = 4194352,
    /// <summary>
    /// <para>F22 key.</para>
    /// </summary>
    F22 = 4194353,
    /// <summary>
    /// <para>F23 key.</para>
    /// </summary>
    F23 = 4194354,
    /// <summary>
    /// <para>F24 key.</para>
    /// </summary>
    F24 = 4194355,
    /// <summary>
    /// <para>F25 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F25 = 4194356,
    /// <summary>
    /// <para>F26 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F26 = 4194357,
    /// <summary>
    /// <para>F27 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F27 = 4194358,
    /// <summary>
    /// <para>F28 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F28 = 4194359,
    /// <summary>
    /// <para>F29 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F29 = 4194360,
    /// <summary>
    /// <para>F30 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F30 = 4194361,
    /// <summary>
    /// <para>F31 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F31 = 4194362,
    /// <summary>
    /// <para>F32 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F32 = 4194363,
    /// <summary>
    /// <para>F33 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F33 = 4194364,
    /// <summary>
    /// <para>F34 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F34 = 4194365,
    /// <summary>
    /// <para>F35 key. Only supported on macOS and Linux due to a Windows limitation.</para>
    /// </summary>
    F35 = 4194366,
    /// <summary>
    /// <para>Multiply (*) key on the numeric keypad.</para>
    /// </summary>
    KpMultiply = 4194433,
    /// <summary>
    /// <para>Divide (/) key on the numeric keypad.</para>
    /// </summary>
    KpDivide = 4194434,
    /// <summary>
    /// <para>Subtract (-) key on the numeric keypad.</para>
    /// </summary>
    KpSubtract = 4194435,
    /// <summary>
    /// <para>Period (.) key on the numeric keypad.</para>
    /// </summary>
    KpPeriod = 4194436,
    /// <summary>
    /// <para>Add (+) key on the numeric keypad.</para>
    /// </summary>
    KpAdd = 4194437,
    /// <summary>
    /// <para>Number 0 on the numeric keypad.</para>
    /// </summary>
    Kp0 = 4194438,
    /// <summary>
    /// <para>Number 1 on the numeric keypad.</para>
    /// </summary>
    Kp1 = 4194439,
    /// <summary>
    /// <para>Number 2 on the numeric keypad.</para>
    /// </summary>
    Kp2 = 4194440,
    /// <summary>
    /// <para>Number 3 on the numeric keypad.</para>
    /// </summary>
    Kp3 = 4194441,
    /// <summary>
    /// <para>Number 4 on the numeric keypad.</para>
    /// </summary>
    Kp4 = 4194442,
    /// <summary>
    /// <para>Number 5 on the numeric keypad.</para>
    /// </summary>
    Kp5 = 4194443,
    /// <summary>
    /// <para>Number 6 on the numeric keypad.</para>
    /// </summary>
    Kp6 = 4194444,
    /// <summary>
    /// <para>Number 7 on the numeric keypad.</para>
    /// </summary>
    Kp7 = 4194445,
    /// <summary>
    /// <para>Number 8 on the numeric keypad.</para>
    /// </summary>
    Kp8 = 4194446,
    /// <summary>
    /// <para>Number 9 on the numeric keypad.</para>
    /// </summary>
    Kp9 = 4194447,
    /// <summary>
    /// <para>Context menu key.</para>
    /// </summary>
    Menu = 4194370,
    /// <summary>
    /// <para>Hyper key. (On Linux/X11 only).</para>
    /// </summary>
    Hyper = 4194371,
    /// <summary>
    /// <para>Help key.</para>
    /// </summary>
    Help = 4194373,
    /// <summary>
    /// <para>Back key.</para>
    /// </summary>
    Back = 4194376,
    /// <summary>
    /// <para>Forward key.</para>
    /// </summary>
    Forward = 4194377,
    /// <summary>
    /// <para>Media stop key.</para>
    /// </summary>
    Stop = 4194378,
    /// <summary>
    /// <para>Refresh key.</para>
    /// </summary>
    Refresh = 4194379,
    /// <summary>
    /// <para>Volume down key.</para>
    /// </summary>
    Volumedown = 4194380,
    /// <summary>
    /// <para>Mute volume key.</para>
    /// </summary>
    Volumemute = 4194381,
    /// <summary>
    /// <para>Volume up key.</para>
    /// </summary>
    Volumeup = 4194382,
    /// <summary>
    /// <para>Media play key.</para>
    /// </summary>
    Mediaplay = 4194388,
    /// <summary>
    /// <para>Media stop key.</para>
    /// </summary>
    Mediastop = 4194389,
    /// <summary>
    /// <para>Previous song key.</para>
    /// </summary>
    Mediaprevious = 4194390,
    /// <summary>
    /// <para>Next song key.</para>
    /// </summary>
    Medianext = 4194391,
    /// <summary>
    /// <para>Media record key.</para>
    /// </summary>
    Mediarecord = 4194392,
    /// <summary>
    /// <para>Home page key.</para>
    /// </summary>
    Homepage = 4194393,
    /// <summary>
    /// <para>Favorites key.</para>
    /// </summary>
    Favorites = 4194394,
    /// <summary>
    /// <para>Search key.</para>
    /// </summary>
    Search = 4194395,
    /// <summary>
    /// <para>Standby key.</para>
    /// </summary>
    Standby = 4194396,
    /// <summary>
    /// <para>Open URL / Launch Browser key.</para>
    /// </summary>
    Openurl = 4194397,
    /// <summary>
    /// <para>Launch Mail key.</para>
    /// </summary>
    Launchmail = 4194398,
    /// <summary>
    /// <para>Launch Media key.</para>
    /// </summary>
    Launchmedia = 4194399,
    /// <summary>
    /// <para>Launch Shortcut 0 key.</para>
    /// </summary>
    Launch0 = 4194400,
    /// <summary>
    /// <para>Launch Shortcut 1 key.</para>
    /// </summary>
    Launch1 = 4194401,
    /// <summary>
    /// <para>Launch Shortcut 2 key.</para>
    /// </summary>
    Launch2 = 4194402,
    /// <summary>
    /// <para>Launch Shortcut 3 key.</para>
    /// </summary>
    Launch3 = 4194403,
    /// <summary>
    /// <para>Launch Shortcut 4 key.</para>
    /// </summary>
    Launch4 = 4194404,
    /// <summary>
    /// <para>Launch Shortcut 5 key.</para>
    /// </summary>
    Launch5 = 4194405,
    /// <summary>
    /// <para>Launch Shortcut 6 key.</para>
    /// </summary>
    Launch6 = 4194406,
    /// <summary>
    /// <para>Launch Shortcut 7 key.</para>
    /// </summary>
    Launch7 = 4194407,
    /// <summary>
    /// <para>Launch Shortcut 8 key.</para>
    /// </summary>
    Launch8 = 4194408,
    /// <summary>
    /// <para>Launch Shortcut 9 key.</para>
    /// </summary>
    Launch9 = 4194409,
    /// <summary>
    /// <para>Launch Shortcut A key.</para>
    /// </summary>
    Launcha = 4194410,
    /// <summary>
    /// <para>Launch Shortcut B key.</para>
    /// </summary>
    Launchb = 4194411,
    /// <summary>
    /// <para>Launch Shortcut C key.</para>
    /// </summary>
    Launchc = 4194412,
    /// <summary>
    /// <para>Launch Shortcut D key.</para>
    /// </summary>
    Launchd = 4194413,
    /// <summary>
    /// <para>Launch Shortcut E key.</para>
    /// </summary>
    Launche = 4194414,
    /// <summary>
    /// <para>Launch Shortcut F key.</para>
    /// </summary>
    Launchf = 4194415,
    /// <summary>
    /// <para>"Globe" key on Mac / iPad keyboard.</para>
    /// </summary>
    Globe = 4194416,
    /// <summary>
    /// <para>"On-screen keyboard" key on iPad keyboard.</para>
    /// </summary>
    Keyboard = 4194417,
    /// <summary>
    /// <para>英数 key on Mac keyboard.</para>
    /// </summary>
    JisEisu = 4194418,
    /// <summary>
    /// <para>かな key on Mac keyboard.</para>
    /// </summary>
    JisKana = 4194419,
    /// <summary>
    /// <para>Unknown key.</para>
    /// </summary>
    Unknown = 8388607,
    /// <summary>
    /// <para>Space key.</para>
    /// </summary>
    Space = 32,
    /// <summary>
    /// <para>Exclamation mark (<c>!</c>) key.</para>
    /// </summary>
    Exclam = 33,
    /// <summary>
    /// <para>Double quotation mark (<c>"</c>) key.</para>
    /// </summary>
    Quotedbl = 34,
    /// <summary>
    /// <para>Number sign or <i>hash</i> (<c>#</c>) key.</para>
    /// </summary>
    Numbersign = 35,
    /// <summary>
    /// <para>Dollar sign (<c>$</c>) key.</para>
    /// </summary>
    Dollar = 36,
    /// <summary>
    /// <para>Percent sign (<c>%</c>) key.</para>
    /// </summary>
    Percent = 37,
    /// <summary>
    /// <para>Ampersand (<c>&amp;</c>) key.</para>
    /// </summary>
    Ampersand = 38,
    /// <summary>
    /// <para>Apostrophe (<c>'</c>) key.</para>
    /// </summary>
    Apostrophe = 39,
    /// <summary>
    /// <para>Left parenthesis (<c>(</c>) key.</para>
    /// </summary>
    Parenleft = 40,
    /// <summary>
    /// <para>Right parenthesis (<c>)</c>) key.</para>
    /// </summary>
    Parenright = 41,
    /// <summary>
    /// <para>Asterisk (<c>*</c>) key.</para>
    /// </summary>
    Asterisk = 42,
    /// <summary>
    /// <para>Plus (<c>+</c>) key.</para>
    /// </summary>
    Plus = 43,
    /// <summary>
    /// <para>Comma (<c>,</c>) key.</para>
    /// </summary>
    Comma = 44,
    /// <summary>
    /// <para>Minus (<c>-</c>) key.</para>
    /// </summary>
    Minus = 45,
    /// <summary>
    /// <para>Period (<c>.</c>) key.</para>
    /// </summary>
    Period = 46,
    /// <summary>
    /// <para>Slash (<c>/</c>) key.</para>
    /// </summary>
    Slash = 47,
    /// <summary>
    /// <para>Number 0 key.</para>
    /// </summary>
    Key0 = 48,
    /// <summary>
    /// <para>Number 1 key.</para>
    /// </summary>
    Key1 = 49,
    /// <summary>
    /// <para>Number 2 key.</para>
    /// </summary>
    Key2 = 50,
    /// <summary>
    /// <para>Number 3 key.</para>
    /// </summary>
    Key3 = 51,
    /// <summary>
    /// <para>Number 4 key.</para>
    /// </summary>
    Key4 = 52,
    /// <summary>
    /// <para>Number 5 key.</para>
    /// </summary>
    Key5 = 53,
    /// <summary>
    /// <para>Number 6 key.</para>
    /// </summary>
    Key6 = 54,
    /// <summary>
    /// <para>Number 7 key.</para>
    /// </summary>
    Key7 = 55,
    /// <summary>
    /// <para>Number 8 key.</para>
    /// </summary>
    Key8 = 56,
    /// <summary>
    /// <para>Number 9 key.</para>
    /// </summary>
    Key9 = 57,
    /// <summary>
    /// <para>Colon (<c>:</c>) key.</para>
    /// </summary>
    Colon = 58,
    /// <summary>
    /// <para>Semicolon (<c>;</c>) key.</para>
    /// </summary>
    Semicolon = 59,
    /// <summary>
    /// <para>Less-than sign (<c>&lt;</c>) key.</para>
    /// </summary>
    Less = 60,
    /// <summary>
    /// <para>Equal sign (<c>=</c>) key.</para>
    /// </summary>
    Equal = 61,
    /// <summary>
    /// <para>Greater-than sign (<c>&gt;</c>) key.</para>
    /// </summary>
    Greater = 62,
    /// <summary>
    /// <para>Question mark (<c>?</c>) key.</para>
    /// </summary>
    Question = 63,
    /// <summary>
    /// <para>At sign (<c>@</c>) key.</para>
    /// </summary>
    At = 64,
    /// <summary>
    /// <para>A key.</para>
    /// </summary>
    A = 65,
    /// <summary>
    /// <para>B key.</para>
    /// </summary>
    B = 66,
    /// <summary>
    /// <para>C key.</para>
    /// </summary>
    C = 67,
    /// <summary>
    /// <para>D key.</para>
    /// </summary>
    D = 68,
    /// <summary>
    /// <para>E key.</para>
    /// </summary>
    E = 69,
    /// <summary>
    /// <para>F key.</para>
    /// </summary>
    F = 70,
    /// <summary>
    /// <para>G key.</para>
    /// </summary>
    G = 71,
    /// <summary>
    /// <para>H key.</para>
    /// </summary>
    H = 72,
    /// <summary>
    /// <para>I key.</para>
    /// </summary>
    I = 73,
    /// <summary>
    /// <para>J key.</para>
    /// </summary>
    J = 74,
    /// <summary>
    /// <para>K key.</para>
    /// </summary>
    K = 75,
    /// <summary>
    /// <para>L key.</para>
    /// </summary>
    L = 76,
    /// <summary>
    /// <para>M key.</para>
    /// </summary>
    M = 77,
    /// <summary>
    /// <para>N key.</para>
    /// </summary>
    N = 78,
    /// <summary>
    /// <para>O key.</para>
    /// </summary>
    O = 79,
    /// <summary>
    /// <para>P key.</para>
    /// </summary>
    P = 80,
    /// <summary>
    /// <para>Q key.</para>
    /// </summary>
    Q = 81,
    /// <summary>
    /// <para>R key.</para>
    /// </summary>
    R = 82,
    /// <summary>
    /// <para>S key.</para>
    /// </summary>
    S = 83,
    /// <summary>
    /// <para>T key.</para>
    /// </summary>
    T = 84,
    /// <summary>
    /// <para>U key.</para>
    /// </summary>
    U = 85,
    /// <summary>
    /// <para>V key.</para>
    /// </summary>
    V = 86,
    /// <summary>
    /// <para>W key.</para>
    /// </summary>
    W = 87,
    /// <summary>
    /// <para>X key.</para>
    /// </summary>
    X = 88,
    /// <summary>
    /// <para>Y key.</para>
    /// </summary>
    Y = 89,
    /// <summary>
    /// <para>Z key.</para>
    /// </summary>
    Z = 90,
    /// <summary>
    /// <para>Left bracket (<c>[lb]</c>) key.</para>
    /// </summary>
    Bracketleft = 91,
    /// <summary>
    /// <para>Backslash (<c>\</c>) key.</para>
    /// </summary>
    Backslash = 92,
    /// <summary>
    /// <para>Right bracket (<c>[rb]</c>) key.</para>
    /// </summary>
    Bracketright = 93,
    /// <summary>
    /// <para>Caret (<c>^</c>) key.</para>
    /// </summary>
    Asciicircum = 94,
    /// <summary>
    /// <para>Underscore (<c>_</c>) key.</para>
    /// </summary>
    Underscore = 95,
    /// <summary>
    /// <para>Backtick (<c>`</c>) key.</para>
    /// </summary>
    Quoteleft = 96,
    /// <summary>
    /// <para>Left brace (<c>{</c>) key.</para>
    /// </summary>
    Braceleft = 123,
    /// <summary>
    /// <para>Vertical bar or <i>pipe</i> (<c>|</c>) key.</para>
    /// </summary>
    Bar = 124,
    /// <summary>
    /// <para>Right brace (<c>}</c>) key.</para>
    /// </summary>
    Braceright = 125,
    /// <summary>
    /// <para>Tilde (<c>~</c>) key.</para>
    /// </summary>
    Asciitilde = 126,
    /// <summary>
    /// <para>Yen symbol (<c>¥</c>) key.</para>
    /// </summary>
    Yen = 165,
    /// <summary>
    /// <para>Section sign (<c>§</c>) key.</para>
    /// </summary>
    Section = 167,
}

[System.Flags]
public enum KeyModifierMask : long
{
    /// <summary>
    /// <para>Key Code mask.</para>
    /// </summary>
    CodeMask = 8388607,
    /// <summary>
    /// <para>Modifier key mask.</para>
    /// </summary>
    ModifierMask = 2130706432,
    /// <summary>
    /// <para>Automatically remapped to <see cref="Godot.Key.Meta"/> on macOS and <see cref="Godot.Key.Ctrl"/> on other platforms, this mask is never set in the actual events, and should be used for key mapping only.</para>
    /// </summary>
    MaskCmdOrCtrl = 16777216,
    /// <summary>
    /// <para>Shift key mask.</para>
    /// </summary>
    MaskShift = 33554432,
    /// <summary>
    /// <para>Alt or Option (on macOS) key mask.</para>
    /// </summary>
    MaskAlt = 67108864,
    /// <summary>
    /// <para>Command (on macOS) or Meta/Windows key mask.</para>
    /// </summary>
    MaskMeta = 134217728,
    /// <summary>
    /// <para>Control key mask.</para>
    /// </summary>
    MaskCtrl = 268435456,
    /// <summary>
    /// <para>Keypad key mask.</para>
    /// </summary>
    MaskKpad = 536870912,
    /// <summary>
    /// <para>Group Switch key mask.</para>
    /// </summary>
    MaskGroupSwitch = 1073741824,
}

public enum KeyLocation : long
{
    /// <summary>
    /// <para>Used for keys which only appear once, or when a comparison doesn't need to differentiate the <c>LEFT</c> and <c>RIGHT</c> versions.</para>
    /// <para>For example, when using <see cref="Godot.InputEvent.IsMatch(InputEvent, bool)"/>, an event which has <see cref="Godot.KeyLocation.Unspecified"/> will match any <see cref="Godot.KeyLocation"/> on the passed event.</para>
    /// </summary>
    Unspecified = 0,
    /// <summary>
    /// <para>A key which is to the left of its twin.</para>
    /// </summary>
    Left = 1,
    /// <summary>
    /// <para>A key which is to the right of its twin.</para>
    /// </summary>
    Right = 2,
}

public enum MouseButton : long
{
    /// <summary>
    /// <para>Enum value which doesn't correspond to any mouse button. This is used to initialize <see cref="Godot.MouseButton"/> properties with a generic state.</para>
    /// </summary>
    None = 0,
    /// <summary>
    /// <para>Primary mouse button, usually assigned to the left button.</para>
    /// </summary>
    Left = 1,
    /// <summary>
    /// <para>Secondary mouse button, usually assigned to the right button.</para>
    /// </summary>
    Right = 2,
    /// <summary>
    /// <para>Middle mouse button.</para>
    /// </summary>
    Middle = 3,
    /// <summary>
    /// <para>Mouse wheel scrolling up.</para>
    /// </summary>
    WheelUp = 4,
    /// <summary>
    /// <para>Mouse wheel scrolling down.</para>
    /// </summary>
    WheelDown = 5,
    /// <summary>
    /// <para>Mouse wheel left button (only present on some mice).</para>
    /// </summary>
    WheelLeft = 6,
    /// <summary>
    /// <para>Mouse wheel right button (only present on some mice).</para>
    /// </summary>
    WheelRight = 7,
    /// <summary>
    /// <para>Extra mouse button 1. This is sometimes present, usually to the sides of the mouse.</para>
    /// </summary>
    Xbutton1 = 8,
    /// <summary>
    /// <para>Extra mouse button 2. This is sometimes present, usually to the sides of the mouse.</para>
    /// </summary>
    Xbutton2 = 9,
}

[System.Flags]
public enum MouseButtonMask : long
{
    /// <summary>
    /// <para>Primary mouse button mask, usually for the left button.</para>
    /// </summary>
    Left = 1,
    /// <summary>
    /// <para>Secondary mouse button mask, usually for the right button.</para>
    /// </summary>
    Right = 2,
    /// <summary>
    /// <para>Middle mouse button mask.</para>
    /// </summary>
    Middle = 4,
    /// <summary>
    /// <para>Extra mouse button 1 mask.</para>
    /// </summary>
    MbXbutton1 = 128,
    /// <summary>
    /// <para>Extra mouse button 2 mask.</para>
    /// </summary>
    MbXbutton2 = 256,
}

public enum JoyButton : long
{
    /// <summary>
    /// <para>An invalid game controller button.</para>
    /// </summary>
    Invalid = -1,
    /// <summary>
    /// <para>Game controller SDL button A. Corresponds to the bottom action button: Sony Cross, Xbox A, Nintendo B.</para>
    /// </summary>
    A = 0,
    /// <summary>
    /// <para>Game controller SDL button B. Corresponds to the right action button: Sony Circle, Xbox B, Nintendo A.</para>
    /// </summary>
    B = 1,
    /// <summary>
    /// <para>Game controller SDL button X. Corresponds to the left action button: Sony Square, Xbox X, Nintendo Y.</para>
    /// </summary>
    X = 2,
    /// <summary>
    /// <para>Game controller SDL button Y. Corresponds to the top action button: Sony Triangle, Xbox Y, Nintendo X.</para>
    /// </summary>
    Y = 3,
    /// <summary>
    /// <para>Game controller SDL back button. Corresponds to the Sony Select, Xbox Back, Nintendo - button.</para>
    /// </summary>
    Back = 4,
    /// <summary>
    /// <para>Game controller SDL guide button. Corresponds to the Sony PS, Xbox Home button.</para>
    /// </summary>
    Guide = 5,
    /// <summary>
    /// <para>Game controller SDL start button. Corresponds to the Sony Options, Xbox Menu, Nintendo + button.</para>
    /// </summary>
    Start = 6,
    /// <summary>
    /// <para>Game controller SDL left stick button. Corresponds to the Sony L3, Xbox L/LS button.</para>
    /// </summary>
    LeftStick = 7,
    /// <summary>
    /// <para>Game controller SDL right stick button. Corresponds to the Sony R3, Xbox R/RS button.</para>
    /// </summary>
    RightStick = 8,
    /// <summary>
    /// <para>Game controller SDL left shoulder button. Corresponds to the Sony L1, Xbox LB button.</para>
    /// </summary>
    LeftShoulder = 9,
    /// <summary>
    /// <para>Game controller SDL right shoulder button. Corresponds to the Sony R1, Xbox RB button.</para>
    /// </summary>
    RightShoulder = 10,
    /// <summary>
    /// <para>Game controller D-pad up button.</para>
    /// </summary>
    DpadUp = 11,
    /// <summary>
    /// <para>Game controller D-pad down button.</para>
    /// </summary>
    DpadDown = 12,
    /// <summary>
    /// <para>Game controller D-pad left button.</para>
    /// </summary>
    DpadLeft = 13,
    /// <summary>
    /// <para>Game controller D-pad right button.</para>
    /// </summary>
    DpadRight = 14,
    /// <summary>
    /// <para>Game controller SDL miscellaneous button. Corresponds to Xbox share button, PS5 microphone button, Nintendo Switch capture button.</para>
    /// </summary>
    Misc1 = 15,
    /// <summary>
    /// <para>Game controller SDL paddle 1 button.</para>
    /// </summary>
    Paddle1 = 16,
    /// <summary>
    /// <para>Game controller SDL paddle 2 button.</para>
    /// </summary>
    Paddle2 = 17,
    /// <summary>
    /// <para>Game controller SDL paddle 3 button.</para>
    /// </summary>
    Paddle3 = 18,
    /// <summary>
    /// <para>Game controller SDL paddle 4 button.</para>
    /// </summary>
    Paddle4 = 19,
    /// <summary>
    /// <para>Game controller SDL touchpad button.</para>
    /// </summary>
    Touchpad = 20,
    /// <summary>
    /// <para>The number of SDL game controller buttons.</para>
    /// </summary>
    SdlMax = 21,
    /// <summary>
    /// <para>The maximum number of game controller buttons supported by the engine. The actual limit may be lower on specific platforms:</para>
    /// <para>- <b>Android:</b> Up to 36 buttons.</para>
    /// <para>- <b>Linux:</b> Up to 80 buttons.</para>
    /// <para>- <b>Windows</b> and <b>macOS:</b> Up to 128 buttons.</para>
    /// </summary>
    Max = 128,
}

public enum JoyAxis : long
{
    /// <summary>
    /// <para>An invalid game controller axis.</para>
    /// </summary>
    Invalid = -1,
    /// <summary>
    /// <para>Game controller left joystick x-axis.</para>
    /// </summary>
    LeftX = 0,
    /// <summary>
    /// <para>Game controller left joystick y-axis.</para>
    /// </summary>
    LeftY = 1,
    /// <summary>
    /// <para>Game controller right joystick x-axis.</para>
    /// </summary>
    RightX = 2,
    /// <summary>
    /// <para>Game controller right joystick y-axis.</para>
    /// </summary>
    RightY = 3,
    /// <summary>
    /// <para>Game controller left trigger axis.</para>
    /// </summary>
    TriggerLeft = 4,
    /// <summary>
    /// <para>Game controller right trigger axis.</para>
    /// </summary>
    TriggerRight = 5,
    /// <summary>
    /// <para>The number of SDL game controller axes.</para>
    /// </summary>
    SdlMax = 6,
    /// <summary>
    /// <para>The maximum number of game controller axes: OpenVR supports up to 5 Joysticks making a total of 10 axes.</para>
    /// </summary>
    Max = 10,
}

public enum MidiMessage : long
{
    /// <summary>
    /// <para>Does not correspond to any MIDI message. This is the default value of <see cref="Godot.InputEventMidi.Message"/>.</para>
    /// </summary>
    None = 0,
    /// <summary>
    /// <para>MIDI message sent when a note is released.</para>
    /// <para><b>Note:</b> Not all MIDI devices send this message; some may send <see cref="Godot.MidiMessage.NoteOn"/> with <see cref="Godot.InputEventMidi.Velocity"/> set to <c>0</c>.</para>
    /// </summary>
    NoteOff = 8,
    /// <summary>
    /// <para>MIDI message sent when a note is pressed.</para>
    /// </summary>
    NoteOn = 9,
    /// <summary>
    /// <para>MIDI message sent to indicate a change in pressure while a note is being pressed down, also called aftertouch.</para>
    /// </summary>
    Aftertouch = 10,
    /// <summary>
    /// <para>MIDI message sent when a controller value changes. In a MIDI device, a controller is any input that doesn't play notes. These may include sliders for volume, balance, and panning, as well as switches and pedals. See the <a href="https://en.wikipedia.org/wiki/General_MIDI#Controller_events">General MIDI specification</a> for a small list.</para>
    /// </summary>
    ControlChange = 11,
    /// <summary>
    /// <para>MIDI message sent when the MIDI device changes its current instrument (also called <i>program</i> or <i>preset</i>).</para>
    /// </summary>
    ProgramChange = 12,
    /// <summary>
    /// <para>MIDI message sent to indicate a change in pressure for the whole channel. Some MIDI devices may send this instead of <see cref="Godot.MidiMessage.Aftertouch"/>.</para>
    /// </summary>
    ChannelPressure = 13,
    /// <summary>
    /// <para>MIDI message sent when the value of the pitch bender changes, usually a wheel on the MIDI device.</para>
    /// </summary>
    PitchBend = 14,
    /// <summary>
    /// <para>MIDI system exclusive (SysEx) message. This type of message is not standardized and it's highly dependent on the MIDI device sending it.</para>
    /// <para><b>Note:</b> Getting this message's data from <see cref="Godot.InputEventMidi"/> is not implemented.</para>
    /// </summary>
    SystemExclusive = 240,
    /// <summary>
    /// <para>MIDI message sent every quarter frame to keep connected MIDI devices synchronized. Related to <see cref="Godot.MidiMessage.TimingClock"/>.</para>
    /// <para><b>Note:</b> Getting this message's data from <see cref="Godot.InputEventMidi"/> is not implemented.</para>
    /// </summary>
    QuarterFrame = 241,
    /// <summary>
    /// <para>MIDI message sent to jump onto a new position in the current sequence or song.</para>
    /// <para><b>Note:</b> Getting this message's data from <see cref="Godot.InputEventMidi"/> is not implemented.</para>
    /// </summary>
    SongPositionPointer = 242,
    /// <summary>
    /// <para>MIDI message sent to select a sequence or song to play.</para>
    /// <para><b>Note:</b> Getting this message's data from <see cref="Godot.InputEventMidi"/> is not implemented.</para>
    /// </summary>
    SongSelect = 243,
    /// <summary>
    /// <para>MIDI message sent to request a tuning calibration. Used on analog synthesizers. Most modern MIDI devices do not need this message.</para>
    /// </summary>
    TuneRequest = 246,
    /// <summary>
    /// <para>MIDI message sent 24 times after <see cref="Godot.MidiMessage.QuarterFrame"/>, to keep connected MIDI devices synchronized.</para>
    /// </summary>
    TimingClock = 248,
    /// <summary>
    /// <para>MIDI message sent to start the current sequence or song from the beginning.</para>
    /// </summary>
    Start = 250,
    /// <summary>
    /// <para>MIDI message sent to resume from the point the current sequence or song was paused.</para>
    /// </summary>
    Continue = 251,
    /// <summary>
    /// <para>MIDI message sent to pause the current sequence or song.</para>
    /// </summary>
    Stop = 252,
    /// <summary>
    /// <para>MIDI message sent repeatedly while the MIDI device is idle, to tell the receiver that the connection is alive. Most MIDI devices do not send this message.</para>
    /// </summary>
    ActiveSensing = 254,
    /// <summary>
    /// <para>MIDI message sent to reset a MIDI device to its default state, as if it was just turned on. It should not be sent when the MIDI device is being turned on.</para>
    /// </summary>
    SystemReset = 255,
}

public enum Error : long
{
    /// <summary>
    /// <para>Methods that return <see cref="Godot.Error"/> return <see cref="Godot.Error.Ok"/> when no error occurred.</para>
    /// <para>Since <see cref="Godot.Error.Ok"/> has value <c>0</c>, and all other error constants are positive integers, it can also be used in boolean checks.</para>
    /// <para><code>
    /// var error = method_that_returns_error()
    /// if error != OK:
    /// 	printerr("Failure!")
    /// 
    /// # Or, alternatively:
    /// if error:
    /// 	printerr("Still failing!")
    /// </code></para>
    /// <para><b>Note:</b> Many functions do not return an error code, but will print error messages to standard output.</para>
    /// </summary>
    Ok = 0,
    /// <summary>
    /// <para>Generic error.</para>
    /// </summary>
    Failed = 1,
    /// <summary>
    /// <para>Unavailable error.</para>
    /// </summary>
    Unavailable = 2,
    /// <summary>
    /// <para>Unconfigured error.</para>
    /// </summary>
    Unconfigured = 3,
    /// <summary>
    /// <para>Unauthorized error.</para>
    /// </summary>
    Unauthorized = 4,
    /// <summary>
    /// <para>Parameter range error.</para>
    /// </summary>
    ParameterRangeError = 5,
    /// <summary>
    /// <para>Out of memory (OOM) error.</para>
    /// </summary>
    OutOfMemory = 6,
    /// <summary>
    /// <para>File: Not found error.</para>
    /// </summary>
    FileNotFound = 7,
    /// <summary>
    /// <para>File: Bad drive error.</para>
    /// </summary>
    FileBadDrive = 8,
    /// <summary>
    /// <para>File: Bad path error.</para>
    /// </summary>
    FileBadPath = 9,
    /// <summary>
    /// <para>File: No permission error.</para>
    /// </summary>
    FileNoPermission = 10,
    /// <summary>
    /// <para>File: Already in use error.</para>
    /// </summary>
    FileAlreadyInUse = 11,
    /// <summary>
    /// <para>File: Can't open error.</para>
    /// </summary>
    FileCantOpen = 12,
    /// <summary>
    /// <para>File: Can't write error.</para>
    /// </summary>
    FileCantWrite = 13,
    /// <summary>
    /// <para>File: Can't read error.</para>
    /// </summary>
    FileCantRead = 14,
    /// <summary>
    /// <para>File: Unrecognized error.</para>
    /// </summary>
    FileUnrecognized = 15,
    /// <summary>
    /// <para>File: Corrupt error.</para>
    /// </summary>
    FileCorrupt = 16,
    /// <summary>
    /// <para>File: Missing dependencies error.</para>
    /// </summary>
    FileMissingDependencies = 17,
    /// <summary>
    /// <para>File: End of file (EOF) error.</para>
    /// </summary>
    FileEof = 18,
    /// <summary>
    /// <para>Can't open error.</para>
    /// </summary>
    CantOpen = 19,
    /// <summary>
    /// <para>Can't create error.</para>
    /// </summary>
    CantCreate = 20,
    /// <summary>
    /// <para>Query failed error.</para>
    /// </summary>
    QueryFailed = 21,
    /// <summary>
    /// <para>Already in use error.</para>
    /// </summary>
    AlreadyInUse = 22,
    /// <summary>
    /// <para>Locked error.</para>
    /// </summary>
    Locked = 23,
    /// <summary>
    /// <para>Timeout error.</para>
    /// </summary>
    Timeout = 24,
    /// <summary>
    /// <para>Can't connect error.</para>
    /// </summary>
    CantConnect = 25,
    /// <summary>
    /// <para>Can't resolve error.</para>
    /// </summary>
    CantResolve = 26,
    /// <summary>
    /// <para>Connection error.</para>
    /// </summary>
    ConnectionError = 27,
    /// <summary>
    /// <para>Can't acquire resource error.</para>
    /// </summary>
    CantAcquireResource = 28,
    /// <summary>
    /// <para>Can't fork process error.</para>
    /// </summary>
    CantFork = 29,
    /// <summary>
    /// <para>Invalid data error.</para>
    /// </summary>
    InvalidData = 30,
    /// <summary>
    /// <para>Invalid parameter error.</para>
    /// </summary>
    InvalidParameter = 31,
    /// <summary>
    /// <para>Already exists error.</para>
    /// </summary>
    AlreadyExists = 32,
    /// <summary>
    /// <para>Does not exist error.</para>
    /// </summary>
    DoesNotExist = 33,
    /// <summary>
    /// <para>Database: Read error.</para>
    /// </summary>
    DatabaseCantRead = 34,
    /// <summary>
    /// <para>Database: Write error.</para>
    /// </summary>
    DatabaseCantWrite = 35,
    /// <summary>
    /// <para>Compilation failed error.</para>
    /// </summary>
    CompilationFailed = 36,
    /// <summary>
    /// <para>Method not found error.</para>
    /// </summary>
    MethodNotFound = 37,
    /// <summary>
    /// <para>Linking failed error.</para>
    /// </summary>
    LinkFailed = 38,
    /// <summary>
    /// <para>Script failed error.</para>
    /// </summary>
    ScriptFailed = 39,
    /// <summary>
    /// <para>Cycling link (import cycle) error.</para>
    /// </summary>
    CyclicLink = 40,
    /// <summary>
    /// <para>Invalid declaration error.</para>
    /// </summary>
    InvalidDeclaration = 41,
    /// <summary>
    /// <para>Duplicate symbol error.</para>
    /// </summary>
    DuplicateSymbol = 42,
    /// <summary>
    /// <para>Parse error.</para>
    /// </summary>
    ParseError = 43,
    /// <summary>
    /// <para>Busy error.</para>
    /// </summary>
    Busy = 44,
    /// <summary>
    /// <para>Skip error.</para>
    /// </summary>
    Skip = 45,
    /// <summary>
    /// <para>Help error. Used internally when passing <c>--version</c> or <c>--help</c> as executable options.</para>
    /// </summary>
    Help = 46,
    /// <summary>
    /// <para>Bug error, caused by an implementation issue in the method.</para>
    /// <para><b>Note:</b> If a built-in method returns this code, please open an issue on <a href="https://github.com/godotengine/godot/issues">the GitHub Issue Tracker</a>.</para>
    /// </summary>
    Bug = 47,
    /// <summary>
    /// <para>Printer on fire error (This is an easter egg, no built-in methods return this error code).</para>
    /// </summary>
    PrinterOnFire = 48,
}

public enum PropertyHint : long
{
    /// <summary>
    /// <para>The property has no hint for the editor.</para>
    /// </summary>
    None = 0,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> or <see cref="float"/> property should be within a range specified via the hint string <c>"min,max"</c> or <c>"min,max,step"</c>. The hint string can optionally include <c>"or_greater"</c> and/or <c>"or_less"</c> to allow manual input going respectively above the max or below the min values.</para>
    /// <para><b>Example:</b> <c>"-360,360,1,or_greater,or_less"</c>.</para>
    /// <para>Additionally, other keywords can be included: <c>"exp"</c> for exponential range editing, <c>"radians_as_degrees"</c> for editing radian angles in degrees (the range values are also in degrees), <c>"degrees"</c> to hint at an angle, <c>"prefer_slider"</c> to show the slider for integers, <c>"hide_control"</c> to hide the slider or up-down arrows, and <c>"suffix:px/s"</c> to display a suffix indicating the value's unit (e.g. <c>px/s</c> for pixels per second).</para>
    /// </summary>
    Range = 1,
    /// <summary>
    /// <para>Hints that an <see cref="int"/>, <see cref="string"/>, or <see cref="Godot.StringName"/> property is an enumerated value to pick in a list specified via a hint string.</para>
    /// <para>The hint string is a comma separated list of names such as <c>"Hello,Something,Else"</c>. Whitespace is <b>not</b> removed from either end of a name. For integer properties, the first name in the list has value 0, the next 1, and so on. Explicit values can also be specified by appending <c>:integer</c> to the name, e.g. <c>"Zero,One,Three:3,Four,Six:6"</c>.</para>
    /// </summary>
    Enum = 2,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> or <see cref="Godot.StringName"/> property can be an enumerated value to pick in a list specified via a hint string such as <c>"Hello,Something,Else"</c>. See <see cref="Godot.PropertyHint.Enum"/> for details.</para>
    /// <para>Unlike <see cref="Godot.PropertyHint.Enum"/>, a property with this hint still accepts arbitrary values and can be empty. The list of values serves to suggest possible values.</para>
    /// </summary>
    EnumSuggestion = 3,
    /// <summary>
    /// <para>Hints that a <see cref="float"/> property should be edited via an exponential easing function. The hint string can include <c>"attenuation"</c> to flip the curve horizontally and/or <c>"positive_only"</c> to exclude in/out easing and limit values to be greater than or equal to zero.</para>
    /// </summary>
    ExpEasing = 4,
    /// <summary>
    /// <para>Hints that a vector property should allow its components to be linked. For example, this allows <c>Vector2.x</c> and <c>Vector2.y</c> to be edited together.</para>
    /// </summary>
    Link = 5,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a bitmask with named bit flags.</para>
    /// <para>The hint string is a comma separated list of names such as <c>"Bit0,Bit1,Bit2,Bit3"</c>. Whitespace is <b>not</b> removed from either end of a name. The first name in the list has value 1, the next 2, then 4, 8, 16 and so on. Explicit values can also be specified by appending <c>:integer</c> to the name, e.g. <c>"A:4,B:8,C:16"</c>. You can also combine several flags (<c>"A:4,B:8,AB:12,C:16"</c>).</para>
    /// <para><b>Note:</b> A flag value must be at least <c>1</c> and at most <c>2 ** 32 - 1</c>.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.PropertyHint.Enum"/>, the previous explicit value is not taken into account. For the hint <c>"A:16,B,C"</c>, A is 16, B is 2, C is 4.</para>
    /// </summary>
    Flags = 6,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a bitmask using the optionally named 2D render layers.</para>
    /// </summary>
    Layers2DRender = 7,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a bitmask using the optionally named 2D physics layers.</para>
    /// </summary>
    Layers2DPhysics = 8,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a bitmask using the optionally named 2D navigation layers.</para>
    /// </summary>
    Layers2DNavigation = 9,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a bitmask using the optionally named 3D render layers.</para>
    /// </summary>
    Layers3DRender = 10,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a bitmask using the optionally named 3D physics layers.</para>
    /// </summary>
    Layers3DPhysics = 11,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a bitmask using the optionally named 3D navigation layers.</para>
    /// </summary>
    Layers3DNavigation = 12,
    /// <summary>
    /// <para>Hints that an integer property is a bitmask using the optionally named avoidance layers.</para>
    /// </summary>
    LayersAvoidance = 37,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is a path to a file. Editing it will show a file dialog for picking the path. The hint string can be a set of filters with wildcards like <c>"*.png,*.jpg"</c>. By default the file will be stored as UID whenever available. You can use <see cref="Godot.ResourceUid"/> methods to convert it back to path. For storing a raw path, use <see cref="Godot.PropertyHint.FilePath"/>.</para>
    /// </summary>
    File = 13,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is a path to a directory. Editing it will show a file dialog for picking the path.</para>
    /// </summary>
    Dir = 14,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is an absolute path to a file outside the project folder. Editing it will show a file dialog for picking the path. The hint string can be a set of filters with wildcards, like <c>"*.png,*.jpg"</c>.</para>
    /// </summary>
    GlobalFile = 15,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is an absolute path to a directory outside the project folder. Editing it will show a file dialog for picking the path.</para>
    /// </summary>
    GlobalDir = 16,
    /// <summary>
    /// <para>Hints that a property is an instance of a <see cref="Godot.Resource"/>-derived type, optionally specified via the hint string (e.g. <c>"Texture2D"</c>). Editing it will show a popup menu of valid resource types to instantiate.</para>
    /// </summary>
    ResourceType = 17,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is text with line breaks. Editing it will show a text input field where line breaks can be typed.</para>
    /// <para>The hint string can be set to <c>"monospace"</c> to force the input field to use a monospaced font.</para>
    /// <para>If the hint string <c>"no_wrap"</c> is set, the input field will not wrap lines at boundaries, instead resorting to making the area scrollable.</para>
    /// </summary>
    MultilineText = 18,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is an <see cref="Godot.Expression"/>.</para>
    /// </summary>
    Expression = 19,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property should show a placeholder text on its input field, if empty. The hint string is the placeholder text to use.</para>
    /// </summary>
    PlaceholderText = 20,
    /// <summary>
    /// <para>Hints that a <see cref="Godot.Color"/> property should be edited without affecting its transparency (<c>Color.a</c> is not editable).</para>
    /// </summary>
    ColorNoAlpha = 21,
    /// <summary>
    /// <para>Hints that the property's value is an object encoded as object ID, with its type specified in the hint string. Used by the debugger.</para>
    /// </summary>
    ObjectId = 22,
    /// <summary>
    /// <para>If a property is <see cref="string"/>, hints that the property represents a particular type (class). This allows to select a type from the create dialog. The property will store the selected type as a string.</para>
    /// <para>If a property is <see cref="Godot.Collections.Array"/>, hints the editor how to show elements. The <c>hint_string</c> must encode nested types using <c>":"</c> and <c>"/"</c>.</para>
    /// <para>If a property is <see cref="Godot.Collections.Dictionary"/>, hints the editor how to show elements. The <c>hint_string</c> is the same as <see cref="Godot.Collections.Array"/>, with a <c>";"</c> separating the key and value.</para>
    /// <para><code>
    /// // Array of elemType.
    /// hintString = $"{elemType:D}:";
    /// hintString = $"{elemType:}/{elemHint:D}:{elemHintString}";
    /// // Two-dimensional array of elemType (array of arrays of elemType).
    /// hintString = $"{Variant.Type.Array:D}:{elemType:D}:";
    /// hintString = $"{Variant.Type.Array:D}:{elemType:D}/{elemHint:D}:{elemHintString}";
    /// // Three-dimensional array of elemType (array of arrays of arrays of elemType).
    /// hintString = $"{Variant.Type.Array:D}:{Variant.Type.Array:D}:{elemType:D}:";
    /// hintString = $"{Variant.Type.Array:D}:{Variant.Type.Array:D}:{elemType:D}/{elemHint:D}:{elemHintString}";
    /// </code></para>
    /// <para><b>Examples:</b></para>
    /// <para><code>
    /// hintString = $"{Variant.Type.Int:D}/{PropertyHint.Range:D}:1,10,1"; // Array of integers (in range from 1 to 10).
    /// hintString = $"{Variant.Type.Int:D}/{PropertyHint.Enum:D}:Zero,One,Two"; // Array of integers (an enum).
    /// hintString = $"{Variant.Type.Int:D}/{PropertyHint.Enum:D}:Zero,One,Three:3,Six:6"; // Array of integers (an enum).
    /// hintString = $"{Variant.Type.String:D}/{PropertyHint.File:D}:*.png"; // Array of strings (file paths).
    /// hintString = $"{Variant.Type.Object:D}/{PropertyHint.ResourceType:D}:Texture2D"; // Array of textures.
    /// 
    /// hintString = $"{Variant.Type.Array:D}:{Variant.Type.Float:D}:"; // Two-dimensional array of floats.
    /// hintString = $"{Variant.Type.Array:D}:{Variant.Type.String:D}/{PropertyHint.MultilineText:D}:"; // Two-dimensional array of multiline strings.
    /// hintString = $"{Variant.Type.Array:D}:{Variant.Type.Float:D}/{PropertyHint.Range:D}:-1,1,0.1"; // Two-dimensional array of floats (in range from -1 to 1).
    /// hintString = $"{Variant.Type.Array:D}:{Variant.Type.Object:D}/{PropertyHint.ResourceType:D}:Texture2D"; // Two-dimensional array of textures.
    /// </code></para>
    /// <para><b>Note:</b> The trailing colon is required for properly detecting built-in types.</para>
    /// </summary>
    TypeString = 23,
    NodePathToEditedNode = 24,
    /// <summary>
    /// <para>Hints that an object is too big to be sent via the debugger.</para>
    /// </summary>
    ObjectTooBig = 25,
    /// <summary>
    /// <para>Hints that the hint string specifies valid node types for property of type <see cref="Godot.NodePath"/>.</para>
    /// </summary>
    NodePathValidTypes = 26,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is a path to a file. Editing it will show a file dialog for picking the path for the file to be saved at. The dialog has access to the project's directory. The hint string can be a set of filters with wildcards like <c>"*.png,*.jpg"</c>. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// </summary>
    SaveFile = 27,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> property is a path to a file. Editing it will show a file dialog for picking the path for the file to be saved at. The dialog has access to the entire filesystem. The hint string can be a set of filters with wildcards like <c>"*.png,*.jpg"</c>. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// </summary>
    GlobalSaveFile = 28,
    IntIsObjectid = 29,
    /// <summary>
    /// <para>Hints that an <see cref="int"/> property is a pointer. Used by GDExtension.</para>
    /// </summary>
    IntIsPointer = 30,
    /// <summary>
    /// <para>Hints that a property is an <see cref="Godot.Collections.Array"/> with the stored type specified in the hint string. The hint string contains the type of the array (e.g. <c>"String"</c>).</para>
    /// <para>Use the hint string format from <see cref="Godot.PropertyHint.TypeString"/> for more control over the stored type.</para>
    /// </summary>
    ArrayType = 31,
    /// <summary>
    /// <para>Hints that a property is a <see cref="Godot.Collections.Dictionary"/> with the stored types specified in the hint string. The hint string contains the key and value types separated by a semicolon (e.g. <c>"int;String"</c>).</para>
    /// <para>Use the hint string format from <see cref="Godot.PropertyHint.TypeString"/> for more control over the stored types.</para>
    /// </summary>
    DictionaryType = 38,
    /// <summary>
    /// <para>Hints that a string property is a locale code. Editing it will show a locale dialog for picking language and country.</para>
    /// </summary>
    LocaleId = 32,
    /// <summary>
    /// <para>Hints that a dictionary property is string translation map. Dictionary keys are locale codes and, values are translated strings.</para>
    /// </summary>
    LocalizableString = 33,
    /// <summary>
    /// <para>Hints that a property is an instance of a <see cref="Godot.Node"/>-derived type, optionally specified via the hint string (e.g. <c>"Node2D"</c>). Editing it will show a dialog for picking a node from the scene.</para>
    /// </summary>
    NodeType = 34,
    /// <summary>
    /// <para>Hints that a quaternion property should disable the temporary euler editor.</para>
    /// </summary>
    HideQuaternionEdit = 35,
    /// <summary>
    /// <para>Hints that a string property is a password, and every character is replaced with the secret character.</para>
    /// </summary>
    Password = 36,
    /// <summary>
    /// <para>Hints that a <see cref="Godot.Callable"/> property should be displayed as a clickable button. When the button is pressed, the callable is called. The hint string specifies the button text and optionally an icon from the <c>"EditorIcons"</c> theme type.</para>
    /// <para><code>
    /// "Click me!" - A button with the text "Click me!" and the default "Callable" icon.
    /// "Click me!,ColorRect" - A button with the text "Click me!" and the "ColorRect" icon.
    /// </code></para>
    /// <para><b>Note:</b> A <see cref="Godot.Callable"/> cannot be properly serialized and stored in a file, so it is recommended to use <see cref="Godot.PropertyUsageFlags.Editor"/> instead of <see cref="Godot.PropertyUsageFlags.Default"/>.</para>
    /// </summary>
    ToolButton = 39,
    /// <summary>
    /// <para>Hints that a property will be changed on its own after setting, such as <see cref="Godot.AudioStreamPlayer.Playing"/> or <see cref="Godot.GpuParticles3D.Emitting"/>.</para>
    /// </summary>
    Oneshot = 40,
    /// <summary>
    /// <para>Hints that a boolean property will enable the feature associated with the group that it occurs in. The property will be displayed as a checkbox on the group header. Only works within a group or subgroup.</para>
    /// <para>By default, disabling the property hides all properties in the group. Use the optional hint string <c>"checkbox_only"</c> to disable this behavior.</para>
    /// </summary>
    GroupEnable = 42,
    /// <summary>
    /// <para>Hints that a <see cref="string"/> or <see cref="Godot.StringName"/> property is the name of an input action. This allows the selection of any action name from the Input Map in the Project Settings. The hint string may contain two options separated by commas:</para>
    /// <para>- If it contains <c>"show_builtin"</c>, built-in input actions are included in the selection.</para>
    /// <para>- If it contains <c>"loose_mode"</c>, loose mode is enabled. This allows inserting any action name even if it's not present in the input map.</para>
    /// </summary>
    InputName = 43,
    /// <summary>
    /// <para>Like <see cref="Godot.PropertyHint.File"/>, but the property is stored as a raw path, not UID. That means the reference will be broken if you move the file. Consider using <see cref="Godot.PropertyHint.File"/> when possible.</para>
    /// </summary>
    FilePath = 44,
    /// <summary>
    /// <para>Represents the size of the <see cref="Godot.PropertyHint"/> enum.</para>
    /// </summary>
    Max = 45,
}

[System.Flags]
public enum PropertyUsageFlags : long
{
    /// <summary>
    /// <para>The property is not stored, and does not display in the editor. This is the default for non-exported properties.</para>
    /// </summary>
    None = 0,
    /// <summary>
    /// <para>The property is serialized and saved in the scene file (default for exported properties).</para>
    /// </summary>
    Storage = 2,
    /// <summary>
    /// <para>The property is shown in the <c>EditorInspector</c> (default for exported properties).</para>
    /// </summary>
    Editor = 4,
    /// <summary>
    /// <para>The property is excluded from the class reference.</para>
    /// </summary>
    Internal = 8,
    /// <summary>
    /// <para>The property can be checked in the <c>EditorInspector</c>.</para>
    /// </summary>
    Checkable = 16,
    /// <summary>
    /// <para>The property is checked in the <c>EditorInspector</c>.</para>
    /// </summary>
    Checked = 32,
    /// <summary>
    /// <para>Used to group properties together in the editor. See <c>EditorInspector</c>.</para>
    /// </summary>
    Group = 64,
    /// <summary>
    /// <para>Used to categorize properties together in the editor.</para>
    /// </summary>
    Category = 128,
    /// <summary>
    /// <para>Used to group properties together in the editor in a subgroup (under a group). See <c>EditorInspector</c>.</para>
    /// </summary>
    Subgroup = 256,
    /// <summary>
    /// <para>The property is a bitfield, i.e. it contains multiple flags represented as bits.</para>
    /// </summary>
    ClassIsBitfield = 512,
    /// <summary>
    /// <para>The property does not save its state in <see cref="Godot.PackedScene"/>.</para>
    /// </summary>
    NoInstanceState = 1024,
    /// <summary>
    /// <para>Editing the property prompts the user for restarting the editor.</para>
    /// </summary>
    RestartIfChanged = 2048,
    /// <summary>
    /// <para>The property is a script variable. <see cref="Godot.PropertyUsageFlags.ScriptVariable"/> can be used to distinguish between exported script variables from built-in variables (which don't have this usage flag). By default, <see cref="Godot.PropertyUsageFlags.ScriptVariable"/> is <b>not</b> applied to variables that are created by overriding <see cref="Godot.GodotObject._GetPropertyList()"/> in a script.</para>
    /// </summary>
    ScriptVariable = 4096,
    /// <summary>
    /// <para>The property value of type <see cref="Godot.GodotObject"/> will be stored even if its value is <see langword="null"/>.</para>
    /// </summary>
    StoreIfNull = 8192,
    /// <summary>
    /// <para>If this property is modified, all inspector fields will be refreshed.</para>
    /// </summary>
    UpdateAllIfModified = 16384,
    ScriptDefaultValue = 32768,
    /// <summary>
    /// <para>The property is a variable of enum type, i.e. it only takes named integer constants from its associated enumeration.</para>
    /// </summary>
    ClassIsEnum = 65536,
    /// <summary>
    /// <para>If property has <c>nil</c> as default value, its type will be <see cref="Godot.Variant"/>.</para>
    /// </summary>
    NilIsVariant = 131072,
    /// <summary>
    /// <para>The property is the element count of a property array, i.e. a list of groups of related properties. Properties defined with this usage also need a specific <c>class_name</c> field in the form of <c>label,prefix</c>. The field may also include additional comma-separated options:</para>
    /// <para>- <c>page_size=N</c>: Overrides <c>EditorSettings.interface/inspector/max_array_dictionary_items_per_page</c> for this array.</para>
    /// <para>- <c>add_button_text=text</c>: The text displayed by the "Add Element" button.</para>
    /// <para>- <c>static</c>: The elements can't be re-arranged.</para>
    /// <para>- <c>const</c>: New elements can't be added.</para>
    /// <para>- <c>numbered</c>: An index will appear next to each element.</para>
    /// <para>- <c>unfoldable</c>: The array can't be folded.</para>
    /// <para>- <c>swap_method=method_name</c>: The method that will be called when two elements switch places. The method should take 2 <see cref="int"/> parameters, which will be indices of the elements being swapped.</para>
    /// <para>Note that making a full-fledged property array requires boilerplate code involving <see cref="Godot.GodotObject._GetPropertyList()"/>.</para>
    /// </summary>
    Array = 262144,
    /// <summary>
    /// <para>When duplicating a resource with <see cref="Godot.Resource.Duplicate(bool)"/>, and this flag is set on a property of that resource, the property should always be duplicated, regardless of the <c>subresources</c> bool parameter.</para>
    /// </summary>
    AlwaysDuplicate = 524288,
    /// <summary>
    /// <para>When duplicating a resource with <see cref="Godot.Resource.Duplicate(bool)"/>, and this flag is set on a property of that resource, the property should never be duplicated, regardless of the <c>subresources</c> bool parameter.</para>
    /// </summary>
    NeverDuplicate = 1048576,
    /// <summary>
    /// <para>The property is only shown in the editor if modern renderers are supported (the Compatibility rendering method is excluded).</para>
    /// </summary>
    HighEndGfx = 2097152,
    /// <summary>
    /// <para>The <see cref="Godot.NodePath"/> property will always be relative to the scene's root. Mostly useful for local resources.</para>
    /// </summary>
    NodePathFromSceneRoot = 4194304,
    /// <summary>
    /// <para>Use when a resource is created on the fly, i.e. the getter will always return a different instance. <see cref="Godot.ResourceSaver"/> needs this information to properly save such resources.</para>
    /// </summary>
    ResourceNotPersistent = 8388608,
    /// <summary>
    /// <para>Inserting an animation key frame of this property will automatically increment the value, allowing to easily keyframe multiple values in a row.</para>
    /// </summary>
    KeyingIncrements = 16777216,
    DeferredSetResource = 33554432,
    /// <summary>
    /// <para>When this property is a <see cref="Godot.Resource"/> and base object is a <see cref="Godot.Node"/>, a resource instance will be automatically created whenever the node is created in the editor.</para>
    /// </summary>
    EditorInstantiateObject = 67108864,
    /// <summary>
    /// <para>The property is considered a basic setting and will appear even when advanced mode is disabled. Used for project settings.</para>
    /// </summary>
    EditorBasicSetting = 134217728,
    /// <summary>
    /// <para>The property is read-only in the <c>EditorInspector</c>.</para>
    /// </summary>
    ReadOnly = 268435456,
    /// <summary>
    /// <para>An export preset property with this flag contains confidential information and is stored separately from the rest of the export preset configuration.</para>
    /// </summary>
    Secret = 536870912,
    /// <summary>
    /// <para>Default usage (storage and editor).</para>
    /// </summary>
    Default = 6,
    /// <summary>
    /// <para>Default usage but without showing the property in the editor (storage).</para>
    /// </summary>
    NoEditor = 2,
}

[System.Flags]
public enum MethodFlags : long
{
    /// <summary>
    /// <para>Flag for a normal method.</para>
    /// </summary>
    Normal = 1,
    /// <summary>
    /// <para>Flag for an editor method.</para>
    /// </summary>
    Editor = 2,
    /// <summary>
    /// <para>Flag for a constant method.</para>
    /// </summary>
    Const = 4,
    /// <summary>
    /// <para>Flag for a virtual method.</para>
    /// </summary>
    Virtual = 8,
    /// <summary>
    /// <para>Flag for a method with a variable number of arguments.</para>
    /// </summary>
    Vararg = 16,
    /// <summary>
    /// <para>Flag for a static method.</para>
    /// </summary>
    Static = 32,
    /// <summary>
    /// <para>Used internally. Allows to not dump core virtual methods (such as <see cref="Godot.GodotObject._Notification(int)"/>) to the JSON API.</para>
    /// </summary>
    ObjectCore = 64,
    /// <summary>
    /// <para>Flag for a virtual method that is required. In GDScript, this flag is set for abstract functions.</para>
    /// </summary>
    VirtualRequired = 128,
    /// <summary>
    /// <para>Default method flags (normal).</para>
    /// </summary>
    Default = 1,
}

public partial struct Variant
{

    public enum Type : long
    {
        /// <summary>
        /// <para>Variable is <see langword="null"/>.</para>
        /// </summary>
        Nil = 0,
        /// <summary>
        /// <para>Variable is of type <see cref="bool"/>.</para>
        /// </summary>
        Bool = 1,
        /// <summary>
        /// <para>Variable is of type <see cref="int"/>.</para>
        /// </summary>
        Int = 2,
        /// <summary>
        /// <para>Variable is of type <see cref="float"/>.</para>
        /// </summary>
        Float = 3,
        /// <summary>
        /// <para>Variable is of type <see cref="string"/>.</para>
        /// </summary>
        String = 4,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector2"/>.</para>
        /// </summary>
        Vector2 = 5,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector2I"/>.</para>
        /// </summary>
        Vector2I = 6,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Rect2"/>.</para>
        /// </summary>
        Rect2 = 7,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Rect2I"/>.</para>
        /// </summary>
        Rect2I = 8,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector3"/>.</para>
        /// </summary>
        Vector3 = 9,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector3I"/>.</para>
        /// </summary>
        Vector3I = 10,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Transform2D"/>.</para>
        /// </summary>
        Transform2D = 11,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector4"/>.</para>
        /// </summary>
        Vector4 = 12,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector4I"/>.</para>
        /// </summary>
        Vector4I = 13,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Plane"/>.</para>
        /// </summary>
        Plane = 14,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Quaternion"/>.</para>
        /// </summary>
        Quaternion = 15,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Aabb"/>.</para>
        /// </summary>
        Aabb = 16,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Basis"/>.</para>
        /// </summary>
        Basis = 17,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Transform3D"/>.</para>
        /// </summary>
        Transform3D = 18,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Projection"/>.</para>
        /// </summary>
        Projection = 19,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Color"/>.</para>
        /// </summary>
        Color = 20,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.StringName"/>.</para>
        /// </summary>
        StringName = 21,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.NodePath"/>.</para>
        /// </summary>
        NodePath = 22,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Rid"/>.</para>
        /// </summary>
        Rid = 23,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.GodotObject"/>.</para>
        /// </summary>
        Object = 24,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Callable"/>.</para>
        /// </summary>
        Callable = 25,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Signal"/>.</para>
        /// </summary>
        Signal = 26,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Collections.Dictionary"/>.</para>
        /// </summary>
        Dictionary = 27,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Collections.Array"/>.</para>
        /// </summary>
        Array = 28,
        /// <summary>
        /// <para>Variable is of type <see cref="byte"/>[].</para>
        /// </summary>
        PackedByteArray = 29,
        /// <summary>
        /// <para>Variable is of type <see cref="int"/>[].</para>
        /// </summary>
        PackedInt32Array = 30,
        /// <summary>
        /// <para>Variable is of type <see cref="long"/>[].</para>
        /// </summary>
        PackedInt64Array = 31,
        /// <summary>
        /// <para>Variable is of type <see cref="float"/>[].</para>
        /// </summary>
        PackedFloat32Array = 32,
        /// <summary>
        /// <para>Variable is of type <see cref="double"/>[].</para>
        /// </summary>
        PackedFloat64Array = 33,
        /// <summary>
        /// <para>Variable is of type <see cref="string"/>[].</para>
        /// </summary>
        PackedStringArray = 34,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector2"/>[].</para>
        /// </summary>
        PackedVector2Array = 35,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector3"/>[].</para>
        /// </summary>
        PackedVector3Array = 36,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Color"/>[].</para>
        /// </summary>
        PackedColorArray = 37,
        /// <summary>
        /// <para>Variable is of type <see cref="Godot.Vector4"/>[].</para>
        /// </summary>
        PackedVector4Array = 38,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Variant.Type"/> enum.</para>
        /// </summary>
        Max = 39,
    }
}

public partial struct Variant
{

    public enum Operator : long
    {
        /// <summary>
        /// <para>Equality operator (<c>==</c>).</para>
        /// </summary>
        Equal = 0,
        /// <summary>
        /// <para>Inequality operator (<c>!=</c>).</para>
        /// </summary>
        NotEqual = 1,
        /// <summary>
        /// <para>Less than operator (<c>&lt;</c>).</para>
        /// </summary>
        Less = 2,
        /// <summary>
        /// <para>Less than or equal operator (<c>&lt;=</c>).</para>
        /// </summary>
        LessEqual = 3,
        /// <summary>
        /// <para>Greater than operator (<c>&gt;</c>).</para>
        /// </summary>
        Greater = 4,
        /// <summary>
        /// <para>Greater than or equal operator (<c>&gt;=</c>).</para>
        /// </summary>
        GreaterEqual = 5,
        /// <summary>
        /// <para>Addition operator (<c>+</c>).</para>
        /// </summary>
        Add = 6,
        /// <summary>
        /// <para>Subtraction operator (<c>-</c>).</para>
        /// </summary>
        Subtract = 7,
        /// <summary>
        /// <para>Multiplication operator (<c>*</c>).</para>
        /// </summary>
        Multiply = 8,
        /// <summary>
        /// <para>Division operator (<c>/</c>).</para>
        /// </summary>
        Divide = 9,
        /// <summary>
        /// <para>Unary negation operator (<c>-</c>).</para>
        /// </summary>
        Negate = 10,
        /// <summary>
        /// <para>Unary plus operator (<c>+</c>).</para>
        /// </summary>
        Positive = 11,
        /// <summary>
        /// <para>Remainder/modulo operator (<c>%</c>).</para>
        /// </summary>
        Module = 12,
        /// <summary>
        /// <para>Power operator (<c>**</c>).</para>
        /// </summary>
        Power = 13,
        /// <summary>
        /// <para>Left shift operator (<c>&lt;&lt;</c>).</para>
        /// </summary>
        ShiftLeft = 14,
        /// <summary>
        /// <para>Right shift operator (<c>&gt;&gt;</c>).</para>
        /// </summary>
        ShiftRight = 15,
        /// <summary>
        /// <para>Bitwise AND operator (<c>&amp;</c>).</para>
        /// </summary>
        BitAnd = 16,
        /// <summary>
        /// <para>Bitwise OR operator (<c>|</c>).</para>
        /// </summary>
        BitOr = 17,
        /// <summary>
        /// <para>Bitwise XOR operator (<c>^</c>).</para>
        /// </summary>
        BitXor = 18,
        /// <summary>
        /// <para>Bitwise NOT operator (<c>~</c>).</para>
        /// </summary>
        BitNegate = 19,
        /// <summary>
        /// <para>Logical AND operator (<c>and</c> or <c>&amp;&amp;</c>).</para>
        /// </summary>
        And = 20,
        /// <summary>
        /// <para>Logical OR operator (<c>or</c> or <c>||</c>).</para>
        /// </summary>
        Or = 21,
        /// <summary>
        /// <para>Logical XOR operator (not implemented in GDScript).</para>
        /// </summary>
        Xor = 22,
        /// <summary>
        /// <para>Logical NOT operator (<c>not</c> or <c>!</c>).</para>
        /// </summary>
        Not = 23,
        /// <summary>
        /// <para>Logical IN operator (<c>in</c>).</para>
        /// </summary>
        In = 24,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Variant.Operator"/> enum.</para>
        /// </summary>
        Max = 25,
    }
}
