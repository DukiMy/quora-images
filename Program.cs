using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Drawing;

namespace quora_images;
class Program
{
    static void Main(string[] args)
    {
        // The greatest height possible for an image on quora.com
        int width = 1;
        int height = 1000000;
        int ppi = 1;

        using (Image<Rgba32> image = new CanvasBuilder()
            .setWidth(width)
            .setHeight(height)
            .setPpi(ppi)
            .setBgColor(Color.FromRgb(38, 38, 38))
            .buildCanvas())
        {

        // bool drawRed = true;
        // for (int i = 0; i < height; i++)
        // {
        //     if (i % 100 == 0)
        //     {
        //         drawRed = !drawRed; // Toggle the drawing state every 50 pixels
        //     }

        //     if (drawRed)
        //     {
        //         // Draw a dot at the current pixel height
        //         image.Mutate(x => x.Fill(Color.FromRgba(0, 0, 0, 0), new EllipsePolygon(0, i, 0.5f)));
        //     }
        // }

            // Save the image
            image.Save(height + "_" + width + "_" + ppi + ".png");
            Console.WriteLine("Image has been saved successfully.");
        }
    }

    public static void StripedImage (int width, int height, int ppi) {
        
        Color snekColor = Color.Red;
        SolidBrush snek = Brushes.Solid(snekColor);
        int snekWidth = 50;
        int yPosition;
        bool movingRight;
        int xStart;
        int xEnd;


        using (Image<Rgba32> image = new CanvasBuilder()
            .setWidth(width)
            .setHeight(height)
            .setPpi(ppi)
            .setBgColor(Color.BlanchedAlmond)
            .buildCanvas())
        {
            // Prepare to draw the snek
            yPosition = 0;
            movingRight = true;

            while (yPosition < image.Height)
            {
                xStart = movingRight ? 0 : image.Width;
                xEnd = movingRight ? image.Width : 0;

                // Draw the full width part (Section 1)
                image.Mutate(x => x.FillPolygon(snek,
                new PointF[]
                {
                    new PointF(xStart, yPosition),
                    new PointF(xEnd, yPosition),
                    new PointF(xEnd, yPosition + snekWidth),
                    new PointF(xStart, yPosition + snekWidth)
                }));

                // Increment y by the snek width to start the next section
                yPosition += snekWidth * 2;

                // Reverse the direction for the next draw
                movingRight = !movingRight;
            }

            // Save the image
            image.Save(height + "_" + width + "_" + ppi + ".png");
            Console.WriteLine("Image has been saved successfully.");
        }
    }
}
