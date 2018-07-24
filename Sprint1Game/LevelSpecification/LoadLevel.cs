using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.GameObjects;
using Sprint1Game.LevelSpecification;

namespace Sprint1Game.LevelSpecification
{
    public class LoadLevel : IDisposable
    {
        CSVReader readerBackground = new CSVReader(@"..\..\..\..\LevelSpecification\mario1-1backgroundFINAL.csv");
        CSVReader readerGameObjects = new CSVReader(@"..\..\..\..\LevelSpecification\mario1-1gameobjectsFINAL.csv");
        List<CSVReader> readerArray = new List<CSVReader>();
        TheGameObjectManager objectManager = new TheGameObjectManager();
        const int filesToRead = 2;
        public LoadLevel(int graphicsWidth, int graphicsHeight, TheGameObjectManager gameManager)
        {
            objectManager = gameManager;
            int a = graphicsWidth + graphicsHeight;
            a = a + 1;
        }

        public void loadTheLevel()
        {
            int csvRow = 0;
            int csvCol = 0;
            readerArray.Add(readerBackground);
            readerArray.Add(readerGameObjects);
            CSVRow row = new CSVRow();
            CSVWriter writer = new CSVWriter(objectManager);
            foreach(CSVReader r in readerArray){
                csvCol = 0;
                csvRow = 0;
                while (r.ReadRow(row))
                {
                    csvCol = 0;
                    foreach (string s in row)
                    {
                        writer.writeObject(csvCol * GameUtilities.BlockSize, csvRow * GameUtilities.BlockSize, s);
                        csvCol++;
                    }
                    csvRow++;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                readerBackground.Dispose();
                readerBackground = null;
                objectManager = null;
                readerGameObjects.Dispose();
                readerGameObjects = null;
            }
        }
    }
}
