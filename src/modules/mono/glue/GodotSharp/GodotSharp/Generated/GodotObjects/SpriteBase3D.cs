namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node that displays 2D texture information in a 3D environment. See also <see cref="Godot.Sprite3D"/> where many other properties are defined.</para>
/// </summary>
public partial class SpriteBase3D : GeometryInstance3D
{
    public enum DrawFlags : long
    {
        /// <summary>
        /// <para>If set, the texture's transparency and the opacity are used to make those parts of the sprite invisible.</para>
        /// </summary>
        Transparent = 0,
        /// <summary>
        /// <para>If set, lights in the environment affect the sprite.</para>
        /// </summary>
        Shaded = 1,
        /// <summary>
        /// <para>If set, texture can be seen from the back as well. If not, the texture is invisible when looking at it from behind.</para>
        /// </summary>
        DoubleSided = 2,
        /// <summary>
        /// <para>Disables the depth test, so this object is drawn on top of all others. However, objects drawn after it in the draw order may cover it.</para>
        /// </summary>
        DisableDepthTest = 3,
        /// <summary>
        /// <para>Label is scaled by depth so that it always appears the same size on screen.</para>
        /// </summary>
        FixedSize = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.SpriteBase3D.DrawFlags"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum AlphaCutMode : long
    {
        /// <summary>
        /// <para>This mode performs standard alpha blending. It can display translucent areas, but transparency sorting issues may be visible when multiple transparent materials are overlapping.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>This mode only allows fully transparent or fully opaque pixels. Harsh edges will be visible unless some form of screen-space antialiasing is enabled (see <c>ProjectSettings.rendering/anti_aliasing/quality/screen_space_aa</c>). On the bright side, this mode doesn't suffer from transparency sorting issues when multiple transparent materials are overlapping. This mode is also known as <i>alpha testing</i> or <i>1-bit transparency</i>.</para>
        /// </summary>
        Discard = 1,
        /// <summary>
        /// <para>This mode draws fully opaque pixels in the depth prepass. This is slower than <see cref="Godot.SpriteBase3D.AlphaCutMode.Disabled"/> or <see cref="Godot.SpriteBase3D.AlphaCutMode.Discard"/>, but it allows displaying translucent areas and smooth edges while using proper sorting.</para>
        /// </summary>
        OpaquePrepass = 2,
        /// <summary>
        /// <para>This mode draws cuts off all values below a spatially-deterministic threshold, the rest will remain opaque.</para>
        /// </summary>
        Hash = 3
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture will be centered.</para>
    /// </summary>
    public bool Centered
    {
        get
        {
            return IsCentered();
        }
        set
        {
            SetCentered(value);
        }
    }

    /// <summary>
    /// <para>The texture's drawing offset.</para>
    /// <para><b>Note:</b> When you increase <see cref="Godot.SpriteBase3D.Offset"/>.y in Sprite3D, the sprite moves upward in world space (i.e., +Y is up).</para>
    /// </summary>
    public Vector2 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture is flipped horizontally.</para>
    /// </summary>
    public bool FlipH
    {
        get
        {
            return IsFlippedH();
        }
        set
        {
            SetFlipH(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture is flipped vertically.</para>
    /// </summary>
    public bool FlipV
    {
        get
        {
            return IsFlippedV();
        }
        set
        {
            SetFlipV(value);
        }
    }

    /// <summary>
    /// <para>A color value used to <i>multiply</i> the texture's colors. Can be used for mood-coloring or to simulate the color of ambient light.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.CanvasItem.Modulate"/> for 2D, colors with values above <c>1.0</c> (overbright) are not supported.</para>
    /// <para><b>Note:</b> If a <see cref="Godot.GeometryInstance3D.MaterialOverride"/> is defined on the <see cref="Godot.SpriteBase3D"/>, the material override must be configured to take vertex colors into account for albedo. Otherwise, the color defined in <see cref="Godot.SpriteBase3D.Modulate"/> will be ignored. For a <see cref="Godot.BaseMaterial3D"/>, <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> must be <see langword="true"/>. For a <see cref="Godot.ShaderMaterial"/>, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function.</para>
    /// </summary>
    public Color Modulate
    {
        get
        {
            return GetModulate();
        }
        set
        {
            SetModulate(value);
        }
    }

    /// <summary>
    /// <para>The size of one pixel's width on the sprite to scale it in 3D.</para>
    /// </summary>
    public float PixelSize
    {
        get
        {
            return GetPixelSize();
        }
        set
        {
            SetPixelSize(value);
        }
    }

    /// <summary>
    /// <para>The direction in which the front of the texture faces.</para>
    /// </summary>
    public Vector3.Axis Axis
    {
        get
        {
            return GetAxis();
        }
        set
        {
            SetAxis(value);
        }
    }

    /// <summary>
    /// <para>The billboard mode to use for the sprite.</para>
    /// <para><b>Note:</b> When billboarding is enabled and the material also casts shadows, billboards will face <b>the</b> camera in the scene when rendering shadows. In scenes with multiple cameras, the intended shadow cannot be determined and this will result in undefined behavior. See <a href="https://github.com/godotengine/godot/pull/72638">GitHub Pull Request #72638</a> for details.</para>
    /// </summary>
    public BaseMaterial3D.BillboardModeEnum Billboard
    {
        get
        {
            return GetBillboardMode();
        }
        set
        {
            SetBillboardMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the texture's transparency and the opacity are used to make those parts of the sprite invisible.</para>
    /// </summary>
    public bool Transparent
    {
        get
        {
            return GetDrawFlag((SpriteBase3D.DrawFlags)(0));
        }
        set
        {
            SetDrawFlag((SpriteBase3D.DrawFlags)(0), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Light3D"/> in the <see cref="Godot.Environment"/> has effects on the sprite.</para>
    /// </summary>
    public bool Shaded
    {
        get
        {
            return GetDrawFlag((SpriteBase3D.DrawFlags)(1));
        }
        set
        {
            SetDrawFlag((SpriteBase3D.DrawFlags)(1), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture can be seen from the back as well, if <see langword="false"/>, it is invisible when looking at it from behind.</para>
    /// </summary>
    public bool DoubleSided
    {
        get
        {
            return GetDrawFlag((SpriteBase3D.DrawFlags)(2));
        }
        set
        {
            SetDrawFlag((SpriteBase3D.DrawFlags)(2), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, depth testing is disabled and the object will be drawn in render order.</para>
    /// </summary>
    public bool NoDepthTest
    {
        get
        {
            return GetDrawFlag((SpriteBase3D.DrawFlags)(3));
        }
        set
        {
            SetDrawFlag((SpriteBase3D.DrawFlags)(3), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the texture is rendered at the same size regardless of distance. The texture's size on screen is the same as if the camera was <c>1.0</c> units away from the texture's origin, regardless of the actual distance from the camera. The <see cref="Godot.Camera3D"/>'s field of view (or <see cref="Godot.Camera3D.Size"/> when in orthogonal/frustum mode) still affects the size the sprite is drawn at.</para>
    /// </summary>
    public bool FixedSize
    {
        get
        {
            return GetDrawFlag((SpriteBase3D.DrawFlags)(4));
        }
        set
        {
            SetDrawFlag((SpriteBase3D.DrawFlags)(4), value);
        }
    }

    /// <summary>
    /// <para>The alpha cutting mode to use for the sprite.</para>
    /// </summary>
    public SpriteBase3D.AlphaCutMode AlphaCut
    {
        get
        {
            return GetAlphaCutMode();
        }
        set
        {
            SetAlphaCutMode(value);
        }
    }

    /// <summary>
    /// <para>Threshold at which the alpha scissor will discard values.</para>
    /// </summary>
    public float AlphaScissorThreshold
    {
        get
        {
            return GetAlphaScissorThreshold();
        }
        set
        {
            SetAlphaScissorThreshold(value);
        }
    }

    /// <summary>
    /// <para>The hashing scale for Alpha Hash. Recommended values between <c>0</c> and <c>2</c>.</para>
    /// </summary>
    public float AlphaHashScale
    {
        get
        {
            return GetAlphaHashScale();
        }
        set
        {
            SetAlphaHashScale(value);
        }
    }

    /// <summary>
    /// <para>The type of alpha antialiasing to apply.</para>
    /// </summary>
    public BaseMaterial3D.AlphaAntiAliasing AlphaAntialiasingMode
    {
        get
        {
            return GetAlphaAntialiasing();
        }
        set
        {
            SetAlphaAntialiasing(value);
        }
    }

    /// <summary>
    /// <para>Threshold at which antialiasing will be applied on the alpha channel.</para>
    /// </summary>
    public float AlphaAntialiasingEdge
    {
        get
        {
            return GetAlphaAntialiasingEdge();
        }
        set
        {
            SetAlphaAntialiasingEdge(value);
        }
    }

    /// <summary>
    /// <para>Filter flags for the texture.</para>
    /// <para><b>Note:</b> Linear filtering may cause artifacts around the edges, which are especially noticeable on opaque textures. To prevent this, use textures with transparent or identical colors around the edges.</para>
    /// </summary>
    public BaseMaterial3D.TextureFilterEnum TextureFilter
    {
        get
        {
            return GetTextureFilter();
        }
        set
        {
            SetTextureFilter(value);
        }
    }

    /// <summary>
    /// <para>Sets the render priority for the sprite. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="Godot.SpriteBase3D.AlphaCut"/> is set to <see cref="Godot.SpriteBase3D.AlphaCutMode.Disabled"/> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    public int RenderPriority
    {
        get
        {
            return GetRenderPriority();
        }
        set
        {
            SetRenderPriority(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SpriteBase3D);

    private static readonly StringName NativeName = "SpriteBase3D";

    internal SpriteBase3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpriteBase3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpriteBase3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCentered, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCentered(bool centered)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), centered.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCentered, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCentered()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind2, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipH, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipH(bool flipH)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), flipH.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedH, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedH()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipV, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipV(bool flipV)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), flipV.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedV, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedV()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetModulate(Color modulate)
    {
        NativeCalls.godot_icall_1_213(MethodBind8, GodotObject.GetPtr(this), &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRenderPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPixelSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPixelSize(float pixelSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), pixelSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPixelSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPixelSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxis, 1144690656ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAxis(Vector3.Axis axis)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAxis, 3050976882ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3.Axis GetAxis()
    {
        return (Vector3.Axis)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawFlag, 1135633219ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the specified flag will be enabled.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawFlag(SpriteBase3D.DrawFlags flag, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind16, GodotObject.GetPtr(this), (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawFlag, 1733036628ul);

    /// <summary>
    /// <para>Returns the value of the specified flag.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDrawFlag(SpriteBase3D.DrawFlags flag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind17, GodotObject.GetPtr(this), (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaCutMode, 227561226ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaCutMode(SpriteBase3D.AlphaCutMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaCutMode, 336003791ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SpriteBase3D.AlphaCutMode GetAlphaCutMode()
    {
        return (SpriteBase3D.AlphaCutMode)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaScissorThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaScissorThreshold(float threshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaScissorThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAlphaScissorThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaHashScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaHashScale(float threshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaHashScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAlphaHashScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaAntialiasing, 3212649852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaAntialiasing(BaseMaterial3D.AlphaAntiAliasing alphaAA)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)alphaAA);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaAntialiasing, 2889939400ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BaseMaterial3D.AlphaAntiAliasing GetAlphaAntialiasing()
    {
        return (BaseMaterial3D.AlphaAntiAliasing)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaAntialiasingEdge, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaAntialiasingEdge(float edge)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), edge);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaAntialiasingEdge, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAlphaAntialiasingEdge()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBillboardMode, 4202036497ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBillboardMode(BaseMaterial3D.BillboardModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBillboardMode, 1283840139ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BaseMaterial3D.BillboardModeEnum GetBillboardMode()
    {
        return (BaseMaterial3D.BillboardModeEnum)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureFilter, 22904437ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureFilter(BaseMaterial3D.TextureFilterEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureFilter, 3289213076ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BaseMaterial3D.TextureFilterEnum GetTextureFilter()
    {
        return (BaseMaterial3D.TextureFilterEnum)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemRect, 1639390495ul);

    /// <summary>
    /// <para>Returns the rectangle representing this sprite.</para>
    /// </summary>
    public Rect2 GetItemRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateTriangleMesh, 3476533166ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.TriangleMesh"/> with the sprite's vertices following its current configuration (such as its <see cref="Godot.SpriteBase3D.Axis"/> and <see cref="Godot.SpriteBase3D.PixelSize"/>).</para>
    /// </summary>
    public TriangleMesh GenerateTriangleMesh()
    {
        return (TriangleMesh)NativeCalls.godot_icall_0_63(MethodBind33, GodotObject.GetPtr(this));
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
    public new class PropertyName : GeometryInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'centered' property.
        /// </summary>
        public static readonly StringName Centered = "centered";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'flip_h' property.
        /// </summary>
        public static readonly StringName FlipH = "flip_h";
        /// <summary>
        /// Cached name for the 'flip_v' property.
        /// </summary>
        public static readonly StringName FlipV = "flip_v";
        /// <summary>
        /// Cached name for the 'modulate' property.
        /// </summary>
        public static readonly StringName Modulate = "modulate";
        /// <summary>
        /// Cached name for the 'pixel_size' property.
        /// </summary>
        public static readonly StringName PixelSize = "pixel_size";
        /// <summary>
        /// Cached name for the 'axis' property.
        /// </summary>
        public static readonly StringName Axis = "axis";
        /// <summary>
        /// Cached name for the 'billboard' property.
        /// </summary>
        public static readonly StringName Billboard = "billboard";
        /// <summary>
        /// Cached name for the 'transparent' property.
        /// </summary>
        public static readonly StringName Transparent = "transparent";
        /// <summary>
        /// Cached name for the 'shaded' property.
        /// </summary>
        public static readonly StringName Shaded = "shaded";
        /// <summary>
        /// Cached name for the 'double_sided' property.
        /// </summary>
        public static readonly StringName DoubleSided = "double_sided";
        /// <summary>
        /// Cached name for the 'no_depth_test' property.
        /// </summary>
        public static readonly StringName NoDepthTest = "no_depth_test";
        /// <summary>
        /// Cached name for the 'fixed_size' property.
        /// </summary>
        public static readonly StringName FixedSize = "fixed_size";
        /// <summary>
        /// Cached name for the 'alpha_cut' property.
        /// </summary>
        public static readonly StringName AlphaCut = "alpha_cut";
        /// <summary>
        /// Cached name for the 'alpha_scissor_threshold' property.
        /// </summary>
        public static readonly StringName AlphaScissorThreshold = "alpha_scissor_threshold";
        /// <summary>
        /// Cached name for the 'alpha_hash_scale' property.
        /// </summary>
        public static readonly StringName AlphaHashScale = "alpha_hash_scale";
        /// <summary>
        /// Cached name for the 'alpha_antialiasing_mode' property.
        /// </summary>
        public static readonly StringName AlphaAntialiasingMode = "alpha_antialiasing_mode";
        /// <summary>
        /// Cached name for the 'alpha_antialiasing_edge' property.
        /// </summary>
        public static readonly StringName AlphaAntialiasingEdge = "alpha_antialiasing_edge";
        /// <summary>
        /// Cached name for the 'texture_filter' property.
        /// </summary>
        public static readonly StringName TextureFilter = "texture_filter";
        /// <summary>
        /// Cached name for the 'render_priority' property.
        /// </summary>
        public static readonly StringName RenderPriority = "render_priority";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GeometryInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_centered' method.
        /// </summary>
        public static readonly StringName SetCentered = "set_centered";
        /// <summary>
        /// Cached name for the 'is_centered' method.
        /// </summary>
        public static readonly StringName IsCentered = "is_centered";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_flip_h' method.
        /// </summary>
        public static readonly StringName SetFlipH = "set_flip_h";
        /// <summary>
        /// Cached name for the 'is_flipped_h' method.
        /// </summary>
        public static readonly StringName IsFlippedH = "is_flipped_h";
        /// <summary>
        /// Cached name for the 'set_flip_v' method.
        /// </summary>
        public static readonly StringName SetFlipV = "set_flip_v";
        /// <summary>
        /// Cached name for the 'is_flipped_v' method.
        /// </summary>
        public static readonly StringName IsFlippedV = "is_flipped_v";
        /// <summary>
        /// Cached name for the 'set_modulate' method.
        /// </summary>
        public static readonly StringName SetModulate = "set_modulate";
        /// <summary>
        /// Cached name for the 'get_modulate' method.
        /// </summary>
        public static readonly StringName GetModulate = "get_modulate";
        /// <summary>
        /// Cached name for the 'set_render_priority' method.
        /// </summary>
        public static readonly StringName SetRenderPriority = "set_render_priority";
        /// <summary>
        /// Cached name for the 'get_render_priority' method.
        /// </summary>
        public static readonly StringName GetRenderPriority = "get_render_priority";
        /// <summary>
        /// Cached name for the 'set_pixel_size' method.
        /// </summary>
        public static readonly StringName SetPixelSize = "set_pixel_size";
        /// <summary>
        /// Cached name for the 'get_pixel_size' method.
        /// </summary>
        public static readonly StringName GetPixelSize = "get_pixel_size";
        /// <summary>
        /// Cached name for the 'set_axis' method.
        /// </summary>
        public static readonly StringName SetAxis = "set_axis";
        /// <summary>
        /// Cached name for the 'get_axis' method.
        /// </summary>
        public static readonly StringName GetAxis = "get_axis";
        /// <summary>
        /// Cached name for the 'set_draw_flag' method.
        /// </summary>
        public static readonly StringName SetDrawFlag = "set_draw_flag";
        /// <summary>
        /// Cached name for the 'get_draw_flag' method.
        /// </summary>
        public static readonly StringName GetDrawFlag = "get_draw_flag";
        /// <summary>
        /// Cached name for the 'set_alpha_cut_mode' method.
        /// </summary>
        public static readonly StringName SetAlphaCutMode = "set_alpha_cut_mode";
        /// <summary>
        /// Cached name for the 'get_alpha_cut_mode' method.
        /// </summary>
        public static readonly StringName GetAlphaCutMode = "get_alpha_cut_mode";
        /// <summary>
        /// Cached name for the 'set_alpha_scissor_threshold' method.
        /// </summary>
        public static readonly StringName SetAlphaScissorThreshold = "set_alpha_scissor_threshold";
        /// <summary>
        /// Cached name for the 'get_alpha_scissor_threshold' method.
        /// </summary>
        public static readonly StringName GetAlphaScissorThreshold = "get_alpha_scissor_threshold";
        /// <summary>
        /// Cached name for the 'set_alpha_hash_scale' method.
        /// </summary>
        public static readonly StringName SetAlphaHashScale = "set_alpha_hash_scale";
        /// <summary>
        /// Cached name for the 'get_alpha_hash_scale' method.
        /// </summary>
        public static readonly StringName GetAlphaHashScale = "get_alpha_hash_scale";
        /// <summary>
        /// Cached name for the 'set_alpha_antialiasing' method.
        /// </summary>
        public static readonly StringName SetAlphaAntialiasing = "set_alpha_antialiasing";
        /// <summary>
        /// Cached name for the 'get_alpha_antialiasing' method.
        /// </summary>
        public static readonly StringName GetAlphaAntialiasing = "get_alpha_antialiasing";
        /// <summary>
        /// Cached name for the 'set_alpha_antialiasing_edge' method.
        /// </summary>
        public static readonly StringName SetAlphaAntialiasingEdge = "set_alpha_antialiasing_edge";
        /// <summary>
        /// Cached name for the 'get_alpha_antialiasing_edge' method.
        /// </summary>
        public static readonly StringName GetAlphaAntialiasingEdge = "get_alpha_antialiasing_edge";
        /// <summary>
        /// Cached name for the 'set_billboard_mode' method.
        /// </summary>
        public static readonly StringName SetBillboardMode = "set_billboard_mode";
        /// <summary>
        /// Cached name for the 'get_billboard_mode' method.
        /// </summary>
        public static readonly StringName GetBillboardMode = "get_billboard_mode";
        /// <summary>
        /// Cached name for the 'set_texture_filter' method.
        /// </summary>
        public static readonly StringName SetTextureFilter = "set_texture_filter";
        /// <summary>
        /// Cached name for the 'get_texture_filter' method.
        /// </summary>
        public static readonly StringName GetTextureFilter = "get_texture_filter";
        /// <summary>
        /// Cached name for the 'get_item_rect' method.
        /// </summary>
        public static readonly StringName GetItemRect = "get_item_rect";
        /// <summary>
        /// Cached name for the 'generate_triangle_mesh' method.
        /// </summary>
        public static readonly StringName GenerateTriangleMesh = "generate_triangle_mesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GeometryInstance3D.SignalName
    {
    }
}
