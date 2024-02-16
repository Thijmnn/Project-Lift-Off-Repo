using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    public class HUD : Canvas
    {
        private Enemy _enemy;
        public HUD (Enemy enemy) : base (128, 64)
        {
            _enemy = enemy;
        }
        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("Hit Range" + _enemy.GetScore(),SystemFonts.DefaultFont, Brushes.White, 0,0);
        }
    }
}
