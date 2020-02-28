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
    public class HelpPage
    {
        public static List<Texture2D> inst; //Define a List With The Help Image
        public Texture2D Instimg { get; set; } //Get Help Image
        public HelpPage(Texture2D instimg)  //Execute this file
        {
            Instimg = instimg;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.instimg, new Rectangle(300, 50, 1200, 800), Color.White); //Draw Screen
        }

    }
}
