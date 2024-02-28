using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                               
using System.Drawing;

public class MyGame : Game 
{
	private Level level;
	public MyGame() : base(1920, 1080, false)
	{
		restartLevel(); 
    }
    void restartLevel()
    {
		if(level != null)
		{
			level.Destroy();
			level = null;
		}
        level = new Level();
        AddChild(level);  
    }
    void Update() 
	{
		if(Enemy.playerHealth <= 0)
		{
			restartLevel();
		}
	}
	
	static void Main()                         
	{
		new MyGame().Start();                  
	}
   


}