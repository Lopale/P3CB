using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public interface IServiceControl
{
    bool PressRight();
    bool PressLeft();
    bool PressSpace();

}

class ControlService : IServiceControl
{
    public ControlService()
    {
        ServiceLocator.RegisterService<IServiceControl>(this);
    }

    public bool PressRight()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool PressLeft()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool PressSpace()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            return true;
        }
        else
        {
            return false;
        }

    }




}