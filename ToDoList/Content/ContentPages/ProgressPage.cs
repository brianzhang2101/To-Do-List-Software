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
    public class ProgressPage
    {
        public static List<Texture2D> progress; //Define a List With The Help Image
        public Texture2D Progressimg { get; set; } //Get Help Image
        public ProgressPage(Texture2D progressimg) //Execute this file
        {
            Progressimg = progressimg;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.progressimg, new Rectangle(300, 50, 1200, 800), Color.White); //Draw Screen
            spriteBatch.DrawString(Main.timefont, Convert.ToString(Main.points), new Vector2(590, 377), Color.Black); //Draw points
            spriteBatch.DrawString(Main.timefont, Convert.ToString(Main.tasksCompleted), new Vector2(803, 502), Color.Black); //Draw tasks completed
            if (Main.points >= 500 && Main.points < 2500) //Bronze requirements
            {
                spriteBatch.Draw(Main.bronzeMedal, new Rectangle(1000, 300, 350, 350), Color.White);
            }
            else if (Main.points >= 2500 && Main.points < 6000) //Silver requirements
            {
                spriteBatch.Draw(Main.silverMedal, new Rectangle(1000, 300, 350, 350), Color.White);
            }
           else  if (Main.points >= 6000) //Gold requirements
            {
                spriteBatch.Draw(Main.goldMedal, new Rectangle(1000, 300, 350, 350), Color.White);
            }
            else //Default: no medal
            {
                spriteBatch.Draw(Main.noMedal, new Rectangle(1000, 300, 350, 350), Color.White);
            }
        }
    }
}