using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


public interface IServiceLife
{
    void Add(int pLife);
    int GetLife();
    string DisplayLife();
    void Subtract(int pLife);
}
class LifeService : IServiceLife
{
    private int nbLife;

    public LifeService()
    {
        nbLife = 3;
        ServiceLocator.RegisterService<IServiceLife>(this);
    }

    public void Add(int pLife)
    {
        nbLife += pLife;
    }

    public void Subtract(int pLife)
    {
        nbLife -= pLife;
    }

    public int GetLife()
    {
        return nbLife;
    }

    public string DisplayLife()
    {

       
       //Debug.WriteLine("Vie : " + nbLife);
        string mylife = "Vie : " + nbLife;
        return mylife;
       
    }
}

