using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Metadata;

namespace quora_images;

class Program
{
    private const string path = "output.png"; 
    private static int width = 580;
    private static int height = 154273;
    private static int ppi = 72;
    private static Color bgColor = Color.Black;
    private static Color snekColor = Color.Red;
    private static SolidBrush snek = Brushes.Solid(snekColor);
    private static int snekWidth = 50;
    private static int yPosition;
    private static bool movingRight;
    private static int xStart;
    private static int xEnd;
    
    static void Main(string[] args)
    {
        using (Image image = new Image<Rgba32>(width, height))
        {
            image.Metadata.HorizontalResolution = ppi;
            image.Metadata.VerticalResolution = ppi;

            // Set the background to black
            image.Mutate(x => x.BackgroundColor(bgColor));

            // Prepare to draw the snek
            yPosition = 0;
            movingRight = true;

            while (yPosition < height)
            {
                xStart = movingRight ? 0 : width;
                xEnd = movingRight ? width : 0;

                // Draw the full width part (Section 1)
                image.Mutate(x => x.FillPolygon(snek,
                [
                    new PointF(xStart, yPosition),
                    new PointF(xEnd, yPosition),
                    new PointF(xEnd, yPosition + snekWidth),
                    new PointF(xStart, yPosition + snekWidth)
                ]));

                // Increment y by the snek width to start the next section
                yPosition += snekWidth * 2;

                // Reverse the direction for the next draw
                movingRight = !movingRight;
            }

            // Save the image
            image.Save(path);
            Console.WriteLine("Image has been saved successfully.");
        }
    }
}

