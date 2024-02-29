using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                               
using System.Drawing;
using System.Collections.Generic;
using TiledMapParser;

public class MyGame : Game 
{
    Button startButton;
    Button restartButton;
    Button exitButton;
    GameOverScreen gameoverscreen;
    StartScreen startscreen;
    private Level level;
    GameState gameState;
    bool gameStart = false;
    int TextX;

    enum GameState
    {
        MainMenu,
        Playing,
        RestartMenu
    }

    public MyGame() : base(1366, 768, false)
	{

        InitializeMainMenu();
    }
    static void Main()
    {
        new MyGame().Start();
    }

    void Update() 
	{

        
        if (Player.playerHealth <= 0)
        {
            gameState = GameState.RestartMenu;
            // Remove all existing children
            foreach (var child in GetChildren())
            {
                RemoveChild(child);
            }
            ResetGame();
        }
        else if (gameState == GameState.RestartMenu)
        {
            if (Input.GetKeyDown(Key.F))
            {
                ResetGame();
            }
        }
    }


    void InitializeMainMenu()
    {
        x = 0; 
        y = 0;
        gameState = GameState.MainMenu;

        startscreen = new StartScreen();
        startButton = new Button("Fire To Start", 400, 150);
        startButton.SetXY(425, height / 2 - 150);
        startButton.OnButtonClick += StartButton_OnButtonClick;
        
        
        AddChild(startscreen);
        AddChild(startButton);
    }

    

    void RemoveMainMenu()
    {
        RemoveChild(startButton); 
    }

    void SetupGame()
    {
        Player.playerHealth = 10;
        restartLevel();
        gameState = GameState.Playing;
        gameStart = true;
    }
    

    void ResetGame()
    {
        x = 0;
        y = 0;
        gameState = GameState.MainMenu;
        gameoverscreen = new GameOverScreen();
        startButton = new Button("Fire To Try Again", 400, 150);
        startButton.SetXY(width / 2, height / 2 - 150);
        startButton.OnButtonClick += RestartButton_OnButtonClick;
        AddChild(gameoverscreen);
        AddChild(startButton);
    }
    void restartLevel()
    {
        if (level != null)
        {
            level.Destroy();
            level = null;
        }
        level = new Level();
        AddChild(level);
    }
    void RestartButton_OnButtonClick()
    {
        gameState = GameState.Playing;
        gameStart = true;

        RemoveChild(gameoverscreen);
        RemoveMainMenu();
        SetupGame();
    }
    void StartButton_OnButtonClick()
    {
        gameState = GameState.Playing;
        gameStart = true;

        RemoveChild(startscreen);
        RemoveMainMenu();
        SetupGame();
    }
}