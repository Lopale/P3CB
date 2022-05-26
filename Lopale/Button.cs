using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lopale
{
    public delegate void OnClick(Button pSender);

    public class Button : Sprite
    {
        public bool isHover { get; private set; }
        private MouseState oldMouseState;
        public OnClick onClick { get; set; }

        public Button(Texture2D pTexture) : base(pTexture)
        {

        }

        public override void Update(GameTime pGameTime)
        {
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;

            if (BoundingBox.Contains(MousePos)) // Est ce que le rectangle du sprite contient la souris
            {
                if (!isHover)
                {
                    isHover = true;
                    Debug.WriteLine("Button hover");
                    
                }

            }
            else{
                isHover = false;
            }

            if (isHover)
            {
                if (newMouseState.LeftButton == ButtonState.Pressed
                    && oldMouseState.LeftButton == ButtonState.Released
                    )
                {
                    Debug.WriteLine("On vient de cliquer");
                    if(onClick != null)
                    {
                        onClick(this);
                    }
                }
            }

            oldMouseState = newMouseState;
            base.Update(pGameTime);
        }

    }
}
