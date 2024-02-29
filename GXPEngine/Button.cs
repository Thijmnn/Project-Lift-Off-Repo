using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GXPEngine.MouseHandler;

namespace GXPEngine
{
    // Button class
    public class Button : EasyDraw
    {
        public event Action OnButtonClick;

        public Button(string text, int width, int height) : base(width, height)
        {
            // Manually adjust text position for centering
            float textX = (width - TextWidth(text)) / 2;
            float textY = (height - TextHeight(text)) / 2;

            // Draw text in the center of the button
            Fill(0, 0, 0); // Text color
            TextAlign(CenterMode.Min, CenterMode.Min);
            TextFont(new Font("Arial", 25, System.Drawing.FontStyle.Regular));

            Text(text, textX, textY);
        }

        public void Update()
        {
            // Check for mouse click inside the button
            if (Input.GetKeyDown(Key.F))
            {
                OnButtonClick?.Invoke();
            }
        }
    }

}