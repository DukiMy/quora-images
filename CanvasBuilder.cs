using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Metadata;
using System.Runtime.CompilerServices;

namespace quora_images
{
public class CanvasBuilder
    {
        private int width;
        private int height;
        private int ppi;
        private Color bgColor;

        public CanvasBuilder setWidth(int width)
        {
            this.width = width;
            return this;
        }

        public CanvasBuilder setHeight(int height)
        {
            this.height = height;
            return this;
        }

        public CanvasBuilder setPpi(int ppi)
        {
            this.ppi = ppi;
            return this;
        }

        public CanvasBuilder setBgColor(Color bgColor)
        {
            this.bgColor = bgColor;
            return this;
        }

        public Image<Rgba32> buildCanvas()
        {
            var image = new Image<Rgba32>(width, height);
            image.Metadata.ResolutionUnits = PixelResolutionUnit.PixelsPerInch;
            image.Metadata.HorizontalResolution = ppi;
            image.Metadata.VerticalResolution = ppi;

            image.Mutate(ctx => ctx.Fill(bgColor));

            return image;
        }
    }
}