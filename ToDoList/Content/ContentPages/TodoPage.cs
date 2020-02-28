using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project
{
    public class TodoPage
    {
        public static List<Texture2D> todo; //Define a List With The To-Do Image
        public Texture2D Todoimg { get; set; } //Get To-Do Image
        public static MouseState oldState; //Get status before click
        public static string priority = ""; //Original state is nothing
        public static bool clicked;
        public static bool errorPriority = false;
        public static bool errorText = false;
        public TodoPage(Texture2D todoimg) //Execute this file
        {
            Todoimg = todoimg;
        }
        public void Update(GameTime gameTime)
        {
            MouseState newState = Mouse.GetState(); //Create new mouse instant

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released) //If mouse pressed
            {
                if (newState.Y >= 770 && newState.Y <= 830) //All Priority buttons exist here
                {
                    if (newState.X > 985 && newState.X < 1085) //Low
                    {
                        priority = "Low";
                        Main.lowState = Color.Yellow;
                        Main.medState = Color.White;
                        Main.highState = Color.White;
                        Console.WriteLine("Low!");
                    }
                    if(newState.X > 1092 && newState.X < 1192) //Med
                    {
                        priority = "Med";
                        Main.lowState = Color.White;
                        Main.medState = Color.Orange;
                        Main.highState = Color.White;
                        Console.WriteLine("Med!");
                    }
                    if(newState.X >1200 && newState.X < 1300) //High
                    {
                        priority = "High";
                        Main.lowState = Color.White;
                        Main.medState = Color.White;
                        Main.highState = Color.Red;
                        Console.WriteLine("High!");
                    }
                }
                if (newState.Y> 680 && newState.Y < 820) //Text box exists here
                {
                    if(newState.X > 1280 && newState.X < 1400) //Add button 
                    {
                        if(priority != "" && Main.emptyBox == false) //Checks if either priority and text are empty
                        {
                            clicked = true; 
                            errorPriority = false;  //No errors
                            errorText = false;
                        }
                        else if(priority == "" && Main.emptyBox == false)
                        {
                            clicked = false;
                            errorText = false;
                            errorPriority = true; //Priority error
                            Console.WriteLine("Please select a priority!");
                        }
                        else if(priority !="" && Main.emptyBox)
                        {
                            clicked = false;
                            errorPriority = false;
                            errorText = true; //Text error
                            Console.WriteLine("Please enter your text input!");
                        }
                    }
                }
            }
            oldState = newState; //Reset click
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.todoimg, new Rectangle(300, 49, 1200, 802), Color.White); //Draw Screen
            spriteBatch.Draw(Main.textbox, new Rectangle(353, 702, 620, 149), Main.textState); //Draw textbox
            spriteBatch.Draw(Main.low_Button, new Rectangle(985, 770, 100, 60), Main.lowState); //Draw low
            spriteBatch.Draw(Main.med_Button, new Rectangle(1092, 770, 100, 60), Main.medState); //Draw med
            spriteBatch.Draw(Main.high_Button, new Rectangle(1200, 770, 100, 60), Main.highState); //Draw high
            if (errorText) //Error for text input
            {
                spriteBatch.DrawString(Main.tinyfont, "Please Enter Your Goal!", new Vector2(700, 730), Color.Red);
            }
            if (errorPriority) //Error for priority input
            {
                spriteBatch.DrawString(Main.tinyfont, "Please Select Your Priority!", new Vector2(1100, 730), Color.Red);
            }
        }
    }
}
