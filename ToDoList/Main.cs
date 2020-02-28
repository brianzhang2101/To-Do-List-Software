using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Major_Project
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Main()
        {
            #region General Settings of Program
            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1600; //Width
            graphics.PreferredBackBufferHeight = 900; // Height
            Content.RootDirectory = "Content";
            #endregion
        }

        protected override void Initialize()
        {
            Window.Title = "Pre-Crastinate"; // Title
            base.Initialize();
        }
        #region Defining Variables
        public Texture2D home_Button;
        public Texture2D todo_Button;
        public Texture2D level_Button;
        public Texture2D help_Button;
        public static Texture2D low_Button;
        public static Texture2D med_Button;
        public static Texture2D high_Button;
        public static Texture2D instimg;
        public static Texture2D homeimg;
        public static Texture2D todoimg;
        public static Texture2D progressimg;
        public static Texture2D textbox;
        public static Texture2D deleteButton;
        public static Texture2D textBar;
        public static Texture2D priorityBar;
        public static Texture2D completeButton;
        public static Texture2D noMedal;
        public static Texture2D bronzeMedal;
        public static Texture2D silverMedal;
        public static Texture2D goldMedal;
        public static menuButtons MenuButtons;
        public static HelpPage helpPage;
        public static HomePage homePage;
        public static TodoPage todoPage;
        public static ProgressPage progressPage;
        public static SpriteFont font;
        public static SpriteFont timefont;
        public static SpriteFont tinyfont;
        public static Color mainState = Color.White;
        public static Color todoState = Color.Gray;
        public static Color levelState = Color.Gray;
        public static Color helpState = Color.Gray;
        public static Color lowState = Color.White;
        public static Color medState = Color.White;
        public static Color highState = Color.White;
        public static Color textState = Color.Gray;
        public static GameWindow gw;
        public static MouseState oldState;
        public static bool alreadyExists;
        public static bool myBoxHasFocus; //TextBox Focus
        public static bool homeScreen = true;
        public static bool todoScreen = false;
        public static bool progressScreen = false;
        public static bool helpScreen = false;
        public static int count = 0; 
        public static int points = 0;
        public static int tasksCompleted = 0;
        public static bool dataReady;
        public static bool emptyBox;
        public static string savepath = @"C:\Users\Brian\Dropbox\ToDoList\ToDoList\ToDoList\Content\Saves\saves.txt";
        #endregion
        StringBuilder myTextBoxDisplayCharacters = new StringBuilder(); //Writing Text Function
        Dictionary<string, string> tabContent = new Dictionary<string, string>(); //Dictionary for tabs
        protected override void LoadContent()
        {
            #region Loading Sprites/Linking Other Files to Main File
            spriteBatch = new SpriteBatch(GraphicsDevice);
            home_Button = Content.Load<Texture2D>("Sprites/Home-Button");
            todo_Button = Content.Load<Texture2D>("Sprites/Todo-Button");
            level_Button = Content.Load<Texture2D>("Sprites/Level-Button");
            help_Button = Content.Load<Texture2D>("Sprites/Help-Button");
            low_Button = Content.Load<Texture2D>("Sprites/Low-Button");
            med_Button = Content.Load<Texture2D>("Sprites/Med-Button");
            high_Button = Content.Load<Texture2D>("Sprites/High-Button");
            instimg = Content.Load<Texture2D>("Sprites/Help Screen");
            homeimg = Content.Load<Texture2D>("Sprites/Home Screen");
            todoimg = Content.Load<Texture2D>("Sprites/To-Do List Screen");
            progressimg = Content.Load<Texture2D>("Sprites/Progress Screen");
            textbox = Content.Load<Texture2D>("Sprites/Textbox");
            deleteButton = Content.Load<Texture2D>("Sprites/Delete-Button");
            textBar = Content.Load<Texture2D>("Sprites/Text-Bar");
            priorityBar = Content.Load<Texture2D>("Sprites/Priority-Bar");
            completeButton = Content.Load<Texture2D>("Sprites/Complete-Button");
            MenuButtons = new menuButtons();
            helpPage = new HelpPage(instimg);
            homePage = new HomePage(homeimg);
            todoPage = new TodoPage(todoimg);
            progressPage = new ProgressPage(progressimg);
            font = Content.Load<SpriteFont>("Fonts/StdFont");
            timefont = Content.Load<SpriteFont>("Fonts/Time");
            tinyfont = Content.Load<SpriteFont>("Fonts/Tinyfont");
            noMedal = Content.Load<Texture2D>("Sprites/no medal");
            bronzeMedal = Content.Load<Texture2D>("Sprites/bronze medal");
            silverMedal = Content.Load<Texture2D>("Sprites/silver medal");
            goldMedal = Content.Load<Texture2D>("Sprites/gold medal");
            #endregion
            gw = Window; //Use MonoGame's Windows Properties
            if (File.Exists(savepath)) 
            {
                using (var reader = new StreamReader(savepath, true)) // If save file exists
                {
                    int i = 0;
                    while (reader.ReadLine() != null) //Read until the end
                    {
                        i++;
                    }
                    var lastLine = File.ReadLines(savepath).Last();
                    points = Int32.Parse(lastLine); // Points = last line (most recent log)
                    tasksCompleted = i;
                }
            }

        }
        protected override void UnloadContent()
        {
        }
        public static void RegisterFocusedButtonForTextInput(System.EventHandler<TextInputEventArgs> method)
        {
            gw.TextInput += method; //Allow typing
        }
        public static void UnRegisterFocusedButtonForTextInput(System.EventHandler<TextInputEventArgs> method)
        {
            gw.TextInput -= method; //Unallow typing
        }
        public void CheckClickOnMyBox(Point mouseClick, bool isClicked, bool isReleased, Rectangle r)
        {
            if (r.Contains(mouseClick) && isClicked && isReleased && alreadyExists) //If Box Clicked then Start Typing
            {
                myBoxHasFocus = !myBoxHasFocus;
                if (myBoxHasFocus) //Call Typing Function
                {
                    RegisterFocusedButtonForTextInput(OnInput);
                    textState = Color.White;
                }
                else //Stop Typing Function
                {
                    UnRegisterFocusedButtonForTextInput(OnInput);
                    textState = Color.Gray;
                }
            }
        }
        public void OnInput(object sender, TextInputEventArgs e) //Typing logic
        {
            var k = e.Key;
            var c = e.Character;
            if (c == '\b') //If Backspace Pressed
            {
                if (myTextBoxDisplayCharacters.Length > 0) //Box cannot be empty
                {
                    myTextBoxDisplayCharacters.Remove(myTextBoxDisplayCharacters.Length - 1, 1); //Remove Letter
                }
            }
            else
            {
              myTextBoxDisplayCharacters.Append(c);
            }
        }
        protected override void Update(GameTime gameTime)
        {
            MouseState newState = Mouse.GetState(); //Create new mouse instant
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit(); //ESC to Exit Program
            MenuButtons.Update(gameTime); //Always Update menuButtons.Update
            todoPage.Update(gameTime);
            var isClicked = newState.LeftButton == ButtonState.Pressed;  //Check mouse click until
            var isReleased = oldState.LeftButton == ButtonState.Released; //mouse released
            CheckClickOnMyBox(oldState.Position, isClicked, isReleased, new Rectangle(350, 700, 620, 150)); //Draw Texbox
            if(myTextBoxDisplayCharacters.Length > 0) //Checks if the button is pressed before text input
            {
                emptyBox = false;
            }
            else
            {
                emptyBox = true;
            }
            if (TodoPage.clicked && myTextBoxDisplayCharacters.Length > 0 && TodoPage.priority != "" && count < 5) //if box clicked, not empty and less than 5 tabs
            {
                dataReady = true; //Add most recent tab
                Console.WriteLine(myTextBoxDisplayCharacters);
                tabContent.Add(myTextBoxDisplayCharacters.ToString(), TodoPage.priority); //Add text input to variable
                lowState = Color.White; //Reset priority
                medState = Color.White;
                highState = Color.White;
                TodoPage.clicked = false; //Reset box
                myTextBoxDisplayCharacters.Clear();
                TodoPage.priority = ""; 
                count++;
            }
            else
            {
                dataReady = false;
            }
            if (isClicked && isReleased) //If clicked complete
            {
                for (int i = 0; i < count; i++) //Loads constant that is multiplied for complete location
                {
                    if (newState.Y > 175 + 105 * i && newState.Y < ((175 + 105 * i) + 105)) //Check if mouse clicks at complete/delete
                    {
                        if (newState.X > 400 && newState.X < 450) //All delete buttons exist here
                        {
                            Console.WriteLine("Delete!");
                            tabContent.Remove(tabContent.ElementAt(i).Key); //Remove from dictionary
                            count--; //Remove from count
                        }
                        if (newState.X > 1300 && newState.X < 1400) //All complete buttons exist here
                        {
                            if (tabContent.Values.ElementAt(i) == "Low")
                            {
                                points += 10;
                            }
                            if (tabContent.Values.ElementAt(i) == "Med")
                            {
                                points += 25;
                            }
                            if (tabContent.Values.ElementAt(i) == "High")
                            {
                                points += 50;
                            }
                            Console.WriteLine("Complete!");
                            Console.WriteLine(points);
                            tabContent.Remove(tabContent.ElementAt(i).Key); //Remove tab
                            count--; //Remove from count
                            tasksCompleted++; //Increment 1 to total task completed
                            using (var writer = new StreamWriter(savepath, true)) //If save file exists
                            {
                                writer.WriteLine(points); //Log new points
                                writer.Dispose(); //Close streamline once done, prevents crashes and system overloads
                            }

                    }
                }
            }
        }
        oldState = newState; // Reset click
            base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        spriteBatch.Begin();
        #region Drawing Buttons
        spriteBatch.Draw(home_Button, new Rectangle(100, 50, 200, 200), mainState); //Home button       
        spriteBatch.Draw(todo_Button, new Rectangle(100, 250, 200, 200), todoState); // To-do button
        spriteBatch.Draw(level_Button, new Rectangle(100, 450, 200, 200), levelState); //Progress button
        spriteBatch.Draw(help_Button, new Rectangle(100, 650, 200, 200), helpState); //Help button
            #endregion

        #region Calling Page Change
            if (homeScreen)
            {
                homePage.Draw(spriteBatch);
            }
            if (todoScreen)
            {
                todoPage.Draw(spriteBatch);
            }
            if (progressScreen)
            {
                progressPage.Draw(spriteBatch);
            }
            if (helpScreen)
            {
                helpPage.Draw(spriteBatch);
            }
            #endregion

        if (alreadyExists)
        {
            spriteBatch.DrawString(font, myTextBoxDisplayCharacters, new Vector2(370, 760), Color.Black); //Draw user input
            foreach (KeyValuePair<string, string> kvp in tabContent) //Draw all tabs
            {
                for (int i = 0; i < count; i++)
                {
                    spriteBatch.Draw(deleteButton, new Rectangle(400, 175 + 105 * i, 50, 100), Color.White); //Delete button
                    spriteBatch.Draw(textBar, new Rectangle(450, 175 + 105 * i, 700, 100), Color.White); //Textbar
                    spriteBatch.Draw(priorityBar, new Rectangle(1150, 175 + 105 * i, 150, 100), Color.White); //Priority Bar
                    spriteBatch.Draw(completeButton, new Rectangle(1300, 175 + 105 * i, 100, 100), Color.White); //Complete Button
                    spriteBatch.DrawString(font, tabContent.Keys.ElementAt(i), new Vector2(460, 205 + 105 * i), Color.Black); //User Input
                    spriteBatch.DrawString(font, tabContent.Values.ElementAt(i).ToString(), new Vector2(1190, 205 + 105 * i), Color.Black); //Draw priority
                }
            }
        }
        spriteBatch.End();
        base.Draw(gameTime);
    }
}
}
