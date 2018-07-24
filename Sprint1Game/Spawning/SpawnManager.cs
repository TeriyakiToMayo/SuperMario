using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.Spawning
{
    class SpawnManager : ISpawnManager
    {
        private int maxEnemies = 10;
        private int minEnemies = 5;
        private int maxEnemyTypes = 4;
        private int minEnemyTypes = 1;
        private int curEnemyCount = 0;
        private int randomRangeMin = 0;
        private int randomRangeMax = 2;
        Random rnd;
        private List<ISpawner> spawnerList;
        
        public SpawnManager()
        {
            spawnerList = new List<ISpawner>();
            rnd = new Random(Guid.NewGuid().GetHashCode());
        }
        public void AddSpawner(ISpawner s)
        {
            spawnerList.Add(s);
        }

        public void EnemyTerminated()
        {
            curEnemyCount--;
        }

        public void Update()
        {
            int enemyRandomNumber = rnd.Next(minEnemyTypes,maxEnemyTypes);
            
            int spawnerRandomNumber;

            if (spawnerList.Count > randomRangeMin)
                spawnerRandomNumber = rnd.Next(randomRangeMin, spawnerList.Count);
            else
                spawnerRandomNumber = randomRangeMin;

            // randomExecute adds variabilty to the spawning process
            int randomExecute = rnd.Next(randomRangeMin, randomRangeMax);
            if (curEnemyCount < maxEnemies)
            {
                
                if (randomExecute > randomRangeMin || curEnemyCount < minEnemies)
                {
                    bool retVal = false;
                    switch (enemyRandomNumber)
                    {
                        case 1:                          
                            retVal = spawnerList[spawnerRandomNumber].SpawnEnemy(ObjectType.Goomba); 
                            break;
                        case 2:   
                            retVal = spawnerList[spawnerRandomNumber].SpawnEnemy(ObjectType.Koopa);
                            break;
                        case 3:
                            retVal = spawnerList[spawnerRandomNumber].SpawnEnemy(ObjectType.Horse);
                            break;
                    }
                    if (retVal)
                    {
                        curEnemyCount++;
                    }
                }
            }
        }
    }
}
