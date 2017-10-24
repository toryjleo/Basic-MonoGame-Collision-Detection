using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ShapeDrawer
{
    private SpriteBatch spriteBatch;
    private Texture2D pixel;

	public ShapeDrawer(SpriteBatch spriteBatch, GraphicsDevice device)
	{
        // Save the sprite batch
        this.spriteBatch = spriteBatch;
        // Create white pixel
        pixel = new Texture2D(device, 1, 1);
        pixel.SetData<Color>(new Color[] { Color.White });
    }

    public void DrawLine(int x0, int y0, int x1, int y1, int thickness, Color color)
    {
        // Calculate the length of the line
        float length = Vector2.Distance(
            new Vector2(x0, y0),
            new Vector2(x1, y1));

        // Calculate the angle between our desired line
        // and the x axis
        float angle = (float)Math.Atan2(y1 - y0, x1 - x0);

        // Create the rectangle we intend to draw
        Rectangle rectToDraw = new Rectangle(
            x0,
            y0,
            (int)length,
            thickness);

        // Use the Draw() overload that accepts a rotation
        spriteBatch.Draw(
            pixel,
            rectToDraw,
            null,
            color,
            angle,
            new Vector2(0, 0.5f),
            SpriteEffects.None,
            0.0f);
    }

    public void DrawCircle(int x, int y, int radius, int segments, Color color)
    {
        // Verify valid parameters
        if (segments <= 0)
        {
            return;
        }

        // Starting point
        float currentX = x + radius;
        float currentY = y;

        // Angle per segment
        float step = MathHelper.TwoPi / segments;
        float currentAngle = step;


        // Loop
        for (int i = 0; i < segments; i++)
        {
            // Calculate the new point on the circle
            float newX = (float)Math.Cos(currentAngle);
            float newY = (float)Math.Sin(currentAngle);

            // Transform these to our circle
            newX = newX * radius + x;
            newY = newY * radius + y;

            // Draw the line
            DrawLine(
                (int)currentX,
                (int)currentY,
                (int)newX,
                (int)newY,
                1,
                color);

            // Adjust the angle for next time
            currentAngle += step;

            // Overwrite current with the new value
            currentX = newX;
            currentY = newY;
        }

    }

    public void DrawPoint(int x, int y, Color color)
    {
        spriteBatch.Draw(
            pixel,
            new Vector2(x, y),
            color);
    }

    public void DrawRectFilled(int x, int y, int width, int height, Color color)
    {
        Rectangle rectToDraw = new Rectangle(
            x,
            y,
            width,
            height);
        spriteBatch.Draw(pixel, rectToDraw, color);
    }

    public void DrawRectOutline(int x, int y, int width, int height, Color color)
    {
        DrawLine(x, y, x+ width, y, 1, color);
        DrawLine(x, y+height, x + width, y+height, 1, color);
        DrawLine(x, y, x, y+height, 1, color);
        DrawLine(x+width, y, x + width, y+height, 1, color);
    }
}
