using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                               
using System.Drawing;

public class MyGame : Game 
{

	public MyGame() : base(800, 600, false)
	{
        Level level = new Level();
        AddChild(level);

       // HUD hud;
       // hud = new HUD(enemy);
       // AddChild(hud);
       
    }
    void Update() 
	{

	}

	static void Main()                         
	{
		new MyGame().Start();                  
	}
   


}