using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;




    public interface IServiceScore
    {
        void Add(int pPoint);
        int GetScore();
        string DisplayScore();
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

        public string DisplayScore()
        {
            string score = "Le score est de "+scorePoint;
            return score;
        }
    }
