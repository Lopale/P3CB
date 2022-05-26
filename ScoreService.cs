using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;




    public interface IServiceScore
    {
        void Add(int pPoint);
        int GetScore();
    void DisplayScore();
    }

    class ScoreService : IServiceScore
    {
        private int scorePoint;

        public ScoreService()
        {
            scorePoint = 0;
            ServiceLocator.RegisterService<IServiceScore>(this);
        }

        public void Add(int pPoint)
        {
            scorePoint += pPoint;
        }

        public int GetScore()
        {
            return scorePoint;
        }

        public void DisplayScore()
        {
            Debug.WriteLine("Le score est de "+scorePoint);
        }
    }
