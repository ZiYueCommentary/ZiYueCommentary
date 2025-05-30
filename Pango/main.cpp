#include <pango/pangocairo.h>

void render() {
    // 初始化Cairo和Pango
    cairo_surface_t* surface = cairo_image_surface_create(CAIRO_FORMAT_A1, 640, 480);
    cairo_t* cr = cairo_create(surface);
    PangoLayout* layout;
    PangoFontDescription* desc;

    // 创建Pango布局
    layout = pango_cairo_create_layout(cr);
    pango_layout_set_text(layout, "说的道理", -1);

    // 设置字体
    desc = pango_font_description_from_string("Containment Breach");
    pango_layout_set_font_description(layout, desc);
    pango_font_description_free(desc);

    // 设置文本颜色
    cairo_set_source_rgb(cr, 255.0, 255.0, 255.0);

    // 渲染文本
    pango_cairo_update_layout(cr, layout);
    pango_cairo_show_layout(cr, layout);

    // 保存结果到文件
    cairo_surface_write_to_png(surface, "output.png");

    // 清理
    g_object_unref(layout);
    cairo_destroy(cr);
    cairo_surface_destroy(surface);

    return;
}