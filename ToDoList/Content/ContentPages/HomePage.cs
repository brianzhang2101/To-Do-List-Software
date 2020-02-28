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
    public class HomePage
    {
        public static List<Texture2D> home; //Define a List With The Home Image
        DateTime dateTime = DateTime.UtcNow.Date; //Get the time
        public Texture2D Homeimg { get; set; } //Get Home Image
        public HomePage(Texture2D homeimg) //Execute this file
        {
            Homeimg = homeimg;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.homeimg, new Rectangle(300, 49, 1200, 802), Color.White); //Draw Screen
            spriteBatch.DrawString(Main.timefont, dateTime.ToString("dd") + dateTime.ToString(" MMMM ") + dateTime.ToString("yyyy"), new Vector2(750, 490), Color.Black); //Get date in date/month-name/year
            spriteBatch.DrawString(Main.timefont, Main.count.ToString(), new Vector2(1035, 641), Color.Black); //Draw time
        }
    }
}
