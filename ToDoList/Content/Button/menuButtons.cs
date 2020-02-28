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
    public class menuButtons
    {
        public MouseState oldState; //Get status before click
        public void Update(GameTime gameTime)
        {
            MouseState newState = Mouse.GetState(); //Create new mouse instant

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released) //Clicking Logic
            {
                //All the buttons exist in the same X values, hence we can say the domain must be this
                if (newState.X >= 100 && newState.X <= 300)
                {
                    if (newState.Y >= 50 && newState.Y <= 250) // Home Button
                    {
                        #region Home Button Logic
                        Main.homeScreen = true; //home page is active
                        Main.todoScreen = false;
                        Main.progressScreen = false;
                        Main.helpScreen = false;
                        Main.helpState = Color.Gray;
                        Main.mainState = Color.White; //This is the Default Page
                        Main.todoState = Color.Gray;
                        Main.levelState = Color.Gray;
                        Main.alreadyExists = false;
                        #endregion
                    }
                    if (newState.Y >= 250 && newState.Y <= 450) //To-Do List Button
                    {
                        #region To-Do List Button Logic
                        Main.homeScreen = false;
                        Main.todoScreen = true; //to-do screen is active
                        Main.progressScreen = false;
                        Main.helpScreen = false;
                        Main.helpState = Color.Gray;
                        Main.mainState = Color.Gray;
                        Main.todoState = Color.White; //Click to show Active Tab
                        Main.levelState = Color.Gray;
                        Main.alreadyExists = true;
                        #endregion
                    }
                    if (newState.Y >= 450 && newState.Y <= 650) //Progress Button
                    {
                        #region Progress Button Logic
                        Main.homeScreen = false;
                        Main.todoScreen = false;
                        Main.progressScreen = true; //Progress screen is active
                        Main.helpScreen = false;
                        Main.helpState = Color.Gray;
                        Main.mainState = Color.Gray;
                        Main.todoState = Color.Gray;
                        Main.levelState = Color.White; //Click to show Active Tab
                        Main.alreadyExists = false;
                        #endregion
                    }
                    if (newState.Y >= 650 && newState.Y <= 850) // Help Button
                    {
                        #region Help Button Logic
                        Main.homeScreen = false;
                        Main.todoScreen = false;
                        Main.progressScreen = false;
                        Main.helpScreen = true; //Help screen is active
                        Main.helpState = Color.White; //Click to show Active Tab
                        Main.mainState = Color.Gray;
                        Main.todoState = Color.Gray;
                        Main.levelState = Color.Gray;
                        Main.alreadyExists = false;
                        #endregion
                    }
                }
            }

            oldState = newState; //Reset Click
        }
    }
}
